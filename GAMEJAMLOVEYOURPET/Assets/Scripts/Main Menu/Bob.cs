using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bob : MonoBehaviour
{
    public float maxyPos;
    public float minyPos;
    public float secondsToBob = 1;

    void Start()
    {
        StartCoroutine(BobCo());
    }

    private IEnumerator BobCo()
    {
        transform.DOMoveY(maxyPos, secondsToBob).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(secondsToBob);
        transform.DOMoveY(minyPos, secondsToBob).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(secondsToBob);
        StartCoroutine(BobCo());
    }
}