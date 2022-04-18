using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class CorruptBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+20% movement speed\n" +
				"+25% melee speed");

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
            player.moveSpeed *= 1.20f;
            player.GetAttackSpeed(DamageClass.Melee) *= 1.25f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.EbonstoneBlock, 20)
                .AddIngredient(ItemID.VileMushroom, 80)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}