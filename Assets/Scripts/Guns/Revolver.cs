using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : GunModel
{
    public Revolver(GameObject bullet) : base(bullet)
    {
    }

//    public override void Shoot(Vector3 pos, Vector3 angle)
//    {
//        GameObject gb = Object.Instantiate(Bullet, pos, Quaternion.identity);
//        gb.transform.LookAt(pos + angle);
//        gb.GetComponent<Rigidbody2D>().AddForce(100 * Speed * angle.normalized);
//    }
}