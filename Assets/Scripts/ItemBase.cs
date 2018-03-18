using UnityEngine;
using System.Collections;
using CONST;

namespace Item
{
    public class ItemBase : MonoBehaviour
    {
        [SerializeField]
        int backpackAmount = 1;

        [SerializeField]
        eItemType itemType = eItemType.None;

        [SerializeField]
        int tableIndex = 1;

        public int BackpackAmount
        {
            get
            {
                return backpackAmount;
            }
        }

        public eItemType ItemType
        {
            get
            {
                return itemType;
            }
        }

        public int TableIndex
        {
            get
            {
                return tableIndex;
            }
        }
    }
}