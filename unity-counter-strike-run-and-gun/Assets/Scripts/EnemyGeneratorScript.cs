using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    public GameObject enemy;
    public float minSpeed;
    public float maxSpeed;
    public float currentSpeed;

    public float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        currentSpeed = minSpeed;
        generateEnemy();
    }

    public void GenerateNextEnemyWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateEnemy", randomWait);
    }

    void generateEnemy()
    {
        GameObject EnemyIns = Instantiate(enemy, transform.position, transform.rotation);

        EnemyIns.GetComponent<EnemyScript>().enemyGenerator = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < maxSpeed){
            currentSpeed += speedMultiplier;
        }
    }
}
