using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using Collectables;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class LevelRestarter : MonoBehaviour
    {
        public static LevelRestarter Instance;
        
        [SerializeField] private Transform collectables;

        private GameObject _player;
        private Vector3 _playerStartPosition;

        private void Awake()
        {
            collectables = GameObject.FindGameObjectWithTag("Collectables").GetComponent<Transform>();
            _player = GameObject.FindGameObjectWithTag("Player");
            
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance =  this;
            }
            
            _playerStartPosition = _player.transform.position;
        }

		public IEnumerator RestartLevel()
        {
            AudioManager.Instance.PlayDeathSound();
            
            Rigidbody2D rb = _player.GetComponent<Rigidbody2D>();
            
            PlayerStats.Instance.ResetCoins();
            foreach (Transform child in collectables)
            {
                child.gameObject.SetActive(true);
            }
            
            //Physics

            PlayerMover playerMover = _player.GetComponent<PlayerMover>();
            playerMover.ResetKnockback();
            rb.simulated = false;
            _player.transform.position = _playerStartPosition;
            
            yield return new WaitForFixedUpdate();
            
            rb.simulated = true;
            rb.linearVelocity = Vector2.zero;
            
            for(int i = 0; i < PlayerStats.Instance.MaxHealth; i++)
            {
                PlayerStats.Instance.AddHealth();
            }

            playerMover.movementAllowed = true;
        }

        public void StopPlayer()
        {
            _player.GetComponent<PlayerMover>().StopPlayer();

        }
        
        
    }
}