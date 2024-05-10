using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class Damage
{
    public Die DamageDie { get; }
    public int DiceAmount { get; }
    public int DamageBonus { get; }
    public int Result { get; set; }

    public Damage(Die damageDie, int diceAmount, int damageBonus)
    {
        DamageDie = damageDie; 
        DiceAmount = diceAmount;
        DamageBonus = damageBonus;
    }

    public int Roll()
    {
        Result = DamageDie.Roll(DiceAmount) + DamageBonus;
        return Result;
    }
}
