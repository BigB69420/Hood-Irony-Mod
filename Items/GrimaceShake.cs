using Terraria.ModLoader;
using Terraria;
using ItemID = Terraria.ID.ItemID;
using Terraria.ID;

namespace HoodIrony.Items
{
    internal class GrimaceShake : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityMaterials[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 7;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.UseSound = SoundID.Item3;
            Item.autoReuse = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Purple;
            Item.buffType = BuffID.Stinky;
            Item.buffTime = 60*1000;


        }
    }
}