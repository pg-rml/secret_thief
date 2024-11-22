using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Knapsack : MonoBehaviour
{

    // 사과, 다이아, 시계, 마음, 금    
    int[] itemWeight = {0, 3, 4, 5, 5, 7};
    int[] itemValue = {0, 1, 5, 3, 10, 5};

    int bundleSize = 10;

    int[,] K = new int[6 , 11];
    public void calculateK(){

        int big = 0;

        for(int i = 0; i < 6; i++){
            K[i, 0] = 0;
        }
        for(int i = 0; i < bundleSize; i++){
            K[0, i] = 0;
        }

        for(int i = 1; i <= 5; i++){
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

        Debug.Log(K[5, 10]);
    }
    // Start is called before the first frame update
    void Start()
    {
        calculateK();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
