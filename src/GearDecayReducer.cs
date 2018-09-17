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
    }

    public class GearDecayReducer
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

            [Name("Global decay rate")]
            [Description("Modifier for the rate the items will decay. 1 is default, 0 is no decay, and 2 doubles the rate.")]
            [Slider(0f, 2f)]
            public float general_decay = 1f;


            [Name("Decay Rate before pickup")]
            [Description("At what rate the items will decay before being picked up or inspected. 1 is default, 0 is no decay until you touch the item.")]
            [Slider(0f, 2f)]
            public float decay_before_pickup = 1f;

            protected override void OnConfirm()
            {
                GearDecayOptions.general_decay = general_decay;
                GearDecayOptions.decay_before_pickup = decay_before_pickup;

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
                }

                custom_settings.AddToModSettings("Xpazeman Mini Mods");
            }
        }
    }
}