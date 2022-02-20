using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Wallofdeath1 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        //lose


            PetSave.pet.firestat += firescoremanager.score;
            PetSave.pet.expstat += firescoremanager.score;

        SceneManager.LoadScene("Main Menu");
    }
}
