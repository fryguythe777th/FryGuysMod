using Terraria.ModLoader;
using FryGuysMod.Common;
using FryGuysMod.Content.NPCs.TownNPCs;

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
	
	public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("Census", out Mod census))
            {
                census.Call("TownNPCCondition", ModContent.NPCType<HolidayPlanner>(), "Defeat any post-Plantera holiday event");
            }
        }
    }
}
