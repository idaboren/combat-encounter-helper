using CombatEncounterHelper.Shared.Interfaces;
using CombatEncounterHelper.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatEncounterHelper.Example;

public static class ExampleEncounterSetup
{
    public static CombatEncounterSetup SetExample()
    {
        return new CombatEncounterSetup()
        {
            PlayerTeam = new ICreature[]
            {
                new Character("playerOne", true, 10, new HitPoints(11, 11), 1, new IAction[]
                    {
                        new Attack("Sword Attack", new Damage(
                            new Die(4), 2, 2), 
                            2)
                    }),
                new Character("playerTwo", true, 10, new HitPoints(11, 11), 1, new IAction[]
                {
                    new Attack("Sword Attack", new Damage(
                        new Die(4), 2, 2), 
                        2)
                })
            },
            EnemyTeam = new ICreature[]
            {
                new Character("enemyOne", false, 10, new HitPoints(11, 11), 1, new IAction[]
                {
                    new Attack("Sword Attack", new Damage(
                        new Die(4), 2, 2), 2)
                }),
                new Character("enemyTwo", false, 10, new HitPoints(11, 11), 1, new IAction[]
                {
                    new Attack("Sword Attack", new Damage(
                        new Die(4), 2, 2), 2)
                })
            }
        };
    }
}
