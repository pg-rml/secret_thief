using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("HouseSelected_0");
        PlayerPrefs.DeleteKey("HouseINDEX_0");
        PlayerPrefs.DeleteKey("HouseX_0");
        PlayerPrefs.DeleteKey("HouseY_0");

        PlayerPrefs.DeleteKey("FirstExecutionDone");

        PlayerPrefs.SetInt("NewGame", 1);
    }

}
