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
        
        if (collision.tag == "Player")
        {
            this.GetComponent<Renderer>().enabled = false;
            firescoremanager.score++;
            FireworkPlayerControl.numberOfFireworks++;
            Debug.Log(firescoremanager.score);
        }
    }
}

