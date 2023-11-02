using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPosition : MonoBehaviour
{
    public Transform[] target;
    public float smoothSpeed = 0.01f;
    private int temp;
    private float sizeincrement=5f;
    public bool isoutside=false,isInSide=false;
    //public Vector2 minP = new Vector2(-18f, 18f);
    //public Vector2 maxP = new Vector2(18f, -18f);
    private Vector3 sum;
    float[] distance = new float[5];
    private void Start()
    {
        
    }
    void Update()
    {
        
        
        for (int i=1;i<target.Length;i++)
        {
            distance[i] = Vector3.Distance(target[i].position, Vector3.zero);
            if (target[i].gameObject.activeInHierarchy)
            {
                
                if (distance[i] >= 5f)
                {
                    temp = i;
                    isoutside = true;
                    
                }
                else
                {
                    if (i == temp)
                    {
                        isInSide = true;
                    }
                }
                Debug.Log(distance + "  distance " + "  is out side  "+ isoutside + "  is in side "+ isInSide);
                sum += target[i].position;
            }
            else
            {
                float dis = Vector3.Distance(target[i].position, Vector3.zero);
                if (distance[i] <= 5f && temp==i)
                {
                    isInSide = true;
                }
                target[i].position = Vector3.zero;                
            }
        }
        Vector3 midpoint = sum / target.Length;
        sum = Vector3.zero;      
        Vector3 desiredPosition = midpoint;
        //Vector3 desiredPosition = target[index].position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        if (isoutside)
        { 
            if (sizeincrement <= 8f)
            {
                isInSide = false;
                sizeincrement = sizeincrement + Time.deltaTime;
            }
            else
            {
                isoutside = false;
            }
        }
        if (isInSide)
        {                
            if (sizeincrement >= 5f)
            {
                isoutside = false;
                sizeincrement = sizeincrement - Time.deltaTime;
            }
            else
            {
                isInSide = false;
            }                
        }
        gameObject.GetComponent<Camera>().orthographicSize = sizeincrement;
        
    }
    
}


//time = time + Time.deltaTime;
//foreach (Transform t in target)
//{
//    if (t.gameObject.activeInHierarchy)
//    {
//        //t.position - Vector3.zero;       
//        //Debug.Log(distance + "  distance ");
//        p += t.position;
//        Debug.Log(t.position + " transform");
//    }
//}

//if (!target[index].gameObject.activeInHierarchy || time >=4f )
//{ 
//iszoomOut = true;
//time=0;
//if (index-1 < target.Length)
//{
//    index++;
//    if (index == 5)
//    {
//        index = 1;
//    }
//}
//}
//if (target[index].position.x < minP.x || target[index].position.x > maxP.x|| target[index].position.y > minP.y || target[index].position.y < maxP.y)
//{

//isoutside = true;
//if (index - 1 < target.Length)
//{
//    index++;
//    if (index == 5)
//    {
//        index = 1;
//    }
//}
//Debug.Log( "index value "+index+ "  target[index].position.x  "+ target[index].position.x  + "    "+ target[index].position.y);
//}