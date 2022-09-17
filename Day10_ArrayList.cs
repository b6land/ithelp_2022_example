using System.Collections;

public class ArrayListExample : IExample
{
    public void Run()
    {
        ArrayList list = new ArrayList();
        list.Add(123);
        list.Add("123");
        List<int> intList = new List<int>();
        intList.Add(123);
        // intList.Add("123"); // 提示錯誤
    }
}