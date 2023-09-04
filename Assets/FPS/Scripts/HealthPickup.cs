using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthPickup : MonoBehaviour
{
    [Header("Ammo Parameters")]
    [Tooltip("Maximum amount of ammo in the gun")]
    public int maxAmmo = 8;
    [Tooltip("List of weapon the player will start with")]
    public List<WeaponController> ammoWeapons = new List<WeaponController>();

    Pickup m_Pickup;
    WeaponController m_Weapon;
    PlayerWeaponsManager weapons;

    void Start()
    {
        m_Pickup = GetComponent<Pickup>();
        DebugUtility.HandleErrorIfNullGetComponent<Pickup, HealthPickup>(m_Pickup, this, gameObject);

        // Subscribe to pickup action
        m_Pickup.onPick += OnPicked;
    }

    void OnPicked(PlayerCharacterController player)
    {
        m_Weapon = GetComponent<WeaponController>();
        weapons = GetComponent<PlayerWeaponsManager>();
        foreach (var weapon in ammoWeapons)
        {
            if (weapon.canPickup() == true) {
                //weapon.rechargeAmmo();
            }
        }

        m_Pickup.PlayPickupFeedback();

        Destroy(gameObject);
    }
}
