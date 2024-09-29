using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // ���ʳt��
    public float rotationSpeed = 100f; // ����t��

    void Update()
    {
        // �e�i�M��h
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // ����M�k��
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
