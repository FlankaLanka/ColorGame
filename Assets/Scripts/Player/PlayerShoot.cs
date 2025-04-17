using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject paintballPrefab;
    public Transform firePoint;
    public bool canShoot = true;
    public float shootCooldown = 0.05f;
    private float timer = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            ShootPaintball();
            canShoot = false;
            timer = 0f;
        }

        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= shootCooldown)
            {
                canShoot = true;
            }
        }
    }

    void ShootPaintball()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 rawDirection = mouseWorldPos - transform.position;
        rawDirection.Normalize();

        //Vector2 shootDirection = rawDirection;
        Vector2 shootDirection = DirectionHelper.GetClosestDirection(rawDirection);

        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position;

        GameObject paintball = Instantiate(paintballPrefab, spawnPos, Quaternion.identity);
        PaintballBase trajectory = paintball.GetComponent<PaintballBase>();

        if (trajectory != null)
        {
            trajectory.SetDirection(shootDirection);
        }
        else
        {
            Debug.LogError("Projectile is missing PaintballBase script");
        }
    }
}
