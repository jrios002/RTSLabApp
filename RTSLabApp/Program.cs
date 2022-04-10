using System;
using System.Collections.Generic;
using System.Linq;

namespace RTSLabApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = MainMenu();
            while (input == "1" || input == "2" || input == "aboveBelow" || input == "stringRotation")
            {
                try
                {
                    string output = "";
                    Console.WriteLine("\n");
                    if(input == "1" || input == "aboveBelow")
                    {
                        output = AboveBelowTest();
                        Console.WriteLine(output + "\n");
                    }
                    else if(input == "2" || input == "stringRotation")
                    {
                        output = StringRotationTest();
                        Console.WriteLine(output + "\n");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("\nAn error occurred. Please try again.\n" + ex.StackTrace);
                }
                input = MainMenu();
            }
        }

        public static string MainMenu()
        {
            Console.WriteLine("Please select the method you would like to test or enter any other value to exit.");
            Console.WriteLine("1. aboveBelow");
            Console.WriteLine("2. stringRotation");
            return Console.ReadLine();
        }

        public static string StringRotationTest()
        {
            bool validate = false;
            string stringRotationInput = "";
            int count = 0;
            while (!validate)
            {
                if(count != 0) Console.WriteLine("Invalid input, try again.");
                Console.WriteLine("Please enter a string and a positive integer separated by a comma (eg. MyString, 2).");
                stringRotationInput = Console.ReadLine();
                validate = Validate(stringRotationInput, false);
                count++;
            }

            //Assign the rotationValue to a variable
            char[] charArr = stringRotationInput.ToCharArray();
            string rotationValue = "";
            int index = 0;
            string stringValue = "";
            for (int i = stringRotationInput.Length - 1; i >= 0; i--)
            {
                if (charArr[i] != ',')
                {
                    //Get rotation value in case the string has another comma in it
                    rotationValue = rotationValue.Insert(0, charArr[i].ToString());
                }
                else
                {
                    index = i;
                    break;
                }
            }

            //Assign the string value to another variable for the next check.
            for (int i = 0; i < index; i++)
            {
                stringValue += charArr[i];
            }
            Console.WriteLine("output:");
            //Return the stringRotation method output
            return CodingExercise.stringRotation(stringValue, int.Parse(rotationValue));
        }

        public static string AboveBelowTest()
        {
            string aboveBelowInput = "";
            bool validate = false;
            int count = 0;
            while (!validate)
            {
                if(count !=0) Console.WriteLine("Invalid input, try again.");
                Console.WriteLine("Please enter a list of integers inside brackets separated by commas and an integer to compare the list to separated by a comma (eg. [1,5,2,1,10],6)");
                aboveBelowInput = Console.ReadLine();
                validate = Validate(aboveBelowInput, true);
                count++;
            }
            string[] separatedInput = aboveBelowInput.Split("],");
            string listString = separatedInput[0].Replace("[", string.Empty);
            string[] separatedList = listString.Split(",");
            List<int> list = new List<int>();
            foreach(var item in separatedList)
            {
                list.Add(int.Parse(item));
            }
            Console.WriteLine("output:");
            //Return the aboveBelow method ouput
            return CodingExercise.aboveBelow(list, int.Parse(separatedInput[1]));
        }

        public static bool Validate(string input, bool isAboveBelow)
        {
            if(isAboveBelow)
            {
                //Validate brackets were entered
                if(input.Count(x => x == '[') != 1 || input.Count(x => x == ']') != 1)
                {
                    return false;
                }
                else
                {
                    //Validate the comparater was entered correctly and is an integer
                    string[] separatedInput = input.Split("],");
                    if(separatedInput.Length != 2 || !int.TryParse(separatedInput[1], out int value))
                    {
                        return false;
                    }
                    else
                    {
                        //Validate that each value in the list is an integer
                        string list = separatedInput[0].Replace("[", string.Empty);
                        string[] separatedList = list.Split(",");
                        foreach(var item in separatedList)
                        {
                            if (!int.TryParse(item, out int itemVal)) return false;
                        }
                        return true;
                    }
                }
            }
            else
            {
                //Validate the last character of the input is an integer
                char[] charArr = input.ToCharArray();
                int index = 0;
                string rotationValue = "";
                string stringValue = "";

                //Loop backwards to find the location of the comma separator or return false if any character found before the comma separator isn't an integer
                for(int i = input.Length - 1; i >= 0; i--)
                {
                    if(charArr[i] == ',')
                    {
                        if (i == input.Length - 1) return false;
                        index = i;
                        break;
                    }
                    else if (!int.TryParse(charArr[i].ToString(), out int value))
                    {
                        return false;
                    }
                    else
                    {
                        //Get rotation value in case the string has another comma in it
                        rotationValue = rotationValue.Insert(0, charArr[i].ToString());
                    }
                }

                //Validate the comma separator wasn't the very first character in the input and the rotation amount is a positive integer
                if (index == 0 || !int.TryParse(rotationValue, out int checkValue) || int.Parse(rotationValue) < 0)
                {
                    return false;
                }

                //Assign the string value to another variable for the next check.
                for(int i = 0; i < index; i++)
                {
                    stringValue += charArr[i];
                }
                
                //Validate the string isn't empty or whitespace
                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    return false;
                }
                return true;
            }
        }
    }
}
