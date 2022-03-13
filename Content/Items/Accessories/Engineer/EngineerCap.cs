using FryGuysMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Engineer
{
    public class EngineerCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("5% increased engineer damage");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<EngineerDamage>() *= 1.05f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FlinxFur, 5)
                .AddIngredient(ItemID.MeteoriteBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}