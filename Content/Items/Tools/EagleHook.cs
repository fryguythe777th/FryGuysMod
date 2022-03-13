using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace FryGuysMod.Content.Items.Tools
{
    public class EagleHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Rather fast hook with short range.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.AmethystHook);
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
            return 350;
        }

        public override void NumGrappleHooks(Player player, ref int numHooks)
        {
            numHooks = 1;
        }

        public override void GrappleRetreatSpeed(Player player, ref float speed)
        {
            speed = 9f;
        }

        public override void GrapplePullSpeed(Player player, ref float speed)
        {
            speed = 14;
        }

        public override bool PreDrawExtras()
        {
            Vector2 playerCenter = Main.player[Projectile.owner].MountedCenter;
            Vector2 center = Projectile.Center;
            Vector2 directionToPlayer = playerCenter - Projectile.Center;
            float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
            float distanceToPlayer = directionToPlayer.Length();

            while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
            {
                directionToPlayer /= distanceToPlayer;
                directionToPlayer *= chainTexture.Height() - 1;
                center += directionToPlayer;
                directionToPlayer = playerCenter - center;
                distanceToPlayer = directionToPlayer.Length();

                Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

                Main.EntitySpriteDraw(chainTexture.Value, center - Main.screenPosition, chainTexture.Value.Bounds, drawColor, chainRotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);
            }

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit) // this doesnt work??
        {
            var y = -12 + target.knockBackResist;

            if (Main.LocalPlayer.kbGlove == true)
            {
                y -= 3;
            }

            if (y >= 0 || target.boss == true)
            {
                y = 0;
            }
            target.velocity = new Vector2(0, y);
        }
    }
}