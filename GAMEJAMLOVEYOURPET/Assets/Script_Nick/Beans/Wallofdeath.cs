using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Wallofdeath : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
            //lose
        
        SceneManager.LoadScene("Main Menu");
    }
}
