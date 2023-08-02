using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecracker : MonoBehaviour
{
    public GameObject fire;
    public ParticleSystem particle;

    public Transform cam;


    public float throwForce = 10f; //������ ��
    public float throwTorque = 3f;// ������ ����

    public float throwdown = 0.1f; //������ �� ����

    bool throwready; //���� �� �ִ��� Ȯ��
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

        //���� ������Ʈ ����
        //GameObject firecracker = Instantiate(fire,player.position,cam.rotation);

        //�����ִ� �������� ������
        Vector3 force = (cam.transform.forward * throwForce) + (transform.up * throwTorque);
        rb.AddForce(force, ForceMode.Impulse);

        Invoke(nameof(ResetThrow), throwdown);

    }
    void ResetThrow()
    {
        throwready = true;
    }

   

}
