using UnityEngine;
using UnityEngine.UI;

public class PressFController : MonoBehaviour
{
    Text text = null;

    private void Awake()
    {
        text = GetComponent<Text>();

        text.enabled = false;
    }
    public void ContactItem()
    {
        text.enabled = true;
    }

    public void SeperateItem()
    {
        text.enabled = false;
    }
}
