﻿using College.Domain.Common;

namespace College.Domain.Entities
{
    public class Student
    {
        public string Identification { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public string Address { get; private set; }
        public string Phone { get; private set; }
        public Enums.StateStudent StateStudent { get; private set; }

        public Student() { }

        public void SetIdentification(string identification)
        {
            Identification = identification;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetLastName(string lastName)
        {
            LastName = lastName;
        }
        public void SetAge(int age)
        {
            Age = age;
        }
        public void SetAddress(string address)
        {
            Address = address;
        }
        public void SetPhone(string phone)
        {
            Phone = phone;
        }
        public void SetStateStudent(Enums.StateStudent stateStudent)
        {
            StateStudent = stateStudent;
        }
    }
}