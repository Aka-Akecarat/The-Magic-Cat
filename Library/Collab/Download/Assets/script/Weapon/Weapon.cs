using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform Firepoint;
    public GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        Instantiate(fireball, Firepoint.position, Firepoint.rotation);
    }
}
