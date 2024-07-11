using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AddLives : MonoBehaviour
{
    public Sprite[] spritesLives;
    public float sizeLives = 1.0f;
    public float minSizeLives = 0.5f;
    public float maxSizeLives = 1.5f;
    public float speedLives = 50.0f;
    public float maxLifeTimeLives = 30.0f;
    public GameObject explosionLives;
    public ParticleSystem explodeLives;
    public bool LivesObtained;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = spritesLives[Random.Range(0, spritesLives.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.sizeLives;
        _rigidbody.mass = this.sizeLives;
        LivesObtained = false;
    }

    public void SetTrajectoryPower(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speedLives);

        Destroy(this.gameObject, this.maxLifeTimeLives);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            FindObjectOfType<GameManager>().LivesDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
