using UnityEngine;
using System.Collections;

public class Movement : Dispatchable
{

    protected Movement() : base(1.0f)
    { }

    public override void Query()
    {
        if (Lock())
        {
            StartCoroutine(Invoke());
        }
    }

    private IEnumerator Invoke()
    {
        Debug.Log("Moving!");
        yield return new WaitForSeconds(2.0f);
        Unlock();
    }

}
