using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class EvilBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increased movement speed and life regen\n" +
				"Decreased mana consumption\n" +
				"Increased damage and melee speed");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(gold: 650);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed *= 1.30f;
            player.GetAttackSpeed(DamageClass.Melee) *= 1.25f;
            player.GetDamage(DamageClass.Generic) *= 1.1f;
            player.lifeRegen += 5;
            player.manaCost /= 1.10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CrimsonBoots>())
                .AddIngredient(ModContent.ItemType<CrystalBoots>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CorruptBoots>())
                .AddIngredient(ModContent.ItemType<CrystalBoots>())
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}