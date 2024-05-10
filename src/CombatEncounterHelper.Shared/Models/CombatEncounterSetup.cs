using CombatEncounterHelper.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class CombatEncounterSetup
{
    public static Random Random { get; } = new Random();
    public CombatEncounterAnalyser Analyser { get; } = new CombatEncounterAnalyser();
    public ICreature[] PlayerTeam { get; set; } = Array.Empty<ICreature>();
    public ICreature[] EnemyTeam { get; set; } = Array.Empty<ICreature>();
}
