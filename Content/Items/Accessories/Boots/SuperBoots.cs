using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class SuperBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased acceleration\n" +
				"30% increased movement speed");

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
            player.runAcceleration *= 1.20f;
            player.moveSpeed *= 1.30f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.ChlorophyteBar, 4)
                .AddIngredient(ItemID.SpectreBar, 4)
                .AddIngredient(ItemID.ShroomiteBar, 4)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}