using UnityEngine;

public class WallDoor : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void OpenWall()
    {
        rb.isKinematic = false;
    }
}