/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using System;
using UnityEngine;

namespace Controllers
{
    public class FurnitureSpriteController : MonoBehaviour
    {
    #region Variables
    #endregion
    
    #region Private Fields

        private SpriteRenderer _spriteRenderer;
    
    #endregion

    #region Unity Methods
        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Start()
        {
        
        }

        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.isTrigger
                && col.GetComponent<SpriteReorderer>() is { } reorderer
                && reorderer.Layer == _spriteRenderer.sortingLayerID
                && reorderer.Position.y >= _spriteRenderer.bounds.center.y)
            {
                reorderer.Order = _spriteRenderer.sortingOrder - 1;
                reorderer.ControlledBy = this;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.isTrigger
                && other.GetComponent<SpriteReorderer>() is { } reorderer
                && reorderer.Layer == _spriteRenderer.sortingLayerID)
            {
                if (reorderer.Position.y >= _spriteRenderer.bounds.center.y)
                {
                    reorderer.Order = _spriteRenderer.sortingOrder - 1;
                    reorderer.ControlledBy = this;
                }
                else
                {
                    reorderer.Reset();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.isTrigger
                && col.GetComponent<SpriteReorderer>() is { } reorderer
                && reorderer.ControlledBy == this)
            {
                reorderer.Reset();
            }
        }

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion
    }
}