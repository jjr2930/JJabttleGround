using UnityEngine;
using System.Collections;

public class TableManager : JMonoSingleton<TableManager>
{
    [SerializeField]
    ItemTable itemTable = null;

    public ItemTable ItemTable
    {
        get
        {
            return itemTable;
        }
    }

    private void Awake()
    {
        itemTable = Resources.Load( "ItemTable" ) as ItemTable;
    }
}
