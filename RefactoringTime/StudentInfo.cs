using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringTime
{
    class StudentInfo
    {
        //initialize class variables
        string studentName;
        string homeTown;
        string skill;
        int age;

        //intialize class constructors
        public StudentInfo()
        {

        }
        
        public StudentInfo(string name, string town, string ability, int number)
        {
            //set each object varible to the variables passed through the parameters
            studentName = name;
            homeTown = town;
            skill = ability;
            age = number;
        }

        //create getter and setter methods for each variable
        public string StudentName 
        { 
          get => studentName; 
          set => studentName = value; 
        }

        public string HomeTown 
        { 
            get => homeTown; 
            set => homeTown = value;
        
        }

        public string Skill 
        { 
            get => skill; 
            set => skill = value; 
        }

        public int Age 
        { 
            get => age; 
            set => age = value; 
        }

        
    }
}
