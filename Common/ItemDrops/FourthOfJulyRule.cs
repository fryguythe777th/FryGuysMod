using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Engineer;
using FryGuysMod.Content.Items.Accessories.Boots;
using FryGuysMod.Content.Items.Consumables;

namespace FryGuysMod.Common.ItemDrops
{
    public class FourthOfJulyRule : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return FryGuySeason.FourthOfJulyActive;
        }

        public bool CanShowItemDropInUI()
        {
            return FryGuySeason.FourthOfJulyActive;
        }

        public string GetConditionDescription()
        {
            return "Only drops during the Fourth of July";
        }
    }
}