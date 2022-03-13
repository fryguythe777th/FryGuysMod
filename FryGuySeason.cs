using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod
{
    public class FryGuySeason : ModSystem
	{
		public static bool FourthOfJulyActive { get; internal set; }
        public static bool CalendarFourthOfJuly;
        public static bool CalendarXMas;
        public static bool CalendarHalloween;

        public override void PostUpdateWorld()
        {
            if (CalendarFourthOfJuly)
            {
                FourthOfJulyActive = true;
            }
            else if (Main.time == 0 && Main.dayTime && Main.netMode != NetmodeID.MultiplayerClient)
            {
                FourthOfJulyActive = DateTime.Now.Month == 7;
            }

            if (CalendarXMas)
            {
                Main.xMas = true;
            }

            if (CalendarHalloween)
            {
                Main.halloween = true;
            }
        }
    }
}