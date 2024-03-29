﻿using System.Reflection;
using UnityEngine;
using MelonLoader;
using Il2Cpp;

namespace GearDecayModifier
{
    public class GearDecayModifier : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        public static float ApplyDecayModifier(GearItem gi)
        {
            float decay_multiplier = 1f;

            if (gi.m_Bed)
            {
                decay_multiplier *= Settings.options.bedrollDecay;
            }
            else
            {
                if (!gi.m_DegradeOnUse)
                {
                    //Before pickup decay
                    if (!gi.m_BeenInspected && !gi.m_BeenInPlayerInventory)
                    {
                        decay_multiplier *= Settings.options.decayBeforePickup;
                    }

                    //Natural degrade
                    //if advanced decay
                    if (Settings.options.advDecay)
                    {
                        if (gi.name == "GEAR_FlareGunAmmoSingle")
                        {
                            decay_multiplier *= Settings.options.flareGunAmmoSingleDecay;
                        }
                        else if (gi.name == "GEAR_CoffeeTin")
                        {
                            decay_multiplier *= Settings.options.coffeeTinDecay;
                        }
                        else if (gi.name == "GEAR_GreenTeaPackage")
                        {
                            decay_multiplier *= Settings.options.greenTeaPackageDecay;
                        }
                        else if (gi.m_ClothingItem)
                        {
                            decay_multiplier *= Settings.options.clothingDecay;
                        }
                        else if (gi.m_BodyHarvest)
                        {
                            decay_multiplier *= Settings.options.quartersDecay;
                        }
                        else if (gi.m_ArrowItem)
                        {
                            decay_multiplier *= Settings.options.arrowDecay;
                        }
                        /*else if (gi.name == "GEAR_GreenTeaCup" || gi.name == "GEAR_ReishiTea" || gi.name == "GEAR_RoseHipTea" || gi.name == "GEAR_BurdockTea" || gi.name == "GEAR_BirchbarkTea" || gi.name == "GEAR_CoffeeCup" || gi.name == "GEAR_AcornCoffeeCup")
                        {
                            decay_multiplier *= Settings.options.cookedTeasAndCoffeesDecay;
                        }*/
                        else if (gi.m_FoodItem)
                        {
                            //if advanced food
                            if (Settings.options.advFoodDecay)
                            {
                                if (gi.m_FoodItem.m_IsNatural)
                                {
                                    if (gi.m_FoodItem.m_IsRawMeat)
                                    {
                                        decay_multiplier *= Settings.options.rawFoodDecay;
                                    }
                                    else
                                    {
                                        decay_multiplier *= Settings.options.cookedFoodDecay;
                                    }
                                }
                                else
                                {
                                    if (!gi.m_FoodItem.m_Opened)
                                    {
                                        decay_multiplier *= Settings.options.packagedFoodDecay;
                                    }
                                    else
                                    {
                                        decay_multiplier *= Settings.options.openedFoodDecay;
                                    }
                                }
                            }
                            else
                            {
                                decay_multiplier *= Settings.options.foodDecay;
                            }
                        }
                        else if (gi.m_FirstAidItem)
                        {
                            decay_multiplier *= Settings.options.firstAidDecay;
                        }
                        else
                        {
                            decay_multiplier *= Settings.options.generalDecay;
                        }
                    }
                    else
                    {
                        decay_multiplier *= Settings.options.generalDecay;
                    }
                }
                else
                {
                    //Items that degrade on use
                    //if advanced decay on use
                    if (Settings.options.advOnUseDecay)
                    {
                        if (gi.m_GunItem)
                        {
                            decay_multiplier *= Settings.options.gunDecay;
                        }
                        else if (gi.m_BowItem)
                        {
                            decay_multiplier *= Settings.options.bowDecay;
                        }
                        else if (gi.m_FireStarterItem)
                        {
                            decay_multiplier *= Settings.options.firestartingDecay;
                        }
                        else if (gi.name == "GEAR_SharpeningStone")
                        {
                            decay_multiplier *= Settings.options.whetstoneDecay;
                        }
                        else if (gi.name == "GEAR_Prybar")
                        {
                            decay_multiplier *= Settings.options.prybarDecay;
                        }
                        else if (gi.m_ToolsItem)
                        {
                            decay_multiplier *= Settings.options.toolsDecay;
                        }
                        else
                        {
                            decay_multiplier *= Settings.options.onUseDecay;
                        }
                    }
                    else
                    {
                        decay_multiplier *= Settings.options.onUseDecay;
                    }
                }
            }
            return decay_multiplier;
        }
    }
} 