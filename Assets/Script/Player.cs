using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0) transform.localScale = new Vector3(movement.x, 1f, 1f);

        if (movement.x != 0f || movement.y != 0f)
        {
            if (movement.x > 0f)
                transform.rotation = Quaternion.Euler(0f, 0f, -10f);
            else
                transform.rotation = Quaternion.Euler(0f, 0f, 10f);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soldier") PickupSoldier();
        if (collision.gameObject.tag == "Hospital") DropOffSoldier();
        if (collision.gameObject.tag == "Tree") GameOver();
    }

    private void PickupSoldier()
    {
        Debug.Log("Pick Up Soldier");
    }

    private void DropOffSoldier()
    {
        Debug.Log("Drop Off Soldier");
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
    }
}
