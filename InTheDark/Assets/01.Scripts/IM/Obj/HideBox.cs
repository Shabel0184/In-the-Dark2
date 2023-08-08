using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBox : MonoBehaviour
{
    int isHide = 0;
    int isHiding = 0;
    public Transform hidePos;
    public Transform playerHidePos; // 플레이어가 캐비닛 내부로 이동할 위치
    public float moveDuration = 1f; // 이동에 걸리는 시간
    Light light;

    private void OnTriggerStay(Collider other)
    {
        if (isHide < 1 && isHiding < 1 && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("HideIn / 0 -> 1");
            isHide = 1;
            StartCoroutine(HideDoor(other));

        }
        else if (isHide > 0 && isHiding < 1 && other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("HideOut -> 0");
            isHide = 0;
            StartCoroutine(HideDoor(other));

        }
        else if(other.CompareTag("ENEMY") && other.GetComponent<EnemyAI>().state == EnemyAI.State.TRACE)
        {
            var playerDie = other.GetComponent<PlayerDie>();
            playerDie.PlayerDieEvent();
        }
    }

    IEnumerator HideDoor(Collider playerCollider)
    {
        //캐비닛 상호작용 중
        isHiding = 1;

        Vector3 startPosition = playerCollider.transform.position;
        Vector3 targetPosition;
        Quaternion targetRotation;
        Rigidbody rb = playerCollider.GetComponent<Rigidbody>();
        if(light == null)
        light = playerCollider.GetComponentInChildren<Light>();

        switch (isHide)
        {
            case 0: //캐비닛 OUT
                //문 열림
                playerCollider.GetComponent<PlayerMove>().stun = false;
                transform.Translate(0, 0, -3.5f);
                yield return new WaitForSeconds(0.2f);

                targetPosition = playerHidePos.position;
                float elapsedTime = 0f;
                while (elapsedTime < moveDuration)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / moveDuration);
                    playerCollider.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                    yield return null;
                }
                playerCollider.transform.position = targetPosition; // 정확한 위치로 설정합니다.

                //물리 시스템 영향 On
                rb.isKinematic = false;
                
                light.enabled = true;
                yield return new WaitForSeconds(1.2f);
                //문 닫힘
                transform.Translate(0, 0, 3.5f);
                //캐비닛 상호작용 중 아님으로
                isHiding = 0;

                break;

            case 1: //캐비닛 IN
                //물리 시스템 영향 Off
                rb.isKinematic = true;
                playerCollider.GetComponent<PlayerMove>().stun = true;
                light.enabled = false;
                //문 열림
                transform.Translate(0, 0, -3.5f);
                yield return new WaitForSeconds(0.2f);

                targetPosition = hidePos.position;
                elapsedTime = 0f;
                while (elapsedTime < moveDuration)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / moveDuration);
                    playerCollider.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                    yield return null;
                }
                playerCollider.transform.position = targetPosition;

                yield return new WaitForSeconds(1.1f);
                //문 닫힘
                transform.Translate(0, 0, 3.5f);
                yield return new WaitForSeconds(0.2f);
                //플레이어가 문쪽으로 향하는 방향
                Vector3 directionToCabinet = (transform.position - playerCollider.transform.position).normalized;
                //
                targetRotation = Quaternion.LookRotation(directionToCabinet);
                //회전시 y축 기준으로만 회전하도록
                targetRotation.z = 0f;
                targetRotation.x = 0f;

                // 부드러운 회전을 위해 Slerp 함수를 사용합니다.
                elapsedTime = 0f;
                while (elapsedTime < moveDuration)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / moveDuration);
                    playerCollider.transform.rotation = Quaternion.Slerp(playerCollider.transform.rotation, targetRotation, t);
                    yield return null;
                }

                //playerCollider.transform.rotation = targetRotation;

                //캐비닛 상호작용 중 아님으로
                isHiding = 0;
                break;
        }
    }
}
/* 
 캐비닛에 플레이어가 들어간 상태면 카메라만 돌릴 수 있게
bool값을 쓰거나 int 값을 써서 플레이어 상태 캐비닛 인걸로 플레이어 움직이는 스크립트에서 바꿔주면 될 듯하다.
 */
//플레이어가 회전 후 바닥쪽을 보는 현상 고쳐야됨
