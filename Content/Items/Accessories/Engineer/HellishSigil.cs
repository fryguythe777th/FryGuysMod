using FryGuysMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FryGuysMod.Content.Items.Accessories.Engineer
{
    public class HellishSigil : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+3 engineer damage\n" +
                "Increases your max number of sentries by 1");
                
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(gold: 1);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage<EngineerDamage>().Flat += 3;
            player.maxTurrets += 1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AshBlock, 25)
                .AddIngredient(ItemID.Fireblossom, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
