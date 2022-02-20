using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CatchPlayerController : MonoBehaviour
{
    [SerializeField] CatchBall ball;

    [SerializeField] Transform hand;
    [SerializeField] Transform catchingPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] Transform returnHandPoint;

    [SerializeField] float missCloseDistance;
    [SerializeField] float amazingCatchDistance;
    [SerializeField] float goodCatchDistance;
    [SerializeField] float missDistance;

    int goodCatches = 0;
    int amazingCatches = 0;
    float duration;
    bool catching;
    bool ending;
    bool canCatchAttempt = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(ball.transform.position, catchingPoint.position);
        if (dist > missCloseDistance && dist < goodCatchDistance)
        {
            catching = true;
        }
        else
        {
            catching = false;
        }

        if (Input.GetButtonDown("Fire1") && canCatchAttempt)
        {            
            if (dist < missDistance)
            {
                Debug.Log("dist: " + dist + " amazingCatchDistance: " + amazingCatchDistance + " goodCatchDistance: " + goodCatchDistance);
                if (dist < missCloseDistance)
                {
                    Debug.Log("Miss...");
                }
                else if (dist < amazingCatchDistance)
                {
                    //Debug.Log("Amazing Catch!");
                    amazingCatches++;
                }
                else if (dist < goodCatchDistance)
                {
                    Debug.Log("Good Catch");
                    goodCatches++;
                }
                else
                {
                    Debug.Log("Miss...");
                }
            }

            var sequence = DOTween.Sequence();
            sequence.Append(hand.DOMove(catchingPoint.position, 0.25f));
            canCatchAttempt = false;
            if (catching)
            {
                DOTween.Kill(0);
                ball.transform.DOMove(catchingPoint.position, 0.25f);
                ball.PlayCatchSound();
                StartCoroutine(ball.ThrowBack());
                sequence.Append(hand.DOMove(catchingPoint.position, 0.05f));
                sequence.Append(hand.DOMove(returnHandPoint.position, 0.15f));
                catching = false;
                canCatchAttempt = true;
            }
            else
            {
                float penalty = 1f;
                sequence.Append(hand.DOMove(returnHandPoint.position, penalty));
                StartCoroutine(PauseCatching(penalty));
            }
        }
        
        if (Vector3.Distance(ball.transform.position, endPoint.position) <= 1)
        {
            if (!ending)
            {
                ball.PlayFallSound();
                // Game Over
                int addValue = (amazingCatches * 3) + (int)(goodCatches * 1.5f);
                Debug.Log("Amazing Catches: " + amazingCatches + "/ Good Catches: " + goodCatches + "/ Increase Happiness by: " + addValue);
                ending = true;
                StartCoroutine(ReturnHome(1.5f));
                PetSave.pet.happiness += addValue;
            }
        }
    }

    IEnumerator PauseCatching(float duration)
    {
        yield return new WaitForSeconds(duration);
        canCatchAttempt = true;
    }
    void FixedUpdate()
    {
        duration += Time.deltaTime;
    }

    IEnumerator ReturnHome(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene("Main Menu");        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(catchingPoint.position, amazingCatchDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(catchingPoint.position, goodCatchDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(catchingPoint.position, missDistance);

        Gizmos.DrawWireSphere(endPoint.position, 1);
    }
}
