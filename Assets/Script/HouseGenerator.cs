using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HouseGenerator : MonoBehaviour
{

    public House[] HouseArray = new House[5];
    public GameObject HousePrefab;
    GraphManager graphManager;
    

    public House MakeHouse (int index, int size, House[] HouseArray){

        int x = -1, y = -1, type = -1;
        int done = 0;
        while(true){
            
            done = 0;

            x = Random.Range(0, 5);
            y = Random.Range(0, 5);

            type = Random.Range(0, 3);

            
            if(size == 0) {
                House newHouse = new House(); // 기본 생성자 호출
                newHouse.Initialize(index, x, y, type);
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
                    newHouse.Initialize(index, x, y, type);
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
            PlayerPrefs.SetInt("OldHouseX", 5);
            PlayerPrefs.SetInt("OldHouseY", 0);

            for (int i = 0; i < 5; i++) {
                HouseArray[i] = MakeHouse(i, i, HouseArray);
                
                PlayerPrefs.SetInt("HouseINDEX_" + i, HouseArray[i].index);
                PlayerPrefs.SetInt("HouseX_" + i, HouseArray[i].x);
                PlayerPrefs.SetInt("HouseY_" + i, HouseArray[i].y);
                PlayerPrefs.SetInt("HouseType_" + i, HouseArray[i].type);
                PlayerPrefs.SetInt("HouseSelected_" + i, HouseArray[i].selected);
            }   
               
            //Debug.Log("House 초기화");
            PlayerPrefs.SetInt("FirstExecutionDone", 1); // 첫 실행 완료 상태 저장
            graphManager = GetComponent<GraphManager>();
            graphManager.makeHouseTree();
            PlayerPrefs.Save(); // 저장
        }

        else{
        // PlayerPrefs에서 값 로드
            for (int i = 0; i < 5; i++) {
                
                int index = PlayerPrefs.GetInt("HouseINDEX_" + i);
                int x = PlayerPrefs.GetInt("HouseX_" + i);
                int y = PlayerPrefs.GetInt("HouseY_" + i);
                int type = PlayerPrefs.GetInt("HouseType_" + i);
                HouseArray[i] = new House(); 
                HouseArray[i].Initialize(index, x, y, type);
                HouseArray[i].selected = PlayerPrefs.GetInt("HouseSelected_" + i);

            }
            //Debug.Log("House 불러오기 완료");

        }

        for(int i = 0; i < 5; i++) {
            
            GameObject house = Instantiate(HousePrefab);
            House houseScript = house.GetComponent<House>();

            
            if(PlayerPrefs.GetInt("HouseSelected_" + i) == 1){
                houseScript.Img_Renderer.sprite = houseScript.offImage;
            }
            else{
                houseScript.Img_Renderer.sprite = houseScript.onImage;
            }
            houseScript.index = HouseArray[i].index;
            houseScript.x = HouseArray[i].x;  
            houseScript.y = HouseArray[i].y;  
            houseScript.type = HouseArray[i].type;
            houseScript.selected = HouseArray[i].selected;
            house.transform.position = new Vector3((float)(-2.3 + 1.9 * (HouseArray[i].x - 2)), (float)(1.4 * (HouseArray[i].y - 2)), 0);
            //Debug.Log(HouseArray[i].index + " " + HouseArray[i].x + " " + HouseArray[i].y + " " + HouseArray[i].selected);
        }

        Debug.Log("트리 계산 결과 " + PlayerPrefs.GetInt("ShortestDistance"));
        //PlayerPrefs.SetInt("ShortestDistance", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnApplicationQuit()
    {   
        PlayerPrefs.DeleteKey("HouseSelected_0");
        PlayerPrefs.DeleteKey("HouseINDEX_0");
        PlayerPrefs.DeleteKey("HouseX_0");
        PlayerPrefs.DeleteKey("HouseY_0");

        PlayerPrefs.DeleteKey("FirstExecutionDone");
    }
}
