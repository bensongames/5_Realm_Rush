using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [Range(1,100)][SerializeField] private int _hitPoints = 10;
    [SerializeField] private Text _hitPointText;


    private void Start()
    {
        DisplayHitpoints();
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        _hitPoints -= 1;
        DisplayHitpoints();
    }

    private void DisplayHitpoints()
    {
        _hitPointText.text = $"base hitpoints {_hitPoints}";
    }
}
