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
        
        PlayerPrefs.SetInt("OldHouseIndex", this.index);
        
        SceneManager.LoadScene("House");
    }
    
}

