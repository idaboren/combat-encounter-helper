using CombatEncounterHelper.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class CombatTurn : ICycle
{
    private ICreature turnTaker;
    private CombatEncounter encounter;

    public CombatTurn(ICreature turnTaker, CombatEncounter encounter)
    {
        this.turnTaker = turnTaker;
        this.encounter = encounter;
    }

    public void Simulate()
    {
        encounter.Analyser.LatestDamageDealtPerTurn = 0;

        foreach (IAction action in turnTaker.Actions)
        {
            var target = GetTarget();

            if (target != null)
            {
                action.Simulate(target);

                if (target.HitPoints.CurrentHP <= 0)
                {
                    target.IsAlive = false;
                    encounter.InitiativeOrder.Remove(target);
                }

                if (action.Damage.Result != 0)
                {
                    encounter.Analyser.LatestDamageDealtPerTurn += action.Damage.Result;
                }
            }
        }

        if (encounter.Analyser.LatestDamageDealtPerTurn != 0)
        {
            encounter.Analyser.DamageDealtPerTurn.Add(encounter.Analyser.LatestDamageDealtPerTurn);
        }
    }

    public ICreature? GetTarget()
    {
        return encounter.InitiativeOrder.Keys
            .Where(k => k.IsAlive)
            .Where(k => k.IsPlayer != turnTaker.IsPlayer)
            .FirstOrDefault();
    }
}
