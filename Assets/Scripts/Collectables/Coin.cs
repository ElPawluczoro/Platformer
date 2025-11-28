using Player;
using UnityEngine;

namespace Collectables
{
    public class Coin : Collectable
    {
        protected override bool Collect()
        {
            PlayerStats.Instance.AddCoin();
            return true;
        }
    }
}