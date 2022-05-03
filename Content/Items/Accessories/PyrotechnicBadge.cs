using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories
{
    public class PyrotechnicBadge : FourthOfJulyItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Attacks have a chance to explode in a firework\n" +
                "Melee attacks have a greater chance to explode than projectile attacks.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(silver: 20);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FryGuyPlayer>().PyrotechnicBadge = true;
        }
    }
}
