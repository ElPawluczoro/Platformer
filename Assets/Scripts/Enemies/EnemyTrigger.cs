using System;
using Player;
using UnityEngine;

namespace Enemies
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private float pushForce;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerStats.Instance.SubHealth();
                other.GetComponent<PlayerHurt>().Hurt();
                float force = Mathf.Sign(other.transform.position.x - transform.position.x);
                other.GetComponent<PlayerMover>().AddKnockback();
                other.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(pushForce * force, 0);
            }
        }
    }
}