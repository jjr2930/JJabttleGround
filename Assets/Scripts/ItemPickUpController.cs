using UnityEngine;
using CONST;
using Item;
public class ItemPickUpController : MonoBehaviour
{
    [SerializeField]
    LayerMask itemLayer;

    ItemBase current_item = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        int layer = 1 << other.gameObject.layer;
        int layerCheck = itemLayer.value & layer;
        if( layerCheck == 0 )
            return;

        current_item = other.gameObject.GetComponent<ItemBase>();
        if(null == current_item)
        {
            Debug.LogErrorFormat( "{0} does not have ItemBaseComponent", other.name );
            return;
        }

        transform.root.BroadcastMessage( eMessage.ContactItem.ToString() );
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ItemBase oldItem = other.GetComponent<ItemBase>();
        if( null == oldItem )
            return;

        if( oldItem == current_item )
            current_item = null;

        transform.root.BroadcastMessage( eMessage.SeperateItem.ToString() );
    }

    private void Update()
    {
        if( !Input.GetKeyDown( KeyCode.F ) )
            return;

        if( null == current_item )
            return;

        MsgParamBase msg = new ItemPickupMsg() { itemType = current_item.ItemType, table_id = current_item.TableIndex };

        transform.root.BroadcastMessage( eMessage.PickUpItem.ToString(), msg, SendMessageOptions.DontRequireReceiver );

        Destroy( current_item.gameObject );
    }
}
