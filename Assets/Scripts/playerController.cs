using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float kekuatanLompatan = 5f;
    private float moveX;
    private bool bisaLoncat = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // gerak kiri kanan
        moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        // hadap kiri kanan
        if(!Mathf.Approximately(0, moveX))
        {
            transform.localRotation = moveX > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        //lompat
        if(bisaLoncat)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector2(0f, kekuatanLompatan), ForceMode2D.Impulse);
                bisaLoncat = false;
            }
        }
        
        
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if(other.collider.tag == "Terrain")
        {
            bisaLoncat = true;
        }
    }
}
