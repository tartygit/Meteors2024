using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (InputReader))]
[RequireComponent(typeof(CommandProcessor))]

public class Character : MonoBehaviour, IEntity
{
    public Cannon cannonPrefab;
    public Cannon2 cannon2Prefab;
    public Cannon3 cannon3Prefab;
    public float Speed = 1.0f;
    public float Turn = 1.0f;
    public Power powerPrefab1;
    public AudioSource collission_audio;
    public GameObject tutorialPanel;
    public BulletType regularType;
    public BulletType normalType;
    public BulletType triangleType;
    public GameObject bulletPrefab;
    public GameObject normalbulletPrefab;
    public GameObject trianglebulletPrefab;
    public Transform firePoint;
    //public SpriteRenderer spriteRenderer;
    //public Collider2D collider1;

    private Rigidbody2D _rigidbody;
    private bool _thrusting;
    private float _turnDirection;
    private bool hyperspace; // true=currently hyperspacing
    private bool PowerObtained;
    private bool TutorialActive;
    //private int spawnCount = 5;
    private InputReader _inputReader;
    private CommandProcessor _commandProcessor;

    // Start is called before the first frame update
    void Start()
    {
        hyperspace = false;
        PowerObtained = false;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<InputReader>();
        _commandProcessor = GetComponent<CommandProcessor>();
    }

    private void OnEnable()
    {
        
    }

    public void MoveFromTo(Vector3 startPosition, Vector3 endPosition)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        //_turnDirection = 0.0f;

        //var directionVector3 = _inputReader.ReadInput();
        //if (directionVector3 != Vector3.zero) 
        //{ 
        //    var moveCommand = new MoveCommand(this, directionVector3);
        //    _commandProcessor.ExecuteCommand(moveCommand);
        //}
                
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            _turnDirection = -1.0f;
        } else {
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetKey(KeyCode.F1))
        {
            // Show the Help panel
            tutorialPanel.SetActive(true);
            TutorialActive = true;
        }

        if (Input.GetKey(KeyCode.Escape) && TutorialActive == true) 
        {
            // Hide the Help panel
            tutorialPanel.SetActive(!TutorialActive);
            TutorialActive = false; 
        }

            // Check for hyperspace
        if (Input.GetButtonDown("Hyperspace") && !hyperspace)
        {
            hyperspace = true;
            //Make player disappear
            //spriteRenderer.enabled = false;
            //collider1.enabled = false;
            Invoke("Hyperspace",1f);
        }
    }

    //void Character.FixedUpdate()

    private void FixedUpdate()
    {
        if (_thrusting)
        {
            _rigidbody.AddForce(this.transform.up * this.Speed);
        }

        if (_turnDirection != 0.0f) {
            _rigidbody.AddTorque(_turnDirection * this.Turn);
        }
    }

    public void Shoot()
    {
        GameObject regularObject = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        RegularBullet regularbullet = regularObject.GetComponent<RegularBullet>();
        regularbullet.bulletType = regularType;
        Vector2 direction = this.transform.up;
        regularbullet.SetTrajectory(direction);

        //Cannon cannon = Instantiate(this.cannonPrefab, this.transform.position, this.transform.rotation);
        //cannon.Project(this.transform.up);

        if (PowerObtained == true)
        {
        //    Cannon2 cannon2 = Instantiate(this.cannon2Prefab, this.transform.position, this.transform.rotation);
        //    cannon2.Project2(this.transform.up);

        //    Cannon3 cannon3 = Instantiate(this.cannon3Prefab, this.transform.position, this.transform.rotation);
        //    cannon3.Project3(this.transform.up);

            GameObject normalObject = Instantiate(this.normalbulletPrefab, this.transform.position, this.transform.rotation);
            NormalBullet normalBullet = normalObject.GetComponent<NormalBullet>();
            normalBullet.bulletType = normalType;
            normalBullet.SetTrajectory(direction);

            GameObject triangleObject = Instantiate(this.trianglebulletPrefab, this.transform.position, this.transform.rotation);
            TriangleBullet triangleBullet = triangleObject.GetComponent<TriangleBullet>();
            triangleBullet.bulletType = triangleType;
            triangleBullet.SetTrajectory(direction);
        }
    }

    private void TurnOffCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
    }

    private void TurnOnCollisions()
    {
        gameObject.layer = LayerMask.NameToLayer("Character");
    }

    void Hyperspace()
    {
        //Move to a new random position
        //Vector2 newPosition = new Vector2(Random.Range(30f,100f), Random.Range(30f, 100f));
        //transform.position = newPosition;
        // Turn on colliders and sprite renderers
        //spriteRenderer.enabled=true;
        //collider1.enabled=true;
        hyperspace = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            collission_audio.Play();
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            //Invoke();
            FindObjectOfType<GameManager>().CharacterDied();
        }

        if (collision.gameObject.tag == "Power")
        {
            PowerObtained = true;
            
        }
    }
}
