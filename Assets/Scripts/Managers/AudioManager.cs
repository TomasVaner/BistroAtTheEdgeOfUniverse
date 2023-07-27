/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using System;
using BaseClasses;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace Managers
{
    public class AudioManager : SaveableMonoBehaviour
    {
        [SerializeField] public static AudioManager Instance;
        
    #region Variables

        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _effectSource;
        [SerializeField] private AudioMixer _audioMixer;
        
    #endregion
    
    #region Private Fields
    #endregion

    #region Properties
        
        public float MusicVolume
        {
            get
            {
                _audioMixer.GetFloat("MusicVolume", out float volume);
                return volume;
            }
            set => _audioMixer.SetFloat("MusicVolume", value);
        }

        public float EffectsVolume
        {
            get
            {
                _audioMixer.GetFloat("EffectsVolume", out float volume);
                return volume;
            }
            set => _audioMixer.SetFloat("EffectsVolume", value);
        }

        public float MasterVolume
        {
            get
            {
                _audioMixer.GetFloat("MasterVolume", out float volume);
                return volume;
            }
            set => _audioMixer.SetFloat("MasterVolume", value);
        }

    #endregion

    #region Unity Methods
        void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    #endregion

    #region Public Methods

        public void PlayEffect(AudioClip effect, float volume = 1f)
        {
            _effectSource.PlayOneShot(effect, volume);
        }
        
        public void ChangeMusic(AudioClip music, float volume = 1f)
        {
            _musicSource.clip = music;
        }

        public override object GetSaveState() => new State()
        {
            _effectVolume = EffectsVolume,
            _masterVolume = MasterVolume,
            _musicVolume = MusicVolume
        };

        public override void SetSaveState(object state)
        {
            if (state is not State newState) return;
            
            MasterVolume = newState._masterVolume;
            MusicVolume = newState._musicVolume;
            EffectsVolume = newState._effectVolume;
        }
        
    #endregion

    #region Private Methods
    #endregion

    #region Types

        [Serializable]
        private class State
        {
            [Header("Volume")]
            [Range(0f, 1f)] [SerializeField] public float _masterVolume = 0f;
            [Range(0f, 1f)] [SerializeField] public float _musicVolume = 0f;
            [Range(0f, 1f)] [SerializeField] public float _effectVolume = 0f;
        }

    #endregion
        
    }
}