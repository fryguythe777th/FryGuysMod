using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Weapons.Ranged;
using Terraria.DataStructures;

namespace FryGuysMod.Content.Items.Weapons.Ranged
{
	public class Pyrolauncher : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Converts wooden arrows into fireworks.");
			
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 27;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 6;
			Item.value = 420;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<Firework>();
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 10f;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			type = ModContent.ProjectileType<Firework>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			int projectileID = Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
			Projectile projectile = Main.projectile[projectileID];
			return false;
		}
    }

	public class Firework : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Firework");
        }

        public override void SetDefaults()
        {
			AIType = ProjectileID.WoodenArrowFriendly;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.arrow = true;
			Projectile.width = 10;
			Projectile.height = 10;
        }

		public override string Texture => "FryGuysMod/Content/Items/Weapons/Ranged/Firework";

		public int timeLeft = 180;

        public override void AI()
        {
			timeLeft = timeLeft - 1;
			if (timeLeft == 0)
            {
				Projectile.Kill();
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			return true;
        }

        public override void Kill(int timeLeft)
        {
			var source = Projectile.GetProjectileSource_FromThis();
			Vector2 velocity = new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-10, -8));

			switch (WorldGen.genRand.Next(4))
            {
				case 0:
					int b = Projectile.NewProjectile(source, Projectile.Center, velocity, ProjectileID.RocketFireworkBlue, Projectile.damage, Projectile.knockBack, Projectile.owner, 0, 1);
					Main.projectile[b].timeLeft = 1;
					Main.projectile[b].hide = true;
					return;

				case 1:
					int r = Projectile.NewProjectile(source, Projectile.Center, velocity, ProjectileID.RocketFireworkRed, Projectile.damage, Projectile.knockBack, Projectile.owner, 0, 1);
					Main.projectile[r].timeLeft = 1;
					Main.projectile[r].hide = true;
					return;

				case 2:
					int g = Projectile.NewProjectile(source, Projectile.Center, velocity, ProjectileID.RocketFireworkGreen, Projectile.damage, Projectile.knockBack, Projectile.owner, 0, 1);
					Main.projectile[g].timeLeft = 1;
					Main.projectile[g].hide = true;
					return;

				case 3:
					int y = Projectile.NewProjectile(source, Projectile.Center, velocity, ProjectileID.RocketFireworkYellow, Projectile.damage, Projectile.knockBack, Projectile.owner, 0, 1);
					Main.projectile[y].timeLeft = 1;
					Main.projectile[y].hide = true;
					return;
			}
        }
    }

	//public class FireworkBlast : ModProjectile
    //{
	//	public override void SetDefaults()
    //    {
	//		Projectile.width = 15;
	//		Projectile.height = 15;
	//
    //    }
    //}
}
