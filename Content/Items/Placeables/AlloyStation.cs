using System;
using System.Linq;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using FryGuysMod.Content.Tiles;

namespace FryGuysMod.Content.Items.Placeables
{
	public class AlloyStation : ModItem
	{
		public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Lets you convert bars into their alternate versions.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
        {
			Item.width = 12;
			Item.height = 9;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 60);
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Content.Tiles.AlloyStation>();
        }

        public override void AddRecipes()
        {
			CreateRecipe()
				.AddIngredient(ItemID.StoneBlock, 12)
				.AddIngredient(ItemID.LavaBucket)
				.AddTile(TileID.HeavyWorkBench)
				.Register();

			//proceeds to create recipes for every ore
			Recipe copperToTin = Mod.CreateRecipe(ItemID.TinBar);
			copperToTin.AddIngredient(ItemID.CopperBar);
			copperToTin.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			copperToTin.Register();

			Recipe tinToCopper = Mod.CreateRecipe(ItemID.CopperBar);
			tinToCopper.AddIngredient(ItemID.TinBar);
			tinToCopper.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			tinToCopper.Register();

			Recipe ironToLead = Mod.CreateRecipe(ItemID.LeadBar);
			ironToLead.AddIngredient(ItemID.IronBar);
			ironToLead.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			ironToLead.Register();

			Recipe leadToIron = Mod.CreateRecipe(ItemID.IronBar);
			leadToIron.AddIngredient(ItemID.LeadBar);
			leadToIron.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			leadToIron.Register();

			Recipe silverToTungsten = Mod.CreateRecipe(ItemID.TungstenBar);
			silverToTungsten.AddIngredient(ItemID.SilverBar);
			silverToTungsten.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			silverToTungsten.Register();

			Recipe tungstenToSilver = Mod.CreateRecipe(ItemID.SilverBar);
			tungstenToSilver.AddIngredient(ItemID.TungstenBar);
			tungstenToSilver.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			tungstenToSilver.Register();

			Recipe goldToPlatinum = Mod.CreateRecipe(ItemID.PlatinumBar);
			goldToPlatinum.AddIngredient(ItemID.GoldBar);
			goldToPlatinum.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			goldToPlatinum.Register();

			Recipe platinumToGold = Mod.CreateRecipe(ItemID.GoldBar);
			platinumToGold.AddIngredient(ItemID.PlatinumBar);
			platinumToGold.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			platinumToGold.Register();

			Recipe demoniteToCrimtane = Mod.CreateRecipe(ItemID.CrimtaneBar);
			demoniteToCrimtane.AddIngredient(ItemID.DemoniteBar);
			demoniteToCrimtane.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			demoniteToCrimtane.Register();

			Recipe crimtaneToDemonite = Mod.CreateRecipe(ItemID.DemoniteBar);
			crimtaneToDemonite.AddIngredient(ItemID.CrimtaneBar);
			crimtaneToDemonite.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			crimtaneToDemonite.Register();

			Recipe cobaltToPalladium = Mod.CreateRecipe(ItemID.PalladiumBar);
			cobaltToPalladium.AddIngredient(ItemID.CobaltBar);
			cobaltToPalladium.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			cobaltToPalladium.Register();

			Recipe palladiumToCobalt = Mod.CreateRecipe(ItemID.CobaltBar);
			palladiumToCobalt.AddIngredient(ItemID.PalladiumBar);
			palladiumToCobalt.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			palladiumToCobalt.Register();

			Recipe mythrilToOrichalcum = Mod.CreateRecipe(ItemID.OrichalcumBar);
			mythrilToOrichalcum.AddIngredient(ItemID.MythrilBar);
			mythrilToOrichalcum.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			mythrilToOrichalcum.Register();

			Recipe orichalcumToMythril = Mod.CreateRecipe(ItemID.MythrilBar);
			orichalcumToMythril.AddIngredient(ItemID.OrichalcumBar);
			orichalcumToMythril.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			orichalcumToMythril.Register();

			Recipe adamantiteToTitanium = Mod.CreateRecipe(ItemID.TitaniumBar);
			adamantiteToTitanium.AddIngredient(ItemID.AdamantiteBar);
			adamantiteToTitanium.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			adamantiteToTitanium.Register();

			Recipe titaniumToAdamantite = Mod.CreateRecipe(ItemID.AdamantiteBar);
			titaniumToAdamantite.AddIngredient(ItemID.TitaniumBar);
			titaniumToAdamantite.AddTile(ModContent.TileType<Tiles.AlloyStation>());
			titaniumToAdamantite.Register();
		}
    }
}
