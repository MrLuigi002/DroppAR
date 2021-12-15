using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    [SerializeField] private SphereCollider shieldCollider;

    [SerializeField] private AudioClip destroyAudio;
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);

            if(PlayerPrefs.GetInt("vfxOff") == 0)
            {
                audioSource.PlayOneShot(destroyAudio);
            }
            
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("vfxOff") == 0)
        {
            GetComponent<AudioSource>().Play();
        }
        
    }
}
