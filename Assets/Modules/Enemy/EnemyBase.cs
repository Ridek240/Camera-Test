using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    Rigidbody rb;
    public float Health = 200f;
    public GameObject target;
    NavMeshAgent navMeshAgent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = PlayerController.Player;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1f*Time.deltaTime);
        navMeshAgent.SetDestination(target.transform.position);
        //rb.linearVelocity = new Vector3(movement.x, 0f, movement.z);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        if(Health<=0)
        {
            GameMenager.Instance.EnemyCounterDown();
            Destroy(gameObject);
        }
    }
}
