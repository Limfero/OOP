namespace time
{
    public class CTime
    {
        public int Hours { get { return _totalSeconds / 3600; } }
        public int Minutes { get { return _totalSeconds % 3600 / 60; } }
        public int Seconds { get { return _totalSeconds % 60; } }

        private int _totalSeconds;

        private static readonly string Invalid = "INVALID";
        private static readonly string TimeFormat = "{0:D2}:{1:D2}:{2:D2}";

        public CTime(int hours, int minutes, int seconds)
        {
            if (hours > 23 || minutes > 59 || seconds > 59)
                throw new ArgumentException(Invalid);

            _totalSeconds = hours * 3600 + minutes * 60 + seconds;
        }

        public CTime(int timeStamp) => _totalSeconds = timeStamp;

        public static CTime operator ++(CTime time)
        {
            time._totalSeconds++;
            if (time._totalSeconds >= 24 * 3600)
                time._totalSeconds = 0;
            return time;
        }

        public static CTime operator --(CTime time)
        {
            time._totalSeconds--;
            if (time._totalSeconds < 0)
                time._totalSeconds = 24 * 3600 - 1;
            return time;
        }

        public static CTime operator +(CTime time1, CTime time2)
        {
            int totalSeconds = time1._totalSeconds + time2._totalSeconds;
            if (totalSeconds >= 24 * 3600)
                totalSeconds -= 24 * 3600;
            return new CTime(totalSeconds);
        }

        public static CTime operator -(CTime time1, CTime time2)
        {
            int totalSeconds = time1._totalSeconds - time2._totalSeconds;
            if (totalSeconds < 0)
                totalSeconds += 24 * 3600;
            return new CTime(totalSeconds);
        }

        public static CTime operator *(CTime time, int multiplier)
        {
            int totalSeconds = time._totalSeconds * multiplier;
            if (totalSeconds >= 24 * 3600)
                totalSeconds %= 24 * 3600;
            return new CTime(totalSeconds);
        }

        public static CTime operator *(int multiplier, CTime time) => time * multiplier;

        public static CTime operator /(CTime time, int divisor) => new(time._totalSeconds / divisor);

        public static int operator /(CTime time1, CTime time2) => (time2._totalSeconds == 0) ? throw new DivideByZeroException() : time1._totalSeconds / time2._totalSeconds;

        public static bool operator ==(CTime time1, CTime time2) => time1._totalSeconds == time2._totalSeconds;

        public static bool operator !=(CTime time1, CTime time2) => time1._totalSeconds != time2._totalSeconds;

        public static bool operator <(CTime time1, CTime time2) => time1._totalSeconds < time2._totalSeconds;

        public static bool operator >(CTime time1, CTime time2) => time1._totalSeconds > time2._totalSeconds;

        public static bool operator <=(CTime time1, CTime time2) => time1._totalSeconds <= time2._totalSeconds;

        public static bool operator >=(CTime time1, CTime time2) => time1._totalSeconds >= time2._totalSeconds;

        public static explicit operator string(CTime time) => string.Format(TimeFormat, time.Hours, time.Minutes, time.Seconds);

        public static explicit operator CTime(string input) => TryGetTimeFromString(input);

        public static CTime Parse(string input) => TryGetTimeFromString(input);

        private static CTime TryGetTimeFromString(string input)
        {
            try
            {
                string[] parts = input.Split(':');
                int hours = int.Parse(parts[0]);
                int minutes = int.Parse(parts[1]);
                int seconds = int.Parse(parts[2]);
                return new CTime(hours, minutes, seconds);
            }
            catch (Exception)
            {
                throw new ArgumentException(Invalid);
            }
        }

        public override bool Equals(object? obj) => obj != null && obj is CTime time && this._totalSeconds == time._totalSeconds;

        public override int GetHashCode() => (int)_totalSeconds;

        public override string ToString() => (string)this;
    }
}
