namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleExample vehicleExample = new VehicleExample();
            vehicleExample.Run();

            ArrayListExample arrayListExample = new ArrayListExample();
            arrayListExample.Run();

            LinqExample linqExample = new LinqExample();
            linqExample.Run();

            LambdaExample lambdaExample = new LambdaExample();
            lambdaExample.Run();

            ThreadExample threadExample = new ThreadExample();
            threadExample.Run();

            EventExample eventExample = new EventExample();
            eventExample.Run();

            DllExample dllExample = new DllExample();
            dllExample.Run();
        }
    }
}