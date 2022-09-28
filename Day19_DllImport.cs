using System.Runtime.InteropServices;
public class DllExample: IExample{

    static class AddSharp
    {
        internal static class UnsafeNativeMethods
        {
            const string _dllLocation = "DllExample.dll";
            [DllImport(_dllLocation)]
            public static extern int Add(int a, int b);
        }

        public static void Execute(){
            Console.WriteLine(UnsafeNativeMethods.Add(5, 10));
        }
    }
    public void Run(){
        AddSharp.Execute();
        
    }
}