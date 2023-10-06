using System;
using System.Security.Permissions;

namespace ConsoleApplication2
{
    class Teenager : Man
    {
        protected string school;
        public Teenager(string name, int age , string school) : base(name, age)
        {
            if (age < 13 || age > 19)
            {
                Console.WriteLine("Возраст неккоректен");
                throw new ArgumentException("Age для подростка должен быть от 13 до 19 лет");

            }

            this.school = school;
        }

        public override string ToString()
        {
            var toString = String.Format("{0},{1}, место учёбы: {2}", name, age, school);
            return toString;
        }

        public override void ChangeAge(int age)
        {
            if (age < 13 || age > 19)
            {
                Console.WriteLine("Возраст неккоректен");
                throw new ArgumentException("Age для подростка должен быть от 13 до 19 лет");
            }

            this.age = age;

        }
        
        // реализация свойств
        // реализация свойства возраст
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 13 || value > 19)
                {
                    Console.WriteLine("Возраст неккоректен");
                    throw new ArgumentException("Age для подростка должен быть от 13 до 19 лет");
                }

                age = value;
            }
        }
        
        // реализация свойства для поля school
        public String School
        {
            get
            {
                return school;
            }
            set
            {
                school = value;
            }
        }
    }
}