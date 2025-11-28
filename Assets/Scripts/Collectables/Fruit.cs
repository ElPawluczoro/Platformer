using Player;
using UnityEngine;

namespace Collectables
{
    public class Fruit : Collectable
    {
        protected override bool Collect()
        {
            if (PlayerStats.Instance.Health < 3)
            {
                PlayerStats.Instance.AddHealth();
                return true;
            }
            return false;
        }
    }
}