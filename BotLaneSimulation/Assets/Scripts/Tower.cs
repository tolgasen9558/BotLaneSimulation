using UnityEngine;

public class Tower : MonoBehaviour {

    public TeamID TeamID;
    public Radar TowerRadar;

    [SerializeField]
    private GameObject _fireHead;


    private void Update()
    {
        if (TowerRadar.MinionInFocus != null)
        {
            RotateTowerHeadToPointEnemy();
        }
    }

    private void RotateTowerHeadToPointEnemy()
    {
        Vector3 dir = TowerRadar.MinionInFocus.transform.position - _fireHead.transform.position;
        _fireHead.transform.rotation = Quaternion.LookRotation(dir);
    }
}
