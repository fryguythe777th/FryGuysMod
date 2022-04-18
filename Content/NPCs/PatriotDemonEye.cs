using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;

namespace FryGuysMod.Content.NPCs
{
	public class PatriotDemonEye : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Eye");

			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.DemonEye];

			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f,
				PortraitPositionYOverride = 5f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
        }

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {

				new BestiaryPortraitBackgroundProviderPreferenceInfoElement(BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime),
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.NightTime,
                
				//new SpawnConditionBestiaryInfoElement("Fourth of July", (Texture2D)TextureAddressMode(FryGuysMod/icon_small), null, )
				new FlavorTextBestiaryInfoElement("This Demon Eye has had the unfortunate experience of having a firework shoved in its eye. Unfortunately for you, it can still see well enough to attack you.")

			});
		}

		public override void SetDefaults()
        {
			NPC.CloneDefaults(NPCID.DemonEye);
			NPC.width = 44;
			AIType = NPCID.DemonEye;
			AnimationType = NPCID.DemonEye;
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (FryGuySeason.FourthOfJulyActive == true && !Main.dayTime && Main.LocalPlayer.ZoneOverworldHeight == true)
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