using RiotSharp.Champion_Mastery_V3;
using RiotSharp.League_V3;
using RiotSharp.Lol_Static_Data_V3;
using RiotSharp.Match_V3;
using RiotSharp.Match_V3.Enums;
using RiotSharp.Misc;
using RiotSharp.Summoner_V3;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RiotSharp.Interfaces
{
    /// <summary>
    /// Entry point for the API.
    /// </summary>
    public interface IRiotApi
    {
        #region Champion_Mastery_V3

        /// <summary>
        /// Gets all champions mastery by summoner ID synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns>All champions mastery entries for the specified summoner ID.</returns>
        List<ChampionMasteryDTO> GetChampionMasteries(Region region, long summonerId);

        #endregion

        #region Champion_V3

        #endregion

        #region League_V3

        /// <summary>
        /// Get leagues in all queues for a given summoner ID.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns></returns>
        List<LeagueListDTO> GetLeaguesBySummoner(Region region, long summonerId);


        /// <summary>
        /// Get league positions in all queues for a given summoner ID. synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns></returns>
        List<LeaguePositionDTO> GetLeaguePositionsBySummoner(Region region, long summonerId);

        /// <summary>
        /// Get league positions in all queues for a given summoner ID.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">ID of the summoner for which to retrieve champion mastery.</param>
        /// <returns></returns>
        Task<List<LeaguePositionDTO>> GetLeaguePositionsBySummonerAsync(Region region, long summonerId);

        #endregion

        #region Lol_Status_V3

        #endregion

        #region Masteries_V3

        #endregion

        #region Match_V3

        /// <summary>
        /// Get matchlist for last 20 matches played on given account ID and platform ID.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="accountId">The account ID.</param>
        /// <returns>MatchlistDto</returns>
        MatchlistDto GetMatchRecentListByAccountId(Region region, long accountId);

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
        MatchlistDto GetMacthAllByAccountId(Region region, long accountId, List<long> championIds = null, List<string> rankedQueues = null,
            List<Season> seasons = null, DateTime? beginTime = null, DateTime? endTime = null,
            int? beginIndex = null, int? endIndex = null);

        #endregion

        #region Runes_V3

        #endregion

        #region Spectator_V3

        #endregion

        #region Summoner_V3
        /// <summary>
        /// Get a summoner by summoner id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        SummonerDTO GetSummonerBySummonerId(Region region, long summonerId);

        /// <summary>
        /// Get a summoner by summoner id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerId">Id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<SummonerDTO> GetSummonerBySummonerIdAsync(Region region, long summonerId);

        /// <summary>
        /// Get a summoner by account id asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="accountId">Account id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<SummonerDTO> GetSummonerByAccountIdAsync(Region region, long accountId);

        /// <summary>
        /// Get a summoner by account id synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="accountId">Account id of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        SummonerDTO GetSummonerByAccountId(Region region, long accountId);

        /// <summary>
        /// Get a summoner by name synchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        SummonerDTO GetSummonerByName(Region region, string summonerName);

        /// <summary>
        /// Get a summoner by name asynchronously.
        /// </summary>
        /// <param name="region">Region in which you wish to look for a summoner.</param>
        /// <param name="summonerName">Name of the summoner you're looking for.</param>
        /// <returns>A summoner.</returns>
        Task<SummonerDTO> GetSummonerByNameAsync(Region region, string summonerName);
        #endregion

        #region Tournament_Stub_V3

        #endregion

        #region Tournament_V3

        #endregion
    }
}
