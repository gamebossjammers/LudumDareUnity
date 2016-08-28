using UnityEngine;
using System.Collections;
using System;

public class DestroyInTime : MonoBehaviour
{
    public float _timeToLive = 5f;

    private Renderer[] _renderers;
    private float _elapsedTime = 0f;

    private void Start ()
    {
        _renderers = GetComponentsInChildren<MeshRenderer>();
        StartCoroutine(FadeIn());
        Destroy(gameObject, _timeToLive);
    }

    private IEnumerator FadeIn ()
    {
        while (_elapsedTime < _timeToLive)
        {
            _elapsedTime += Time.deltaTime;
            foreach (var r in _renderers)
            {
                var color = r.material.color;
                color.a -= 1 / _timeToLive * Time.deltaTime;
                r.material.color = color;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
