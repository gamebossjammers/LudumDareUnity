using UnityEngine;

public class KingTowerTrigger : MonoBehaviour
{
    public GameObject _brokenPrefab;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("King's Tower hit");
            GameInstance.GetCurrentGameManager().MasterTowerDestroyed();
            var go = Instantiate(_brokenPrefab, this.transform.position, this.transform.rotation) as GameObject;
            go.transform.parent = this.transform.parent;
            Destroy(gameObject);
        }
    }
}
