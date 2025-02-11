using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    [SerializeField] private float WeaponDelay;
    [SerializeField] private Transform BulletPrefab;
    [SerializeField] private float BulletFollow;


    public float bulletForce = 20f;
    public float bulletDamage = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
