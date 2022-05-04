using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class CrimsonBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% damage\n" +
				"Increased life regeneration");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(silver: 450);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 1.1f;
            player.lifeRegen += 5;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimstoneBlock, 20)
                .AddIngredient(ItemID.ViciousMushroom, 80)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}