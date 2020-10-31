using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEditor.UIElements;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public abstract class GunModel
{
    // Wind resistance
    // Wind speed difference

    public GameObject Bullet;
    public float Speed = 10;
    public float Inaccuracy = 0.5f;
    public float BarrelSize = 10;
    public float ReloadSpeed = 3;
    public float TimeBtwShots = 1;
    public float BulletsPerShot = 3;

    //

    private GunShootBehaviour _behaviour;

    private bool _valid = false;
    private float _lastShot;
    private float _currentBarrel;

    public GunModel(GameObject bullet, GunShootBehaviour behaviour)
    {
        this.Bullet = bullet;
        this._behaviour = behaviour;

        _lastShot = TimeBtwShots;
        _currentBarrel = BarrelSize;
    }

    public void Reset()
    {
        _lastShot = TimeBtwShots;
        _currentBarrel = BarrelSize;
    }

    public void Update()
    {
        _valid =
            _lastShot >= TimeBtwShots &&
            _currentBarrel > 0
            ;

        _lastShot += Time.deltaTime;

        if (_currentBarrel <= 0)
            Reload();
    }

    public void Shoot(Vector3 pos, Vector2 direction)
    {
        if (!_valid) return;

        _currentBarrel--;
        _lastShot = 0;

        for (int i = 0; i < BulletsPerShot; i++)
        {
            // Getting the gameObject and it's meta 
            GameObject gb = Object.Instantiate(Bullet, pos, Quaternion.identity);
            BulletController bullet = gb.GetComponent<BulletController>();

            // Adding Inaccuracy
            Vector2 newDir = direction;
            newDir.x *= 1 + Random.Range(-1f, 1f) * Inaccuracy;
            newDir.y *= 1 + Random.Range(-1f, 1f) * Inaccuracy;
            newDir.Normalize();

            // Giving it it's velocity
            bullet.rb.AddForce(Speed * newDir, ForceMode2D.Impulse);
        }
    }

    async void Reload()
    {
        await Task.Delay((int) (ReloadSpeed * 1000));
        _currentBarrel = BarrelSize;
    }
}