using System.Data.SQLite;
ReadData(CreateConnection());
//InsertCustomer(CreateConnection());
//RemoveCustomer(CreateConnection());
FindCustomer();
static SQLiteConnection CreateConnection()
{
    SQLiteConnection connection = new SQLiteConnection(&quot; Data
    Source = mydb.db; Version = 3; New = True; Compress = True & quot;);
try
{
    connection.Open();
    //Console.WriteLine(&quot;DB found.&quot;);

}
catch
{
    Console.WriteLine(&quot; DB not found.& quot;);
}
return connection;
}

static void ReadData(SQLiteConnection myConnection)
{
    Console.Clear();
    SQLiteDataReader reader;
    SQLiteCommand command;
    command = myConnection.CreateCommand();
    command.CommandText = &quot; SELECT rowid, *FROM customer & quot; ;
    reader = command.ExecuteReader();
    while (reader.Read())
    {
        string readerRowId = reader[&quot; rowid & quot;].ToString();
        string readerStringFirstName = reader.GetString(1);
        string readerStringLastName = reader.GetString(2);
        string readerStringDoB = reader.GetString(3);
        Console.WriteLine($&quot;
        { readerRowId}. Full name: { readerStringFirstName}
{ readerStringLastName}; DoB: { readerStringDoB}
&quot;);
}
myConnection.Close();
}

static void InsertCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;
    string fName, lName, dob;
    Console.WriteLine(&quot; Enter first name: &quot;);
fName = Console.ReadLine();

Console.WriteLine(&quot; Enter last name:&quot;);
lName = Console.ReadLine();
Console.WriteLine(&quot; Enter date of birth (mm-dd-yyyy):&quot;);
dob = Console.ReadLine();
command = myConnection.CreateCommand();
command.CommandText = $&quot; INSERT INTO customer(firstName, lastName,
dateOfBirth) &quot; +
$&quot; VALUES(&#39;{fName}&#39;, &#39;{lName}&#39;, &#39;{dob}&#39;)&quot;;
int rowInserted = command.ExecuteNonQuery();
Console.WriteLine($&quot; Row inserted: { rowInserted}
&quot;);

ReadData(myConnection);
}
static void RemoveCustomer(SQLiteConnection myConnection)
{
    SQLiteCommand command;
    string idToDelete;
    Console.WriteLine(&quot; Enter an id to delete a customer: &quot;);
idToDelete = Console.ReadLine();
command = myConnection.CreateCommand();
command.CommandText = $&quot; DELETE FROM customer WHERE rowid =
{idToDelete}&quot; ;
int rowRemoved = command.ExecuteNonQuery();
Console.WriteLine($&quot;
{ rowRemoved}
was removed from the table customer.&quot;);
ReadData(myConnection);
}
static void FindCustomer()
{
}
