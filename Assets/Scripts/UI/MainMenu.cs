/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
#region Variables

    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private string _gameSceneName;
    
#endregion
    
#region Private Fields
#endregion

#region Unity Methods
#endregion

#region Public Methods

    public void StartTheGame()
    {
        SceneManager.LoadScene(_gameSceneName);
    }
    
    public void GoToSettings()
    {
        gameObject.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
#endregion

#region Private Methods
#endregion
}