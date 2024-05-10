using CombatEncounterHelper.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class CombatEncounter : ICycle
{
    private ICreature[] playerTeam = Array.Empty<ICreature>();
    private ICreature[] enemyTeam = Array.Empty<ICreature>();
    public CombatEncounterAnalyser Analyser { get; }
    public Dictionary<ICreature, int> InitiativeOrder { get; set; }

    public CombatEncounter(CombatEncounterSetup setup)
    {
        Analyser = setup.Analyser;
        playerTeam = setup.PlayerTeam;
        enemyTeam = setup.EnemyTeam;
        InitiativeOrder = new Dictionary<ICreature, int>();
    }

    public void Simulate()
    {
        // Start of encounter reset
        foreach (var creature in playerTeam.Union(enemyTeam))
        {
            creature.IsAlive = true;
            creature.HitPoints.CurrentHP = creature.HitPoints.MaxHP;
        }

        Analyser.ResetAnalyserForNewEncounter();
        Analyser.EncounterCount ++;

        RollInitiative();
        
        // Start rounds
        while (playerTeam.Where(c => c.IsAlive).Count() > 0 
            && enemyTeam.Where(c => c.IsAlive).Count() > 0)
        {
            var round = new Round(this);
            round.Simulate();
        }

        // End of encounter analytics
        Analyser.LatestAliveAtEndCount = InitiativeOrder.Count();
        Analyser.AliveAtEndCountPerEncounter.Add(Analyser.LatestAliveAtEndCount);

        if (InitiativeOrder.First().Key.IsPlayer)
        {
            Analyser.LatestWinningTeam = "PlayerTeam";
            Analyser.PlayerTeamWinCount++;
        }
        else
        {
            Analyser.LatestWinningTeam = "EnemyTeam";
        }
    }

    private void RollInitiative()
    {
        foreach (var creature in playerTeam.Union(enemyTeam))
        {
            var initiative = new Die(20).Roll() + creature.InitiativeModifier;
            InitiativeOrder.Add(creature, initiative);
        }
        InitiativeOrder = InitiativeOrder
                            .OrderByDescending(k => k.Value)
                            .ToDictionary(k => k.Key, k => k.Value);
    }
}
