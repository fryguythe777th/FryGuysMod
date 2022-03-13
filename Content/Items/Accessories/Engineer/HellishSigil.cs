using FryGuysMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Engineer
{
    public class HellishSigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("3% increased engineer damage\n" +
                "Increases your max number of sentries by 1");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<EngineerDamage>() *= 1.03f;
            player.maxTurrets += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AshBlock, 25)
                .AddIngredient(ItemID.Fireblossom, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}