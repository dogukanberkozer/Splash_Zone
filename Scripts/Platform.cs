using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    BoxCollider2D boxCollider2D; // platforms have box collider 2D
    public bool isMove; // platforms move control
    float randomSpeed; // platform speeds must be different

    public bool Movement // to control platform situation from outside
    {
        get{
            return isMove;
        }
        set{
            isMove = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>(); // reference of collider
        randomSpeed = Random.Range(0.9f, 1.6f); // to create random
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            float pingPongX = Mathf.PingPong(Time.time * randomSpeed, 3.175f); // PingPong inputs
            Vector2 pingPong = new Vector2(pingPongX, transform.position.y); // required vector to move platform
            transform.position = pingPong; // updating platform position
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Legs"){
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            // when legs component is on a platform, jump counter resets itself
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerMove>().ResetJumpCounter();
            // ResetJumpCounter method is script of the child component
        }
    }
}
