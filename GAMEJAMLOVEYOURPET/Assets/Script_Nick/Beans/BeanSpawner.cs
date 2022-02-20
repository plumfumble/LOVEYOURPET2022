using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSpawner : MonoBehaviour
{
    public float queueTime = 1.5f;
    private float time = 0;
    public GameObject obstacle;
    public float launchrate = 1f;
    float speed = 3;
    float i;

    public float width;

    // Update is called once per frame
    void Update()
    {
        if (time > queueTime)
        {
            queueTime = Random.Range(launchrate / 2, launchrate * 2);
            GameObject go = Instantiate(obstacle);
            go.transform.position = transform.position + new Vector3(Random.Range(-width, width), 0, 0);

            time = 0;
            i = Time.deltaTime * 10f;
            speed = speed + i;
            go.GetComponent<Beans>().addspeed(speed);
            Destroy(go, 10);
        }

        time += Time.deltaTime;
    }
}
