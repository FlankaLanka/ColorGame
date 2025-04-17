using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class PaintballBase : MonoBehaviour
{
    [Header("Paintball Settings")]
    [SerializeField]
    protected float speed = 10f;
    protected Vector2 direction;
    protected ColorHelper.WorldColors colorType;
    protected Rigidbody2D rb;
    protected SpriteRenderer sr;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = ColorHelper.colorsMap[colorType];
    }

    protected void Update()
    {
        rb.linearVelocity = direction * speed;
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 moveDir)
    {
        direction = moveDir;
        rb.linearVelocity = moveDir.normalized * speed;
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for color match on the collided object
        ColorTag wallTag = collision.collider.GetComponent<ColorTag>();
        if (wallTag != null && ColorHelper.Matches(this.colorType, wallTag.colorType))
        {
            // Bounce: reflect velocity
            Vector2 surfaceNormal = collision.contacts[0].normal;
            Vector2 reflect = Vector2.Reflect(direction, surfaceNormal).normalized;
            direction = reflect;
            Debug.Log("Bounced off same-color surface.");
            return;
        }

        ColorTag targetTag = collision.collider.GetComponent<ColorTag>();
        if (targetTag != null && ColorHelper.Matches(this.colorType, targetTag.colorType))
        {
            DoSomething();
        }

        // Fallback effect logic to be handled in derived class
        Debug.Log("Paintball hit something (no bounce).");
        Destroy(gameObject);
    }

    protected virtual void DoSomething()
    {
        //override this 
    }
}
