using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private GameObject cannonCylinder;
    [SerializeField] private GameObject cannonBall;
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject mouth;
    [SerializeField] private Transform ballParent;

    [SerializeField] private AudioSource audioSource;
    int coid = 0;

    [SerializeField] private float shootingDelayMin = 0.8f;
    [SerializeField] private float shootingDelayMax = 1.2f;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    
    void Update()
    {
        //cannonCylinder.transform.LookAt(target.transform.position, Vector3.up);
    }

    void FixedUpdate()
    {
        Vector3 relativePos = target.transform.position - cannonCylinder.transform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        cannonCylinder.transform.rotation = Quaternion.Lerp(cannonCylinder.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    IEnumerator Shoot()
    {
        coid++;
        Debug.Log($"Start {coid}");
        if(Random.Range(1, 10) <= 2) // Probabilidades de disparar moneda
        {
            //Instantiate(coin, mouth.transform.position, mouth.transform.rotation, ballParent);

            GameObject coin = ObjectPool.SharedInstance.GetPooledCoin();

            if (coin != null)
            {
                coin.transform.position = mouth.transform.position;
                coin.transform.rotation = mouth.transform.rotation;
                coin.SetActive(true);

                if (PlayerPrefs.GetInt("vfxOff") == 0)
                    audioSource.Play();
            }

            yield return new WaitForSeconds(Random.Range(shootingDelayMin, shootingDelayMax));
            
            StartCoroutine(Shoot());
          
        }

        else
        {
            //Instantiate(cannonBall, mouth.transform.position, mouth.transform.rotation, ballParent);

            GameObject cannonBall = ObjectPool.SharedInstance.GetPooledCannon();

            if(cannonBall != null)
            {
                cannonBall.transform.position = mouth.transform.position;
                cannonBall.transform.rotation = mouth.transform.rotation;
                cannonBall.SetActive(true);

                if (PlayerPrefs.GetInt("vfxOff") == 0)
                    audioSource.Play();
            }

            yield return new WaitForSeconds(Random.Range(shootingDelayMin, shootingDelayMax));

            StartCoroutine(Shoot());
        }
        Debug.Log($"End {coid}");
    }
}
