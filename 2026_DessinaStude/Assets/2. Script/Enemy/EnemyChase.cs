using UnityEngine;

/// <summary>
/// === | 적 AI | ===
/// </summary>
public class EnemyChase : MonoBehaviour
{
    /// <summary>
    /// | public | ====================
    /// </summary>
    
    public float moveSpeed = 2f;

    /// <summary>
    /// | private | ====================
    /// </summary>
    
    private Transform target;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player"); ///플레이어 태그를 찾음

        if(player != null)
        {
            target = player.transform; //타겟은 player 태그를 가지고있는 오브젝트 위치를 저장
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) return;

        Vector3 direction = target.position - transform.position; // 타겟의 위치 - 내 위치 = 플레이어의 위치.
        direction.y = 0f; //위로 올라가지 않음

        Vector3 moveDir = direction.normalized; //대각선 보장

        transform.position += moveDir * moveSpeed * Time.deltaTime; //이동속도 값.

        if(moveDir != Vector3.zero) //만약 이동 없으면?
        {
            transform.forward = moveDir; //정면을 봄
        }
    }
}
