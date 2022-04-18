using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Pets.FrenchFry
{
	public class FrenchFry : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Summons the McDonald's Fry Man to follow you.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ZephyrFish);
			Item.width = 16;
			Item.height = 28;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<FrenchFryPet>();
			Item.buffType = ModContent.BuffType<FrenchFryBuff>();
		}

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if(player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
				player.AddBuff(Item.buffType, 3600);
            }
        }
    }

	public class FrenchFryPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Obligatory Self-Insert Pet");

			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
			Projectile.height = 40;
			Projectile.width = 40;
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
			AIType = ProjectileID.ZephyrFish;
        }

        public override bool PreAI()
        {
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false;
			return true;
        }

        public override void AI()
        {
			Player player = Main.player[Projectile.owner];

			if(!player.dead && player.HasBuff(ModContent.BuffType<FrenchFryBuff>()))
            {
				Projectile.timeLeft = 2;
            }
        }
    }

	public class FrenchFryBuff : ModBuff
    {
		public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Obligatory Self-Insert Pet");
			Description.SetDefault("Let the glory of this sentient pack of french fries wash over you");

			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
			player.buffTime[buffIndex] = 18000;

			int projType = ModContent.ProjectileType<FrenchFryPet>();

			if(player.whoAmI == Main.myPlayer && player.ownedProjectileCounts[projType] <= 0)
            {
				Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.Center, Vector2.Zero, projType, 0, 0f, player.whoAmI);
            }
        }
    }
}