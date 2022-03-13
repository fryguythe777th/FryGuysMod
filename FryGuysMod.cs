using Terraria.ModLoader;
using FryGuysMod.Common;

namespace FryGuysMod
{
	public class FryGuysMod : Mod
	{
        public override void Load()
        {
            FryGlobalItem.Sets.Initialize();
            FryGuySeason.CalendarFourthOfJuly = false;
            FryGuySeason.CalendarHalloween = false;
            FryGuySeason.CalendarXMas = false;
        }
    }
}