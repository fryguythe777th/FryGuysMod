using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Biomes
{
	public class TechnicalHellBiome : ModBiome
	{
		public override bool IsBiomeActive(Player player)
		{
			if (Main.LocalPlayer.ZoneUnderworldHeight)
            {
				return true;
            }
			else
            {
				return false;
            }
        }
	}
}