using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletType", menuName = "Game/BulletType")]
public class BulletType : ScriptableObject
{
    public string bulletName;
    public float speed;
    public float maxLife;
    //public GameObject prefab;
    //public GameObject explosionPrefab;

    public void ApplyTo(Bullet bullet)
    {
        bullet.bulletName = bulletName;
        bullet.speed = speed;
        bullet.maxLife = maxLife;
        //bullet.explosionPrefab = explosionPrefab;

        // Apply other properties as needed
        //if (bullet.GetComponent<SpriteRenderer>() != null)
        //{
        //    bullet.GetComponent<SpriteRenderer>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
        //}
    }
}
