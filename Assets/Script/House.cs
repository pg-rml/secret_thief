using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class House : MonoBehaviour
{
    
    public int index;
    public int x;
    public int y;
    public int type;

    public int selected;

    public SpriteRenderer Img_Renderer;
    public Sprite offImage;
    public Sprite onImage;

    public void Initialize(int index, int x, int y, int type)
    {   
        this.index = index;
        this.x = x;
        this.y = y;
        this.type = type;
        this.selected = 0;
        
    }

    public void HouseSelected(){
        this.selected = 1;
        PlayerPrefs.SetInt("HouseSelected_" + this.index, this.selected);
        
        int oldHouseX = PlayerPrefs.GetInt("OldHouseX");
        int oldHouseY = PlayerPrefs.GetInt("OldHouseY");

        int calX = 0;
        int calY = 0;

        if(oldHouseX > x){
            calX = oldHouseX - x;
        }
        else{
            calX = x - oldHouseX;
        } 

        if(oldHouseY > y){
            calY = oldHouseY - y;
        }
        else{
            calY = y - oldHouseY;
        }    

        int PlayerDistance = PlayerPrefs.GetInt("PlayerDistance") + (calX + calY);
        PlayerPrefs.SetInt("PlayerDistance", PlayerDistance);

        Debug.Log("이동 거리 갱신 " + PlayerPrefs.GetInt("PlayerDistance"));

        PlayerPrefs.SetInt("OldHouseX", x);
        PlayerPrefs.SetInt("OldHouseY", y);

        int HouseCount = PlayerPrefs.GetInt("HouseCount") + 1;
        PlayerPrefs.SetInt("HouseCount", HouseCount);
        PlayerPrefs.Save();
        SceneManager.LoadScene("House");
    }
    
}

