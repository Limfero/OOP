namespace bodies
{
    public class CCompound : CBody
    {
        public List<CBody> Bodies { get; private set; }

        private static readonly string Info = "\nКоличество вложенных тел: {0}\nСодержащиеся тела:";
        private static readonly string AddError = "Попытка добавления составного тела внутрь себя!";

        public CCompound() : base(0, 0)
        {
            Bodies = new List<CBody>();
        }

        public void AddBody(CBody body)
        {
            if (body is CCompound compound && compound.Contains(this))
            {
                Console.WriteLine(AddError);
                return;
            }

            Bodies.Add(body);
            Volume += body.Volume;
            Mass += body.Mass;
            Density = Mass / Volume;
        }

        public bool Contains(CBody body)
        {
            if (Bodies.Contains(body))
                return true;

            foreach (CBody cBody in Bodies)
                if (cBody is CCompound compound && compound.Contains(body))
                    return true;

            return false;
        }

        public override string ToString()
        {
            string result = base.ToString() + string.Format(Info, Bodies.Count);
            foreach (var body in Bodies)
                result += string.Format("\n\t{0}\n", body.ToString());

            return result;
        }
    }
}
