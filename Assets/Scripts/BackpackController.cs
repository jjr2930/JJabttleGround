using UnityEngine;
using System.Collections.Generic;
using Item;
using CONST;

public class BackpackController : MonoBehaviour
{
    [SerializeField]
    ItemTable itemTable = null;

    [SerializeField]
    int limitAmount = 100;

    [SerializeField]
    int currentAmount = 0;

    HashSet<ItemData> items = new HashSet<ItemData>();

    private void Start()
    {
        //itemTable.Init();
    }

    public void ChangeBackpack(int limitAmount)
    {
        if( this.limitAmount > limitAmount )
        {
            Debug.Log( "더 좋은 가방을 가지고 있습니다." );
            return;
        }

        this.limitAmount = limitAmount;
    }

    public void PickUpItem(ItemPickupMsg msg)
    {
        ItemData itemData = itemTable.GetItem<ItemData>( msg.itemType, msg.table_id );

        if( currentAmount + itemData.BackpackAmount > limitAmount )
        {
            Debug.Log( "가방 공간이 부족함" );
            return;
        }

        items.Add( itemData );

        switch( itemData.ItemType )
        {
            case CONST.eItemType.Backpack:
                BackpackItem backpackItem = itemData as BackpackItem;
                ChangeBackpack( backpackItem.BackpackCapacity );
                break;

            case CONST.eItemType.Weapon:
                break;

            case CONST.eItemType.Medicine:
                break;

            default:
                Debug.LogErrorFormat( "{0} is not supported yet", itemData.ItemType );
                break;
        }

        currentAmount += itemData.BackpackAmount;
        transform.root.BroadcastMessage( eMessage.CompletePickup.ToString(), msg );
    }

    public void ThrowItem(ThrowItemMsg msg)
    {
        ItemData itemData = itemTable.GetItem<ItemData>( msg.itemType, msg.table_id );
        if( !items.Contains( itemData ) )
        {
            Debug.Log( "가방에 없는 아이템임" );
            return;
        }

        items.Remove( itemData );
        currentAmount -= itemData.BackpackAmount;
    }
}
