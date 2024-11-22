using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HouseGenerator : MonoBehaviour
{

    public House[] HouseArray = new House[5];
    public GameObject HousePrefab;

    public House MakeHouse (int size, House[] HouseArray){

        int x = -1, y = -1, type = -1;
        int done = 0;
        while(true){
            
            done = 0;

            x = Random.Range(0, 5);
            y = Random.Range(0, 5);

            type = Random.Range(0, 3);

            
            if(size == 0) {
                House newHouse = new House(); // 기본 생성자 호출
                newHouse.Initialize(x, y, type);
                return newHouse;
            }
            
            else{
                
                for(int i = 0; i < size; i++){
            
                    if ((x == HouseArray[i].x && y == HouseArray[i].y)){
                        done = -1;
                    }
                
                }     

                if(done == 0){
                    House newHouse = new House(); // 기본 생성자 호출
                    newHouse.Initialize(x, y, type);
                    return newHouse;    
                }

                
            }

            
            
        }    
    } 

    void Awake()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        if (!PlayerPrefs.HasKey("FirstExecutionDone"))
        {   
            for (int i = 0; i < 5; i++) {
                HouseArray[i] = MakeHouse(i, HouseArray);
                
                PlayerPrefs.SetInt("HouseX_" + i, HouseArray[i].x);
                PlayerPrefs.SetInt("HouseY_" + i, HouseArray[i].y);
                PlayerPrefs.SetInt("HouseType_" + i, HouseArray[i].type);
            }   
               
            Debug.Log("House 초기화");
            PlayerPrefs.SetInt("FirstExecutionDone", 1); // 첫 실행 완료 상태 저장
            PlayerPrefs.Save(); // 저장
        }

        else{
        // PlayerPrefs에서 값 로드
            for (int i = 0; i < 5; i++) {
                int x = PlayerPrefs.GetInt("HouseX_" + i);
                int y = PlayerPrefs.GetInt("HouseY_" + i);
                int type = PlayerPrefs.GetInt("HouseType_" + i);
                HouseArray[i] = new House(); 
                HouseArray[i].Initialize(x, y, type);
            }
            //Debug.Log("House 불러오기 완료");

        }

        for(int i = 0; i < 5; i++) {
            
            GameObject house = Instantiate(HousePrefab);
            House houseScript = house.GetComponent<House>();
            houseScript.x = HouseArray[i].x;  
            houseScript.y = HouseArray[i].y;  
            houseScript.type = HouseArray[i].type;
            house.transform.position = new Vector3((float)(-2.3 + 1.9 * (HouseArray[i].x - 2)), (float)(1.4 * (HouseArray[i].y - 2)), 0);
            //Debug.Log(i + " " + HouseArray[i].x + " " + HouseArray[i].y + " " + HouseArray[i].type);
        }
  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {
        
        PlayerPrefs.DeleteKey("HouseX_0");
        PlayerPrefs.DeleteKey("HouseY_0");

        PlayerPrefs.DeleteKey("FirstExecutionDone");
    }
}
