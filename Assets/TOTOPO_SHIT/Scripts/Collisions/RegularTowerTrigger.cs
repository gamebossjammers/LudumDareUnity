using UnityEngine;

public class RegularTowerTrigger : MonoBehaviour
{
    public int _bonusMoves = 2;
    public GameObject _brokenPrefab;


    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            //Debug.Log("Regular Tower hit");
            GameInstance.GetCurrentGameManager().RegularTowerHit(_bonusMoves);
            var go = Instantiate(_brokenPrefab, this.transform.position, this.transform.rotation) as GameObject;
            go.transform.parent = this.transform.parent;
            Destroy(gameObject);
        }
    }
}
