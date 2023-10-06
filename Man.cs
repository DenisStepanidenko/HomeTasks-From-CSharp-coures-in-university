using System;

namespace ConsoleApplication2
{
    class Man
    {
        protected string name;
        protected int age;
        public Man(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        
        public virtual void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Имя неккоректное");
                return;
            }
            this.name = name;
        }
        public virtual void ChangeAge(int age)
        {
            this.age = age;
        }
        public override string ToString()
        {
            // имя возраст
            var toString = String.Format("Человек: {0}, {1}", name, age);
            return toString;
        }
        // реализация через свойства
        
        // реализация свойства Имя
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Имя неккоректное");
                    return;
                }
                name = value;
            }
        }
        
        // реализация свойства возраст
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        
    }
}