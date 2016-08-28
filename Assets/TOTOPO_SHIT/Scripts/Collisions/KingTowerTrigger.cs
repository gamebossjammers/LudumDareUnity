using UnityEngine;

public class KingTowerTrigger : MonoBehaviour
{
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("King's Tower hit");
            GameInstance.GetCurrentGameManager().MasterTowerDestroyed();
        }
    }
}
