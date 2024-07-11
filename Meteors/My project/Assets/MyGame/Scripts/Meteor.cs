using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Meteor : MonoBehaviour
{
    public Sprite[] sprites;
    public float size = 1.0f;
    public float minSize = 0.5f;
    public float maxSize = 1.5f;
    public float speed = 50.0f;
    public float maxLifeTime = 30.0f;
    public GameObject explosion;
    public ParticleSystem explode;
    //public AudioSource collide_audio;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        int countMeteors = PlayerPrefs.GetInt("MeteorsCounter");
        //_spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        _spriteRenderer.sprite = sprites[Random.Range(0, countMeteors)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.size;
        _rigidbody.mass = this.size;
    }

    public void SetTrajectory(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Canon")
        //{
            //collide_audio.Play();
            if ((this.size * 0.5f) > this.minSize)
            {
                CreateSplit();
                CreateSplit();
            }
                FindObjectOfType<GameManager>().MeteorDestroyed(this);
                Destroy(this.gameObject);
            //}
            //else
            //{
                //Make an explosion
                //Instantiate(explosion, transform.position, transform.rotation);
                //this.explode.Play();
                //Destroy(this.gameObject);
            //}
        //}

    }
    
    private void CreateSplit()
    {
        Vector2 current = this.transform.position;
        current += Random.insideUnitCircle * 0.5f;
        Meteor half = Instantiate(this, current, this.transform.rotation);
        half.size = this.size * 0.5f;
        half.SetTrajectory(Random.insideUnitCircle.normalized * this.speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
