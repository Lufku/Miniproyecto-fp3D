using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject wall;

    private int remainingTargets;

    public void ActivateRoom()
    {
        remainingTargets = targets.Length;

        foreach (GameObject target in targets)
        {
            target.SetActive(true);
        }

        Debug.Log("Room Activated. Targets: " + remainingTargets);
    }

    public void TargetDestroyed()
    {
        remainingTargets--;

        Debug.Log("Targets Remaining: " + remainingTargets);

        if (remainingTargets <= 0)
        {
            Destroy(wall);

            Debug.Log("Wall Destroyed");
        }
    }
}