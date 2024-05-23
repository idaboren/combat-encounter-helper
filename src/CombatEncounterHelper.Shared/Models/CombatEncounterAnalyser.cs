using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class CombatEncounterAnalyser
{
    public int EncounterCount { get; set; } = 0;
    public string LatestWinningTeam { get; set; } = string.Empty;
    public int PlayerTeamWinCount { get; set; } = 0;
    public int LatestRoundCount { get; set; } = 0;
    public List<int> RoundCountPerEncounter { get; set; } = new();
    public int LatestAliveAtEndCount { get; set; } = 0;
    public List<int> AliveAtEndCountPerEncounter { get; set; } = new();
    public int LatestDamageDealtPerTurn { get; set; } = 0; // ??
    public List<int> DamageDealtPerTurn { get; set; } = new(); // ??

    public double CalculatePlayerTeamWinPercentage()
    {
        return Math.Round(((double)PlayerTeamWinCount / EncounterCount) * 100, 2);
    }

    public double CalculateRoundCountAverage()
    {
        return Math.Round(RoundCountPerEncounter.Average(), 2);
    }

    public double CalculateAliveAtEndAverage()
    {
        return Math.Round(AliveAtEndCountPerEncounter.Average(), 2);
    }

    public double CalculateDamageDealtPerTurnAverage()
    {
        return Math.Round(DamageDealtPerTurn.Average(), 2);
    }

    public void ResetAnalyserForNewEncounter()
    {
        LatestWinningTeam = string.Empty;
        LatestRoundCount = 0;
        LatestAliveAtEndCount = 0;
        LatestDamageDealtPerTurn = 0;
    }
}
