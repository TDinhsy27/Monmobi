using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFinish : MonoBehaviour
{
    public void loadFinish()
    {
        SceneManager.LoadScene(2);
    }
}
