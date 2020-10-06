using System;
using UnityEngine;
using UnityEngine.AI;

public class Trader7Action : GOAPAction
{
	private bool take4CaGive1Su = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader7Action () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasFourCa", true);
		addEffect ("BagHasSomething", true);
        addEffect ("hasOneSu", true);
		// if(backpack.Su >= 2)
		// 	addEffect ("hasTwoSu", true);
		cost = 20f;
	}
	
	public override void reset ()
	{
		take4CaGive1Su = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return take4CaGive1Su;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = GameObject.Find("T7").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T7").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;
			backpack.Ca -= 4;
            backpack.Su += 1;
			take4CaGive1Su = true;
		}
		return true;
	}
	
}