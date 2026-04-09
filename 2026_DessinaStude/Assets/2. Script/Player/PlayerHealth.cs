using UnityEngine;

/// <summary>
/// === | 플레이어 HP | ===
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// | public | ====================
    /// </summary>
    
    public int maxHp = 10;
    public int currentHp;

    public bool isDead = false;

    /// <summary>
    /// | private | ====================
    /// </summary>

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    /// <summary>
    /// === | 플레이어가 받는 데미지 | ===
    /// </summary>
    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHp -= damage;

        if (currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }

        Debug.Log("Player HP : " + currentHp);

    }

    /// <summary>
    /// === | 플레이어 HP = 0일때 | ===
    /// </summary>
    public void Die()
    {
        isDead = true;
        Debug.Log("Game Over");
    }

}
