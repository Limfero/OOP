namespace bodies
{
    public class CBody
    {
        public double Volume { get; protected set; }
        public double Density { get; protected set; }
        public double Mass { get;  protected set; }

        private static readonly string Info = "Тип тела: {0}\n\tОбъем: {1} м^3\n\tПлотность: {2} кг/м^3\n\tМасса: {3} кг";

        public CBody(double volume, double density)
        {
            Volume = volume;
            Density = density;
            Mass = volume * density;
        }

        public override string ToString()
        {
            return string.Format(Info, this.GetType().Name, Volume, Density, Mass);
        }
    }
}
