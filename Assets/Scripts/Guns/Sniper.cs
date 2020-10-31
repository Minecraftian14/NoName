using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : GunModel
{
    public Sniper(GameObject bullet, GunShootBehaviour behaviour) : base(bullet, behaviour)
    {
        Speed = 70;
        Inaccuracy = 0;
        BarrelSize = 5;
        ReloadSpeed = 10;
        TimeBtwShots = 1;
        BulletsPerShot = 1;
        
        Reset();
    }
}
