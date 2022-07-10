using System;
using System.Text;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

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
            // P05: Console.WriteLine(ChangeTownNamesCasing(sqlConnection));
            // P06: Console.WriteLine(RemoveVillain(sqlConnection));
            // P09: Console.WriteLine(IncreaseAgeStoredProcedure(sqlConnection));

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

        // P05: Change Town Names Casing
        private static string ChangeTownNamesCasing(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();

            // Read the given country name
            string countryName = Console.ReadLine();

            // Get Id of the given country 
            string getCountryIdQuery = @"SELECT [Id] FROM [Countries] WHERE [Name] = @countryName";
            SqlCommand getCountryIdCmd = new SqlCommand(getCountryIdQuery, sqlConnection);
            getCountryIdCmd.Parameters.AddWithValue("@countryName", countryName);

            // Check if the country existing in the database
            if (getCountryIdCmd.ExecuteScalar() == null)
            {
                return "The given country does not exist in the database.";
            }
            int countryId = (int)getCountryIdCmd.ExecuteScalar();

            // Update towns which is part of the given country
            string updateTownsToUpperCaseQuery = @"UPDATE [Towns]
                                                      SET [Name] = UPPER([Name])
                                                    WHERE [CountryCode] = @countryId";
            SqlCommand updateTownsToUpperCaseCmd = new SqlCommand(updateTownsToUpperCaseQuery, sqlConnection);
            updateTownsToUpperCaseCmd.Parameters.AddWithValue("@countryId", countryId);

            // Execute the command
            updateTownsToUpperCaseCmd.ExecuteNonQuery();

            // Get names of affected towns
            string getNameOfAffectedTownsQuery = @"SELECT [Name] FROM [Towns] WHERE [CountryCode] = @countryId";
            SqlCommand getNameOfAffectedTownsCmd = new SqlCommand(getNameOfAffectedTownsQuery, sqlConnection);
            getNameOfAffectedTownsCmd.Parameters.AddWithValue("@countryId", countryId);
            
            using SqlDataReader sqlTownsNameReader = getNameOfAffectedTownsCmd.ExecuteReader();

            var affectedTowns = new List<string>();
            while (sqlTownsNameReader.Read())
            {
                affectedTowns.Add((string)sqlTownsNameReader["Name"]);
            }

            // Check if have towns that is affected
            if (affectedTowns.Count == 0)
            {
                output.AppendLine("No town names were affected.");
            }
            else
            {
                output.AppendLine($"{affectedTowns.Count} town names were affected.");
                output.AppendLine($"{string.Join(", ", affectedTowns)}");
            }

            return output.ToString().TrimEnd();
        }

        // PO6: Remove Villain
        private static string RemoveVillain(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();

            int villainId = int.Parse(Console.ReadLine());
            // Get villain id
            string villainNameQuery = $"SELECT [Name] FROM [Villains] WHERE [Id] = @villainId";
            SqlCommand villainNameCmd = new SqlCommand(villainNameQuery, sqlConnection);
            villainNameCmd.Parameters.AddWithValue("@villainId", villainId);
            string villainName = (string)villainNameCmd.ExecuteScalar();

            // Check if villain with given id exist exist in the database
            if (villainName == null)
            {
                // If not exist - return the message:
                return "No such villain was found.";
            }

            // If exist - open the sql transaction
            using SqlTransaction sqlTransaction  = sqlConnection.BeginTransaction();

            try
            {
                // Delete villains id from MinionsVillains table
                string deleteVillainsIdFromMinionsVillainsQuery = 
                    @"DELETE FROM [MinionsVillains] WHERE [VillainId] = @villainId";
                SqlCommand deleteVillainsIdFromMinionsVillainsCmd = 
                    new SqlCommand(deleteVillainsIdFromMinionsVillainsQuery, sqlConnection, sqlTransaction);
                deleteVillainsIdFromMinionsVillainsCmd.Parameters.AddWithValue("@villainId", villainId);

                // Get count of releasesMinion
                int releasesMinion = deleteVillainsIdFromMinionsVillainsCmd.ExecuteNonQuery();

                // Delete villains from Villains table
                string deleteVillaindFromVilliansTableQuery = "DELETE FROM [Villains] WHERE [Name] = @villainName";
                SqlCommand deleteVillaindFromVilliansTableCmd = 
                    new SqlCommand(deleteVillaindFromVilliansTableQuery, sqlConnection, sqlTransaction);
                deleteVillaindFromVilliansTableCmd.Parameters.AddWithValue("@villainName", villainName);

                deleteVillaindFromVilliansTableCmd.ExecuteNonQuery();

                output.AppendLine($"{villainName} was deleted.");
                output.AppendLine($"{releasesMinion} minions were released.");
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                return ex.Message;
            }

            sqlTransaction.Commit();
            return output.ToString().TrimEnd();
        }

        // P09: Increase Age Stored Procedure
        private static string IncreaseAgeStoredProcedure(SqlConnection sqlConnection)
        {
            StringBuilder output = new StringBuilder();

            int minionId = int.Parse(Console.ReadLine());

            string increaseAgeQuery = @"EXEC [dbo].[usp_GetOlder] @minionId";
            SqlCommand icreaseAgeCmd = new SqlCommand(increaseAgeQuery, sqlConnection);
            icreaseAgeCmd.Parameters.AddWithValue("@minionId", minionId);

            using SqlDataReader minionDataReader = icreaseAgeCmd.ExecuteReader();

            if (!minionDataReader.Read())
            {
                return "Minion with given Id does not exist!";
            }

            string minionName = (string)minionDataReader["Name"];
            int minionAge = (int)minionDataReader["Age"];
            output.AppendLine($"{minionName.ToLower()} - {minionAge} years old");

            minionDataReader.Close();
            return output.ToString().TrimEnd();
        }
    }
}