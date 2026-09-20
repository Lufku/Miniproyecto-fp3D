using UnityEngine;

public class Target : MonoBehaviour
{
    public TargetManager manager;

    public void Hit()
    {
        Debug.Log(gameObject.name + " destroyed");

        if (manager != null)
        {
            manager.TargetDestroyed();
        }

        Destroy(gameObject);
    }
}
