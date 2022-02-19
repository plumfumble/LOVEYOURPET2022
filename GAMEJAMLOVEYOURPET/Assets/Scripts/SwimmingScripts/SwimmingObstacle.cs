using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingObstacle : MonoBehaviour
{
    [SerializeField] float existanceDuration;
    float speed;  

    void Update()
    {
        if (existanceDuration < 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        existanceDuration -= Time.deltaTime;
    }

    public void SetStats(float speed)
    {
        this.speed = speed;
    }
    
}
