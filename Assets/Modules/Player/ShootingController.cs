using System;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAttack()
    {
        Shoot();
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
