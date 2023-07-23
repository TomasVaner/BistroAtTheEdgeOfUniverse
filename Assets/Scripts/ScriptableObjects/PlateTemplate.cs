/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using Managers;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Plate", menuName = "ScriptableObjects/Plate Template", order = 1)]
    public class PlateTemplate : SpriteTemplate
    {
    #region Variables

        public int cost;
    #endregion
    
    #region Private Fields
    #endregion

    #region Public Methods

        void Sell(bool full)
        {
            PlayerManager.Instance.AddMoney(full ? cost : cost / 2);
        }
    #endregion

    #region Private Methods
    #endregion
    }
}