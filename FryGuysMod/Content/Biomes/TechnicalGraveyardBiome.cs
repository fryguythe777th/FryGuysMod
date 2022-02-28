using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Biomes
{
	public class TechnicalGraveyardBiome : ModBiome
	{
		public override bool IsBiomeActive(Player player)
		{
			if (Main.LocalPlayer.ZoneGraveyard)
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