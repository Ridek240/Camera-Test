using UnityEngine;

public class bulletLogic : MonoBehaviour
{

    public float bulletForce = 20f;
    public float bulletDamage = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * bulletForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if(other.TryGetComponent<EnemyBase>(out EnemyBase enemyBase))
            {
                enemyBase.TakeDamage(bulletDamage);
            }
        }
        Destroy(gameObject);   
    }
}
