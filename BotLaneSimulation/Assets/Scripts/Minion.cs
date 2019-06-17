using UnityEngine;

public class Minion : MonoBehaviour {

    public TeamID TeamID;
    public MinionWalk MinionWalk;
    public MinionAttack MinionAttack;
    public Radar MinionRadar;

    public GameObject CurrentTarget
    {
        get { return _currentTarget; }
        set { _currentTarget = value; }
    }
    private GameObject _currentTarget;


    private void Update()
    {
        if (MinionRadar.HasTarget)
            _currentTarget = MinionRadar.MinionInFocus.gameObject;

        if (_currentTarget == null) return;

        bool shouldAttack = !MinionWalk.MoveTowardsTarget(_currentTarget);

        if (shouldAttack) MinionAttack.Attack(_currentTarget);
    }
}
