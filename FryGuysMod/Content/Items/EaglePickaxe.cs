using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.XNA.Framework;

namespace FryGuysMod.Content.Items.Tools
{
    public class EaglePickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A very light and fast pickaxe but with a rather short range.");
        }
        
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Melee;
            Item.width = 35;
            Item.height = 35;
            Item.useTime = 6;
            Item.useAnimation = 6;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1;
            Item.useSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.pick = 51;
        }
    }
}