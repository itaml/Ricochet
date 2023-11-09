using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public BoxCollider2D box, box2, box3;
    private Game game;

    public Sprite[] balls;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = balls[Menu.currentball];
        game = GameObject.Find("Main Camera").GetComponent<Game>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        box.enabled = true;
        box.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        if (GameObject.Find("level3") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level4") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level7") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level8") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
            box3.enabled = true;
            box3.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level9") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level12") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level13") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level14") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
            box3.enabled = true;
            box3.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        if (GameObject.Find("level15") != null)
        {
            box2.enabled = true;
            box2.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
            box3.enabled = true;
            box3.gameObject.transform.parent.gameObject.GetComponent<DragAndDrop>().rotate = false;
        }
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            game.timerStart = false;
            if (GameObject.Find("level1") != null) game.second.SetActive(false);
            gameObject.SetActive(false);
            game.gameover.SetActive(true);
        }
        else if (collision.CompareTag("Respawn")) SceneManager.LoadScene(1);
        else if (collision.CompareTag("Jump")) rb.AddForce(collision.gameObject.transform.up * 20, ForceMode2D.Impulse);
        else if (collision.CompareTag("Batut")) rb.AddForce(collision.gameObject.transform.up * 20, ForceMode2D.Impulse);
        else if (collision.CompareTag("tp1"))
        {
            transform.position = GameObject.FindGameObjectWithTag("tp2").gameObject.transform.position;
            rb.velocity = Vector2.zero;
        }
    }
}
