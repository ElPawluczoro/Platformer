using System;
using UnityEngine;

namespace Player
{
    public class PlayerHurt : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private float _countdown;
        
        [SerializeField] private Color hurtColor = Color.red;
        [SerializeField] private float hurtTime;
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (_countdown <= 0) return;
            _countdown -= Time.deltaTime;
            if(_countdown <= 0) _spriteRenderer.color = Color.white;
        }

        public void Hurt()
        {
            _spriteRenderer.color = hurtColor;
            _countdown = hurtTime;
        }
    }
}