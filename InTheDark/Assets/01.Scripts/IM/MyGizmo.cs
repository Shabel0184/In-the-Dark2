using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color _color = Color.yellow; //기즈모 색상
    public float _radius = 0.1f; //기즈모 사이즈

    private void OnDrawGizmos()
    {
        //사용자가 기즈모 생성할때 사용하는 콜벡 메서드
        Gizmos.color = _color;
        //구모양 기즈모를 만드는데
        //DrawSphere(생성위치, 크기)
        Gizmos.DrawSphere(transform.position, _radius);

    }

    

}
