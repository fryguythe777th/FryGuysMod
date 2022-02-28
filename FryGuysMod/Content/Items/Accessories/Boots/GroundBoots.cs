using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class GroundBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased fall speed\n" +
				"Increased jump height and speed\n" +
				"Negates fall damage");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxFallSpeed = 15f;
            player.jumpBoost = true;
            player.noFallDmg = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<MarbleBoots>())
                .AddIngredient(ModContent.ItemType<GraniteBoots>())
                .AddIngredient(ModContent.ItemType<SpiderBoots>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}