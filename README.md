# Gear Decay Modifier
Mod for The Long Dark to modify decay rates of gear

## Options
+ **Decay rate before pickup**: Modifies the decay rate of gear before player has inspected or taken the item.
+ **Food decay rate**: The rate at which food that isn't inside a container decays. Affects to inside/outside/inventory.
+ **Stored food decay rate**: The rate at which food that is stored inside a container decays.
+ **Clothing decay rate**: The rate at which clothing that isn't inside a container decays. Affects to inside/outside/inventory.
+ **Stored clothing decay rate**: The rate at which clothing that is stored inside a container decays.
+ **Other items decay rate**: Modifies the rate of gear decay for the rest of items.
+ **Apply decay modifier to tools on use**: Wether or not to apply the global modifier to tools when they are used.

## Installation
* Download and install [Mod Installer](https://github.com/WulfMarius/Mod-Installer/releases) by **WulfMarius** if you don't have it already.
* After opening it, click on refresh sources at the top.
* Install the latest [ModSettings](https://github.com/zeobviouslyfakeacc/ModSettings) by **zeobviouslyfakeacc** from the list if you don't have it or have an earlier version.
* Install GearDecayModifier from the list.

## Updating
* Open ModInstaller and click on Refresh Sources, click on GearDecayModifier from the list, and click on the Update button to the right.

## Examples
For these examples let's assume a food item that takes 100 hours to completely degrade, and a clothing item that takes 50 days to do the same:
* With a **Decay rate before pickup** setting of 0.5, ALL items, no matter which type, will decay at half speed until you find them. If it takes you 25 days to find that piece of clothing, instead of it being at 50% condition, you'll find it at 75% condition.
* If you set **Decay rate before pickup** to 0, things won't start decaying at all until you have found them (kinda like the earlier versions of tld did)
* With a **Food decay rate** of 0.5, the food item will take 200 hours to degrade completely instead of 100 when it is stored outside of a container (on the floor or in your inventory)
* With a **Stored food decay rate** of 0.1, if you store that food item inside a container, it will take 1000 hours to completely degrade.
* Same applies to the clothing options. With a setting of 0.2 in **Stored clothing decay rate** and a setting of 0.5 in **Clothing decay rate**, the same item would take 100 days to fully degrade while on your inventory, and 250 days while inside a container.
* If **Apply decay modifier to tools on use** is enabled, and you have a **Global decay rate** of 0.2, if a hatchet lost 5% when used normally, it would lose 1% per use.
* **Global decay rate** is applied in every other situation (storm lanterns, quarter bags, matches, etc in every situation)

## Uninstalling
* Go into your mods folder (<path_to_TheLongDark_installation_folder>/mods) and delete **GearDecayModifier.dll**, from that point, every item will be back to decaying normally.