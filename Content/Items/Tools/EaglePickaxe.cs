using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Tools
{
    public class EaglePickaxe : FourthOfJulyItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A very light and fast pickaxe but with a rather short range.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Melee;
            Item.width = 35;
            Item.height = 35;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.pick = 49;
            Item.value = Item.sellPrice(silver: 20);
            Item.rare = ItemRarityID.White;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            FryGuyMethods.UpKnockback(player, target, 6);
        }
    }
}
// TODOLIST
// NERF THIS PICKAXE A LOT - DONE
// FIX MULTIPLE MESSAGES SHOWING WHEN YA CLICK CALENDAR - DONE
// FIX CALENDAR SECRETLY KEEPING IT ON HALLOWEEN FOREVER - DONE (I HOPE)
// MAKE EAGLE SWORD USE ANIMATION - 
// MAKE EAGLE HOOK - DONE
// MAKE EAGLE YOYO - DONE
// PERHAPS MAKE EAGLE WEAPON KNOCKBACK SCALE WITH KNOCKBACK ACCESSORIES?? - DONE (easy dub)
