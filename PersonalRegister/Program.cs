using System.Reflection.Metadata.Ecma335;

namespace PersonalRegister
{
    class Employee
    {
        public string name;
        public string salary;

        public Employee(string n, string s)
        {
            name = n;
            salary = s;
        }
    }
    internal class Program
    {   

        static void Main(string[] args)
        {
            byte menuChoice;
            bool exit = false;
            List<Employee> employeeList = new List<Employee>();

            //Titel
            Console.WriteLine("-----------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PERSONAL REGISTER");
            Console.ResetColor();
            Console.WriteLine("-----------------");

            do
            {
                menuChoice = MenuPrompt();

                switch (menuChoice)
                {
                    case 1:
                        employeeList.Add(FeedData());
                        break;
                    case 2:
                        PrintEmployeesList(employeeList);
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        break;
                }
            } while (!exit);
            
        }

        static byte MenuPrompt()
        {
            bool validated = false;
            byte returnValue;
            string answer;

            do
            {
                Console.WriteLine();
                Console.WriteLine("-----------MENU-----------");
                Console.WriteLine("1 - Introduce an employee.");
                Console.WriteLine("2 - List all employees.");
                Console.WriteLine("3 - Exit.");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Select a number from the menu.");

                answer = Console.ReadLine();

                bool isValid = byte.TryParse(answer, out returnValue);
                if (isValid)
                {
                    if (returnValue>0 && returnValue < 4)
                    {
                        validated = true;
                    }
                    else
                    {
                        WrongChoiceMessage();
                    }
                }
                else
                {
                    WrongChoiceMessage();
                }

            } while (!validated);

            return returnValue;

            static void WrongChoiceMessage()
            {
                Console.WriteLine("Enter a valid input.");
            }
        }

        static Employee FeedData()
        {
            bool nameValidated=false;
            bool salaryValidated=false;
            string answer="";
            int salary;
            string salaryString ="";
            string name="";
            Console.WriteLine("");

            //feed name
            do
            {
                Console.WriteLine("Enter the employee's name");
                answer = Console.ReadLine();
                if (answer.Length >2)
                {
                    nameValidated = true;
                    name= answer;
                }
            } while (!nameValidated);

            //feed lön

            do
            {
                Console.WriteLine("Enter the employee's salary");
                answer = Console.ReadLine();

                bool isValid = int.TryParse(answer, out salary);

                if (isValid)
                {
                    salaryValidated = true;
                    salaryString = answer;
                }
                else
                {
                    Console.Write("Salary not valid. ");
                }
            } while (!salaryValidated);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Employee successfully created.");
            Console.ResetColor();

            //return Employee with name and salary

            return new Employee(name, salaryString);
        }

        static void PrintEmployeesList(List<Employee>employeesList)
        {
            if (employeesList.Count > 0)
            {
                Console.WriteLine("");
                Console.WriteLine("-------EMPLOYEE LIST-------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Employee            Salary");
                Console.ResetColor();

                foreach (Employee e in employeesList)
                {
                    
                    Console.Write(e.name);
                    string spaces = "                    ";
                    spaces = spaces.Substring(0, 20-e.name.Length);
                    Console.Write(spaces);
                    Console.Write(e.salary);
                    Console.Write("\n");

                }
                Console.WriteLine("--------------------------");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("There are no employees in the list.");
                Console.WriteLine("");
            }
            Console.WriteLine("Press ENTER to go back to the Menu.");
            Console.ReadLine();


        }
    }
}
