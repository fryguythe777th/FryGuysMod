using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FryGuysMod

public class FryGuyMethods
{
    public static void UpKnockBack(NPC target, int upKnockBack)
    {
        if (upKnockBack > 0)
        {
            int y = upKnockBack * -1;
            y += target.knockBackResist;
            
            if (Main.LocalPlayer.kbGlove == true)
            {
                y -= 2;
            }
            
            if (y >= 0 || target.boss == true)
            {
                y = 0;
            }
            
            target.velocity = new Vector2
        }
    }
}
