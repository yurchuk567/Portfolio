using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CoinHelper : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] GameObject _coinEffects;
 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOne();
        Destroy(gameObject);
        Instantiate(_coinEffects, transform.position, transform.rotation);
    }
}
