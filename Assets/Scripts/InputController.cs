using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] Battler playerBattler;
    [SerializeField] Battler enemyBattler;

    private void Update()
    {
#if DEBUG
        if (Input.GetKeyDown(KeyCode.Z)) enemyBattler.Attack1();
        if (Input.GetKeyDown(KeyCode.X)) enemyBattler.Attack2();
        if (Input.GetKeyDown(KeyCode.G)) enemyBattler.StartGuard();
        if (Input.GetKeyUp(KeyCode.G)) enemyBattler.EndGuard();
#endif
    }

    public void Attack1()
    {
        playerBattler.Attack1();
    }

    public void Attack2()
    {
        playerBattler.Attack2();
    }

    public void StartGuard()
    {
        playerBattler.StartGuard();
    }

    public void EndGuard()
    {
        playerBattler.EndGuard();
    }
}
