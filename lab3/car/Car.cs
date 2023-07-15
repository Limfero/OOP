namespace car
{
    public class Car
    {
        private bool _isStarted;
        private int _speed;
        private int _gear;
        private string _direction;

        public static readonly Range[] SpeedLimits = new Range[7] { 0..20, 0..MaxSpeed, 0..30, 20..50, 30..60, 40..90, 50..150 };
        public static readonly int MaxSpeed = 150;
        public static readonly int[] Gears = new int[7] { -1, 0, 1, 2, 3, 4, 5 };
        public static readonly string[] Directions = new string[3] { "стоим на месте", "вперед", "назад" };

        public Car()
        {
            _isStarted = false;
            _speed = 0;
            _gear = 0;
            _direction = Directions[0];
        }

        public bool IsTurnedOn() => _isStarted;

        public string GetDirection() => _direction;

        public int GetSpeed() => _speed;

        public int GetGear() => _gear;

        public bool TurnOnEngine()
        {
            if (!IsTurnedOn())
            {
                _isStarted = true;
                return true;
            }

            return false;
        }

        public bool TurnOffEngine()
        {
            if (IsTurnedOn() && GetGear() == 0 && GetDirection() == Directions[0])
            {
                _isStarted = false;
                return true;
            }

            return false;
        }

        public bool SetGear(int gear)
        {
            if (!IsTurnedOn() || !Gears.Contains(gear) || _speed < SpeedLimits[gear + 1].Start.Value || _speed > SpeedLimits[gear + 1].End.Value)
                return false;

            _gear = gear;

            return true;
        }

        public bool SetSpeed(int speed)
        {
            if (!IsTurnedOn() || _gear == 0 && speed > 0 || speed < SpeedLimits[_gear + 1].Start.Value || speed > SpeedLimits[_gear + 1].End.Value)
                return false;

            if (speed == 0)
                _direction = Directions[0];
            else if(_gear == -1)
                _direction = Directions[2];
            else
                _direction = Directions[1];

            _speed = Math.Abs(speed);

            return true;
        }
    }
}
