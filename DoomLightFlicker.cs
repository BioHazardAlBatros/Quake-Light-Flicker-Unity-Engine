//Pros: Easy to create new presets, works on any object with Light Source(won't work on BAKED lighting for obvious reasons).

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomLightFlicker : MonoBehaviour
{
    [SerializeField] float StartIntensity;
    [SerializeField] int delay;
    [SerializeField] float AddIntensity;
    [SerializeField] string CurrentAnim, NewCustomAnim;
    [SerializeField] int AnimationPreset;
    [SerializeField] bool Reinitialize;
    private int i, tick;
    private float[] anim;
    private Light lighting;

    //I hope those will help someone with scripted events
    void SetNewPreset(int NewValue)
    {
        AnimationPreset = NewValue;
    }
    void SetNewDelay(int NewValue)
    {
        delay = NewValue;
    }
    void SetNewCustomAnim(string Animation)
    {
        NewCustomAnim = Animation;
    }
    void SetNewStartIntensity(float NewValue)
    {
        StartIntensity = NewValue;
    }
    void CallReinitialize()
    {
        Reinitialize = true;
    }

    void Start()
    {
        lighting = GetComponent<Light>();
        StartIntensity = lighting.intensity;
        GenerateAnimation();
    }
    // This function changes light intensity when number of ticks is equal to delay.
    // Why did i choose FixedUpdate? To make animation look identical on every device/pc.
    // UPD(02.20.24): Maybe i should consider using time.DeltaTime instead...
    void FixedUpdate()
    {
        //Generates new array with intensity values for animation if asked to
        if (Reinitialize)
            GenerateAnimation();
        //Updates light intensity after itdelay. 0-2  - Smooth Transition;
        if (tick++ == delay)
        {
            lighting.intensity = ((anim[i++] * StartIntensity) + AddIntensity);
            if (i == anim.Length)
                i = 0;
        }
        //Restarts frame counter.
        if (tick > delay)
            tick = 0;
    }
    //This function reads CustomAnim value, if it's empty function checks preset value and fills CustomAnim with symbols,then translates them into floats.
    void GenerateAnimation()
    {
        if (NewCustomAnim == "")
        {
            switch (AnimationPreset)
            {
                //Broken Light
                case -1:
                    NewCustomAnim = "a";
                    break;
                //Normal Light
                case 0:
                    NewCustomAnim = "m";
                    break;
                //Flicker 1
                case 1:
                    NewCustomAnim = "mmnmmommommnonmmonqnmmo";
                    break;
                //Slow strong pulse
                case 2:
                    NewCustomAnim = "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba";
                    break;
                //Candle 1
                case 3:
                    NewCustomAnim = "mmmmmaaaaammmmmaaaaaabcdefgabcdefg";
                    break;
                //Fast Strobe
                case 4:
                    NewCustomAnim = "mamamamamama";
                    break;
                //Gentle Pulse
                case 5:
                    NewCustomAnim = "jklmnopqrstuvwxyzyxwvutsrqponmlkj";
                    break;
                //Flicker 2
                case 6:
                    NewCustomAnim = "nmonqnmomnmomomno";
                    break;
                //Candle 2
                case 7:
                    NewCustomAnim = "mmmaaaabcdefgmmmmaaaammmaamm";
                    break;
                //Candle 3
                case 8:
                    NewCustomAnim = "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa";
                    break;
                //Slow strobe 4
                case 9:
                    NewCustomAnim = "aaaaaaaazzzzzzzz";
                    break;
                //Fluorescent Flicker
                case 10:
                    NewCustomAnim = "mmamammmmammamamaaamammma";
                    break;
                //Slow pulse not fade to black
                case 11:
                    NewCustomAnim = "abcdefghijklmnopqrrqponmlkjihgfedcba";
                    break;
                    //You can add your presets here.
            }
        }
        else
        {
            NewCustomAnim = NewCustomAnim.ToLower();
        }
        anim = new float[NewCustomAnim.Length];
        CurrentAnim = NewCustomAnim;
        for (int i = 0; i < NewCustomAnim.Length; i++)
        {
            if ((96 < NewCustomAnim[i]) && (NewCustomAnim[i] < 123))
                anim[i] = 0.083f * (NewCustomAnim[i] - 97);
            else
                anim[i] = 0f;
        }
        i = 0;
        tick = 0;
        Reinitialize = false;
        NewCustomAnim = "";
    }
}
