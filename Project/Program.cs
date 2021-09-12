using System;

namespace Project
{
    record MyTypes<T,R>(T one, R two)
    {
        public static implicit operator MyTypes<T,R>((T one, R two) a)
        {
            return new MyTypes<T, R>(a.one, a.two);
        }
        public static implicit operator (T one, R two)(MyTypes<T,R> a)
        {
            return (a.one, a.two);
        }
    }
    class Name<T>
    {
        public T t;
        public static implicit operator Name<T>(T na)
        {
            return new Name<T>() { t = na };
        }
        public static implicit operator T(Name<T> na)
        {
            return na.t;
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            new MyClass()
                .Start<Name<(string,string)>>(((string, string))new MyTypes<string,string>("one", "two"));
            Console.ReadKey();
        }
    }
    class MyClass
    {
        public void Start<T>(T t) where T : Name<(string firstName,string LastName)>
        {
            (string firstName, string LastName) one = t;
            Console.WriteLine(one.firstName);
            Console.WriteLine(one.LastName);
            Console.ReadKey();
        }
    }

}
