using CombatEncounterHelper.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class CombatRound : ICycle
{
    private CombatEncounter encounter;

    public CombatRound(CombatEncounter encounter)
    {
        this.encounter = encounter;
    }

    public void Simulate()
    {
        encounter.Analyser.LatestRoundCount ++;

        foreach (var creature in encounter.InitiativeOrder.Keys)
        {
            new CombatTurn(creature, encounter).Simulate();
        }

        encounter.Analyser.RoundCountPerEncounter.Add(encounter.Analyser.LatestRoundCount);
    }
}
