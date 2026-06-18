using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager:MonoBehaviour
{
    public Player player;
    public ScoreManager scoreManager;
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    private Vector3 playerStartingPoint;
    private Vector3 groundGeneratorStartpoint;

    public GroundGenerator groundGenerator;
    public GameObject largeGround;
    public GameObject mediumGround;
    public GameObject gameOverScreen;

    
    void Start()
    {
        playerStartingPoint = player.transform.position;
        groundGeneratorStartpoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);
    }
   public void Quit()
   {
        Application.Quit();
        Debug.Log("GameQuit");
   }
   public void Restart()
   {
    GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>();
    for(int i=0;i<destroyer.Length;i++)
    {
        destroyer[i].gameObject.SetActive(false);
    }
    largeGround.SetActive(true);
    mediumGround.SetActive(true);
    player.transform.position=playerStartingPoint;
    groundGenerator.transform.position=groundGeneratorStartpoint;
    player.gameObject.SetActive(true);
    gameOverScreen.SetActive(false);
    scoreManager.IsscoreIncreasing=true;
    backgroundSound.Play();
    scoreManager.score=0;
    
    
    
   }
   public void GameOver()
   {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreManager.IsscoreIncreasing=false;
        backgroundSound.Stop();
        deathSound.Play();
   }

}
