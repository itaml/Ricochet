using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePos;
    public bool rotate;

    private Vector3 screenPos;
    private float angle;
    private Collider2D col;

    public Color inviz;

    public Game game;

    private void Start()
    {
        game = GameObject.Find("Main Camera").GetComponent<Game>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (rotate)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else 
        { 
            gameObject.GetComponent<SpriteRenderer>().color = inviz; 
        }

        if (rotate)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    screenPos = Camera.main.WorldToScreenPoint(transform.position);
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    angle = (Mathf.Atan2(transform.right.y, transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                }
            }
            if (Input.GetMouseButton(0))
            {
                if (col == Physics2D.OverlapPoint(mousePos))
                {
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    float angle2 = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    transform.eulerAngles = new Vector3(0, 0, angle2 + angle);
                }
            }
        }
    }

    private Vector3 GetMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (rotate == false) mousePos = gameObject.transform.position - GetMouse();
    }

    private void OnMouseUp()
    {
        rotate = !rotate;
        if (GameObject.Find("level1") != null)
        {
            if (game.first.activeSelf == true)
            {
                game.first.SetActive(false);
                game.second.SetActive(true);
            }
            else if (game.second.activeSelf == true)
            {
                game.second.SetActive(false);
                game.third.SetActive(true);
            }
        }
    }

    private void OnMouseDrag()
    {
        if (rotate == false ) transform.position = GetMouse() + mousePos;
    }
}
