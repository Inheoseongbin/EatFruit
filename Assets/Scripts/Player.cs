using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject trail;

    public PlayerStats stats;

    private string KeyName = "BestScore";
    private int score = 0;
    private int bestScore = 0;
    public Text scoreText;
    public Text bestScoreText;
    public Text endScoreText;
    public Text endBestScoreText;
    public AudioSource slashAudio;
    public AudioClip slashClip;


    private void Awake()
    {
        trail = GameObject.Find("Trail");
        bestScore = PlayerPrefs.GetInt(KeyName, 0);
        bestScoreText.text = $"최고점수 : {bestScore}";
    }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            trail.SetActive(true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                trail.transform.position = hit.point;
                if (hit.collider.CompareTag("Fruit"))
                {
                    score++;
                    hit.collider.GetComponent<Fruits>().Particle();
                    hit.collider.GetComponent<Fruits>().NOMiss();
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    slashAudio.PlayOneShot(slashClip);
                    Destroy(hit.collider);
                }
                if (hit.collider.CompareTag("Alogi"))
                {
                    stats.TakeDamage(1);
                    hit.collider.GetComponent<Fruits>().Particle();
                    hit.collider.GetComponent<Fruits>().NOMiss();
                    hit.collider.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Destroy(hit.collider);
                }
            }
        }
        else
            trail.SetActive(false);

        if(score >= bestScore)
        {
            PlayerPrefs.SetInt(KeyName, score);
            bestScore = score;
        }


        scoreText.text = $"점수 : {score}";
        endScoreText.text = $"점수 : {score}";
        bestScoreText.text = $"최고점수 : {bestScore}";
        endBestScoreText.text = $"최고점수 : {bestScore}";
    }
}

