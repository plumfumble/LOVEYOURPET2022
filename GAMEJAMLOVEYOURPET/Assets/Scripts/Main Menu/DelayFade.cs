using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DelayFade : MonoBehaviour
{
    [SerializeField] float secondsToStayOpaque;
    [SerializeField] float secondsToFade;

    void Start()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(secondsToStayOpaque);
        GetComponent<Image>().DOFade(0, secondsToFade);
        yield return new WaitForSeconds(secondsToFade);
        Destroy(gameObject);
    }
}
