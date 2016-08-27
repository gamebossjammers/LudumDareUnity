using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/// <summary>
/// An Enum with the 4 possible directions.
/// </summary>
public enum EDirections
{
    Up,
    Down,
    Right,
    Left
}

[System.Serializable]
public struct ColliderStruct
{
    public EDirections direction;
    public Vector3 position;
    public bool isClear;
}

public class ColliderChecker : MonoBehaviour
{
    public LayerMask _collisionLayer;
    public ColliderStruct[] _colliders;
    public float _collisionRadius = 7f;
    public Color _debugCanSpawnColor = Color.green;
    public Color _debugCannotSpawnColor = Color.red;
    public float _checkPeriod = 1f;

    private bool IsColliderClear(ColliderStruct pCollider)
    {
        var pos = pCollider.position;
        pos.x += this.transform.position.x;
        pos.y += this.transform.position.y;
        pos.z += this.transform.position.z;
        Collider[] hitColliders = Physics.OverlapSphere(pos, _collisionRadius, _collisionLayer);
        //Debug.Log(hitColliders.Length);
        return hitColliders.Length == 0;
    }

    public List<ColliderStruct> GetClearColliders ()
    {
        var clearColliders = new List<ColliderStruct>();
        for (int i = 0; i < _colliders.Length; i++)
        {
            _colliders[i].isClear = IsColliderClear(_colliders[i]);
            if (_colliders[i].isClear)
            {
                clearColliders.Add(_colliders[i]);
            }
        }
        return clearColliders;
    }

    private void OnDrawGizmos()
    {
        foreach (var collider in _colliders)
        {
            var pos = collider.position;
            pos.x += transform.position.x;
            pos.y += transform.position.y;
            pos.z += transform.position.z;
            Gizmos.color = collider.isClear ? _debugCanSpawnColor : _debugCannotSpawnColor;
            Gizmos.DrawWireSphere(pos, _collisionRadius);
        }
    }


    private IEnumerator CheckCollisions ()
    {
        while (true)
        {
            foreach (var collider in _colliders)
            {
                var list = GetClearColliders();
            }
            yield return new WaitForSeconds(_checkPeriod);
        }
    }

    private void Start ()
    {
        StartCoroutine(CheckCollisions());
    }
}
