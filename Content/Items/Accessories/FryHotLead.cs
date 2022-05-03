using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories
{
    public class FryHotLead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hot Lead");

            Tooltip.SetDefault("Ranged attacks inflict fire to enemies.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 2);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FryGuyPlayer>().HotLead = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 6)
                .AddIngredient(ItemID.MagmaStone)
                .AddIngredient(ModContent.GetInstance<Gunpowder>(), 2)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
