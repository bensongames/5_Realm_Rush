using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private int _hitPoints = 10;
    private ParticleFactory _particleFactory;

    private void OnEnable()
    {
        GameEventManager.OnGameOver += Explode;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameOver -= Explode;
    }

    private void Start()
    {
        _particleFactory = FindObjectOfType<ParticleFactory>();
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
            _particleFactory.CreateHitParticles(transform.position, transform);
        }
    }

    private void Explode()
    {
        _particleFactory.CreateExplosionParticles(transform.position);
        Destroy(gameObject);
    }
}
