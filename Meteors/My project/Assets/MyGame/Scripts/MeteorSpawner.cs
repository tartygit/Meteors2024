using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public Meteor meteorPrefab;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnDistance = 15.0f;
    public int spawnCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Meteor meteor = Instantiate(this.meteorPrefab, spawnPoint, rotation);
            meteor.size = Random.Range(meteor.minSize, meteor.maxSize);
            meteor.SetTrajectory(rotation * -spawnDirection); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
