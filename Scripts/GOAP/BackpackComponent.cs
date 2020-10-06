using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

/**
 * Holds resources for the Agent.
 */
public class BackpackComponent : MonoBehaviour
{
    public TextMeshPro showNumber;

    private int _Tu; 
    private int _Sa; 
    private int _Ca; 
    private int _Ci; 
    private int _Cl; 
    private int _Pe; 
    private int _Su; 

    public int Tu { get { return _Tu; } set { _Tu = value; } }
    public int Sa { get { return _Sa; } set { _Sa = value; } }
    public int Ca { get { return _Ca; } set { _Ca = value; } }
    public int Ci { get { return _Ci; } set { _Ci = value; } }
    public int Cl { get { return _Cl; } set { _Cl = value; } }
    public int Pe { get { return _Pe; } set { _Pe = value; } }
    public int Su { get { return _Su; } set { _Su = value; } }

    void Update()
    {
        if (showNumber != null)
        {
            showNumber.text = "In the Backpack: \n" +
                              "\nTu: " + Tu.ToString() +
                            "\nSa: " + Sa.ToString() +
                            "\nCa: " + Ca.ToString() +
                            "\nCi: " + Ci.ToString() +
                            "\nCl: " + Cl.ToString() +
                            "\nPe: " + Pe.ToString() +
                            "\nSu: " + Su.ToString();
        }
    }

    public int getTotalNumber()
    {
        return Tu + Sa + Ca + Ci + Cl + Pe + Su;
    }

    public void cleanBackpack()
    {
        this.Tu = 0;
        this.Sa = 0;
        this.Ca = 0;
        this.Ci = 0;
        this.Cl = 0;
        this.Pe = 0;
        this.Su = 0;
    }
}