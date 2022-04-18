using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using FryGuysMod.Content.Biomes;
using FryGuysMod.Common;
using Terraria.GameContent.Events;
using static Terraria.GameContent.RGB.CommonConditions;
using FryGuysMod.Content.Items.Weapons;
using Terraria.GameContent.Personalities;
using Terraria.GameContent.Bestiary;

namespace FryGuysMod.Content.NPCs.Critters
{
	public class PatriotBunny : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bunny");

			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Bunny];
			Main.npcCatchable[Type] = true;

			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {

				new BestiaryPortraitBackgroundProviderPreferenceInfoElement(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime),
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
				new FlavorTextBestiaryInfoElement("This cute little bunny felt a little patriotic before going out today and put on a fancy hat.")

			});
		}

		public override void SetDefaults()
        {
			NPC.CloneDefaults(NPCID.Bunny);
			AIType = NPCID.Bunny;
			NPC.catchItem = ItemID.Bunny;
			AnimationType = NPCID.Bunny;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (FryGuySeason.FourthOfJulyActive == true && Main.LocalPlayer.ZoneForest == true && Main.dayTime)
            {
				return 0.1f;
            }
			else
            {
				return 0f;
            }
        }
    }
}