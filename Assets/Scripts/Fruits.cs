using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject particle;
    private Rigidbody _rigid;

    HealthBarHUDTester health;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        health = FindObjectOfType<HealthBarHUDTester>();
    }

    void Start()
    {
        Up();
        StartCoroutine(MissCheck());

        Destroy(gameObject, 3);
    }

    void Up()
    {
        int ran = Random.Range(8, 13);
        _rigid.AddForce(new Vector3(0, ran, 0), ForceMode.Impulse);
    }

    public IEnumerator MissCheck()
    {
        if (gameObject.CompareTag("Fruit"))
        {
            yield return new WaitForSeconds(2.9f);
            health.Hurt(1);
        }
    }

    public void NOMiss()
    {
        Destroy(gameObject, .1f);
    }


    public void Particle()
    {
        Instantiate(particle, gameObject.transform);
        particle.SetActive(true);
    }
}
