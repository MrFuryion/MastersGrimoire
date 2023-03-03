  /  |/  /__ ____/ /____ ___( )___   / ___/___(_)_ _  ___  (_)______ 
 / /|_/ / _ `(_-< __/ -_) __//(_-<  / (_ / __/ /  ' \/ _ \/ / __/ -_)
/_/  /_/\_,_/___|__/\__/_/   /___/  \___/_/ /_/_/_/_/\___/_/_/  \__/ 

    		  __...--~~~~~-._   _.-~~~~~--...__
    		//               `V'               \\ 
   	       //                 |                 \\ 
 	      //__...--~~~~~~-._  |  _.-~~~~~~--...__\\ 
 	     //__.....----~~~~._\ | /_.~~~~----.....__\\
            ====================\\|//====================
                    		`---`

A Celtic Heroes search tool that allows you to search mob, item, and damage related data. Also includes some calculators to assist in theorycrafting damage/DPS.
(Accurate as of September 1st 2022)

< Table of Contents >
I. Usage Guide(NPC/Enemy)
II. Usage Guide(Skill/Auto)
III. Usage Guide(DPS/Aggro)
IV. Usage Guide(Item)
V. FAQs
VI. Known Problems

< I. Usage Guide(NPC/Enemy) >

[Monster Searching]

1. Begin by searching a monster name(the same as you see in-game) or ID(you probably won't know this but it's good to have).
(The results will refresh on every letter added. This may be slow on old computers)

2. Click on one of the results in the box below. All of the monster's stats will be loaded below that.
(The ID of the monster is shown in the ID searchbox upon doing this, if you are interested in that)

(Optional)
3. If auto-search is ON, the drop sets of that monster will appear in the top right box. If there is an x2(or more) at the end that means that the set is used/rolled twice(or more) for loot.

(Optional 2)
4. If one of the drop sets from above is clicked, the middle box on the righthand side of the screen will list out the loot tables for that loot set, along with the names and percentage chance of them occuring.

(Optional 3)
5. If one of the drop tables is clicked, all of the items with their names and percentage chance of dropping are shown below.

[Loot Set Searching]

1. Uncheck the Auto Search checkbox, the loot set search tool will open.

2. Search a name or an ID and results will pop up in the box below.
(You are searching loot table names, not loot set names. Loot sets are not named, and this is the closest to a name searcher we can get. The number on the left of the names is the loot set ID)

3. Click on a result and all of the loot tables within the set(and their names/percentages) will be shown in the box below.

4. Click on one of the loot tables and all of the items within will be shown in the box below that.

[Item Searching]
(This method of searching is much slower than the other ones, due to it having to search several lists to complete)

1. Check the Item Search checkbox.

2. Search the name of the item you want to find, or its ID.
(If Auto Search is on you can search mobs, if it is off you can search loot sets)

3. All mobs that drop it, or all loot sets that contain the item(depending on if Auto Search is on or off) will appear in the box below.

[Filter Section Guide]
(These options can be found on the bottom right on the first page)

If you want to filter by item name, type what you want to look for in Filter Results, if you want to remove the filter just backspace until there is nothing left.

You can switch between percentage and fractional representation for loot table/item odds, fractions are automatically simplified as far as possible.

