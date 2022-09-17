using System.Data;

///<summary> 範例程式: Day 12: C# LINQ to DataTable 介紹 </summary>
public class LinqExample : IExample
{
    private DataTable GetTable()
    {
        DataTable table = new DataTable();

        table.Columns.Add("ID", typeof(int));
        table.Columns.Add("Name", typeof(string));
        table.Columns.Add("BirthYear", typeof(int));
        table.Columns.Add("City", typeof(string));

        table.Rows.Add(1, "Ming", 1990, "Taipei");
        table.Rows.Add(2, "Alice", 1991, "Taichung");
        table.Rows.Add(3, "Belly", 1992, "Kaohsiung");
        table.Rows.Add(4, "Peter", 1993, "Taipei");
        return table;
    }

    public void Run(){
        DataTable table = GetTable();
        var result = from r in table.AsEnumerable()
                     where (r.Field<string>("City") ?? string.Empty).StartsWith("Tai") // 避免 null
                     // select r.Field<int>("ID");
                     select r;
        foreach (var r in result)
        {
            Console.WriteLine($"ID:{r["ID"]}: Name: {r["Name"]}, City: {r["city"]}");
        }
    }
}