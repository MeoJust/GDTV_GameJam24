using System.Collections;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float _damageMin = 1f;
    [SerializeField] float _damageMax = 10f;
    [SerializeField] float _attackDelay = 1f;

    public IEnumerator Attack(Health target)
    {
        Health targetHealth = target.GetComponent<Health>();

        while (targetHealth != null)
        {
            targetHealth.GetDamage(Random.Range(_damageMin, _damageMax));
            yield return new WaitForSeconds(_attackDelay);
        }

    }
}
