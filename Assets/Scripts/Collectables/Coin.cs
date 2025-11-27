using Player;
using UnityEngine;

namespace Collectables
{
    public class Coin : Collectable
    {
        public override bool Collect()
        {
            PlayerStats.Instance.AddCoin();
            return true;
        }
    }
}