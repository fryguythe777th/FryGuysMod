using System;
using System.Linq;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace FryGuysMod
{
	public class FryGuyRecipes : ModSystem
	{
		public static RecipeGroup AnyEvilComponent;

		public override void AddRecipeGroups()
        {
			AnyEvilComponent = new RecipeGroup(() => "Any Evil Component",
				ItemID.ShadowScale, ItemID.TissueSample);

			RecipeGroup.RegisterGroup("[i:{86}]", AnyEvilComponent);
        }
	}
}