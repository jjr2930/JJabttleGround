using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackpackElementUIController : MonoBehaviour
{
    [SerializeField]    Image   img = null;
    [SerializeField]    Text    txt = null;


    public void SetMember(string spriteName, string text )
    {
        img.sprite = Resources.Load( spriteName ) as Sprite;
        txt.text = text;
    }
}
