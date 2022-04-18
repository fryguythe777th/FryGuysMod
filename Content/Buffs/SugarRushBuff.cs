using Terraria;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Buffs
{
	public class SugarRushBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sugar Rush");
			Description.SetDefault("Increased movement speed, but a high risk of decreased energy afterwards.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.moveSpeed *= 1.4f;
			player.maxRunSpeed *= 1.2f;

			if (player.buffTime[buffIndex] == 1)
            		{
				player.AddBuff(ModContent.BuffType<Content.Buffs.SugarCrashDebuff>(), 1800);
           		}
		}

        	public override bool RightClick(int buffIndex)
        	{
			Main.player[Main.myPlayer].AddBuff(ModContent.BuffType<SugarCrashDebuff>(), 1800);
			return true;
        	}
    }
}
