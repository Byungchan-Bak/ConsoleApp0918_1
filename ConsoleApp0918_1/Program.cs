using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0918_1
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;
        }

        public override string ToString()
        {
            string str = $@"******* Person *******
성: { FirstName}  | 이름 : { LastName}
**********************";
            /*
            string str = "******* Person *******\n";
            str += $"성 : {FirstName}  |이름 : {LastName}\n";
            str += "**********************\n";
            */
            return str;
        }

        public void PrintInfo()
        {
            Console.Write("성 : {0}\t이름 : {1}", FirstName, LastName);
        }

        public override bool Equals(object obj)
        {
            /*
            if (obj is Person)
            {
                Person temp = (Person)obj;

                if (this.FirstName == temp.FirstName && this.LastName == temp.LastName)
                    return true;
                else
                    return false;
            }
            else
                return false;
            */
            return obj is Person temp && FirstName == temp.FirstName && LastName == temp.LastName;
        }

        public override int GetHashCode()
        {
            int result = EqualityComparer<string>.Default.GetHashCode(FirstName);
            result += EqualityComparer<string>.Default.GetHashCode(LastName);
            return result ;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person per = new Person("류", "현진" );
            //string str = per.ToString();
            Console.WriteLine(per.ToString());

            /*
            Type t1 = per.GetType();    //인스턴스의 타입을 얻을 때
            Type t2 = typeof(Person);   //클래스의 타입을 얻을 때
            */

            Person per2 = new Person("류", "현진");
            if(per.Equals(per2))
                Console.WriteLine("동일한 이름입니다.");
            else
                Console.WriteLine("다른 이름입니다.");

            string str1 = "류현진";
            string str2 = "류현진";
            if (str1.Equals(str2))
                Console.WriteLine("동일한 이름입니다.");
            else
                Console.WriteLine("다른 이름입니다.");

            Console.WriteLine(per.GetHashCode());
            Console.WriteLine(per2.GetHashCode());
        }
    }
}
