using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.DamageClasses;

namespace FryGuysMod.Common.GlobalItems
{
	public class LavaBombGlobalItem : GlobalItem
	{
		public override void SetDefaults(Item item)
		{
			switch (item.type)
            {
				case ItemID.LavaBomb:
					item.DamageType = ModContent.GetInstance<EngineerDamage>();
					break;
			}
		}
	}
}