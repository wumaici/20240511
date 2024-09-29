using UnityEngine;

public class ObjectSnap : MonoBehaviour
{
    // 吸附的目标位置
    public Transform snapTarget;

    // 吸附触发的距离
    public float snapDistance = 1.0f;

    // 移动速度，控制物体吸附的平滑程度
    public float moveSpeed = 5.0f;

    // 旋转速度，控制物体旋转对齐的平滑程度
    public float rotateSpeed = 5.0f;

    // 物体与目标保持的最小距离（设置一个非常小的值）
    public float offsetDistance = 0.01f;

    void Update()
    {
        // 计算物体和目标点之间的距离
        float distance = Vector3.Distance(transform.position, snapTarget.position);

        // 当物体距离目标点小于吸附阈值时，执行吸附操作
        if (distance < snapDistance)
        {
            // 计算物体与目标的方向向量
            Vector3 direction = (transform.position - snapTarget.position).normalized;

            // 计算带有微小缝隙的目标位置
            Vector3 targetPosition = snapTarget.position + direction * offsetDistance;

            // 平滑移动到目标位置，并保持微小的缝隙
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            // 平滑旋转对齐到吸附目标的方向
            transform.rotation = Quaternion.Lerp(transform.rotation, snapTarget.rotation, Time.deltaTime * rotateSpeed);
        }
    }
}
