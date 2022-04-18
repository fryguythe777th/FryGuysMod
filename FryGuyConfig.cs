using Terraria.ModLoader;
using FryGuysMod.Common;
using FryGuysMod;
using Terraria.ModLoader.Config;
using System.ComponentModel;
using FryGuysMod.Content.Items.Consumables;

namespace FryGuysMod
{
	public class FourthOfJulyConfig : ModConfig
	{
        public static void Load()
        {
            var text = LocalizationLoader.CreateTranslation("Mods.FryGuysMod.ServerConfig.FourthOfJulyLabel");
            text.SetDefault("[i:" + ModContent.ItemType<Hat>() + "] Permanent Fourth of July");
            LocalizationLoader.AddTranslation(text);
        }

        public override ConfigScope Mode => ConfigScope.ServerSide;
        [Label("$Mods.FryGuysMod.ServerConfig.FourthOfJulyLabel")]
        [DefaultValue(false)]
        [Description("The Fourth of July will always be active.")]
        public bool FourthOfJulyActiveConfig;
    }
}