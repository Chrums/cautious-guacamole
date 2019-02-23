using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Ability
{

    private void Start()
    {
        unit.onDamageDealt += OnDamageDealt;
        unit.onDamageTaken += OnDamageTaken;
    }

    private void OnDamageDealt(int amount)
    {
        charge += amount * 2;
    }

    private void OnDamageTaken(int amount)
    {
        charge += amount;
    }

    protected override IEnumerator Cast()
    {
        charge -= cost;
        Debug.Log("Fireball!");
        yield return null;
    }

}
