using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;
using FryGuysMod.DamageClasses;

namespace FryGuysMod.Content.Items.Accessories.Armor.Engineer
{
    [AutoloadEquip(EquipType.Head)]
    public class OrichalcumSpangenhelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+17% engineer crit chance\n" +
				"+1 sentry slot");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 6;
            Item.value = Item.sellPrice(gold: 2, silver: 25);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(ModContent.GetInstance<EngineerDamage>()) += 17;
            player.maxTurrets += 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Flower petals will fall on your target for extra damage,\n" +
                "+another sentry slot";
            player.onHitPetal = true;
            player.maxTurrets += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.OrichalcumBar, 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}