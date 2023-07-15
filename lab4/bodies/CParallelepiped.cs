namespace bodies
{
    public class CParallelepiped : CBody
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Depth { get; private set; }

        private static readonly string Info = "\n\tШирина: {0} м\n\tВысота: {1} м\n\tДлина: {2} м";

        public CParallelepiped(double width, double height, double depth, double density) : base(width * height * depth, density)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(Info, Width, Height, Depth);
        }
    }
}
