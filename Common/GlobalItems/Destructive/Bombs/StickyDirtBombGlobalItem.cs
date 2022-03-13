using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.DamageClasses;

namespace FryGuysMod.Common.GlobalItems
{
	public class StickyDirtBombGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			switch (item.type)
            {
				case ItemID.DirtStickyBomb:
					item.DamageType = ModContent.GetInstance<EngineerDamage>();
					break;
			}
		}
	}
}