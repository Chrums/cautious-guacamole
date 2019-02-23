using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public delegate void OnDamageDealt(int amount);
    public delegate void OnDamageTaken(int amount);

    private OnDamageDealt m_OnDamageDealt;
    public OnDamageDealt onDamageDealt { get { return m_OnDamageDealt; } set { m_OnDamageDealt = value; } }

    private OnDamageDealt m_OnDamageTaken;
    public OnDamageDealt onDamageTaken { get { return m_OnDamageTaken; } set { m_OnDamageTaken = value; } }

}
