using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weaponHolder;
    Weapon weapon;

    void Awake()
    {
        weapon = Instantiate(weaponHolder);
    }

    void Start()
    {
        if (weapon != null)
        {
            TurnVisual(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Memeriksa apakah objek yang terkena collider adalah player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Picked Weapon");
            Weapon playerWeapon = other.gameObject.GetComponentInChildren<Weapon>();

            if (playerWeapon != null)
            {
                playerWeapon.transform.SetParent(playerWeapon.parentTransform);

                playerWeapon.transform.localPosition = Vector3.zero;

                TurnVisual(false, playerWeapon);
            }

            weapon.transform.parent = other.transform;
            weapon.transform.SetParent(Player.Instance.transform);
            weapon.transform.localPosition = new Vector3(0, -0.05f, 0);

            TurnVisual(true, weapon);
        }
    }

    public void TurnVisual(bool on)
    {
        // Mengambil semua komponen yang ada dalam objek Weapon dan mengatur enable/disable berdasarkan parameter 'on'
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }

    // Fungsi overload untuk mengatur komponen dalam objek senjata tertentu
    public void TurnVisual(bool on, Weapon weapon)
    {
        if (weapon != null)
        {
            weapon.gameObject.SetActive(on);
        }
    }


}