namespace car
{
    internal class Program
    {
        static readonly Car car = new();

        static readonly int ArgumentCount = 2;

        static readonly string[] commands = new string[5] { "Info", "EngineOn", "EngineOff", "SetGear", "SetSpeed" };
        static readonly string EngineOn = "Двигатель включен!";
        static readonly string ErrorEngineOn = "Двигатель не может быть включен!";
        static readonly string EngineOff = "Двигатель выключен!";
        static readonly string ErrorEngineOff = "Двигатель не может быть выключен!";
        static readonly string IncorrectCommand = "Неверная комманда!";
        static readonly string IncorrectSpeedForGear = "Скорость неподходит для переключения передачи!";
        static readonly string IncorrectGear = "Такой передачи не существует!";
        static readonly string IncorrectSpeed = "Не правльное значение скорости!";
        static readonly string SuccessfulGearChange = "Передача успешно сменена!";
        static readonly string SuccessfulSpeedChange = "Скорость успешно изменена!";

        static void Main()
        {
            Console.WriteLine("Список команд:");
            foreach (var command in commands)
                Console.Write("{0} ", command);
            Console.WriteLine();

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");

                ExecuteСommand(command);
            }
        }

        public static void ExecuteСommand(string[] command)
        {
            string commandName = command[0];

            if(commandName == commands[0])
                Info();
            else if(commandName == commands[1])
                Console.WriteLine(car.TurnOnEngine() ? EngineOn : ErrorEngineOn);
            else if(commandName == commands[2])
                Console.WriteLine(car.TurnOffEngine() ? EngineOff : ErrorEngineOff);
            else if(commandName == commands[3] && command.Length == ArgumentCount)
                SetGear(int.Parse(command[1]));
            else if(commandName == commands[4] && command.Length == ArgumentCount)
                SetSpeed(int.Parse(command[1]));
            else
                Console.WriteLine(IncorrectCommand);
        }

        public static void Info()
        {
            Console.WriteLine("Характеристики машины:");
            Console.WriteLine("\tПередача: {0}", car.GetGear());
            Console.WriteLine("\tСкорость: {0}", car.GetSpeed());
            Console.WriteLine("\tСостояние двигателья: {0}", car.IsTurnedOn() ? "включен" : "выключен");
            Console.WriteLine("\tНаправление движения: {0}", car.GetDirection());
        }

        public static void SetGear(int gear)
        {
            int speed = car.GetSpeed();

            if (car.SetGear(gear)) 
                Console.WriteLine(SuccessfulGearChange);
            else if(!Car.Gears.Contains(gear))
                Console.WriteLine(IncorrectGear);
            else
                NotCorrectInput(speed, gear);
        }

        public static void SetSpeed(int speed)
        {
            int gear = car.GetGear();

            if (car.SetSpeed(speed))
                Console.WriteLine(SuccessfulSpeedChange);
            else if(speed > Car.MaxSpeed)
                Console.WriteLine(IncorrectSpeed);
            else
                NotCorrectInput(speed, gear);
        }

        public static void NotCorrectInput(int speed, int gear)
        {
            if (!car.IsTurnedOn())
                Console.WriteLine(EngineOff);
            else if (speed < Car.SpeedLimits[gear + 1].Start.Value || speed > Car.SpeedLimits[gear + 1].End.Value)
                Console.WriteLine(IncorrectSpeedForGear);
        }

    }
}