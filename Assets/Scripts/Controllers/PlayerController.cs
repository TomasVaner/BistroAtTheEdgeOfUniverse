/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using UnityEngine;
using UnityEngine.InputSystem;

namespace Controllers
{
    [RequireComponent(typeof(MovementController))]
    public class PlayerController : MonoBehaviour
    {
    #region Variables
    #endregion
    
    #region Private Fields

        private MovementController _movementController;
        
    #endregion

    #region Unity Methods
        void Awake()
        {
            _movementController = GetComponent<MovementController>();
        }

    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
    #endregion

    #region InputCallbacks

        public void MovementInput(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _movementController.Movement = context.ReadValue<Vector2>();
            }

            if (context.canceled)
            {
                _movementController.Movement = Vector2.zero;
            }
        }

    #endregion
    }
}