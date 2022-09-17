///<summary> 範例程式: Day 9: C# 物件導向: Interface, Abstract, Virtual 介紹 </summary>
public class VehicleExample : IExample
{
    protected interface IVehicle
    {
        public string Turn();
    }

    protected abstract class Car : IVehicle
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

    protected class Bicycle : IVehicle
    {
        public string Turn()
        {
            return "轉動握把";
        }
    }

    protected class Taxi : Car
    {

    }

    protected class FutureCar : Car
    {
        public override string Accelerate()
        {
            return "按下加速鈕";
        }
    }

    public void Run()
    {
        Bicycle bicycle = new Bicycle();
        Taxi taxi = new Taxi();
        FutureCar futureCar = new FutureCar();

        Console.WriteLine(bicycle.Turn());
        Console.WriteLine(taxi.Turn());
        Console.WriteLine(futureCar.Turn());

        Console.WriteLine(taxi.Accelerate());
        Console.WriteLine(futureCar.Accelerate());
    }
}

