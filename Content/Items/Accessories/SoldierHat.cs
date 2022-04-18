using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Head)]
    public class SoldierHat : FourthOfJulyItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+3 ranged damage.\n" +
                "Higher bullet speed.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 12;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 3f;
            player.GetModPlayer<FryGuyPlayer>().SoldierHat = true;
            player.statDefense += 1;
        }
    }
}