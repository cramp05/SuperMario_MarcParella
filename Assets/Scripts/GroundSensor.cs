using UnityEngine;

public class GroundSensor : MonoBehaviour
{
   public bool isGrouned;
   PlayerControler _playerScript;

   void Awake()
   {
      _playerScript = GetComponentInParent<PlayerControler>();
   }


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
        
        _playerScript.Bounce();

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
