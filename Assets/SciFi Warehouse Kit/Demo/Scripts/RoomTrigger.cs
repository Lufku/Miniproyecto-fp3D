using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public TargetManager targetManager;
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered trigger: " + other.name);

        if (activated) return;

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER DETECTED");

            activated = true;
            targetManager.ActivateRoom();
        }
    }
}