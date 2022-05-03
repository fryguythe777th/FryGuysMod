using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod;
using Terraria.GameContent.Creative;

namespace FryGuysMod.Content.Items.Accessories
{
    public class FryRiddleOfLead : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Riddle of Lead");

            Tooltip.SetDefault("Increased damage and speed.\n" +
                "Chance to gain additional invincibility frames on hit when under 1/6 of your max life.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.accessory = true;
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 10);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<FryGuyPlayer>().RiddleOfLead = true;
            player.GetDamage(DamageClass.Generic) *= 1.10f;
            player.moveSpeed *= 1.15f;
            player.maxRunSpeed *= 1.15f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 6)
                .AddIngredient(ItemID.HallowedBar, 4)
                .AddIngredient(ModContent.GetInstance<Gunpowder>(), 2)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
