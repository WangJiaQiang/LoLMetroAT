using RiotSharp.Misc;

namespace RiotSharp.Lol_Static_Data_V3.Cache
{
    class ItemStaticWrapper
    {
        public ItemDtoStatic ItemStatic { get; private set; }
        public Language Language { get; private set; }
        public ItemData ItemData { get; private set; }

        public ItemStaticWrapper(ItemDtoStatic item, Language language, ItemData itemData)
        {
            ItemStatic = item;
            Language = language;
            ItemData = itemData;
        }
    }
}
