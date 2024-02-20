using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    AudioSource[] Audio;
    public AudioSource audioSource;
    public AudioClip MusicBackGround;
    public Button onMusic;
    public Button offMusic;
    public Button pauseGame;
    public GameObject pausegame;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        Audio = GetComponents<AudioSource>();
        onMusic.onClick.AddListener(OnMusic);
        offMusic.onClick.AddListener(OffMusic);
        pauseGame.onClick.AddListener(PauseGame);
        pausegame.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMusic()
    {
        audioSource.Play();
    }
    void OffMusic()
    {
        audioSource.Pause();
    }
    void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            pausegame.SetActive(true);
            Audio[0].Pause();
        }
        else
        {
            Time.timeScale = 1f;
            pausegame.SetActive(true);
            Audio[0].Play();
        }
    }
}