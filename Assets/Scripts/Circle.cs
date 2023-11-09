using UnityEngine;

public class Circle : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 1));
    }
}
