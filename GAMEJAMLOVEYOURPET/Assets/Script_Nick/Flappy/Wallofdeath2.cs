using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Wallofdeath2 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            PetSave.pet.flystat += flappyscoremanager.score;
            PetSave.pet.expstat += flappyscoremanager.score;


            SceneManager.LoadScene("Main Menu");
        }
            
    }
}
