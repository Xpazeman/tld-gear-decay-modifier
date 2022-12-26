using HarmonyLib;
using Il2Cpp;

namespace GearDecayModifier
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.Degrade), new Type[] { typeof(float) })]
    internal class GearItem_Degrade
    {
        private static void Prefix(GearItem __instance, ref float hp)
        {
            float decay_multiplier = GearDecayModifier.ApplyDecayModifier(__instance);

            hp *= decay_multiplier;
        }
    }
}
