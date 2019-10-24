/*Program: Refactoring time
 *Programmer: Ivoire Morrell 
 *Date: 10-23-2019
 *Description: This program refactors the previous student 
 * information program using list and StudentInfo objects
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RefactoringTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "What student would you like to get to know? (enter number) \n";
            string searchStudent = "Would you like to learn about another student? (y / n): \n";
            int number;
            bool ok = true;

            //create and initalize StudentInfo objects to prepopulate the student list
            StudentInfo studentOne = new StudentInfo("Kapri Marie", "Detroit, MI", "Speaking", 36);
            StudentInfo studentTwo = new StudentInfo("Propho Picasso", "Lansing, MI", "Writing", 32);
            StudentInfo studentThree = new StudentInfo("Mike Tyson", "Brownsville, NY", "Boxing", 49);
            StudentInfo studentFour = new StudentInfo("Halle Berry", "Clevland, OH", "Acting", 54);
            StudentInfo studentFive = new StudentInfo("Darth Vadar", "Tatooine", "The Force", 45);

            //create a list to hold student objects
            List<StudentInfo> students = new List<StudentInfo>{{studentOne}, {studentTwo}, {studentThree}, {studentFour},  {studentFive}}; 
           
            //prompt the user to the program and display
            Console.WriteLine("Welcome to the student information application! \n");

            //use while loop to determine if user would like to gather information about
            //another user
            while (ok)
            {
                //call the display names menu method
                DisplayStudentNames(students);

                Console.WriteLine();

                //use the ValidateRange method to ensure the user is selecting from the right number range
                number = ValidateRange(message, 1, students.Count + 1);

                Console.WriteLine();

                //pass the number and the student names list to the student info method 
                //to gather more informations about the student
                StudentInfo(number, students);

                //ask the user if they would like to learn about another user 
                ok = GetContinue(searchStudent);
                Console.WriteLine();
            }
            //display exit message
            Console.WriteLine("Thanks!");
        }

        //the add user method

        public static void StudentInfo(int number, List<StudentInfo> students)
        {
            string message = "Would you like to learn more information about this student? (y or n) \n";
            //gather and holds user input for category
            string category;

            //create bool loop to ask user if they want to know more information about the selected student
            bool moreInfo = true;

            //initalize bool to track whether or not the user accessed the right category
            bool rightCategory = false;

            //create an index variable to withdrawl the right student from the list
            int index = number - 1;

            //Display the student that the user selected
            Console.WriteLine("Student " + number + " is "
                + students[index].StudentName + ". \n");

            //wrap code in while loop to determine if the user wantes to know more information about selected student
            while (moreInfo)
            {
                //use while loop to validate the users input
                while (rightCategory == false)
                {
                    Console.WriteLine("What would you like to know about " + students[index].StudentName + "? (enter hometown, skill, or age)" + "\n");

                    category = Console.ReadLine();

                    Console.WriteLine();

                    //check to see if the category equals Hometown or Skills
                    if (category.Equals("hometown", StringComparison.OrdinalIgnoreCase))
                    {
                        //display the students name along with their hometown
                        Console.WriteLine(students[index].StudentName + " is from " + students[index].HomeTown + "\n");
                        rightCategory = true;
                    }
                    else if (category.Equals("skill", StringComparison.OrdinalIgnoreCase))
                    {
                        //display the students name along with their skill
                        Console.WriteLine(students[index].StudentName + "'s skill is " + students[index].Skill + "\n");
                        rightCategory = true;
                    }
                    else if (category.Equals("age", StringComparison.OrdinalIgnoreCase))
                    {
                        //display the students name along with their skill
                        Console.WriteLine(students[index].StudentName + "'s age is " + students[index].Age + "\n");
                        rightCategory = true;
                    }
                    else
                    {
                        //user entered the wrong entry. Prompt them to try again
                        Console.WriteLine("That data does not exist. Please try again. \n");
                        rightCategory = false;
                    }

                }
                //call the getContinue method to determine if the user wants to learn  more information about the selcted student
                rightCategory = false;
                moreInfo = GetContinue(message);
                Console.WriteLine();
               
            }

            //call AddStudent method to process user response
            AddStudent(students);

            Console.WriteLine();
        }
        //the AddStudent method recieves a string variable from the user along
        //with a StudentInfo List and will determine if the user wants to add another 
        public static void AddStudent(List<StudentInfo> list)
        {
            //initialize variables
            string name;
            string homeTown;
            string skill;
            int age;
            bool addStudent = true;
            string message = "Would you like to add another student (y or n)?";
            string answer;
            bool wrongInput = false;

            //ask the user if the would like to add new student
            Console.WriteLine("Would you like to add a student? (y or n) \n");

            answer = Console.ReadLine();

            Console.WriteLine();

            //use while loop to determine if user wants to add another user
            while (addStudent)
            {
                //nest code in another while loop to ensure user enters right input
                while (wrongInput == false)
                { 
                    //determine whether or not to add a user based on the users answer
                    if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        //ask the user for the name, hometown, skill, and age of the new student
                        name = UserInput("Enter student name \n");

                        homeTown = UserInput("Enter students hometown \n");

                        skill = UserInput("Enter students skill \n");

                        age = ParseString("Enter students age \n");

                        Console.WriteLine();

                        //create a StudentInfo object that takes the newly defined variables
                        StudentInfo newStudent = new StudentInfo(name, homeTown, skill, age);

                        //add the new student to the student list
                        list.Add(newStudent);

                        //Tell user the student has been added
                        Console.WriteLine("Student Added \n");

                        Console.WriteLine();

                        wrongInput = true;
                    }
                    else if (answer.Equals("n", StringComparison.OrdinalIgnoreCase))
                    {
                        //display message and set addStudent bool to false
                        Console.WriteLine("No new users added \n");
                        wrongInput = true;
                    }
                    else
                    {
                        //student entered incorrect input
                        Console.WriteLine("Wrong input! Please enter (y or n) \n");
                    }
                }
                //ask the user if they would like to add another user
                wrongInput = false;
                addStudent = GetContinue(message);
            }
        }


        //The DisplayNamesMenu print out the name of each student
        public static void DisplayStudentNames(List<StudentInfo> students)
        {
            int index = 1;

            Console.WriteLine("Student list");
            Console.WriteLine("-------------");

            //use for loop to display the menu
            foreach (StudentInfo person in students)
            {
                Console.WriteLine((index++ + ". ") + person.StudentName);
            }
        }

        public static int ValidateRange(string message, int min, int max)
        {
            int number = ParseString(message);

            if (number >= min && number < max)
            {
                return number;
            }
            else
            {
                //This student does not exist
                Console.WriteLine("This student does not exist.\n");
                return ValidateRange(message, min, max);
            }
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad input. We need a number \n");
                return ParseString(message);
            }

        }

        public static string UserInput(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            Console.WriteLine();

            //check to see if input is alphabet only

            if (Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
            {
                return input;
            }
            else
            {
                //input is not all alphabet. Return message and recall method
                Console.WriteLine("Wrong input! must contain letters only. \n");
                return UserInput(message);
            }
        }

        public static string GetUserInput(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            return input;
        }

        public static bool GetContinue(string message)
        {
            //create variables
            String choice;
            bool ok = true;
            bool result = true;

            //create while loop to determine if user wants to continue
            while (ok)
            {
                Console.WriteLine(message);

                //retrieve user input
                choice = Console.ReadLine();

                //determine the users input and return corresponding message
                if (choice.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    //user wants to continue. exit the while loop and return true
                    ok = false;
                    result = true;
                }
                else if (choice.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    //user does not want to continue
                    ok = false;
                    result = false;
                }
                else
                {
                    //user did not enter y or n
                    Console.WriteLine("Error! Please enter Y or N. Please enter correct input \n");
                }

            }

            return result;
        }
    }
 }

