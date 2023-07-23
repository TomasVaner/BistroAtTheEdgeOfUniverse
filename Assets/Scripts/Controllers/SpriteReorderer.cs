/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteReorderer : MonoBehaviour
    {
    #region Variables

        
        
    #endregion
    
    #region Private Fields

        private SpriteRenderer _spriteRenderer;
        private int _baseOrder;
        
    #endregion

    #region Properties

        public int Order
        {
            get => _spriteRenderer.sortingOrder;
            set => _spriteRenderer.sortingOrder = value;
        }

        public int Layer => _spriteRenderer.sortingLayerID;

        public Vector2 Position => _spriteRenderer.bounds.center;

        public FurnitureSpriteController ControlledBy { get; set; }

    #endregion

    #region Unity Methods
        
        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _baseOrder = _spriteRenderer.sortingOrder;
        }
        
    #endregion

    #region Public Methods

        public void Reset()
        {
            _spriteRenderer.sortingOrder = _baseOrder;
            ControlledBy = null;
        }
        
    #endregion

    #region Private Methods
    #endregion
    }
}