using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSpawner : MonoBehaviour
{
    public AddLives livesPrefab;
    public float trajectoryVariancelives = 15.0f;
    public float spawnRatelives = 2.0f;
    public float spawnDistancelives = 15.0f;
    public int spawnCountlives = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRatelives, this.spawnRatelives);
    }
        private void Spawn()
    {
        for (int i = 0; i < spawnCountlives; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistancelives;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.trajectoryVariancelives, this.trajectoryVariancelives);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            AddLives addlives = Instantiate(this.livesPrefab, spawnPoint, rotation);
            addlives.sizeLives = Random.Range(addlives.minSizeLives, addlives.maxSizeLives);
            addlives.SetTrajectoryPower(rotation * -spawnDirection);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
