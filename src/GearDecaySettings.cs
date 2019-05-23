using System.IO;
using System.Reflection;
using ModSettings;

namespace GearDecayModifier
{
    internal class GearDecaySettings : ModSettingsBase
    {
        internal readonly GearDecayOptions setOptions = new GearDecayOptions();

        [Section("Decay Modifier Settings")]

        [Name("Global decay Rate before pickup")]
        [Description("At what rate the items will decay before being picked up or inspected. For example, 1 is default, 0.5 is half decay, and 0 is no decay until you discover the item.")]
        [Slider(0f, 2f, 1)]
        public float decayBeforePickup = 1f;

        [Name("Global decay rate")]
        [Description("Base modifier for the rate items will decay over time (doesn't affect items that decay on use). For example, 1 is default, 0 is no decay, 0.5 is half the normal decay and 2 doubles the rate. If advanced decay is on, this rate will only be applied to items not in other categories.")]
        [Slider(0f, 2f, 1)]
        public float generalDecay = 1f;

        [Name("Advanced decay Modifiers")]
        [Description("Turn this on to make decay control more granular.")]
        public bool advDecay = false;

        [Name("Clothing decay rate")]
        [Description("At what rate the clothing will decay. For example, 1 is default, 0.5 is half decay, and 0 is no decay at all.")]
        [Slider(0f, 2f, 1)]
        public float clothingDecay = 1f;

        [Name("Quarter bags decay rate")]
        [Description("At what rate the quarter bag items decay.")]
        [Slider(0f, 2f, 1)]
        public float quartersDecay = 1f;

        [Name("Bedrolls decay rate")]
        [Description("At what rate the bedroll items decay. Affects both degradation over time and when used.")]
        [Slider(0f, 2f, 1)]
        public float bedrollDecay = 1f;

        [Name("Food decay rate")]
        [Description("At what rate the food items decay. For example, 1 is default, 0.5 is half decay, and 0 is no decay at all.")]
        [Slider(0f, 2f, 1)]
        public float foodDecay = 1f;

        [Name("Advanced food decay Modifiers")]
        [Description("Turn this on to make food decay control more granular.")]
        public bool advFoodDecay = false;

        [Name("Raw meat decay rate")]
        [Description("This affects the rate at which raw meat and fish will decay.")]
        [Slider(0f, 2f, 1)]
        public float rawFoodDecay = 1f;

        [Name("Cooked meat decay rate")]
        [Description("This affects the rate at which cooked meat and fish will decay.")]
        [Slider(0f, 2f, 1)]
        public float cookedFoodDecay = 1f;

        [Name("Packaged food decay rate")]
        [Description("This affects the rate at which packaged foods and drinks will decay.")]
        [Slider(0f, 2f, 1)]
        public float packagedFoodDecay = 1f;

        [Name("Packaged food decay rate when opened")]
        [Description("This affects the rate at which packaged foods will decay while they are open.")]
        [Slider(0f, 2f, 1)]
        public float openedFoodDecay = 1f;

        [Name("Global On Use decay rate")]
        [Description("Modifier for how much tools will decay after uses. Setting this to 0.5 would make them last twice as long, while setting this to 2 will make them last half as long.")]
        [Slider(0f, 2f, 1)]
        public float onUseDecay = 1f;

        [Name("Advanced on use decay Modifiers")]
        [Description("Turn this on to make on use decay control more granular.")]
        public bool advOnUseDecay = false;

        [Name("Guns decay rate")]
        [Description("Modifies how much decay is applied when firing any gun (rifle or revolver).")]
        [Slider(0f, 2f, 1)]
        public float gunDecay = 1f;

        [Name("Bows decay rate")]
        [Description("Modifies how much decay is applied when shooting with a bow.")]
        [Slider(0f, 2f, 1)]
        public float bowDecay = 1f;

        [Name("Arrows decay rate")]
        [Description("Modifies how much decay is applied when to arrows when shot.")]
        [Slider(0f, 2f, 1)]
        public float arrowDecay = 1f;

        [Name("Fire starting gear decay rate")]
        [Description("Modifies how much decay is applied to the fire starting gear when used.")]
        [Slider(0f, 2f, 1)]
        public float firestartingDecay = 1f;

