using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkPlayerControl : MonoBehaviour
{
    readonly Vector3 offset = new Vector3(30000, 3800, 0);

    [SerializeField] GameObject fireworkPrefab;

    float angle;
    int numberOfFireworks;

    void Start()
    {
        numberOfFireworks = 5;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 object_pos = Camera.main.ScreenToWorldPoint(transform.localPosition);
        Debug.Log("mousePos = " + mousePos + "/ object_pos = " + object_pos);
        //mousePos -= offset;
        mousePos.x = mousePos.x - object_pos.x;
        mousePos.y = mousePos.y - object_pos.y;
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        Debug.Log("angle = " + angle);
        // clamping
        if (angle < 10f && angle > -90f) angle = 10f;
        else if (angle > 170f || angle < -90f) angle = 170f;

        // Set angle
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Firing");
            if (numberOfFireworks > 0)
            {
                ShootFirework();
            }
        }
    }

    void ShootFirework()
    {
        Instantiate(fireworkPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)));
        numberOfFireworks--;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Gizmos.DrawSphere(mousePos, 2);

        Gizmos.color = Color.green;

        Vector3 object_pos = Camera.main.ScreenToWorldPoint(transform.localPosition);
        mousePos.x = mousePos.x - object_pos.x;
        mousePos.y = mousePos.y - object_pos.y;

        Gizmos.DrawLine(object_pos, mousePos);
        //angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

    }
}
