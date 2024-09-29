using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 7f; // ���D�O���j�p
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // �������ե�
    }

    void Update()
    {
        // ���U�Ů���åB����b�a���W�ɸ��D
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // �[�O�Ӹ��D
        isGrounded = false; // ���D��Ȯɳ]���D���a���A
    }

    // �I���˴��H�T�{����O�_���a
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // ��P�a���I���ɫ�_�i���D���A
        }
    }
}
