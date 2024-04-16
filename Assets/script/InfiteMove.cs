using System.Collections;
using UnityEngine;

public class InfiniteMove : MonoBehaviour
{
    private float speed = 6f;
    public float pos1 = -3.16f;
    public float pos2 = -1.06f;
    public float pos3 = -5.19f;
    private bool cantmove = true;
    public float jumpForce = 7f;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(isGrounded);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; 
        }

        
        if (transform.position.x == pos1 && cantmove)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(MoveToPosition(new Vector3(pos2, transform.position.y, transform.position.z)));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(MoveToPosition(new Vector3(pos3, transform.position.y, transform.position.z)));
            }
        }
        else if (transform.position.x == pos2 && cantmove && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(MoveToPosition(new Vector3(pos1, transform.position.y, transform.position.z)));
        }
        else if (transform.position.x == pos3 && cantmove && Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartCoroutine(MoveToPosition(new Vector3(pos1, transform.position.y, transform.position.z)));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        cantmove = false;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 1f);
        yield return new WaitForSeconds(.1f);
        cantmove = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true; 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
