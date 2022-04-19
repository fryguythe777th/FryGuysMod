using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using FryGuysMod.Content.Items.Weapons.Engineer;

namespace FryGuysMod.Common
{
	public class FryGuyProjectile : GlobalProjectile
	{
        public override bool PreAI(Projectile projectile)
        {
            Player player = Main.player[Main.myPlayer];
            FryGuyPlayer modPlayer = player.GetModPlayer<FryGuyPlayer>();

            if(modPlayer.SoldierHat == true && projectile.friendly && projectile.DamageType == DamageClass.Ranged)
            {
                projectile.velocity *= 1.10f;
            }

            return true;
        }
	
	public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Main.myPlayer];
            FryGuyPlayer modPlayer = player.GetModPlayer<FryGuyPlayer>();

            if (modPlayer.HotLead == true && projectile.friendly && projectile.DamageType == DamageClass.Ranged)
            {
                target.AddBuff(BuffID.OnFire, 100, false);
            }
        }

        public override void OnHitPvp(Projectile projectile, Player target, int damage, bool crit)
        {
            Player player = Main.player[Main.myPlayer];
            FryGuyPlayer modPlayer = player.GetModPlayer<FryGuyPlayer>();

            if (modPlayer.HotLead == true && projectile.friendly && projectile.DamageType == DamageClass.Ranged)
            {
                target.AddBuff(BuffID.OnFire, 100, false);
            }
        }

        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (projectile.type == ProjectileID.Flames)
            {
                FryGuyMethods.CheckDestructibility(1, oldVelocity, projectile);

                return false;
            }
            else if (projectile.type == ModContent.ProjectileType<DemonTongueTip>())
            {
                FryGuyMethods.CheckDestructibility(5, oldVelocity, projectile);

                return true;
            }
            else
            {
                return projectile.tileCollide;
            }
        }
    }
}
