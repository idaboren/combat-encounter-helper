using CombatEncounterHelper.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Interfaces;

public interface IAction
{
    public string Name { get; }
    public Damage Damage { get; }
    public void Simulate(ICreature target);
}
