using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackpackElementUIController : MonoBehaviour
{
    [SerializeField]    Image   img = null;
    [SerializeField]    Text    txt = null;


    public void SetMember(string spritePath, string text )
    {
        Sprite loaded = Resources.Load( spritePath, typeof(Sprite) ) as Sprite;
        img.sprite = loaded;
        txt.text = text;
    }
}
