using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomParentController : MonoBehaviour
{
    public GameObject child;
    public Transform[] checkpoints;
    public AnimationCurve movementCurve;
    public float speed = 5f;
    private bool isMoving = false;

    public void MoveOne()
    {
        MoveToCheckpoint(1);
    }

    public void ResetMom()
    {
        MoveToCheckpoint(0);
    }

    public void MoveTwo()
    {
        MoveToCheckpoint(3);
    }

    public void StopWalk()
    {
        child.GetComponent<MomController>().Idle();
    }

    public void StartWalk()
    {
        child.GetComponent<MomController>().Walk();
    }


    void MoveToCheckpoint(int checkpointIndex)
    {
        isMoving = true;
        Vector3 targetPosition = checkpoints[checkpointIndex].position;
        StartCoroutine(MoveObject(targetPosition));
    }

    IEnumerator MoveObject(Vector3 targetPosition)
    {
        StartWalk();
        Vector3 startPosition = transform.position;
        float distance = Vector3.Distance(startPosition, targetPosition);
        float duration = distance / speed;

        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            float normalizedTime = (Time.time - startTime) / duration;
            float curveValue = movementCurve.Evaluate(normalizedTime);

            transform.position = Vector3.Lerp(startPosition, targetPosition, curveValue);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
        StopWalk();
    }
}
