using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunscript : MonoBehaviour
{
   public Camera fpscam;
    public float damage = 10f;
    public float range = 200f;
    public float force = 50f;

    public int maxammo = 10;
    private int currentammo;

    Animator animator;

    private bool isreload=false;
    public bool isscoped=false;

    public void Start()
    {
        animator = GetComponent<Animator>();
        currentammo = maxammo;
    }
    void Update()
    {
        if (isreload)
        {
            return;
        }
        //scope in and out
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!isscoped)
            {
            animator.SetBool("scope", true);
            isscoped = true;
            fpscam.fieldOfView = 45;
        
           }
            else
            {
                animator.SetBool("scope", false);
                isscoped=false;
                fpscam.fieldOfView = 60;
            }
           
        }
        if (currentammo <= 0)
        {
          StartCoroutine ( Reload());
        }
        if (Input.GetButton("Fire1") )
        {
   
            shoot();
        }
       
    }
    IEnumerator Reload()
    {
        Debug.Log("reloading");
        isreload = true;
        animator.SetBool("reload",true);
        yield return new WaitForSeconds(1f);
        currentammo = maxammo;
        isreload = false;
        animator.SetBool("reload", false);
    }

    
    void shoot()
    {   //decreasing bullets
        currentammo--;

        RaycastHit hit ;
        if (Physics.Raycast(fpscam.transform.position,fpscam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            if (hit.rigidbody!=null)
            {
                hit.rigidbody.AddForce(-hit.normal*force);
            }
            //calling method of enemy class
            enemy enemyobj=hit.transform.GetComponent<enemy>();
            if (enemyobj != null)
            {
                enemyobj.getdamage(damage);
            }
        }
    }
}
