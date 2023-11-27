using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("hej")
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }
}
