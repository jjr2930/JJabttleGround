using CONST;

public abstract class MsgParamBase { }

[System.Serializable]
public class ItemPickupMsg : MsgParamBase
{
    public eItemType    itemType = eItemType.None;
    public int          table_id = 0;
}
/// <summary>
/// 가독성을 위해 이름만 바꿔쓰자
/// </summary>
public class ThrowItemMsg : ItemPickupMsg { }
