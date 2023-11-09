using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static int currentLevel;
    public int levelplus;
    public Text level_text;
    public static int money;
    public static int currentball;
    public GameObject[] balls;
    public Sprite selected, select;
    public Text money_text;
    public Image flags;
    public Sprite flag1, flag2, flag3, flagempty;

    private void Start()
    {
        Time.timeScale = 1;

        PlayerPrefs.SetInt("ball0", 1);
        if (PlayerPrefs.HasKey("ball")) currentball = PlayerPrefs.GetInt("ball");
        if (!PlayerPrefs.HasKey("level")) PlayerPrefs.SetInt("level", 0);

        if (PlayerPrefs.HasKey("money")) money = PlayerPrefs.GetInt("money");
    }

    public void LeftRight(int i)
    {
        if (i == 0)
        {
            if (currentLevel != 0) currentLevel--;
        }
        else 
        {
            if (currentLevel != PlayerPrefs.GetInt("level")) currentLevel++;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        money_text.text = money.ToString();
        if (PlayerPrefs.HasKey("stars" + currentLevel.ToString()))
        {
            if (PlayerPrefs.GetInt("stars" + currentLevel.ToString()) == 3) flags.sprite = flag3;
            else if (PlayerPrefs.GetInt("stars" + currentLevel.ToString()) == 2) flags.sprite = flag2;
            else if (PlayerPrefs.GetInt("stars" + currentLevel.ToString()) == 1) flags.sprite = flag1;
        }
        else
        {
            flags.sprite = flagempty;
        }

        levelplus = currentLevel + 1;
        level_text.text = "Level " + levelplus.ToString();

        for (int i = 0; i < 15; i++)
        {
            if (PlayerPrefs.HasKey("ball" + i.ToString()))
            {
                balls[i].transform.GetChild(1).gameObject.SetActive(false);
                balls[i].transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
    
    public void BuyBall(int i)
    {
        int cost = i * 3;
        if (money >= cost)
        {
            money -= cost;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("ball" + i.ToString(), 1);
        }
    }

    public void SelectBall(int f)
    {
        currentball = f;
        PlayerPrefs.SetInt("ball", currentball);

        for (int i = 0; i < 15; i++)
        {
            balls[i].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = select;

            if (currentball == i)
            {
                balls[i].transform.GetChild(2).gameObject.GetComponent<Image>().sprite = selected;
            }
        }
    }

}
