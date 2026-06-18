using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private AudioSource coinPickupSound;
    private float coinPoints = 15f;
    private ScoreManager scoreManager;
    
    void Start()
    {
        coinPickupSound = GameObject.Find("laysaudio").GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            gameObject.SetActive(false);

            if(coinPickupSound.isPlaying)
            {
                coinPickupSound.Stop();
            }
            coinPickupSound.Play();
            scoreManager.score += coinPoints;
        }

    }
}
