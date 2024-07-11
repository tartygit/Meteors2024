using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Power : MonoBehaviour
{
    public Sprite[] spritesPower;
    public float sizePower = 1.0f;
    public float minSizePower = 0.5f;
    public float maxSizePower = 1.5f;
    public float speedPower = 50.0f;
    public float maxLifeTimePower = 30.0f;
    public GameObject explosionPower;
    public ParticleSystem explodePower;
    public bool PowerObtained;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private bool sleeping = false;
    private float _sleepTime = 0.0f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer.sprite = spritesPower[Random.Range(0, spritesPower.Length)];
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);
        this.transform.localScale = Vector3.one * this.sizePower;
        _rigidbody.mass = this.sizePower;
        PowerObtained = false;
        sleeping = false;
        _sleepTime = 0.0f;
    }
    public void SetTrajectoryPower(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speedPower);

        Destroy(this.gameObject, this.maxLifeTimePower);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Character" || collision.gameObject.tag == "Meteor" || collision.gameObject.tag == "Canon" || collision.gameObject.tag == "Cannon2" || collision.gameObject.tag == "Cannon3")
        if (collision.gameObject.tag == "Character")
        {
            //collide_audio.Play();
            //if ((this.sizePower * 0.5f) > this.minSizePower)
            //{
            //CreateSplit();
            //CreateSplit();
            FindObjectOfType<GameManager>().PowerDestroyed(this);
            Destroy(this.gameObject);
            //PowerObtained = true;
            //}
            //FindObjectOfType<GameManager>().MeteorDestroyed(this);
            //Destroy(this.gameObject);
        }
    }

    private void CreateSplit()
    {
        Vector2 current = this.transform.position;
        current += Random.insideUnitCircle * 0.5f;
        Power half = Instantiate(this, current, this.transform.rotation);
        half.sizePower = this.sizePower * 0.5f;
        half.SetTrajectoryPower(Random.insideUnitCircle.normalized * this.speedPower);
    }
    // Update is called once per frame
    void Update()
    {
        if (_sleepTime > 1.0f)
        {
            if (sleeping)
            {
                _rigidbody.WakeUp();
            }
            else
            {
                _rigidbody.Sleep();
            }
            sleeping = !sleeping;
            _sleepTime = 0.0f;
        }
        _sleepTime += Time.deltaTime;
    }
}
