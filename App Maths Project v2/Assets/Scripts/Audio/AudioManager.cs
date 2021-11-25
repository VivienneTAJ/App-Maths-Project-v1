using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour //Script by: B00381904
{
    public Sound[] sounds; //Sound array to hold all of the sounds in the game 
    public static AudioManager instance; //AudioManager variable to hold the current instance of the Audio Manager
    public AudioMixerGroup BGM; //AudioMixerGroup to hold the background music of the game
    public AudioMixerGroup SFX; //AudioMixerGroup to hold the sound effects of the game

    private void Awake()
    {
        if (instance == null) //If there is no other Audio Manager in the scene
        {
            instance = this; //Set the current instance to this Audio Manager
        }
        else
        {
            Destroy(gameObject); //Else destroy this Audio Manager to prevent duplicate Audio Managers in the scene
            return; //Exits the "Awake" method as no further code needs to be executed in this case
        }
        DontDestroyOnLoad(gameObject); //Add this Audio Manager to DontDestroyOnLoad so that it persists between scenes
        foreach (Sound s in sounds) //For each sound in the sounds array
        {
            s.source = gameObject.AddComponent<AudioSource>(); //Adds an AudioSource to the current sound so that it may be played
            s.source.clip = s.clip; //Sets the AudioSource's clip to the clip of the current sound
            s.source.volume = s.volume; //Sets the AudioSource's volume to the volume of the current sound
            s.source.pitch = s.pitch; //Sets the AudioSource's pitch to the pitch of the current sound
            s.source.loop = s.loop; //Sets the AudioSource's loop value to the loop value of the current sound (This will be true or false)
            s.source.outputAudioMixerGroup = BGM; //Sets the AudioSource's AudioMixerGroup to BGM by default
            if (s.clip.name[0] == 'S') //If the current clip's name starts with the letter 'S' (All SFX in game has the prefix "SFX_")
            {
                s.source.outputAudioMixerGroup = SFX; //Sets the AudioSource's AudioMixerGroup to SFX
            }            
        }
    }
    public void Play(string name) //Method to Play the current sound
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //Finds the required sound inside the sounds array by name
        if (s == null) //If the sound does not exist
        {
            Debug.LogWarning($"Sound: {name} not found!"); //Display error message
            return; //Exits the "Play" method as no further code needs to be executed in this case
        }
        s.source.Play(); //Plays the current sound
    }
    public void Stop(string name) //Method to Stop the current sound
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //Finds the required sound inside the sounds array by name
        s.source.Stop(); //Stops the current sound
    }
}
