using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class HitPoints
{
    public int MaxHP;
    public int CurrentHP;
    public int TempHP;

    public HitPoints(int max, int current)
    {
        MaxHP = max;
        CurrentHP = current;
    }
}
