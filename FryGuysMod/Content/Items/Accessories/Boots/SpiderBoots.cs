using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Boots
{
    public class SpiderBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Negates fall damage");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 2);

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noFallDmg = true;
        }
    }
}