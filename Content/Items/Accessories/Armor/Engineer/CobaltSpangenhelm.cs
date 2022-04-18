using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;
using FryGuysMod.DamageClasses;

namespace FryGuysMod.Content.Items.Accessories.Armor.Engineer
{
    [AutoloadEquip(EquipType.Head)]
    public class CobaltSpangenhelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+10% increased engineer damage and crit chance.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 20;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 13;
            Item.value = Item.sellPrice(gold: 1, silver: 50);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<EngineerDamage>()) *= 1.10f;
            player.GetCritChance(ModContent.GetInstance<EngineerDamage>()) += 10;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+2 sentry slots";
            player.maxTurrets += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CobaltBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}