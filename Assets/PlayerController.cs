using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedplay = 5;
    public AudioClip sound, die;
    //bool isMoving = true;
    GameController gameController;
    ScoreController scoreController;
    public Item item;

    public float suctionForce = 100f;//lực hút của vật thể.
    public float suctionLength = 30f;//khoảng cách tối đa mà vật thể có thể hút các vật khác.
    public string suctionTag = "SuctionObject";//tag của các vật cần bị hút.
    public float suctionTime = 50f;//thời gian hệ thống hút sẽ hoạt động khi tiếp xúc với vật thể.

    private bool isSuctionActive = false;
    private float suctionTimer = 0f;

    public bool anduocvatpham = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();

        //item = GameObject.FindObjectOfType<Item>().GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(horizontal * speedplay, rb.velocity.y);

        if (GameObject.FindObjectOfType<Item>() != null)
        {
            item = GameObject.FindObjectOfType<Item>().GetComponent<Item>();
        }
    }



    void loadFinish()
    {
        Save_by_name(gameController.score);
        SceneManager.LoadScene(2);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //isMoving = false;
        if (collision.gameObject.CompareTag("banana"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            gameController.score+=2;
            scoreController.count+=2;
        }

        if (collision.gameObject.CompareTag("diamond"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            gameController.score+=1;
            scoreController.count+=1;
        }
        if (collision.gameObject.CompareTag("boom"))
        {
            AudioSource.PlayClipAtPoint(die, transform.position);
            gameController.hp -= 1;
            if (gameController.hp == 0) loadFinish();
        }
        if (collision.gameObject.CompareTag("hp"))
        {
            AudioSource.PlayClipAtPoint(sound, transform.position);
            gameController.hp += 1;
            if (gameController.hp >= 3) gameController.hp = 3;
        }
        if (collision.gameObject.CompareTag("dongho"))
        {
            Debug.Log(" OnCollisionEnter2D dongho");
            AudioSource.PlayClipAtPoint(sound, transform.position);
            //item.speed *= 0.2f;
            anduocvatpham = true;
            item.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            StartCoroutine(ResetVelocity(10f));
        }
        IEnumerator ResetVelocity(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            Debug.Log("waitTime " + waitTime + " ResetVelocity");
            //item.speed /= 0.2f;
            anduocvatpham = false;
        }

        if (collision.gameObject.CompareTag("tangtoc"))
        {
            Debug.Log(" OnCollisionEnter2D tangtoc");
            AudioSource.PlayClipAtPoint(sound, transform.position);
            speedplay *= 2f;
            StartCoroutine(ResetVelocity1(5f));
        }
        IEnumerator ResetVelocity1(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            speedplay /= 2f;
        }

        if (collision.gameObject.CompareTag("lamcham"))
        {
            Debug.Log(" OnCollisionEnter2D lamcham"); 
            AudioSource.PlayClipAtPoint(sound, transform.position);
            speedplay *= 0.4f;
            StartCoroutine(ResetVelocity2(5f));
        }
        IEnumerator ResetVelocity2(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            speedplay /= 0.4f;
        }
        if (collision.gameObject.tag == "Ground")
        {

        }
        //if (gameController.score > 0)
        //{
            //PlayerPrefs.SetInt("Count", scoreController.count);
            PlayerPrefs.SetInt("Count", gameController.score);
        //}
        
        if (gameController.score > gameController.highScore)
        {
            gameController.highScore = gameController.score;
            PlayerPrefs.SetInt("HighScore", gameController.score);
            //PlayerPrefs.SetInt("HighCount", scoreController.count);
        }
    }

    public void Save_by_name(int score)
    {
        var names = PlayerPrefs.GetString("PlayerNames");
        Debug.Log(names);
        string[] namesArray = names.Split('\n');
        var json = PlayerPrefs.GetString("BXH");
        if(namesArray.Length > 0)
        {
            json += namesArray[namesArray.Length - 1] + "   " + score + "\n";
        }
        Debug.Log("Save " + json);
        PlayerPrefs.SetString("BXH", json);
        PlayerPrefs.Save();
    }
}
