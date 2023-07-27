/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using System;
using System.Collections.Generic;
using System.Linq;
using BaseClasses;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SettingsUI : SaveableMonoBehaviour
    {
    #region Variables

        [SerializeField] private TMP_Dropdown _resolutionsDropdown;
        [SerializeField] private Toggle _fullscreenToggle;
        [SerializeField] private Slider _masterVolumeSlider;
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private Slider _effectsVolumeSlider;
        [SerializeField] private GameObject _mainMenu;
        
    #endregion
    
    #region Private Fields

        private List<Resolution> _resolutions;
        
    #endregion

    #region Unity Methods

        private void Start()
        {
            _resolutions = Screen.resolutions.Select(res => res)
                .GroupBy(res => (res.width, res.height))
                .Select(res => res.First())
                .ToList();
                
            Load();
        }

    #endregion

    #region Public Methods

        public void SetMasterVolume(float volume)
        {
            AudioManager.Instance.MasterVolume = volume;
        }
        
        public void SetMusicVolume(float volume)
        {
            AudioManager.Instance.MusicVolume = volume;
        }
        
        public void SetEffectsVolume(float volume)
        {
            AudioManager.Instance.EffectsVolume = volume;
        }

        public void SetResolution(int i)
        {
            if (i < _resolutions.Count)
                Screen.SetResolution(_resolutions[i].width, _resolutions[i].height, Screen.fullScreen);
        }
        
        public void SetFullscreen(bool value)
        {
            Screen.fullScreen = value;
        }

        public void Apply()
        {
            SaveManager.Instance.Save(GetSaveState(), "settings.json");
            ReturnToMainMenu();
        }

        public void Cancel()
        {
            Load();
            ReturnToMainMenu();
        }

        private void Load()
        {
            if (SaveManager.Instance.Load<State>("settings.json") is { } state)
            {
                SetSaveState(state);
            }
            UpdateUI();
        }

    #endregion

    #region Private Methods

        public override object GetSaveState()
        {
            var state = new State
            {
                _audioSettings = AudioManager.Instance.GetSaveState(),
                _fullScreen = Screen.fullScreen,
                _resolution = (Screen.currentResolution.width, Screen.currentResolution.height)
            };
            return state;
        }

        public override void SetSaveState(object state)
        {
            if (state is State newState)
            {
                AudioManager.Instance.SetSaveState(newState._audioSettings);

                int resIndex = _resolutions.FindIndex(
                    res => res.width == newState._resolution.w && res.height == newState._resolution.h);
                int minDiff = Int32.MaxValue;
                if (resIndex < 0)
                {
                    for (int index = 0; index < _resolutions.Count; ++index)
                    {
                        int diff = Math.Abs(_resolutions[index].width - newState._resolution.w) +
                                   Math.Abs(_resolutions[index].height - newState._resolution.h);
                        if (diff < minDiff)
                        {
                            minDiff = diff;
                            resIndex = index;
                        }
                    }
                }
                SetResolution(resIndex);
                SetFullscreen(newState._fullScreen);
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            int selectedIndex = _resolutions.FindIndex(res =>
                res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height);
            if (selectedIndex < 0)
                selectedIndex = 0;
            
            _resolutionsDropdown.ClearOptions();
            _resolutionsDropdown.AddOptions(
                _resolutions.Select(
                        res => res.width + "x" + res.height)
                    .ToList());

            _resolutionsDropdown.value = selectedIndex;
            _resolutionsDropdown.RefreshShownValue();
            
            _fullscreenToggle.isOn = Screen.fullScreen;

            _masterVolumeSlider.value = AudioManager.Instance.MasterVolume;
            _musicVolumeSlider.value = AudioManager.Instance.MusicVolume;
            _effectsVolumeSlider.value = AudioManager.Instance.EffectsVolume;
        }

        private void ReturnToMainMenu()
        {
            gameObject.SetActive(false);
            _mainMenu.SetActive(true);
        }

    #endregion
        
    #region Types

        [Serializable]
        private class State
        {
            [SerializeReference] public object _audioSettings;
            public (int w, int h) _resolution = (1920, 1080);
            public bool _fullScreen = true;
        }

    #endregion
        
    }
}