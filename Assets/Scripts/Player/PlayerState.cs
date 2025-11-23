using System;
using UnityEngine;

namespace Player
{
    public class PlayerState : MonoBehaviour
    {
        private bool _grounded;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float checkRadius = 0.1f;
        [SerializeField] private LayerMask groundLayer;

        public bool Grounded => _grounded;

        private void Update()
        {
            _grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        }
    }
}