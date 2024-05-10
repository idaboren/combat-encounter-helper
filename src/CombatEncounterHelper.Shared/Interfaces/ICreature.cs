using CombatEncounterHelper.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Interfaces;

public interface ICreature
{
    public string Name { get; }
    public bool IsAlive { get; set; }
    public bool IsPlayer { get; set; }
    public int ArmorClass { get; }
    public HitPoints HitPoints { get; set; }
    public int InitiativeModifier { get; }
    public IAction[] Actions { get; }
}
