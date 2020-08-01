using UnityEngine;

public class Tower : MonoBehaviour
{

    [SerializeField] private Transform _gun;
    [SerializeField] private ParticleSystem _bullets;
    [SerializeField] private Transform _target;
    [SerializeField] private float _range = 30f;

    private void Update()
    {
        FollowTarget();
        FireAtTargetWhenInRange();
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

    private bool TargetInRange()
    {
        if (_target == null) return false;
        var distanceToTarget = Vector3.Distance(_target.position, transform.position);
        return distanceToTarget <= _range;
    }
}
