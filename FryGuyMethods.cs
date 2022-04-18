using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace FryGuysMod
{
    public class FryGuyMethods
    {
        public static void UpKnockback(Player player, NPC target, float upKnockBack)
        {
            if (upKnockBack > 0)
            {
                float y = upKnockBack * -1;
                y += target.knockBackResist;

                if (player.kbGlove == true)
                {
                    y -= 2;
                }

                if (y >= 0 || target.boss == true)
                {
                    y = 0;
                }

                target.velocity = new Vector2(0, y);
            }
        }

        public static void DrawProjectileChain(Projectile projectile, int drawOffset, Asset<Texture2D> chainTexture)
        {
            Vector2 playerCenter = Main.player[projectile.owner].MountedCenter;
            Vector2 center = projectile.Center;
            Vector2 directionToPlayer = playerCenter - projectile.Center;
            float chainRotation = directionToPlayer.ToRotation() - MathHelper.PiOver2;
            float distanceToPlayer = directionToPlayer.Length();

            while (distanceToPlayer > 20f && !float.IsNaN(distanceToPlayer))
            {
                directionToPlayer /= distanceToPlayer;
                directionToPlayer *= chainTexture.Height() + drawOffset;
                center += directionToPlayer;
                directionToPlayer = playerCenter - center;
                distanceToPlayer = directionToPlayer.Length();

                Color drawColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16));

                Main.EntitySpriteDraw(chainTexture.Value, center - Main.screenPosition, chainTexture.Value.Bounds, drawColor, chainRotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0);
            }
        }

        public static void GetAngleToMouse(Projectile projectile)
        {
            float x = projectile.position.X - Main.MouseWorld.X;
            float y = projectile.position.Y - Main.MouseWorld.Y;
            float distance = (float)Math.Sqrt((x * x) + (y * y));

            float angle1 = (float)Math.Acos(x / distance);

            if (Math.Sign(projectile.position.Y - Main.MouseWorld.Y) == -1)
            {
                projectile.ai[0] = ((angle1 + MathHelper.ToRadians(90)) * -1) + MathHelper.ToRadians(180);

                projectile.rotation = projectile.rotation.AngleTowards(((angle1 + MathHelper.ToRadians(270)) * -1) + MathHelper.ToRadians(180), 1250);
            }
            else
            {
                projectile.ai[0] = angle1 + MathHelper.ToRadians(90);

                projectile.rotation = projectile.rotation.AngleTowards(angle1 + MathHelper.ToRadians(270), 1250);
            }

            if (Math.Sign(projectile.position.X - Main.MouseWorld.X) == 1)
            {
                projectile.spriteDirection = -1;
            }
            else
            {
                projectile.spriteDirection = 1;
            }
        }

        public static void CheckDestructibility(int DestroyType, Vector2 oldVelocity, Projectile projectile)
            // DestroyTypes::: 1 = wood, 2 = sand, 3 = stone, 4 = dungeon, 5 = ash, 6 = mud, 7 = stone + dirt, 8 = moon stuff (left out for now), 9 = corrupt/crimson blocks
        {
            Vector2 TileThingy = new Vector2((oldVelocity.X / Math.Abs(oldVelocity.X)), (oldVelocity.Y / Math.Abs(oldVelocity.Y)));

            Tile tile = Framing.GetTileSafely(((int)projectile.position.X / 16) + (int)TileThingy.X, ((int)projectile.position.Y / 16) + (int)TileThingy.Y);

            Vector2 TileThingy2 = new Vector2((projectile.position.X / 16) + (int)TileThingy.X, (projectile.position.Y / 16) + (int)TileThingy.Y);

            if (DestroyType == 1)
            {
                if (Sets.IsWoodTile[tile.TileType])
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
            else if (DestroyType == 2)
            {
                if (Sets.IsSandTile[tile.TileType])
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
            else if (DestroyType == 3)
            {
                if (Sets.IsStoneTile[tile.TileType])
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
            else if (DestroyType == 4)
            {
                if (Sets.IsDungeonTile[tile.TileType])
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
            else if (DestroyType == 5)
            {
                if (tile.TileType == TileID.Ash)
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
            else if (DestroyType == 6)
            {
                if (tile.TileType == TileID.Mud)
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
            else if (DestroyType == 7)
            {
                if (Sets.IsStoneOrDirtTile[tile.TileType])
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
            else if (DestroyType == 9)
            {
                if (Sets.IsCorruptOrCrimsonTile[tile.TileType])
                {
                    WorldGen.KillTile((int)TileThingy2.X, (int)TileThingy2.Y);
                }
            }
        }

        public static class Sets
        {
            public static bool[] IsWoodTile
            {
                get;
                private set;
            }

            public static bool[] IsSandTile
            {
                get;
                private set;
            }

            public static bool[] IsStoneTile
            {
                get;
                private set;
            }

            public static bool[] IsDungeonTile
            {
                get;
                private set;
            }

            public static bool[] IsStoneOrDirtTile
            {
                get;
                private set;
            }

            public static bool[] IsCorruptOrCrimsonTile
            {
                get;
                private set;
            }


            public static void Initialize()
            {
                IsWoodTile = new bool[TileLoader.TileCount];

                IsWoodTile[TileID.WoodBlock] = true;
                IsWoodTile[TileID.BorealWood] = true;
                IsWoodTile[TileID.DynastyWood] = true;
                IsWoodTile[TileID.LivingWood] = true;
                IsWoodTile[TileID.LeafBlock] = true;
                IsWoodTile[TileID.PalmWood] = true;
                IsWoodTile[TileID.SpookyWood] = true;
                IsWoodTile[TileID.Ebonwood] = true;
                IsWoodTile[TileID.Pearlwood] = true;
                IsWoodTile[TileID.Shadewood] = true;
                IsWoodTile[TileID.RichMahogany] = true;
                IsWoodTile[TileID.LivingMahogany] = true;
                IsWoodTile[TileID.LivingMahoganyLeaves] = true;

                IsSandTile = new bool[TileLoader.TileCount];

                IsSandTile[TileID.Sand] = true;
                IsSandTile[TileID.Ebonsand] = true;
                IsSandTile[TileID.Crimsand] = true;
                IsSandTile[TileID.Pearlsand] = true;

                IsStoneTile = new bool[TileLoader.TileCount];

                IsStoneTile[TileID.Stone] = true;
                IsStoneTile[TileID.Ebonstone] = true;
                IsStoneTile[TileID.Crimstone] = true;
                IsStoneTile[TileID.Pearlstone] = true;

                IsDungeonTile = new bool[TileLoader.TileCount];

                IsDungeonTile[TileID.BlueDungeonBrick] = true;
                IsDungeonTile[TileID.CrackedBlueDungeonBrick] = true;
                IsDungeonTile[TileID.CrackedGreenDungeonBrick] = true;
                IsDungeonTile[TileID.CrackedPinkDungeonBrick] = true;
                IsDungeonTile[TileID.GreenDungeonBrick] = true;
                IsDungeonTile[TileID.PinkDungeonBrick] = true;

                IsStoneOrDirtTile = new bool[TileLoader.TileCount];

                IsStoneOrDirtTile[TileID.Dirt] = true;
                IsStoneOrDirtTile[TileID.ClayBlock] = true;
                IsStoneOrDirtTile[TileID.Stone] = true;
                IsStoneOrDirtTile[TileID.Crimstone] = true;
                IsStoneOrDirtTile[TileID.Ebonstone] = true;
                IsStoneOrDirtTile[TileID.Pearlstone] = true;

                IsCorruptOrCrimsonTile = new bool[TileLoader.TileCount];

                IsCorruptOrCrimsonTile[TileID.Ebonsand] = true;
                IsCorruptOrCrimsonTile[TileID.Ebonstone] = true;
                IsCorruptOrCrimsonTile[TileID.Ebonwood] = true;
                IsCorruptOrCrimsonTile[TileID.CorruptIce] = true;
                IsCorruptOrCrimsonTile[TileID.Shadewood] = true;
                IsCorruptOrCrimsonTile[TileID.Crimsand] = true;
                IsCorruptOrCrimsonTile[TileID.Crimstone] = true;
                IsCorruptOrCrimsonTile[TileID.FleshIce] = true;
                IsCorruptOrCrimsonTile[TileID.CorruptGrass] = true;
                IsCorruptOrCrimsonTile[TileID.CrimsonGrass] = true;
                IsCorruptOrCrimsonTile[TileID.CorruptHardenedSand] = true;
                IsCorruptOrCrimsonTile[TileID.CorruptSandstone] = true;
                IsCorruptOrCrimsonTile[TileID.CrimsonHardenedSand] = true;
                IsCorruptOrCrimsonTile[TileID.CrimsonSandstone] = true;
            }
        }
    }
}
