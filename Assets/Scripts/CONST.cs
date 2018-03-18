using UnityEngine;
using System.Collections;

namespace CONST
{

    public enum eMessage
    {
        None = 0,
        ContactItem = 1,
        SeperateItem = 2,
        PickUpItem = 3,
        CompletePickup = 4,
        Count
    }

    public enum eItemType
    {
        None,
        Weapon = 1,
        Backpack = 2,
        Helmet = 3,
        Amour = 4,
        Bullet = 5,
        Bandage = 6,
        Medicine = 7,
        Count
    }

    public enum eBulletType
    {
        None,
        _5_56mm = 1,
        _7_62mm = 2,
        _5mm = 3,
        _12ga = 4,
        Count
    }
}