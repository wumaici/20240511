using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 7f; // 跳躍力的大小
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 獲取剛體組件
    }

    void Update()
    {
        // 按下空格鍵並且角色在地面上時跳躍
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // 加力來跳躍
        isGrounded = false; // 跳躍後暫時設為非落地狀態
    }

    // 碰撞檢測以確認角色是否落地
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // 當與地面碰撞時恢復可跳躍狀態
        }
    }
}
