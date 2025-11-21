using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using FluentFTP;
using Newtonsoft.Json;
using System.Data;
using System.Linq;
using System.Net;

namespace ACCLoadResults
{
    public partial class frmLoadData : Form
    {

        public frmLoadData()
        {
            InitializeComponent();
            calDate.Value = DateTime.Now.Date;
        }

        private void frmLoadData_Load(object sender, EventArgs e)
        {
            

            using (var conn = new FtpClient())
            {
                conn.Host = "176.57.168.181";
                conn.Port = 28021;
                conn.Credentials = new NetworkCredential("gpftp20260467362404400", "CLVmbmx6");

                conn.Connect();
                conn.SetWorkingDirectory("results");

                //Get FTP Files
                //Get Files Imported in DB
                //Get Only not exist in DB

                if (chkPracticeData.Checked ==false)
                { 
                    var DifFiles = from c in conn.GetListing()
                                   where !(from Datos in Classes.Globals.oData.Sessions select Datos.LogFileName.ToUpper().Trim()).Contains(c.Name.ToUpper().Trim()) &&
                                         (c.Name.Contains("_R") || c.Name.Contains("_Q")) &&
                                         (c.Modified >= calDate.Value && c.Modified <= calDate.Value.AddDays(1).AddHours(4))
                                   orderby c.Modified descending
                                   select new { c.Name, c.Modified };
                
                    grdAvFiles.DataSource = DifFiles.ToArray();
                }
                else
                {
                    var DifFiles = from c in conn.GetListing()
                                   where !(from Datos in Classes.Globals.oData.Sessions select Datos.LogFileName.ToUpper().Trim()).Contains(c.Name.ToUpper().Trim()) &&                                         
                                         (!c.Name.Contains("entry")) &&
                                         (c.Modified >= calDate.Value)
                                   orderby c.Modified descending
                                   select new { c.Name, c.Modified };

                    grdAvFiles.DataSource = DifFiles.ToArray();
                }

                grdAvFiles.Columns[0].Width = 300;

            }


        }

