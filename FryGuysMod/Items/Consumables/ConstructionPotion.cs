using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Items.Consumables
{
    public class ConstructionPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases your max number of sentries by 1");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.buffType = ModContent.BuffType<Buffs.ConstructionPotionBuff>();
            Item.buffTime = 21600;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Blinkroot)
                .AddIngredient(ItemID.VariegatedLardfish)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}