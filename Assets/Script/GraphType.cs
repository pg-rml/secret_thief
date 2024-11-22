using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphType {
    
    public int Housenum;
    public int[,] weight = new int[6, 6];

    // 생성자 (멤버 변수 초기화)
    public GraphType(){

        Housenum = 0;
        
        for(int i = 0; i < 6; i++) {

            for(int j = 0; j < 6; j++) {
                weight[i, j] = -1;
            }
        }

    }

}
