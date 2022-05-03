using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Weapons.Ranged;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using FryGuysMod.Content.Items.Consumables;
using FryGuysMod;

namespace FryGuysMod.Content.Items.Weapons.Ranged
{
	public class FryBigIron : FourthOfJulyItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Iron");

			Tooltip.SetDefault("\"For the stranger there among them had a big iron on his hip.\"");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 14;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 20;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 4;
			Item.value = 17500;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = false;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.useAmmo = AmmoID.Bullet;
			Item.shootSpeed = 10f;
		}

        public override Vector2? HoldoutOffset()
        {
			return new Vector2(-1.1f, 1f);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			for (int i = 0; i < 3; i++)
            {
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(10)); // randomly rotate the bullet by 10 degrees
				newVelocity *= 1f - Main.rand.NextFloat(0.3f); // randomly changes the speed so that some bullets are slower
				Projectile.NewProjectile(source, position, newVelocity, type, damage, knockback, player.whoAmI);
            }
			return false;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.IronBar, 5)
				.AddIngredient(ModContent.ItemType<Gunpowder>(), 5)
				.AddRecipeGroup(FryGuyRecipes.AnyEvilComponent, 3)
				.AddTile(TileID.Anvils)
				.Register();
        }
    }
}
