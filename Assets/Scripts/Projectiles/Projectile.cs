using System;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    private UnityEvent<Collider> _onHit = new();
    private Rigidbody _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 force, float timeAutoDestroy, Action<Collider> onHit)
    {
        _rigidbody.velocity = force; 
        _onHit.RemoveAllListeners();
        _onHit.AddListener((collider) => onHit?.Invoke(collider));
        Invoke("NoTrigger", timeAutoDestroy);
    }

    private void NoTrigger()
    {
        _onHit?.Invoke(null);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        _onHit?.Invoke(other);
    }
}
