using CombatEncounterHelper.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class Attack : IAction
{
    public string Name { get; }
    public Damage Damage { get; } // Singular for now
    public int AttackBonus { get; }

    public Attack(string name, Damage damage, int attackBonus)
    {
        Name = name;
        Damage = damage;
        AttackBonus = attackBonus;
    }

    public void Simulate(ICreature target)
    {
        var rollToHit = new Die(20).Roll() + AttackBonus;

        if (rollToHit >= target.ArmorClass)
        {
            var roll = Damage.Roll();
            target.HitPoints.CurrentHP -= roll;
        }
    }
}
