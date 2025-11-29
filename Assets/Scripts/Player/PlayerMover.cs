using Audio;
using Game;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] float speed = 3f;
        [SerializeField] float jumpForce = 25f;
        [SerializeField] private float fallMultiplier = 2f;
        
        private PlayerInputActions _inputActions;
        private Vector2 _moveInput;
        private Rigidbody2D _rb;
        private PlayerState _playerState;

        private float _knockbackTimer;
        [SerializeField] private float knockbackTime = 0.3f;

        public float KnockbackTimer => _knockbackTimer;

        private void Awake()
        {
            _inputActions = new PlayerInputActions();
            _rb = GetComponent<Rigidbody2D>();
            _playerState = GetComponent<PlayerState>();
        }

        private void OnEnable()
        {
            _inputActions.Enable();
            _inputActions.Player.Move.performed += OnMove;
            _inputActions.Player.Move.canceled += OnMove;
            _inputActions.Player.Jump.performed += OnJump;
            //inputActions.Player.Jump.canceled += OnJump;
        }

        private void OnDisable()
        {
            _inputActions.Player.Move.performed -= OnMove;
            _inputActions.Player.Move.canceled -= OnMove;
            _inputActions.Player.Jump.performed -= OnJump;
            //inputActions.Player.Jump.canceled -= OnJump;
            _inputActions.Disable();
        }
        
        private void OnMove(InputAction.CallbackContext ctx)
        {
            _moveInput = ctx.ReadValue<Vector2>();
        }

        private void OnJump(InputAction.CallbackContext ctx)
        {
            if (!_playerState.Grounded) return;
            if (_knockbackTimer > 0.1f) return;
            AudioManager.Instance.PlayJumpSound();
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, jumpForce);
        }
        
        private void FixedUpdate()
        {
            //rb.linearVelocity = moveInput * speed;
            if (_knockbackTimer <= 0f)
            {
                _rb.linearVelocity = new Vector2(_moveInput.x * speed, _rb.linearVelocity.y);
            }
            else
            {
                _knockbackTimer -= Time.fixedDeltaTime;
                if(_knockbackTimer < 0.01f) _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
            }

            if (_rb.linearVelocity.y < 0)
            {
                _rb.linearVelocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime);
            }
            
            if(transform.position.y <= LevelInformation.Instance.minimalY) StartCoroutine(LevelRestarter.Instance.RestartLevel());
        }

        public void AddKnockback()
        {
            _knockbackTimer = knockbackTime;
            _rb.linearVelocity = Vector2.zero;
        }

        public void ResetKnockback()
        {
            _knockbackTimer = 0;
            _rb.linearVelocity = Vector2.zero;
        }
    }   
}
