using System;
using UnityEngine;

namespace BukoClimbers
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        
        public Sound[] musicSounds, sfxSounds;
        public AudioSource musicSource, sfxSource;

        private void OnEnable()
        {
            PlayMusic("MainMenu_Theme");
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayMusic(string name)
        {
            Sound s = Array.Find(musicSounds, x => x.name == name);

            if (s == null)
            {
                Debug.Log("Music not found", this);
            }
            else
            {
                musicSource.clip = s.clip;
                musicSource.Play();
            }
        }

        public void PlaySfx(string name)
        {
            Sound s = Array.Find(sfxSounds, x => x.name == name);

            if (s == null)
            {
                Debug.Log("SFX not found", this);
            }
            else
            {
                sfxSource.PlayOneShot(s.clip);
            }
        }

        public void ToggleMusic()
        {
            musicSource.mute = !musicSource.mute;
        }
        
        public void ToggleSFX()
        {
            sfxSource.mute = !sfxSource.mute;
        }

        public void MusicVolume(float volume)
        {
            musicSource.volume = volume;
        }
        
        public void SFXVolume(float volume)
        {
            sfxSource.volume = volume;
        }
    }
}
