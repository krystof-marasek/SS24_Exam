using UnityEngine;

public class SignalAnimationOnCat : MonoBehaviour
{
    public Animator animator;
    
    public void IdleCat()
    {
        animator.SetInteger("AnimationInt", 2);
    }

    public void WalkingCat()
    {
        animator.SetInteger("AnimationInt", 3);
    }

    public void RunnigCat()
    {
        animator.SetInteger("AnimationInt", 4);
    }

    public void JumpingCat()
    {
        animator.SetInteger("AnimationInt", 5);
    }

    public void GreetingCat()
    {
        animator.SetInteger("AnimationInt", 6);
    }
}
