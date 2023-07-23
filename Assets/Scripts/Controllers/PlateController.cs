/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlateController : MonoBehaviour
    {
    #region Variables

        [SerializeField] private PlateTemplate _plateTemplate;
    
    #endregion
    
    #region Properties

        public PlateTemplate PlateTemplate
        {
            get => _plateTemplate;
            set => _plateTemplate = value;
        }
    #endregion

    #region Unity Methods
        void Awake()
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _plateTemplate.sprite;
        }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
    }
}