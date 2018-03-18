using System.Collections.Generic;
using UnityEngine;
using CONST;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public partial class ItemData
{
    [SerializeField] protected eItemType   itemType        = eItemType.None;
    [SerializeField] protected int         index           = 0;
    [SerializeField] protected int         backpackAmount  = 0;
    [SerializeField] protected string      iconPath        = "";

    #region Properties
    public eItemType ItemType
    {
        get
        {
            return itemType;
        }
    }

    public int Index
    {
        get
        {
            return index;
        }
    }

    public int BackpackAmount
    {
        get
        {
            return backpackAmount;
        }
    }

    public string IconPath
    {
        get
        {
            return iconPath;
        }

        set
        {
            iconPath = value;
        }
    }
    #endregion
}

[System.Serializable]
public partial class WeaponItem : ItemData
{
    [SerializeField]    eBulletType bulletType          = eBulletType.None;
    [SerializeField]    int         magazineCapacity    = 0;

    #region Properties
    public eBulletType BulletType
    {
        get
        {
            return bulletType;
        }
    }

    public int MagazineCapacity
    {
        get
        {
            return magazineCapacity;
        }
    }
    #endregion

    public WeaponItem() : base()
    {
        itemType = eItemType.Weapon;
    }
}

[System.Serializable]
public partial class BackpackItem : ItemData
{
    [SerializeField]    int         backpackLevel       = 0;
    [SerializeField]    int         backpackCapacity    = 0;

    #region Properties
    public int BackpackLevel
    {
        get
        {
            return backpackLevel;
        }
    }

    public int BackpackCapacity
    {
        get
        {
            return backpackCapacity;
        }
    }
    #endregion

    public BackpackItem()
    {
        itemType = eItemType.Backpack;
    }
}

[System.Serializable]
public partial class HelmetItem : ItemData
{
    [SerializeField]    int         defence     = 0;
    [SerializeField]    int         durability  = 0;

    #region Properties
    public int Defence
    {
        get
        {
            return defence;
        }
    }

    public int Durability
    {
        get
        {
            return durability;
        }
    }
    #endregion

    public HelmetItem() : base()
    {
        itemType = eItemType.Helmet;
    }
}

[System.Serializable]
public partial class AmourItem : ItemData
{
    [SerializeField]    int         defence     = 0;
    [SerializeField]    int         durability  = 0;

    #region Properties
    public int Defence
    {
        get
        {
            return defence;
        }
    }

    public int Durability
    {
        get
        {
            return durability;
        }
    }
    #endregion

    public AmourItem() : base()
    {
        itemType = eItemType.Amour;
    }
}

[System.Serializable]
public partial class BulletItem : ItemData
{
    [SerializeField]    eBulletType bulletType      = eBulletType.None;
    [SerializeField]    int         bulletAmount    = 0;

    #region Properties
    public eBulletType BulletType
    {
        get
        {
            return bulletType;
        }
    }

    public int BulletAmount
    {
        get
        {
            return bulletAmount;
        }
    }
    #endregion

    public BulletItem() : base()
    {
        itemType = eItemType.Bullet;
    }
}

[System.Serializable]
public partial class BandageItem : ItemData
{
    [SerializeField]    int         healingAmount   = 0;
    [SerializeField]    float       castingTime     = 0f;

    #region Properties
    public int HealingAmount
    {
        get
        {
            return healingAmount;
        }
    }

    public float CastingTime
    {
        get
        {
            return castingTime;
        }
    }
    #endregion

    public BandageItem() : base()
    {
        itemType = eItemType.Bandage;
    }
}

[System.Serializable]
public partial class MedicineItem : ItemData
{
    [SerializeField]    float       castingTime     = 0f;
    [SerializeField]    int         healingPerSec   = 0;
    [SerializeField]    int         gageAmount      = 0;

    #region Properties
    public float CastingTime
    {
        get
        {
            return castingTime;
        }
    }

    public int HealingPerSec
    {
        get
        {
            return healingPerSec;
        }
    }

    public int GageAmount
    {
        get
        {
            return gageAmount;
        }
    }
    #endregion

    public MedicineItem() : base()
    {
        itemType = eItemType.Medicine;
    }
}

