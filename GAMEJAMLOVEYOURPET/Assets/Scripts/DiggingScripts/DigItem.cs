using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DigItem : MonoBehaviour
{
    [SerializeField] SpriteRenderer sr;
    public event Action OnClick;
    public event Action OnMissed;
    float speed;
    float lifetime = .25f;
    Tweener scaling; 
    void Update()
    {
        if (lifetime < 0)
        {
            if (!sr.isVisible)
            {
                //scaling.Kill();
                DOTween.Kill(transform.gameObject);
                OnMissed?.Invoke();
                Destroy(this.gameObject);
            }
        }

    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        scaling = sr.transform.DOScale(new Vector3(15, 15, 1), 1.5f).SetId(transform.gameObject);
        lifetime -= Time.deltaTime;
    }

    void OnMouseDown()
    {
        DOTween.Kill(transform.gameObject);
        OnClick?.Invoke();
        Destroy(this.gameObject);
    }

    public void SetStats(float speed, float lifetime)
    {
        this.speed = speed;
        //this.lifetime = lifetime;
    }
}
