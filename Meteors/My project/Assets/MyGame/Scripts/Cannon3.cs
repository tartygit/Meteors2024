using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon3 : MonoBehaviour
{
    public float speed3 = 500.0f;
    public float maxLifeTime3 = 10.0f;
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
    public void Project3(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed3);

        Destroy(this.gameObject, this.maxLifeTime3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
