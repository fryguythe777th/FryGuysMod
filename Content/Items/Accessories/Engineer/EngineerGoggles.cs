using FryGuysMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Engineer
{
    public class EngineerGoggles : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("10% increased engineer crit chance");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.buyPrice(gold: 25);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance<EngineerDamage>() += 10;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Lens, 2)
                .AddIngredient(ItemID.MeteoriteBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
