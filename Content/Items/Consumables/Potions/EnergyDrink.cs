using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Buffs;

namespace FryGuysMod.Content.Items.Consumables.Potions
{
    public class EnergyDrink : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Gives you a 3-minute sugar rush but then a 30-second sugar crash.");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 60);
            Item.buffType = ModContent.BuffType<Content.Buffs.SugarRushBuff>();
            Item.buffTime = 10800;
        }
    }
}
