using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyController : MonoBehaviour
{
    [SerializeField] private GameObject shieldGameobject;
    [SerializeField] private int shieldPrice = 10;
    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BuyShield()
    {
        if(player.GetComponent<PlayerHitboxController>().coinCounter >= shieldPrice && !shieldGameobject.activeSelf)
        {
            shieldGameobject.SetActive(true);

            player.GetComponent<PlayerHitboxController>().coinCounter -= shieldPrice;
        }        
    }
}
