using System.Collections.Generic;
using Terraria.ModLoader;

namespace FryGuysMod.DamageClasses
{
	public class EngineerDamage : DamageClass
	{
		public override void SetStaticDefaults()
		{
			ClassName.SetDefault("engineer damage");
		}

		public StatInheritanceData GetStatInheritance(DamageClass damageClass)
        {
			if (damageClass == DamageClass.Generic)
            {
				return new StatInheritanceData(1f, 1f, 1f, 1f, 1f);
            }
			else
            {
				return new StatInheritanceData(0f, 0f, 0f, 0f, 0f);
            }
        }

		public override bool GetEffectInheritance(DamageClass damageClass)
		{
			return false;
		}

		public override bool UseStandardCritCalcs => true;
    }
}
