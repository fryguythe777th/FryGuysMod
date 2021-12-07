
using Terraria;
using Terraria.ModLoader;

namespace FryGuysMod.Buffs
{
	public class ConstructionPotionBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Construction Potion");
			Description.SetDefault("+1 Sentry Slot");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.maxTurrets += 1;
		}
	}
}