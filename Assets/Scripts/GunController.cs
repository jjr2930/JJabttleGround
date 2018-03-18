using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Tooltip("총알 프리팹을 이곳에 넣으세요 없으면 기본 총알로 대체됩니다.(기본총알 구현 중....)")]
    [SerializeField]
    string bulletPath = "";

    [Tooltip("총구의 위치")]
    [SerializeField]
    Transform nozzle = null;

    [Tooltip("총의 발사속도")]
    [SerializeField]
    float oneShotTime = 0f;

    float beforeShootTime = 0f;

    private void Awake()
    {
        bulletPath = ( "" == bulletPath ) ? ( JObjectPool.DEFAULT_BULLET ) : bulletPath;
    }

    private void Update()
    {
        if( !( Input.GetButton( "Fire1" ) || Input.GetButtonDown( "Fire1" ) ) )
            return;

        if( Time.realtimeSinceStartup - beforeShootTime < oneShotTime )
            return;

#if UNITY_EDITOR
        bulletPath = ( "" == bulletPath ) ? ( JObjectPool.DEFAULT_BULLET ) : bulletPath;
#endif
        JObjectPool.Instance.GetObject( bulletPath, nozzle.position, nozzle.rotation );

        beforeShootTime = Time.realtimeSinceStartup;
    }
}