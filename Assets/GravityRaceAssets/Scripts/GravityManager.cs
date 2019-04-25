using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour {


    public float GravityPower = 1.001f;

    private GameObject PlayerMachine;

    private Vector3 myPos;
    private Vector3 GravityDirction;

    private SphereCollider myCollider;
    private float maxDistance;
    

    void Start()
    {
        PlayerMachine = GameObject.FindGameObjectWithTag("Player");
        myPos = this.transform.position;
        myCollider = GetComponent<SphereCollider>();
        maxDistance = this.transform.localScale.x * myCollider.radius;
        
    }

	void OnTriggerEnter(Collider hit)
    {
        if(hit.CompareTag("Player"))
        {
            PlayerMachine.GetComponent<MachineController>().ChangeGravity(true);
        }
    }
    
    void OnTriggerStay(Collider hit)
    {

        if(hit.CompareTag("Player"))
        {
            Vector3 target = PlayerMachine.transform.position;
            float distance = Vector3.Distance(myPos, target);
            Vector3 heading = (myPos - target).normalized;
            
            PlayerMachine.GetComponent<MachineController>().ApplyGravity(((maxDistance - distance)*GravityPower)*heading);
        }
    }
   
    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            PlayerMachine.GetComponent<MachineController>().ChangeGravity(false);
        }
    }
}
