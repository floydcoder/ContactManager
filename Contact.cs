using System;
namespace ASGMT_2
{
    public class Contact
    {
        // DATA MEMBERS --> are variable that will be used by the constructor to generate objects

        private string firstName;
        private string lastName;
        private string phone;
        private string email;
        private int dayOfBirth;
        private int monthOfBirth;
        private int yearOfBirth;

        

        // PROPERTIES --> Will allow us to use the private data members through out other classes, by using get and set methods
        // set --> The get method ( accsessor ) returns the value of the data member
        // get --> The set method ( accsessor ) stores a value into the data type ( value rapresents almost a input parameter to set, then it refers to its indicated data member )
        // ENCAPSULATION --> is a safety procedure that will hide sensitive information to the user. like a capsule, data is contained into it.

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public int DayOfBirth { get => dayOfBirth; set => dayOfBirth = value; }
        public int MonthOfBirth { get => monthOfBirth; set => monthOfBirth = value; }
        public int YearOfBirth { get => yearOfBirth; set => yearOfBirth = value; }

        // CONSTRUCTOR --> is a method that is invoked automatically at the moment of object creation. Its goal is to initialize the data members of the new object

        public Contact(string firstName, string lastName, string phone, string email, int dayOfBirth, int monthOfBirth, int yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            DayOfBirth = dayOfBirth;
            MonthOfBirth = monthOfBirth;
            YearOfBirth = yearOfBirth;
        }

        // FUNCTIONALITIES --> can be considered as the behavior of a class, what does it do ?
        // it is important to understand that this methods will allow us to use the data members of this class once we return them.

        public string GetFirstName() 
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetFullName()
        {
            return $"{firstName} {lastName}";
        }

        public string GetPhone()
        {
            return phone;
        }

        public string GetDateOfBirth()
        {
            return $"{dayOfBirth}/{monthOfBirth}/{yearOfBirth}";
        }

        public string GetInfo()
        {
            return "-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" +
                   "\n                   CONTACT INFORMATION                      " +
                   "\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" +
                   "\nNAME:\t" + $"{firstName} {lastName}" +
                   "\nPHONE:\t" + phone +
                   "\nEMAIL:\t" + email +
                   "\nBIRTHDAY:\t" + $"{dayOfBirth}/{monthOfBirth}/{yearOfBirth}" +
                   "\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" +
                    "\n";
        }
    }
}

