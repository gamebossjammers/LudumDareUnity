using System.Collections;
using UnityEngine;

public class HidePanels : MonoBehaviour
{
    public GameObject[] _panels;
    public float _timeToLive = 6f;
    
    private void OnEnable ()
    {
        StartCoroutine(DisablePanels());
    }

    private void OnDisable ()
    {
        foreach (var panel in _panels)
        {
            panel.gameObject.SetActive(true);
        }
    }

    private IEnumerator DisablePanels ()
    {
        yield return new WaitForSeconds(_timeToLive);
        foreach (var panel in _panels)
        {
            panel.gameObject.SetActive(false);
        }
    }
}
