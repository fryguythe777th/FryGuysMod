using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class CrystalBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("10% decreased mana usage\n" +
				"+10% movement speed");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(silver: 450);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost /= 1.10f;
            player.moveSpeed *= 1.10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrystalShard, 20)
                .AddIngredient(ItemID.PearlstoneBlock, 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}