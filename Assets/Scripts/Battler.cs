using UnityEngine;

public class Battler : MonoBehaviour
{
    [SerializeField] Battler targetBattler;
    [SerializeField] BattlerAnimatorController battlerAnimatorController;
    [SerializeField] HpGuage hpGuage;

    const int MaxHp = 10;
    public int Hp { get; private set; } = MaxHp;
    public float HpRate { get { return (float)Hp / MaxHp; } }

    public bool IsDead { get { return Hp <= 0; } }
    public bool IsAttacking { get; private set; } = false;
    public bool IsDamaging { get; private set; } = false;
    public bool IsGuard { get; private set; } = false;

    public void Damage(Battler attacker, int damage)
    {
        IsGuard = false;
        IsDamaging = true;
        Hp = Mathf.Max(0, Hp - damage);
        hpGuage?.UpdateHpGuage(HpRate);
        if (Hp > 0)
        {
            battlerAnimatorController.StartDamage(() =>
            {
                IsDamaging = false;
            });
        }
        else
        {
            battlerAnimatorController.StartDead();
        }
    }

    public void Attack1()
    {
        if (IsAttacking || IsDead || IsDamaging) return;

        IsAttacking = true;
        battlerAnimatorController.StartAttack1(() =>
        {
            targetBattler.Damage(this, 1);
        }, () =>
        {
            IsAttacking = false;
        });
    }

    public void Attack2()
    {
        if (IsAttacking || IsDamaging) return;

        IsAttacking = true;
        battlerAnimatorController.StartAttack2(() =>
        {
            targetBattler.Damage(this, 2);
        }, () =>
        {
            IsAttacking = false;
        });
    }

    public void StartGuard()
    {
        if (IsAttacking || IsDead || IsDamaging) return;

        IsGuard = true;
        battlerAnimatorController.StartGuard();
    }

    public void EndGuard()
    {
        IsGuard = false;
        battlerAnimatorController.EndGuard();
    }
}
