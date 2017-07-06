using RiotSharp.Lol_Static_Data_V3;
using RiotSharp.Misc;

namespace RiotSharp.Interfaces
{
    public interface IStaticRiotApi
    {
        #region Lol_Static_Data_V3

        /// <summary>
        /// Get a list of all items synchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="itemData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>An ItemListStatic object containing all items.</returns>
        ItemListDtoStatic GetStaticItems(Region region, ItemData itemData = ItemData.basic,
            Language language = Language.en_US);

        /// <summary>
        /// Get a list of all champions synchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="championData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A ChampionListStatic object containing all champions.</returns>
        ChampionListDtoStatic GetStaticChampions(Region region, ChampionData championData = ChampionData.basic,
            Language language = Language.en_US);

        /// <summary>
        /// Get a list of all summoner spells synchronously.
        /// </summary>
        /// <param name="region">Region from which to retrieve the data.</param>
        /// <param name="summonerSpellData">Data to retrieve.</param>
        /// <param name="language">Language of the data to be retrieved.</param>
        /// <returns>A SummonerSpellListStatic object containing all summoner spells.</returns>
        SummonerSpellListDtoStatic GetStaticSummonerSpells(Region region,
            SummonerSpellData summonerSpellData = SummonerSpellData.basic, Language language = Language.en_US);


        #endregion
    }
}
