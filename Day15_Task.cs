public class TaskExample: IExample
{
    int n = 0;

    private void AddN(){
        for(int i = 0;i < 50;i++){
            n = n + 1;
        }
    }
    
    private void AddNWithCancel(CancellationToken cancelToken){
        int a = 0;
        for(int i = 0;i < 1000;i++){
            a = a + 1;
            
            if(cancelToken.IsCancellationRequested){
                cancelToken.ThrowIfCancellationRequested();
            }
        }
    }

    public async void Run(){
        Task task = new Task(AddN);
        task.Start();
        task.Wait();
        Console.WriteLine(n.ToString());

        var tokenSource = new CancellationTokenSource();
        CancellationToken cancelToken = tokenSource.Token;

        var task2 = Task.Run(()=> AddNWithCancel(cancelToken), cancelToken);
        tokenSource.Cancel();
        try{
            await task2;
        }
        catch(OperationCanceledException e){
            Console.WriteLine("工作已取消");
        }
    }
}