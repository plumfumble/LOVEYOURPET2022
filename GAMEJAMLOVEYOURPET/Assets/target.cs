using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public float speed;
    public bool goleft;
    void Update()
    {
        if (goleft)
            transform.position += ((Vector3.left * speed) * Time.deltaTime);
        else
            transform.position += ((Vector3.right * speed) * Time.deltaTime);

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        this.GetComponent<Renderer>().enabled = false;
        if (collision.tag == "Player")
        {
            firescoremanager.score++;
            Debug.Log(firescoremanager.score);
        }
    }
}

