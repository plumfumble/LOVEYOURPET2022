using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatchBall : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] List<AudioClip> catchSounds;
    [SerializeField] AudioClip fallSound;
    [SerializeField] Transform playerHandTarget;
    [SerializeField] Transform petTarget;

    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOJump(playerHandTarget.position, 6, 1, speed).SetEase(Ease.InQuad).SetId(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public IEnumerator ThrowBack()
    {
        yield return new WaitForSeconds(0.3f);
        transform.DOJump(petTarget.position, 6, 1, speed).SetEase(Ease.InQuad);
        yield return new WaitForSeconds(speed);
        PlayCatchSound();
        speed -= 0.1f;
        speed = Mathf.Clamp(speed, 0.4f, 2f);
        transform.DOJump(playerHandTarget.position, 6, 1, speed).SetEase(Ease.InQuad).SetId(0);
    }

    public void PlayCatchSound()
    {
        audio.PlayOneShot(catchSounds[Random.Range(0, catchSounds.Count)]);
    }

    public void PlayFallSound()
    {
        audio.PlayOneShot(fallSound);
    }
}
