using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Weapons.Mage
{
    public class FryLeadMaiden : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lead Maiden");
            Tooltip.SetDefault("Your worst enemy, under your control.");
        }

        public override void SetDefaults()
        {
            Item.autoReuse = true;
            Item.damage = 21;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 6;
            Item.width = 36;
            Item.height = 20;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 6;
            Item.value = 17500;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item9;
            Item.shoot = ModContent.ProjectileType<FryLeadMaidenBullet>();
            Item.noMelee = true;
            Main.NewText(Item.shoot);
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            velocity = FryGuyMethods.GetItemShootToMouse(player, velocity);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 5)
                .AddIngredient(ModContent.ItemType<Gunpowder>())
                .AddRecipeGroup(FryGuyRecipes.AnyEvilComponent, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }

    public class FryLeadMaidenBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 24;
            Projectile.timeLeft = 3600;
            Projectile.friendly = true;
            AIType = ProjectileID.NanoBullet;
            Projectile.ignoreWater = true;
        }

        public int bounceTimer = 0;
        public float angle1;
        public Vector2 postBounceVelocity;

        public override void AI()
        {
            if (Projectile.timeLeft == 3600)
            {
                FryGuyMethods.GetAngleToMouse(Projectile);
                Projectile.velocity = new Vector2(0, 7).RotatedBy(Projectile.ai[0]);
                Projectile.ai[1] = 0;
            }

            if (Projectile.ai[1] == 1)
            {
                int TimeFreeze = Projectile.timeLeft;

                Projectile.velocity = new Vector2(0, 0);

                int targetIndex = Projectile.FindTargetWithLineOfSight(2000); //this funny method gets the main.npc number of the closest npc reachable

                if (targetIndex != -1) //can return -1 if no npcs so cancel that code or else you have problems
                {
                    NPC target = Main.npc[targetIndex];

                    float x = Projectile.position.X - target.position.X;
                    float y = Projectile.position.Y - target.position.Y;
                    float shooterDistance = (float)Math.Sqrt((x * x) + (y * y));

                    if (bounceTimer == 0)
                    {
                        angle1 = (float)Math.Acos(x / shooterDistance);
                        bounceTimer = 1;
                    }

                    if (Math.Sign(Projectile.position.Y - target.position.Y) == -1)
                    {
                        yourMom = ((angle1 + MathHelper.ToRadians(90)) * -1) + MathHelper.ToRadians(180);

                        Projectile.rotation = Projectile.rotation.AngleTowards(((angle1 + MathHelper.ToRadians(270)) * -1) + MathHelper.ToRadians(180), 1250);
                    }
                    else
                    {
                        yourMom = angle1 + MathHelper.ToRadians(90);

                        Projectile.rotation = Projectile.rotation.AngleTowards(angle1 + MathHelper.ToRadians(270), 1250);
                    }

                    Projectile.velocity = new Vector2(0, 7).RotatedBy(yourMom);

                    for (int j = 0; j < 30; j++)
                    {
                        if (Projectile.timeLeft == TimeFreeze - 10)
                        {
                            Projectile.ai[1] = 2;
                            break;
                        }
                    }
                }
                else
                {
                    Projectile.Kill();
                }
            }
        }

        public float yourMom;

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.ai[1] == 0)
            {
                Projectile.ai[1] = 1;
                return false;
            }

            if (Projectile.ai[1] == 2)
            {
                return true;
            }

            return true;
        }
    }
}