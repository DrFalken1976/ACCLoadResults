using ACCLoadResults.Classes;
using ACCLoadResults.Models;
using System.Data;
using System.Reflection;

namespace ACCLoadResults.Forms
{

    public partial class frmRaceAnalysis : Form
    {

        const string sJavaScript = @"<script lang=""javascript"">
                                            function openLaps(evt, objName) {
                                                // Declare all variables
                                                var i, tabcontent, tablinks;
        
                                                // Get all elements with class=""tabcontent"" and hide them
                                                tabcontent = document.getElementsByClassName(""tabcontent"");
                                                for (i = 0; i < tabcontent.length; i++) {

                                                    if(objName.includes(""p1"") && tabcontent[i].id.includes(""p2""))
                                                        continue;
                                                    else if(objName.includes(""p2"") && tabcontent[i].id.includes(""p1""))
                                                        continue;


                                                    tabcontent[i].style.display = ""none"";
                                                }
        
                                                // Get all elements with class=""tablinks"" and remove the class ""active""
                                                tablinks = document.getElementsByClassName(""tablinks"");
                                                for (i = 0; i < tablinks.length; i++) {
                                                    
                                                    tablinks[i].className = tablinks[i].className.replace("" active"", """");
                                                }
        
                                                // Show the current tab, and add an ""active"" class to the button that opened the tab
                                                document.getElementById(objName).style.display = ""block"";
                                                evt.currentTarget.className += "" active"";
                                            }
                                        </script>";

        const string sStyles = @"<style>
                                        /* Style the tab */
                                        .tab {
                                        overflow: hidden;
                                        border: 1px solid #ccc;
                                        background-color: white;
                                        }

                                        /* Style the buttons that are used to open the tab content */
                                        .tab button {
                                        background-color: inherit;
                                        float: left;
                                        border: none;
                                        outline: none;
                                        cursor: pointer;
                                        padding: 14px 16px;
                                        transition: 0.3s;
                                        }

                                        /* Change background color of buttons on hover */
                                        .tab button:hover {
                                        background-color: Gold;
                                        }

                                        /* Create an active/current tablink class */
                                        .tab button.active {
                                        background-color: Gold;
                                        }

                                        /* Style the tab content */
                                        .tabcontent {
                                        display: none;
                                        padding: 6px 12px;
                                        border: 0px solid #ccc;
                                        border-top: none;
                                        }

                                        .tabcontent {
                                        animation: fadeEffect 1s; /* Fading effect takes 1 second */
                                        }

                                        /* Go from zero to full opacity */
                                        @keyframes fadeEffect {
                                        from {opacity: 0;}
                                        to {opacity: 1;}
                                        }
                                    </style>";


        private string _html = string.Empty;
        string _IDSession = string.Empty;
        Sessions _Sessions = null;

        public frmRaceAnalysis()
        {
            InitializeComponent();
        }

        private void btnGenHTML_Click(object sender, EventArgs e)
        {

            _html = string.Empty;

            if (grdRaces.CurrentRow != null)
                _IDSession = grdRaces.CurrentRow.Cells[1].Value.ToString();
            else
            {
                MessageBox.Show("Select session to export", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_IDSession != string.Empty)
            {

                if (Globals.oData.Sessions.Where(w => w.ID == long.Parse(_IDSession)).Any())
                {

                    _Sessions = Globals.oData.Sessions.Where(w => w.ID == long.Parse(_IDSession)).First();

                    if (GenerateHTML_Classification() == true)
                    {

                        //Draw RaceQualyInfo
                        if (_Sessions.IDQualySession != null)
                            GenerateHTML_LapsInfo(_Sessions.IDQualySession.ToString(), "Qualy laps info", true);

                        //Draw RaceLapsInfo
                        if (_Sessions.IDQualySession != null)
                            GenerateHTML_LapsInfo(_IDSession, "Race laps info", false);
                        else
                            GenerateHTML_LapsInfo(_IDSession, "Race laps info", true);

                        //Draw Camparite laps
                        GenerateHTML_CompareLaps(_IDSession);

                        //Draw Qualy Penalities
                        if (_Sessions.IDQualySession != null)
                            GenerateHTML_PenaltiesInfo(_Sessions.IDQualySession.ToString(), "Qualy penalties");

                        //Draw Race Penalities
                        GenerateHTML_PenaltiesInfo(_IDSession, "Race penalties");

                        //Draw Chart Possition by Lap
                        GenerateHTML_ChartPosByLap();

                    }

                    //END BODY & HTML
                    _html += "</body>" + Environment.NewLine;
                    _html += "</HTML>" + Environment.NewLine;

                    string strPathFiles = "";
                    string AppPath = AppDomain.CurrentDomain.BaseDirectory;
                    string PathNewDir = "Session_" + _Sessions.trackName.Trim() + "_" + _Sessions.SessionDate.ToString("ddMMyyyy") + "_" + _Sessions.ID.ToString();
                    string PathAssets = AppPath + @"\Assets";
                    string strZipName = AppPath + @"\RaceDataFiles\" + PathNewDir + ".zip";

                    Directory.SetCurrentDirectory(AppPath + @"\RaceDataFiles");
                    Directory.CreateDirectory(PathNewDir);
                    Directory.SetCurrentDirectory(AppPath + @"\RaceDataFiles\" + PathNewDir);

                    File.WriteAllText(@_Sessions.trackName.Trim() + "_" + _Sessions.SessionDate.ToString("ddMMyyyy") + "_" + _Sessions.ID.ToString() + ".htm", _html);

                    //Copy Asset files
                    Globals.CopyDirectory(PathAssets, AppPath + @"\RaceDataFiles\" + PathNewDir + @"\Assets", true);

                    //Create ZIP File
                    System.IO.Compression.ZipFile.CreateFromDirectory(AppPath + @"\RaceDataFiles\" + PathNewDir, strZipName);

                    MessageBox.Show("Race Data file generated!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        bool GenerateHTML_PenaltiesInfo(string IDSession, string DataTitle)
        {

            string htmlPart = string.Empty;

            try
            {


                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<b style='color: Gold; font-size: 15pt;font-family:verdana'>" + DataTitle + "</b>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;

                //Table start.
                htmlPart += "<table style='width:75%;'>" + Environment.NewLine;

                //Adding HeaderRow.
                htmlPart += "<tr>" + Environment.NewLine;

                var PenaltiesData = typeof(vSessionPenalties).GetProperties();

                foreach (PropertyInfo column in PenaltiesData)
                {

                    string strHidenTD = string.Empty;
                    if (Globals.PenaltiesHidenFields.Contains(column.Name))
                        strHidenTD = "display:none;";

                    htmlPart += "<th style='text-align: center; color: white; background-color: rgb(100, 97, 97);border: 0px solid #ccc;" + strHidenTD + "'>" + column.Name + "</th>" + Environment.NewLine;
                }
                htmlPart += "</tr>" + Environment.NewLine;

                List<vSessionPenalties> oDataP = (from Datos in Globals.oData.vSessionPenalties where Datos.IDSession == decimal.Parse(IDSession) select Datos).ToList();

                //Adding DataRow.
                foreach (vSessionPenalties row in oDataP)
                {
                    htmlPart += "<tr>" + Environment.NewLine;


                    foreach (PropertyInfo cell in PenaltiesData)
                    {
                        string strHidenTD = string.Empty;
                        if (Globals.RacevsQualyHidenFields.Contains(cell.Name))
                            strHidenTD = "display:none;";


                        htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + "'>" + cell.GetValue(row).ToString().Trim() + "</td>" + Environment.NewLine;

                    }
                    htmlPart += "</tr>" + Environment.NewLine;
                }

                //******************************************************************************************

                htmlPart += "</table>" + Environment.NewLine;

                _html += htmlPart;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        bool GenerateHTML_LapsInfo(string IDSession, string DataTitle, bool addJavaScript, string preCompare = "")
        {

            string htmlPart = string.Empty;

            try
            {


                const string AddNickName = @"<tr>
                                                <TD class='tab'><button class='tablinks' onclick='openLaps(event, ""{1}"")'>{0}</button></TD>
                                            </tr>";


                if (addJavaScript == true)
                    htmlPart += sJavaScript + Environment.NewLine;

                //Add Title
                htmlPart += "<b style='color: Gold; font-size: 15pt;font-family:verdana'>" + DataTitle + "</b>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;


                //Create table
                htmlPart += "<table style='width:75%;' >" + Environment.NewLine;

                htmlPart += "<TR style='vertical-align: top;'>" + Environment.NewLine;

                //******************************************************************************************
                //Add Pilots
                //******************************************************************************************
                htmlPart += "<TD>" + Environment.NewLine;

                //Get Pilots NickNames
                List<string> NickNames = (from Datos in Globals.oData.LeaderBoard
                                          where Datos.IDSession == long.Parse(IDSession)
                                          orderby Datos.Position
                                          select Datos.lastName).ToList();

                htmlPart += "<table>" + Environment.NewLine;

                foreach (string name in NickNames)
                {
                    htmlPart += string.Format(AddNickName, name.Trim(), preCompare + IDSession + name.Trim());
                }

                htmlPart += "</table>" + Environment.NewLine;

                htmlPart += "</TD>" + Environment.NewLine;
                //******************************************************************************************

                //******************************************************************************************
                //Add Laps
                //******************************************************************************************
                htmlPart += "<TD>" + Environment.NewLine;

                foreach (string name in NickNames)
                {

                    //Get Columns
                    var LapsColumns = typeof(vSessionLaps).GetProperties();

                    htmlPart += @"<div id='" + preCompare + IDSession + name.Trim() + "' class='tabcontent'>" + Environment.NewLine;

                    //Table start.
                    htmlPart += "<table style='width:75%;'>" + Environment.NewLine;

                    //Adding HeaderRow.
                    htmlPart += "<tr>" + Environment.NewLine;

                    //Add Lap column
                    htmlPart += "<th width: 20px; style='text-align: center; color: white; border: 0px solid #ccc;'>L</th>" + Environment.NewLine;

                    foreach (PropertyInfo column in LapsColumns)
                    {

                        string strHidenTD = string.Empty;
                        if (column.Name.ToLower() != "laptime" && column.Name.ToLower() != "sector1" && column.Name.ToLower() != "sector2" && column.Name.ToLower() != "sector3" && column.Name.ToLower() != "position")
                            strHidenTD = "display:none;";

                        htmlPart += "<th style='text-align: center; color: white; background-color: rgb(100, 97, 97);border: 0px solid #ccc;" + strHidenTD + "'>" + column.Name + "</th>" + Environment.NewLine;
                    }
                    htmlPart += "</tr>" + Environment.NewLine;

                    //Get Race Laps
                    List<vSessionLaps> SLapsR = Globals.oData.vSessionLaps.Where(w => w.NickName == name.Trim() && w.IDSession == long.Parse(IDSession)).OrderBy(o => o.numLap).ToList();

                    //Any clear lap?
                    bool AnyCleanLap = (from Datos in SLapsR where Datos.isValidForBest == true select Datos).Any();

                    string RBestLap = "0:00.000";
                    string RBestS1 = "0:00.000";
                    string RBestS2 = "0:00.000";
                    string RBestS3 = "0:00.000";

                    //Only if have any clean lap
                    if (AnyCleanLap == true)
                    {
                        //Get Race best lap
                        RBestLap = Globals.oData.vSessionLaps.Where(w => w.NickName == name.Trim() && w.IDSession == long.Parse(IDSession) && w.isValidForBest == true).Select(s => s.laptime).Min().Trim();
                        //Get Race best S1
                        RBestS1 = Globals.oData.vSessionLaps.Where(w => w.NickName == name.Trim() && w.IDSession == long.Parse(IDSession) && w.isValidForBest == true).Select(s => s.Sector1).Min().Trim();
                        //Get Race best S2
                        RBestS2 = Globals.oData.vSessionLaps.Where(w => w.NickName == name.Trim() && w.IDSession == long.Parse(IDSession) && w.isValidForBest == true).Select(s => s.Sector2).Min().Trim();
                        //Get Race best S3
                        RBestS3 = Globals.oData.vSessionLaps.Where(w => w.NickName == name.Trim() && w.IDSession == long.Parse(IDSession) && w.isValidForBest == true).Select(s => s.Sector3).Min().Trim();
                    }

                    ////Adding DataRow.
                    foreach (vSessionLaps row in SLapsR)
                    {

                        if (row.isValidForBest == true)
                            htmlPart += "<tr>" + Environment.NewLine;
                        else
                            htmlPart += "<tr style='background-color: red'>" + Environment.NewLine;


                        htmlPart += "<td style='width: 20px; text-align: center; background-color: white; color: black;border: 0px solid #ccc;'><b>" + row.numLap.ToString() + "</b></td>" + Environment.NewLine;

                        foreach (PropertyInfo cell in LapsColumns)
                        {

                            if (cell.GetValue(row) == null) continue;

                            string strHidenTD = string.Empty;
                            if (cell.Name.ToLower() != "laptime" && cell.Name.ToLower() != "sector1" && cell.Name.ToLower() != "sector2" && cell.Name.ToLower() != "sector3" && cell.Name.ToLower() != "position")
                                strHidenTD = "display:none;";

                            string CellBackColor = string.Empty;


                            if (cell.GetValue(row).ToString().Trim() == RBestLap || cell.GetValue(row).ToString().Trim() == RBestS1 || cell.GetValue(row).ToString().Trim() == RBestS2 || cell.GetValue(row).ToString().Trim() == RBestS3)
                                CellBackColor = "; background-color: #4aca3e";

                            if (cell.GetValue(row).ToString().Trim() == SLapsR.First().BestLapSession || cell.GetValue(row).ToString().Trim() == SLapsR.First().BestSector1Session || cell.GetValue(row).ToString().Trim() == SLapsR.First().BestSector2Session || cell.GetValue(row).ToString().Trim() == SLapsR.First().BestSector3Session)
                                CellBackColor = "; background-color: #800080";

                            htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + CellBackColor + "'>" + cell.GetValue(row).ToString().Trim() + "</td>" + Environment.NewLine;
                        }
                        htmlPart += "</tr>" + Environment.NewLine;
                    }

                    //Table end.
                    htmlPart += "</table>" + Environment.NewLine;


                    htmlPart += "</div>" + Environment.NewLine;

                }

                htmlPart += "</TD>" + Environment.NewLine;
                htmlPart += "</TR>" + Environment.NewLine;
                //******************************************************************************************

                htmlPart += "</table>" + Environment.NewLine;

                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;


                _html += htmlPart;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        bool GenerateHTML_CompareLaps(string IDSession)
        {

            try
            {

                //Add Title
                _html += "<b style='color: Gold; font-size: 15pt;font-family:verdana'>Compare laps</b>" + Environment.NewLine;
                _html += "<br>" + Environment.NewLine;
                _html += "<br>" + Environment.NewLine;


                //Create table
                _html += "<table style='width:75%;' >" + Environment.NewLine;
                _html += "<TR style='vertical-align: top;'>" + Environment.NewLine;

                //******************************************************************************************
                //Add First Grid
                //******************************************************************************************
                _html += "<TD>" + Environment.NewLine;
                //Draw RaceLapsInfo
                GenerateHTML_LapsInfo(_IDSession, "Pilot 1", false, "p1");
                _html += "</TD>" + Environment.NewLine;

                //******************************************************************************************
                //Add second Grid
                //******************************************************************************************
                _html += "<TD>" + Environment.NewLine;
                //Draw RaceLapsInfo
                GenerateHTML_LapsInfo(_IDSession, "Pilot 2", false, "p2");
                _html += "</TD>" + Environment.NewLine;

                _html += "</TR>" + Environment.NewLine;
                _html += "</table>" + Environment.NewLine;

                _html += "<br>" + Environment.NewLine;
                _html += "<br>" + Environment.NewLine;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        bool GenerateHTML_Classification()
        {

            try
            {

                string htmlPart = string.Empty;

                //CREATE HTML FILE
                htmlPart = "<HTML>" + Environment.NewLine;
                htmlPart = "<TITLE>Race Data</TITLE>" + Environment.NewLine;
                htmlPart += "<HEAD>" + Environment.NewLine;

                //Define Styles
                htmlPart += sStyles + Environment.NewLine;

                htmlPart += "</HEAD>" + Environment.NewLine;

                //CREATE BODY
                htmlPart += "<body style='background-color: #000000'>" + Environment.NewLine;

                //GET RACEvsQualyDATA
                List<vStatsRaceVsQualy> OStatsR = Globals.oData.vStatsRaceVsQualy.Where(w => w.IDSession == long.Parse(_IDSession)).OrderBy(o => o.FinalPosition).ToList();

                string HotLap = (from Datos in Globals.oData.vStatsRaceVsQualy where Datos.IDSession == long.Parse(_IDSession) select Datos.HotLapRace).ToArray()[0].ToString();
                string PolePosition = (from Datos in Globals.oData.vStatsRaceVsQualy where Datos.IDSession == long.Parse(_IDSession) select Datos.PolePosition).ToArray()[0].ToString();

                //Table TITLE.
                htmlPart += "<table cellpadding='5' cellspacing='0' style='color: white;border: 0px solid #ccc;font-size: 24pt;font-family:verdana'>" + Environment.NewLine; ;
                htmlPart += "<TR></TR>" + Environment.NewLine; ;
                htmlPart += "<TR>" + Environment.NewLine;
                htmlPart += "<TD>";
                htmlPart += "<img src='assets/LogoFalkenCup-Small.png'>" + Environment.NewLine;
                htmlPart += "</TD>" + Environment.NewLine;
                htmlPart += "<TD width='500px'>";
                htmlPart += "<center><b>ACC Race Data</b></center>" + Environment.NewLine;
                htmlPart += "</TD>" + Environment.NewLine;
                htmlPart += "<TD>" + Environment.NewLine;
                htmlPart += "<b style='color: Gold'> " + OStatsR[0].TrackName.ToUpper() + "</b><br>" + Environment.NewLine;
                htmlPart += "<b style='color: Gold'> " + OStatsR.First().SessionDate.ToString("dd/MM/yyyy") + " (" + OStatsR.First().RaceMeteorology.Trim() + ") </b>" + Environment.NewLine;
                htmlPart += "</TD>" + Environment.NewLine;
                htmlPart += "</TR>" + Environment.NewLine;


                htmlPart += "<TR></TR>" + Environment.NewLine;
                htmlPart += "<TR></TR>" + Environment.NewLine;
                htmlPart += "<TR></TR>" + Environment.NewLine;
                htmlPart += "</table>" + Environment.NewLine;

                var car = new vStatsRaceVsQualy();
                var RaceColumns = typeof(vStatsRaceVsQualy).GetProperties();

                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<b style='color: Gold; font-size: 15pt;font-family:verdana'>Classification</b>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;

                //Table start.
                htmlPart += "<table style='width:75%;'>" + Environment.NewLine;

                //Adding HeaderRow.
                htmlPart += "<tr>" + Environment.NewLine;

                //Add Pos in Race Column
                htmlPart += "<th width: 20px; style='text-align: center; color: white; border: 0px solid #ccc;'></th>" + Environment.NewLine;

                foreach (PropertyInfo column in RaceColumns)
                {

                    string strHidenTD = string.Empty;
                    if (Globals.RacevsQualyHidenFields.Contains(column.Name))
                        strHidenTD = "display:none;";

                    htmlPart += "<th style='text-align: center; color: white; background-color: rgb(100, 97, 97);border: 0px solid #ccc;" + strHidenTD + "'>" + column.Name + "</th>" + Environment.NewLine;
                }
                htmlPart += "</tr>" + Environment.NewLine;

                //Adding DataRow.
                foreach (vStatsRaceVsQualy row in OStatsR)
                {
                    htmlPart += "<tr title ='" + row.CarModel.Trim() + "'>" + Environment.NewLine;

                    htmlPart += "<td style='width: 20px; text-align: center; background-color: white; color: black;border: 0px solid #ccc;'><b>" + row.FinalPosition.ToString() + "</b></td>" + Environment.NewLine;

                    foreach (PropertyInfo cell in RaceColumns)
                    {
                        string strHidenTD = string.Empty;
                        if (Globals.RacevsQualyHidenFields.Contains(cell.Name))
                            strHidenTD = "display:none;";

                        if (cell.GetValue(row) == null)
                            continue;

                        if ((cell.GetValue(row).ToString().Trim() == HotLap) || (cell.GetValue(row).ToString().Trim() == PolePosition && PolePosition != "0:00.000"))
                            htmlPart += "<td style='text-align: center; color: white;background-color: #800080;width:120px;border: 1px solid #ccc;" + strHidenTD + "'>" + cell.GetValue(row).ToString().Trim() + "</td>" + Environment.NewLine;
                        else
                        {
                            if (cell.Name != "DiffPosition")

                                if (cell.Name != "Diff")
                                    if (cell.GetValue(row).ToString().Trim().Length > 10 && cell.Name != "NickName")
                                        htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + "'>0:00.000</td>" + Environment.NewLine;
                                    else
                                        htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + "'>" + cell.GetValue(row).ToString().Trim() + "</td>" + Environment.NewLine;
                                else
                                    htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + "'>" + Globals.formatTime(long.Parse(cell.GetValue(row).ToString())) + "</td>" + Environment.NewLine;
                            else
                            {
                                if (int.Parse(cell.GetValue(row).ToString()) > 0)
                                {
                                    htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + "'>" + cell.GetValue(row).ToString().Trim() + "<img src='assets/GainPos.png'></td>" + Environment.NewLine;
                                }
                                else if (int.Parse(cell.GetValue(row).ToString()) < 0)
                                {
                                    htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + "'>" + cell.GetValue(row).ToString().Trim() + "<img src='assets/LessPos.png'></td>" + Environment.NewLine;
                                }
                                else
                                    htmlPart += "<td style='text-align: center; color: white;width:120px;border: 0px solid #ccc;" + strHidenTD + "'>" + cell.GetValue(row).ToString().Trim() + Environment.NewLine;
                            }
                        }
                    }
                    htmlPart += "</tr>" + Environment.NewLine;
                }

                //Table end.
                htmlPart += "</table>" + Environment.NewLine;


                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;

                _html = htmlPart;

                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }

        bool GenerateHTML_ChartPosByLap()
        {

            string htmlPart = string.Empty;

            try
            {

                //Add Title
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<b style='color: Gold; font-size: 15pt;font-family:verdana'>Position by lap</b>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;
                htmlPart += "<br>" + Environment.NewLine;

                //Add Chart.js
                htmlPart += "<script type= 'text/javascript' src='https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.8.0/chart.min.js'></script>" + Environment.NewLine;

                //CreateCanvas
                htmlPart += "<div style = 'width: 1200px; height: 500px;'>" + Environment.NewLine;
                htmlPart += "  <canvas id = 'PosByLap'></canvas>" + Environment.NewLine;
                htmlPart += "</div>" + Environment.NewLine;

                //*****************************************************
                //Create Srcipt for Load Data in Graph
                //*****************************************************

                //Create Script
                htmlPart += "<script lang=\"javascript\">" + Environment.NewLine;

                //Create X Axys (Laps)
                //*************************************************

                //Get totallaps
                int TotalLaps = (from Datos in Globals.oData.LeaderBoard where Datos.IDSession == decimal.Parse(_IDSession) select Datos.LapCount).Max();

                htmlPart += "  const labels = [";

                //Create Laps Array
                for (int Lap = 0; Lap <= TotalLaps; Lap++)
                {
                    htmlPart += "'L" + Lap.ToString() + "'";

                    if (Lap < TotalLaps)
                        htmlPart += ",";
                }

                htmlPart += "]" + Environment.NewLine;

                //*************************************************
                //Get DataSets (Pilot DATA)

                //Get all Pilots in session Race (NO QUALY)
                List<string> Pilots = (from Datos in Globals.oData.LeaderBoard where Datos.IDSession == decimal.Parse(_IDSession) select Datos.lastName.Trim()).ToList();

                string sPilotaDataSets = string.Empty;

                foreach (string Pilot in Pilots)
                {

                    //Get Laps
                    List<long?> PosByLapPilot = (from Datos in Globals.oData.vSessionLaps where Datos.IDSession == decimal.Parse(_IDSession) && Datos.NickName.Trim() == Pilot select Datos.Position).ToList();

                    if (PosByLapPilot.Any())
                    {


                        Random random = new Random();
                        string sPilot = Pilot.Replace(" ", string.Empty).Replace("#", string.Empty);

                        //Create Data by Pilot
                        htmlPart += "const " + sPilot + " = {" + Environment.NewLine;
                        htmlPart += "  label: '" + sPilot + "', " + Environment.NewLine;
                        htmlPart += "  borderColor: 'rgba(" + random.Next(256).ToString() + ", " + random.Next(256).ToString() + ", " + random.Next(256).ToString() + ", 1.8)'," + Environment.NewLine;
                        htmlPart += "  fill: false," + Environment.NewLine;
                        htmlPart += "  tension: 0.1, " + Environment.NewLine;

                        sPilotaDataSets += sPilot + ",";

                        
                        //Get IDQualy
                        decimal? lngIDQualy = (from Datos in Globals.oData.vSessionLaps where Datos.IDSession == decimal.Parse(_IDSession) && Datos.NickName.Trim() == Pilot select Datos.IDQualySession).ToList().First();

                        //Get Initial possition
                        var qryInitPos = (from Datos in Globals.oData.LeaderBoard where Datos.IDSession == lngIDQualy && Datos.lastName.Trim() == Pilot select Datos.Position);

                        //Default 99 (control No Qualy Challenge)
                        long PosInitialPilot = Pilots.Count();

                        if (qryInitPos.Any())
                            PosInitialPilot = (from Datos in Globals.oData.LeaderBoard where Datos.IDSession == lngIDQualy && Datos.lastName.Trim() == Pilot select Datos.Position).ToList().First();

                        //If any qualy
                        if (lngIDQualy != null)
                        {
                            htmlPart += "  data: [" + PosInitialPilot.ToString() + ",";
                        }

                        if (PosByLapPilot.Count > 0)
                        {
                            //Ad Position x Lap
                            if (lngIDQualy == null)
                                htmlPart += "  data: [";

                            for (int PosLap = 0; PosLap <= PosByLapPilot.Count() - 1; PosLap++)
                            {
                                htmlPart += PosByLapPilot[PosLap].ToString();
                                if (PosLap < PosByLapPilot.Count() - 1)
                                    htmlPart += ",";

                            }

                            htmlPart += "]};" + Environment.NewLine;
                        }
                        else
                            htmlPart += "data: []};" + Environment.NewLine;
                    }

                }

                //ADD All PilotData to Data Section
                //*****************************************

                //Drop last ","
                sPilotaDataSets = sPilotaDataSets.Substring(0, sPilotaDataSets.Length - 1);

                htmlPart += "const data = { " + Environment.NewLine;
                htmlPart += "  labels: labels, " + Environment.NewLine;
                htmlPart += "datasets: [" + sPilotaDataSets + "]}" + Environment.NewLine;


                htmlPart += @"
                                const options =  {
                                                        responsive: true,
                                                        maintainAspectRatio: false,
                                                        plugins: {
                                                                    legend: {                                                                    
                                                                                labels: {                                                                                    
                                                                                            generateLabels: (chart) => 
                                                                                                {
                                                                                                    return chart.data.datasets.map(
                                                                                                                                    (dataset, index) => ({
                                                                                                                                            text: dataset.label,
                                                                                                                                            fillStyle: dataset.borderColor,
                                                                                                                                            strokeStyle: dataset.borderColor,
                                                                                                                                            fontColor: 'white'
                                                                                                                                    })
                                                                                                                                )
                                                                                                }
                                                                                        }
                                                                            }
                                                            },
                                                        scales: {
                                                            y: {
                                                                        reverse: true,
                                                                        suggestedMax: " + Pilots.Count().ToString() + @",
                                                                        ticks: {
                                                                                beginAtZero: false,
                                                                                precision: 0,
                                                                                color: 'white',
                                                                            }
                                                                },
                                                            x: {
                                                                    ticks: {
                                                                            color: 'white',
                                                                        }
                                                                }                             
                                                        }   
                                        };

                                        const config = {
                                            type: 'line',
                                            data: data,
                                            options: options
                                        };

        
                                        var graph = document.getElementById('PosByLap');
                                        new Chart(graph, config);" + Environment.NewLine;


                htmlPart += "</script>" + Environment.NewLine;
                //*****************************************************

                _html += htmlPart;

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private void frmRaceAnalysis_Load(object sender, EventArgs e)
        {

            grdRaces.DataBindingComplete += grdRaces_DataBindingComplete;

            List<vGetCompleteSessions> OStatsR = (from Datos in Globals.oData.vGetCompleteSessions orderby Datos.IDQualySession descending, Datos.ID descending select Datos).ToList();
            grdRaces.DataSource = OStatsR;

            List<Seasons> oSeasons = (from Data in Globals.oData.Seasons orderby Data.Active descending select Data).ToList();
            cboSeason.ValueMember = "ID";
            cboSeason.DisplayMember = "Name";
            cboSeason.DataSource = oSeasons;
        }

        private void grdRaces_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {


            foreach (DataGridViewRow row in grdRaces.Rows)
            {

                if (row.Cells["IDQualySession"].Value != null)
                    row.DefaultCellStyle.BackColor = Color.LightGreen;


            }

        }

        private void cboSeason_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<vGetCompleteSessions> OStatsR = (from Datos in Globals.oData.vGetCompleteSessions join S in Globals.oData.SeasonSessions on
                                                    Datos.ID equals S.IdSession
                                                  where S.IdSeason == (Decimal)cboSeason.SelectedValue
                                                  orderby Datos.IDQualySession descending, Datos.ID descending 
                                                  select Datos).ToList();
            grdRaces.DataSource = OStatsR;


        }
    }
}

