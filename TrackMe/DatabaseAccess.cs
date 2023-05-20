using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Windows.Storage;
using System.IO;


namespace TrackMe
{
    // databaseAccess class with all database operations 
    public class DatabaseAccess
    {

        public DatabaseAccess()
        {
            InitializeDatabase1();
            InitializeDatabase2();
        }

        public async static void InitializeDatabase1()
        {
          //  await Windows.ApplicationModel.Package.Current.InstalledLocation.CreateFileAsync("asset.db", CreationCollisionOption.OpenIfExists);
            await ApplicationData.Current.LocalFolder.CreateFileAsync("asset.db", CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset.db");
            //string dbpath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path,"Database","asset.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                string tableCommand = "CREATE TABLE IF NOT EXISTS asset(Asset_Name NVARCHAR(150) NOT NULL," +
                "Type NVARCHAR(150) NOT NULL," +
                "Description NVARCHAR(150) NOT NULL," +
                "Model NVARCHAR(150) NOT NULL," +
                "Manufacturer NVARCHAR(150) NOT NULL," +
                "Internal_ID NVARCHAR(150) NOT NULL," +
                "MAC NVARCHAR(150) NOT NULL," +
                "IP NVARCHAR(150) NOT NULL PRIMARY KEY," +
                "Physical_Location NVARCHAR(150) NOT NULL," +
                "Purchase_Date NVARCHAR(150) NOT NULL," +
                "Warranty_Information NVARCHAR(150) NOT NULL," +
                "Other_Notes NVARCHAR(150))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
                db.Close();
            }
        }

        public async static void InitializeDatabase2()
        {
          //  await Windows.ApplicationModel.Package.Current.InstalledLocation.CreateFileAsync("asset2.db", CreationCollisionOption.OpenIfExists);
            await ApplicationData.Current.LocalFolder.CreateFileAsync("asset2.db", CreationCollisionOption.OpenIfExists);
            string databasepath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset2.db");
            //string databasepath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Database", "asset2.db");
            using (SqliteConnection database = new SqliteConnection($"Filename={databasepath}"))
            {
                database.Open();

                string tableCommand = "CREATE TABLE IF NOT EXISTS asset2(Software_Product_Name NVARCHAR(150) NOT NULL," +
                "Type NVARCHAR(150) NOT NULL," +
                "Description NVARCHAR(150) NOT NULL," +
                "Version NVARCHAR(150) NOT NULL," +
                "Developer NVARCHAR(150) NOT NULL," +
                "License_Type NVARCHAR(150) NOT NULL," +
                "License_Key NVARCHAR(150) NOT NULL," +
                "Date_Purchased NVARCHAR(150) NOT NULL PRIMARY KEY," +
                "Other_Notes NVARCHAR(150))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, database);

                createTable.ExecuteReader();
                database.Close();
            }
        }

        public class record2
        {
            public string softwareProductName { get; set; }
            public string type { get; set; }
            public string description { get; set; }
            public string version { get; set; }
            public string developer { get; set; }
            public string licenseType { get; set; }
            public string licenseKey { get; set; }
            public string purchaseDate { get; set; }
            public string otherNotes { get; set; }

            public record2(string Software_Product_Name, string Type, string Description, string Version, string Developer, string License_Type, string License_Key, string Purchase_Date, string Other_Notes)
            {
                softwareProductName = Software_Product_Name;
                type = Type;
                description = Description;
                version = Version;
                developer = Developer;
                licenseType = License_Type;
                licenseKey = License_Key;
                purchaseDate = Purchase_Date;
                otherNotes = Other_Notes;
            }
        }

        public static List<record2> GetData2()
        {
            List<record2> entries = new List<record2>();

            string databasepath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset2.db");
            //string databasepath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Database", "asset2.db");
            using (SqliteConnection database = new SqliteConnection($"Filename={databasepath}"))
            {
                database.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * from asset2", database);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(new record2(query.GetString(0), query.GetString(1), query.GetString(2), query.GetString(3), query.GetString(4), query.GetString(5), query.GetString(6), query.GetString(7), query.GetString(8)));
                }

                database.Close();
            }

            return entries;
        }

