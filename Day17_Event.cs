public class EventExample: IExample
{
    public class Countdown 
    {
        int internalCounter;

        public event EventHandler? CountdownCompleted;  

        public Countdown(int n){
            internalCounter = n;
        }

        protected virtual void OnCountdownCompleted(EventArgs e)
        {
            if (CountdownCompleted != null)
                CountdownCompleted(this, e);
        } 

        public void Decrement()
        {
            internalCounter = internalCounter - 1;
            if (internalCounter == 0)
                OnCountdownCompleted(new EventArgs());
        }
    }

    public class Receiver{
        public void Tip(object? sender , EventArgs eventArgs){
            Console.WriteLine("Tip!!!");
        }

        public void Run(){
            Countdown countdown = new Countdown(3);
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