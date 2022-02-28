using FryGuysMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Engineer
{
    public class EngineerGuise : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("25% increased engineer damage\n" +
                "15% increased engineer crit chance");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<EngineerDamage>() *= 1.25f;
            player.GetCritChance<EngineerDamage>() += 15;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<EngineerEmblem>()
                .AddIngredient<EngineerCap>()
                .AddIngredient<EngineerGoggles>()
                .AddIngredient(ItemID.SoulofSight, 2)
                .AddIngredient(ItemID.SoulofMight, 2)
                .AddIngredient(ItemID.HallowedBar, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}