using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public Power powerPrefab;
    public float trajectoryVariancepower = 15.0f;
    public float spawnRatepower = 2.0f;
    public float spawnDistancepower = 15.0f;
    public int spawnCountpower = 0;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRatepower, this.spawnRatepower);
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnCountpower; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistancepower;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.trajectoryVariancepower, this.trajectoryVariancepower);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Power power = Instantiate(this.powerPrefab, spawnPoint, rotation);
            power.sizePower = Random.Range(power.minSizePower, power.maxSizePower);
            power.SetTrajectoryPower(rotation * -spawnDirection);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
