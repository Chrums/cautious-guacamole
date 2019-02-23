using UnityEngine;
using System.Collections.Generic;

public class Dispatcher : MonoBehaviour
{

    private bool m_State;
    private Dispatchable m_Active;

    private SortedDictionary<float, List<Dispatchable>> m_Dispatchables = new SortedDictionary<float, List<Dispatchable>>();

    private void Update()
    {
        Dispatch();
    }

    public void Register(float priority, Dispatchable dispatchable)
    {
        List<Dispatchable> dispatchables;
        if (!m_Dispatchables.TryGetValue(priority, out dispatchables))
        {
            dispatchables = new List<Dispatchable>();
            m_Dispatchables[priority] = dispatchables;
        }
        dispatchables.Add(dispatchable);
    }

    private void Dispatch()
    {
        //foreach (KeyValuePair<float, List<Dispatchable>> priority in m_Dispatchables)
        //    foreach (Dispatchable dispatchable in priority.Value)
        //        dispatchable.Query();
        foreach (KeyValuePair<float, List<Dispatchable>> priority in m_Dispatchables)
        {
            Debug.Log(priority.Key);
            foreach (Dispatchable dispatchable in priority.Value)
            {
                dispatchable.Query();
            }
        }
    }

    public bool Lock(Dispatchable dispatchable)
    {
        if (!m_State)
        {
            m_State = true;
            m_Active = dispatchable;
            return true;
        }
        else
        {
            bool yield = m_Active.Yield(dispatchable);
            if (yield) Yield(dispatchable);
            return yield;
        }
    }

    public void Unlock(Dispatchable dispatchable)
    {
        if (m_State && m_Active == dispatchable)
        {
            m_State = false;
            m_Active = null;
        }
    }

    private void Yield(Dispatchable dispatchable)
    {
        m_Active = dispatchable;
    }

}