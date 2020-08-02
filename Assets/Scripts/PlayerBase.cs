using UnityEngine;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    [SerializeField] private AudioClip _damageSFX;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        PlayDamageSound();
        GameEventManager.DecrementHealth(1);
    }

    private void PlayDamageSound()
    {
        if (_damageSFX != null)
        {
            _audioSource.PlayOneShot(_damageSFX);
        }
    }

}
