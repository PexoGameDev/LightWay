﻿using UnityEngine;

public abstract class Weapon : MonoBehaviour {

    #region Variables
    // FIELDS //
    [SerializeField] protected float weaponCooldown = 0.1f;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int ammoCount = 1;
    [SerializeField] protected GameObject particles;

    // PROPERTIES //
    public virtual float WeaponCooldown
    {
        get { return weaponCooldown; }
        set { weaponCooldown = value; }
    }
    public virtual int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

    public virtual int AmmoCount
    {
        get { return ammoCount; }

        set
        {
            ammoCount = value;
            if (ammoCount <= 0)
            {
                ammoCount = 0;
            }
        }
    }

    public virtual GameObject Particles
    {
        get { return particles; }
        set { particles = value; }
    }
    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public virtual void Shoot()
    {
        print("Main Weapon Class shoots");
    }
    #endregion
}
