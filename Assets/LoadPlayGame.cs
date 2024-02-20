using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LoadPlayGame : MonoBehaviour
{
    public static LoadPlayGame instance;
    public GameObject menu, mota;

    private void Awake()
    {
        instance = this;
        OpenMenu();
    }
    public void OpenMenu()
    {
        CloseAll();
        menu.SetActive(true);
    }
    public void OpenMota()
    {
        CloseAll();
        mota.SetActive(true);
    }
    private void CloseAll()
    {
        menu.SetActive(false);
        mota.SetActive(false);
    }
    public TMP_InputField nameInput;
    public void loadGame()
    {
        SceneManager.LoadScene(0);

        string playerName = nameInput.text;

        //ResetPlayerPre();

        // Lấy danh sách tên từ PlayerPrefs
        string namesString = PlayerPrefs.GetString("PlayerNames");
        string[] namesArray = namesString.Split('\n');

        // Kiểm tra nếu tên đã tồn tại trong danh sách
        if (System.Array.IndexOf(namesArray, playerName) == -1)
        {
            // Thêm tên vào danh sách
            PlayerPrefs.SetString("PlayerNames", namesString + "\n" + playerName);
            PlayerPrefs.Save();
        }        
    }

    public void ResetPlayerPre()
    {
        PlayerPrefs.SetString("BXH", "");
        PlayerPrefs.SetString("PlayerNames", "");
        PlayerPrefs.Save();
    }
}
