using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firecracker : MonoBehaviour
{
    public GameObject fire; 
    public ParticleSystem particle;

    public Transform cam;
    public Transform player;

    public float throwForce = 5f; //������ ��
    public float throwTorque = 10f;// ������ ����

    public int firecount = 8;

    public float throwdown = 0.1f; //������ �� ����

    bool throwready; //���� �� �ִ��� Ȯ��
    Rigidbody rb;


    private void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>();
        throwready = true;
        rb = GetComponent<Rigidbody>();
        
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&throwready)
        {
            if (!particle.isPlaying)
            {
                particle.Play();
                Throw();
            }
            
        }
    }
    void Throw()
    {
        throwready = false;

        //���� ������Ʈ ����
        GameObject firecracker = Instantiate(fire,player.position,cam.rotation);

        //�����ִ� �������� ������
        Vector3 force = cam.transform.forward * throwForce + transform.up * throwTorque;
        rb.AddForce(force,ForceMode.Impulse);

        Invoke(nameof(ResetThrow), throwdown);

        firecount--;
    }
    void ResetThrow()
    {
        throwready = true;
    }


   
}
