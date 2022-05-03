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
    public class DemonTongue : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gross...");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            var line = new TooltipLine(Mod, "DemonTongue:Warning", "Destructive Weapon")
            {
                OverrideColor = new Color(255, 0, 0)
            };
            tooltips.Add(line);

            var line2 = new TooltipLine(Mod, "DemonTongue:CanBreakAsh", "Can break ash blocks.")
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
            Item.shoot = ModContent.ProjectileType<DemonTongueTip>();
            Item.shootSpeed = 22f;
            Item.value = Item.sellPrice(gold: 3);
            Item.rare = ItemRarityID.LightRed;
        }
    }

    public class DemonTongueTip : ModProjectile
    {
        private static Asset<Texture2D> chainTexture;

        public override void Load()
        {
            chainTexture = ModContent.Request<Texture2D>("FryGuysMod/Content/Items/Weapons/Engineer/DemonTongueBridge");
        }

        public override void Unload()
        {
            chainTexture = null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Demon Tongue Tip");
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
        Vector2 InitialAddedVelocity = new Vector2(0, 12);
        Vector2 InitialDetractedVelocity = new Vector2(0, -12);

        public override void AI()
        {
            if (TimeTillRetract == 20)
            {
                if (Main.myPlayer == Projectile.owner)
                {
                    FryGuyMethods.GetAngleToMouse(Projectile);
                }
            }

            if (TimeTillRetract > 0)
            {
                TimeTillRetract--;

                Projectile.velocity = Main.player[Projectile.owner].velocity + InitialAddedVelocity.RotatedBy(Projectile.ai[0]);
            }
            else
            {
                TimeTillHitPlayer--;

                Projectile.velocity = Main.player[Projectile.owner].velocity + InitialDetractedVelocity.RotatedBy(Projectile.ai[0]);

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
