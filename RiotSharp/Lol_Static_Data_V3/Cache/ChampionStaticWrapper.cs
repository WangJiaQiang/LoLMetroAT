using RiotSharp.Misc;

namespace RiotSharp.Lol_Static_Data_V3.Cache
{
    class ChampionStaticWrapper
    {
        public ChampionDtoStatic ChampionStatic { get; private set; }
        public Language Language { get; private set; }
        public ChampionData ChampionData { get; private set; }

        public ChampionStaticWrapper(ChampionDtoStatic champion, Language language, ChampionData championData)
        {
            ChampionStatic = champion;
            Language = language;
            ChampionData = championData;
        }
    }
}
