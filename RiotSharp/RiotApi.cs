using Newtonsoft.Json;
using RiotSharp.Champion_Mastery_V3;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.League_V3;
using RiotSharp.Match_V3;
using RiotSharp.Match_V3.Enums;
using RiotSharp.Misc;
using RiotSharp.Summoner_V3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp
{
    public class RiotApi : IRiotApi
    {
        #region Private Fields
        private const string Summoner_V3_RootUrl = "/lol/summoner/v3/summoners";
        private const string Summoner_V3_ByAccountIdUrl = "/by-account/{0}";
        private const string Summoner_V3_ByNameUrl = "/by-name/{0}";
        private const string Summoner_V3_BySummonerIdUrl = "/{0}";

        private const string Match_V3_RootUrl = "/lol/match/v3/";
        private const string Match_V3_Url = "matches";
        private const string MatchAllList_V3_ByAccountIdUrl = "matchlists/by-account/{0}";
        private const string MatchRecentList_V3_ByAccountIdUrl = "matchlists/by-account/{0}/recent";

        //jp1.api.riotgames.com/lol/champion-mastery/v3/champion-masteries/by-summoner/6583612
        //jp1.api.riotgames.com/lol/champion-mastery/v3/champion-masteries/by-summoner/6583612/by-champion/49
        private const string ChampionMastery_V3_RootUrl = "/lol/champion-mastery/v3/";
        private const string ChampionMastery_V3_BySummonerId = "champion-masteries/by-summoner/{0}";
        private const string ChampionMastery_V3_ByChampionId = "champion-masteries/by-summoner/{0}/by-champion/{1}";


        //jp1.api.riotgames.com/lol/league/v3/positions/by-summoner/6583612
        //jp1.api.riotgames.com/lol/league/v3/leagues/by-summoner/6583612
        private const string League_V3_RootUrl = "/lol/league/v3/";
        private const string League_V3_Leagues = "leagues/by-summoner/{0}";
        private const string League_V3_Positions = "positions/by-summoner/{0}";


        private const string IdUrl = "/{0}";

        // Used in call which have a maximum number of items you can retrieve in a single call
        private const int MaxNrSummoners = 40;
        private const int MaxNrMasteryPages = 40;
        private const int MaxNrRunePages = 40;
        private const int MaxNrLeagues = 10;
        private const int MaxNrEntireLeagues = 10;

        private IRateLimitedRequester requester;

        private static RiotApi instance;
        #endregion

        /// <summary>
        /// Get the instance of RiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <param name="rateLimitPer10s">The 10 seconds rate limit for your production api key.</param>
        /// <param name="rateLimitPer10m">The 10 minutes rate limit for your production api key.</param>
        /// <returns>The instance of RiotApi.</returns>
        public static RiotApi GetInstance(string apiKey, int rateLimitPer10s = 10, int rateLimitPer10m = 500)
        {
            if (instance == null || Requesters.RiotApiRequester == null ||
                apiKey != Requesters.RiotApiRequester.ApiKey ||
                rateLimitPer10s != Requesters.RiotApiRequester.RateLimitPer10S ||
                rateLimitPer10m != Requesters.RiotApiRequester.RateLimitPer10M)
            {
                instance = new RiotApi(apiKey, rateLimitPer10s, rateLimitPer10m);
            }
            return instance;
        }

        private RiotApi(string apiKey, int rateLimitPer10s, int rateLimitPer10m)
        {
            Requesters.RiotApiRequester = new RateLimitedRequester(apiKey, rateLimitPer10s, rateLimitPer10m);
            requester = Requesters.RiotApiRequester;
        }

        public RiotApi(IRateLimitedRequester rateLimitedRequester)
        {
            if (rateLimitedRequester == null)
                throw new ArgumentNullException("rateLimitedRequester");
            requester = rateLimitedRequester;
        }

        #region Champion_Mastery_V3

        public List<ChampionMasteryDTO> GetChampionMasteries(Region region, long summonerId)
        {
            var url = string.Format(ChampionMastery_V3_RootUrl + ChampionMastery_V3_BySummonerId, summonerId);

            var json = requester.CreateGetRequest(
                url, region, usePlatforms: true);

            return JsonConvert.DeserializeObject<List<ChampionMasteryDTO>>(json);
        }

        #endregion

        #region Match_V3

        /// <summary>
        /// Get matchlist for last 20 matches played on given account ID and platform ID.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="accountId">The account ID.</param>
        /// <returns>MatchlistDto</returns>
        public MatchlistDto GetMatchRecentListByAccountId(Region region, long accountId)
        {
            var json = requester.CreateGetRequest(
                string.Format(Match_V3_RootUrl + MatchRecentList_V3_ByAccountIdUrl, accountId), 
                region, usePlatforms: true);

            return JsonConvert.DeserializeObject<MatchlistDto>(json);
        }

        /// <summary>
        /// Get the list of matches of a specific summoner synchronously.
        /// </summary>
        /// <param name="region">Region in which the summoner is.</param>
        /// <param name="summonerId">Summoner ID for which you want to retrieve the match list.</param>
        /// <param name="championIds">List of champion IDS to use for fetching games.</param>
        /// <param name="rankedQueues">List of ranked queue types to use for fetching games. Non-ranked queue types
        ///  will be ignored.</param>
        /// <param name="seasons">List of seasons for which to filter the match list by.</param>
        /// <param name="beginTime">The earliest date you wish to get matches from.</param>
        /// <param name="endTime">The latest date you wish to get matches from.</param>
        /// <param name="beginIndex">The begin index to use for fetching matches.</param>
        /// <param name="endIndex">The end index to use for fetching matches.</param>
        /// <returns>A list of Match references object.</returns>
        public MatchlistDto GetMacthAllByAccountId(Region region, long accountId, List<long> championIds = null, List<string> rankedQueues = null,
            List<Season> seasons = null, DateTime? beginTime = null, DateTime? endTime = null,
            int? beginIndex = null, int? endIndex = null)
        {
            var addedArguments = new List<string> {
                    string.Format("beginIndex={0}", beginIndex),
                    string.Format("endIndex={0}", endIndex),
            };
            if (beginTime != null)
            {
                addedArguments.Add(string.Format("beginTime={0}", beginTime.Value.ToLong()));
            }
            if (endTime != null)
            {
                addedArguments.Add(string.Format("endTime={0}", endTime.Value.ToLong()));
            }
            if (championIds != null)
            {
                addedArguments.Add(string.Format("championIds={0}", Util.BuildIdsString(championIds)));
            }
            if (rankedQueues != null)
            {
                addedArguments.Add(string.Format("rankedQueues={0}", Util.BuildQueuesString(rankedQueues)));
            }
            if (seasons != null)
            {
                addedArguments.Add(string.Format("seasons={0}", Util.BuildSeasonString(seasons)));
            }

            var json = requester.CreateGetRequest(
                string.Format(Match_V3_RootUrl + MatchAllList_V3_ByAccountIdUrl, accountId),
                region,
                addedArguments,
                usePlatforms: true);
            return JsonConvert.DeserializeObject<MatchlistDto>(json);

            //var json = requester.CreateGetRequest(
            //    string.Format(Match_V3_RootUrl + MatchAllList_V3_ByAccountIdUrl, accountId),
            //    region, usePlatforms: true);

            //return JsonConvert.DeserializeObject<MatchlistDto>(json);
        }

        public MatchDto GetMatch(Region region, long matchId, bool includeTimeline = false)
        {
            var json = requester.CreateGetRequest(
                string.Format(Match_V3_RootUrl + Match_V3_Url, region.ToString()) + string.Format(IdUrl, matchId),
                region,
                includeTimeline
                    ? new List<string> { string.Format("includeTimeline={0}", includeTimeline.ToString().ToLower()) }
                    : null, usePlatforms: true);
            return JsonConvert.DeserializeObject<MatchDto>(json);
        }

        #endregion

        #region Summoner_V3
        public SummonerDTO GetSummonerByAccountId(Region region, long accountId)
        {
            var json = requester.CreateGetRequest(
                string.Format(Summoner_V3_RootUrl + Summoner_V3_ByAccountIdUrl, accountId), region, usePlatforms: true);
            var obj = JsonConvert.DeserializeObject<SummonerDTO>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<SummonerDTO> GetSummonerByAccountIdAsync(Region region, long accountId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(Summoner_V3_RootUrl + Summoner_V3_ByAccountIdUrl, accountId), region, usePlatforms: true);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SummonerDTO>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public SummonerDTO GetSummonerBySummonerId(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(Summoner_V3_RootUrl + Summoner_V3_BySummonerIdUrl, summonerId), region, usePlatforms: true);
            var obj = JsonConvert.DeserializeObject<SummonerDTO>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<SummonerDTO> GetSummonerBySummonerIdAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(Summoner_V3_RootUrl + Summoner_V3_BySummonerIdUrl, summonerId), region, usePlatforms: true);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SummonerDTO>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public SummonerDTO GetSummonerByName(Region region, string summonerName)
        {
            var json = requester.CreateGetRequest(
                string.Format(Summoner_V3_RootUrl + Summoner_V3_ByNameUrl, summonerName), region, usePlatforms: true);
            var obj = JsonConvert.DeserializeObject<SummonerDTO>(json);
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }

        public async Task<SummonerDTO> GetSummonerByNameAsync(Region region, string summonerName)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(Summoner_V3_RootUrl + Summoner_V3_ByNameUrl, summonerName), region, usePlatforms: true);
            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SummonerDTO>(json)));
            if (obj != null)
            {
                obj.Region = region;
            }
            return obj;
        }
        #endregion

        #region League_V3

        /// <summary>
        /// Get leagues in all queues for a given summoner ID.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns></returns>
        public List<LeagueListDTO> GetLeaguesBySummoner(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(League_V3_RootUrl + League_V3_Leagues, summonerId), region, usePlatforms: true);
            var obj = JsonConvert.DeserializeObject<List<LeagueListDTO>>(json);

            return obj;
        }

        public List<LeaguePositionDTO> GetLeaguePositionsBySummoner(Region region, long summonerId)
        {
            var json = requester.CreateGetRequest(
                string.Format(League_V3_RootUrl + League_V3_Positions, summonerId), region, usePlatforms: true);
            var obj = JsonConvert.DeserializeObject<List<LeaguePositionDTO>>(json);

            return obj;
        }

        public async Task<List<LeaguePositionDTO>> GetLeaguePositionsBySummonerAsync(Region region, long summonerId)
        {
            var json = await requester.CreateGetRequestAsync(
                string.Format(League_V3_RootUrl + League_V3_Positions, summonerId), region, usePlatforms: true);

            var obj = (await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<LeaguePositionDTO>>(json)));

            return obj;
        }

        #endregion
    }
}
