using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingController : MonoBehaviour
{
    public Transform firePoint;
    //public GameObject bulletPrefab;
    [SerializeField] public static List<WeaponScript> WeaponList = new List<WeaponScript>();
    [SerializeField] public List<WeaponScript> WeaponListVis = new List<WeaponScript>();

    public static event EventHandler WeaponAdded;
    public static event EventHandler<int> WeaponChangedEvent;
    //[SerializeField] WeaponScript FirstWeapon;
    public int CurrentWeapon = 0;
    bool shooting = false;
    public float CurrentWeaponIndex = 0;

    private void Awake()
    {
        //WeaponList.Add(FirstWeapon);
        WeaponList = WeaponListVis;
        WeaponList[0].UpdateWeapon();
        WeaponList[1].UpdateWeapon();
        InputSystem.actions["Attack"].performed += ShotActive;
        InputSystem.actions["Attack"].canceled += ShotDisactive;
        InputSystem.actions["ScrollWheel"].performed += OnScroll;

    }
    private void Start()
    {
        WeaponChangedEvent?.Invoke(this,CurrentWeapon);
    }

    private void ShotDisactive(InputAction.CallbackContext context)
    {
        shooting = false;
    }

    private void ShotActive(InputAction.CallbackContext context)
    {
        shooting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(shooting) 
        { 
            Shoot();
        }
    }


    private void Shoot()
    {
        WeaponList[CurrentWeapon].firePoint = firePoint;
        WeaponList[CurrentWeapon].Shoot();

    }
    public static WeaponScript GetWeapont(int Index)
    {
        return WeaponList[Index];
    }

    public void OnNext()
    {
        CurrentWeapon = (CurrentWeapon + 1)%WeaponList.Count;
        WeaponChangedEvent?.Invoke(this, CurrentWeapon);
    }
    public void OnPrevious()
    {
        CurrentWeapon = (CurrentWeapon - 1 + WeaponList.Count) % WeaponList.Count;
        WeaponChangedEvent?.Invoke(this, CurrentWeapon);

    }
    public void OnScroll(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            float value2 = context.ReadValue<Vector2>().y;
            if (value2 > 0) { OnNext(); }
            if (value2 < 0) { OnPrevious(); }
            CurrentWeaponIndex += value2;
        }

    }
}
