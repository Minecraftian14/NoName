using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunModel
{
    protected GameObject Bullet;
    protected float Speed = 10;

    public GunModel(GameObject bullet)
    {
        this.Bullet = bullet;
    }

    public void Shoot(Vector3 pos, Vector2 direction)
    {
        GameObject gb = Object.Instantiate(Bullet, pos, Quaternion.identity);
        gb.GetComponent<Rigidbody2D>().AddForce(100 * Speed * direction);
    }
}
