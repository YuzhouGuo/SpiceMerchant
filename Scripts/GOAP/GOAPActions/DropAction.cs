using System;
using UnityEngine;
using UnityEngine.AI;

public class DropAction : GOAPAction
{
	BackpackComponent backpack;
	private bool dropped = false;
    // To drop how many spice of which kind
    private string spice;
    private int n;
	
	private float startTime = 0;
	public float workDuration = 2; // seconds

    void Start ()
	{
		navAgent = GetComponent<NavMeshAgent>();
		target = GameObject.Find("Caravan").gameObject;
	}
	
	public DropAction (string s, int n) {
        this.spice = s;
        this.n = n;
		addPrecondition("BagHasSomething", true);
        addEffect ("CaravanHasSomething", true);
		cost = 1f;
	}
	
	public override void reset ()
	{
		dropped = false;
		startTime = 0;
	}
	
	public override bool isDone ()
	{
		return dropped;
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
			//         backpack.Tu -= this.n;
			//         Caravan.Tu += this.n;
			//         break;
			//     case "Sa":
			//         backpack.Sa -= this.n;
			//         Caravan.Sa += this.n;
			//         break;
			//     case "Ca":
			//         backpack.Ca -= this.n;
			//         Caravan.Ca += this.n;
			//         break;
			//     case "Ci":
			//         backpack.Ci -= this.n;
			//         Caravan.Ci += this.n;
			//         break;
			//     case "Cl":
			//         backpack.Cl -= this.n;
			//         Caravan.Cl += this.n;
			//         break;
			//     case "Pe":
			//         backpack.Pe -= this.n;
			//         Caravan.Pe += this.n;
			//         break;
			//     case "Su":
			//         backpack.Su -= this.n;
			//         Caravan.Su += this.n;
			//         break;
			// }
			navAgent = GetComponent<NavMeshAgent>();
			target = GameObject.Find("T2").gameObject;
			// If we have the same navAgent, then we're using the same backpack
			backpack = (BackpackComponent)navAgent.GetComponent(typeof(BackpackComponent));

			navAgent.destination = target.transform.position;

			backpack.Tu += Caravan.Tu;
            backpack.Sa += Caravan.Sa;
            backpack.Ca += Caravan.Ca;
            backpack.Ci += Caravan.Ci;
            backpack.Cl += Caravan.Cl;
            backpack.Pe += Caravan.Pe;
            backpack.Su += Caravan.Su;
            Caravan.cleanCaravan();
			dropped = true;
		}
		return true;
	}
}