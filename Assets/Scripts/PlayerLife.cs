using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioSource deathSoundEffect;

    private Animator anim;

    private Rigidbody2D rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Spawn();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if((collision.gameObject.CompareTag("Spikes")) || (collision.gameObject.CompareTag("Saw") || (collision.gameObject.CompareTag("Death")))){
            Die();
        }
    }

    private void Spawn(){
        anim.SetTrigger("live");
    }

    private void Die(){
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }




    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