        public static void AddData1(string Asset_Name, string Type, string Description, string Model, string Manufacturer, string Internal_ID, string MAC, string IP, string Physical_Location, string Purchase_Date, string Warranty_Information, string Other_Notes)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO asset VALUES (@Asset_Name, @Type, @Description, @Model, @Manufacturer, @Internal_ID, @MAC, @IP, @Physical_Location, @Purchase_Date, @Warranty_Information, @Other_Notes);";
                insertCommand.Parameters.AddWithValue("@Asset_Name", Asset_Name);
                insertCommand.Parameters.AddWithValue("@Type", Type);
                insertCommand.Parameters.AddWithValue("@Description", Description);
                insertCommand.Parameters.AddWithValue("@Model", Model);
                insertCommand.Parameters.AddWithValue("@Manufacturer", Manufacturer);
                insertCommand.Parameters.AddWithValue("@Internal_ID", Internal_ID);
                insertCommand.Parameters.AddWithValue("@MAC", MAC);
                insertCommand.Parameters.AddWithValue("@IP", IP);
                insertCommand.Parameters.AddWithValue("@Physical_Location", Physical_Location);
                insertCommand.Parameters.AddWithValue("@Purchase_Date", Purchase_Date);
                insertCommand.Parameters.AddWithValue("@Warranty_Information", Warranty_Information);
                insertCommand.Parameters.AddWithValue("@Other_Notes", Other_Notes);
                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static void AddData2(string Software_Product_Name, string Type, string Description, string Version, string Developer, string License_Type, string License_Key, string Purchase_Date, string Other_Notes)
        {
            string databasepath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset2.db");
            using (SqliteConnection database = new SqliteConnection($"Filename={databasepath}"))
            {
                database.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = database;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO asset2 VALUES (@Software_Product_Name, @Type, @Description, @Version, @Developer, @License_Type, @License_Key, @Purchase_Date, @Other_Notes);";
                insertCommand.Parameters.AddWithValue("@Software_Product_Name", Software_Product_Name);
                insertCommand.Parameters.AddWithValue("@Type", Type);
                insertCommand.Parameters.AddWithValue("@Description", Description);
                insertCommand.Parameters.AddWithValue("@Version", Version);
                insertCommand.Parameters.AddWithValue("@Developer", Developer);
                insertCommand.Parameters.AddWithValue("@License_Type", License_Type);
                insertCommand.Parameters.AddWithValue("@License_Key", License_Key);
                insertCommand.Parameters.AddWithValue("@Purchase_Date", Purchase_Date);
                insertCommand.Parameters.AddWithValue("@Other_Notes", Other_Notes);
                insertCommand.ExecuteReader();

                database.Close();
            }

        }

        public class record
        {
            public string assetName { get; set; }
            public string type { get; set; }
            public string description { get; set; }
            public string model { get; set; }
            public string manufacturer { get; set; }
            public string id { get; set; }
            public string mac { get; set; }
            public string ip { get; set; }
            public string location { get; set; }
            public string purchaseDate { get; set; }
            public string warranty { get; set; }
            public string otherNotes { get; set; }

            public record(string Asset_Name, string Type, string Description, string Model, string Manufacturer, string Internal_ID, string MAC, string IP, string Physical_Location, string Purchase_Date, string Warranty_Information, string Other_Notes)
            {
                assetName = Asset_Name;
                type = Type;
                description = Description;
                model = Model;
                manufacturer = Manufacturer;
                id = Internal_ID;
                mac = MAC;
                ip = IP;
                location = Physical_Location;
                purchaseDate = Purchase_Date;
                warranty = Warranty_Information;
                otherNotes = Other_Notes;
            }
        }


        public static List<record> GetData1()
        {
            List<record> entries = new List<record>();

            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset.db");
            //string dbpath = Path.Combine(Windows.ApplicationModel.Package.Current.InstalledLocation.Path, "Database", "asset.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand("SELECT * from asset", db);

                SqliteDataReader query = selectCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(new record(query.GetString(0), query.GetString(1), query.GetString(2), query.GetString(3), query.GetString(4), query.GetString(5), query.GetString(6), query.GetString(7), query.GetString(8), query.GetString(9), query.GetString(10), query.GetString(11)));
                }

