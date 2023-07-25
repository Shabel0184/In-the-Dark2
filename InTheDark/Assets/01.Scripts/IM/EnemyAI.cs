using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    //귀신 종류
    public enum Type
    {
        WALK, //배회령
        TRAP, //상실령
        TANGK  //청음령
    }

    //상태
    public enum State
    {
        IDLE,
        PATROLL, //순찰
        TRACE,   //추격
        LISTEN,  //소리 들음
        STUN,    //플레이어 사용 아이템으로 인한 상태이상
        P_DIE    //플레이어 사망, 플레이어 잡음
    }
    //종류
    public Type type;
    //처음 기본 상태 순찰로
    public State state = State.IDLE;

    //플레이어 위치
    public Transform playerTr;
    //플레이어 마지막 위치
    Vector3 lastPlayerTr;
    //귀신 위치
    Transform enemyTr;

    //추격 범위
    [Range(1f, 20f)]
    public float traceDist;

    //강제 인식 범위
    public float spotDist = 5f;

    //스턴 아이템을 맞았는지
    public int isStun = -1;

    //트랩 오브젝트 프리팹
    public GameObject trapPrefab;

    //코루틴 함수에 사용할 지연시간
    WaitForSeconds ws;

    //무브 에이전트 스크립트
    MoveAgent moveAgent;

    //FOV
    EnemyFOV enemyFOV;
    //애니메이터
    Animator anim;

    readonly int hashWalk = Animator.StringToHash("isWalk");
    readonly int hashRun = Animator.StringToHash("isRun");
    readonly int hashStun = Animator.StringToHash("isStun");

    private void Awake()
    {
        //플레이어 찾음
        var player = GameObject.FindGameObjectWithTag("Player");

        //플레이어 오브젝트가 있다면
        if (player != null)
        {
            //플레이어의 트랜스폼 컴포넌트 할당
            playerTr = player.GetComponent<Transform>();
        }

        //컴포넌트 할당
        enemyTr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        moveAgent = GetComponent<MoveAgent>();
        enemyFOV = GetComponent<EnemyFOV>();


        //지연시간 초기화
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

    //종류 체크
    IEnumerator CheckType() //귀신 타입에 따라 다른 코루틴을 실행하도록
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


    //상태 체크
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
        //안개 거리
        float minDistance = 5f;
        //안개 거리
        float maxDistance = 30f;
        //최소 안개 밀도
        float minFogDensity = 0f;
        //최대 안개 밀도
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
