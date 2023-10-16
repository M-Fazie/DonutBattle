using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int speed = 5;
    
    void Update()
    {
        transform.Rotate(0,0, 5 * speed *Time.deltaTime);
    
    }
}
