using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhastlyPlant : Plant {

    // for adding packet back to shop (used for recurring)
    [SerializeField] Packet addPacket;
    [SerializeField] int addAfterTurns = -1;

    [SerializeField] int numCorpses = 0;
    [SerializeField] bool isUndead = false;

    protected bool exorcised = false;

    public override void Harvest()
    {
        if (!exorcised)
        {
            if (plot.garden.corpses != 0) plot.garden.addCorpses(numCorpses);
            if (addAfterTurns > 0 && addPacket) plot.garden.market.addFuturePacket(addPacket, addAfterTurns);
            base.Harvest();
        }
        else
        {
            DestroyPlant();
        }
    }

    public void Exorcise ()
    {
        if (isUndead)
        {
            exorcised = true;
        }
    }

    public bool getUndead()
    {
        return isUndead;
    }
}
