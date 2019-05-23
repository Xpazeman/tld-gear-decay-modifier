using System;
using Harmony;
using UnityEngine;

namespace GearDecayModifier
{
    [HarmonyPatch(typeof(GearItem), "Degrade", new Type[] { typeof(float) })]
    internal class GearItem_Degrade
    {
        private static void Prefix(GearItem __instance, ref float hp)
        {

            float decay_multiplier = GearDecayModifier.ApplyDecayModifier(__instance);

            hp *= decay_multiplier;
        }
    }
}
