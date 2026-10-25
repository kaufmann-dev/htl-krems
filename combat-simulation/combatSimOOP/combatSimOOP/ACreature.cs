using System;
using System.Collections.Generic;

namespace combatSimOOP {
    public abstract class ACreature : AGameObject {
        private int _armor;

        private List<int> _attackValues;

        private int _healthValue;

        private int _moveValue;

        private EPlayerType _playerType;

        private int _range;

        public ACreature(int x, int y, GameEngine gameEngine, char c, List<int> attackValues, int range,
            int healthValue, int moveValue, int armor, EPlayerType playerType) : base(x, y, gameEngine,
            c) {
            this._attackValues = attackValues;
            this._healthValue = healthValue;
            this._moveValue = moveValue;
            this._playerType = playerType;
            this._range = range;
        }

        public EPlayerType PlayerType => _playerType;

        public void PerformAction() {
            int defaultMoveValue = _moveValue;
            
            ACreature creature = FindNextEnemy();
            double distance = CalculateDistance(creature);
            
            if (creature != null) {
                List<Point> route = CalculateRoute(creature);

                foreach (var p in route) {
                    if (distance > _range && IsMoveLegal(_gameEngine.GetField(p))) {
                         Move(_gameEngine.GetField(p));
                         distance = CalculateDistance(creature);
                    }
                    else {
                        break;
                    }
                }

                if (CalculateDistance(creature) <= _range) Attack(creature);
            }

            _moveValue = defaultMoveValue;
        }

        private bool IsMoveLegal(ATerrain terrain) {
            if (_moveValue >= terrain.MovementPenalty)
                return true;
            
            return false;
        }
        
        private void Move(ATerrain terrain) {
            this.X = terrain.X;
            this.Y = terrain.Y;
            this._moveValue -= terrain.MovementPenalty;
            
            _gameEngine.LogMessage($"Move: x {X} y {Y}");
        }

        private void Attack(ACreature creature) {
            Dice d = new Dice();
            int attackValue = d.Roll();
            
            _gameEngine.LogMessage($"Attack: diceroll {attackValue}");

            int attackStrength = 0;
            foreach (var av in _attackValues) {
                if (attackValue <= av) {
                    ++attackStrength;
                }
            }
            
            _gameEngine.LogMessage($"Attack: strength {attackStrength}");

            if (attackStrength > creature._armor) {
                creature._healthValue -= attackStrength - creature._armor;

                if (creature.IsDead()) {
                    _gameEngine.LogMessage($"Attack: creature killed");
                    _gameEngine.RemoveCreature(creature);
                }
            }
        }

        public ACreature FindNextEnemy() {
            double distance = Double.PositiveInfinity;
            ACreature enemy = null;

            foreach (var creature in _gameEngine.Creatures) {
                if (creature.PlayerType != PlayerType && CalculateDistance(creature) < distance) {
                    distance = CalculateDistance(creature);
                    enemy = creature;
                }
            }

            return enemy;
        }

        public bool IsDead() {
            return _healthValue <= 0;
        }
    }
}