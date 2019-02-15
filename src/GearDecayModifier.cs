using System;
using System.IO;
using System.Reflection;
using ModSettings;
using UnityEngine;

namespace GearDecayModifier
{
    public class GearDecayOptions
    {
        public static float decay_before_pickup = 1f;
        public static float general_decay = 1f;
        public static float food_decay = 1f;
        public static float clothing_decay = 1f;
        public static bool apply_to_tools = false;
    }

    public class GearDecayModifier
    {
        public static string mods_folder;
        public static string mod_options_folder;
        public static string options_folder_name = "xpazeman-minimods";
        public static string options_file_name = "config-decay.json";

        public static void OnLoad()
        {
            Debug.Log("[gear-decay-reducer] Version " + Assembly.GetExecutingAssembly().GetName().Version);

            mods_folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            mod_options_folder = Path.Combine(mods_folder, options_folder_name);
        }

        internal class GearDecaySettings : ModSettingsBase
        {
            [Section("Decay Reducer Settings")]

            [Name("Global decay Rate before pickup")]
            [Description("At what rate the items will decay before being picked up or inspected. For example, 1 is default, 0.5 is half decay, and 0 is no decay until you discover the item.")]
            [Slider(0f, 2f, 1)]
            public float decay_before_pickup = 1f;

            [Name("Food decay rate")]
            [Description("At what rate the food items decay. For example, 1 is default, 0.5 is half decay, and 0 is no decay at all.")]
            [Slider(0f, 2f, 1)]
            public float food_decay = 1f;

            [Name("Clothing decay rate")]
            [Description("At what rate the clothing will decay. For example, 1 is default, 0.5 is half decay, and 0 is no decay at all.")]
            [Slider(0f, 2f, 1)]
            public float clothing_decay = 1f;

            [Name("Global decay rate")]
            [Description("Modifier for the rate the rest of items will decay. For example, 1 is default, 0 is no decay, 0.5 is half the normal decay and 2 doubles the rate.")]
            [Slider(0f, 2f, 1)]
            public float general_decay = 1f;

            [Name("Apply decay modifier to tools on use")]
            [Description("If set to yes, the global modifier will be applied when tools like hatchet or whetstone are used.")]
            public bool apply_to_tools = false;

            protected override void OnConfirm()
            {
                GearDecayOptions.general_decay = (float)Math.Round(general_decay, 1);
                GearDecayOptions.decay_before_pickup = (float)Math.Round(decay_before_pickup, 1);
                GearDecayOptions.apply_to_tools = apply_to_tools;
                GearDecayOptions.food_decay = (float)Math.Round(food_decay, 1);
                GearDecayOptions.clothing_decay = (float)Math.Round(clothing_decay, 1);

                string json_opts = FastJson.Serialize(this);

                File.WriteAllText(Path.Combine(mod_options_folder, options_file_name), json_opts);
            }
        }

        internal static class GearDecaySettingsLoad
        {
            private static GearDecaySettings custom_settings = new GearDecaySettings();

            public static void OnLoad()
            {
                if (File.Exists(Path.Combine(mod_options_folder, options_file_name)))
                {
                    string opts = File.ReadAllText(Path.Combine(mod_options_folder, options_file_name));
                    custom_settings = FastJson.Deserialize<GearDecaySettings>(opts);

                    GearDecayOptions.general_decay = custom_settings.general_decay;
                    GearDecayOptions.decay_before_pickup = custom_settings.decay_before_pickup;
                    GearDecayOptions.apply_to_tools = custom_settings.apply_to_tools;
                    GearDecayOptions.food_decay = custom_settings.food_decay;
                    GearDecayOptions.clothing_decay = custom_settings.clothing_decay;
                }

                custom_settings.AddToModSettings("Gear Decay Modifier");
            }
        }
    }
}