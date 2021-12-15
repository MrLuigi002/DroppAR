using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    [SerializeField] private Rigidbody rbBall;
    public float ballForce = 1f;
    public float ballLongevity = 3f;

    float time = 0f;

    void Start()
    {
        //rbBall.AddForce(transform.up * ballForce, ForceMode.Impulse);
    }

    
    void Update()
    {
        time += Time.deltaTime;

        if(time >= ballLongevity)
        {
            FindObjectOfType<PlayerHitboxController>().obstaclesEvaded++;
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        time = 0;

        rbBall.velocity = new Vector3(0, 0, 0);

        rbBall.AddForce(transform.up * ballForce, ForceMode.Impulse);
    }
}
