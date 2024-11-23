using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int index;
    public int weight;
    public int value;

    int totalWeight;
    int totalValue;

    void steal(){
        totalWeight = PlayerPrefs.GetInt("TotalWeight");
        totalValue = PlayerPrefs.GetInt("TotalValue");

        if(totalWeight + weight <= 10){

            PlayerPrefs.SetInt("TotalWeight", totalWeight + weight);
            PlayerPrefs.Save();

            Debug.Log(PlayerPrefs.GetInt("TotalWeight"));

            int PlayerScore = PlayerPrefs.GetInt("PlayerScore") + value;
            PlayerPrefs.SetInt("PlayerScore", PlayerScore);

            Debug.Log("누적 점수 " + PlayerPrefs.GetInt("PlayerScore"));
            
            Destroy(gameObject);
        }

        
    }

    void Start(){

    }

    void OnMouseDown(){
        steal();
        
    }

}
