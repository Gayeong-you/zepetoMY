using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour
{
    public float posXMin = 1f;
    public float posXMax = 2f;
    
    public float posYMin = 1f;
    public float posYMax = 2f;
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
   
   public Vector3 SetRandomPlace(Vector3 position, int count)
   {
      float posX = Random.Range(posXMin, posXMax);
      float posY = Random.Range(posYMin, posYMax);
      
      Vector3 placePosition = position + new Vector3(posX,posY,0f);
      return placePosition;

   }
}
