using System;
using UnityEngine;
using UnityEngine.AI;

public class Trader5Action : GOAPAction
{
	private bool take1Ca1TuGive1Cl = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader5Action () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasOneCa", true);
        addPrecondition("hasOneTu", true);
		addEffect ("BagHasSomething", true);
        addEffect ("hasOneCl", true);
		// if(backpack.Cl >= 2)
		// 	addEffect ("hasTwoCl", true);
		cost = 4f + 1f + 1f;
	}
	
	public override void reset ()
	{
		take1Ca1TuGive1Cl = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return take1Ca1TuGive1Cl;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = GameObject.Find("T5").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T5").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;
			backpack.Ca -= 1;
            backpack.Tu -= 1;
            backpack.Cl += 1;
			take1Ca1TuGive1Cl = true;
		}
		return true;
	}
	
}