                db.Close();
            }

            return entries;
        }

        public static void UpdateData1(string Asset_Name, string Type, string Description, string Model, string Manufacturer, string Internal_ID, string MAC, string IP, string Physical_Location, string Purchase_Date, string Warranty_Information, string Other_Notes)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "Update asset SET Asset_Name=@assetName, Type=@type, Description=@description, Model=@model, Manufacturer=@manufacturer, Internal_ID=@internalID, MAC=@mac, IP=@ip, Physical_Location=@physicalLocation, Purchase_Date=@purchaseDate, Warranty_Information=@warrantyInformation, Other_Notes=@otherNotes WHERE Asset_Name=@assetName;";
                insertCommand.Parameters.AddWithValue("@assetName", Asset_Name);
                insertCommand.Parameters.AddWithValue("@type", Type);
                insertCommand.Parameters.AddWithValue("@description", Description);
                insertCommand.Parameters.AddWithValue("@model", Model);
                insertCommand.Parameters.AddWithValue("@manufacturer", Manufacturer);
                insertCommand.Parameters.AddWithValue("@internalID", Internal_ID);
                insertCommand.Parameters.AddWithValue("@mac", MAC);
                insertCommand.Parameters.AddWithValue("@ip", IP);
                insertCommand.Parameters.AddWithValue("@physicalLocation", Physical_Location);
                insertCommand.Parameters.AddWithValue("@purchaseDate", Purchase_Date);
                insertCommand.Parameters.AddWithValue("@warrantyInformation", Warranty_Information);
                insertCommand.Parameters.AddWithValue("@otherNotes", Other_Notes);
                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static void UpdateData2(string Software_Product_Name, string Type, string Description, string Version, string Developer, string License_Type, string License_Key, string Date_Purchased, string Other_Notes)
        {
            string databasepath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset2.db");
            using (SqliteConnection database = new SqliteConnection($"Filename={databasepath}"))
            {
                database.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = database;
                insertCommand.CommandText = "Update asset2 SET Software_Product_Name=@softwareProductName, Type=@type2, Description=@description2, Version=@version, Developer=@developer, License_Type=@licenseType, License_Key=@licenseKey, Date_Purchased=@purchaseDate2, Other_Notes=@otherNotes2 WHERE Software_Product_Name=@softwareProductName;";
                insertCommand.Parameters.AddWithValue("@softwareProductName", Software_Product_Name);
                insertCommand.Parameters.AddWithValue("@type2", Type);
                insertCommand.Parameters.AddWithValue("@description2", Description);
                insertCommand.Parameters.AddWithValue("@version", Version);
                insertCommand.Parameters.AddWithValue("@developer", Developer);
                insertCommand.Parameters.AddWithValue("@licenseType", License_Type);
                insertCommand.Parameters.AddWithValue("@licenseKey", License_Key);
                insertCommand.Parameters.AddWithValue("@purchaseDate2", Date_Purchased);
                insertCommand.Parameters.AddWithValue("@otherNotes2", Other_Notes);
                insertCommand.ExecuteReader();

                database.Close();
            }

        }


        public static void DeleteData1(string assetName)
        {
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset.db");
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                insertCommand.CommandText = "DELETE FROM asset WHERE Asset_Name=@assetName;";
                insertCommand.Parameters.AddWithValue("@assetName", assetName);
                insertCommand.ExecuteReader();

                db.Close();
            }

        }

        public static void DeleteData2(string softwareProductName)
        {
            string databasepath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "asset2.db");
            using (SqliteConnection database = new SqliteConnection($"Filename={databasepath}"))
            {
                database.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = database;

                insertCommand.CommandText = "DELETE FROM asset2 WHERE Software_Product_Name=@softwareProductName;";
                insertCommand.Parameters.AddWithValue("@softwareProductName", softwareProductName );
                insertCommand.ExecuteReader();

                database.Close();
            }

        }

        public static async void BackupDB1()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile dboriginal = await localfolder.GetFileAsync("asset.db");
            await dboriginal.CopyAsync(localfolder, "assetbackup.db", NameCollisionOption.ReplaceExisting);
        }

        public static async void BackupDB2()
        {
            StorageFolder localfolder = ApplicationData.Current.LocalFolder;
            StorageFile dboriginal = await localfolder.GetFileAsync("asset2.db");
            await dboriginal.CopyAsync(localfolder, "asset2backup.db", NameCollisionOption.ReplaceExisting);
        }

    }
}
