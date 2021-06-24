using System;
using System.Linq;
using ValidityControl.Models;

namespace ValidityControl
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\nPress (1) for add new person (check null) " +
                "\nPress (2) for exit");

            UserAction();
        }


        private static void UserAction()
        {

            switch (Console.ReadLine())
            {
                case "1":
                    Person p1 = addPerson();
                    Console.WriteLine($"Name: {p1.FName} {p1.LName}\nPersonal NO.: {p1.PersonalNumber}");
                    break;
                case "2":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong input");
                    break;
            }
        }


        public static Person addPerson()
        {
            Person p = ValidityChecker(new Person());
            return p;
        }

        public static Person ValidityChecker(Person person)
        {
            bool isNull = true;
            do
            {
                try
                {
                    Console.WriteLine($"Enter first name");
                    person.FName = Console.ReadLine();
                    isNull = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error! first name should not be null", e.Message);

                };
            } while (isNull);

            do
            {
                try
                {
                    isNull = true;
                    Console.WriteLine($"Enter last name");
                    person.LName = Console.ReadLine();
                    isNull = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error! last name should not be null", e.Message);
                }
            } while (isNull);
            do
            {
                try
                {
                    isNull = true;
                    Console.WriteLine($"Enter personal number");
                    var str = Console.ReadLine();
                    int lastDigit = (int)Char.GetNumericValue(str[12]);
                    if (lastDigit == CheckPN(str))
                    { 
                    person.PersonalNumber = str;
                    isNull = false;
                    } else 
                    {
                       Console.WriteLine($"The personal number not correct YYYYMMDD-XXXX");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"The personal number should be 12 digit in this format YYYYMMDD-XXXX", e.Message);

                }
            } while (isNull);
            
            return person;

        }


        public static int CheckPN(string str)
        {
            int[] arryOfPN = new int[12];
            int totalOfDigits = 0;
            arryOfPN = Array.ConvertAll(str.Remove(8, 1).ToCharArray(), x => (int)x - 48);
            for (int i = 0; i < 11; i++)
            {
                int[] tempUpTen = new int[2];

                if (i >= 2 && i % 2 == 0)
                {

                    if (arryOfPN[i] * 2 < 10)
                    {
                        totalOfDigits = totalOfDigits + arryOfPN[i] * 2;
                    }
                    else
                    {
                        tempUpTen[0] = 1;
                        tempUpTen[1] = arryOfPN[i] * 2 - 10;
                        totalOfDigits = totalOfDigits + tempUpTen[0] + tempUpTen[1];
                    }
                }

                if (i >= 2 && i % 2 != 0)
                {
                    totalOfDigits = totalOfDigits + arryOfPN[i];
                }
            }

            int final = ((totalOfDigits % 10) - 10) * (-1) % 10;
            if (final != arryOfPN[11])
            {
                Console.WriteLine($"Checksum: {final} should be equal to the last digit: {arryOfPN[11]} ");
            }else
            {
                Console.WriteLine($"Checksum: passed successfully! ");

            }
            return final;

        }
    }
}
