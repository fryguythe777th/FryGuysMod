using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;
using FryGuysMod.DamageClasses;

namespace FryGuysMod.Content.Items.Accessories.Armor.Engineer
{
    [AutoloadEquip(EquipType.Head)]
    public class MythrilSpangenhelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+8% engineer crit chance\n" +
				"+14% engineer damage");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 18;
            Item.accessory = true;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 5;
            Item.value = Item.sellPrice(gold: 2, silver: 25);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(ModContent.GetInstance<EngineerDamage>()) += 8;
            player.GetDamage(ModContent.GetInstance<EngineerDamage>()) *= 1.14f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+2 sentry slots";
            player.maxTurrets += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MythrilBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}