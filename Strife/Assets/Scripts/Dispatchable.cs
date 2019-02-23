using UnityEngine;

[RequireComponent(typeof(Dispatcher))]
public abstract class Dispatchable : MonoBehaviour
{

    private float m_Priority = 0.0f;

    private Dispatcher m_Dispatcher;

    protected Dispatchable(float priority)
    {
        m_Priority = priority;
    }

    protected void Awake()
    {
        m_Dispatcher = GetComponent<Dispatcher>();
        m_Dispatcher.Register(m_Priority, this);
    }

    protected bool Lock()
    {
        return m_Dispatcher.Lock(this);
    }

    protected void Unlock()
    {
        m_Dispatcher.Unlock(this);
    }

    public virtual void Query()
    { }

    public virtual bool Yield(Dispatchable dispatchable)
    {
        return false;
    }

}