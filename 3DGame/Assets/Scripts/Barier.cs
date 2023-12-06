using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    [SerializeField] GameObject _bricksEffect;
    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = other.attachedRigidbody.GetComponent<PlayerModifier>();
        if (playerModifier)
        {
            playerModifier.HitBarier();
            Destroy(gameObject);
            Instantiate(_bricksEffect, transform.position, transform.rotation);
        }
    }
}
