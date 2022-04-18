using System;
using System.Linq;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items
{
	public abstract class FourthOfJulyItem : ModItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			var line = new TooltipLine(Mod, "FourthOfJulyItem:Indicator", "Fourth of July Item")
			{
				OverrideColor = new Color(50, 0, 255)
			};
			tooltips.Add(line);
        }
	}
}