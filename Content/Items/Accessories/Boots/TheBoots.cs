using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Boots;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class TheBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("All effects of Volcanospark Boots\n" +
				"All effects of Super Boots\n" +
				"All effects of Evil Boots");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.value = Item.buyPrice(platinum: 1, gold: 50);
            Item.rare = ItemRarityID.Red;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //terra boot effects
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 420;
            player.lavaRose = true;
            player.accRunSpeed = 6.75f;
            player.moveSpeed += 0.08f;
            player.iceSkate = true;
            player.rocketBoots = (player.vanityRocketBoots = 4);
            //ground boot effects
            player.maxFallSpeed = 15f;
            player.jumpBoost = true;
            player.noFallDmg = true;
            //super boot effects
            player.runAcceleration *= 1.20f;
            //evil boot effects
            player.GetAttackSpeed(DamageClass.Melee) *= 1.25f;
            player.GetDamage(DamageClass.Generic) *= 1.1f;
            player.lifeRegen += 5;
            player.manaCost /= 1.10f;
            //shared effects
            player.moveSpeed *= 1.6f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<VolcanosparkBoots>())
                .AddIngredient(ModContent.ItemType<SuperBoots>())
                .AddIngredient(ModContent.ItemType<EvilBoots>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}