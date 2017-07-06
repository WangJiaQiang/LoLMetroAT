using RiotSharp.Misc;

namespace RiotSharp.Lol_Static_Data_V3.Cache
{
    class ChampionListStaticWrapper
    {
        public ChampionListDtoStatic ChampionListStatic { get; private set; }
        public Language Language { get; private set; }
        public ChampionData ChampionData { get; private set; }

        public ChampionListStaticWrapper(ChampionListDtoStatic champions, Language language, ChampionData championData)
        {
            ChampionListStatic = champions;
            Language = language;
            ChampionData = championData;
        }
    }
}
