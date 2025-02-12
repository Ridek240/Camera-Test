using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPref", menuName = "Weapons")]
public class WeaponScript : ScriptableObject
{

    [SerializeField] private float WeaponDelay;
    [SerializeField] private Transform ShootingBulletPrefab;
    [SerializeField] private Transform BulletPrefab;
    [SerializeField] private float BulletFollow;
    [SerializeField] private GunType ShotGun;
    public Transform firePoint;
    float lastShotTime = 0f;
    [SerializeField] private int IndexInList;

    public float bulletForce = 20f;
    public float bulletDamage = 20f;

    public event EventHandler<ReloadEventArgs> Reload;
    public class ReloadEventArgs : EventArgs
    {
        public float lastShotTime;
        public float RealodTime;
        public int IndexInList;
    }

    public void UpdateWeapon()
    {
        if(BulletPrefab == null)
        {
            BulletPrefab = ShootingBulletPrefab;
        }
        BulletPrefab.GetComponent<bulletLogic>().bulletForce = bulletForce;
        BulletPrefab.GetComponent<bulletLogic>().bulletDamage = bulletDamage;
        IndexInList = ShootingController.WeaponList.IndexOf(this);
        lastShotTime = 0f;
    }

    public void Shoot()
    {
        if (Time.time >= lastShotTime + WeaponDelay)
        {
            lastShotTime = Time.time;
            Reload?.Invoke(this, new ReloadEventArgs{ lastShotTime = lastShotTime, RealodTime = lastShotTime + WeaponDelay, IndexInList = IndexInList});
            Instantiate(ShootingBulletPrefab, firePoint.position, firePoint.rotation);
        }
    }


    public enum GunType
    {
        None,
        Standard,
        ShotGun
    }
}
