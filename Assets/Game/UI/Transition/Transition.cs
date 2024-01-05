using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    private Animator animator;
    private string fadeInAnimation = "FadeIn";
    private string fadeOutAnimation = "FadeOut";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeIn(float speed = 1, float delaySeconds = 0)
    {
        StartCoroutine(PlayAnimation(speed, delaySeconds, fadeInAnimation));
    }

    public void FadeOut(float speed = 1, float delaySeconds = 0)
    {
        StartCoroutine(PlayAnimation(speed, delaySeconds, fadeOutAnimation));
    }
    

    private IEnumerator PlayAnimation(float speed, float delaySeconds, string animation)
    {
        yield return new WaitForSeconds(delaySeconds);

        //animator.speed = speed;
        animator.Play(animation);
    }
}
