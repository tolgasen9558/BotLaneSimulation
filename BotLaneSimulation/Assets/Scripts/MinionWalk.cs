using System;
using UnityEngine;

public class MinionWalk : MonoBehaviour {

    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private float _movementSpeed;

    [SerializeField]
    private float _stoppageDistance;

	void Update () {
		if(_target != null && !HasArrivedToTarget())
        {
            MoveTowardsTarget();
        }
	}

    private void MoveTowardsTarget()
    {
        Vector3 dir = _target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(dir);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _movementSpeed * Time.deltaTime);
    }

    private bool HasArrivedToTarget()
    {
        Vector3 distance = _target.transform.position - transform.position;
        return Vector3.SqrMagnitude(distance) <= _stoppageDistance;
    }
}
