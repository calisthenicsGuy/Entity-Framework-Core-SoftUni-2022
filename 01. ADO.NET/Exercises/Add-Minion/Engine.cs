using System;
using System.Text;
using System.Linq;
using System.Data.SqlClient;

namespace Add_Minion
{
    public class Engine
    {
        private SqlConnection sqlConnection;
        private SqlTransaction sqlTransaction;

        public Engine(string connectionString)
        {
            this.ConnectionString = connectionString;
            Config();
        }

        private void Config()
        {
            // Connecting with database
            this.sqlConnection = new SqlConnection(ConnectionString);

            // Open the connection
            this.sqlConnection.Open();

            // Create the transaction
            this.sqlTransaction = sqlConnection.BeginTransaction();
        }

        public string ConnectionString { get; }


        public string Run()
        {
            // Initializate StringBuilder
            StringBuilder output = new StringBuilder();

            // Read the input
            string[] minionInfo = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)[1]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string townName = minionInfo[2];
            string villainName = Console.ReadLine()
                .Split(" ").Last();

            // Check if the town existing in database
            try
            {
                string getTownIdQuery = "SELECT [Id] FROM [Towns] WHERE [Name] = @townName";
                SqlCommand getTownIdCmd = new SqlCommand(getTownIdQuery, this.sqlConnection, this.sqlTransaction);
                getTownIdCmd.Parameters.AddWithValue("@townName", townName);
                bool isTownAlreadyExisting = getTownIdCmd.ExecuteScalar() == null ? false : true;

                // If town is not existing - add to database
                if (!isTownAlreadyExisting)
                {
                    string addTownToDatabaseQuery = @"INSERT INTO [Towns]([Name])
                                                           VALUES (@townName)";
                    SqlCommand addTownToDatabaseCmd = 
                        new SqlCommand(addTownToDatabaseQuery, this.sqlConnection, this.sqlTransaction);
                    addTownToDatabaseCmd.Parameters.AddWithValue("@townName", townName);

                    // Execute the query - add new town to database
                    addTownToDatabaseCmd.ExecuteNonQuery();
                    output.AppendLine($"Town {townName} was added to the database.");
                }


                // Check if villain existing in the database
                string getVillainIdQuery = "SELECT [Id] FROM [Villains] WHERE [Name] = @villainName";
                SqlCommand getVillainIdCmd = 
                    new SqlCommand(getVillainIdQuery, this.sqlConnection, this.sqlTransaction);
                getVillainIdCmd.Parameters.AddWithValue("@villainName", villainName);
                bool isVillainExisting = getVillainIdCmd.ExecuteScalar() == null ? false : true;

                // If villain is not existing - add to database 
                if (!isVillainExisting)
                {
                    string addVillainQuery = @"INSERT INTO [Villains]([Name], [EvilnessFactorId])
                                                    VALUES (@villainName, 4)";
                    SqlCommand addVillainCmd = 
                        new SqlCommand(addVillainQuery, this.sqlConnection, this.sqlTransaction);
                    addVillainCmd.Parameters.AddWithValue("@villainName", villainName);

                    // Execute the query - add new villain to database with default EvilnessFactorId (4)
                    addVillainCmd.ExecuteNonQuery();
                    output.AppendLine($"Villain {villainName} was added to the database.");
                }


                // Add minion to database
                string addMinionQuery = @"INSERT INTO [Minions]([Name], [Age], [TownId])
                                               VALUES
                                         (@minionName, @minionAge, @townId)";
                SqlCommand addMinionCmd = new SqlCommand(addMinionQuery, this.sqlConnection, this.sqlTransaction);
                addMinionCmd.Parameters.AddWithValue("@minionName", minionName);
                addMinionCmd.Parameters.AddWithValue("@minionAge", minionAge);
                addMinionCmd.Parameters.AddWithValue("@townId", (int)getTownIdCmd.ExecuteScalar());

                addMinionCmd.ExecuteNonQuery();

                // Get minion Id
                string getMinionIdQuery = @"SELECT [Id] From [Minions] WHERE [Name] = @minionName";
                SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQuery, this.sqlConnection, this.sqlTransaction);
                getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);
                object minionId = (int)getMinionIdCmd.ExecuteScalar();

                string createConnectionBetweenMinionsAndVillainsQuery = 
                    @"INSERT INTO [MinionsVillains]([MinionId], [VillainId]) 
	                       VALUES (@minionId, @villainId)";
                SqlCommand createConnectionBetweenMinionsAndVillainsCmd = 
                    new SqlCommand(createConnectionBetweenMinionsAndVillainsQuery, 
                    this.sqlConnection, this.sqlTransaction);
                createConnectionBetweenMinionsAndVillainsCmd.Parameters.AddWithValue
                    ("@minionId", (int)minionId);
                createConnectionBetweenMinionsAndVillainsCmd.Parameters.AddWithValue("@villainId", 
                    (int)getVillainIdCmd.ExecuteScalar());

                // Execute the SQL command
                createConnectionBetweenMinionsAndVillainsCmd.ExecuteNonQuery();
                output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");

                // Commit the transaction
                this.sqlTransaction.Commit();

                // Close the connection to database
                this.sqlConnection.Close();
            }
            catch (Exception ex)
            {
                this.sqlTransaction.Rollback();
                return ex.Message;
            }

            return output.ToString().TrimEnd();
        }
    }
}