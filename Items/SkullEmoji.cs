using Terraria.ModLoader;
using Terraria;
using ItemID = Terraria.ID.ItemID;
using Terraria.ID;

namespace HoodIrony.Items
{
    internal class SkullEmoji : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityMaterials[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 9999;
            Item.consumable = false;
            Item.value = Item.buyPrice(platinum: 1);
            Item.rare = ItemRarityID.Red;
        }
    }
}