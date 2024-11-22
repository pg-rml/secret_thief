using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer Img_Renderer;
    public Sprite offImage;
    public Sprite onImage;
    
    // Start is called before the first frame update
    void OnMouseDown(){
        // ㅇㅇㅇ
        SceneManager.LoadScene("Map");
                 
    }

     void OnMouseEnter(){
        Img_Renderer.sprite = onImage;
     }

     void OnMouseExit(){
        Img_Renderer.sprite = offImage;
     }
}
