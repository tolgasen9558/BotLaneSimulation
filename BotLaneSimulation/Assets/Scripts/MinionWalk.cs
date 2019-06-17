using System;
using UnityEngine;

public class MinionWalk : MonoBehaviour {

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _stoppageDistance;

    public bool MoveTowardsTarget(GameObject target)
    {
        if (HasArrivedToTarget(target))
            return false;

        Vector3 dir = target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, _movementSpeed * Time.deltaTime);
        return true;
    }

    private bool HasArrivedToTarget(GameObject target)
    {
        Vector3 distance = target.transform.position - transform.position;
        return Vector3.SqrMagnitude(distance) <= _stoppageDistance;
    }
}
