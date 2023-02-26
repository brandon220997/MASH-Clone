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
        if (GameManager.level.GetLevelState() != LevelState.LevelStart)
        {
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0) transform.localScale = new Vector3(movement.x, 1f, 1f);

        if (movement.x != 0f || movement.y != 0f)
        {
            if (movement.x > 0f)
                transform.rotation = Quaternion.Euler(0f, 0f, -10f);
            else if(movement.x < 0f)
                transform.rotation = Quaternion.Euler(0f, 0f, 10f);
            else
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.level.GetLevelState() != LevelState.LevelStart)
        {
            return;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soldier") PickupSoldier(collision.gameObject);
        if (collision.gameObject.tag == "Hospital") DropOffSoldier();
        if (collision.gameObject.tag == "Tree") GameOver();
    }

    private void PickupSoldier(GameObject soldier)
    {
        Debug.Log("Pick Up Soldier");
        GameManager.level.PickupSoldier(soldier);

        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.updateSoldierInHelicopter(GameManager.level.GetSoldiersInHeliCount());
    }

    private void DropOffSoldier()
    {
        Debug.Log("Drop Off Soldier");
        GameManager.level.DropSoldier();

        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.updateSoldierInHelicopter(GameManager.level.GetSoldiersInHeliCount());
        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.updateSoldiersRescued(GameManager.level.GetSoldiersRescuedCount());

        if (GameManager.level.GameIsWon())
        {
            Debug.Log("You Won!");
            GameManager.level.StopGame();
            GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.displayGameEndScreen(GameManager.level.GameIsWon());
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        GameManager.level.StopGame();
        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.displayGameEndScreen(GameManager.level.GameIsWon());
    }
}
