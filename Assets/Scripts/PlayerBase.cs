using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    [Range(1,100)][SerializeField] private int _hitPoints = 10;

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        _hitPoints -= 1;
    }
}
