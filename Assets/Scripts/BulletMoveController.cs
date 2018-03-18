using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveController : MonoBehaviour
{
    [SerializeField]
    float limitRange = 20f;

    [SerializeField]
    float bulletSpeed = 10f;

    Transform cTrans = null;

    Vector3 startPosition = Vector3.zero;

    float sqrLimitRange;

    private void Awake()
    {
        cTrans = transform;
    }

    private void OnEnable()
    {
        startPosition = cTrans.position;

        sqrLimitRange = limitRange * limitRange;
    }


    //2d game's forward is up
    private void Update()
    {
#if UNITY_EDITOR
        sqrLimitRange = limitRange * limitRange;
#endif
        float sqrMoveDistance = ( startPosition - cTrans.position ).sqrMagnitude;

        if( sqrMoveDistance <= sqrLimitRange )
            cTrans.Translate( cTrans.up * bulletSpeed * Time.deltaTime, Space.World );

        else
        {
            JObjectPool.Instance.ReturnToPool( JObjectPool.DEFAULT_BULLET, gameObject );
        }
    }
}
