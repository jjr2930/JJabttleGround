using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    #region Fields    
    [SerializeField]
    Transform player = null;

    [SerializeField]
    float orthoChangeTime = 0f;

    Transform cTrans = null;

    /// <summary>
    /// c means cached
    /// </summary>
    Camera cCam = null;

    Vector3 curPosition = Vector3.zero;

    IEnumerator changeOrthoSizeCoroutine = null;
    #endregion

    private void Awake()
    {
        cCam = GetComponent<Camera>();

        cTrans = transform;

        curPosition = transform.position;
    }

    private void Update()
    {
        curPosition = cTrans.position;

        curPosition.x = player.position.x;

        curPosition.y = player.position.y;

        cTrans.position = curPosition;
    }

    public void SetOrthoSize(float size)
    {
        if( null != changeOrthoSizeCoroutine )
            StopCoroutine( changeOrthoSizeCoroutine );

        changeOrthoSizeCoroutine = JobChangeOrthSize( size );
        StartCoroutine( changeOrthoSizeCoroutine );
    }

    IEnumerator JobChangeOrthSize(float size)
    {
        float amount = size - cCam.orthographicSize;

        float amountPerSec = amount / orthoChangeTime;

        float startTime = Time.realtimeSinceStartup;

        while( Time.realtimeSinceStartup - startTime < orthoChangeTime )
        {
            cCam.orthographicSize += amountPerSec * Time.deltaTime;

            yield return null;
        }

        cCam.orthographicSize = size;
    }

    //public void OnGUI()
    //{
    //    if( GUILayout.Button( "2X" ) )
    //    {
    //        SetOrthoSize( 2f );
    //    }

    //    if( GUILayout.Button( "4X" ) )
    //    {
    //        SetOrthoSize( 4f );
    //    }

    //    if( GUILayout.Button( "8X" ) )
    //    {
    //        SetOrthoSize( 8f );
    //    }

    //    if( GUILayout.Button( "16X" ) )
    //    {
    //        SetOrthoSize( 16f );
    //    }
    //}
}
