using UnityEngine;

public class EnemyMovement : MonoBehaviour
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
        Vector2 point = currPoint.position - transform.position;
        if (currPoint == PointB.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currPoint.position) < 0.5f && currPoint == PointB.transform)
        {
            currPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currPoint.position) < 0.5f && currPoint == PointA.transform)
        {
            currPoint = PointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}
