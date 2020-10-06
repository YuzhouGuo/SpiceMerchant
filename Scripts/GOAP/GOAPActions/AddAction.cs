using System;
using UnityEngine;
using UnityEngine.AI;

public class AddAction : GOAPAction
{
	BackpackComponent backpack;
	private bool added = false;
    // To drop how many spice of which kind
    private string spice;
    private int n;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

    void Start ()
	{
	}
	
	// public AddAction (string s, int n) {
    //     this.spice = s;
    //     this.n = n;
	// 	addPrecondition("CaravanHasSomething", true);
    //     addEffect ("BagHasSomething", true);
	// 	cost = 1f;
	// }

    public AddAction () {
		addPrecondition("CaravanHasSomething", true);
        addEffect ("BagHasSomething", true);
		cost = 1f;
	}
	
	public override void reset ()
	{
		added = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return added;
	}
	
	public override bool requiresInRange ()
	{
		return true; // yes we need to be near a chopping block
	}
	
	public override bool checkProceduralPrecondition (GameObject agent)
	{
        target = GameObject.Find("Caravan").gameObject;
		return target != null;
	}
	
	public override bool perform (GameObject agent)
	{
		if (startTime == 0)
			startTime = Time.time;
		
		if (Time.time - startTime > workDuration) {
			// finished chopping
			// switch(this.spice)
			// {
			//     case "Tu":
			//         backpack.Tu += this.n;
			//         Caravan.Tu -= this.n;
			//         break;
			//     case "Sa":
			//         backpack.Sa += this.n;
			//         Caravan.Sa -= this.n;
			//         break;
			//     case "Ca":
			//         backpack.Ca += this.n;
			//         Caravan.Ca -= this.n;
			//         break;
			//     case "Ci":
			//         backpack.Ci += this.n;
			//         Caravan.Ci -= this.n;
			//         break;
			//     case "Cl":
			//         backpack.Cl += this.n;
			//         Caravan.Cl -= this.n;
			//         break;
			//     case "Pe":
			//         backpack.Pe += this.n;
			//         Caravan.Pe -= this.n;
			//         break;
			//     case "Su":
			//         backpack.Su += this.n;
			//         Caravan.Su -= this.n;
			//         break;
			// }
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("Caravan").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;

			Caravan.Tu += backpack.Tu;
            Caravan.Sa += backpack.Sa;
            Caravan.Ca += backpack.Ca;
            Caravan.Ci += backpack.Ci;
            Caravan.Cl += backpack.Cl;
            Caravan.Pe += backpack.Pe;
            Caravan.Su += backpack.Su;
            backpack.cleanBackpack();
			added = true;
		}
		return true;
	}
}