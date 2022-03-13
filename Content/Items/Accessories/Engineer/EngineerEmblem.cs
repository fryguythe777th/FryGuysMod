using FryGuysMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Engineer
{
    public class EngineerEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("15% increased engineer damage");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<EngineerDamage>() *= 1.15f;
        }

        public override void AddRecipes()
        {
            Mod.CreateRecipe(ItemID.AvengerEmblem)
                .AddIngredient<EngineerEmblem>()
                .AddIngredient(ItemID.SoulofMight, 5)
                .AddIngredient(ItemID.SoulofFright, 5)
                .AddIngredient(ItemID.SoulofSight, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}