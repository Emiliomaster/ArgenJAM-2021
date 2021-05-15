using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionState : MonoBehaviour
{
    public bool fullPosition;
    public InfectionSites parentSpt;
    public bool npcInPos;

    private void Start()
    {
        parentSpt = GetComponentInParent<InfectionSites>();
    }

    private void Update()
    {
        SetState();
    }
    void SetState()
    {
        if (fullPosition && !npcInPos)
        {
            if(parentSpt.countFullPos <= parentSpt.positions.Length - 1)
            {
                parentSpt.countFullPos++;
                //Debug.Log("posicion ocupada: " + gameObject.name);
                npcInPos = true;
            }
        }
        else if (!fullPosition && npcInPos)
        {
            if(parentSpt.countFullPos > 0)
            {
                parentSpt.countFullPos--;
                //Debug.Log("posicion desocupada: " + gameObject.name);
                npcInPos = false;
            }
        }
    }
}
