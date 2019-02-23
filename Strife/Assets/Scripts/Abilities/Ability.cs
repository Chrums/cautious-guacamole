using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Unit))]
public class Ability : Dispatchable
{

    private Unit m_Unit;
    protected Unit unit { get { return m_Unit; } }

    [SerializeField]
    private int m_Charge;
    public int charge { get { return m_Charge; } protected set { m_Charge = value; } }

    [SerializeField]
    private int m_Cost;
    public int cost { get { return m_Cost; } protected set { m_Cost = value; } }

    protected Ability() : base(0.0f)
    { }

    private new void Awake()
    {
        base.Awake();
        m_Unit = GetComponent<Unit>();
    }

    public override void Query()
    {
        if (m_Charge > m_Cost) // Ability has sufficient charge
        {
            if (Lock())
            {
                StartCoroutine(Invoke());
            }
        }
    }

    private IEnumerator Invoke()
    {
        yield return StartCoroutine(Cast());
        Unlock();
    }

    protected virtual IEnumerator Cast()
    {
        yield return null;
    }

}
