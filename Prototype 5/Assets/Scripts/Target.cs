using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targerRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;
    public ParticleSystem explosionPaticle;
    // Start is called before the first frame update
    void Start()
    {
        targerRb = GetComponent<Rigidbody>();
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
        targerRb.AddForce(RandomForce(),ForceMode.Impulse);
        targerRb.AddTorque(RandomTourqe(),RandomTourqe(), RandomTourqe(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            //Instantiate(explosionPaticle,transform.position,explosionPaticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
   
    }

    Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minSpeed,maxSpeed);
    }
    float RandomTourqe()
    {
        return Random.Range(-maxTorque,maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

}
