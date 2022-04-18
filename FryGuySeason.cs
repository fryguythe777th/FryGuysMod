using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework.Graphics;

namespace FryGuysMod
{
    public class FryGuySeason : ModSystem
    {
        public override void OnWorldLoad()
        {
            CalendarFourthOfJuly = false;
            CalendarHalloween = false;
            CalendarXMas = false;

            CheckFourthOfJuly();
        }

        public static void CheckFourthOfJuly()
        {
            FourthOfJulyActive = DateTime.Now.Month == 7;
        }

        public static bool FourthOfJulyActive { get; internal set; }
        public static bool CalendarFourthOfJuly;
        public static bool CalendarXMas;
        public static bool CalendarHalloween;

        //new SpawnConditionBestiaryInfoElement
        //ModSourceBestiaryInfoElement FourthOfJuly = new ModSourceBestiaryInfoElement();

        public override void PostUpdateWorld()
        {
            if (CalendarFourthOfJuly || ModContent.GetInstance<FourthOfJulyConfig>().FourthOfJulyActiveConfig)
            {
                FourthOfJulyActive = true;
                Main.xMas = false;
                Main.halloween = false;
            }
            else if (Main.time == 0 && Main.dayTime && Main.netMode != NetmodeID.MultiplayerClient)
            {
                CheckFourthOfJuly();
            }

            if (CalendarXMas)
            {
                Main.xMas = true;
                Main.halloween = false;
                FourthOfJulyActive = false;
            }

            if (CalendarHalloween)
            {
                Main.halloween = true;
                Main.xMas = false;
                FourthOfJulyActive = false;
            }
        }
    }
}
