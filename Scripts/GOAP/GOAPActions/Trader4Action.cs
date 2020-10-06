using System;
using UnityEngine;
using UnityEngine.AI;

public class Trader4Action : GOAPAction
{
	private bool take4TuGive1Ci = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader4Action () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasFourTu", true);
		addEffect ("BagHasSomething", true);
        addEffect ("hasOneCi", true);
		// if(backpack.Ci >= 2)
		// 	addEffect ("hasTwoCi", true);
		cost = 4f;
	}
	
	public override void reset ()
	{
		take4TuGive1Ci = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return take4TuGive1Ci;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = GameObject.Find("T4").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T4").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;
			backpack.Tu -= 4;
            backpack.Ci += 1;
			take4TuGive1Ci = true;
		}
		return true;
	}
	
}