using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SaveName : MonoBehaviour
{
    public TMP_Text namesText;
    public int count;
    private void Start()
    {
        //count = PlayerPrefs.GetInt("Count");
        //string namesString = PlayerPrefs.GetString("PlayerNames") + "   " + count;
        //string[] namesArray = namesString.Split('\n');
        //string namesFormatted = string.Join("\n", namesArray);
        //namesText.text = namesFormatted;

        string jsonbxh = PlayerPrefs.GetString("BXH");
        string[] bxhArray = jsonbxh.Split('\n');
        if(bxhArray != null && bxhArray.Length > 10)
        {
            jsonbxh = "";
            for(int i = bxhArray.Length - 11; i < bxhArray.Length; i++)
            {
                jsonbxh += bxhArray[i] + '\n';
            }
        }
        namesText.text = jsonbxh;
        //PlayerPrefs.SetString("BXH", jsonbxh);
       
    }


}
