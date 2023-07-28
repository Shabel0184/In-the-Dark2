using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{

    public float viewRange = 15f;
    public float viewAngle = 120f;

    Transform enemyTr;
    Transform playerTr;

    int playerLayer;
    int obstacleLayer;
    int fireitemLayer;
    int layerMask;
   

    //파인드로 플레이어 찾는 것 보단 EnemyAI 스크립트에서 플레이어 위치값을 가져오는게 더 나을거라 판단.
    EnemyAI enemyAI;

    // Start is called before the first frame update
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        enemyTr = GetComponent<Transform>();
        playerTr = enemyAI.playerTr;

        playerLayer = LayerMask.NameToLayer("PLAYER");
        obstacleLayer = LayerMask.NameToLayer("OBSTACLE");
        fireitemLayer = LayerMask.NameToLayer("ITEM");
        layerMask = 1 << playerLayer | 1 << obstacleLayer;

    }

    public bool isTracePlayer()
    {
        bool isTrace = false;

        Collider[] colls = Physics.OverlapSphere(enemyTr.position, viewRange, 1 << playerLayer);

        if(colls.Length == 1)
        {
            Vector3 dir = (playerTr.position - enemyTr.position).normalized;
            if(Vector3.Angle(enemyTr.forward, dir) < viewAngle * 0.5) 
            {
                isTrace = true;
            }
        }
        return isTrace;
    }
    

    public bool isViewPlayer()
    {
        bool isView = false;
        RaycastHit hit;
        Vector3 dir = (playerTr.position - enemyTr.position).normalized;
        if(Physics.Raycast(enemyTr.position, dir, out hit, viewRange, layerMask))
        {
            isView = hit.collider.CompareTag("Player");
        }

        return isView;
    }


    public bool FireItemTrace(out Vector3 fireitemPos)
    {
        fireitemPos = Vector3.zero;
        bool fireitem = false;
        Collider[] colls = Physics.OverlapSphere(enemyTr.position, viewRange, 1 << fireitemLayer);

        foreach(Collider coll in colls)
        {
            if(coll.CompareTag("Fire"))
            {
                fireitem = true;
                fireitemPos = coll.transform.position;
                break;
            }
        }
        return fireitem;

    }



    public Vector3 CirclePoint(float angle)
    {
        angle += transform.eulerAngles.y;

        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));

    }

}
