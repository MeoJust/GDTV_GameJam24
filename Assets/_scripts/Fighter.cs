using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float _damageMin = 1f;
    [SerializeField] float _damageMax = 10f;
    [SerializeField] float _attackDelay = 1f;

    bool _isAttacking;

    public IEnumerator Attack(Health target)
    {
        Health targetHealth = target.GetComponent<Health>();

        while (targetHealth != null && !_isAttacking)
        {
            _isAttacking = true;
            GetComponent<AttackAnimator>().AttackAnim();
            targetHealth.GetDamage(Random.Range(_damageMin, _damageMax));
            yield return new WaitForSeconds(_attackDelay);
            _isAttacking = false;
        }

    }
}
