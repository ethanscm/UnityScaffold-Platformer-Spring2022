using UnityEngine.Audio;
using System;
using UnityEngine;

public class InventoryAudioManager : MonoBehaviour
{
	public InventorySound[] sounds;
	

    void Awake()
    {
        foreach (InventorySound s in sounds)
        {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
		InventorySound s = Array.Find(sounds, sound => sound.name == name);
		s.source.Play();
    }
}
