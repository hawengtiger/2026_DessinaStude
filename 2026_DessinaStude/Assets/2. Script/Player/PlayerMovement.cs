using UnityEngine;

/// <summary>
/// === | 플레이어 움직임 | ===
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// | public | ====================
    /// </summary>

    public float moveSpeed = 5f;    //플레이어 이동속도

    public float minX = -14f;   //플레이어가 움직일 수 있는 범위 (x = -14 ~ 14 && z = -14 ~ 14)
    public float maxX = 14f;    
    public float minZ = -14f;   
    public float maxZ = 14f;

    /// <summary>
    /// | private | ====================
    /// </summary>

    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    /// <summary>
    /// === | 플레이어의 움직임을 담당함. | ===
    /// </summary>
    private void Move()
    {
        if (playerHealth != null && playerHealth.isDead) return;

        float x = Input.GetAxisRaw("Horizontal");   //수평이동 x좌표
        float z = Input.GetAxisRaw("Vertical");     //수직이동 z좌표

        Vector3 movDir = new Vector3(x, 0f, z).normalized;    //플레이어 방향 지정 )=> normalized = 대각선 이동 보정 (1:1:v-2 이슈.)

        Vector3 nextPosition = transform.position + movDir * moveSpeed * Time.deltaTime; //이동속도 값.

        nextPosition.x = Mathf.Clamp(nextPosition.x, minX, maxX); //x좌표의 이동 최소, 최대 범위
        nextPosition.z = Mathf.Clamp(nextPosition.z, minZ, maxZ); //z좌표의 이동 최소, 최대 범위

        transform.position = nextPosition; //이동값을 대입해 플레이어 이동하게만드는 코드

        if (movDir != Vector3.zero)     //움직임이 없을경우 앞을 바라보게끔 (앞바라보면 예쁘자나.)
        {
            transform.forward = movDir;
        }
    }
}