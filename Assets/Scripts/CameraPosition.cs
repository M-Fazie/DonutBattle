using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform[] target;
    public float smoothSpeed = 0.01f;
    //public Vector3 offset;
    private int index=0;
    private void Start()
    {
        
    }
    void Update()
    {
        if (!target[index].gameObject.activeInHierarchy)
        { 
            if (index < target.Length)
            {
                index++;
            }
        }
        Vector3 desiredPosition = target[index].position;
        //Debug.Log("index of target "+target[index].position+"  index : "+ index);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
