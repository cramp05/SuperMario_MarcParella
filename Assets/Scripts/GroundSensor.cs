using UnityEngine;

public class GroundSensor : MonoBehaviour
{
   public bool isGrouned;

 
 
   

  void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.layer == 6)
     {
        isGrouned = true;
     } 

     if(collision.gameObject.layer == 7)
     {
         //Destroy(collision.gameObject);
         Enemigo _enemyScript = collision.gameObject.GetComponent<Enemigo>();
         _enemyScript.GoombaDeath();

     }

  }


  void OnTriggerStay2D(Collider2D collision)
  {
    if(collision.gameObject.layer == 6)
     {
        isGrouned = true;
     } 
  }


  void OnTriggerExit2D(Collider2D collision)
  {
    if(collision.gameObject.layer == 6)
     {
        isGrouned = false;
     } 
  }






}
