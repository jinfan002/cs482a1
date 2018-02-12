using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text countText;
    public Text wintext;
    public bool onGround;
    public int jcount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jcount = 0;
        count = 0;
        SetCountText ();
        wintext.text = "";
        onGround = true;
       
    }
    void Update()
    {
        if (jcount <= 8)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(0f, 10f, 0f);
                onGround = false;
               jcount = jcount +1;
            }
        }
    }
        private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText ();
        }
    }
    void OnCollisionEnter(Collision any)
    {
        if (any.gameObject.CompareTag("Ground"))

        {
            onGround = true;
        }



    }
    void SetCountText()
    {   
    countText.text = "You are a Russian Tomato trying to reunite with your Lettuce comrades. \nCollect all the pieces of lettuce! \nOnly 8 jumps allowed.      \nPieces of lettuce collected: " + count.ToString() + "/12";
        if (count >= 12)
        {
            wintext.text = "Congradulations! You have reunited with your comrades to make a salad!";
        }
       
           

    }
}
