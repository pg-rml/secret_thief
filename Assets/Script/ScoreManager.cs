using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        float score = 0f;
        score += ((float)(PlayerPrefs.GetInt("PlayerScore"))/(float)(PlayerPrefs.GetInt("HighScore"))) * 50;
        Debug.Log(score);
        score += ((float)(PlayerPrefs.GetInt("ShortestDistance")) / (float)(PlayerPrefs.GetInt("PlayerDistance"))) * 50;
        Debug.Log(score);
        textMeshPro.text = "" + score.ToString("F1");
    }


}
