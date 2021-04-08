using System;

namespace Configs
{
    class Program
    {
        static void Main(string[] args)
        {
            Student Jim = new Student("Jim", "Business", 2.8);
            Student Pam = new Student("Pam", "Art", 3.6);

            if(Jim.HasHonors() == true)
            {
                Console.WriteLine("Jim is on honors!");
            }
            if (Pam.HasHonors() == true)
            {
                Console.WriteLine("Pam is on honors!");
            }
            Console.ReadLine();
        }
    }
}
