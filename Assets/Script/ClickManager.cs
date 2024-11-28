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
      
      if(SceneManager.GetActiveScene().name == "Main"){
         if(gameObject.name == "startButton")
            SceneManager.LoadScene("Map");

         if(gameObject.name == "HowToPlayButton")
            SceneManager.LoadScene("HowToPlay");
      }
      
      else if(SceneManager.GetActiveScene().name == "HowToPlay"){
         SceneManager.LoadScene("Main");
      }

      else if(SceneManager.GetActiveScene().name == "House"){
         
         if(PlayerPrefs.GetInt("HouseCount") == 3){
            
            SceneManager.LoadScene("Ending");
         }
            
         else SceneManager.LoadScene("Map");
      }

      else if(SceneManager.GetActiveScene().name == "Ending"){
         SceneManager.LoadScene("Main");
      }

      else if(SceneManager.GetActiveScene().name == "GameOver"){
         SceneManager.LoadScene("Main");
      }
                 
   }

   void OnMouseEnter(){
     Img_Renderer.sprite = onImage;
   }

   void OnMouseExit(){
      Img_Renderer.sprite = offImage;
   }
}
