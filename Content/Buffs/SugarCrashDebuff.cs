using Terraria;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Buffs
{
	public class SugarCrashDebuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sugar Crash");
			Description.SetDefault("Reduced movement speed. Let's just hope you don't get diabetes.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.accRunSpeed /= 1.4f;
			player.moveSpeed /= 1.4f;
			player.maxRunSpeed /= 1.2f;
		}
	}
}