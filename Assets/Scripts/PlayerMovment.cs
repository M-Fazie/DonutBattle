using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public int RotationSpeed = 20;
     private int RotationDir=+1;
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
        transform.Rotate(0,0, RotationDir*5 * RotationSpeed *Time.deltaTime);
        PlayerPrefs.SetInt("movingSpeed", movingSpeed);
    }
    public void mouseclick()
    {
        Vector3 direction = targetObject.position - transform.position;
        rb.AddForce(direction*movingSpeed,ForceMode2D.Impulse);
        //Debug.Log("speed "+direction * movingSpeed / 5);
        //transform.position= Vector2.MoveTowards(transform.position,targetObject.position,movingSpeed*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(RotationDir ==+1)
        {
            RotationDir = -1;
        }
        else
        {
            RotationDir = +1;
        }
        if(collision.gameObject.tag=="Danger")
        {

            Dead();
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
        PlayerPrefs.SetInt("IsPlayerDead", 1);
        PlayerPrefs.SetString("PlayerName", gameObject.name);
        {
            Debug.Log("player 1 dead  !!!!!!!!!!!!!!1" + gameObject.name);
        }
        this.gameObject.SetActive(false);
    }
}
