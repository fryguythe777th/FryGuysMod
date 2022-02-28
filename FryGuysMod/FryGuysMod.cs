using Terraria.ModLoader;
using FryGuysMod.Common;

namespace FryGuysMod
{
	public class FryGuysMod : Mod
	{
        public override void Load() => FryGlobalItem.Sets.Initialize();
    }
}