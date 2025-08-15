using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public GameObject PointA, PointB;
    private Rigidbody2D rb;
    private Transform currPoint;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currPoint = PointB.transform;
    }

    void Update()
    {
        if (currPoint == PointB.transform)
        {
            rb.linearVelocity = new Vector2(0, speed);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, -speed);
        }

        if (Vector2.Distance(transform.position, currPoint.position) < 0.5f)
        {
            currPoint = (currPoint == PointB.transform) ? PointA.transform : PointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
