using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public float speed;
    public int objects;
    public Text countText;
    public Text winText;
    public Text LoseText;

    private Rigidbody rb;
    private int count;
    private bool isjumping = false;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        LoseText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveJump = 0;// Input.GetAxis("Jump");

        if (Input.GetKeyDown(KeyCode.Space) && !isjumping)
        {
            moveJump = 10;
            isjumping = true;
        }

        if (rb.velocity.y == 0) isjumping = false;

        Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVertical);

        rb.AddForce(movement * speed);

        Debug.Log(rb.velocity.ToString());

       // rb.velocity
        if(rb.position.y < -2.588)
        {
            LoseText.text = "Game over!";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("PickUpRed"))
        {
            other.gameObject.SetActive(false);
            count++;
            speed += 6;
            SetCountText();
        }
        if (other.gameObject.CompareTag("PickUpBlue"))
        {
            other.gameObject.SetActive(false);
            count++;
            speed -= 4;
            SetCountText();
        }
        if (other.gameObject.CompareTag("wind"))
        {
            
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= objects)
        {
            winText.text = "You Win!";
        }
    }
}
