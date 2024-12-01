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
    
    void Print2DArray(int[,] array)
    {
        string output = ""; // 출력할 문자열

        for (int i = 0; i < array.GetLength(0); i++) // 행 순회
        {
            for (int j = 0; j < array.GetLength(1); j++) // 열 순회
            {
                output += array[i, j] + " "; // 각 값을 문자열에 추가
            }
            output += "\n"; // 각 행의 끝에 줄바꿈 추가
        }

        Debug.Log(output); // 최종 문자열을 Console 창에 출력
    }
    void itemSetting(){

        int delete = 0;
        int delete2 = 0;

        int temp = Random.Range(1, 4);
        delete = temp;
        Debug.Log("delete " + delete);
        while(true){

            temp = Random.Range(1, 4);
            if(delete == temp) continue;
            
            delete2 = temp;
            Debug.Log("delete2 " + delete2);

            if(delete2 > delete){
                itemWeight.RemoveAt(delete2);
                itemWeight.RemoveAt(delete);
            }
            else{
                itemWeight.RemoveAt(delete);
                itemWeight.RemoveAt(delete2);
            }

            if(delete2 > delete){
                itemValue.RemoveAt(delete2);
                itemValue.RemoveAt(delete);
            }
            else{
                itemValue.RemoveAt(delete);
                itemValue.RemoveAt(delete2);
            }
            

            foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()){
                Item item = obj.GetComponent<Item>();

                if (item != null && item.index == delete){
                    
                    Destroy(obj); // 오브젝트 삭제
                    break;

                }
            
            }

            foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>()){
                Item item = obj.GetComponent<Item>();

                if (item != null && item.index == delete2){
                    
                    Destroy(obj); // 오브젝트 삭제
                    break;

                }
            
            }

            if(itemWeight.Count == 4) break;
        }
        
    }
    public void calculateK(){

        int big = 0;
        Debug.Log(itemWeight[1] + ", " + itemWeight[2] + ", " +itemWeight[3]);
        Debug.Log(itemValue[1] + ", " + itemValue[2] + ", " +itemValue[3]);
        
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
        Print2DArray(K);
        
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
