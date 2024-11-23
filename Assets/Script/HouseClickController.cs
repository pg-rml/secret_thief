using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HouseClickController : MonoBehaviour
{
    House house;    

    void Start(){
        // house = GetComponent<House>();
    }

    // Start is called before the first frame update
    void OnMouseDown(){

        house = GetComponent<House>();

        if(house.selected == 0){
            //Debug.Log(house.index);
            house.HouseSelected();
        }
        
    }
}
