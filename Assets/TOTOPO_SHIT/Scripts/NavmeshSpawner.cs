using System;
using UnityEngine;


public class NavmeshSpawner : MonoBehaviour
{
    public float _checkRange;
    
    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Look for a point bastard!");
            SpawnOnNavMesh();
        }
    }

    private void SpawnOnNavMesh()
    {
        NavMeshHit navHit;
        if (NavMesh.SamplePosition(transform.position, out navHit, _checkRange, -1))
        {
            transform.position = navHit.position;
        }
    }
}
