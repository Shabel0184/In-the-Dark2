using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    //스폰 포인트
    public List<Transform> Spawnpoints;
    //순찰 포인트 저장용 리스트
    public List<Transform> WayPoints;
    //다음 순찰지점 지정 변수
    public int nextIndex;


    NavMeshAgent agent;

    //순찰, 추격 속도 
    readonly float patrolSpeed = 2.5f;
    readonly float traceSpeed = 4.0f;

    //회전 속도
    float damping = 1f;

    Transform enemyTr;

    EnemyAI enemyAI;

    //순찰 프로퍼티
    bool patrolling;
    public bool PATROLLING
    {
        get { return patrolling; }
        set
        {
            patrolling = value;
            if (patrolling)
            {
                agent.speed = patrolSpeed;
                damping = 1f;
                //순찰 지점으로 이동하는 함수
                MoveWayPoint();
            }
        }
    }

    //추격 프로퍼티
    Vector3 traceTarget;
    public Vector3 TRACETARGET
    {
        get { return traceTarget; }
        set
        {
            traceTarget = value;
            agent.speed = traceSpeed;
            damping = 7f;
            //추적 대상 지정 함수
            TraceTarget(traceTarget);
        }
    }

    //추격 대상 지정 함수
    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale)
        {
            return;
        }
        agent.destination = pos;
        agent.isStopped = false;
    }

    //폭죽 추격 프로퍼티
    public Vector3 firePos;
    public Vector3 FIREITEMTRACE
    {
        get { return firePos; }
        set
        {
            firePos = value;
            agent.speed = traceSpeed;
            damping = 7f;
            
            TraceFire(firePos);
        }
    }

    //폭죽 위치 지정 함수
    void TraceFire(Vector3 pos)
    {
        if (agent.isPathStale)
        {
            return;
        }
        agent.destination = pos;
        agent.isStopped = false;

        float dist = agent.remainingDistance;
        if( dist < 1f)
        {
            enemyAI.state = EnemyAI.State.IDLE;
        }
    }









    //에너미 정지 함수
    public void Stop()
    {
        agent.isStopped = true;

        agent.velocity = Vector3.zero;
        patrolling = false;
    }

    private void OnEnable()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 70, 1 << 9);
        if (colls.Length > 0)
        {
            for (int i = 0; i < colls.Length; i++)
            {
                WayPoints.Add(colls[i].transform);
            }
            nextIndex = 0;
        }
    }

    private void OnDisable()
    {
        //Spawnpoints.Clear();
        WayPoints.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyTr = GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        enemyAI = GetComponent<EnemyAI>();

        agent.autoBraking = false;
        agent.updateRotation = false;


        var spawnpoint = GameObject.Find("SpawnPointGroup");
        if (spawnpoint != null)
        {
            spawnpoint.GetComponentsInChildren<Transform>(Spawnpoints);
            Spawnpoints.RemoveAt(0);
        }

        //this.patrolling = true;

    }

    void MoveWayPoint()
    {
        if (agent.isPathStale)
        {
            return;
        }
        agent.destination = WayPoints[nextIndex].position;
        agent.isStopped = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!agent.isStopped)
        {
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
        }

        if (!patrolling)
        {
            return;
        }
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        {
            nextIndex = Random.Range(0, WayPoints.Count);

            MoveWayPoint();
        }

    }




    //귀신 스폰 함수
    public void Spawn()
    {
        //스폰 포인트 리스트를 플레이어와의 거리별로 정렬
        var sp = Spawnpoints.OrderBy(x => Vector3.Distance(enemyAI.playerTr.transform.position, x.transform.position)).ToList();
        //플레이어와 가까운 스폰 포인트로 이동
        transform.position = sp[0].position;
    }




}
