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
			Item.shoot = ProjectileID.PurificationPowder;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 3f;
		}

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
			//Projectile.width = 10;
			//Projectile.height = 10;
			//Projectile.friendly = true;
			//Projectile.DamageType = DamageClass.Ranged;
			//Projectile.arrow = true;
			//Projectile.tileCollide = true;
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			AIType = ProjectileID.WoodenArrowFriendly;
        }

		public override string Texture => "FryGuysMod/Content/Items/Weapons/Ranged/Firework";

		public int timeLeft = 180;

        public override void AI()
        {
			Projectile.position = Projectile.Center;


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
            
        }
    }
}