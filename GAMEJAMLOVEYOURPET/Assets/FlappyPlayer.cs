using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlayer : MonoBehaviour
{

    public float velocity = 2.4f;
    private Rigidbody2D rigidbody;
 
    public bool losing;

    // Start is called before the first frame update
    void Start()
    {
        
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        losing = true;
        Destroy(gameObject);//lose game
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            scoremanager.score++;
            Debug.Log(scoremanager.score);
        }
        else
        {
            losing = true;
            Destroy(gameObject);
        }
    }

    }

