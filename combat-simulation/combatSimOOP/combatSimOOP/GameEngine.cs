using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace combatSimOOP {
    public class GameEngine {
        
        private readonly ATerrain[,] map = new ATerrain[16,16];
        
        private readonly List<ACreature> creatures = new List<ACreature>();

        private Random r = new Random();

        public ReadOnlyCollection<ACreature> Creatures => creatures.AsReadOnly();

        public GameEngine() {
            Init();
        }

        public void TakeTurn(EPlayerType playerType) {
            
        }
        
        private void Init() {
            for (int i = 0; i < map.GetLength(1); i++) {
                for (int j = 0; j < map.GetLength(0); j++) {
                    map[j,i] = GenerateTerrain(j, i);
                }
                
            }
        }

        public bool ContainsCreature(Point p) {
            foreach (var creature in creatures) {
                if (p.IsEqual(creature))
                    return true;
            }

            return false;
        }
        
        public ACreature FindCreature(Point p) {
            if (ContainsCreature(p)) {
                foreach (var c in creatures) {
                    if (p.IsEqual(c))
                        return c;
                }
            }
            
            return null;
        }
        
        private ATerrain GenerateTerrain(int x, int y) {
            int randomValue = r.Next(1, 101);
            
            if(randomValue < 20)
                return new HillTerrain(x, y, this);
                
            if(randomValue >= 20 && randomValue < 40)
                return new WaterBody(x, y, this);
            
            return new DefaultTerrain(x, y, this);
        }

        public String Info() {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < map.GetLength(1); i++) {
                for (int j = 0; j < map.GetLength(0); j++) {
                    
                    str.Append(map[j,i].CharValue);
                }

                str.Append("\n");
            }
            
            return str.ToString();
        }

        public void AddCreatures(List<ACreature> creatures) {
            this.creatures.AddRange(creatures);
        }

        public bool IsPointLegal(Point p) {
            if (p.X >= 0 && p.X < map.GetLength(0) && p.Y >= 0 && p.Y < map.GetLength(1)) {
                return true;
            }
            
            return false;
        }

        public ATerrain GetField(Point p) {
            return map[p.X, p.Y];
        }

        public void LogMessage(string message) {
            Console.WriteLine(message);
        }

        public bool RemoveCreature(ACreature creature) {
            return this.creatures.Remove(creature);
        }


    }
}