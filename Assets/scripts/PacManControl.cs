using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
          
public class PacManControl : MonoBehaviour
{
    private Vector2 direction;  
    private Rigidbody2D rb;
    private CircleCollider2D karakterCollider;
    private int layerMusk = 1 << 8;
    [SerializeField] float distance; 
    private GameObject[] Foods;
    private int FoodMiktari;
    private int Puan = 0;

    [SerializeField] TextMeshProUGUI TextMeshPro_PuanText;
    void Start()
    {
        Vector2.Distance(transform.position, transform.forward);
        rb = transform.GetComponent<Rigidbody2D>();
        karakterCollider = gameObject.GetComponent<CircleCollider2D>();
        Foods = GameObject.FindGameObjectsWithTag("YellowFood");
        FoodMiktari = Foods.Length;  
        Reset();
        
    }
    void Update()
    {
        GetUserInput();
    }
    private void FixedUpdate()
    {
        PacManMove();
    }

    
    private void OnTriggerEnter2D(Collider2D other)    //telelport //Food //Puan
    {
       
       
        if (other.CompareTag("YellowFood"))  //YellowFood sistem

        {
            Destroy(other.gameObject);
            Puan += 10;        
            FoodMiktari--;
            if (FoodMiktari == 0)
            {
                Debug.Log("Won");
            }
        }   
        if (other.CompareTag("BlueFood")) //BlueFood  sistem  
        {
            Destroy(other.gameObject);
            Puan += 100;
        }
        TextMeshPro_PuanText.text = Puan.ToString();

        if (other.CompareTag("RightTeleport"))   //Teleport sistem
        {
            gameObject.transform.position = new Vector2(-8.39f, 0.5f);
        }    
        if (other.CompareTag("LeftTeleport"))
        {
            gameObject.transform.position = new Vector2(8.464f, 0.49f);
        }
    }
    private void Reset() 
    {
        direction= Vector2.right;
    }
    private void PacManMove()  
    {
        rb.velocity = direction*20f;
    }
    private void GetUserInput()    
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.localPosition-0.49f*Vector3.up, Vector2.up, distance, layerMusk);
        RaycastHit2D hitUp2 = Physics2D.Raycast(transform.localPosition + 0.49f * Vector3.up, Vector2.up, distance, layerMusk);
       
        RaycastHit2D hitRight = Physics2D.Raycast(transform.localPosition - 0.49f * Vector3.right, Vector2.right , distance, layerMusk);
       RaycastHit2D hitRight2 = Physics2D.Raycast(transform.localPosition + 0.49f * Vector3.right, Vector2.right, distance, layerMusk);
       
        RaycastHit2D hitleft = Physics2D.Raycast(transform.localPosition - 0.49f * Vector3.left, Vector2.left, distance, layerMusk);
        RaycastHit2D hitleft2 = Physics2D.Raycast(transform.localPosition + 0.49f * Vector3.left, Vector2.left, distance, layerMusk);
       
        RaycastHit2D hitDown = Physics2D.Raycast(transform.localPosition - 0.49f * Vector3.down, Vector2.down, distance, layerMusk);
        RaycastHit2D hitDown2 = Physics2D.Raycast(transform.localPosition + 0.5f * Vector3.down, Vector2.down, distance, layerMusk);

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!hitUp.collider&& !hitUp2.collider)
            {
                direction = Vector2.up;
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }
        if (Input.GetKeyDown(KeyCode.D)  )
        {
            if (!hitRight.collider&& !hitRight2.collider)
            {
                direction = Vector2.right;
                transform.rotation = Quaternion.Euler(0f, 360f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!hitleft.collider && !hitleft2.collider)
            {
                direction = Vector2.left;
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!hitDown.collider && !hitDown2.collider)
            {
                direction = Vector2.down;
                transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            }
        }
        
    }
}
