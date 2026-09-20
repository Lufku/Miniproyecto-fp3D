using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public float lifeTime = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = transform.forward * speed;

        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();

        if (target != null)
        {
            target.Hit();
        }

        Destroy(gameObject);
    }
}