
namespace ACCLoadResults.Classes
{
    static class Globals
    {

        public static Models.DataContext? oData;

        public const string RacevsQualyHidenFields = "TrackName, CarModel, IDSession, IDQualySession, SessionDate, RaceMeteorology, HotLapRace, PolePosition";
        public const string PenaltiesHidenFields = "IDSession";

        public const string EntriesINITEntries = @"
        {
            ""entries"": 
            [
                {0}
            ],
            ""configVersion"": 1
        }";


        public const string EntriesINITDriver = @"
                {
                    ""firstName"": ""{0}"",
                    ""lastName"": ""{1}"",
                    ""shortName"": ""{2}"",
                    ""driverCategory"": {3},
                    ""playerID"": ""{4}""
                }";


        public const string EntriesAddTeam = @"
            {   
                ""drivers"": 
                [
                    [0]
                ],
                ""customCar"": """",
                ""raceNumber"": 1,
                ""forcedCarModel"": -1,
                ""overrideDriverInfo"": 1,
                ""isServerAdmin"": 1,
                ""configVersion"": 0
            }";

        public const string EventRules = @",
                                          ""driverStintTimeSec"": {0},
                                          ""maxTotalDrivingTime"": {1},
                                          ""maxDriversCount"": {2}";


        public const string Weather = @"
                                        ""rain"": {0},
                                        ""cloudLevel"": {1},
                                        ""ambientTemp"": {2},
                                        ""weatherRandomness"": 0";



        /// <summary>
        /// Transform ACC Time format to M/S/Mil
        /// </summary>
        /// <param name="time_ms"></param>
        /// <returns></returns>
        public static string formatTime(long time_ms)
        {
            decimal ms = time_ms % 1000;
            decimal time_s = (time_ms - ms) / 1000;
            decimal s = time_s % 60;
            decimal m = (time_s - s) / 60;

            return m.ToString() + ':' + s.ToString().PadLeft(2, '0') + '.' + ms.ToString().PadLeft(3, '0');
        }

        public static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
