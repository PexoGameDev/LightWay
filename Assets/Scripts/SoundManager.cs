using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [System.Serializable]
    public struct Sound
    {
        public string name;
        public AudioSource source;

        [Range(-3, 3)]
        public float pitchMin;
        [Range(-3, 3)]
        public float pitchMax;
        [Range(0, 1)]
        public float volumeMin;
        [Range(0, 1)]
        public float volumeMax;

        public Sound(string name, AudioSource source, float pitchMin, float pitchMax, float volumeMin, float volumeMax)
        {
            this.name = name;
            this.source = source;
            this.pitchMin = pitchMin;
            this.pitchMax = pitchMax;
            this.volumeMin = volumeMin;
            this.volumeMax = volumeMax;
        }
    }

    public Sound[] soundList;

    public void PlaySound (string name)
    {
        foreach(Sound sound in soundList)
        {
            if(sound.name == name)
            {
                sound.source.pitch = Random.Range(sound.pitchMin, sound.pitchMax);
                sound.source.volume = Random.Range(sound.volumeMin, sound.volumeMax);

                sound.source.Play();

                break;
            }
        }
	}
}