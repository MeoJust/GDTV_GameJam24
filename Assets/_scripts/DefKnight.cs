using UnityEngine;

public class DefKnight : MonoBehaviour, IDefender
{
    Fighter _fighter;
    

    void Start()
    {
        _fighter = GetComponent<Fighter>();
    }

    void OnTriggerEnter(Collider collider)
    {
        // print("enterring trigger: " + collider.name);;
        if (collider.GetComponent<IEnemy>() != null)
        {
            Attack(collider.GetComponent<Health>());
        }
    }

    public void Attack(Health health)
    {
        StartCoroutine(_fighter.Attack(health));
    }
}
