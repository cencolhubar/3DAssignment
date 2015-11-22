using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// This class spawns birds and bats for the player to collect and avoid respectively
/// </summary>

public class SpawnManager : MonoBehaviour {
    private bool spawn= true;
    public int maxPlatforms = 100;
    public GameObject platform;
    public float horizontalMin;
    public float horizontalMax;
    public float verticalMin;
    public float verticalMax;
    public GameObject Bird1;
    public GameObject Bird2;
    public GameObject Bird3;
   // public GameObject Bird4;
    public GameObject Bat;

    public Vector3 spawnValues;
    public Vector3 spawnValuesbat;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;


    public Text scoreText;
    public Text restartText;
    public Text livesText;
    public Text Timer;
    public int time;

    public bool gameOver;
    private bool restart;
    public int score;
    public int lives=3;
    private bool bird = false;


    private Vector2 originPosition;

    // Use this for initialization
    void Start () {
        score = 0;
        originPosition = new Vector2(0, -5);
        Spawn();
        StartCoroutine(SpawnWaves());
    }
	

    void Spawn()
    {
         for (int i = 0; i < maxPlatforms; i++)
        //if(spawn)
        {
            Vector3 randomPosition = new Vector3(Random.Range(90, 300), 30f, Random.Range(50, 300));
            Instantiate(platform, randomPosition, Quaternion.Euler(280,170,225));
        //    Instantiate(Bird1, randomPosition, Quaternion.identity);
          //  Instantiate(Bird2, randomPosition, Quaternion.identity);
          //  Instantiate(Bird3, randomPosition, Quaternion.identity);
         //   Instantiate(Bird4, randomPosition, Quaternion.identity);
            //originPosition = randomPosition;
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            /*
            if (bird == false)
            {

                temphazard = hazard;
                bird = true;
            }
            else if (bird == true)
            {

                temphazard = hazard3;
                bird = false;
            }
            */

            
            Quaternion spawnRotation = Quaternion.identity;
            for (int i = 0; i < hazardCount; i++)
            {


                Vector3 spawnPosition1 = new Vector3(Random.Range(spawnValues.x, spawnValues.x+55),spawnValues.y , spawnValues.z);
                Vector3 spawnPosition2 = new Vector3(Random.Range(spawnValues.x, spawnValues.x+55), spawnValues.y, spawnValues.z);
                Vector3 spawnPosition3 = new Vector3(Random.Range(spawnValues.x, spawnValues.x+55), spawnValues.y, spawnValues.z);
              //  Vector3 spawnPosition4 = new Vector3(Random.Range(spawnValues.x, spawnValues.x+55), spawnValues.y, spawnValues.z);

                
//Generates enemies on screen
                Instantiate(Bird1, spawnPosition1, spawnRotation);
                Instantiate(Bird2, spawnPosition2, spawnRotation);
                Instantiate(Bird3, spawnPosition3, spawnRotation);
               // Instantiate(Bird4, spawnPosition4, spawnRotation);

                /*
				//Randomly generate bats on screen
                if (Random.Range(1,18) % 3 == 0)
                {
                    Vector3 spawnPosition5 = new Vector3(spawnValuesbat.x, Random.Range(-spawnValuesbat.y, spawnValuesbat.y), spawnValuesbat.z);
                    Instantiate(Bat, spawnPosition5, spawnRotation);
                }
                */
                yield return new WaitForSeconds(spawnWait);
            }
           
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "    Game Over!\n\nPress 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        //   Spawn();

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


    //updates the score
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }


    //Displays the new score to the UI
    void UpdateScore()
    {
 
        scoreText.text = "Score: " + score;
    }


    //Displays the new life count to the UI
    public void UpdateLives()
    {
        if (lives< 0)
        {
           lives= 0;
        }
        livesText.text = "Lives: " + lives;
    }

    //Sets game as ended
    public void GameOver()
    {
    //    livesText.text = "Game Over!";
        gameOver = true;
        
    }

    
}
