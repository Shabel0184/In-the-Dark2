using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecracker : MonoBehaviour
{
    public GameObject fire;
    public ParticleSystem particle;

    public Transform cam;


    public float throwForce = 10f; //던지는 힘
    public float throwTorque = 3f;// 던지는 높이

    public float throwdown = 0.1f; //던져진 힘 줄임

    bool throwready; //던질 수 있는지 확인
    Rigidbody rb;


    private void OnEnable()
    {
        cam = GameManager.instance.camPos;

        transform.position = cam.position;
        transform.rotation = cam.rotation;
    }
    private void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        throwready = true;
        rb = GetComponent<Rigidbody>();
        if (!particle.isPlaying)
        {
            transform.position = cam.position;
            transform.rotation = cam.rotation;
            particle.Play();
            Throw();
        }
        Destroy(this.gameObject,9f);

    }
   
    void Throw()
    {
        throwready = false;

        //던질 오브젝트 생성
        //GameObject firecracker = Instantiate(fire,player.position,cam.rotation);

        //보고있는 방향으로 던지기
        Vector3 force = (cam.transform.forward * throwForce) + (transform.up * throwTorque);
        rb.AddForce(force, ForceMode.Impulse);

        Invoke(nameof(ResetThrow), throwdown);

    }
    void ResetThrow()
    {
        throwready = true;
    }

   

}
