using UnityEngine;

public class TowerRadar : MonoBehaviour {

    public Minion MinionInFocus { get; private set; }

    [SerializeField]
    private TeamID _teamID;
    [SerializeField]
    private LayerMask _agressiveAgainst;
    [SerializeField]
    private float _sweepFrequency               = 15f;

    private float _radarRadius                  = 9.8f;
    private float _timeElapsedSinceLastCheck    = 0.0f;


	void Start () {
        MinionInFocus = null;
	}
	
	void Update () {
        _timeElapsedSinceLastCheck += Time.deltaTime;

        if(_timeElapsedSinceLastCheck > 1 / _sweepFrequency)
        {
            _timeElapsedSinceLastCheck = 0;
            MinionInFocus = FindMinionInRange();
            Debug.Log(MinionInFocus);
        }
	}

    private Minion FindMinionInRange()
    {
        var cols = Physics.OverlapSphere(transform.position, _radarRadius, _agressiveAgainst);

        foreach(Collider hitCollider in cols)
        {
            var minion = hitCollider.GetComponentInParent<Minion>();
            if (minion != null && !_teamID.IsFriendly(minion.TeamID))
                return minion;
        }
    
        return null;
    }

}
