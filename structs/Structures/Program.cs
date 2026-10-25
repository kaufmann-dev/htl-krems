using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Welt!");
            Console.WriteLine("-----------");

            Creatures ork = new Creatures();
            ork.name = "Lucia";
            ork.type = "ork";
            ork.hitpoint = 10;
            ork.attackValue = 3;
            ork.defenseValue = 10;
            ork.movementSpeed = 12;

            Creatures wizard = new Creatures();
            ork.name = "Franz";
            ork.type = "wizard";
            ork.hitpoint = 15;
            ork.attackValue = 5;
            ork.defenseValue = 3;
            ork.movementSpeed = 10;

            Creatures[] creatures = new Creatures[4];
            creatures[0] = ork;
            creatures[1] = wizard;

            Attack(ork, wizard);

            Console.ReadLine();
        }

        static void Attack(Creatures c1, Creatures c2)
        {
            int[] c1results = RollDices(c1.attackValue);
            int[] c2results = RollDices(c2.attackValue);

            int c1Hits = ResolveAttack(c1results);
            int c2Hits = ResolveAttack(c2results);

            c1results = RollDices(c1.defenseValue);
            c2results = RollDices(c2.defenseValue);

            int c1DefendedHits = ResolveDefense(c1results);
            int c2DefendedHits = ResolveDefense(c2results);

            Console.WriteLine(c1Hits + " " + c2DefendedHits);
            Console.WriteLine(c1DefendedHits + " " + c2DefendedHits);
        }

        static int ResolveDefense(int[] diceResults)
        {
            int defendHits = 0;

            for (int i = 0; i < diceResults.Length; i++)
            {
                if(diceResults[i] == 6)
                {
                    ++defendHits;
                }
            }

            return defendHits;
        }

        static int ResolveAttack(int[] diceResults)
        {
            int hits = 0;

            for (int i = 0; i < diceResults.Length; i++)
            {
                if (diceResults[i] >= 5)
                {
                    ++hits;
                }
            }

            return hits;
        }

        static int[] RollDices(int attackValue)
        {
            int[] diceResults = new int[attackValue];

            for (int i = 0; i < attackValue; i++)
            {
                diceResults[i] = RollDice();
            }

            return diceResults;
        }

        static void PrintList(int[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        static Random r = new Random();

        static int RollDice()
        {
            return r.Next(1, 7);
        }

        static void RollMultipleDice(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(RollDice());
            }
        }

        static void PrintCreatureList(Creatures[] creatures)
        {
            for (int i = 0; i < creatures.Length; i++)
            {
                PrintCreature(creatures[i]);
            }
        }

        static void PrintCreature(Creatures creature)
        {
            Console.WriteLine("Name: " + creature.name);
            Console.WriteLine("Typ: " + creature.type);
            Console.WriteLine("Hitpoints: " + creature.hitpoint);
            Console.WriteLine("Angriffspunkte: " + creature.attackValue);
            Console.WriteLine("Verteidigungspunkte: " + creature.defenseValue);
        }
    }
}
