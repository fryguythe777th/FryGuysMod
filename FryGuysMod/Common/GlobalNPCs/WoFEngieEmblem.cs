using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Items.Accessories;

namespace FryGuysMod.Common.GlobalNPCs
{
    public class WoFEngieEmblem : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EngineerEmblem>(), 7));
            }
        }
    }
}