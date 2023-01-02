public class EventExample: IExample
{
    // Day 18: C# Event 2
    public class CountdownEventArgs:EventArgs
    {
        public string name;

        public CountdownEventArgs(string name){
            this.name = name;
        }
    }
    
    public class Countdown 
    {
        int internalCounter;
        string name;

        public delegate void CountDownEventHandler(object sender, CountdownEventArgs e);  
        public event CountDownEventHandler? CountdownCompleted;

        public Countdown(int n, string name){
            internalCounter = n;
            this.name = name;
        }

        protected virtual void OnCountdownCompleted(CountdownEventArgs e)
        {
            if (CountdownCompleted != null)
                CountdownCompleted(this, e);
        } 

        public void Decrement()
        {
            internalCounter = internalCounter - 1;
            if (internalCounter == 0)
                OnCountdownCompleted(new CountdownEventArgs(name));
        }
    }

    public class Receiver{
        public void Tip(object? sender , CountdownEventArgs eventArgs){
            Console.WriteLine(eventArgs.name + ": Tip!!!");
        }

        public void Run(){
            Countdown countdown = new Countdown(3, "Example");
            countdown.CountdownCompleted += Tip;
            countdown.Decrement();
            countdown.Decrement();
            countdown.Decrement();
        }
    }

    public void Run(){
        Receiver r = new Receiver();
        r.Run();
    }
}