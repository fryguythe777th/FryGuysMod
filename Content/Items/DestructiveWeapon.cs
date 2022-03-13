using System;
using System.Linq;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items
{
	public abstract class DestructiveWeapon : ModItem
	{
		public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
			var line = new TooltipLine(Mod, "DestructiveWeapons:Warning", "Destructive Weapon")
			{
				overrideColor = new Color(255, 0, 0)
			};
			tooltips.Add(line);
        }
	}
}