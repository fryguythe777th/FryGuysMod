using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;
using FryGuysMod.DamageClasses;

namespace FryGuysMod.Content.Items.Accessories.Armor.Engineer
{
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumSpangenhelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+9% engineer crit chance\n" +
				"+2 sentry slot");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 4;
            Item.value = Item.sellPrice(gold: 1, silver: 50);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(ModContent.GetInstance<EngineerDamage>()) += 9;
            player.maxTurrets += 2;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Greatly increases life regeneration after striking an enemy";
            player.onHitRegen = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PalladiumBar, 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}