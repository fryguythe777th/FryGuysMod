using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent.Creative;
using System.Collections.Generic;
using FryGuysMod.DamageClasses;
using Terraria.DataStructures;
using System;

namespace FryGuysMod.Content.Items.Weapons.Engineer
{
    public class PlanteraHook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera's Hooks");
            Tooltip.SetDefault("Unfortunately useless as a grappling method.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "PlanteraHook:Warning", "Destructive Weapon")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);

            var line2 = new TooltipLine(Mod, "PlanteraHook:CanBreakDungeon", "Can break dungeon blocks.")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line2);
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.knockBack = 19;
            Item.autoReuse = true;
            Item.width = 28;
            Item.height = 24;
            Item.damage = 31;
            Item.DamageType = ModContent.GetInstance<EngineerDamage>();
            Item.shoot = ModContent.ProjectileType<PlanteraHookHook>();
            Item.shootSpeed = 22f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            for (int i = 0; i < 3; i++)
            {
                Projectile.NewProjectile(null, position, velocity, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }

    public class PlanteraHookHook : ModProjectile
    {
        private static Asset<Texture2D> chainTexture;

        public override void Load()
        {
            chainTexture = ModContent.Request<Texture2D>("FryGuysMod/Content/Items/Weapons/Engineer/PlanteraHookBridge");
        }

        public override void Unload()
        {
            chainTexture = null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plantera's Hook");
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<EngineerDamage>();
            Projectile.width = 14;
            Projectile.height = 12;
            Projectile.penetrate = -1;
        }

        public int TimeTillRetract = 20;
        public int TimeTillHitPlayer = 20;
        Vector2 InitialAddedVelocity = new Vector2(0, 15);
        Vector2 InitialDetractedVelocity = new Vector2(0, -15);

        public override void AI()
        {
            if (TimeTillRetract == 20)
            {
                if (Main.myPlayer == Projectile.owner)
                {
                    float x = Projectile.position.X - Main.MouseWorld.X;
                    float y = Projectile.position.Y - Main.MouseWorld.Y;
                    float distance = (float)Math.Sqrt((x * x) + (y * y));

                    float angle1 = (float)Math.Acos(x / distance);

                    if (Math.Sign(Projectile.position.Y - Main.MouseWorld.Y) == -1)
                    {
                        int rand = Main.rand.Next(-1, 2);
                        Projectile.ai[0] = (((angle1 + MathHelper.ToRadians(90)) * -1) + MathHelper.ToRadians(180) + rand);

                        Projectile.rotation = Projectile.rotation.AngleTowards(((angle1 + MathHelper.ToRadians(270)) * -1) + MathHelper.ToRadians(180) + rand, 1250);
                    }
                    else
                    {
                        int rand = Main.rand.Next(-1, 2);
                        Projectile.ai[0] = (angle1 + MathHelper.ToRadians(90) + rand);

                        Projectile.rotation = Projectile.rotation.AngleTowards(angle1 + MathHelper.ToRadians(270) + rand, 1250);
                    }

                    if (Math.Sign(Projectile.position.X - Main.MouseWorld.X) == 1)
                    {
                        Projectile.spriteDirection = -1;
                    }
                    else
                    {
                        Projectile.spriteDirection = 1;
                    }

                    Projectile.ai[1] = Main.rand.Next(-2, 2);
                }
            }

            if (TimeTillRetract > 0)
            {
                TimeTillRetract--;

                Projectile.velocity = Main.player[Projectile.owner].velocity + (new Vector2(0, InitialAddedVelocity.Y + Projectile.ai[1])).RotatedBy(Projectile.ai[0]);
            }
            else
            {
                TimeTillHitPlayer--;

                Projectile.velocity = Main.player[Projectile.owner].velocity + (new Vector2(0, -(InitialAddedVelocity.Y + Projectile.ai[1]))).RotatedBy(Projectile.ai[0]);

                if (TimeTillHitPlayer == 0)
                {
                    Projectile.Kill();
                }
            }

            if (Projectile.Hitbox.Intersects(Main.player[Projectile.owner].Hitbox) && TimeTillRetract == 0)
            {
                Projectile.Kill();
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (TimeTillRetract > 0)
            {
                TimeTillRetract = 0;
            }
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (TimeTillRetract > 0)
            {
                TimeTillRetract = 0;
            }
        }

        public override bool PreDrawExtras()
        {
            FryGuyMethods.DrawProjectileChain(Projectile, 0, chainTexture);

            return false;
        }
    }
}