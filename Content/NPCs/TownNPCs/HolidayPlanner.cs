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

namespace FryGuysMod.Content.NPCs.TownNPCs
{
	[AutoloadHead]
	public class HolidayPlanner : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[Type] = 25;

			NPCID.Sets.ExtraFramesCount[Type] = 9;
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 700;
			NPCID.Sets.AttackType[Type] = 3;
			NPCID.Sets.AttackTime[Type] = 20;
			NPCID.Sets.AttackAverageChance[Type] = 10;
			NPCID.Sets.HatOffsetY[Type] = 4;

			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Velocity = 1f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

			NPC.Happiness
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
				.SetBiomeAffection<TechnicalGraveyardBiome>(AffectionLevel.Love)
				.SetBiomeAffection<TechnicalHellBiome>(AffectionLevel.Like)

				.SetNPCAffection(NPCID.SantaClaus, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Pirate, AffectionLevel.Like)
				.SetNPCAffection(NPCID.TaxCollector, AffectionLevel.Hate)
			;

			// loves snow, graveyard, likes hell
			// loves santa, likes pirate, hates taxist
        }

		public override void SetDefaults()
        {
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.Guide;
		}

		public override bool CanGoToStatue(bool toKingStatue)
        {
			return toKingStatue;
			//OMG official GENDER confirmed????? nvm its my headcanon that Holiday Planner is nonbinary. zad
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
			damage = 80;
			knockback = 12f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
			cooldown = 30;
			randExtraCooldown = 5;
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
        {
			item = (Texture2D)TextureAssets.Item[ModContent.ItemType<TestEngineerWeapon>()];
			scale = 0.8f;
			itemSize = 54;
			//Important note: this doesn't work. Don't try to copy-paste this to get an item to show up in a future NPC. I only kept it not working because I wanted a custom attack animation anyway.
        } 

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight)
        {
			itemWidth = 40;
			itemHeight = 40;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
			if (NPC.downedChristmasIceQueen || NPC.downedHalloweenKing)
				return true;
			else
				return false;
        }

        public override string TownNPCName()
        {
			switch (WorldGen.genRand.Next(9))
            {
				case 0:
					return "Troy";

				case 1:
					return "Troy";

				case 2:
					return "Troy";

				case 3:
					return "Troy";

				case 4:
					return "Troy";

				case 5:
					return "Troy";

				case 6:
					return "Troy";

				case 7:
					return "Troy";

				default:
					return "Chad"; //rare chad name because funny

				//names if I ever get tired of Troy all the time: Tony, Geodude, Troy, Brad, Brent, Dirk, Kirk, Chad, Brock
            }
        }

        public override string GetChat()
        {
			WeightedRandom<string> chat = new WeightedRandom<string>();

			if(!Main.pumpkinMoon && !Main.snowMoon && !BirthdayParty.GenuineParty && !BirthdayParty.ManualParty && !Main.LocalPlayer.ZoneUnderworldHeight && !Main.eclipse)
            {
				chat.Add("I thank you for slaying that horrid Wall of Flesh.");
				chat.Add("Ausagis and I are very similar. We share an origin and a love of holidays.");
				chat.Add("Ausagis is a genius for creating these living holidays, even if they can be violent.");
				chat.Add("You know, my ancestors helped him escape.");
				chat.Add("I have only heard stories of the Deep Place.");
			}
			

			if(!Main.dayTime && !Main.pumpkinMoon && !Main.snowMoon && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("Night is the perfect time for celebrating! Just don't wake up the neighbors.");
            }

			if(BirthdayParty.GenuineParty || BirthdayParty.ManualParty && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("Everyone is celebrating! What new holiday have I discovered?", 100.0);
            }

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if(partyGirl >= 0 && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("That " + Main.npc[partyGirl].GivenName + "... Something about her makes my heart feel funny. She's so... celebratory.", 3.0);
            }

			if(Main.pumpkinMoon && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("Eek! It is absolutely terrifying tonight.");
				chat.Add("Have you seen those grinning pumpkins with the knife arms? Simply thrilling!");
				chat.Add("I could go for some candy corn right now.");
            }

			if(Main.snowMoon && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("Ah... Christmas was said to be a break from the heat of the Deep Place");
				chat.Add("I feel like getting cosy by a frost fire with somebody I love");
				chat.Add("I could go for some milk and cookies right now");
            }

			if(Main.eclipse && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("I feel like these horrid monsters out today aare celebrating something of their own...");
            }

			if(Boss.HighestTierBossOrEvent == -3 && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("Yarrrghh!!! I have always loved pirates.");
            }

			int taxCollector = NPC.FindFirstNPC(NPCID.TaxCollector);
			if(taxCollector >= 0 && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("Blech... " + Main.npc[taxCollector].GivenName + " reminds me of an old story.");
            }

			int santa = NPC.FindFirstNPC(NPCID.SantaClaus);
			if(santa >= 0 && !Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("Ho, ho, ho! Santa Claus being around gets me in a festive mood!");
            }

			if(Main.LocalPlayer.ZoneUnderworldHeight)
            {
				chat.Add("So these are the ruins of my former people.");
				chat.Add("I can feel their souls tormenting my mind. This is... not festive.");
				chat.Add("I can only imagine what it looked like before the Wall plagued it.");
            }

			return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Sell Holiday Loot";
        }

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
			if (firstButton)
            {
				shop = true;
            }

			if (!firstButton)
            {
				for (int i = 10; i < 50; i++)
                {
					Item item = Main.LocalPlayer.inventory[i];

					if (FryGlobalItem.Sets.IsHolidayItem[item.type] && !item.favorited && !item.IsAir)
                    {
						var source = Main.LocalPlayer.GetItemSource_Misc(Type);
						int sellPrice = item.value / 5;
						int[] Coin = Utils.CoinsSplit((long)sellPrice * item.stack);

						if (Coin[0] > 0)
							Item.NewItem(source, Main.LocalPlayer.getRect(), ItemID.CopperCoin, Coin[0]); //the number inside Coin[] refers to the type of coin. 0 = copper, 1 = silver, on until 3. You HAVE to do this for each type of coin

						if (Coin[1] > 0)
							Item.NewItem(source, Main.LocalPlayer.getRect(), ItemID.SilverCoin, Coin[1]);

						if (Coin[2] > 0)
							Item.NewItem(source, Main.LocalPlayer.getRect(), ItemID.GoldCoin, Coin[2]);

						if (Coin[3] > 0)
							Item.NewItem(source, Main.LocalPlayer.getRect(), ItemID.PlatinumCoin, Coin[3]);

						item.TurnToAir();
						
                    }
                }
            }
        }

		public override void SetupShop(Chest shop, ref int nextSlot)
        {
			shop.item[nextSlot].SetDefaults(ItemID.NaughtyPresent);
			shop.item[nextSlot].shopCustomPrice = 300000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.PumpkinMoonMedallion);
			shop.item[nextSlot].shopCustomPrice = 300000;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.SnowGlobe);
			shop.item[nextSlot].shopCustomPrice = 150000;
			nextSlot++;

			if (Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.ChristmasTreeSword);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Razorpine);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ChainGun);
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.TheHorsemansBlade);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BatScepter);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.StakeLauncher);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.Stake);
				shop.item[nextSlot].shopCustomPrice = 800;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.RavenStaff);
				nextSlot++;
			}

			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemID.NorthPole);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.BlizzardStaff);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.SnowmanCannon);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.EldMelter);
				nextSlot++;

				shop.item[nextSlot].SetDefaults(ItemID.SpookyTwig);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.JackOLanternLauncher);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.JackOLantern);
				shop.item[nextSlot].shopCustomPrice = 800;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CandyCornRifle);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.CandyCorn);
				shop.item[nextSlot].shopCustomPrice = 800;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ItemID.ScytheWhip);
				nextSlot++;
			}
		}
	}
}