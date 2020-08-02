using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] GameObject _destroyedPrefab;
    [SerializeField] GameObject _hitPrefab;
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
            Instantiate(_hitPrefab, transform.position, Quaternion.identity, transform);
        }
    }

    private void Explode()
    {
        Instantiate(_destroyedPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
