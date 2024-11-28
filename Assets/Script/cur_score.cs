using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class cur_score : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float currentScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetFloat("CurrentScore");
        textMeshPro.text = "" + currentScore.ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
