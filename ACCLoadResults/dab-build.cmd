@echo off
@echo This cmd file creates a Data API Builder configuration based on the chosen database objects.
@echo To run the cmd, create an .env file with the following contents:
@echo dab-connection-string=your connection string
@echo ** Make sure to exclude the .env file from source control **
@echo **
dotnet tool install -g Microsoft.DataApiBuilder
dab init -c dab-config.json --database-type mssql --connection-string "@env('dab-connection-string')" --host-mode Development
@echo Adding tables
@echo Adding views and tables without primary key
@echo No primary key found for table/view 'vGetBestimeByGameTAG', using first column (GameTag) as key field
dab add "VGetBestimeByGameTagView" --source "[dbo].[vGetBestimeByGameTAG]" --fields.include "GameTag,Circuit,RaceMeteorology,Session,BestLapSession,BestSector1,BestSector2,BestSector3,Position,CarModel,carGroup" --source.type "view" --source.key-fields "GameTag" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vGetClassification', using first column (IdSeason) as key field
dab add "VGetClassificationView" --source "[dbo].[vGetClassification]" --fields.include "IdSeason,IdTemporada,Posicio,GameTag,Puntuacio,SancionsTemps,SancionsBox,Poles,VoltesRapides,Curses,DiffPunts,DiffLider,MitjaPuntsPerCursa" --source.type "view" --source.key-fields "IdSeason" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vGetCompleteSessions', using Id column (ID) as key field
dab add "VGetCompleteSessionView" --source "[dbo].[vGetCompleteSessions]" --fields.include "CompleteRace,ID,sessionType,trackName,LogFileName,BestLap,BestSector1,BestSector2,BestSector3,IsWet,SessionDate,SessionHour,IDQualySession,BestLapNumeric,BestSector1Numeric,BestSector2Numeric,BestSector3Numeric" --source.type "view" --source.key-fields "ID" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vGetQualyResult', using first column (trackName) as key field
dab add "VGetQualyResultView" --source "[dbo].[vGetQualyResult]" --fields.include "trackName,CarModel,Driver,BestLap,Position,GeneralPos" --source.type "view" --source.key-fields "trackName" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vGetRaceCSVFile', using first column (IDSession) as key field
dab add "VGetRaceCsvfileView" --source "[dbo].[vGetRaceCSVFile]" --fields.include "IDSession,SessionDate,SessionHour,IdTemporada,IdCircuit,GameTag,Posicio,PenalitzacioTemps,PenalitzacioBoxes,Pole,VoltaRapida,CursaLlarga,PuntsPossicio,PuntsExtres,InfoPuntsExtres,PuntsTotals" --source.type "view" --source.key-fields "IDSession" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vLastRaceResult', using first column (Posici?) as key field
dab add "VLastRaceResultView" --source "[dbo].[vLastRaceResult]" --fields.include "Posici?,GameTag,Puntuaci?,Pole,VoltaR?pida" --source.type "view" --source.key-fields "Posici?" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vLeaderBoardControlPanel', using Id column (Id) as key field
dab add "VLeaderBoardControlPanelView" --source "[dbo].[vLeaderBoardControlPanel]" --fields.include "Order,Id,IdSeason,IdTemporada,IdSession,Posicio,GameTag,Puntuacio,SancionsTemps,SancionsBox,Poles,VoltesRapides,Curses,DiffPunts,DiffLider,MitjaPuntsPerCursa,TrackNameClean" --source.type "view" --source.key-fields "Id" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vPalmares', using first column (lastName) as key field
dab add "VPalmareView" --source "[dbo].[vPalmares]" --fields.include "lastName,position,trackName" --source.type "view" --source.key-fields "lastName" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vPBIClearLaps', using first column (Season) as key field
dab add "VPbiclearLapView" --source "[dbo].[vPBIClearLaps]" --fields.include "Season,trackName,GameTag,isValidForBest,TotalLaps" --source.type "view" --source.key-fields "Season" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vPBIMapData', using Id column (Id) as key field
dab add "VPbimapDatumView" --source "[dbo].[vPBIMapData]" --fields.include "Id,TrackName,Lat,Lon,GameTag,Victorias" --source.type "view" --source.key-fields "Id" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vPBIPenalties', using first column (IdSeason) as key field
dab add "VPbipenaltyView" --source "[dbo].[vPBIPenalties]" --fields.include "IdSeason,GameTag,penalty,trackName" --source.type "view" --source.key-fields "IdSeason" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vSeasonRaceLeaderBoard', using first column (Season) as key field
dab add "VSeasonRaceLeaderBoardView" --source "[dbo].[vSeasonRaceLeaderBoard]" --fields.include "Season,DateStart,DateEnd,IDSession,IDQualySession,SessionDate,SessionHour,Session,TrackName,BestLapSession,BestSector1Session,BestSector2Session,BestSector3Session,RaceMeteorology,CarModel,NickName,BestLap,BestSector1,BestSector2,BestSector3,LastLap,LastSector1,LastSector2,LastSector3,LapCount,Position,BestLapNumeric,BestSector1Numeric,BestSector2Numeric,BestSector3Numeric,TotalTimeNumeric" --source.type "view" --source.key-fields "Season" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vSessionLaps', using first column (Season) as key field
dab add "VSessionLapView" --source "[dbo].[vSessionLaps]" --fields.include "Season,DateStart,DateEnd,IDSession,IDQualySession,SessionDate,SessionHour,Session,TrackName,BestLapSession,BestSector1Session,BestSector2Session,BestSector3Session,BestLapNumeric,BestSector1Numeric,BestSector2Numeric,BestSector3Numeric,RaceMeteorology,NickName,numLap,isValidForBest,laptime,Sector1,Sector2,Sector3,Position" --source.type "view" --source.key-fields "Season" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vSessionLeaderBoard', using first column (IdSeason) as key field
dab add "VSessionLeaderBoardView" --source "[dbo].[vSessionLeaderBoard]" --fields.include "IdSeason,IDSession,IDQualySession,SessionDate,SessionHour,Session,TrackName,BestLapSession,BestSector1Session,BestSector2Session,BestSector3Session,RaceMeteorology,CarModel,NickName,BestLap,BestSector1,BestSector2,BestSector3,LastLap,LastSector1,LastSector2,LastSector3,LapCount,Position,TotalTimeNumeric,TotalTime" --source.type "view" --source.key-fields "IdSeason" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vSessionPenalties', using first column (IDSession) as key field
dab add "VSessionPenaltyView" --source "[dbo].[vSessionPenalties]" --fields.include "IDSession,NickName,penalty,reason,violationInLap,clearedInLap" --source.type "view" --source.key-fields "IDSession" --permissions "anonymous:*" 
@echo No primary key found for table/view 'vStatsRaceVsQualy', using first column (IDSession) as key field
dab add "VStatsRaceVsQualyView" --source "[dbo].[vStatsRaceVsQualy]" --fields.include "IDSession,IDQualySession,SessionDate,RaceMeteorology,CarModel,TrackName,NickName,StartPosition,FinalPosition,DiffPosition,HotLapRace,HotLapPlayerRace,PolePosition,HotLapQualy,LapsInRace,ValidLaps,LapsInQualy,TotalTime,Diff" --source.type "view" --source.key-fields "IDSession" --permissions "anonymous:*" 
@echo Adding relationships
@echo Adding stored procedures
@echo **
@echo ** run 'dab validate' to validate your configuration **
@echo ** run 'dab start' to start the development API host **
