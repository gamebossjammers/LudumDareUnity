using UnityEngine;

public class RegularTowerTrigger : MonoBehaviour
{
    public int _bonusMoves = 2;
    public Mesh _brokenMesh;

    private MeshFilter _meshFilter;

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Regular Tower hit");
            GameInstance.GetCurrentGameManager().AddMove(_bonusMoves);
            _meshFilter.mesh = _brokenMesh;
        }
    }
}
