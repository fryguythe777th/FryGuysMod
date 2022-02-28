using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class MarbleBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased jump height and speed");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.jumpBoost = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Marble, 10)
                .AddIngredient(ItemID.Silk, 3)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}