using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float startingPosition;
    [SerializeField] private float endPosition;
    [SerializeField] private bool isX;

    private bool upMove = true;

    private Vector3 pos;

    void FixedUpdate()
    {
        if (isX)
        {
            transform.position += transform.right * speed * Time.deltaTime;
            if (pos.x > endPosition && upMove)
            {
                upMove = false;
                speed *= -1f;
            }
            if (pos.x < startingPosition && !upMove)
            {
                upMove = true;
                speed *= -1f;
            }
            pos = transform.position;
        }
        else
        {
            transform.position += transform.up * speed * Time.deltaTime;
            if (pos.y > endPosition && upMove)
            {
                upMove = false;
                speed *= -1f;
            }
            if (pos.y < startingPosition && !upMove)
            {
                upMove = true;
                speed *= -1f;
            }
            pos = transform.position;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        col.gameObject.transform.parent = transform;
    }

    void OnCollisionExit(Collision col)
    {
        col.gameObject.transform.parent = null;
    }
}
