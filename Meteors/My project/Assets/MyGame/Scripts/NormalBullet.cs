using UnityEngine;

public class NormalBullet : Bullet
{
    public BulletType bulletType;

    protected override void Initialize()
    {
        if (bulletType != null)
        {
            bulletType.ApplyTo(this);
        }
        base.Initialize();
    }

    public override void OnHit()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit();
    }

    public void SetTrajectory(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * this.speed);
        Destroy(this.gameObject, this.maxLife);
    }
}
