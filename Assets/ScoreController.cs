using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    public TMP_Text ScoreText2;
    public int count;
    public int highCount;
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        //loadMenu();
        count = PlayerPrefs.GetInt("Count");
        //highCount = PlayerPrefs.GetInt("HighCount");
        highScore = PlayerPrefs.GetInt("HighScore");
    }
    
    // Update is called once per frame
    void Update()
    {
        //ScoreText2.text = "Count: " + count + "\nHighCount: " + highCount+"\nHighScore: "+highScore;
        ScoreText2.text = "Count: " + count + "\nHighScore: " + highScore;
        //if (count != 0)
        //{
        //    count = 0;
        //}
    }
}