You can switch between basic and combined odds for items.
Basic - Shows the chance of the item being picked from that loot table.
Combined - Shows the REAL chance of the item being picked from that drop slot(the normal basic chance multiplied by the chance of the loot table it is from occurring).
(Fractions do NOT work well with this mode due to their nature(they don't use decimals), and will usually be inaccurate)

You can switch between showing items or showing tiers.
Show Items - Shows the items as normal.
Show Tiers - Sorts items into groups, which are customizable(read below if you want to find out how)

The file that contains the tiers/groups is located at /Resources/Settings/tiers.txt
The data needed is...
1. The Search Mode, 0 will search for the text anywhere in the item's name, 1 will search for if the item's name starts with it, 2 will search for if it ends with it.
2. The text to search for.
3. The name you want the results to be grouped under.
The entries are laid out like this...
1~2~3

[Enemy Skills]

If you search an enemy that has skill attacks or abilities, the Enemy Skills button will activate, press it to show a window containing these skills/abilities.

[Spawn Data]

If you search an enemy that has at least one spawn point in the game(the Spawn Points number will tell you how many), you can use the Spawn Data Button.

Pressing this button opens up a new window and automatically loads the first instance of the enemy it finds and displays it along with other enemies on that map.
(You can zoom in and out using the buttons below the map)

The spawn points are color coded, and you can figure out what means what by looking at the colored rectangles on the bottom right under Legend.
(You can also change these colors by clicking on those rectangles)

Dots on the map are enemy spawn points, lines are paths the enemies can walk, circles mean that the enemy walks randomly in that area.

You can click on the arrows on the bottom right to jump around to different spawn points that contain the enemy you searched, and you can use the dropdown selection on the top right to change maps.

You can click on other dots to view other spawn points, and data related to that spawn point will be loaded.

You can change the selected mob by selecting a mob in Possible Mob Spawns and then hitting the Switch Mob button, which will allow you to use the arrow buttons to search for that mob instead.

You can use the Show Other Spawns checkbox to show/hide unrelated spawns(doesn't delete the one you are on if its unrelated), and Show Movement Paths to show/hide enemy paths.

< II. Usage Guide(Skill/Auto) >

[Skill Searching]

1. Begin by searching a skill name in the skill search textbox.

2. Click on a result in the box below, the skill's stats will be loaded below that(level 1), and if auto-search is enabled the related status effect will be loaded on the bottom right if the skill has one.

3. If you would like to change the skill's level use the dropdown list under skill level to choose the level you want to see.
(If auto-search is on the status will also change its level to match the skill)

[Status Searching]

1. Turn off the auto-search, the status search tool will open.

2. Click on a result in the box below, the status's stats will be loaded below that(level 1)
(Most Statuses only have one effect, but there is a status formula 2 for those that have two.)

3. If you would like to change the status's level use the dropdown list under status level to choose the level you want to see.

[Extra Data]

If a status has additional data, such as an aura or character effect, this button will be enabled. Click it to view that data.

[Calculation]

1. Enter all of your stats on the top right and choose the skill/status you would like calculated(or none if you just want your auto damage calculated).

2. Press the Calculate button and your results will appear on the bottom of the program.

< III. Usage Guide(DPS/Aggro) >

1. Press the Enter Mob Stats button.

2. Either search for a mob and select it, or check the Custom Mob checkbox to enter your own stats in. PvP Mode can also be selected, if you want to emulate dueling a player(there are some differences between PvP and PvE).

3. Press the Save Selected Mob button.

4. Press the Enter Player Stats Button

5. Enter your stats and press the Save Player Stats Button

6. Press the Add New Action button to add auto attacks/skills/statuses.
- Cooldown reduction and direct damage can be added, as well as positive/negative stat modifiers and empty space, to account for swaps, lag, or other things.

7. The factors at play will be shown in the boxes, the middle and right box will change depending on which relevance mode is selected.
Selected - What is shown in the box is only relevant to the one action selected in the left box.
Total - What is shown in the box is relevant to every action combined.

< IV. Usage Guide(Item) >

[Item Searching]

1. Search a name or ID with Stat Search unchecked.

2. Click on one of the results below to load the stats of that item on the right.
(You can press the Display Mode button to switch between viewing how the item would look in-game and all stats)

[Item Filtering]

1. Check the Stat Search checkbox.

2. Press the Advanced Search Button

3. Press Add New Filter, choose what you want, and press Start Search.
(You can use as many filters as you'd like)

[Set Bonuses]

1. If an item you search has a set bonus, the Set Bonus button will be enabled.
(It will also tell you the name of the set bonus, or the amount if it's more than one)

2. Press the Set Bonus button to open a new window with more information.

3. The items required to activate the set bonus will be listed on the left.
(You can use the Sort By Equipment Slot dropdown list to filter the results if need be)

4. The rewards from the set bonus are on the right.
(You can switch to other set bonuses this item has by using the Set Bonus Selected dropdown list)

< V. FAQs >
Q - Why can't I open the program?
A1 - If the program hasn't been unzipped yet, it won't work.
A2 - If the Resources folder isn't in the same folder as the program, it won't work.
A3 - If Smartscreen stops you from opening it, press More Info, then press Run Anyway.

Q - Why aren't the loot tables/sets and items listed in order?
A - That would require a bit of extra work, and I think it actually is better in its current order. Jumbled up loot sets make it easier to search as you would already know what is in the set by clicking it. Having the items in the natural order usually pair similar items by default(the item IDs are typically close and that is what the names are pulled from), and rare items such as a dark moon helm wouldn't be thrown to the bottom of the list.

Q - Why did Visual come up for the status formula?
A - This status does not contain any information within the status itself. Any buffs it grants are likely scripted in or given by an "invisible item".

Q - Why does the DPS/Aggro Solver show a non-zero critical hit chance with 0 ability?
A - One of the requirements of hitting a crit is that you have the ability, we assume you do in all cases. Aside from that, there is a part in the equation that gives you a small chance even with 0 ability.

Q - Why are some consumables missing part of their description?
A - Consumables sometimes list their effect in the description, but I was unable to figure out how.

< VI. Known Problems >

Damage formulas may be off by a single point.
The program sometimes crashes if very large numbers are added(Int32 Limit/2.14 billion)
Consumables sometimes missing part of their description.

-Furyion