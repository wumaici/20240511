using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMe : MonoBehaviour
{

    // 定义每分钟在 X、Y、Z 轴上的旋转次数
    [SerializeField] float xRotationsPerMinute = 1f;
    [SerializeField] float yRotationsPerMinute = 1f;
    [SerializeField] float zRotationsPerMinute = 1f;

    void Update()
    {
        // 计算每帧的旋转角度
        float xDegreesPerFrame = xRotationsPerMinute * 360 * Time.deltaTime / 60;
        float yDegreesPerFrame = yRotationsPerMinute * 360 * Time.deltaTime / 60;
        float zDegreesPerFrame = zRotationsPerMinute * 360 * Time.deltaTime / 60;

        // 直接对物体进行自身旋转
        transform.Rotate(xDegreesPerFrame, yDegreesPerFrame, zDegreesPerFrame);
    }
}
