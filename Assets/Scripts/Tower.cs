﻿using System;
using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Transform _gun;
    [SerializeField] private ParticleSystem _bullets;
    [SerializeField] private AudioClip _shootSFX;
    [SerializeField] private float _range = 30f;

    public Waypoint BaseWaypoint;
    private Transform _target;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        LocateClosestTarget();
        if (_target != null)
        {
            FollowTarget();
            FireAtTargetWhenInRange();
        }
    }

    private void LocateClosestTarget()
    {
        var enemies = FindObjectsOfType<EnemyDamage>();        
        if (enemies.Length == 0) return;
        var closestEnemy = enemies[0].transform;
        foreach (var enemy in enemies)
        {
            var distanceToClosestEnemy = GetDistance(closestEnemy, transform);
            var distanceToCurrentEnemy = GetDistance(enemy.transform, transform);
            if (distanceToCurrentEnemy < distanceToClosestEnemy)
            {
                closestEnemy = enemy.transform;
            }
        }
        _target = closestEnemy;
    }

    private void FollowTarget()
    {
        if (_target == null) return;
        _gun.LookAt(_target);
    }

    private void FireAtTargetWhenInRange()
    {
        if (TargetInRange())
        {
            FireWeapon(true);
            PlayShootSound();
        }
        else
        {
            FireWeapon(false);
        }
    }

    private void FireWeapon(bool fire)
    {
        var bulletEmission = _bullets.emission;
        bulletEmission.enabled = fire;        
    }

    private void PlayShootSound()
    {
        if (_shootSFX != null)
        {
            _audioSource.Stop();
            _audioSource.PlayOneShot(_shootSFX);
        }
    }

    private bool TargetInRange()
    {
        if (_target == null) return false;
        var distanceToTarget = GetDistance(_target, transform);
        return distanceToTarget <= _range;
    }

    private float GetDistance(Transform start, Transform end)
    {
        return Vector3.Distance(start.position, end.position);
    }

}
