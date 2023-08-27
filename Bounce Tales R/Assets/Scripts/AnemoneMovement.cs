using UnityEngine;

public class AnemoneAnimation : MonoBehaviour
{
    public Animator animator;
    public float animationChangeInterval = 3.0f;

    private float animationTimer;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animationTimer = Random.Range(0.0f, animationChangeInterval);
    }

    private void Update()
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0)
        {
            ChooseRandomAnimation();
            animationTimer = animationChangeInterval;
        }
    }

    private void ChooseRandomAnimation()
    {
        int randomAnimationIndex = Random.Range(0, animator.runtimeAnimatorController.animationClips.Length);
        animator.Play(animator.runtimeAnimatorController.animationClips[randomAnimationIndex].name);
    }
}
