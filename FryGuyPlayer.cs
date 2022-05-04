using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace FryGuysMod
{
	public class FryGuyPlayer : ModPlayer
	{
        public bool PyrotechnicBadge;
		public bool SoldierHat;
		public bool HotLead;
		public bool RiddleOfLead;

        public override void ResetEffects()
        {
			PyrotechnicBadge = false;
			SoldierHat = false;
			HotLead = false;
			RiddleOfLead = false;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
			if(PyrotechnicBadge == true)
            {
				var source = target.GetSource_FromAI();
				Vector2 velocity = new Vector2(0, 0);
				var fireworkChance = WorldGen.genRand.Next(5);

				if (fireworkChance == 0)
				{
					switch (WorldGen.genRand.Next(4))
					{
						case 0:
							int b = Projectile.NewProjectile(source, target.Center, velocity, ProjectileID.RocketFireworkBlue, damage, knockback, Player.whoAmI, 0, 1);
							Main.projectile[b].timeLeft = 1;
							Main.projectile[b].hide = true;
							return;

						case 1:
							int r = Projectile.NewProjectile(source, target.Center, velocity, ProjectileID.RocketFireworkRed, damage, knockback, Player.whoAmI, 0, 1);
							Main.projectile[r].timeLeft = 1;
							Main.projectile[r].hide = true;
							return;

						case 2:
							int g = Projectile.NewProjectile(source, target.Center, velocity, ProjectileID.RocketFireworkGreen, damage, knockback, Player.whoAmI, 0, 1);
							Main.projectile[g].timeLeft = 1;
							Main.projectile[g].hide = true;
							return;

						case 3:
							int y = Projectile.NewProjectile(source, target.Center, velocity, ProjectileID.RocketFireworkYellow, damage, knockback, Player.whoAmI, 0, 1);
							Main.projectile[y].timeLeft = 1;
							Main.projectile[y].hide = true;
							return;
					}
				}
			}
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
			if(PyrotechnicBadge == true)
            {
				var source = proj.GetSource_FromThis();
				Vector2 velocity = new Vector2(0, 0);
				var fireworkChance = WorldGen.genRand.Next(10);

				if (fireworkChance == 0)
				{
					switch (WorldGen.genRand.Next(4))
					{
						case 0:
							int b = Projectile.NewProjectile(source, proj.Center, velocity, ProjectileID.RocketFireworkBlue, damage, knockback, proj.owner, 0, 1);
							Main.projectile[b].timeLeft = 1;
							Main.projectile[b].hide = true;
							return;

						case 1:
							int r = Projectile.NewProjectile(source, proj.Center, velocity, ProjectileID.RocketFireworkRed, damage, knockback, proj.owner, 0, 1);
							Main.projectile[r].timeLeft = 1;
							Main.projectile[r].hide = true;
							return;

						case 2:
							int g = Projectile.NewProjectile(source, proj.Center, velocity, ProjectileID.RocketFireworkGreen, damage, knockback, proj.owner, 0, 1);
							Main.projectile[g].timeLeft = 1;
							Main.projectile[g].hide = true;
							return;

						case 3:
							int y = Projectile.NewProjectile(source, proj.Center, velocity, ProjectileID.RocketFireworkYellow, damage, knockback, proj.owner, 0, 1);
							Main.projectile[y].timeLeft = 1;
							Main.projectile[y].hide = true;
							return;
					}
				}
			}
		}

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
			if (RiddleOfLead == true && Player.statLife <= Player.statLifeMax / 6 && Main.rand.NextBool())
            {
				Player.immuneTime += 500;
            }
        }

		public override void OnHitByProjectile(Projectile projectile, int damage, bool crit)
		{
			if (RiddleOfLead == true && Player.statLife <= Player.statLifeMax / 6 && Main.rand.NextBool())
			{
				Player.immuneTime += 500;
			}
		}
	}
}
