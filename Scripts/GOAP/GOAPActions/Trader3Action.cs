using System;
using UnityEngine;
using UnityEngine.AI;

public class Trader3Action : GOAPAction
{
	private bool take2SaGive1Ca = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader3Action () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasTwoSa", true);
		addEffect ("BagHasSomething", true);
        addEffect ("hasOneCa", true);
		// if(backpack.Ca >= 2)
		// 	addEffect("hasTwoCa", true);
		// if(backpack.Ca == 4)
		// 	addEffect("hasFourCa", true);
		cost = 4f + 1f; // since we need to exchange for Tu first
	}
	
	public override void reset ()
	{
		take2SaGive1Ca = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return take2SaGive1Ca;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = GameObject.Find("T3").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T3").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;
			backpack.Sa -= 2;
            backpack.Ca += 1;
			take2SaGive1Ca = true;
		}
		return true;
	}
	
}