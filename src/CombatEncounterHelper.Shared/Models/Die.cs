using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class Die
{
    public int Sides { get; }

    public Die(int sides)
    {
        Sides = sides;
    }

    public int Roll(int diceAmount = 1)
    {
        var result = 0;
        for (int i = 0; i < diceAmount; i++)
        {
            result += CombatEncounterSetup.Random.Next(1, Sides + 1);
        }
        return result;
    }
}
