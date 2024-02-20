using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] Item;
    public GameObject[] Support;
    float T = 1.5f;
    float timeCountDown1 = 0;
    float timeCountDown2 = 0;
    float timeCountDown3 = 0;
    public TMP_Text ScoreText, HpText;
    public int score;
    public int highScore;
    public int hp = 3;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        //InvokeRepeating("Create", 1, 1);
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(1);
    }
    
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score + "\nHighScore: " + highScore;
        HpText.text = "" + hp;
        timeCountDown1 += Time.deltaTime;
        timeCountDown2 += Time.deltaTime;
        timeCountDown3 += Time.deltaTime;

        if (timeCountDown1 > T)
        {
            Instantiate(Item[Random.Range(0, Item.Length)], new Vector2(Random.Range(-2.5f, 2.5f), 5.5f), Quaternion.identity);
            timeCountDown1 = 0;
        }
        if (timeCountDown2 > 10)
        {
            T -= 0.1f;
            timeCountDown2 = 0;
        }
        if (timeCountDown3 > 10)
        {
            Instantiate(Support[Random.Range(0, Support.Length)], new Vector2(Random.Range(-2.5f, 2.5f), 5.5f), Quaternion.identity);
            timeCountDown3 = 0;
        }
    }
}