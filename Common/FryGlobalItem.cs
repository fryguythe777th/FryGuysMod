using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FryGuysMod.Common
{
    public class FryGlobalItem : GlobalItem
    {
        public static class Sets
        {
            public static bool[] IsHolidayItem
            {
                get;
                private set;
            }

            public static void Initialize()
            {
                IsHolidayItem = new bool[ItemLoader.ItemCount];

                IsHolidayItem[ItemID.ScarecrowBanner] = true;
                IsHolidayItem[ItemID.SplinterlingBanner] = true;
                IsHolidayItem[ItemID.HellhoundBanner] = true;
                IsHolidayItem[ItemID.PoltergeistBanner] = true;
                IsHolidayItem[ItemID.HeadlessHorsemanBanner] = true;
                IsHolidayItem[ItemID.ScarecrowHat] = true;
                IsHolidayItem[ItemID.ScarecrowShirt] = true;
                IsHolidayItem[ItemID.ScarecrowPants] = true;
                IsHolidayItem[ItemID.SpookyWood] = true;
                IsHolidayItem[ItemID.JackOLanternMask] = true;
                IsHolidayItem[ItemID.StakeLauncher] = true;
                IsHolidayItem[ItemID.Stake] = true;
                IsHolidayItem[ItemID.NecromanticScroll] = true;
                IsHolidayItem[ItemID.SpookyHook] = true;
                IsHolidayItem[ItemID.SpookyTwig] = true;
                IsHolidayItem[ItemID.CursedSapling] = true;
                IsHolidayItem[ItemID.MourningWoodTrophy] = true;
                IsHolidayItem[ItemID.WitchBroom] = true;
                IsHolidayItem[ItemID.MourningWoodMasterTrophy] = true;
                IsHolidayItem[ItemID.PumpkingMasterTrophy] = true;
                IsHolidayItem[ItemID.EverscreamMasterTrophy] = true;
                IsHolidayItem[ItemID.SantankMasterTrophy] = true;
                IsHolidayItem[ItemID.IceQueenMasterTrophy] = true;
                IsHolidayItem[ItemID.SpookyWoodMountItem] = true;
                IsHolidayItem[ItemID.SantankMountItem] = true;
                IsHolidayItem[ItemID.TheHorsemansBlade] = true;
                IsHolidayItem[ItemID.RavenStaff] = true;
                IsHolidayItem[ItemID.BatScepter] = true;
                IsHolidayItem[ItemID.CandyCornRifle] = true;
                IsHolidayItem[ItemID.CandyCorn] = true;
                IsHolidayItem[ItemID.JackOLanternLauncher] = true;
                IsHolidayItem[ItemID.ExplosiveJackOLantern] = true;
                IsHolidayItem[ItemID.BlackFairyDust] = true;
                IsHolidayItem[ItemID.SpiderEgg] = true;
                IsHolidayItem[ItemID.ScytheWhip] = true;
                IsHolidayItem[ItemID.PumpkingPetItem] = true;
                IsHolidayItem[ItemID.EverscreamPetItem] = true;
                IsHolidayItem[ItemID.IceQueenPetItem] = true;
                IsHolidayItem[ItemID.PresentMimicBanner] = true;
                IsHolidayItem[ItemID.FlockoBanner] = true;
                IsHolidayItem[ItemID.GingerbreadManBanner] = true;
                IsHolidayItem[ItemID.ZombieElfBanner] = true;
                IsHolidayItem[ItemID.ElfArcherBanner] = true;
                IsHolidayItem[ItemID.NutcrackerBanner] = true;
                IsHolidayItem[ItemID.YetiBanner] = true;
                IsHolidayItem[ItemID.ElfCopterBanner] = true;
                IsHolidayItem[ItemID.KrampusBanner] = true;
                IsHolidayItem[ItemID.ElfHat] = true;
                IsHolidayItem[ItemID.ElfShirt] = true;
                IsHolidayItem[ItemID.ElfPants] = true;
                IsHolidayItem[ItemID.ChristmasTreeSword] = true;
                IsHolidayItem[ItemID.Razorpine] = true;
                IsHolidayItem[ItemID.FestiveWings] = true;
                IsHolidayItem[ItemID.ChristmasHook] = true;
                IsHolidayItem[ItemID.EldMelter] = true;
                IsHolidayItem[ItemID.ChainGun] = true;
                IsHolidayItem[ItemID.BlizzardStaff] = true;
                IsHolidayItem[ItemID.NorthPole] = true;
                IsHolidayItem[ItemID.SnowmanCannon] = true;
                IsHolidayItem[ItemID.BabyGrinchMischiefWhistle] = true;
                IsHolidayItem[ItemID.ReindeerBells] = true;
            }
        }

        

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (Sets.IsHolidayItem[item.type])
                 tooltips.Add(new TooltipLine(Mod, "HolidayItemsDebug", "Can be instantly sold to the Holiday Planner"));
        }
    }
}