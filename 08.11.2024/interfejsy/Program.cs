namespace interfejsy
{
    public interface IAnimal
    {
        void MakeSound();
        void Eat();

    }

    public interface IPet
    {
        void Play();
        void Walk();
    }

    public class Dog : Animal, IAnimal, IPet
    {
        public void Eat()
        {
            Console.WriteLine("Pies je karmę");
        }

        public void MakeSound()
        {
            Console.WriteLine("Hau");
        }

        public void Play()
        {
            Console.WriteLine("Pies bawi się");
        }

        public void Walk()
        {
            Console.WriteLine("Pies idzie na spacer");
        }
    }

    public class Cat : IAnimal
    {
        public void Eat()
        {
            Console.WriteLine("Kot jes karmę");
        }

        public void MakeSound()
        {
            Console.WriteLine("Miau");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();

            dog.MakeSound();
            dog.Eat();
            dog.Play();
            dog.Walk();

            cat.MakeSound();
            cat.Eat();

            Console.ReadKey();
        }
    }
}
