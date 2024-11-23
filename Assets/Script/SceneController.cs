using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{   
    public void OnMouseDown(){
        
        Debug.Log("눌림");
        SceneManager.LoadScene("House");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
