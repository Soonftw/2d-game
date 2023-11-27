using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private int points = 0;



    // [Header("Text")]
    [SerializeField] private TextMeshProUGUI cherriesText;

    // [Header("Audio")]
    // [SerializeField] private AudioSource collectSoundEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry")){
            // collectSoundEffect.Play();
            points ++;
            Debug.Log(points);
            Destroy(collision.gameObject);
            cherriesText.text = "Cherries: " + points;
        }   

    }

    


}
