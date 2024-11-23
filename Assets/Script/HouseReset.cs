using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseReset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("TotalWeight", 0);
        PlayerPrefs.SetInt("TotalValue", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
