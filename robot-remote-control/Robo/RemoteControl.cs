using System;
using System.Collections.Generic;

namespace Robo
{
    // Da "Löschen Sie alle Elemente der _history" für mich keinen Sinn macht habe ich es anders gemacht.
    
    public class RemoteControl
    {
        private Robot _robot;
        private Stack<ACommand> _commands;
        private Stack<ACommand> _history;

        public RemoteControl(Robot robot)
        {
            this._robot = robot;
        }

        public bool MoveUp()
        {
            Map mappy = Map.GetInstance();
            if (mappy.IsMoveLegal(_robot, EDirectionType.NORTH))
            {
                _commands.Push(new MoveUpCommand(_robot));
                _commands.Peek().Process();
                _history.Push(_commands.Peek());
                
                return true;
            }

            return false;
        }
        
        public bool MoveRight()
        {
            Map mappy = Map.GetInstance();
            if (mappy.IsMoveLegal(_robot, EDirectionType.EAST))
            {
                _commands.Push(new MoveRightCommand(_robot));
                _commands.Peek().Process();
                _history.Push(_commands.Peek());
                
                return true;
            }

            return false;
        }
        public bool MoveDown()
        {
            Map mappy = Map.GetInstance();
            if (mappy.IsMoveLegal(_robot, EDirectionType.SOUTH))
            {
                _commands.Push(new MoveDownCommand(_robot));
                _commands.Peek().Process();
                _history.Push(_commands.Peek());
                
                return true;
            }

            return false;
        }
        
        public bool MoveLeft()
        {
            Map mappy = Map.GetInstance();
            if (mappy.IsMoveLegal(_robot, EDirectionType.WEST))
            {
                _commands.Push(new MoveLeftCommand(_robot));
                _commands.Peek().Process();
                _history.Push(_commands.Peek());
                
                return true;
            }

            return false;
        }

        public bool Do()
        {
            switch (this._history.Peek())
            {
                case MoveDownCommand moveDownCommand:
                    if (MoveDown())
                    {
                        return true;
                    }
                    break;
                case MoveLeftCommand moveLeftCommand:
                    if (MoveLeft())
                    {
                        return true;
                    }
                    break;
                case MoveRightCommand moveRightCommand:
                    if (MoveRight())
                    {
                        return true;
                    }
                    break;
                case MoveUpCommand moveUpCommand:
                    if (MoveUp())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        public bool Undo()
        {
            switch (this._history.Peek())
            {
                case MoveDownCommand moveDownCommand:
                    if (MoveUp())
                    {
                        return true;
                    }
                    break;
                case MoveLeftCommand moveLeftCommand:
                    if (MoveRight())
                    {
                        return true;
                    }
                    break;
                case MoveRightCommand moveRightCommand:
                    if (MoveLeft())
                    {
                        return true;
                    }
                    break;
                case MoveUpCommand moveUpCommand:
                    if (MoveDown())
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }
    }
}