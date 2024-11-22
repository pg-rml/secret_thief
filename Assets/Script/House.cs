using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    
    public int x;
    public int y;
    public int type;


    public void Initialize(int x, int y, int type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }
}

