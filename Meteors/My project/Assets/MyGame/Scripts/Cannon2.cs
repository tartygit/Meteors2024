using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon2 : MonoBehaviour
{
    public float speed2 = 500.0f;
    public float maxLifeTime2 = 10.0f;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void Project2(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed2);

        Destroy(this.gameObject, this.maxLifeTime2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
