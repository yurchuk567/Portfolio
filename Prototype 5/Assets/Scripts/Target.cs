using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour

{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();//щоб очки добавлялися як ми нажимаємо на ціль
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomToque(), RandomToque(), RandomToque(), ForceMode.Impulse);
        transform.position =  SpawnPos();
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)//умова коли активна гра і він виконується поки активна
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);//метод з ефектами вибуху
            gameManager.UpdateScore(pointValue);
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
       Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)//метод щоб відінмалися життя
        {
            gameManager.UpdateLives(-1);
        }
   }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)//умова коли активна гра і він виконується поки активна
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);//метод з ефектами вибуху
            gameManager.UpdateScore(pointValue);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomToque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 SpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
