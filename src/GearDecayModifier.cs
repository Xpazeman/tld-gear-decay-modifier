using System.IO;
using System.Reflection;
using UnityEngine;

namespace GearDecayModifier
{
    public class GearDecayOptions
    {
        public float decayBeforePickup = 1f;

        public float generalDecay = 1f;
        public bool advDecay = false;

        public float foodDecay = 1f;
        public bool advFoodDecay = false;
        public float rawFoodDecay = 1f;
        public float cookedFoodDecay = 1f;
        public float packagedFoodDecay = 1f;
        public float openedFoodDecay = 1f;

        public float clothingDecay = 1f;
        public float quartersDecay = 1f;
        public float bedrollDecay = 1f;

        public float onUseDecay = 1f;
        public bool advOnUseDecay = false;

        public float gunDecay = 1f;
        public float bowDecay = 1f;
        public float arrowDecay = 1f;
        //public float fishingDecay = 1f;
        public float firestartingDecay = 1f;
        //public float snareDecay = 1f;
        public float toolsDecay = 1f;
    }

    public class GearDecayModifier
    {
        public static string mods_folder;
        public static string mod_options_folder;
        public static string options_folder_name = "xpazeman-minimods";
        public static string options_file_name = "config-decay.json";

        public static GearDecayOptions opts;

        public static void OnLoad()
        {
            mods_folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            mod_options_folder = Path.Combine(mods_folder, options_folder_name);

            GearDecaySettings decaySettings = new GearDecaySettings();
            decaySettings.AddToModSettings("Gear Decay Settings");
            opts = decaySettings.setOptions;

            Debug.Log("[gear-decay-modifier] Version " + Assembly.GetExecutingAssembly().GetName().Version);
        }

        public static float ApplyDecayModifier(GearItem gi)
        {
            float decay_multiplier = 1f;

            if (!gi.m_DegradeOnUse)
            {
                //Before pickup decay
                if (!gi.m_BeenInspected && !gi.m_BeenInPlayerInventory && !gi.m_BeenInContainer)
                {
                    decay_multiplier *= opts.decayBeforePickup;
                }

                if (!gi.m_HasBeenOwnedByPlayer)
                {
                    //Never picked Up
                }

                //Natural degrade
                //if advanced decay
                if (opts.advDecay)
                {
                    if (gi.m_ClothingItem)
                    {
                        decay_multiplier *= opts.clothingDecay;
                    }
                    else if (gi.m_BodyHarvest)
                    {
                        decay_multiplier *= opts.quartersDecay;
                    }
                    else if (gi.m_Bed)
                    {
                        decay_multiplier *= opts.bedrollDecay;
                    }
                    else if (gi.m_ArrowItem)
                    {
                        decay_multiplier *= opts.arrowDecay;
                    }
                    else if (gi.m_FoodItem)
                    {
                        //if advanced food
                        if (GearDecayModifier.opts.advFoodDecay)
                        {
                            if (gi.m_FoodItem.m_IsNatural)
                            {
                                if (gi.m_FoodItem.m_IsRawMeat)
                                {
                                    decay_multiplier *= opts.rawFoodDecay;
                                }
                                else
                                {
                                    decay_multiplier *= opts.cookedFoodDecay;
                                }
                            }
                            else
                            {
                                if (!gi.m_FoodItem.m_Opened)
                                {
                                    decay_multiplier *= opts.packagedFoodDecay;
                                }
                                else
                                {
                                    decay_multiplier *= opts.openedFoodDecay;
                                }
                            }
                        }
                        else
                        {
                            decay_multiplier *= opts.foodDecay;
                        }
                    }
                    else
                    {
                        decay_multiplier *= opts.generalDecay;
                    }
                }
                else
                {
                    decay_multiplier *= opts.generalDecay;
                }
            }
            else
            {
                //Items that degrade on use
                //if advanced decay on use
                if (opts.advOnUseDecay)
                {
                    if (gi.m_GunItem)
                    {
                        decay_multiplier *= opts.gunDecay;
                    }
                    else if (gi.m_BowItem)
                    {
                        decay_multiplier *= opts.bowDecay;
                    }
                    else if (gi.m_FireStarterItem)
                    {
                        decay_multiplier *= opts.firestartingDecay;
                    }
                    else if (gi.m_ToolsItem)
                    {
                        decay_multiplier *= opts.toolsDecay;
                    }
                    else if (!gi.m_Bed)
                    {
                        decay_multiplier *= opts.onUseDecay;
                    }
                }
                else
                {
                    decay_multiplier *= opts.onUseDecay;
                }
            }

            return decay_multiplier;
        }
    }
}