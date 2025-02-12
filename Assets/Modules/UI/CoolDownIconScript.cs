using UnityEngine;
using UnityEngine.UI;

public class CoolDownIconScript : MonoBehaviour
{

    public Slider Slider;
    public Image WeaponSelected;
    private bool _IsWeaponSelected;
    public bool IsWeaponSelected {
        get { return _IsWeaponSelected; }
        set
        {
            _IsWeaponSelected = value;
            if (value == true)
            {
                WeaponSelected.enabled = true;
            }
            else
            {
                {
                    WeaponSelected.enabled = false;
                }
            }
        } 
    }

}
