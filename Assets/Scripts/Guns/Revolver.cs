using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : GunModel
{
    public Revolver(GameObject bullet, GunShootBehaviour behaviour) : base(bullet, behaviour)
    {
        Speed = 10;
        Inaccuracy = 0.5f;
        BarrelSize = 6;
        ReloadSpeed = 6;
        TimeBtwShots = 1.2f;
        BulletsPerShot = 1;
        
        Reset();
    }
}