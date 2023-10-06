using System;

namespace ConsoleApplication2
{
    class Worker : Man
    {
        protected string job;
        public Worker(string name, int age , string job) : base(name, age)
        {
            if (age > 70 || age < 16)
            {
                Console.WriteLine("Возраст неккоректен");
                throw new ArgumentException("Age для подростка должен быть от 16 до 70 лет");
            }

            this.job = job;
        }

        public override string ToString()
        {
            var toString = String.Format("Работник, {0} , {1} \nМесто работы : {2}" , name , age , job);
            return toString;
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
                if (value > 70 || value < 16)
                {
                    Console.WriteLine("Возраст неккоректен");
                    throw new ArgumentException("Age для подростка должен быть от 16 до 70 лет");
                }

                age = value;
            }
        }
        
        // реализация свойства для job
        public String Job
        {
            get
            {
                return job;
            }
            set
            {
                job = value;
            }
        }
    }
}