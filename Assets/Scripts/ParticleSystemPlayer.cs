using System.Collections;
using UnityEngine;

public class ParticleSystemPlayer : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private ParticleSystem _particleSystem;

    private Coroutine _coroutine;

    private void Start()
    {
        _particleSystem.gameObject.SetActive(false);
    }

    protected void PlayEffect(Transform place)
    {
        _particleSystem.transform.position = place.position;

        if(_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        _particleSystem.gameObject.SetActive(true);
        _particleSystem.Play();

        yield return new WaitForSeconds(_lifetime);

        _particleSystem.Stop();
        _particleSystem.gameObject.SetActive(false);
    }
}
