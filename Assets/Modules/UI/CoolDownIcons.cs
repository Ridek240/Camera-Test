using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownIcons : MonoBehaviour
{

    //[SerializeField] private CoolDownIconScript FirstSlot;
    //[SerializeField] private CoolDownIconScript SecondSlot;
    [SerializeField] private List<CoolDownIconScript> SlotList = new List<CoolDownIconScript>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ShootingController.GetWeapont(0).Reload += FirstSlotReload;
        //ShootingController.GetWeapont(1).Reload += SecondSlotReload;
        ShootingController.WeaponChangedEvent += WeaponChanged;
        foreach(var weapon in ShootingController.WeaponList)
        {
            weapon.Reload += SlotReload;
        }
    }

    private void WeaponChanged(object sender, int e)
    {
        foreach (var item in SlotList)
        {
            item.IsWeaponSelected = false;
        }
        SlotList[e].IsWeaponSelected = true;
            
    }

    //private void FirstSlotReload(object sender, WeaponScript.ReloadEventArgs e)
    //{
    //    FirstSlot.Slider.maxValue=e.RealodTime;
    //    FirstSlot.Slider.minValue = e.lastShotTime;
    //    FirstSlot.Slider.value = Time.time;
    //}
    private void SlotReload(object sender, WeaponScript.ReloadEventArgs e)
    {
        SlotList[e.IndexInList].Slider.maxValue = e.RealodTime;
        SlotList[e.IndexInList].Slider.minValue = e.lastShotTime;
        SlotList[e.IndexInList].Slider.value = Time.time;
    }
    //private void SecondSlotReload(object sender, WeaponScript.ReloadEventArgs e)
    //{
    //    SecondSlot.Slider.maxValue = e.RealodTime;
    //    SecondSlot.Slider.minValue = e.lastShotTime;
    //    SecondSlot.Slider.value = Time.time;
    //}

    // Update is called once per frame
    void Update()
    {
        //FirstSlot.Slider.value = Time.time;
        //SecondSlot.Slider.value = Time.time;
        foreach (var item in SlotList)
        {
            item.Slider.value = Time.time;
        }
    }
}
