using RiotSharp.Misc;

namespace RiotSharp.Lol_Static_Data_V3.Cache
{
    class ItemListStaticWrapper
    {
        public ItemListDtoStatic ItemListStatic { get; private set; }
        public Language Language { get; private set; }
        public ItemData ItemData { get; private set; }

        public ItemListStaticWrapper(ItemListDtoStatic items, Language language, ItemData itemData)
        {
            ItemListStatic = items;
            Language = language;
            ItemData = itemData;
        }
    }
}
