using System;
using System.Collections.Generic;

namespace BattleShip {
    public class Ship {
        /*private int _size;
        private EPlayerType _playerType;
        private Point _origin;
        private EDirection _direction;

        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public EPlayerType PlayerType
        {
            get => _playerType;
            set => _playerType = value;
        }

        public Point Origin
        {
            get => _origin;
            set => _origin = value;
        }

        public EDirection Direction
        {
            get => _direction;
            set => _direction = value;
        }*/
        private Point _origin;
        private EDirection _orientation;
        private EShipType _shipType;
        private EFieldtype _fieldType;
        private int _size;

        public Ship(Point origin, EDirection orientation, EShipType shipType, EFieldtype fieldType, int size)
        {
            _origin = origin;
            _orientation = orientation;
            _shipType = shipType;
            _fieldType = fieldType;
            _size = size;
        }

        public List<Point> CalculateShipCoordinates()
        {
            List<Point> BruhList = new List<Point>();
            
            switch (_orientation)
            {
                case EDirection.HORIZONTAL:
                    for (int i = 0; i < _size; i++)
                    {
                        BruhList.Add(new Point(_origin.X, _origin.Y + i));
                    }
                    break;
                case EDirection.VERTICAL:
                    for (int i = 0; i < _size; i++)
                    {
                        BruhList.Add(new Point(_origin.X + i, _origin.Y));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return BruhList;
        }

        public List<Field> CalculateFieldValues()
        {
            List<Field> Bapapa = new List<Field>();
            List<Point> Bree = CalculateShipCoordinates();

            foreach (var bruuu in Bree)
            {
                switch (_fieldType)
                {
                    case EFieldtype.DEFAULT:
                        break;
                    case EFieldtype.SHIP_PLAYER_1:
                        Bapapa.Add(new ShipPlayer1(_origin.X, _origin.Y));
                        break;
                    case EFieldtype.DAMAGED_SHIP_PLAYER_1:
                        Bapapa.Add(new ShipPlayer1(_origin.X, _origin.Y));
                        break;
                    case EFieldtype.SHIP_PLAYER_2:
                        Bapapa.Add(new ShipPlayer2(_origin.X, _origin.Y));
                        break;
                    case EFieldtype.DAMAGED_SHIP_PLAYER_2:
                        Bapapa.Add(new ShipPlayer2(_origin.X, _origin.Y));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return Bapapa;
        }
    }
}