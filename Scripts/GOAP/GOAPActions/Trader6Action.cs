using System;
using UnityEngine;
using UnityEngine.AI;

public class Trader6Action : GOAPAction
{
	private bool take2Tu1Sa1CiGive1Pe = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader6Action () {
		addPrecondition("BagHasSomething", true);
		addPrecondition("hasTwoTu", true);
        addPrecondition("hasOneSa", true);
        addPrecondition("hasOneCi", true);
		addEffect ("BagHasSomething", true);
        addEffect ("hasOnePe", true);
		// if(backpack.Pe >= 2)
		// 	addEffect ("hasTwoPe", true);
		cost = 2f + 2f + 4f;
	}
	
	public override void reset ()
	{
		take2Tu1Sa1CiGive1Pe = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return take2Tu1Sa1CiGive1Pe;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = GameObject.Find("T6").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T6").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;
			backpack.Tu -= 2;
            backpack.Sa -= 1;
            backpack.Ci -= 1;
            backpack.Pe += 1;
			take2Tu1Sa1CiGive1Pe = true;
		}
		return true;
	}
	
}