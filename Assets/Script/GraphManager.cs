using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    GraphType graphType = new GraphType();
    House startHouse = new House();

    int[] distance = new int[6];
    int[] selected = new int[6];


    public void printArray(int[] array){
        string output = "";
        for (int i = 0; i < 6; i++) // 열 순회
        {
            output += array[i] + " ";
        }

        Debug.Log(output);
    }
    
    // 매개변수: 배열 개수
    public int getMinDisHouse(int n){
        
        int result = -1;
        
        for(int i = 0; i < n; i++){
            if(selected[i] != 1){
                result = i;
                break;
            }
        }

        //printArray(distance);
        for(int i = 0; i < n; i++){
            if((selected[i] != 1) && (distance[i] < distance[result])) {
                result = i;
            }
        } 

        return result;
    }

    public void prim(ref GraphType graphType, ref int[] result){

        int totalDistance = 0;
        int selectedHouse = 0;

        for(int i = 0; i < 6; i++){
            selected[i] = 0;
        }

        int shortestHouse = 0;

        //Debug.Log(graphType.Housenum);
        // 각 요소까지의 거리를 초기화 
        for(int i = 0; i < graphType.Housenum; i++){
            distance[i] = 100;
        }
    
        //Debug.Log("distance 초기화");

        // 시작 정점과의 거리를 0으로 설정 
        distance[0] = 0;

        for(int i = 0; i < graphType.Housenum; i++){
            //Debug.Log(i + "번째 반복문 시작");
            shortestHouse = getMinDisHouse(graphType.Housenum);
            selected[shortestHouse] = 1;

            if(distance[shortestHouse] == -1){
               //Debug.Log("리턴함");
               return;
            }

            result[i] = shortestHouse;
            Debug.Log("집" + shortestHouse + "추가");
            selectedHouse += 1;
            if(selectedHouse < 5) totalDistance += distance[shortestHouse];

            // 첫바퀴에 돌아가겠네...
            for(int anotherHouse = 0; anotherHouse < graphType.Housenum; anotherHouse++)
                if(graphType.weight[shortestHouse, anotherHouse] != -1)
                    if((selected[anotherHouse] != 1) && graphType.weight[shortestHouse, anotherHouse] < distance[anotherHouse])
                        distance[anotherHouse] = graphType.weight[shortestHouse, anotherHouse];
                      
        }

        PlayerPrefs.SetInt("totalDistance", totalDistance);
        Debug.Log(totalDistance);
        //printArray(result);

    }

    public void calculate(House[] HouseArray, ref int[,] weight) {

        int bigx = 0;
        int smallx = 0;
        int bigy = 0;
        int smally = 0;

        for(int i = 0; i < 6; i++){
            
            for(int j = 0; j < 6; j++){
                
                if(HouseArray[i].x > HouseArray[j].x){
                    bigx = HouseArray[i].x;
                    smallx = HouseArray[j].x;
                }
                else{
                    bigx = HouseArray[j].x;
                    smallx = HouseArray[i].x;
                } 

                if(HouseArray[i].y > HouseArray[j].y){
                    bigy = HouseArray[i].y;
                    smally = HouseArray[j].y;
                }
                else{
                    bigy = HouseArray[j].y;
                    smally = HouseArray[i].y;
                }    

                weight[i, j] = (bigx - smallx) + (bigy - smally); 

                //if(weight[i, j] > 5) weight[i, j] = -1;       
            }
        
        }

    }

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
    public void makeHouseTree(){

        // 0번: 플레이어 자리
        // 1~5번: 집 
        House[] HouseArray = new House[6];

        int[] result = new int[6];
        
        graphType.Housenum = 6;

        HouseArray[0] = new House(); 
        HouseArray[0].Initialize(0, 5, 0, -1);

        for (int index = 0; index < 5; index++) {
            
            int x = PlayerPrefs.GetInt("HouseX_" + index);
            int y = PlayerPrefs.GetInt("HouseY_" + index);
            int type = PlayerPrefs.GetInt("HouseType_" + index);
            HouseArray[index + 1] = new House(); 
            HouseArray[index + 1].Initialize(index, x, y, type);

        }


        calculate(HouseArray, ref graphType.weight);

        Print2DArray(graphType.weight);
         
        prim(ref graphType, ref result);     

    }

    void Start(){
        //makeHouseTree();
    }

    void OnApplicationQuit(){
        PlayerPrefs.DeleteKey("totalDistance");
    }
}
