using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static System.Net.WebRequestMethods;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public GameObject dusman;
    private int layerMusk = 1 << 8;
    [SerializeField] float distance;



    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        Reset();
    }
    private void Reset()
    {
        direction = Vector2.right;
    }
    void Update()
    {
        RandomOrientation();
    }



    void RandomOrientation()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(dusman.transform.position, Vector2.right, distance, layerMusk);
        RaycastHit2D hitUp = Physics2D.Raycast(dusman.transform.position, Vector2.right, distance, layerMusk);
        RaycastHit2D hitLeft = Physics2D.Raycast(dusman.transform.position, Vector2.right, distance, layerMusk);
        RaycastHit2D hitDown = Physics2D.Raycast(dusman.transform.position, Vector2.right, distance, layerMusk);
        rb.velocity = direction * 20f;


        if (!hitDown.collider && !hitUp.collider)
        {
            int RandomDirection1 = Random.Range(0, 2);

            if (RandomDirection1==0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                direction = Vector2.down;
                Debug.Log("asaðý git");
            }
            else if (RandomDirection1 == 1)
            {
                direction = Vector2.up;
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                Debug.Log("yukarý git");
            }
            
        }
        if (!hitDown.collider && hitUp.collider)
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Debug.Log("yukarý git");
        }
        if (hitDown.collider && !hitUp.collider)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            direction = Vector2.down;
            Debug.Log("asaðý git");
        }

        else if (!hitRight.collider)
        {
            rb.velocity = direction * 20f;
        }
     

    }

}
   
 




