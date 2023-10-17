using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int RotationSpeed = 20;
    [SerializeField] private int Dir=+1;
    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField]private Transform targetObject;
    [SerializeField] private int movingSpeed;

    public void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Rotate(0,0, Dir*5 * RotationSpeed *Time.deltaTime);
        
    }
    public void mouseclick()
    {
        Vector3 direction = targetObject.position - transform.position;
        direction.Normalize();
        rb.AddForce(direction*movingSpeed);
        //transform.position= Vector2.MoveTowards(transform.position,targetObject.position,movingSpeed*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(Dir==+1)
        {
            Dir = -1;
        }
        else
        {
            Dir = +1;
        }
    }
    private void OnTriggerExit2D()
    {
        anim.SetBool("Danger", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="SafeZone")
        {
            anim.SetBool("Danger", false);
        }
    }
    public void Dead()
    {
        this.gameObject.SetActive(false);
    }
}
