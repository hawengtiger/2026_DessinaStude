using UnityEngine;

/// <summary>
/// === | 적 데미지 | ===
/// </summary>
public class EnemyDamage : MonoBehaviour
{
    /// <summary>
    /// | public | ====================
    /// </summary>

    public int damage = 1;      //데미지
    public float attackInterval = 1f;   //몇초마다 데미지를 줄지 정하기

    public float attackTimer = 0f;      //누적 시간

    /// <summary>
    /// | private | ====================
    /// </summary>

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player")) return;        //맞은 대상이 플레이어가 아니면 반환 함.

        if (attackTimer < attackInterval) return;       //누적시간이 공격쿨타임보다 작으면 반환 함.

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();     //PlayerHealth를 가져옴.

        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);        //PlayerHealth에 있는 TakeDamage를 사용.
            attackTimer = 0f;
        }
    }
}
