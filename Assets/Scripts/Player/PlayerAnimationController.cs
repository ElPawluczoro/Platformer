using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        private static readonly int Moving = Animator.StringToHash("moving");
        private Animator _animator;
        private Rigidbody2D _rb;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {   
            var _linVelocity = Mathf.Abs(_rb.linearVelocity.x) > 0.01f;
            var _knockback = _playerMover.KnockbackTimer > 0;
            _animator.SetBool(Moving, _linVelocity && !_knockback);
            if(_linVelocity && !_knockback) SetRotation();
        }

        private void SetRotation()
        {
            transform.localScale = _rb.linearVelocity.x switch
            {
                > 0.01f => new Vector3(4, 4, 1),
                < -0.01f => new Vector3(-4, 4, 1),
                _ => transform.localScale
            };
        }
    }
}