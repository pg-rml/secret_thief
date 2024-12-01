using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {   
        PlayerPrefs.SetInt("HouseCount", 0);
        // House의 가치 합산용 
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("PlayerScore", 0);

        // Map의 거리 합산용 
        PlayerPrefs.SetInt("ShortestDistance", 0);
        PlayerPrefs.SetInt("PlayerDistance", 0);

        PlayerPrefs.DeleteKey("NewGame");
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
