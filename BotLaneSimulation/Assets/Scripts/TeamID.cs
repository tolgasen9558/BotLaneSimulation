using UnityEngine;

public class TeamID : MonoBehaviour {

	public enum Team { Blue, Red, None };

    [SerializeField]
    public Team _teamID;

    public bool IsFriendly(TeamID other)
    {
        if (_teamID == Team.Red && other._teamID == Team.Blue)
            return false;

        if (_teamID == Team.Blue && other._teamID == Team.Red)
            return false;

        return true;
    }
}
