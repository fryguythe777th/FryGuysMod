using FryGuysMod.DamageClasses;
using System;
using Terraria.DataStructures;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FryGuysMod.Content.Items.Weapons.Engineer
{
	public class SentryClearingRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Orb of Sentry Clearing");
			Tooltip.SetDefault("Instantly clears all sentries");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 12;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item44;
			Item.sentry = true;
			Item.shoot = ProjectileType<SentryClearingHelper>();
			Item.shootSpeed = 1f;
			Item.knockBack = 0;
			Item.value = 10000;
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        // public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        // {
        // 	int repeat = player.maxTurrets;
        //
        //	for (int i = 0; i < repeat; i++)
        //	{
        //		Main.NewText("Debug");
        //		player.SpawnMinionOnCursor(source, player.whoAmI, type, Item.damage, knockback);
        //	}
        //
        //	return false;
        // }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			player.SpawnMinionOnCursor(source, player.whoAmI, type, Item.damage, knockback);
			return false;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}

	public class SentryClearingHelper : ModProjectile
    {
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Sentry Clearing Helper");
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

        public override void SetDefaults()
        {
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.sentry = true;
			Projectile.hostile = false;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.timeLeft = Projectile.SentryLifeTime;
			Projectile.penetrate = -1;
			Projectile.tileCollide = true;
			Projectile.hide = true;
        }

        public override void AI()
        {
			Projectile.frame = 1;
			Main.player[Projectile.owner].UpdateMaxTurrets();
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			return false;
        }
    }
}