using UnityEngine;

[System.Serializable] //Class is serializable so that multiple sounds may be created
public class Sound //Script by: B00381904
{
    public string name; //String to hold the name of the current sound
    public AudioClip clip; //AudioClip variable to hold the audio clip of the current sound
    [Range(0f, 1f)] //Keeps the value of "volume" between 0 and 1
    public float volume; //Float to hold the volume of the current sound
    [Range(.1f, 3f)] //Keeps the value of "pitch" between 0.1 and 3
    public float pitch; //Float to hold the pitch of the current sound
    public bool loop; //Bool to check if the current sound should loop
    [HideInInspector] //Hides the audio source in the inspector
    public AudioSource source; //AudioSource variable to hold the audio source of the current sound
}
