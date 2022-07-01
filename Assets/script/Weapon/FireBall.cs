using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed = 20f;
    // public Player Player;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public BattleSystem battleSystem;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    
     {
        Unit enemy = hitInfo.GetComponent<Unit>();
        if (enemy != null)
        { 
            battleSystem.PlayerAttack();
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
    
}
