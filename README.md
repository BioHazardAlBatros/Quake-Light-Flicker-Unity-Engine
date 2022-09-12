![](https://github.com/BioHazardAlBatros/Quake-Light-Flicker-Unity-Engine/blob/main/demo.gif)

THIS SCRIPT WAS MADE FOR UNITY.

Doom is a typo!!! I'm just too lazy to fix it.


Pros:

-Easy animation

-Can be used to make a scripted sequence animation

-It works

-shit sux


How to use:

1.Create an object with light component.

2.Attach this script to the same object.

3.It just works!


CustomAnim property(string):

Type any string using ONLY latin a-z symbols. Other symbols will be considered as "a" or «No light».

a - is «No light»

m - is «Normal intensity»

z - is «Double intensity»


AnimationPreset property(int):

If CustomAnim property is empty, script uses preset 0 as default(No animation; Normal intensity)


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

12-??:Your own preset!


Delay property(int):

Change this value to decrease/increase delay between light updates. DON'T MAKE IT 0!

AddIntenstity property(float):

Change this value to add some more intensity to EVERY intensity change.

Reinitialize property(bool):

Allows you to update the animation in Editor/by other scripts.

StartIntensity property(float):

Made for editor ONLY. It's an intensity multiplier that let's you change intensity "normally" during runtime. When initializing grabs a value from Light Intensity.
