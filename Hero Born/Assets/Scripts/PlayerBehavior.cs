using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVilocety = 5f;
    public float distanceGround = 0.1f;

    public LayerMask groundLayer;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpVilocety, ForceMode.Impulse);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet,
                this.transform.position + new Vector3(1, 0, 0),
                this.transform.rotation) as GameObject;

            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
    }
    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * hInput;
        Quaternion angelRot = Quaternion.Euler(rotation *
            Time.deltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward *
            vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angelRot);

    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y,
            _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
            capsuleBottom, distanceGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }
}
