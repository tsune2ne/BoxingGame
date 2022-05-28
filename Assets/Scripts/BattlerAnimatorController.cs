using System;
using System.Threading.Tasks;
using UnityEngine;

public class BattlerAnimatorController : MonoBehaviour
{
    [SerializeField] Animator animator;
    Action onHitted, onFinshed;

    public void StartAttack1(Action onHitted, Action onFinished)
    {
        animator.SetTrigger("Attack1Trigger");
        DelayAction(200, onHitted);
        DelayAction(700, onFinished);
    }

    public void StartAttack2(Action onHitted, Action onFinished)
    {
        animator.SetTrigger("Attack2Trigger");
        DelayAction(1500, onHitted);
        DelayAction(2000, onFinished);
    }

    public void StartGuard()
    {
        animator.SetBool("IsGuard", true);
    }

    public void EndGuard()
    {
        animator.SetBool("IsGuard", false);
    }

    public void StartDamage(Action onFinished)
    {
        animator.SetTrigger("DamageTrigger");
        DelayAction(500, onFinished);
    }

    public void StartDead()
    {
        animator.SetTrigger("DeadTrigger");
    }

    public void OnHitted()
    {
        onHitted?.Invoke();
    }

    public void OnFinished()
    {
        onFinshed?.Invoke();
    }

    async void DelayAction(int waitMiliSeconds, Action onFinished)
    {
        await Task.Delay(waitMiliSeconds);
        onFinished?.Invoke();
    }
}
