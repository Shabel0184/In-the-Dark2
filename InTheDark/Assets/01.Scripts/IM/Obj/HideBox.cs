using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBox : MonoBehaviour
{
    int isHide = 0;
    int isHiding = 0;
    public Transform hidePos;
    public Transform playerHidePos; // �÷��̾ ĳ��� ���η� �̵��� ��ġ
    public float moveDuration = 1f; // �̵��� �ɸ��� �ð�

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
    }

    IEnumerator HideDoor(Collider playerCollider)
    {
        //ĳ��� ��ȣ�ۿ� ��
        isHiding = 1;

        Vector3 startPosition = playerCollider.transform.position;
        Vector3 targetPosition;
        Quaternion targetRotation;
        Rigidbody rb = playerCollider.GetComponent<Rigidbody>();

        switch (isHide)
        {
            case 0: //ĳ��� OUT
                //�� ����
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
                playerCollider.transform.position = targetPosition; // ��Ȯ�� ��ġ�� �����մϴ�.

                //���� �ý��� ���� On
                rb.isKinematic = false;
                yield return new WaitForSeconds(1.2f);
                //�� ����
                transform.Translate(0, 0, 3.5f);
                //ĳ��� ��ȣ�ۿ� �� �ƴ�����
                isHiding = 0;

                break;

            case 1: //ĳ��� IN
                //���� �ý��� ���� Off
                rb.isKinematic = true;
                //�� ����
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
                //�� ����
                transform.Translate(0, 0, 3.5f);
                yield return new WaitForSeconds(0.1f);
                //�÷��̾ �������� ���ϴ� ����
                Vector3 directionToCabinet = (transform.position - playerCollider.transform.position).normalized;
                //
                targetRotation = Quaternion.LookRotation(directionToCabinet);
                //ȸ���� y�� �������θ� ȸ���ϵ���
                targetRotation.z = 0f;
                targetRotation.x = 0f;

                // �ε巯�� ȸ���� ���� Slerp �Լ��� ����մϴ�.
                elapsedTime = 0f;
                while (elapsedTime < moveDuration)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / moveDuration);
                    playerCollider.transform.rotation = Quaternion.Slerp(playerCollider.transform.rotation, targetRotation, t);
                    yield return null;
                }

                //playerCollider.transform.rotation = targetRotation;

                //ĳ��� ��ȣ�ۿ� �� �ƴ�����
                isHiding = 0;
                break;
        }
    }
}
/* 
 ĳ��ֿ� �÷��̾ �� ���¸� ī�޶� ���� �� �ְ�
bool���� ���ų� int ���� �Ἥ �÷��̾� ���� ĳ��� �ΰɷ� �÷��̾� �����̴� ��ũ��Ʈ���� �ٲ��ָ� �� ���ϴ�.
 */
//�÷��̾ ȸ�� �� �ٴ����� ���� ���� ���ľߵ�
