using CombatEncounterHelper.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class Round : ICycle
{
    private CombatEncounter encounter;

    public Round(CombatEncounter encounter)
    {
        this.encounter = encounter;
    }

    public void Simulate()
    {
        encounter.Analyser.LatestRoundCount ++;

        foreach (var creature in encounter.InitiativeOrder.Keys)
        {
            new Turn(creature, encounter).Simulate();
        }

        encounter.Analyser.RoundCountPerEncounter.Add(encounter.Analyser.LatestRoundCount);
    }
}
