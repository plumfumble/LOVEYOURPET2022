using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallofdeath : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
            //lose
            Debug.Log("you lose");
    }
}
