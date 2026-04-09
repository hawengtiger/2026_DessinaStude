using UnityEngine;

/// <summary>
/// === | 카메라 움직임 | ===
/// </summary>
public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// | public | ====================
    /// </summary>

    public Transform target;        // 카메라가 따라갈 대상
    public Vector3 offset = new Vector3(0f, 12f, - 8f);

    /// <summary>
    /// | private | ====================
    /// </summary>
    
    private void LateUpdate()       //플레이어가 움직인 다음에 카메라 무빙이 있어야 하기 때문에 (LateUpdate 사용.)
    {
        if (target == null) return;     //target이 널일경우 반환함.

        transform.position = target.position + offset; //카메라위치는 (대상 + 떨어진정도)를 불러옴
    }

}
