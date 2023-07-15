namespace bodies
{
    public class Program
    {
        private static readonly List<CBody> bodies = new();

        private static readonly string Start = "Введите информацию о телах (для завершения введите пустую строку):";
        private static readonly string SuccessfulAdditionBody = "Тело успешно добавлено!";
        private static readonly string UnfortunateAdditionBody = "Тело не было добавлено!";

        private static readonly string BodyInformation = "Информация о телах:";
        private static readonly string BodyWithLargestMass = "Тело с наибольшей массой:";
        private static readonly string BodyThatWeighsLeastInWater = "Тело, которое меньше всего весит в воде:";

        private static readonly string IncorrectBodyType = "Некорректный тип тела!";
        private static readonly string IncorrectDensity = "Некорректное значение плотности!";
        private static readonly string IncorrectRadius = "Некорректное значение радиуса!";
        private static readonly string IncorrectHeight = "Некорректное значение высоты!";
        private static readonly string IncorrectWidth = "Некорректное значение ширины!";
        private static readonly string IncorrectLength = "Некорректное значение длины!";

        private static readonly string ReadTypeBody = "Введите тип тела (sphere, parallelepiped, cone, cylinder, compound):";

        // Сфера
        private static readonly string ReadSphereRadius = "Введите радиус сферы (в метрах):";
        private static readonly string ReadSphereDensity = "Введите плотность сферы (в кг/м^3):";

        // Прямоугольник
        private static readonly string ReadParallelepipedLength = "Введите длину прямоугольного параллелепипеда (в метрах):";
        private static readonly string ReadParallelepipedWidth = "Введите ширину прямоугольного параллелепипеда (в метрах):";
        private static readonly string ReadParallelepipedHeight = "Введите высоту прямоугольного параллелепипеда (в метрах):";
        private static readonly string ReadParallelepipedDensity = "Введите плотность прямоугольного параллелепипеда (в кг/м^3):";

        // Конус
        private static readonly string ReadConeRadius = "Введите радиус основания конуса (в метрах):";
        private static readonly string ReadConeHeight = "Введите высоту конуса(в метрах) :";
        private static readonly string ReadConeDensity = "Введите плотность конуса (в кг/м^3):";

        // Цилиндр
        private static readonly string ReadСylinderRadius = "Введите радиус основания цилиндра (в метрах):";
        private static readonly string ReadСylinderHeight = "Введите высоту цилиндра (в метрах):";
        private static readonly string ReadСylinderDensity = "Введите плотность цилиндра (в кг/м^3):";

        // Составное тело
        private static readonly string CountBodyInCompound = "Введите количество вложенных тел в составное тело:";
        private static readonly string BodyNumber = "Тело №{0}:";
        private static readonly string IncorrectCountBody = "Некорректное значение количества вложенных тел!";

        static void Main()
        {
            Console.WriteLine(Start);

            while (true)
            {
                Console.WriteLine(ReadTypeBody);
                string bodyType = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(bodyType))
                    break;

                CBody body = ReadBody(bodyType);

                if (body is null)
                    continue;

                AddBodyInList(body);
                Console.WriteLine(SuccessfulAdditionBody);
            }

            Console.WriteLine(BodyInformation);
            foreach (CBody body in bodies)
            {
                Console.WriteLine(body.ToString());
                Console.WriteLine();
            }
 

            CBody heaviestBody = GetHeaviestBody(bodies);
            Console.WriteLine(BodyWithLargestMass);
            Console.WriteLine(heaviestBody.ToString());
            Console.WriteLine();

            CBody lightestBodyInWater = GetLightestBodyInWater(bodies);
            Console.WriteLine(BodyThatWeighsLeastInWater);
            Console.WriteLine(lightestBodyInWater.ToString());
        }

        public static CBody ReadBody(string bodyType)
        {
            switch (bodyType)
            {
                case "sphere":
                    return ReadSphere();
                case "parallelepiped":
                    return ReadParallelepiped();
                case "cone":
                    return ReadCone();
                case "cylinder":
                    return ReadCylinder();
                case "compound":
                    return ReadCompound();
                default:
                    Console.WriteLine(IncorrectBodyType);
                    return null;
            }
        }

        public static CBody ReadSphere()
        {
            Console.WriteLine(ReadSphereRadius);
            if (double.TryParse(Console.ReadLine(), out double sphereRadius))
            {
                Console.WriteLine(ReadSphereDensity);
                if (double.TryParse(Console.ReadLine(), out double sphereDensity))
                    return new CSphere(sphereRadius, sphereDensity);
                else Console.WriteLine(IncorrectDensity);
            }
            else Console.WriteLine(IncorrectRadius);

            return null;
        }

        public static CBody ReadParallelepiped()
        {
            Console.WriteLine(ReadParallelepipedLength);
            if (double.TryParse(Console.ReadLine(), out double parallelepipedLength))
            {
                Console.WriteLine(ReadParallelepipedWidth);
                if (double.TryParse(Console.ReadLine(), out double parallelepipedWidth))
                {
                    Console.WriteLine(ReadParallelepipedHeight);
                    if (double.TryParse(Console.ReadLine(), out double parallelepipedHeight))
                    {
                        Console.WriteLine(ReadParallelepipedDensity);
                        if (double.TryParse(Console.ReadLine(), out double parallelepipedDensity))
                            return new CParallelepiped(parallelepipedLength, parallelepipedWidth, parallelepipedHeight, parallelepipedDensity);
                        else Console.WriteLine(IncorrectDensity);
                    }
                    else Console.WriteLine(IncorrectHeight);
                }
                else Console.WriteLine(IncorrectWidth);
            }
            else Console.WriteLine(IncorrectLength);

            return null;
        }

        public static CBody ReadCone()
        {
            Console.WriteLine(ReadConeRadius);
            if (double.TryParse(Console.ReadLine(), out double coneRadius))
            {
                Console.WriteLine(ReadConeHeight);
                if (double.TryParse(Console.ReadLine(), out double coneHeight))
                {
                    Console.WriteLine(ReadConeDensity);
                    if (double.TryParse(Console.ReadLine(), out double coneDensity))
                        return new CCone(coneRadius, coneHeight, coneDensity);
                    else Console.WriteLine(IncorrectDensity);
                }
                else Console.WriteLine(IncorrectHeight);
            }
            else Console.WriteLine(IncorrectRadius);

            return null;
        }

        public static CBody ReadCylinder()
        {
            Console.WriteLine(ReadСylinderRadius);
            if (double.TryParse(Console.ReadLine(), out double cylinderRadius))
            {
                Console.WriteLine(ReadСylinderHeight);
                if (double.TryParse(Console.ReadLine(), out double cylinderHeight))
                {
                    Console.WriteLine(ReadСylinderDensity);
                    if (double.TryParse(Console.ReadLine(), out double cylinderDensity))
                        return new CCylinder(cylinderRadius, cylinderHeight, cylinderDensity);
                    else Console.WriteLine(IncorrectDensity);
                }
                else Console.WriteLine(IncorrectHeight);
            }
            else Console.WriteLine(IncorrectRadius);

            return null;
        }

        public static CBody ReadCompound()
        {
            CCompound compound = new();

            Console.WriteLine(CountBodyInCompound);
            if (int.TryParse(Console.ReadLine(), out int count))
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(BodyNumber, i + 1);
                    Console.WriteLine(ReadTypeBody);
                    string bodyType = Console.ReadLine().ToLower();
                      
                    CBody body = ReadBody(bodyType);

                    if (body is null)
                        continue;

                    AddBodyInCompound(body, compound);
                }

                if (compound.Bodies.Count == 0)
                {
                    Console.WriteLine(UnfortunateAdditionBody);
                    return null;
                }
                else return compound;
            }
            else Console.WriteLine(IncorrectCountBody);

            return null;
        }

        public static void AddBodyInList(CBody body) => bodies.Add(body);

        public static void AddBodyInCompound(CBody body, CCompound compound) => compound.AddBody(body);

        public static CBody GetHeaviestBody(List<CBody> bodies)
        {
            CBody heaviestBody = null;
            double maxMass = 0;

            foreach (CBody body in bodies)
            {
                if (body.Mass > maxMass)
                {
                    maxMass = body.Mass;
                    heaviestBody = body;
                }
            }

            return heaviestBody;
        }

        public static CBody GetLightestBodyInWater(List<CBody> bodies)
        {
            CBody lightestBodyInWater = null;
            double minWeightInWater = double.MaxValue;

            foreach (CBody body in bodies)
            {
                double weightInWater = body.Volume * 9.8 * (body.Density - 1000);

                if (weightInWater < minWeightInWater)
                {
                    minWeightInWater = weightInWater;
                    lightestBodyInWater = body;
                }
            }

            return lightestBodyInWater;
        }
    }
}