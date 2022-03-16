using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerattack : MonoBehaviour
{
 public Animator animator; 
  void Update()
  {
      if(Input.GetKeyDown(KeyCode.Q))
      {
          attack();
      }
  }
  void attack()
  {
      animator.SetTrigger("attack");
  }
}