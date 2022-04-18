using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;
using FryGuysMod.DamageClasses;

namespace FryGuysMod.Content.Items.Accessories.Armor.Engineer
{
    [AutoloadEquip(EquipType.Head)]
    public class HallowedSpangenhelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+13% engineer damage\n" +
				"+1 sentry slot");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 22;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.defense = 7;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(ModContent.GetInstance<EngineerDamage>()) *= 1.13f;
            player.maxTurrets += 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.HallowedPlateMail && legs.type == ItemID.HallowedGreaves;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Become immune after striking an enemy,\n" +
                "and increases your max number of sentries by 2";
            player.onHitDodge = true;
            player.maxTurrets += 2;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}