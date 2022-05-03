using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Weapons.Ranged;
using FryGuysMod.Content.Items.Consumables.Potions;
using FryGuysMod.Content.Items.Weapons.Melee;
using FryGuysMod.Content.Items.Tools;
using FryGuysMod.Content.Items.Pets.FrenchFry;
using FryGuysMod.Content.Items.Accessories;
using FryGuysMod.Content.Items.Placeables;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Consumables
{
    public class Hat : FourthOfJulyItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Contatins many patriotic prizes.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;
            Item.maxStack = 999;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 5);
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            var source = player.GetItemSource_OpenItem(Type);

            switch (WorldGen.genRand.Next(15))
            {
                case 0:
                    player.QuickSpawnItem(source, ModContent.ItemType<Pyrolauncher>());
                    player.QuickSpawnItem(source, ItemID.WoodenArrow, 7);
                    break;

                case 1:
                    player.QuickSpawnItem(source, ModContent.ItemType<EnergyDrink>());
                    break;

                case 2:
                    player.QuickSpawnItem(source, ItemID.Pizza);
                    break;

                case 3:
                    player.QuickSpawnItem(source, ItemID.ApplePie);
                    break;

                case 4:
                    player.QuickSpawnItem(source, ModContent.ItemType<EagleSword>());
                    break;

                case 5:
                    player.QuickSpawnItem(source, ModContent.ItemType<EagleYoyo>());
                    break;

                case 6:
                    player.QuickSpawnItem(source, ModContent.ItemType<EagleHook>());
                    break;

                case 7:
                    player.QuickSpawnItem(source, ModContent.ItemType<EaglePickaxe>());
                    break;

                case 8:
                    player.QuickSpawnItem(source, ModContent.ItemType<Gunpowder>(), Main.rand.Next(1, 3));
                    break;

                case 9:
                    player.QuickSpawnItem(source, ModContent.ItemType<FrenchFry>());
                    break;

                case 10:
                    player.QuickSpawnItem(source, ModContent.ItemType<PyrotechnicBadge>());
                    break;

                case 11:
                    player.QuickSpawnItem(source, ModContent.ItemType<SoldierHat>());
                    break;

                case 12:
                    player.QuickSpawnItem(source, ModContent.ItemType<GunFrame>());
                    break;

                case 13:
                    player.QuickSpawnItem(source, ModContent.ItemType<AmericanStarBlock>(), Main.rand.Next(5, 20));
                    break;

                default:
                    player.QuickSpawnItem(source, ModContent.ItemType<AmericanStripeBlock>(), Main.rand.Next(5, 20));
                    break;
            }

            Dust.NewDust(player.position, 5, 5, DustID.Confetti, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Blue, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Green, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Pink, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Yellow, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Blue, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Green, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Pink, Main.rand.Next(-5, 5), -5, 0, default, 1);
            Dust.NewDust(player.position, 5, 5, DustID.Confetti_Yellow, Main.rand.Next(-5, 5), -5, 0, default, 1);
        }
    }
}
