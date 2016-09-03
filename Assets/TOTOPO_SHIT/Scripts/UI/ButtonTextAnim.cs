using UnityEngine;
using UnityEngine.UI;

public class ButtonTextAnim : MonoBehaviour
{
    public GameObject _text;
    public float _displacement = 0.4f;

    public void Click ()
    {
        _text.transform.localPosition -= new Vector3 (0, _displacement, 0);
    }

    public void Release ()
    {
        _text.transform.localPosition += new Vector3(0, _displacement, 0);
    }
}
