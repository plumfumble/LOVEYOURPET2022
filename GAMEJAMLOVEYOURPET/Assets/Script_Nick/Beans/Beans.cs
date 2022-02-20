using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beans : MonoBehaviour
{
    public float speed=3;

    // Update is called once per frame
    void Update()
    {
        transform.position += ((Vector3.down * speed) * Time.deltaTime);   
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
    public void addspeed(float sp)
    {
        speed = sp;
    }
}
