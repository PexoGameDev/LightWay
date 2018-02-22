using UnityEngine;

public class MineWeapon : Weapon {

    #region Variables
    // FIELDS //
    [SerializeField] GameObject minePrefab;

    [SerializeField] float explosionRadius;
    [SerializeField] float mineTimeDelay;

    MineScript tmpMine;

    // PUBLIC PROPERTIES //
    public GameObject MinePrefab
    {
        get { return minePrefab; }
        set { minePrefab = value; }
    }


    public float ExplosionRadius
    {
        get { return explosionRadius; }
        set { explosionRadius = value; }
    }

    public float MineTimeDelay
    {
        get { return mineTimeDelay; }
        set { mineTimeDelay = value; }
    }

    // PRIVATE PROPERTIES //

    #endregion

    #region Public Methods
    // PUBLIC METHODS //
    public override void Shoot()
    {
        if (AmmoCount > 0)
        {
            tmpMine = Instantiate(MinePrefab, PlayerController.Player.transform.position, Quaternion.identity, GameController.PlayerBulletsContainer).GetComponent<MineScript>();

            tmpMine.Damage = Damage;
            tmpMine.ExplosionRadius = ExplosionRadius;
            tmpMine.ExplosionParticles = Particles;
            tmpMine.TimeDelay = MineTimeDelay;

            AmmoCount--;
        }
        else
        {
            //click sound or smth.
            print("Not enough ammo!");
        }
    }
    #endregion

    #region Private Methods
    // PRIVATE METHODS //

    #endregion
}
