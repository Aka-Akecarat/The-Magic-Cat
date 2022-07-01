using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
   public int coinValue = 1;
   public GameObject count;

    private void Start()
    {
        count = GameObject.Find("CountCanvas");
    }

    private void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.CompareTag("Player")){
             FindObjectOfType<AudioManager>().Play("Coin");
             Destroy(this.gameObject);
             GlobalControl.Instance.currentMoney +=1;
             count.GetComponent<count>().addcoin();
      }
   }
}
