![](https://github.com/BioHazardAlBatros/Quake-Light-Flicker-Unity-Engine/blob/main/demo.gif)

THIS SCRIPT WAS MADE FOR UNITY.
Doom is a typo!!! I'm just too lazy to fix it.

How to use:
1.Create an object with light component.
2.Attach this script to the same object.
3.It just works!

CustomAnim property:
Type any string using ONLY latin a-z symbols.
a - is «No light»
m - is «Normal intensity»
z - is «Double intensity»

AnimationPreset property:
If CustomAnim property is empty, script uses 0 preset as default(No animation; Normal intensity)
Premade presets:
-1: Broken Light
 0: Normal Light
 1: Flicker 1
 2: Slow strong pulse
 3: Candle 1
 4: Fast Strobe
 5: Gentle Pulse
 6: Flicker 2
 7: Candle 2
 8: Candle 3
 9: Slow strobe 4
10: Fluorescent Flicker
11: Slow pulse not fade to black

Delay property:
Change this value to decrease/increase delay between light updates.

AddIntenstity property:
Change this value to add some more intensity to EVERY intensity change.
