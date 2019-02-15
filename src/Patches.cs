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
            float decay_multiplier = 1f;

            GearItem gi = __instance;

            if (!gi.m_BeenInspected && !gi.m_BeenInPlayerInventory && !gi.m_BeenInContainer)
            {
                decay_multiplier *= GearDecayOptions.decay_before_pickup;
            }
            else if (gi.m_DegradeOnUse && !GearDecayOptions.apply_to_tools)
            {
                decay_multiplier = 1f;
            }
            else
            {
                //If clothing
                if (gi.m_ClothingItem)
                {
                    decay_multiplier *= GearDecayOptions.clothing_decay;
                }
                else if (gi.m_FoodItem)
                {
                    decay_multiplier *= GearDecayOptions.food_decay;
                }
                else
                {
                    decay_multiplier *= GearDecayOptions.general_decay;
                }
            }
            
            hp *= decay_multiplier;
        }
    }
}
