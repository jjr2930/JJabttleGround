using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [Tooltip("캐릭터의 움직임 스피드를 정합니다.")]
    [SerializeField]
    float moveSpeed = 1f;

    float deltaTime = 0f;
    /// <summary>
    /// c means cached
    /// </summary>
    Transform cTrans = null;

    private void Awake()
    {
        cTrans = transform;
    }

    void Update()
    {

        #region Translation
        deltaTime = Time.deltaTime;

        if( Input.GetKeyDown( KeyCode.A ) || Input.GetKey( KeyCode.A ) )
        {
            cTrans.Translate( Vector3.left * moveSpeed * deltaTime, Space.World );
        }

        if( Input.GetKeyDown( KeyCode.S ) || Input.GetKey( KeyCode.S ) )
        {
            cTrans.Translate( Vector3.down * moveSpeed * deltaTime, Space.World );
        }

        if( Input.GetKeyDown( KeyCode.D ) || Input.GetKey( KeyCode.D ) )
        {
            cTrans.Translate( Vector3.right * moveSpeed * deltaTime, Space.World );
        }

        if( Input.GetKeyDown( KeyCode.W ) || Input.GetKey( KeyCode.W ) )
        {
            cTrans.Translate( Vector3.up * moveSpeed * deltaTime, Space.World );
        }
        #endregion

        #region Rotation

        Vector3 point = Camera.main.ScreenPointToRay( Input.mousePosition ).origin;

        point.z = 0;

        Vector3 toMouse = point - cTrans.position;

        toMouse.Normalize();

        cTrans.up = toMouse;

        #endregion
    }
}
