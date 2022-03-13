using Terraria.GameContent.Creative;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FryGuysMod.Content.Items.Weapons.Melee
{
	public class EagleSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Knocks enemies upwards when you hit them.");
		}

		public override void SetDefaults()
		{
			Item.damage = 8;
			Item.DamageType = DamageClass.Melee;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 1;
			Item.value = 10000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			var y = -6 + target.knockBackResist;

			if (player.kbGlove == true)
            {
				y -= 2;
            }

			if(y >= 0 || target.boss == true)
            {
				y = 0;
            }
			target.velocity = new Vector2(0, y);
        }
    }
}