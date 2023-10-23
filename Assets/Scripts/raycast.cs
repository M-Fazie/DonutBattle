using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class raycast : MonoBehaviour
{
    public Transform rayDir;
    public float raycastDistance = 5f;
    public LayerMask layer;
    public Rigidbody2D rb;
    private bool check = true;
    
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {        
        Vector2 rayDirection = rayDir.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, raycastDistance,layer);
        Debug.DrawRay(transform.position,rayDirection, Color.yellow);
        //Debug.DrawLine(transform.position, rayDirection);
        if (hit.collider != null)
        {            
            //Debug.Log("Raycast hit " + hit.transform.name);
            if (hit.collider.gameObject.tag == "Enemy"&& check)
            {               
                 check = false;
                 StartCoroutine(AutoMove());
            }           
        }
    }
    IEnumerator AutoMove()
    {
        //Debug.Log("hi whats up bro");
        int movingSpeed = PlayerPrefs.GetInt("movingSpeed");
        Vector3 direction = rayDir.position - transform.position;        
        rb.AddForce(direction * movingSpeed, ForceMode2D.Impulse);
        //transform.position= Vector2.MoveTowards(transform.position,targetObject.position,movingSpeed*Time.deltaTime);
        yield return new WaitForSeconds(1f);
        check = true;
    }

}
