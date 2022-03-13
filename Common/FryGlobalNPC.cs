using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using FryGuysMod.Content.Items.Accessories.Engineer;
using FryGuysMod.Content.Items.Accessories.Boots;

namespace FryGuysMod.Common
{
    public class WoFEngieEmblem : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.WallofFlesh)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<EngineerEmblem>(), 7));
                //the "7" at the end refers to the drop chance and means that this is a 1/7 drop chance
            }
        }
    }

    public class SpiderBootLoot : GlobalNPC
    {
        public override void ModifyNPCLoot (NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.WallCreeper)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpiderBoots>(), 10));
            }
        }
    }

    public class SpiderBootLoot2 : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.BlackRecluse)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpiderBoots>(), 5));
            }
        }
    }

    public class VanillaShops : GlobalNPC
    {
        //you can override any NPC shop here with else if(type == npcid.whatever) so use this as a global shop editor pls thank you
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Stylist)
            {
                shop.item[nextSlot].SetDefaults(ModContent.ItemType<SpiderBoots>());
                nextSlot++;

                //shop.item[nextSlot].shopCustomPrice = x;
                //shop.item[nextSlot].shopSpecialCurrency = FryGuysMod.CurrencyId;
            }
        }
    }
}