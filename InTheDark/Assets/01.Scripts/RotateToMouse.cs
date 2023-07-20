using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField] float rotCamXAxisSpeed = 5f; // ī�޶� x�� ȸ���ӵ�
    [SerializeField] float rotCamYAxisSpeed = 3f; // ī�޶� y�� ȸ���ӵ�

    float limitMinX = -80f; // ī�޶� x�� ȸ������ (�ּ�)
    float limitMaxX = 50f;  // ī�޶� x�� ȸ������ (�ִ�)

    float eulerAngleX; // ���콺 �� / �� �̵����� ī�޶� y�� ȸ��
    float eulerAngleY; // ���콺 �� / �Ʒ� �̵����� ī�޶� x�� ȸ��

    public void CalculateRotation(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * rotCamYAxisSpeed;
        eulerAngleX -= mouseY * rotCamYAxisSpeed;
        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);
        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }

    // ī�޶� x�� ȸ���� ��� ȸ�� ������ ����
    float ClampAngle(float angle, float min, float max)
    {
        if(angle < -360)
        {
            angle += 360;
        }

        if(angle > 360)
        {
            angle -= 360;
        }

        return Mathf.Clamp(angle, min, max);
    }

}
