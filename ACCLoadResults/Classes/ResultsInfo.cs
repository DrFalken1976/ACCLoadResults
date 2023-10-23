
namespace ACCLoadResults.Classes
{

    public class ResultsInfo
    {
        public string sessionType { get; set; }
        public string trackName { get; set; }
        public int sessionIndex { get; set; }
        public int raceWeekendIndex { get; set; }
        public string metaData { get; set; }
        public string serverName { get; set; }
        public SessionResult sessionResult { get; set; }
        public List<Laps> laps { get; set; }
        public List<Penalty> penalties { get; set; }
        public List<object> post_race_penalties { get; set; }
    }

    public class Laps
    {
        public int carId { get; set; }
        public int driverIndex { get; set; }
        public long laptime { get; set; }
        public bool isValidForBest { get; set; }
        public List<long> splits { get; set; }
    }

    public class Car
    {
        public int carId { get; set; }
        public int raceNumber { get; set; }
        public int carModel { get; set; }
        public int cupCategory { get; set; }
        public string carGroup { get; set; }
        public string teamName { get; set; }
        public int nationality { get; set; }
        public int carGuid { get; set; }
        public int teamGuid { get; set; }
        public List<Driver> drivers { get; set; }
    }

    public class CurrentDriver
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string shortName { get; set; }
        public string playerId { get; set; }
    }

    public class Driver
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string shortName { get; set; }
        public string playerId { get; set; }
    }



    public class LeaderBoardLine
    {
        public Car car { get; set; }
        public CurrentDriver currentDriver { get; set; }
        public int currentDriverIndex { get; set; }
        public Timing timing { get; set; }
        public bool missingMandatoryPitstop { get; set; }
        public List<double> driverTotalTimes { get; set; }
        public bool bIsSpectator { get; set; }
    }

    public class Penalty
    {
        public int carId { get; set; }
        public int driverIndex { get; set; }
        public string reason { get; set; }
        public string penalty { get; set; }
        public int penaltyValue { get; set; }
        public int violationInLap { get; set; }
        public int clearedInLap { get; set; }
    }

    public class SessionResult
    {
        public long bestlap { get; set; }
        public List<long> bestSplits { get; set; }
        public bool isWetSession { get; set; }
        public int type { get; set; }
        public List<LeaderBoardLine> leaderBoardLines { get; set; }
    }

    public class Timing
    {
        public long lastLap { get; set; }
        public List<long> lastSplits { get; set; }
        public long bestLap { get; set; }
        public List<long> bestSplits { get; set; }
        public long totalTime { get; set; }
        public int lapCount { get; set; }
        public long lastSplitId { get; set; }
    }

}