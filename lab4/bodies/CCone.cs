namespace bodies
{
    public class CCone : CBody
    {
        public double Radius { get; private set; }
        public double Height { get; private set; }

        private static readonly string Info = "\n\tРадиус основания конуса: {0} м\n\tВысота конуса: {1} м";

        public CCone(double radius, double height, double density) : base(((double)1 / 3) * Math.PI * Math.Pow(radius, 2) * height, density)
        {
            Radius = radius;
            Height = height;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(Info, Radius, Height);
        }
    }
}
