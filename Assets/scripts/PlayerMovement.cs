using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // 移動速度
    public float rotationSpeed = 100f; // 旋轉速度

    void Update()
    {
        // 前進和後退
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // 左轉和右轉
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