[CreateAssetMenu( fileName = "ItemTable", menuName = "ItemTable", order = 1 )]
public class ItemTable : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]    List<WeaponItem>    weaponItems     = new List<WeaponItem>();
    [SerializeField]    List<BackpackItem>  backpackItems   = new List<BackpackItem>();
    [SerializeField]    List<HelmetItem>    helmetItems     = new List<HelmetItem>();
    [SerializeField]    List<AmourItem>     amourItems      = new List<AmourItem>();
    [SerializeField]    List<BulletItem>    bulletItems     = new List<BulletItem>();
    [SerializeField]    List<BandageItem>   bandageItems    = new List<BandageItem>();
    [SerializeField]    List<MedicineItem>  medicineItems   = new List<MedicineItem>();

    #region Properties
    public Dictionary<eItemType, Dictionary<int, ItemData>> DicItemTable { get; } = new Dictionary<eItemType, Dictionary<int, ItemData>>();

    public List<WeaponItem> WeaponItems
    {
        get
        {
            return weaponItems;
        }
    }

    public List<BackpackItem> BackpackItems
    {
        get
        {
            return backpackItems;
        }
    }

    public List<HelmetItem> HelmetItems
    {
        get
        {
            return helmetItems;
        }
    }

    public List<AmourItem> AmourItems
    {
        get
        {
            return amourItems;
        }
    }

    public List<BulletItem> BulletItems
    {
        get
        {
            return bulletItems;
        }
    }

    public List<BandageItem> BandageItems
    {
        get
        {
            return bandageItems;
        }

        set
        {
            bandageItems = value;
        }
    }

    public List<MedicineItem> MedicineItems
    {
        get
        {
            return medicineItems;
        }

        set
        {
            medicineItems = value;
        }
    }
    #endregion

    public void OnBeforeSerialize()
    {
        //weaponItems.Clear();
        //backpackItems.Clear();
        //helmetItems.Clear();
        //amourItems.Clear();
        //bulletItems.Clear();
        //bandageItems.Clear();
        //medicineItems.Clear();

        //foreach( var elementDic in dicItemTable )
        //{
        //    foreach( var element in elementDic.Value )
        //    {
        //        switch( elementDic.Key )
        //        {
        //            case eItemType.Weapon:
        //                weaponItems.Add( element.Value as WeaponItem );
        //                break;
        //            case eItemType.Backpack:
        //                backpackItems.Add( element.Value as BackpackItem );
        //                break;
        //            case eItemType.Helmet:
        //                helmetItems.Add( element.Value as HelmetItem );
        //                break;
        //            case eItemType.Amour:
        //                amourItems.Add( element.Value as AmourItem );
        //                break;
        //            case eItemType.Bullet:
        //                bulletItems.Add( element.Value as BulletItem );
        //                break;
        //            case eItemType.Bandage:
        //                bandageItems.Add( element.Value as BandageItem );
        //                break;
        //            case eItemType.Medicine:
        //                medicineItems.Add( element.Value as MedicineItem );
        //                break;
        //            default:
        //                Debug.LogErrorFormat( "{0} is not supported", elementDic.Key );
        //                break;
        //        }
        //    }
        //}
    }

    public void OnAfterDeserialize()
    {
        DicItemTable.Clear();

        PushToDictionary( weaponItems );
        PushToDictionary( backpackItems );
        PushToDictionary( helmetItems );
        PushToDictionary( amourItems );
        PushToDictionary( bulletItems );
        PushToDictionary( bandageItems );
        PushToDictionary( medicineItems );
    }

    public void PushToDictionary<T>(List<T> itemTable) where T : ItemData
    {
        for( int i = 0; i < itemTable.Count; ++i )
        {
            Dictionary<int, ItemData> foundedDic = null;

            if( !DicItemTable.TryGetValue( itemTable[ i ].ItemType, out foundedDic ) )
            {
                foundedDic = new Dictionary<int, ItemData>();

                DicItemTable.Add( itemTable[ i ].ItemType, foundedDic );
            }

            foundedDic.Add( itemTable[ i ].Index, itemTable[ i ] );
        }
    }

    public T GetItem<T>(eItemType itemType, int index) where T : ItemData, new()
    {
        Dictionary<int, ItemData> founded;
        if( DicItemTable.TryGetValue( itemType, out founded ) )
        {
            ItemData foundedItem;

            if( founded.TryGetValue( index, out foundedItem ) )
            {
                return foundedItem as T;
            }
        }

        Debug.LogError( "Not founded" );
        return new T();
    }
}


#if UNITY_EDITOR
#region Editor Class

public partial class ItemData
{
    public virtual void OnDrawMember()
    {
        EditorGUILayout.LabelField( this.ItemType.ToString(), GUILayout.MaxWidth( 130f ) );
        this.index = EditorGUILayout.IntField( this.index, GUILayout.MaxWidth( 130f ) );
        this.backpackAmount = EditorGUILayout.IntField( this.backpackAmount, GUILayout.MaxWidth( 130f ) );
        this.iconPath = EditorGUILayout.TextField( this.iconPath, GUILayout.MaxWidth( 130f ) );
    }

