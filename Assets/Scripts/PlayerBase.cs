using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private AudioClip _damageSFX;
    [Range(1,100)][SerializeField] private int _hitPoints = 10;
    [SerializeField] private Text _hitPointText;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        DisplayHitpoints();
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        PlayDamageSound();
        _hitPoints -= 1;
        DisplayHitpoints();
    }

    private void PlayDamageSound()
    {
        if (_damageSFX != null)
        {
            _audioSource.PlayOneShot(_damageSFX);
        }
    }

    private void DisplayHitpoints()
    {
        _hitPointText.text = $"base hitpoints {_hitPoints}";
    }
}
