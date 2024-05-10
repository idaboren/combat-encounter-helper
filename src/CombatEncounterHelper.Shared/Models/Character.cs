using CombatEncounterHelper.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Shared.Models;

public class Character : ICreature
{
    public string Name { get; }
    public bool IsAlive { get; set; }
    public bool IsPlayer { get; set; }
    public int ArmorClass { get; }
    public HitPoints HitPoints { get; set; }
    public int InitiativeModifier { get; }
    public IAction[] Actions { get; }

    public Character(string name, bool isPlayer, int armorClass, HitPoints hitPoints, int initiativeModifier, IAction[] actions)
    {
        Name = name;
        IsAlive = true;
        IsPlayer = isPlayer;
        ArmorClass = armorClass;
        HitPoints = hitPoints;
        InitiativeModifier = initiativeModifier;
        Actions = actions;
    }
}
