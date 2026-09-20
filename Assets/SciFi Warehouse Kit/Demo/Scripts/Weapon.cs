using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public Transform muzzlePoint;
    public GameObject bulletPrefab;

    [Header("Weapon Settings")]
    public float fireRate = 0.2f;
    public float shootDistance = 100f;

    private float nextFireTime;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f));

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out RaycastHit hit, shootDistance))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(shootDistance);
        }

        Vector3 direction =
            (targetPoint - muzzlePoint.position).normalized;

        Instantiate(
            bulletPrefab,
            muzzlePoint.position,
            Quaternion.LookRotation(direction));
    }
}