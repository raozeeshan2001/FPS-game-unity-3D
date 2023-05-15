using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
   public float health = 50f;

  public void getdamage(float damage)
    {
        health -= damage;
        if (health<=0)
        {
            Destroy(this.gameObject);
        }
    }
   
}
