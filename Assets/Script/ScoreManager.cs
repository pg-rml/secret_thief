using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    float[] rankerScore = new float[7];

    // Start is called before the first frame update
    void Start()
    {
        
        float currentScore = 0f;
        currentScore += ((float)(PlayerPrefs.GetInt("PlayerScore"))/(float)(PlayerPrefs.GetInt("HighScore"))) * 50;
        Debug.Log(currentScore);
        currentScore += ((float)(PlayerPrefs.GetInt("ShortestDistance")) / (float)(PlayerPrefs.GetInt("PlayerDistance"))) * 50;
        Debug.Log(currentScore);

        if(!PlayerPrefs.HasKey("NewGame"))
        {
            ResetRankScore(rankerScore);
        }

        PlayerPrefs.SetFloat("CurrentScore", currentScore);
        SetScore(rankerScore, currentScore);

        //textMeshPro.text = "" + currentScore.ToString("F1");
        //출력 어케함
        ShowRank(textMeshPro);
        
    }

    void ResetRankScore(float[] rankerScore)
    {
        for(int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetFloat("RankerScore" + i, 0);
        }
    }

    void SetScore(float[] rankerScore, float currentScore)
    {
    //상위 ranker의 점수를 가져옴
        for(int i = 0; i < 7; i++)
        {
            rankerScore[i] = PlayerPrefs.GetFloat("RankerScore" + i);
        }

    //7위보다 점수가 높을 경우 삽입정렬 실행
        if(rankerScore[6] < currentScore)
        {
            Insertion_sort(rankerScore, currentScore);
        }

    //재배열된 랭크 저장
        for(int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetFloat("RankerScore" + i, rankerScore[i]);
        }
    }

    //삽입정렬 내림차순
    void Insertion_sort(float[] list, float key)
    {
        int i;
        for(i = 5; 0 <= i && list[i] < key; i--) 
        {
            list[i+1] = list[i];
        }

        list[i+1] = key;
    }

    void ShowRank(TextMeshProUGUI textMeshPro)
    {
        string rank = "     Rank\n\n";
        for(int i = 0; i < 7; i++)
        {
            rank += ((i+1) + ". " + PlayerPrefs.GetFloat("RankerScore" + i).ToString("F1") + "\n");
        }

        textMeshPro.text = rank;
    }
}


