using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] ParticleSystem _destroyedPrefab;
    [SerializeField] ParticleSystem _hitPrefab;
    [SerializeField] private int _hitPoints = 10;

    private void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void AddNonTriggerBoxCollider()
    {
        var boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }

    void ProcessHit()
    {
        _hitPoints -= 1;
        if (_hitPoints <= 0)
        {
            Explode();
        } 
        else
        {
            var hitParticles = Instantiate(_hitPrefab, transform.position, Quaternion.identity, transform);
            var destroyDelay = hitParticles.main.duration;
            Destroy(hitParticles.gameObject, destroyDelay);
        }
    }

    private void Explode()
    {
        var destroyedParticles = Instantiate(_destroyedPrefab, transform.position, Quaternion.identity, transform);
        var destroyDelay = destroyedParticles.main.duration;
        Destroy(gameObject, destroyDelay);
    }
}
