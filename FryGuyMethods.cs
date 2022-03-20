using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FryGuysMod
{
    public class FryGuyMethods
    {
        public static void UpKnockback(Player player, NPC target, float upKnockBack)
        {
            if(upKnockBack > 0)
            {
                float y = upKnockBack * -1;
                y += target.knockBackResist;

                if (player.kbGlove == true)
                {
                    y -= 2;
                }

                if (y >= 0 || target.boss == true)
                {
                    y = 0;
                }

                target.velocity = new Vector2(0, y);
            }
        }
    }
}