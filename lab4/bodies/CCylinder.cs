namespace bodies
{
    public class CCylinder : CBody
    {
        public double Radius { get; private set; }
        public double Height { get; private set; }

        private static readonly string Info = "\n\tРадиус основания цилиндра: {0} м\n\tВысота цилиндра: {1} м";

        public CCylinder(double radius, double height, double density) : base(Math.PI * Math.Pow(radius, 2) * height, density)
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
