using UnityEngine;

public class MinionAttack : MonoBehaviour {



    [SerializeField]
    private float _meleeAttackCooldown = 1f;

    [SerializeField]
    private Animation _animation;

    private float _nextAttackTime = 0;

    public bool Attack(GameObject target)
    {
        if (Time.time > _nextAttackTime)
        {
            string animationString = "minion_sword_swing_" + (Random.Range(0f, 1f) < 0.5f ? "1" : "2");
            _animation.Play(animationString, PlayMode.StopAll);
            _nextAttackTime = Time.time + _meleeAttackCooldown;
            return true;
        }

        return false;
    }

}
