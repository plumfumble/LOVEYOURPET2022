using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanPlayer : MonoBehaviour
{

    public float velocity = 5f;
    private Rigidbody2D rigidbody;
    [SerializeField]
    private Camera mainCamera;
    public bool losing;
    public bool mousenotin;

    // Start is called before the first frame update
    void Start()
    {

        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;
        
            //float control = mousePos.x / 100;
            //transform.position = transform.position + new Vector3(control * velocity * Time.deltaTime, 0, 0);
            //transform.position = Vector3.Lerp(transform.position, mousePos, velocity * Time.deltaTime);
            //Debug.Log(mousePos.x);
            Vector3 mouseWorldPosition = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log(mainCamera.ScreenToViewportPoint(Input.mousePosition));
        float stuff = mouseWorldPosition.x - 0.5f;
        float rythym = stuff * 15f;
        float control = rythym - transform.position.x;
        if (mousenotin == false)
        {
            transform.position = transform.position + new Vector3(control * velocity * Time.deltaTime, 0, 0);
        }
        
        if (0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y)
        {
            mousenotin = true;
        }
        else
        {
            mousenotin = false;
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
            //collision.GetComponent<Renderer>().enabled = false;
            beanscoremanager.score++;
            Debug.Log(beanscoremanager.score);
        }
        else
        {
            losing = true;
            Destroy(gameObject);
        }
    }

}

