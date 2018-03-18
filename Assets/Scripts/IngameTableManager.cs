using UnityEngine;
using System.Collections;

public class IngameTableManager : JMonoSingleton<IngameTableManager>
{
    public ItemTable table = null;
    private void Awake()
    {
        table = ScriptableObject.CreateInstance<ItemTable>();
    }

}
