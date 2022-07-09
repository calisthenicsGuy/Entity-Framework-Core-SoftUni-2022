using System;
using System.Data.SqlClient;

namespace Demo_ADO.NET
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Connecting to the SQL Server
            using SqlConnection sqlConnection = new SqlConnection(Config.connectionString);

            // Open the connection
            sqlConnection.Open();

            //Just for debugging
            Console.WriteLine("Connection comleted!");

            Console.WriteLine(new string('-', 80));

            // Write query (command) that return one row and one column of data()
            string emlpoyeeCountQuery = "SELECT COUNT(*) AS [EmployeeCount] FROM [Employees]";

            // Initializes new sql command with query and database for connection 
            SqlCommand sqlEmployeeCountCmd = new SqlCommand(emlpoyeeCountQuery, sqlConnection);
            // Cast the output data from sql command, because we know what type will be the data
            object numberOfEmployees = (int)sqlEmployeeCountCmd.ExecuteScalar();
            Console.WriteLine($"Employees available: {numberOfEmployees}");

            Console.WriteLine(new string('-', 80));

            // Write new query (command) that return many rows with many columns
            string sqlEmployeesInfoCmd = "SELECT [FirstName], [LastName], [JobTitle] From [Employees]";
            // Initializes new sql command that accepts sql query and database for connection
            SqlCommand sqlEmployeeInfoData = new SqlCommand(sqlEmployeesInfoCmd, sqlConnection);
            using SqlDataReader employeeInfoReader = sqlEmployeeInfoData.ExecuteReader();


            // Read() -> method that return bool value and move cursor on the next row 
            // If have next row return true
            // If have not next row return false and reading of data stops

            int rowNum = 1;
            while (employeeInfoReader.Read())
            {
                object firstName = (string)employeeInfoReader["FirstName"];
                object lastName = (string)employeeInfoReader["LastName"];
                object jobTitle = (string)employeeInfoReader["JobTitle"];

                Console.WriteLine($"#{rowNum++}. {firstName} {lastName} - {jobTitle}");
            }

            // When we stop working with particular database always close (dispose) the connection if we do not use key word "using"
            employeeInfoReader.Close();

            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();

            // SQL injection attack - example

            Console.Write("Enter a job: ");
            string jobTitleEnt = Console.ReadLine(); // enter "  '' OR 1=1 --  "

            string jobTitleEntQuery = @$"SELECT [FirstName], [LastName], [JobTitle] FROM [Employees]
                                                                WHERE [JobTitle] = '{jobTitleEnt}'";

            SqlCommand sqlJobTitleCmd = new SqlCommand(jobTitleEntQuery, sqlConnection);

            using SqlDataReader sqlJobTitleData = sqlJobTitleCmd.ExecuteReader();

            rowNum = 1;
            while (sqlJobTitleData.Read())
            {
                object firstName = (string)sqlJobTitleData["FirstName"];
                object lastName = (string)sqlJobTitleData["LastName"];
                object jobTitle = (string)sqlJobTitleData["JobTitle"];

                Console.WriteLine($"#{rowNum++}. {firstName} {lastName} - {jobTitle}");
            }
            sqlJobTitleData.Close();

            Console.WriteLine();
            jobTitleEnt = null;
            jobTitleEntQuery = null;
            Console.WriteLine();


            // Prevent frrom SQL Injection - use parameters
            Console.Write("Enter a job: ");
            jobTitleEnt = Console.ReadLine();

            jobTitleEntQuery = @$"SELECT [FirstName], [LastName], [JobTitle] FROM [Employees]
                                                          WHERE [JobTitle] = @jobTitle"; // create parameter

            SqlCommand newSqlJobTitleCmd = new SqlCommand(jobTitleEntQuery, sqlConnection);
            newSqlJobTitleCmd.Parameters.AddWithValue("@jobTitle", jobTitleEnt);
            using SqlDataReader newSqlJobTitleData = newSqlJobTitleCmd.ExecuteReader();

            rowNum = 1;
            while (newSqlJobTitleData.Read())
            {
                object firstName = (string)newSqlJobTitleData["FirstName"];
                object lastName = (string)newSqlJobTitleData["LastName"];
                object jobTitle = (string)newSqlJobTitleData["JobTitle"];

                Console.WriteLine($"#{rowNum++}. {firstName} {lastName} - {jobTitle}");
            }
            newSqlJobTitleData.Close();
            sqlConnection.Close();
        }
    }
}