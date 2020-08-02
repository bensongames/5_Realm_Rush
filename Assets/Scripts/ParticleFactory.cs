using UnityEngine;

public class ParticleFactory : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionPrefab;
    [SerializeField] ParticleSystem _hitPrefab;
    [SerializeField] ParticleSystem _attackPlayerBasePrefab;

    public void CreateHitParticles()
    {
        CreateHitParticles(transform.position, transform);
    }

    public void CreateHitParticles(Vector3 position)
    {
        CreateHitParticles(position, transform);
    }

    public void CreateHitParticles(Vector3 position, Transform parent)
    {
        var hitParticles = Instantiate(_hitPrefab, position, Quaternion.identity, parent);
        var destroyDelay = hitParticles.main.duration;
        Destroy(hitParticles.gameObject, destroyDelay);
    }

    public void CreateExplosionParticles()
    {
        CreateExplosionParticles(transform.position, transform);
    }

    public void CreateExplosionParticles(Vector3 position)
    {
        CreateExplosionParticles(position, transform);
    }

    public void CreateExplosionParticles(Vector3 position, Transform parent)
    {
        var explosionParticles = Instantiate(_explosionPrefab, position, Quaternion.identity, parent);
        var destroyDelay = explosionParticles.main.duration;
        Destroy(explosionParticles.gameObject, destroyDelay);
    }


    public void CreateAttackPlayerBaseParticles()
    {
        CreateAttackPlayerBaseParticles(transform.position, transform);
    }

    public void CreateAttackPlayerBaseParticles(Vector3 position)
    {
        CreateAttackPlayerBaseParticles(position, transform);
    }

    public void CreateAttackPlayerBaseParticles(Vector3 position, Transform parent)
    {
        var attackPlayerBaseParticles = Instantiate(_attackPlayerBasePrefab, position, Quaternion.identity, parent);
        var destroyDelay = attackPlayerBaseParticles.main.duration;
        Destroy(attackPlayerBaseParticles.gameObject, destroyDelay);
    }

}
