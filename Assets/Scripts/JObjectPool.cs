////////////////////////////////////
//
//  Created by Jung Yeol Joo
//      this class is object pool
//  1. if isCanOverflow variable is checked, create object more than specified;
//
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class JObjectPool : JMonoSingleton<JObjectPool>
{
    #region PoolName
    public const string DEFAULT_BULLET = "DEFAULT_BULLET";
    #endregion

    [System.Serializable]
    public class ObjectPoolData
    {
        public string   poolName    = "";
        public string   path        = "";
        public int      count       = 0;
    }

    [SerializeField]
    bool isCanOverflow = true;

    [SerializeField]
    List<ObjectPoolData> preCreatedData
        = new List<ObjectPoolData>();

    Dictionary<string, ObjectPoolData> poolDataByPoolName
        =new Dictionary<string, ObjectPoolData>();

    JMultiDictionary<string, GameObject> pool
        = new JMultiDictionary<string, GameObject>();

    private IEnumerator Start()
    {
        for( int i = 0; i < preCreatedData.Count; ++i )
        {
            poolDataByPoolName.Add(preCreatedData[ i ].poolName, preCreatedData[ i ]);
        }

        for( int i = 0; i < preCreatedData.Count; ++i )
        {
            for( int j = 0; j < preCreatedData[ i ].count; ++j )
            {
                ResourceRequest enumerator = Resources.LoadAsync(preCreatedData[ i ].path);
                while( !enumerator.isDone )
                {
                    yield return null;
                }

                if( null == enumerator.asset )
                    continue;

                UnityEngine.Object loaded = enumerator.asset;

                GameObject go = Instantiate(loaded) as GameObject;
                go.transform.parent = this.transform;
                go.SetActive(false);

                pool.Add(preCreatedData[ i ].poolName, go);
            }
        }
        yield break;
    }

    public GameObject GetObject(string poolName)
    {
        return GetObject( poolName, Vector3.zero, Quaternion.identity );
    }

    public GameObject GetObject(string poolName, Vector3 pos, Quaternion rot)
    {
        GameObject old = pool.GetFirst( poolName );
        if( null == old )
        {
            if( isCanOverflow )
            {
                string path = poolDataByPoolName[ poolName ].path;
                GameObject go = Instantiate( Resources.Load( path ) ) as GameObject;
                old = go;
            }
            else
            {
                Debug.LogErrorFormat( "pool is empty poolName : {0}", poolName );
                return null;
            }
        }
        else
        {
            pool.Remove( poolName, old );
        }

        old.transform.position = pos;
        old.transform.rotation = rot;
        old.SetActive( true );
        return old;
    }

    public void ReturnToPool(string poolName, GameObject obj)
    {
        obj.SetActive(false);
        pool.Add(poolName, obj);
        obj.transform.parent = this.transform;
    }
}