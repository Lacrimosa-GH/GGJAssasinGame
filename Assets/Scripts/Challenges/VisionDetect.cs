using UnityEngine;

public class VisionDetect : MonoBehaviour
{

   public bool playerInView = false;

   public void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         playerInView = true;
      }
      
   }

   public void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         playerInView = false;
      }
   }
   
}