    public virtual void DrawMemberName()
    {
        EditorGUILayout.LabelField( "", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "Index", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "BackpackAmount", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "IconPath", GUILayout.MaxWidth( 130f ) );
    }
}

public partial class WeaponItem
{
    public override void OnDrawMember()
    {
        base.OnDrawMember();
        this.bulletType = ( eBulletType )EditorGUILayout.EnumPopup( this.bulletType, GUILayout.MaxWidth( 130f ) );
        this.magazineCapacity = EditorGUILayout.IntField( this.magazineCapacity, GUILayout.MaxWidth( 130f ) );
    }

    public override void DrawMemberName()
    {
        base.DrawMemberName();
        EditorGUILayout.LabelField( "Bullet Type", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "Magazine Capacity", GUILayout.MaxWidth( 130f ) );
    }
}

public partial class BackpackItem
{
    public override void OnDrawMember()
    {
        base.OnDrawMember();
        this.backpackLevel = EditorGUILayout.IntField( this.backpackLevel, GUILayout.MaxWidth( 130f ) );
        this.backpackCapacity = EditorGUILayout.IntField( this.backpackCapacity, GUILayout.MaxWidth( 130f ) );
    }

    public override void DrawMemberName()
    {
        base.DrawMemberName();
        EditorGUILayout.LabelField( "Backpack Level", GUILayout.MaxWidth( 130f ), GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "Backpack Capacity", GUILayout.MaxWidth( 130f ), GUILayout.MaxWidth( 130f ) );
    }
}

public partial class HelmetItem
{
    public override void OnDrawMember()
    {
        base.OnDrawMember();
        this.defence = EditorGUILayout.IntField( this.defence, GUILayout.MaxWidth( 130f ) );
        this.durability = EditorGUILayout.IntField( this.durability, GUILayout.MaxWidth( 130f ) );
    }

    public override void DrawMemberName()
    {
        base.DrawMemberName();
        EditorGUILayout.LabelField( "Defence", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "Durability", GUILayout.MaxWidth( 130f ) );
    }
}

public partial class AmourItem
{
    public override void OnDrawMember()
    {
        base.OnDrawMember();
        this.defence = EditorGUILayout.IntField( this.defence, GUILayout.MaxWidth( 130f ) );
        this.durability = EditorGUILayout.IntField( this.durability, GUILayout.MaxWidth( 130f ) );
    }

    public override void DrawMemberName()
    {
        base.DrawMemberName();
        EditorGUILayout.LabelField( "Defence", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "Durability", GUILayout.MaxWidth( 130f ) );
    }
}

public partial class BulletItem
{
    public override void OnDrawMember()
    {
        base.OnDrawMember();
        this.bulletType = ( eBulletType )EditorGUILayout.EnumPopup( this.bulletType, GUILayout.MaxWidth( 130f ) );
        this.bulletAmount = EditorGUILayout.IntField( this.bulletAmount, GUILayout.MaxWidth( 130f ) );
    }
    public override void DrawMemberName()
    {
        base.DrawMemberName();
        EditorGUILayout.LabelField( "bulletType", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "bulletAmount", GUILayout.MaxWidth( 130f ) );
    }
}

public partial class BandageItem
{
    public override void OnDrawMember()
    {
        base.OnDrawMember();
        this.healingAmount = EditorGUILayout.IntField( this.healingAmount, GUILayout.MaxWidth( 130f ) );
        this.castingTime = EditorGUILayout.FloatField( this.castingTime, GUILayout.MaxWidth( 130f ) );
    }

    public override void DrawMemberName()
    {
        base.DrawMemberName();
        EditorGUILayout.LabelField( "healingAmount", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "castingTime", GUILayout.MaxWidth( 130f ) );
    }
}

public partial class MedicineItem
{
    public override void OnDrawMember()
    {
        base.OnDrawMember();
        this.castingTime = EditorGUILayout.FloatField( this.castingTime, GUILayout.MaxWidth( 130f ) );
        this.healingPerSec = EditorGUILayout.IntField( this.healingPerSec, GUILayout.MaxWidth( 130f ) );
        this.gageAmount = EditorGUILayout.IntField( this.gageAmount, GUILayout.MaxWidth( 130f ) );
    }

    public override void DrawMemberName()
    {
        base.DrawMemberName();
        EditorGUILayout.LabelField( "castingTime", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "healingPerSec", GUILayout.MaxWidth( 130f ) );
        EditorGUILayout.LabelField( "gageAmount", GUILayout.MaxWidth( 130f ) );
    }
}
#endregion
#endif