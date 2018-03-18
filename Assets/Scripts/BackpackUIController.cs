using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Element = BackpackElementUIController;
public class BackpackUIController : MonoBehaviour
{
    ItemTable itemTable = null;

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

    [SerializeField]    Element currentWeapon   = null;

    private void Start()
    {
        itemTable = TableManager.Instance.ItemTable;
    }

    public void CompletePickup(ItemPickupMsg msg)
    {
        switch( msg.itemType )
        {
            case CONST.eItemType.Weapon:
                WeaponItem weapon =  itemTable.GetItem<WeaponItem>( msg.itemType, msg.table_id );
                currentWeapon.SetMember( weapon.IconPath, weapon.ItemName );
                break;

            case CONST.eItemType.Backpack:
                BackpackItem backpackData = itemTable.GetItem<BackpackItem>( msg.itemType, msg.table_id );
                backpack.SetMember( backpackData.IconPath, backpackData.ItemName );
                break;

            case CONST.eItemType.Helmet:
                HelmetItem helmetData = itemTable.GetItem<HelmetItem>( msg.itemType, msg.table_id );
                backpack.SetMember( helmetData.IconPath, helmetData.ItemName );
                break;

            case CONST.eItemType.Amour:
                AmourItem amourData = itemTable.GetItem<AmourItem>( msg.itemType, msg.table_id );
                backpack.SetMember( amourData.IconPath, amourData.ItemName );
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
