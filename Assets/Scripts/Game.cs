using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject first, second, third;
    public int stars;
    public GameObject gameover;
    public float timer;
    public bool timerStart;
    public int seconds;

    public Text record, win_record;
    public GameObject flag1, flag2, flag3;
    public Image flags;
    public Sprite flags1, flags2, flags0;

    public GameObject[] levels;

    private void Start()
    {
        levels[Menu.currentLevel].SetActive(true);

        Time.timeScale = 1;
        if (Menu.currentLevel == 0)
        {
            first.SetActive(true);
        }
    }

    private void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime;
            seconds = (int)timer;
            record.text = seconds.ToString();
            win_record.text = seconds.ToString();
        }

        if (seconds <= 15) stars = 3;
        else if (seconds <= 20)
        {
            stars = 2;
            flag1.SetActive(false);
            flags.sprite = flags2;
        }
        else if (seconds <= 30)
        {
            stars = 1;
            flag1.SetActive(false);
            flag2.SetActive(false);
            flags.sprite = flags1;
        }
        else
        {
            stars = 0;
            flag1.SetActive(false);
            flag2.SetActive(false);
            flag3.SetActive(false);
            flags.sprite = flags0;
        }
    }

    public void Pause(int i)
    {
        if (i == 0) Time.timeScale = 0;
        else { Time.timeScale = 1; }
    }

    public void Win()
    {
        if (PlayerPrefs.HasKey("stars"+ Menu.currentLevel.ToString()))
        {
            if (PlayerPrefs.GetInt("stars" + Menu.currentLevel.ToString()) == 0)
            {
                Menu.money += 3;
                PlayerPrefs.SetInt("money", Menu.money);
            }
            else if (PlayerPrefs.GetInt("stars" + Menu.currentLevel.ToString()) == 1)
            {
                Menu.money += 2;
                PlayerPrefs.SetInt("money", Menu.money);
            }
            else if (PlayerPrefs.GetInt("stars" + Menu.currentLevel.ToString()) == 2)
            {
                Menu.money += 1;
                PlayerPrefs.SetInt("money", Menu.money);
            }
        }
        else
        {
            PlayerPrefs.SetInt("stars" + Menu.currentLevel.ToString(), stars);
        }
        if (Menu.currentLevel == PlayerPrefs.GetInt("level"))
        {
            Menu.currentLevel++;
            PlayerPrefs.SetInt("level", Menu.currentLevel);
            Menu.money += stars;
            PlayerPrefs.SetInt("money", Menu.money);
        }
        else
        {
            Menu.currentLevel++;
        }
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
