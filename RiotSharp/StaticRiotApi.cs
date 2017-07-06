using Newtonsoft.Json;
using RiotSharp.Http;
using RiotSharp.Http.Interfaces;
using RiotSharp.Interfaces;
using RiotSharp.Lol_Static_Data_V3;
using RiotSharp.Lol_Static_Data_V3.Cache;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;

namespace RiotSharp
{
    public class StaticRiotApi : IStaticRiotApi
    {
        #region Private Fields
        private const string StaticDataRootUrl = "/lol/static-data/v3/";

        private const string ChampionsUrl = "champions";
        private const string ChampionByIdUrl = "champions/{0}";
        private const string ChampionsCacheKey = "champions";
        private const string ChampionByIdCacheKey = "champion";

        private const string ItemsUrl = "items";
        private const string ItemByIdUrl = "items/{0}";
        private const string ItemsCacheKey = "items";
        private const string ItemByIdCacheKey = "item";

        private const string LanguageStringsUrl = "language-strings";
        private const string LanguageStringsCacheKey = "language-strings";

        private const string LanguagesUrl = "languages";
        private const string LanguagesCacheKey = "languages";

        private const string MapsUrl = "maps";
        private const string MapsCacheKey = "maps";

        private const string MasteriesUrl = "masteries";
        private const string MasteryByIdUrl = "masteries/{0}";
        private const string MasteriesCacheKey = "masteries";
        private const string MasteryByIdCacheKey = "mastery";

        private const string ProfileIconsUrl = "profile-icons";
        private const string ProfileIconsCacheKey = "profile-icons";

        private const string RealmsUrl = "realms";
        private const string RealmsCacheKey = "realms";

        private const string RunesUrl = "runes";
        private const string RuneByIdUrl = "runes/{0}";
        private const string RunesCacheKey = "runes";
        private const string RuneByIdCacheKey = "rune";

        private const string SummonerSpellsUrl = "summoner-spells";
        private const string SummonerSpellsCacheKey = "summoner-spells";
        private const string SummonerSpellByIdUrl = "summoner-spells/{0}";
        private const string SummonerSpellByIdCacheKey = "summoner-spell";

        private const string VersionsUrl = "versions";
        private const string VersionsCacheKey = "versions";

        private const string IdUrl = "/{0}";

        private const string RootDomain = "global.api.pvp.net";

        private const string StaticTagsFormat = "tags={0}";

        private IRequester requester;

        private ICache cache;
        private readonly TimeSpan DefaultSlidingExpiry = new TimeSpan(0, 30, 0);

        private static StaticRiotApi instance;
        #endregion

        /// <summary>
        /// Get the instance of StaticRiotApi.
        /// </summary>
        /// <param name="apiKey">The api key.</param>
        /// <returns>The instance of StaticRiotApi.</returns>
        public static StaticRiotApi GetInstance(string apiKey)
        {
            if (instance == null ||
                Requesters.StaticApiRequester == null ||
                apiKey != Requesters.StaticApiRequester.ApiKey)
            {
                instance = new StaticRiotApi(apiKey);
            }
            return instance;
        }

        private StaticRiotApi(string apiKey)
        {
            Requesters.StaticApiRequester = new Requester(apiKey);
            requester = Requesters.StaticApiRequester;
            cache = new Cache();
        }

        public StaticRiotApi(IRequester requester, ICache cache)
        {
            if (requester == null)
                throw new ArgumentNullException("requester");
            if (cache == null)
                throw new ArgumentNullException("cache");
            this.requester = requester;
            this.cache = cache;
        }


        #region Lol_Static_Data_V3


        #region Static Items

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="itemData"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public ItemListDtoStatic GetStaticItems(Region region, ItemData itemData = ItemData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ItemListStaticWrapper>(ItemsCacheKey);
            if (wrapper == null || language != wrapper.Language || itemData != wrapper.ItemData)
            {
                var json = requester.CreateGetRequest(StaticDataRootUrl + ItemsUrl, region,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        itemData == ItemData.basic ?
                        string.Empty :
                        string.Format(StaticTagsFormat, itemData.ToString())
                    });
                var items = JsonConvert.DeserializeObject<ItemListDtoStatic>(json);
                wrapper = new ItemListStaticWrapper(items, language, itemData);
                cache.Add(ItemsCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.ItemListStatic;
        }

        #endregion


        #region Static Champions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="championData"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public ChampionListDtoStatic GetStaticChampions(Region region, ChampionData championData = ChampionData.basic,
            Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, ChampionListStaticWrapper>(ChampionsCacheKey);
            if (wrapper == null || language != wrapper.Language || championData != wrapper.ChampionData)
            {
                var json = requester.CreateGetRequest(StaticDataRootUrl + ChampionsUrl, region,
                    new List<string> {
                        string.Format("locale={0}", language.ToString()),
                        championData == ChampionData.basic ?
                        string.Empty :
                        string.Format(StaticTagsFormat, championData.ToString())
                    });
                var champs = JsonConvert.DeserializeObject<ChampionListDtoStatic>(json);
                wrapper = new ChampionListStaticWrapper(champs, language, championData);
                cache.Add(ChampionsCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.ChampionListStatic;
        }


        #endregion


        #region Static Summoner Spells

        /// <summary>
        /// 
        /// </summary>
        /// <param name="region"></param>
        /// <param name="summonerSpellData"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public SummonerSpellListDtoStatic GetStaticSummonerSpells(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US)
        {
            var wrapper = cache.Get<string, SummonerSpellListStaticWrapper>(SummonerSpellsCacheKey);
            if (wrapper == null || wrapper.Language != language || wrapper.SummonerSpellData != summonerSpellData)
            {
                var json = requester.CreateGetRequest(StaticDataRootUrl + SummonerSpellsUrl, region,
                    new List<string>
                    {
                        string.Format("locale={0}", language.ToString()),
                        summonerSpellData == SummonerSpellData.basic ?
                        string.Empty :
                        string.Format(StaticTagsFormat, summonerSpellData.ToString())
                    });
                var spells = JsonConvert.DeserializeObject<SummonerSpellListDtoStatic>(json);
                wrapper = new SummonerSpellListStaticWrapper(spells, language, summonerSpellData);
                cache.Add(SummonerSpellsCacheKey, wrapper, DefaultSlidingExpiry);
            }
            return wrapper.SummonerSpellListStatic;
        }

        #endregion


        #endregion
    }
}
