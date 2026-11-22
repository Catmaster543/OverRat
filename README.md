# What is this game about?
In this game, you **play as a rat carrying an uknown disease, that will cause those bitten enough to turn into one of you, a rat.** Your ultimate goal is to infect the entirety of humanity, but that's a far stretch for now. **Play [here](https://cat-master543.itch.io/overrat)**

<p align="center">
  <img width="502" height="432" alt="Snímek obrazovky 2026-10-25 181116" src="https://github.com/user-attachments/assets/0e01cd5c-2eee-4f5e-99cb-85e04d0c8ff8" />
</p>

## Current features:
- **Fully working player movement system** - you can move around, rotate your camera and even make tiny cute jumps!
- **Intro, Pre-game & game phases**
  - Intro stage is quite simple really, all you have to do is take a look around the newly added sewers!
  - During the pre-game you can collect ingredients around the map with a set time
  - In the game you "bite" people (for now)
- **Working biting/damage & hp system** - you can bite dummy targets for now that have a set amout of hp and if you cause enough damage you kill them (for now).
- **First puzzle in place** - explore the map a little to find these, once you figure out where they're at you'll find a way to get there.
- **Gaining experience** - the more people you *kill* (only for now) the more xp you get.
- **Simple upgrades** - upgrade your damage, or range for the xp you've received in the sewers (which is just a baseplate with 5 rats for now)
- **Working fading system** that fades between transfers in the main game (not from main menu yet!)
- **Dynamic info text** that shows you what you've just picked up
- **Working objective** text, showing you your current objective
- **Damage and biting indicators** - whenever you begin your round you'll get a tip reminding you to bite someone. After you do so it's gone. And once you bite someone you can see how much hp they have left from the red bar that appears.
- **Main menu** - I've implemented a super simple main menu, which allows you to either enter the game or quit.
- **Random NPC movement** - spawned in NPC move around the map
- **3 Different ingredients** - collect these and merge them into your infection! (still wip)
- **Brewing cutscene** - after you finish collecting the ingredients they will all be dropped into the cooking pot and a cube with color mixed from what you've picked up will appear. This will be replaced in the future
- **Antenna cutscene** - don't go near one, it ain't the safest place to be!
- **Talkable ol'rat ghost NPC** - have a chat with him, you can find him in the sewers.
- **Game ending conditions and menus for them** - if you run out of lives, you'll get the game over menu. If you manage to bite every person that has been spawned in you win!

## Latest added features (what was added this update?)
### Reach the peak update
- **Big map improvements!**
  - Added a few extra buildings
  - Added windows to some buildings
  - Added roofs to all houses on the map
  - Added almost full interior of one of the rooms
  - Added antenna to one of the houses
  - Fixed the map's scale of certain objects, like the trees for example
- **Added the first puzzle**
  - Reason for making of one of the new houses interiors
  - Mainly parkour, should be doable in the newly extended collect time
- **New antenna cutscene**
  - Don't stand near the antenna, that's all I'll tell you
- **2 New ingredients**
  - **The rock** - yeah it's a rock, what did you expect?
  - **The leaf** - found under trees surprisingl
- **Effects on ingredients**
  - Ingredients can now have their own effects, which can modify their (for example) damage values
  - First test effect is already in-game, try to find it!
  - Added showing of effect icons to the inventory, so you know if you have an effect on an item or not
- **Results screen**
  - A super simple screen shown after the brewing cutscene that shows you damage and effects for now
- **Added rat spawning from killed enemies**
  - Now when you bite someone to death, a rat shall appear in their place. (Sometimes the rat spawns underground for some reason, not sure why it's not working)
- **Added fall damage**
  - I'm sorry, it had to be done. When you jumped from the roof of a building, just landing and being able to continue normally just doesn't make much sense.
- **And so much more!** - be sure to read through my commits in case I missed anything here :)

## Planned features
- Proper models for people
- A way larger map
- Proper models for the environment
- Entire graphics-side overhaul
- Deratizators chasing you down after you openly bite someone
- Complete upgrades overhaul to match the infection theme closer
- And much much more!

## Your goal
Collect ingredients and then bite everyone on the map!

## Controls
- Moving around - WASD
- Camera movement - hover around with your mouse just like in any other games
- Biting - Left Mouse Button click
- Grabbing - Left Mouse Button click
- Talking to NPCs - Left Mouse Button click

### AI Usage declaration
No generative AI has been used.
