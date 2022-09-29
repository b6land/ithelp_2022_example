using System;
using System.Reflection;
public class ReflectionExample:IExample
{
    public void Run(){
        Assembly printDll = Assembly.LoadFrom(@"bin\Debug\net6.0\PrintLibrary.dll");
        Type type = printDll.GetType("PrintLibrary.PrintClass");
        Console.WriteLine(type.ToString());
        var printClass = Activator.CreateInstance(type);
        type.InvokeMember("Print", BindingFlags.InvokeMethod, null, printClass, new object[]{});
        

        Type typeTest = printDll.GetType("PrintLibrary.PrintTestClass");
        Console.WriteLine(typeTest.ToString());
        var printTestClass = Activator.CreateInstance(typeTest);
        if(printTestClass is IReflectionTest){
            IReflectionTest printTest = printTestClass as IReflectionTest;
            printTest.Test();
        }
    }

}