using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerStats.Instance.SubHealth();
                other.GetComponent<PlayerHurt>().Hurt();
            }
        }
    }
}