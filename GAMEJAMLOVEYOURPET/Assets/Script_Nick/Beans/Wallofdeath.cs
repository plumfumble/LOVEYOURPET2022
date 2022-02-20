using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Wallofdeath : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(scoremanager.score);
        PetSave.pet.plantstat += scoremanager.score;
        PetSave.pet.expstat += scoremanager.score;
        Debug.Log(scoremanager.score);
        Debug.Log("WOD] " + PetSave.pet.plantstat);
        SceneManager.LoadScene("Main Menu");
    }
}
