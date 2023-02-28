using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public AudioSource sfxAudio;
    public AudioSource helicopterAudio;
    public Animator helicopterAnimator;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        helicopterAnimator.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.levelService.GetLevelState() != LevelState.LevelStart)
        {
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0) transform.localScale = new Vector3(movement.x, 1f, 1f);

        if (movement.x != 0f || movement.y != 0f)
        {
            if(helicopterAudio.clip == null)
            {
                helicopterAnimator.speed = 1f;

                helicopterAudio.clip = GameManager.audioService.GetAudioClip("Helicopter");
                helicopterAudio.loop = true;
                helicopterAudio.Play();
            }

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
        if (GameManager.levelService.GetLevelState() != LevelState.LevelStart)
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
        bool pickedUp = GameManager.levelService.PickupSoldier(soldier);

        if(pickedUp) sfxAudio.PlayOneShot(GameManager.audioService.GetAudioClip("Pickup"));

        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.updateSoldierInHelicopter(GameManager.levelService.GetSoldiersInHeliCount());
    }

    private void DropOffSoldier()
    {
        Debug.Log("Drop Off Soldier");
        bool droppedOff = GameManager.levelService.DropSoldier();

        if (droppedOff) sfxAudio.PlayOneShot(GameManager.audioService.GetAudioClip("DropOff"));

        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.updateSoldierInHelicopter(GameManager.levelService.GetSoldiersInHeliCount());
        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.updateSoldiersRescued(GameManager.levelService.GetSoldiersRescuedCount());

        if (GameManager.levelService.GameIsWon())
        {
            Debug.Log("You Won!");
            helicopterAudio.Stop();
            GameManager.levelService.StopGame();
            helicopterAnimator.speed = 0f;
            GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.displayGameEndScreen(GameManager.levelService.GameIsWon());
        }
    }

    private void GameOver()
    {
        sfxAudio.PlayOneShot(GameManager.audioService.GetAudioClip("Explosion"));

        Debug.Log("Game Over");
        helicopterAudio.Stop();
        helicopterAnimator.speed = 0f;
        GameManager.levelService.StopGame();
        GameObject.Find("Level Manager").GetComponent<LevelManager>().levelUI.displayGameEndScreen(GameManager.levelService.GameIsWon());
    }
}
