using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{   
    public Image timerImage;
    float totalTime = 5.0f;
    float currentTime;

    // Start is called before the first frame update
    void Awake()
    {      
        currentTime = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        timerImage.fillAmount = currentTime / totalTime;

        if(timerImage.fillAmount == 0) SceneManager.LoadScene("GameOver");
    }
}
