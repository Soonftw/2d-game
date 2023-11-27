using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife2 : MonoBehaviour
{

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("hej");
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("Spikes")){
            Die();
        }
    }

    private void Die(){
        anim.SetTrigger("death");
    }

}
