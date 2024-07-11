using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    public string bulletName;
    public float speed;
    public float maxLife;
    //public GameObject explosionPrefab;

    public abstract void OnHit();

    private void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        // Custom initialization logic for bullets
    }
}