using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [System.Serializable]
    public struct Sound
    {
        public string name;
        public AudioSource source;

        public Sound(string name, AudioSource source)
        {
            this.name = name;
            this.source = source;
        }
    }

    public Sound[] soundList;

    [Range(0, 1)]
    public float pitchMin;
    [Range(0, 1)]
    public float pitchMax;
    [Range(0, 1)]
    public float volumeMin;
    [Range(0, 1)]
    public float volumeMax;

    private void Start()
    {
        PlaySound("Sho 2");
    }

    public void PlaySound (string name)
    {
        foreach(Sound sound in soundList)
        {
            if(sound.name == name)
            {
                sound.source.pitch = Random.Range(pitchMin, pitchMax);
                sound.source.volume = Random.Range(volumeMin, volumeMax);

                sound.source.Play();

                break;
            }
        }
	}
}