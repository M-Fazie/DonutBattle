using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public Transform rayDir;
    public float raycastDistance = 5f;
    void Start()
    {
        
    }
    private void Update()
    {
        
        Vector2 rayDirection = rayDir.position; 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, raycastDistance);
        Debug.DrawRay(transform.position, rayDirection, Color.yellow);
        if (hit.collider != null)
        {
            
            Debug.Log("Raycast hit " + hit.transform.name);

           
        }
    }

}
