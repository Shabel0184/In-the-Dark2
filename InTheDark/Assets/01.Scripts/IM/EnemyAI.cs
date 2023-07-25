using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //�ͽ� ����
    public enum Type
    {
        WALK, //��ȸ��
        TRAP, //��Ƿ�
        TANGK  //û����
    }

    //����
    public enum State
    {
        IDLE,
        PATROLL, //����
        TRACE,   //�߰�
        LISTEN,  //�Ҹ� ����
        STUN,    //�÷��̾� ��� ���������� ���� �����̻�
        P_DIE    //�÷��̾� ���, �÷��̾� ����
    }
    //����
    public Type type;
    //ó�� �⺻ ���� ������
    public State state = State.IDLE;

    //�÷��̾� ��ġ
    public Transform playerTr;
    //�÷��̾� ������ ��ġ
    Vector3 lastPlayerTr;
    //�ͽ� ��ġ
    Transform enemyTr;

    //�߰� ����
    [Range(1f, 20f)]
    public float traceDist;

    //���� �ν� ����
    public float spotDist = 5f;

    //���� �������� �¾Ҵ���
    public int isStun = -1;

    //Ʈ�� ������Ʈ ������
    public GameObject trapPrefab;

    //�ڷ�ƾ �Լ��� ����� �����ð�
    WaitForSeconds ws;

    //���� ������Ʈ ��ũ��Ʈ
    MoveAgent moveAgent;

    //FOV
    EnemyFOV enemyFOV;
    //�ִϸ�����
    Animator anim;

    readonly int hashWalk = Animator.StringToHash("isWalk");
    readonly int hashRun = Animator.StringToHash("isRun");
    readonly int hashStun = Animator.StringToHash("isStun");

    private void Awake()
    {
        //�÷��̾� ã��
        var player = GameObject.FindGameObjectWithTag("Player");

        //�÷��̾� ������Ʈ�� �ִٸ�
        if (player != null)
        {
            //�÷��̾��� Ʈ������ ������Ʈ �Ҵ�
            playerTr = player.GetComponent<Transform>();
        }

        //������Ʈ �Ҵ�
        enemyTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        moveAgent = GetComponent<MoveAgent>();
        enemyFOV = GetComponent<EnemyFOV>();


        //�����ð� �ʱ�ȭ
        ws = new WaitForSeconds(0.3f);


    }


    private void OnEnable()
    {
        state = State.PATROLL;
        StartCoroutine(CheckType());
        StartCoroutine(CheckState());

    }

    // Update is called once per frame
    void Update()
    {

    }

    //���� üũ
    IEnumerator CheckType() //�ͽ� Ÿ�Կ� ���� �ٸ� �ڷ�ƾ�� �����ϵ���
    {
        yield return null;
        if (type == Type.WALK)
        {
            StartCoroutine(WalkAction());
            StartCoroutine(WalkFogSet());
        }
        else if (type == Type.TRAP)
        {
            StartCoroutine(TrapAction());
            StartCoroutine(TrapDown());
        }
        else if (type == Type.TANGK)
        {
            // StartCoroutine(HearCheckState());
        }
    }


    //���� üũ
    IEnumerator CheckState()
    {
        yield return new WaitForSeconds(1f);

        while (true)
        {
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);

            if (isStun < 0 && dist < traceDist)
            {
                if (dist < spotDist && enemyFOV.isViewPlayer())
                {
                    state = State.TRACE;
                    //lastPlayerTr = playerTr.position;
                }
                else if (enemyFOV.isViewPlayer() && enemyFOV.isTracePlayer())
                {
                    state = State.TRACE;
                }
                else
                {
                    state = State.PATROLL;
                }
            }
            else if (isStun < 0 && enemyFOV.isTracePlayer())
            {
                state = State.TRACE;
            }
            else if (isStun < 0)
            {
                state = State.PATROLL;
            }
            else if (isStun > 0)
            {
                state = State.STUN;
            }

            yield return ws;
        }

    }






    IEnumerator WalkAction()
    {
        while (true)
        {
            yield return ws;

            switch (state)
            {
                case State.IDLE:
                    moveAgent.Stop();
                    anim.SetBool(hashRun, false);
                    anim.SetBool(hashWalk, false);
                    break;
                case State.TRACE:
                    moveAgent.TRACETARGET = playerTr.position;
                    anim.SetBool(hashRun, true);
                    anim.SetBool(hashWalk, false);
                    break;
                case State.PATROLL:
                    moveAgent.PATROLLING = true;
                    anim.SetBool(hashRun, false);
                    anim.SetBool(hashWalk, true);
                    break;
                case State.LISTEN:
                    break;
                case State.STUN:
                    moveAgent.Stop();
                    anim.SetBool(hashStun, true);
                    yield return new WaitForSeconds(3.0f);
                    anim.SetBool(hashStun, false);
                    isStun = -1;
                    state = State.PATROLL;
                    break;
            }
        }
    }



    IEnumerator TrapAction()
    {
        while (true)
        {
            yield return ws;

            switch (state)
            {
                case State.IDLE:
                    moveAgent.Stop();
                    anim.SetBool(hashRun, false);
                    anim.SetBool(hashWalk, false);
                    break;
                case State.TRACE:
                    moveAgent.TRACETARGET = playerTr.position;
                    anim.SetBool(hashRun, true);
                    anim.SetBool(hashWalk, false);
                    break;
                case State.PATROLL:
                    moveAgent.PATROLLING = true;
                    anim.SetBool(hashRun, false);
                    anim.SetBool(hashWalk, true);
                    
                    break;
                case State.LISTEN:
                    break;
                case State.STUN:
                    moveAgent.Stop();
                    anim.SetBool(hashStun, true);
                    yield return new WaitForSeconds(3.0f);
                    anim.SetBool(hashStun, false);
                    isStun = 0;
                    state = State.PATROLL;
                    break;
            }
        }
    }

    IEnumerator TrapDown()
    {
        yield return new WaitForSeconds(0.2f);

        while (true)
        {
            int down = Random.Range(0, 4);
            yield return new WaitForSeconds(5f);
            switch (down)
            {
                case 2:
                    var _Trap = GameManager.instance.GetTrap();
                    if (_Trap != null)
                    {
                        _Trap.transform.position = transform.position;
                        _Trap.transform.rotation = transform.rotation;
                        _Trap.SetActive(true);
                    }
                    break;
                case 4:
                    _Trap = GameManager.instance.GetTrap();
                    if (_Trap != null)
                    {
                        _Trap.transform.position = transform.position;
                        _Trap.transform.rotation = transform.rotation;
                        _Trap.SetActive(true);
                    }
                    break;
            }
        }

    }






    IEnumerator WalkFogSet()
    {
        yield return new WaitForSeconds(0.1f);
        //�Ȱ� �Ÿ�
        float minDistance = 5f;
        //�Ȱ� �Ÿ�
        float maxDistance = 30f;
        //�ּ� �Ȱ� �е�
        float minFogDensity = 0f;
        //�ִ� �Ȱ� �е�
        float maxFogDensity = 0.25f;

        while (true)
        {
            float distance = Vector3.Distance(transform.position, playerTr.position);

            float t = Mathf.InverseLerp(minDistance, maxDistance, distance);
            float fogDensity = Mathf.Lerp(maxFogDensity, minFogDensity, t);

            RenderSettings.fogDensity = fogDensity;

            yield return ws;
        }
    }


}