        private void btnLoadFiles_Click(object sender, EventArgs e)
        {

            string AppPath = AppDomain.CurrentDomain.BaseDirectory;

            prgLoad.Value = 0;

            List<string> FileNames = new List<string>();

            if (grdAvFiles.SelectedRows.Count == 0)
                return;

            for (int pos = 0; pos < grdAvFiles.SelectedRows.Count; pos++)
            {
                //FileNames += grdAvFiles.SelectedRows[pos].Cells["Name"].Value;
                FileNames.Add(grdAvFiles.SelectedRows[pos].Cells["Name"].Value.ToString());
            }


            using (var conn = new FtpClient())
            {
                conn.Host = "176.57.168.181";
                conn.Port = 28021;
                conn.Credentials = new NetworkCredential("gpftp20260467362404400", "CLVmbmx6");

                conn.Connect();
                conn.SetWorkingDirectory("results");

                //Get FTP Files
                //Get Files Imported in DB
                //Get Only not exist in DB

                /*                var DifFiles = from c in conn.GetListing()
                                               where !(from Datos in Classes.Globals.oData.Sessions select Datos.LogFileName.ToUpper().Trim()).Contains(c.Name.ToUpper().Trim())
                                               select c;*/

                var DifFiles = from c in conn.GetListing()
                               where FileNames.Contains(c.Name)
                               select c;


                prgLoad.Maximum = DifFiles.Count();
                lblTotalFiles.Text = DifFiles.Count().ToString();

                int LoadOK = 0;
                int LoadKO = 0;

                //Download Diff FTP Files to PC
                foreach (var file in DifFiles)
                {

                    string JsonFile = string.Empty;


                    if (chkPracticeData.Checked == false)
                        JsonFile = AppPath + @"DownloadFiles\" + file.Name;
                    else
                        JsonFile = AppPath + @"DownloadFilesPractice\" + file.Name;

                    //DownLoad File from G-PORTAL
                    FtpStatus rStatus = conn.DownloadFile(JsonFile, file.Name, FtpLocalExists.Overwrite);

                    if (rStatus != FtpStatus.Success)
                    {
                        MessageBox.Show("Download FTP File Error", "Error", MessageBoxButtons.OK);
                        break;
                    }
                    else
                    {

                        ResultsInfo oResultsInfo;

                        using StreamReader reader = new(JsonFile, System.Text.Encoding.Unicode);
                        var json = reader.ReadToEnd();

                        try
                        {
                            oResultsInfo = JsonConvert.DeserializeObject<ResultsInfo>(json);
                        }
                        catch (Exception ex)
                        {
                            //If read file fails, next file
                            prgLoad.Value++;
                            LoadKO++;
                            lblTotalKO.Text = LoadKO.ToString();
                            continue;
                        }

                        //Create new session Model and Add File info
                        Models.Sessions oSessions = new Models.Sessions();

                        //Create date Value
                        string SessionDate = "20" + file.Name.Substring(0, 6);
                        SessionDate = SessionDate.Substring(6, 2) + "/" + SessionDate.Substring(4, 2) + "/" + SessionDate.Substring(0, 4);

                        //Create Time Value
                        string SessionHour = file.Name.Substring(7, 6);
                        SessionHour = SessionHour.Substring(0, 2) + ":" + SessionHour.Substring(2, 2) + ":" + SessionHour.Substring(4, 2);

                        oSessions.sessionType = oResultsInfo.sessionType;
                        oSessions.trackName = oResultsInfo.trackName;
                        oSessions.LogFileName = file.Name;
                        oSessions.BestLap = Globals.formatTime(oResultsInfo.sessionResult.bestlap);
                        oSessions.BestSector1 = Globals.formatTime(oResultsInfo.sessionResult.bestSplits[0]);
                        oSessions.BestSector2 = Globals.formatTime(oResultsInfo.sessionResult.bestSplits[1]);
                        oSessions.BestSector3 = Globals.formatTime(oResultsInfo.sessionResult.bestSplits[2]);
                        oSessions.IsWet = oResultsInfo.sessionResult.isWetSession;
                        oSessions.SessionDate = DateTime.Parse(SessionDate);
                        oSessions.SessionHour = SessionHour;
                        oSessions.BestLapNumeric = oResultsInfo.sessionResult.bestlap;
                        oSessions.BestSector1Numeric = oResultsInfo.sessionResult.bestSplits[0];
                        oSessions.BestSector2Numeric = oResultsInfo.sessionResult.bestSplits[1];
                        oSessions.BestSector3Numeric = oResultsInfo.sessionResult.bestSplits[2];

                        if (chkPracticeData.Checked == true)
                            oSessions.IsTestSession = true;

                        Globals.oData.Sessions.Add(oSessions);
                        Globals.oData.SaveChanges();

                        //Get new SessionID
                        decimal lIDSession = (from Datos in Globals.oData.Sessions where Datos.LogFileName == oSessions.LogFileName select Datos.ID).First();

                        int position = 1;

                        //Save leaderBoard Data
                        foreach (LeaderBoardLine Data in oResultsInfo.sessionResult.leaderBoardLines)
                        {

                            //Create new 
                            Models.LeaderBoard oLeaderBoard = new Models.LeaderBoard();

                            oLeaderBoard.IDSession = lIDSession;
                            oLeaderBoard.carId = Data.car.carId;
                            oLeaderBoard.carModel = Data.car.carModel;
                            oLeaderBoard.carGroup = Data.car.carGroup;
                            oLeaderBoard.firstName = Data.currentDriver.firstName;
                            oLeaderBoard.lastName = Data.currentDriver.lastName;
                            oLeaderBoard.currentDriverIndex = Data.currentDriverIndex;
                            oLeaderBoard.lastLap = Globals.formatTime(Data.timing.lastLap);

                            if (Data.timing.lastSplits.Count == 3)
                            {
                                oLeaderBoard.LastSector1 = Globals.formatTime(Data.timing.lastSplits[0]);
                                oLeaderBoard.LastSector2 = Globals.formatTime(Data.timing.lastSplits[1]);
                                oLeaderBoard.LastSector3 = Globals.formatTime(Data.timing.lastSplits[2]);

                            }

                            oLeaderBoard.BestLap = Globals.formatTime(Data.timing.bestLap);
                            oLeaderBoard.BestLapNumeric = Data.timing.bestLap;

                            if (Data.timing.bestSplits.Count == 3)
                            {
                                oLeaderBoard.BestSector1 = Globals.formatTime(Data.timing.bestSplits[0]);
                                oLeaderBoard.BestSector2 = Globals.formatTime(Data.timing.bestSplits[1]);
                                oLeaderBoard.BestSector3 = Globals.formatTime(Data.timing.bestSplits[2]);
                                oLeaderBoard.BestSector1Numeric = Data.timing.bestSplits[0];
                                oLeaderBoard.BestSector2Numeric = Data.timing.bestSplits[1];
                                oLeaderBoard.BestSector3Numeric = Data.timing.bestSplits[2];

                            }

                            oLeaderBoard.TotalTime = Globals.formatTime(Data.timing.totalTime);
                            oLeaderBoard.TotalTimeNumeric = Data.timing.totalTime;

                            oLeaderBoard.LapCount = Data.timing.lapCount;
                            oLeaderBoard.missingMandatoryPitstop = Data.missingMandatoryPitstop;
                            oLeaderBoard.Position = position;

                            if (chkPracticeData.Checked == true)
                                oLeaderBoard.IsTestSession = true;

                            Globals.oData.LeaderBoard.Add(oLeaderBoard);
                            position++;

                        }

                        if (oResultsInfo.sessionResult.leaderBoardLines.Any())
                            Globals.oData.SaveChanges();


                        //Save Laps DATA
                        foreach (Classes.Laps Data in oResultsInfo.laps)
                        {

                            //Create new 
                            Models.Laps oLap = new Models.Laps();

                            int LapPlayer = (from Datos in Globals.oData.Laps where Datos.carId == Data.carId && Datos.IDSession == lIDSession select Datos).Count() + 1;

                            oLap.IDSession = lIDSession;
                            oLap.carId = Data.carId;
                            oLap.driverIndex = Data.driverIndex;
                            oLap.numLap = LapPlayer;
                            oLap.laptime = Globals.formatTime(Data.laptime);
                            oLap.LaptimeNumeric = Data.laptime;
                            oLap.isValidForBest = Data.isValidForBest;

                            if (Data.splits.Count == 3)
                            {
                                oLap.Sector1 = Globals.formatTime(Data.splits[0]);
                                oLap.Sector2 = Globals.formatTime(Data.splits[1]);
                                oLap.Sector3 = Globals.formatTime(Data.splits[2]);

                                oLap.Sector1Numeric = Data.splits[0];
                                oLap.Sector2Numeric = Data.splits[1];
                                oLap.Sector3Numeric = Data.splits[2];

                            }

                            if (chkPracticeData.Checked == true)
                                oLap.IsTestSession = true;

                            Globals.oData.Laps.Add(oLap);
                            Globals.oData.SaveChanges();
                        }



                        //Save Penalties
                        foreach (Classes.Penalty Data in oResultsInfo.penalties)
                        {

                            //Create new 
                            Models.penalties openalties = new Models.penalties();

                            openalties.IDSession = lIDSession;
                            openalties.carId = Data.carId;
                            openalties.driverIndex = Data.driverIndex;
                            openalties.reason = Data.reason;
                            openalties.penalty = Data.penalty;
                            openalties.penaltyvalue = Data.penaltyValue;
                            openalties.violationInLap = Data.violationInLap;
                            openalties.clearedInLap = Data.clearedInLap;

                            Globals.oData.penalties.Add(openalties);

                        }

                        if (oResultsInfo.penalties.Any())
                            Globals.oData.SaveChanges();

                        LoadOK++;
                        lblTotalOK.Text = LoadOK.ToString();

                    }

                    prgLoad.Value++;

                }

            }

            MessageBox.Show(this, "Import success!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void calDate_ValueChanged(object sender, EventArgs e)
        {
            frmLoadData_Load(sender, e);
        }
    }
}