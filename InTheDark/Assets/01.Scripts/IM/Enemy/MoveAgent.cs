using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    //���� ����Ʈ
    public List<Transform> Spawnpoints;
    //���� ����Ʈ ����� ����Ʈ
    public List<Transform> WayPoints;
    //���� �������� ���� ����
    public int nextIndex;


    NavMeshAgent agent;

    //����, �߰� �ӵ� 
    readonly float patrolSpeed = 2.5f;
    readonly float traceSpeed = 4.0f;

    //ȸ�� �ӵ�
    float damping = 1f;

    Transform enemyTr;

    EnemyAI enemyAI;

    //���� ������Ƽ
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
                //���� �������� �̵��ϴ� �Լ�
                MoveWayPoint();
            }
        }
    }

    //�߰� ������Ƽ
    Vector3 traceTarget;
    public Vector3 TRACETARGET
    {
        get { return traceTarget; }
        set
        {
            traceTarget = value;
            agent.speed = traceSpeed;
            damping = 7f;
            //���� ��� ���� �Լ�
            TraceTarget(traceTarget);
        }
    }

    //�߰� ��� ���� �Լ�
    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale)
        {
            return;
        }
        agent.destination = pos;
        agent.isStopped = false;
    }

    //���� �߰� ������Ƽ
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

    //���� ��ġ ���� �Լ�
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









    //���ʹ� ���� �Լ�
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




    //�ͽ� ���� �Լ�
    public void Spawn()
    {
        //���� ����Ʈ ����Ʈ�� �÷��̾���� �Ÿ����� ����
        var sp = Spawnpoints.OrderBy(x => Vector3.Distance(enemyAI.playerTr.transform.position, x.transform.position)).ToList();
        //�÷��̾�� ����� ���� ����Ʈ�� �̵�
        transform.position = sp[0].position;
    }




}
