using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float jumpForceStand = 6.0f;
    [SerializeField] private Derrotas derrotas;
    [SerializeField] private AudioSource _audioSource;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private SpriteRenderer spriteRenderer;

    public Sprite newSprite;

    public Sprite oldSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing from this game object!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmountHorizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.position += new Vector3(moveAmountHorizontal, 0, 0);
        if (angleIsLyeDown(transform.rotation.eulerAngles.z))
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            spriteRenderer.sprite = oldSprite;
        }
        
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            _audioSource.Play();
            if (angleIsStand(transform.rotation.eulerAngles.z))
            {
                rb.AddForce(new Vector2(0, jumpForceStand), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("En piso");
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Dead"))
        {
            Respawn();
            derrotas.SumarDerrota();
        }

        if (collision.gameObject.CompareTag("Win"))
        {
            Debug.Log("yOU WIN");
            SceneManager.LoadScene(1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log(transform.rotation.eulerAngles.z.ToString());
        }
    }

    private void Respawn()
    {
        Debug.Log("Muerto");
        Debug.Log("Initial Position: " + initialPosition.ToString());
        Debug.Log("Initial Rotation: " + initialRotation.ToString());
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f; 
    }

    private bool angleIsStand(float angle)
    {
        var a1 = angle > 179.0 && angle < 181.0;
        var a2 = angle >= 0.0f && angle < 1.0f;
        var a3 = angle >= 359.0f && angle <= 360.0f;
        return a1 || a2 || a3;
    }
    
    private bool angleIsLyeDown(float angle)
    {
        var a1 = angle > 85.0 && angle < 95.0;
        var a2 = angle >= 265.0f && angle < 275.0f;
        return a1 || a2 ;
    }
}