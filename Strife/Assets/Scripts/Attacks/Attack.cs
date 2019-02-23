using UnityEngine;
using System.Collections;

public class Attack : Dispatchable
{

    private Unit m_Unit;
    protected Unit unit { get { return m_Unit; } }

    [SerializeField]
    private int m_Range;
    public int range { get { return m_Range; } protected set { m_Range = value; } }

    protected Attack() : base(0.5f)
    { }

    private new void Awake()
    {
        base.Awake();
        m_Unit = GetComponent<Unit>();
    }

    public override void Query()
    {
        if (true) // Any enemy Unit is within range
        {
            if (Lock())
            {
                StartCoroutine(Invoke());
            }
        }
    }

    private IEnumerator Invoke()
    {
        Debug.Log("Attacking!");
        yield return new WaitForSeconds(2.0f);
        unit.onDamageDealt(Random.Range(2, 5));
        Unlock();
    }

}
