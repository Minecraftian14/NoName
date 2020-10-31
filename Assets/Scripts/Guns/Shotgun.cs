using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : GunModel
{
    public Shotgun(GameObject bullet, GunShootBehaviour behaviour) : base(bullet, behaviour)
    {
        Speed = 12;
        Inaccuracy = 1;
        BarrelSize = 2;
        ReloadSpeed = 6;
        TimeBtwShots = 1.2f;
        BulletsPerShot = 7;
        
        Reset();
    }
}
