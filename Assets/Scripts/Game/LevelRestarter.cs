using System;
using System.Collections;
using System.Collections.Generic;
using Collectables;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game
{
    public class LevelRestarter : MonoBehaviour
    {
        public static LevelRestarter Instance;
        
        [SerializeField] private List<Transform> collectables;

        private Vector3 _playerStartPosition;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance =  this;
            }
            
            _playerStartPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

		public IEnumerator RestartLevel()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerStats playerStats = GetComponent<PlayerStats>();
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            
            player.GetComponent<PlayerMover>().ResetKnockback();
            rb.simulated = false;
            player.transform.position = _playerStartPosition;
            
            yield return new WaitForFixedUpdate();
            
            rb.simulated = true;
            rb.linearVelocity = Vector2.zero;
            
            for(int i = 0; i < playerStats.MaxHealth; i++)
            {
                playerStats.AddHealth();
            }
            
            
        }
        
        
    }
}