using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.Graphics;
using Terraria.GameContent.Events;

namespace FryGuysMod.Content.Items.Weapons.Melee
{
	public class FryBlasphemy : FourthOfJulyItem
	{
		private void DefaultUse()
        {
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useTurn = false;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Shoot;
        }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blasphemy");
			Tooltip.SetDefault("Left click to swing.\n" +
				"Hold down left click to charge a beam attack.\n" +
				"Right click to release a bullet-destroying shockwave.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			DefaultUse();
			Item.knockBack = 10;
			Item.noMelee = true;
			Item.value = 10000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = false;
			Item.shoot = ModContent.ProjectileType<FryBlasphemySwipe>();
		}

        public override bool AltFunctionUse(Player player)
        {
			return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
				Item.useTime = 600;
				Item.useAnimation = 600;
				Item.useTurn = true;
				Item.noUseGraphic = false;
				Item.useStyle = ItemUseStyleID.HoldUp;
            }
			else
            {
				DefaultUse();
            }
			return true;
        }

		public float realAngle;

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			if (player.altFunctionUse == 2)
            {
				DefaultUse();

				/* for (int i = 0; i < Main.maxProjectiles; i++)
				{
					Projectile potentialTarget = Main.projectile[i];

					if (potentialTarget.hostile)
                    {
						potentialTarget.timeLeft = Math.Min(potentialTarget.timeLeft, 2);
					}
				} */

				for (int i = 0; i < Main.maxNPCs; i++)
                {
					NPC potentialTarget = Main.npc[i];

					if (potentialTarget.friendly == false && potentialTarget.boss == false)
                    {
						float x = player.position.X - potentialTarget.position.X;
						float y = player.position.Y - potentialTarget.position.Y;
						float distance = (float)Math.Sqrt((x * x) + (y * y));

						float angle1 = (float)Math.Acos(x / distance);

						if (Math.Sign(player.position.Y - potentialTarget.position.Y) == -1)
						{
							realAngle = ((angle1 + MathHelper.ToRadians(90)) * -1) + MathHelper.ToRadians(180);
						}
						else
						{
							realAngle = angle1 + MathHelper.ToRadians(90);
						}
						Vector2 initVelocity = new Vector2(0, 15);
						potentialTarget.velocity = initVelocity.RotatedBy(realAngle);
					}
                }

				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, -1);
				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, -1);
				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, -1);
				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, -1);
				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, -1);
				SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, -1);

				MoonlordDeathDrama.RequestLight(1f, player.position);

				return false;
			}
			else
            {
				Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
				return false;
			}
		}

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.LeadBar, 6)
				.AddIngredient(ModContent.ItemType<Gunpowder>(), 3)
				.AddIngredient(ItemID.HallowedBar, 6)
				.AddTile(TileID.MythrilAnvil)
				.Register();
        }
    }

	public class FryBlasphemySwipe : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Blasphemy Slice");
			Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
			Projectile.width = 38;
			Projectile.height = 56;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.timeLeft = int.MaxValue;
			Projectile.penetrate = -1;
        }

        public override bool PreAI()
        {
			Main.player[Projectile.owner].heldProj = Projectile.whoAmI;

			return true;
        }

		public int TimeAfterHold = 0;
		public bool CurrentlyCharging = false;

        public override void AI()
        {
			if (Projectile.timeLeft == int.MaxValue)
            {
				if (Projectile.position.X > Main.MouseWorld.X)
                {
					Projectile.spriteDirection = -1;
                }
				CurrentlyCharging = false;
				TimeAfterHold = 0;
			}

			int offset = 20;

			if (Projectile.spriteDirection == -1)
            {
				offset = -40;
            }

			Projectile.position = Main.player[Projectile.owner].position + new Vector2(offset, -4);

            if (++Projectile.frameCounter >= 4)
            {
				Projectile.frameCounter = 0;

				if(++Projectile.frame >= Main.projFrames[Projectile.type])
                {
					Projectile.frame = 5;
					Projectile.damage = -30;

					if (TimeAfterHold == 0)
                    {
						CurrentlyCharging = true;
                    }
					TimeAfterHold = 1;
                }
            }

			if (Projectile.timeLeft <= int.MaxValue - 24 && Main.mouseLeft == false)
            {
				Projectile.Kill();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
			SpriteEffects spriteEffects = SpriteEffects.None;
			if (Projectile.spriteDirection == -1)
            {
				spriteEffects = SpriteEffects.FlipHorizontally;
            }

			Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);

			int frameHeight = texture.Height / Main.projFrames[Projectile.type];
			int startY = frameHeight * Projectile.frame;

			Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);

			Vector2 origin = sourceRectangle.Size() / 2f;

			

			Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, Projectile.GetAlpha(lightColor), Projectile.rotation, origin, Projectile.scale, spriteEffects, 0);

			return false;
        }

        public override void PostDraw(Color lightColor)
        {
			if (CurrentlyCharging == true)
            {
				for (int i = 1; i <= 3000; i++)
                {
					if (Main.mouseLeft == true)
                    {
						decimal framePreRound = 3000 / i;
						int frame = (int)Math.Round(framePreRound);
						Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("FryGuysMod/Content/ChargeBar");
						int frameHeight = texture.Height / 6;
						int startY = frameHeight * frame;
						Rectangle sourceRectangle = new Rectangle(0, startY, texture.Width, frameHeight);
						Vector2 origin = sourceRectangle.Size() / 2f;

						Main.EntitySpriteDraw(texture, Main.player[Projectile.owner].position + new Vector2(0, 20), sourceRectangle, Color.White, 0, origin, 1f, SpriteEffects.None, 0);

						if (i == 3000)
						{
							Vector2 position6 = Main.player[Projectile.owner].position + new Vector2(Main.player[Projectile.owner].width / 2, Main.player[Projectile.owner].height / 2);
							Vector2 position7;

							if (Projectile.spriteDirection == -1)
                            {
								position7 = new Vector2(position6.X, position6.Y - 20);
                            }
							else
                            {
								position7 = new Vector2(position6.X, position6.Y + 20);
                            }

							Projectile.NewProjectile(Main.player[Projectile.owner].GetSource_FromThis(), position7, new Vector2(10 * Projectile.spriteDirection, 0), ModContent.ProjectileType<FryBlasphemyLaser>(), 75, 10, Projectile.owner);

							CurrentlyCharging = false;
						}
					}
                }
            }
        }
    }

	public class FryBlasphemyLaser : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Blasphemy Laser");
        }

        public override void SetDefaults()
        {
			Projectile.height = 40;
			Projectile.width = 40;
			Projectile.timeLeft = 3600;
			Projectile.tileCollide = false;
			Projectile.friendly = true;
			Projectile.hide = true;
			Projectile.scale = 1.5f;
			Projectile.penetrate = 2;
        }

        public override void AI()
        {
			if (Projectile.timeLeft == 3600)
            {
				Projectile.hide = true;
				if (Math.Sign(Projectile.velocity.X) == -1)
				{
					Projectile.rotation = MathHelper.ToRadians(225);
				}
				else
				{
					Projectile.rotation = MathHelper.ToRadians(45);
				}
				Projectile.hide = false;
			}
        }
    }
}