using UnityEngine;

public class ShootDirIndicator : MonoBehaviour
{
    public Transform player;
    public float distanceFromPlayer = 1f;

    void Update()
    {
        if (player == null) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDir = (mouseWorldPos - player.position).normalized;

        //Vector2 snappedDir = mouseDir.normalized;
        Vector2 snappedDir = DirectionHelper.GetClosestDirection(mouseDir);
        transform.position = (Vector2)player.position + (Vector2)(snappedDir * distanceFromPlayer);
    }
}
