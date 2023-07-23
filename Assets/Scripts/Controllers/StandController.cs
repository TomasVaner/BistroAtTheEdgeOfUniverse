/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Controllers
{
    public class StandController : MonoBehaviour
    {
    #region Variables

        [SerializeField] private List<Transform> _placementPoints;
        [SerializeField] private List<Transform> _stools;
        
    #endregion
    
    #region Private Fields
    #endregion

    #region Unity Methods
        void Awake()
        {
        
        }

        void Start()
        {
        
        }

        void Update()
        {
        
        }
    #endregion

    #region Public Methods

        void PutPlate(PlateTemplate plate, int position)
        {
            if (position < _placementPoints.Count)
            {
                //Instantiate(SpriteRenderer, _placementPoints[position]);
            }
        }

    #endregion

    #region Private Methods
    #endregion
    }
}