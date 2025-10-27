using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         if (GameManager.Instance != null)
         {
            GameManager.Instance.DecreaseLife();
         }
         
         Destroy(gameObject);
      }
   }
}
