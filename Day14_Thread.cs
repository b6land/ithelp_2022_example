public class ThreadExample: IExample
{
    int n = 0;

    private void AddN(){
        for(int i = 0;i < 50;i++){
            n = n + 1;
        }
    }
    public void Run(){
        Thread threadAdd = new Thread(AddN);
        threadAdd.Start();
        
        Thread threadAdd2 = new Thread(AddN);
        threadAdd2.Start();

        threadAdd.Join();
        threadAdd2.Join();

        Console.WriteLine(n.ToString());
    }
}