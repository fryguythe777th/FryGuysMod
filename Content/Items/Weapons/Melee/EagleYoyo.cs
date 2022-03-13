using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FryGuysMod.Content.Items.Weapons.Melee
{
	public class EagleYoyo : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Knocks enemies upwards when you hit them.");

			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 6;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<EagleYoyoProj>();
		}
    }

	public class EagleYoyoProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 5f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 190f;
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 10f;
        }

		public override void SetDefaults()
        {
			Projectile.extraUpdates = 0;
			Projectile.width = 28;
			Projectile.height = 28;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			var y = -3 + target.knockBackResist;

			if(Main.LocalPlayer.kbGlove == true)
            {
				y -= 1;
            }

			if (y >= 0 || target.boss == true)
            {
				y = 0;
            }

			target.velocity = new Vector2(0, y);
        }
    }
}