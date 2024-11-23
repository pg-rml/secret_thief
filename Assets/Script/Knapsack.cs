using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;

public class Knapsack : MonoBehaviour
{

    // 사과, 다이아, 시계, 마음, 금    
    List<int> itemWeight = new List<int> { 0, 3, 4, 5, 6, 7 };
    List<int> itemValue = new List<int> { 0, 1, 5, 3, 10, 5 };
    //int[] itemWeight = {0, 3, 4, 5, 5, 7};
    //int[] itemValue = {0, 1, 5, 3, 10, 5};


    int bundleSize = 10;

    int[,] K = new int[4 , 11];
    
    void itemSetting(){

        int delete = 0;

        while(true){

            int temp = Random.Range(1, 4);
            if(delete == temp) continue;
            
            delete = temp;

            itemWeight.RemoveAt(delete);
            itemValue.RemoveAt(delete);

            foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()){
                Item item = obj.GetComponent<Item>();

                if (item != null && item.index == delete){
                    
                    Destroy(obj); // 오브젝트 삭제
                    break;
                }
            
            }

            if(itemWeight.Count == 4) break;
        }
        
    }
    public void calculateK(){

        int big = 0;

        for(int i = 0; i < 4; i++){
            K[i, 0] = 0;
        }
        for(int i = 0; i < bundleSize; i++){
            K[0, i] = 0;
        }

        for(int i = 1; i < 4; i++){
            for(int w = 1; w <= bundleSize; w++){
                if(itemWeight[i] > w){
                    K[i, w] = K[i-1, w];
                }
                else{
                    if(K[i-1, w] > (K[i-1, w-itemWeight[i]])+itemValue[i]){
                        big = K[i-1, w];
                    }

                    else{
                        big = (K[i-1, w-itemWeight[i]])+itemValue[i];
                    }

                    K[i, w] = big;
                }
            } 
        }

        Debug.Log("최고 점수 " + K[3, 10]);
        int HighScore = PlayerPrefs.GetInt("HighScore") + K[3, 10];
        PlayerPrefs.SetInt("HighScore", HighScore);
        PlayerPrefs.Save();
    }
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        itemSetting();
        calculateK();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
