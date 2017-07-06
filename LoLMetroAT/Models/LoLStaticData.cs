using RiotSharp.Lol_Static_Data_V3;

namespace LoLMetroAT.Models
{
    public class LoLStaticData
    {
        public static ItemListDtoStatic ItemsStaticData { get; set; }

        public static ChampionListDtoStatic ChampionsStaticData { get; set; }

        public static SummonerSpellListDtoStatic SummonerSpellsStaticData { get; set; }

        public static bool LoLStaticDataAlreadyLoaded()
        {
            bool blRet = false;

            if (ItemsStaticData == null || 
                ChampionsStaticData == null || 
                SummonerSpellsStaticData == null)

                blRet = false;
            else
                blRet = true;

            return blRet;
        }
    }
}
