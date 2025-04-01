using System.Reflection.Metadata.Ecma335;

namespace PersonalRegister
{
    class Employee
    {
        private string name;
        private string salary;

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
            
            Console.WriteLine("-----------------\nPERSONAL REGISTER\n-----------------"); //Tittel

            do
            {
                menuChoice = MenuPrompt();

                switch (menuChoice)
                {
                    case 1:
                        employeeList.Add(FeedData());
                        Console.WriteLine("Add to list");
                        break;
                    case 2:
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
                Console.WriteLine();
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
            } while (!nameValidated);

            //return Employee with name and salary

            return new Employee(name, salaryString);
        }
    }
}
