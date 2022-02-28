using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Consumables.Summons
{
    public class PatrioticPyrotechnics : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Initiates the Night of Light");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.HoldingOut;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
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