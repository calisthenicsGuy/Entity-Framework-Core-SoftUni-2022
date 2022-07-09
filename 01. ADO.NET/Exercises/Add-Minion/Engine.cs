using System;
using System.Linq;
using System.Data.SqlClient;

namespace Add_Minion
{
    public class Engine
    {
        public Engine(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public void Run()
        {
            using SqlConnection sqlConnection = new SqlConnection(this.ConnectionString);
            sqlConnection.Open();

            string[] minionInformation = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
            string minionName = minionInformation[1];
            int minionAge = int.Parse(minionInformation[2]);
            string townName = minionInformation[3];

            string getTownIdQuery = "SELECT [Id] FROM [Towns] WHERE [Name] = @Name";
            SqlCommand getTownIdCmd = new SqlCommand(getTownIdQuery, sqlConnection);
            int condition = getTownIdCmd.Parameters.AddWithValue("@Name", townName) != null ? 1 : 0;

            if (condition == 0)
            {
                string addTownQuery = "INSERT INTO [Towns]([Name]) VALUES @townName";
                SqlCommand addTownCmd = new SqlCommand(addTownQuery, sqlConnection);
                addTownCmd.Parameters.AddWithValue("@townName", townName);
                Console.WriteLine($"Town {townName} was added to the database.");
            }


            string addMinionsQuery = "INSERT INTO [Minions] ([Name], [Age], [TownId]) VALUES (@name, @age, @townId)";
            SqlCommand addMinionsCmd = new SqlCommand(addMinionsQuery, sqlConnection);
            addMinionsCmd.Parameters.AddWithValue("@name", minionName);
            addMinionsCmd.Parameters.AddWithValue("@age", minionAge);
            addMinionsCmd.Parameters.AddWithValue("@townId", (int)getTownIdCmd.ExecuteScalar());

            addMinionsCmd.ExecuteNonQuery();


            string villainName = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray().Last();

            string getVillainIdQuery = "SELECT [Id] FROM [Villains] WHERE [Name] = @Name";
            SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQuery, sqlConnection);
            condition = getVillainIdCmd.Parameters.AddWithValue("@Name", villainName) != null ? 1 : 0;

            if (condition == 0)
            {
                string addVillainsQuery = 
                    "INSERT INTO [Villains] ([Name], [EvilnessFactorId]) VALUES (@villainName, 4)";
                SqlCommand addVillainsCmd = new SqlCommand(addVillainsQuery, sqlConnection);
                addVillainsCmd.Parameters.AddWithValue("@villainName", villainName);
                addVillainsCmd.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            else
            {
                string addVillainsQuery =
                    "INSERT INTO [Villains] ([Name], [EvilnessFactorId]) VALUES (@villainName, @id)";
                SqlCommand addVillainsCmd = new SqlCommand(addVillainsQuery, sqlConnection);
                addVillainsCmd.Parameters.AddWithValue("@villainName", villainName);
                addVillainsCmd.Parameters.AddWithValue("@id", (int)getVillainIdCmd.ExecuteScalar());
                addVillainsCmd.ExecuteNonQuery();
            }

        }
    }
}
