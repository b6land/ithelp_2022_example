///<summary> 範例程式: Day 13: C# Lambda 語法介紹 </summary>
public class LambdaExample : IExample
{
    public class Employee{
		public string name;
		public string country;
		
		public Employee(string n, string c){
			this.name = n;
			this.country = c;
		}
	}
	
    public void Run()
    {
        Employee[] emp = new Employee[3];
		emp[0] = new Employee("jacky", "taiwan");
		emp[1] = new Employee("annie", "america");
		emp[2] = new Employee("jeff", "taiwan");

        var anonymous = emp.Where(delegate (Employee x) {return x.country.Equals("taiwan"); });
		var lambda = emp.Where(x=>x.country.Equals("taiwan"));
        var lambdaWithBrackets = emp.Where((x)=>x.country.Equals("taiwan"));
		
        foreach(var t in lambdaWithBrackets.AsEnumerable()){
			Console.WriteLine(t.name + ": " + t.country);
		}

		foreach(var t in lambda.AsEnumerable()){
			Console.WriteLine(t.name + ": " + t.country);
		}
    }
}