        [Name("Tools decay rate")]
        [Description("Modifies how much decay is applied to tools when used, this includes knives, hatchets or whetstones among others.")]
        [Slider(0f, 2f, 1)]
        public float toolsDecay = 1f;


        internal GearDecaySettings()
        {
            if (File.Exists(Path.Combine(GearDecayModifier.mod_options_folder, GearDecayModifier.options_file_name)))
            {
                string opts = File.ReadAllText(Path.Combine(GearDecayModifier.mod_options_folder, GearDecayModifier.options_file_name));
                setOptions = FastJson.Deserialize<GearDecayOptions>(opts);

                decayBeforePickup = setOptions.decayBeforePickup;

                generalDecay = setOptions.generalDecay;
                advDecay = setOptions.advDecay;

                foodDecay = setOptions.foodDecay;
                advFoodDecay = setOptions.advFoodDecay;
                rawFoodDecay = setOptions.rawFoodDecay;
                cookedFoodDecay = setOptions.cookedFoodDecay;
                packagedFoodDecay = setOptions.packagedFoodDecay;
                openedFoodDecay = setOptions.openedFoodDecay;

                clothingDecay = setOptions.clothingDecay;
                quartersDecay = setOptions.quartersDecay;
                bedrollDecay = setOptions.bedrollDecay;

                onUseDecay = setOptions.onUseDecay;
                advOnUseDecay = setOptions.advOnUseDecay;

                gunDecay = setOptions.gunDecay;
                bowDecay = setOptions.bowDecay;
                arrowDecay = setOptions.arrowDecay;
                firestartingDecay = setOptions.firestartingDecay;
                toolsDecay = setOptions.toolsDecay;
            }

            RefreshFields();
        }

        protected override void OnConfirm()
        {
            setOptions.decayBeforePickup = decayBeforePickup;

            setOptions.generalDecay = generalDecay;
            setOptions.advDecay = advDecay;

            setOptions.foodDecay = foodDecay;
            setOptions.advFoodDecay = advFoodDecay;
            setOptions.rawFoodDecay = rawFoodDecay;
            setOptions.cookedFoodDecay = cookedFoodDecay;
            setOptions.packagedFoodDecay = packagedFoodDecay;
            setOptions.openedFoodDecay = openedFoodDecay;

            setOptions.clothingDecay = clothingDecay;
            setOptions.quartersDecay = quartersDecay;
            setOptions.bedrollDecay = bedrollDecay;

            setOptions.onUseDecay = onUseDecay;
            setOptions.advOnUseDecay = advOnUseDecay;

            setOptions.gunDecay = gunDecay;
            setOptions.bowDecay = bowDecay;
            setOptions.arrowDecay = arrowDecay;
            setOptions.firestartingDecay = firestartingDecay;
            setOptions.toolsDecay = toolsDecay;

            string json_opts = FastJson.Serialize(this);

            File.WriteAllText(Path.Combine(GearDecayModifier.mod_options_folder, GearDecayModifier.options_file_name), json_opts);
        }

        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            if (field.Name == nameof(advDecay) || field.Name == nameof(advFoodDecay) || field.Name == nameof(advOnUseDecay))
            {
                RefreshFields();
            }
        }

        internal void RefreshFields()
        {
            SetFieldVisible(nameof(foodDecay), advDecay);
            SetFieldVisible(nameof(advFoodDecay), advDecay);
            SetFieldVisible(nameof(rawFoodDecay), advDecay && advFoodDecay);
            SetFieldVisible(nameof(cookedFoodDecay), advDecay && advFoodDecay);
            SetFieldVisible(nameof(packagedFoodDecay), advDecay && advFoodDecay);
            SetFieldVisible(nameof(openedFoodDecay), advDecay && advFoodDecay);
            SetFieldVisible(nameof(clothingDecay), advDecay);
            SetFieldVisible(nameof(quartersDecay), advDecay);
            SetFieldVisible(nameof(bedrollDecay), advDecay);

            SetFieldVisible(nameof(gunDecay), advOnUseDecay);
            SetFieldVisible(nameof(bowDecay), advOnUseDecay);
            SetFieldVisible(nameof(arrowDecay), advOnUseDecay);
            SetFieldVisible(nameof(firestartingDecay), advOnUseDecay);
            SetFieldVisible(nameof(toolsDecay), advOnUseDecay);
        }
    }
}
