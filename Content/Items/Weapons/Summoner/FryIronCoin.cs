using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Weapons.Ranged;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using FryGuysMod.Content.Items.Consumables;
using FryGuysMod;
using Terraria.Audio;
using Terraria.GameContent.Events;
using Microsoft.Xna.Framework.Graphics;

namespace FryGuysMod.Content.Items.Weapons.Summoner
{
	public class FryIronCoin : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iron Coin");

			Tooltip.SetDefault("Valar Morgunis");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 0;
			Item.DamageType = DamageClass.Summon;
			Item.width = 38;
			Item.height = 36;
			Item.useTime = 1000;
			Item.useAnimation = 1000;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = 17500;
			Item.rare = ItemRarityID.Green;
			Item.autoReuse = false;
			Item.consumable = true;
			Item.maxStack = 3;
			Item.shoot = ModContent.ProjectileType<FryIronCoinSpin>();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			Projectile.NewProjectile(source, position, new Vector2 (0, -5), ModContent.ProjectileType<FryIronCoinSpin>(), 0, 0, player.whoAmI);
			return false;
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.IronBar, 2)
				.AddIngredient(ModContent.ItemType<Gunpowder>(), 1)
				.AddIngredient(ItemID.HallowedBar, 1)
				.AddTile(TileID.MythrilAnvil)
				.Register();
        }
    }

	public class FryIronCoinSpin : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Iron Coin");
			Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
			Projectile.width = 38;
			Projectile.height = 36;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.damage = 0;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 240;
			Projectile.scale = 1f;
        }

        public override void AI()
        {
			Projectile.velocity *= 0.97f;
			if (Projectile.scale < 2)
            {
				Projectile.scale *= 1.005f;
            }

			if (++Projectile.frameCounter >= 4)
			{
				Projectile.frameCounter = 0;

				if (++Projectile.frame >= Main.projFrames[Projectile.type])
				{
					Projectile.frame = 0;
				}
			}

			if (Projectile.timeLeft == 1)
            {
				for (int i = 0; i < Main.maxNPCs; i++)
				{
					NPC potentialTarget = Main.npc[i];

					if (potentialTarget.friendly == false && potentialTarget.damage > 0 && potentialTarget.lifeMax > 5)
					{
						if (potentialTarget.boss == true)
                        {
							potentialTarget.StrikeNPC((int)(potentialTarget.lifeMax * 0.05), 0, 0, false, false, false);
						}
						else
                        {
							potentialTarget.StrikeNPC((int)(potentialTarget.lifeMax * 0.3), 0, 0, false, false, false);
						}

						if (potentialTarget.life < 0)
                        {
							potentialTarget.life = 0;
                        }
					}
				}

				Main.player[Projectile.owner].statLife -= (int)(Main.player[Projectile.owner].statLifeMax * 0.5);
				if (Main.player[Projectile.owner].statLife <= 0)
                {
					Main.player[Projectile.owner].KillMe(PlayerDeathReason.ByCustomReason(Main.player[Projectile.owner].name + " died of their own arrogance."), 1000, 0, false);
                }

				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);

				MoonlordDeathDrama.RequestLight(1f, Main.player[Projectile.owner].position);

				for (int j = 0; j < 12; j++)
				{
					Dust.NewDust(Projectile.position, 10, 10, DustID.Smoke, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 0, default, 4);
				}


				Projectile.Kill();
			}
        }

		public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects = SpriteEffects.None;

			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("FryGuysMod/Content/Items/Weapons/Summoner/FryIronCoinSpin");

			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;

			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

			Vector2 origin = sourceRectangle.Size() / 2f;

			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, Projectile.GetAlpha(lightColor), Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

			return false;
		}
	}
}