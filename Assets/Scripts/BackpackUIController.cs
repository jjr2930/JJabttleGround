using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Element = BackpackElementUIController;
public class BackpackUIController : MonoBehaviour
{
    [SerializeField]    Element backpack        = null;
    [SerializeField]    Element Bandage         = null;
    [SerializeField]    Element Soda            = null;
    [SerializeField]    Element Medicine        = null;
    [SerializeField]    Element _5mm            = null;
    [SerializeField]    Element _5_56mm         = null;
    [SerializeField]    Element _7_62mm         = null;
    [SerializeField]    Element _12_ga          = null;
    [SerializeField]    Element firsWeapon      = null;
    [SerializeField]    Element secondWeapon    = null;
    [SerializeField]    Element grande          = null;

    public void CompletePickup(ItemPickupMsg msg)
    {
        switch( msg.itemType )
        {
            case CONST.eItemType.Weapon:
                
                break;

            case CONST.eItemType.Backpack:
                break;

            case CONST.eItemType.Helmet:
                break;

            case CONST.eItemType.Amour:
                break;

            case CONST.eItemType.Bullet:
                break;

            case CONST.eItemType.Bandage:
                break;

            case CONST.eItemType.Medicine:
                break;

            default:
                break;
        }
    }
}
