using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class Champion : Entity
{
    //protected
    protected abstract void Passive();
    protected abstract void Q(bool pressed);
    protected abstract void W(bool pressed);
    protected abstract void E(bool pressed);
    protected abstract void R(bool pressed);

    [Header("Cooldowns")]
    [SerializeField] protected float m_Q_CD;
    [SerializeField] protected float m_W_CD;
    [SerializeField] protected float m_E_CD;
    [SerializeField] protected float m_R_CD;

    //@TODO: Igual merece la pena convertir las habilidades en clases para que controlen su timer etc y poder generalizar esto a una estructura sin tamaño fijo.
    Timer[] m_cdTimers = new Timer[4];

    private void Start()
    {
        for(int i=0;i<4;i++)
        {
            m_cdTimers[i] = new Timer(0.0f);
        }
    }

    protected virtual void Update()
    {
        foreach(Timer t in m_cdTimers)
        {
            t.Update(Time.deltaTime);
        }

        bool qPressed = Input.GetKeyDown(KeyCode.Q) && m_cdTimers[0].IsElapsed() && m_cdTimers[0].IsRunning();
        bool wPressed = Input.GetKeyDown(KeyCode.W) && m_cdTimers[1].IsElapsed() && m_cdTimers[1].IsRunning();
        bool ePressed = Input.GetKeyDown(KeyCode.E) && m_cdTimers[2].IsElapsed() && m_cdTimers[2].IsRunning();
        bool rPressed = Input.GetKeyDown(KeyCode.R) && m_cdTimers[3].IsElapsed() && m_cdTimers[3].IsRunning();
        bool[] pressed = { qPressed, wPressed, ePressed, rPressed };
        
        //Abilities
        Passive();
        Q(qPressed);
        W(wPressed);
        E(ePressed);
        R(rPressed);

        //@TODO: Está feo. Mira a ver si puedes encapsular las habilidades para que manejen todo esto mejor. 
        /////////////////////////////////////////////////////////
        for(int i=0;i<4; i++)
        {
            if(pressed[i])
            {
                m_cdTimers[i].SetTime(m_R_CD);
                m_cdTimers[i].Play();
            }
        }
        /////////////////////////////////////////////////////////

        //Mouse
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                m_NavMesAgent.SetDestination(hit.point);
            }
        }
    }
}
