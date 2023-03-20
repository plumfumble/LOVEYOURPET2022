using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyPlayer : MonoBehaviour
{

    public float velocity = 2.4f;
    private Rigidbody2D rigidbody;
    private AudioSource bellsource;
    public bool losing;

    public AudioSource flapSound;

    // Start is called before the first frame update
    void Start()
    {
        bellsource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody.velocity = Vector2.up * velocity;
            flapSound.pitch = Random.Range(0.95f, 1.05f);
            flapSound.Play();
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
            bellsource.Play();
            flappyscoremanager.score++;
            Debug.Log(flappyscoremanager.score);
        }
        else
        {
            PetSave.pet.flystat+=flappyscoremanager.score;
            PetSave.pet.expstat += flappyscoremanager.score;
            SceneManager.LoadScene("Main Menu");
            Destroy(gameObject);
        }
    }

    }

