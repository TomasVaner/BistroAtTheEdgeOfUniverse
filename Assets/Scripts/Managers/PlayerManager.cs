/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using System;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager Instance;
    
    #region Variables

        [SerializeField] private Int64 _money;
    
    #endregion
    
    #region Private Fields
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
                Destroy(gameObject);
            }
        }

    #endregion

    #region Public Methods

        public void AddMoney(int sum)
        {
            _money += sum;
        }
    #endregion

    #region Private Methods
    #endregion
    }
}