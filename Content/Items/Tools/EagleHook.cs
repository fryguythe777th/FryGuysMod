using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Tools
{
    public class EagleHook : FourthOfJulyItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Rather fast hook with short range.\n" +
                "Knocks enemies upwards a significant amount when hit by the hook.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AmethystHook);
            Item.damage = 1;
            Item.DamageType = DamageClass.Default;
            Item.shootSpeed = 11f;
            Item.shoot = ModContent.ProjectileType<EagleHookProjectile>();
        }
    }

    public class EagleHookProjectile : ModProjectile
    {
        private static Asset<Texture2D> chainTexture;

        public override void Load()
        {
            chainTexture = ModContent.Request<Texture2D>("FryGuysMod/Content/Items/Tools/EagleHookChain");
        }

        public override void Unload()
        {
            chainTexture = null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eagle Hook");
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.GemHookAmethyst);
            Projectile.damage = 1;
            Projectile.DamageType = DamageClass.Melee;
        }

        public override float GrappleRange()
        {
            return 270;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 1;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 11f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 10;
        }

        public override bool PreDrawExtras()
        {
            FryGuyMethods.DrawProjectileChain(Projectile, -1, chainTexture);

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit) // this doesnt work??
        {
            FryGuyMethods.UpKnockback(Main.player[Projectile.owner], target, 12);
        }
    }
}
