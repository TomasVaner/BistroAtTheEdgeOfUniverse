/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using System;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
    #region Variables

        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxVelocity;

    #endregion

    #region Private Fields

        private Rigidbody2D _rb;
        private Animator _animator;
        private bool _canMove = true;
        private int _animHorizontal = Animator.StringToHash("Horizontal");
        private int _animVertical = Animator.StringToHash("Vertical");
        private int _animSpeed = Animator.StringToHash("Speed");

    #endregion

    #region Properties

        public Vector2 Movement { get; set; }

        public bool CanMove
        {
            get => _canMove;
            set
            {
                _canMove = value;
                if (!_canMove)
                    Movement = Vector2.zero;
            }
        }

    #endregion

    #region Unity Methods

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var velocity = _rb.velocity;

            if (CanMove
                && Movement.sqrMagnitude > 0.01f)
            {
                // accelerating
                velocity += Movement * (_acceleration * Time.deltaTime);
                var absVelocity = velocity.magnitude;
                if (absVelocity > _maxVelocity)
                    velocity = velocity * (_maxVelocity / absVelocity);
                if (absVelocity < 0.01f)
                    velocity = Vector2.zero;
            }
            else
            {
                velocity = Vector2.zero;
            }

            _rb.velocity = velocity;

            var speed = Mathf.Clamp(velocity.sqrMagnitude / _maxVelocity, 0, 1);
            _animator.SetFloat(_animSpeed, speed);
            _animator.SetFloat(_animHorizontal, velocity.x);
            _animator.SetFloat(_animVertical, velocity.y);
        }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
    }
}