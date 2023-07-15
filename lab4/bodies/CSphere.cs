namespace bodies
{
    public class CSphere : CBody
    {
        public double Radius { get; private set; }

        private static readonly string Info = "\n\tРадиус сферы: {0} м";
        public CSphere(double radius, double density) : base(((double)4 / 3) * Math.PI * Math.Pow(radius, 3), density)
        {
            Radius = radius;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(Info, Radius);
        }
    }
}
