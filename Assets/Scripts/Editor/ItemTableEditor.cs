using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using CONST;
[CustomEditor( typeof( ItemTable ) )]
public class ItemTableEditor : Editor
{
    ItemTable table = null;

    Dictionary<eItemType,bool> dicFoldout = new Dictionary<eItemType, bool>()
    {
        { eItemType.Amour,false },
        { eItemType.Backpack,false },
        { eItemType.Bandage,false },
        { eItemType.Bullet,false },
        { eItemType.Helmet,false },
        { eItemType.Medicine,false },
        { eItemType.Weapon,false },
    };

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        table = target as ItemTable;

        //if( null == table )
        //{
        //    Debug.LogError( "target is not have itemtable" );

        //    return;
        //}

        //if( GUILayout.Button( "+" ) )
        //{

        //}

        //EditorGUILayout.BeginVertical();
        //{
        //    foreach( var item in table.DicItemTable )
        //    {
        //        EditorGUILayout.BeginHorizontal();
        //        {
        //            EditorGUILayout.LabelField( item.Key.ToString() );
        //        }
        //        EditorGUILayout.EndHorizontal();
        //    }
        //}
        //EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginVertical();
        {
            PrintList( table.WeaponItems, eItemType.Weapon );
            PrintList( table.BackpackItems, eItemType.Backpack );
            PrintList( table.HelmetItems, eItemType.Helmet );
            PrintList( table.AmourItems, eItemType.Amour );
            PrintList( table.BulletItems, eItemType.Bullet );
            PrintList( table.BandageItems, eItemType.Bandage );
            PrintList( table.MedicineItems, eItemType.Medicine );
        }
        EditorGUILayout.EndVertical();
    }

    public void PrintList<T>(List<T> list, eItemType foldoutKey) where T : ItemData, new()
    {
        dicFoldout[ foldoutKey ] = EditorGUILayout.Foldout( dicFoldout[ foldoutKey ], typeof( T ).ToString() );
        if( dicFoldout[ foldoutKey ] )
        {
            if( GUILayout.Button( "+" ) )
            {
                list.Add( new T() );
            }

            if( 0 < list.Count )
            {
                EditorGUILayout.BeginHorizontal();
                {
                    list[ 0 ].DrawMemberName();
                }
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.BeginVertical();
            {
                foreach( var item in list )
                {
                    EditorGUILayout.BeginHorizontal();
                    {
                        item.OnDrawMember();

                        if( GUILayout.Button( "-", GUILayout.MaxWidth( 40f ) ) )
                        {
                            list.Remove( item );
                            break;
                        }
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.BeginVertical();
        }    
        
        if(GUI.changed)
        {
            EditorUtility.SetDirty( target );
        }
    }
}
