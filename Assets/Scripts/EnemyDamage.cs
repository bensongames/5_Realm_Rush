using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject _explosionPrefab;
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
    }

    private void Explode()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
