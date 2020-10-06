using System;
using UnityEngine;
using UnityEngine.AI;

public class Trader8Action : GOAPAction
{
	private bool take1Sa1Ci1ClGive1Su = false;
	BackpackComponent backpack;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

	void Start ()
	{
	}
	
	public Trader8Action () {
		addPrecondition("hasOneSa", true);
        addPrecondition("hasOneCi", true);
        addPrecondition("hasOneCl", true);
		addPrecondition("BagHasSomething", true);
        addEffect ("BagHasSomething", true);
        addEffect ("hasOneSu", true);
		// if(backpack.Su >= 2)
		// 	addEffect ("hasTwoSu", true);
		cost = 2f + 4f + 6f;
	}
	
	public override void reset ()
	{
		take1Sa1Ci1ClGive1Su = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return take1Sa1Ci1ClGive1Su;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
		target = GameObject.Find("T8").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T8").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;
			backpack.Sa -= 1;
            backpack.Ci -= 1;
            backpack.Cl -= 1;
            backpack.Su += 1;
			take1Sa1Ci1ClGive1Su = true;
		}
		return true;
	}
	
}