using System;
using Harmony;

namespace GearDecayModifier
{
    [HarmonyPatch(typeof(GearItem), "Degrade", new Type[] { typeof(float) })]
    internal class GearItem_Degrade
    {
        private static void Prefix(GearItem __instance, ref float hp)
        {
            if (!__instance.m_BeenInspected && !__instance.m_BeenInPlayerInventory)
            {
                hp *= GearDecayOptions.decay_before_pickup;
            }

            hp *= GearDecayOptions.general_decay;
        }
    }
}
