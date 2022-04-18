using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class VolcanosparkBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Effects of Terraspark Boots\n" +
				"Effects of Ground Boots");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
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
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 420;
            player.lavaRose = true;
            player.accRunSpeed = 6.75f;
            player.moveSpeed += 0.08f;
            player.iceSkate = true;
            player.maxFallSpeed = 15f;
            player.jumpBoost = true;
            player.noFallDmg = true;
            player.rocketBoots = (player.vanityRocketBoots = 3);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TerrasparkBoots)
                .AddIngredient(ModContent.ItemType<GroundBoots>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}