using System;
using System.Text;
using System.Linq;
using System.Data.SqlClient;

namespace Villain
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection(Config.connectionString);
            sqlConnection.Open();

            // P02: Console.WriteLine(VillainNames(sqlConnection));
            // P03: Console.WriteLine(MinionNames(sqlConnection));

            sqlConnection.Close();
        }


        // P02. Villain Names
        private static string VillainNames(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();

            string sqlVillainsNameQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount
                                            FROM Villains AS v
                                            JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                            GROUP BY v.Id, v.Name
                                            HAVING COUNT(mv.VillainId) > 3
                                            ORDER BY COUNT(mv.VillainId)";

            SqlCommand cmd = new SqlCommand(sqlVillainsNameQuery, sqlConnection);
            using SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                object name = (string)dataReader["Name"];
                object minionsCount = (int)dataReader["MinionsCount"];

                output.AppendLine($"{name} - {minionsCount}");
            }
            dataReader.Close();

            return output.ToString().TrimEnd();
        }

        // P03. Minion Names
        private static string MinionNames(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();

            string villainId = Console.ReadLine();

            string villainNameQuery = @"SELECT [Name]
                                          FROM [Villains]
                                         WHERE [Id] = @Id";

            SqlCommand villainNameCmd = new SqlCommand(villainNameQuery, sqlConnection);
            villainNameCmd.Parameters.AddWithValue("@Id", villainId);

            if (String.IsNullOrWhiteSpace((string)villainNameCmd.ExecuteScalar()))
            {
                return $"No villain with ID {villainId} exists in the database.";
            }
            output.AppendLine($"Villain: {(string)villainNameCmd.ExecuteScalar()}");

            string minionsQuery = @"SELECT [m].[Name] 
                                        AS [Name],
	                                       [m].[Age]
                                        AS [Age]
                                      FROM [MinionsVillains] AS[mv]
                                 LEFT JOIN [Minions] AS[m]
                                        ON [mv].[MinionId] = [m].[Id]
                                     WHERE [mv].[VillainId] = @Id
                                  ORDER BY [m].[Name]";

            SqlCommand minionsCmd = new SqlCommand(minionsQuery, sqlConnection);
            minionsCmd.Parameters.AddWithValue("@Id", villainId);
            using SqlDataReader minionsDataReader = minionsCmd.ExecuteReader();

            int rowNumber = 1;
            while (minionsDataReader.Read())
            {
                object name = (string)minionsDataReader["Name"];
                object age = (int)minionsDataReader["Age"];

                output.AppendLine($"{rowNumber++}. {name} {age}");
            }
            minionsDataReader.Close();


            return output.ToString().TrimEnd();
        }
    }
}
