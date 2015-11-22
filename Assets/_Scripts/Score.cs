using UnityEngine;
using System.Collections;


/// <summary>
/// This class updates the score when coins are collected
/// </summary>
public class Score : MonoBehaviour
{



    public AudioSource coin;
    public AudioSource die;
    public int scoreValue;
    private SpawnManager gameController;



    void Start()
    {
        //Gets a reference to game controller so the score can be updated 
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<SpawnManager>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log()


        //If the police collects the coin then score is updated
        if (other.tag == "Coin")
        {
            if (!gameController.gameOver)
            {
                //No points added if player is dead
                coin.Play();
                Destroy(other.transform.gameObject);
                gameController.AddScore(scoreValue);
            }
            // Destroy(gameObject);
        }


    }
}
