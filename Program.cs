using System.Collections;
using System.Data;

namespace test
{
    public interface IVehicle{
        public string Turn();
    }
    
    public abstract class Car : IVehicle
    {
        public string Turn()
        {
            return "旋轉方向盤";
        }

        public virtual string Accelerate()
        {
            return "踩油門";
        }
    } 

    public class Bicycle : IVehicle
    {
        public string Turn(){
            return "轉動握把";
        }
    }

    public class Taxi : Car
    {
        
    }

    public class FutureCar: Car
    {
        public override string Accelerate()
        {
            return "按下加速鈕";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bicycle bicycle = new Bicycle();
            Taxi taxi = new Taxi();
            FutureCar futureCar = new FutureCar();

            Console.WriteLine(bicycle.Turn());
            Console.WriteLine(taxi.Turn());
            Console.WriteLine(futureCar.Turn());

            Console.WriteLine(taxi.Accelerate());
            Console.WriteLine(futureCar.Accelerate());

            ArrayList list = new ArrayList();
            list.Add(123);
            list.Add("123");
            List<int> intList = new List<int>();
            intList.Add(123);
            // intList.Add("123"); // 提示錯誤

            DataTable table = GetTable();
            var result = from r in table.AsEnumerable()
                         where (r.Field<string>("City")?? string.Empty).StartsWith("Tai") // 避免 null
                         // select r.Field<int>("ID");
                         select r;
            foreach(var r in result){
                Console.WriteLine($"ID:{r["ID"]}: Name: {r["Name"]}, City: {r["city"]}");
            }             
        }

        static DataTable GetTable(){
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("BirthYear", typeof(int));
            table.Columns.Add("City", typeof(string));

            table.Rows.Add(1, "Ming", 1990, "Taipei");
            table.Rows.Add(2, "Alice", 1991, "Taichung");
            table.Rows.Add(3, "Belly", 1992, "Kaohsiung");
            table.Rows.Add(4, "Peter", 1993, "Taipei");
            return table;
        }
    }

    
}