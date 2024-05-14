Imports Microsoft.Office.Interop
Imports Microsoft

Public Class FrmGenerateLoadingSequence
    Private Sub FrmGenerateLoadingSequence_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadStrCmb(cmbFV, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
        Call LoadStrCmb(cmbLoadingSequence, "SELECT ID, FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE STAT = '1'")

        With cmbRefno.Items
            .Clear()
            For i As Integer = 1 To 100
                .Add(Format(i, "000"))
            Next
        End With

        With cmbCargoType.Items
            .Clear()
            .Add("GENERAL")
            .Add("DANGEROUS")
        End With

        cmbCargoType.SelectedIndex = 0
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbFV.SelectedIndex = -1 Then
            MsgBox("Invalid Feeder Vessel!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbRefno.SelectedIndex = -1 Then
            MsgBox("Invalid sequence!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbCargoType.SelectedIndex = -1 Then
            MsgBox("Invalid Cargo type!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbLoadingSequence.SelectedIndex = -1 Then
            MsgBox("Invalid feeder carrier!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Generate loading sequence report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim _10DC = 0, _20DC = 0, _40DC = 0, _40HQ = 0, _40RF As Integer = 0

            Dim T_10DC = 0, T_20DC = 0, T_40DC = 0, T_40HQ = 0, T_40RF As Integer = 0

            Dim RowStart As Integer = 15
            Dim ColStart As Integer = 2
            Dim itemCount As Integer = 1
            Dim HeaderRowStart As Integer = 7
            Dim DetailStartRow = 0, DetailRowEnd As Integer = 0


            Dim Dbo As New SQLClass


            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet




            ColStart = 1

            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "NOS.", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "CONTAINER NOS.", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "SIZE", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "SEAL NO.", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "SHIPPER", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "GWT", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "COMMODITY", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "DESTINATION", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "GATE-IN", False, sheet, Color.Black, 44)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "STORAGE", False, sheet, Color.Black, 44)


            RowStart += 1

            ColStart = 1

            DetailStartRow = RowStart

            Dbo.SqlCon.Open()
            'SQL = "SELECT  bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME AS F1_POL , POD1.NAME AS F1_POD,  BK.F1_ETA as F1_ETA, BK.F1_ETD  as F1_ETD   , C.ContainerNo, C.SizeIs, C.SealNo,SHIPPER.ClientName AS SHIPPER, C.VGM, BK.Commodity, POD1.NAME AS POD, PRT.NAME AS PORTIS, C.GateInDate,                 MV.VESSELNAME as MotherVessel , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.ClientName AS SHIPPER, BK.BLNO, CONSIGNEE.ClientName AS CONSIGNEE, C.VGM, BK.ServiceType, POD1.NAME AS POD, PRT.NAME AS PORTIS,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType   FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND C.CargoType = '" & KVal(cmbCargoType.Text) & "' ORDER BY BK.BLNO, MV.VESSELNAME, BK.BKNO asc"

            'SQL = " SELECT DISTINCT  bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME AS F1_POL , POD1.NAME AS F1_POD,  BK.F1_ETA as F1_ETA, BK.F1_ETD  as F1_ETD   , C.ContainerNo, C.SizeIs, C.SealNo,SHIPPER.ClientName AS SHIPPER, C.VGM, BK.Commodity, POD1.NAME AS POD, PRT.NAME AS PORTIS, C.GateInDate,                 MV.VESSELNAME as MotherVessel , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.ClientName AS SHIPPER, BK.BLNO, CONSIGNEE.ClientName AS CONSIGNEE, C.VGM, BK.ServiceType, POD1.NAME AS POD, PRT.NAME AS PORTIS,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType, O.EtaMnl, O.EtdMnl, st.name    FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON convert(nvarchar(50),BK.Shipper) = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' LEFT JOIN TBL_OPERATIONS AS O ON BK.BKNO = O.BKNO AND  BK.Stat  = '1'  WHERE  o.stat = '1' AND          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND C.CargoType = '" & KVal(cmbCargoType.Text) & "'  AND CONVERT(DATE,ETAMNL) = '" & Format(CDate(DtETAMnl.Value), "yyyy-MM-dd") & "' AND CONVERT(DATE,ETDMNL) = '" & Format(CDate(dtETDMnl.Value), "yyyy-MM-dd") & "'   GROUP BY BK.BLNO, MV.VESSELNAME, BK.BKNO, bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME , POD1.NAME  ,  BK.F1_ETA  , BK.F1_ETD    , C.ContainerNo, C.SizeIs, C.SealNo,SHIPPER.ClientName  , C.VGM, BK.Commodity, POD1.NAME  , PRT.NAME  , C.GateInDate,                 MV.VESSELNAME   , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.ClientName  , BK.BLNO, CONSIGNEE.ClientName  , C.VGM, BK.ServiceType, POD1.NAME  , PRT.NAME  ,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType, O.EtaMnl, O.EtdMnl, st.name "
            SQL = "SELECT DISTINCT  bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME AS F1_POL , POD1.NAME AS F1_POD,  BK.F1_ETA as F1_ETA, BK.F1_ETD  as F1_ETD   , C.ContainerNo, C.SizeIs, C.SealNo, SHIPPER.cardname AS SHIPPER, C.VGM, BK.Commodity, POD1.NAME AS POD, PRT.NAME AS PORTIS, C.GateInDate,                 MV.VESSELNAME as MotherVessel , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.cardname AS SHIPPER, BK.BLNO, CONSIGNEE.ClientName AS CONSIGNEE, C.VGM, BK.ServiceType, POD1.NAME AS POD, PRT.NAME AS PORTIS,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType, O.EtaMnl, O.EtdMnl, st.name    FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS SHIPPER ON convert(nvarchar(50),BK.Shipper) = convert(nvarchar(50),SHIPPER.cardcode) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' LEFT JOIN TBL_OPERATIONS AS O ON BK.BKNO = O.BKNO AND  BK.Stat  = '1'  WHERE  o.stat = '1'  AND          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND C.CargoType = '" & KVal(cmbCargoType.Text) & "'  AND CONVERT(DATE,ETAMNL) = '" & Format(CDate(DtETAMnl.Value), "yyyy-MM-dd") & "' AND CONVERT(DATE,ETDMNL) = '" & Format(CDate(dtETDMnl.Value), "yyyy-MM-dd") & "'   GROUP BY BK.BLNO, MV.VESSELNAME, BK.BKNO, bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME , POD1.NAME  ,  BK.F1_ETA  , BK.F1_ETD    , C.ContainerNo, C.SizeIs, C.SealNo, SHIPPER.cardname  , C.VGM, BK.Commodity, POD1.NAME  , PRT.NAME  , C.GateInDate,                 MV.VESSELNAME   , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.cardname  , BK.BLNO, CONSIGNEE.ClientName  , C.VGM, BK.ServiceType, POD1.NAME  , PRT.NAME  ,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType, O.EtaMnl, O.EtdMnl, st.name "

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read



                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 8, "Arial Black", "C", itemCount, False, sheet, Color.Black, 44)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Dbo.reader(7).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                If Dbo.reader(8).ToString = "10DC" Then
                    _10DC = _10DC + 1
                    T_10DC = T_10DC + 1
                ElseIf Dbo.reader(8).ToString = "20DC" Then
                    _20DC = _20DC + 1
                    T_20DC = T_20DC + 1
                ElseIf Dbo.reader(8).ToString = "40DC" Then
                    _40DC = _40DC + 1
                    T_40DC = T_40DC + 2
                ElseIf Dbo.reader(8).ToString = "40HQ" Then
                    _40HQ = _40HQ + 1
                    T_40HQ = T_40HQ + 2
                ElseIf Dbo.reader(8).ToString = "40RF" Then
                    _40RF = _40RF + 1
                    T_40HQ = T_40HQ + 2
                End If

                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Dbo.reader(8).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Dbo.reader(9).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Dbo.reader(10).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Dbo.reader(11).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Dbo.reader(12).ToString, False, sheet, Color.Black, 0)
                ColStart += 1

                Dim Dest As String = ""
                If String.IsNullOrEmpty(Dbo.reader(14).ToString) Then
                    Dest = Dbo.reader(36).ToString
                Else
                    Dest = Dbo.reader(14).ToString
                End If
                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Dbo.reader(13).ToString & "/" & Dest, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 33.75, 5.64, 12, "Cambria", "C", Format(CDate(Dbo.reader(15).ToString), "dd-MMM"), False, sheet, Color.Black, 0)





                ColStart = 1
                'backgroundColor
                itemCount += 1
                RowStart += 1
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

            DetailRowEnd = RowStart

            sheet.Columns("A:AZ").AutoFit()



            Dim TotalTeusStr = "", CutTotalTeus As String = ""

            Dim Teus10DCStr = "", Teus20DCStr = "", Teus40DCStr = "", Teus40HQStr = "", Teus40RFStr As String = ""


            Teus10DCStr = _10DC & "X10DC & "
            Teus20DCStr = _20DC & "X20DC & "
            Teus40DCStr = _40DC & "X40DC & "
            Teus40HQStr = _40HQ & "X40HQ & "
            Teus40RFStr = _40RF & "X40RF & "

            If _40RF = 0 Then
                Teus40RFStr = ""
            End If

            If _40HQ = 0 Then
                Teus40HQStr = ""
            End If

            If _40DC = 0 Then
                Teus40DCStr = ""
            End If

            If _20DC = 0 Then
                Teus20DCStr = ""
            End If

            If _10DC = 0 Then
                Teus10DCStr = ""
            End If

            TotalTeusStr = "TOTAL: " & Teus10DCStr & Teus20DCStr & Teus40DCStr & Teus40HQStr & Teus40RFStr

            If VisualBasic.Right(TotalTeusStr, 2) = "& " Then
                TotalTeusStr = VisualBasic.Left(TotalTeusStr, Len(TotalTeusStr) - 2)
            End If

            Dim TotalTeus As Double = 0

            TotalTeus = Val(T_10DC) + Val(T_20DC) + Val(T_40DC) + Val(T_40HQ) + Val(T_40RF)

            TotalTeusStr = TotalTeusStr & "= " & TotalTeus & IIf(TotalTeus > 1, " TEU'S", "TEUS")

            sheet.Range("A" & DetailStartRow - 1 & ":" & "J" & DetailRowEnd - 1).Borders.Weight = Excel.XlBorderWeight.xlThin

            DetailRowEnd += 2

            InputTextRFC("D" & DetailRowEnd & ":D" & DetailRowEnd, True, 15.75, 5.64, 16, "Cambria Italic", "L", TotalTeusStr, True, sheet, Color.Red)

            DetailRowEnd += 3

            InputTextRFC("B" & DetailRowEnd & ":B" & DetailRowEnd, True, 15.75, 5.64, 12, "Cambria", "L", "TOP STOW", True, sheet, Color.Red)


            DetailRowEnd += 1
            InputTextRFC("B" & DetailRowEnd & ":B" & DetailRowEnd, True, 15.75, 5.64, 12, "Cambria", "L", "PREPARED BY: " & UCase(FNAME & " " & LNAME), True, sheet, Color.Black)
            InputTextRFC("H" & DetailRowEnd & ":H" & DetailRowEnd, True, 15.75, 5.64, 12, "Cambria", "L", "APPROVED BY: CHRISTINE FAMINIAL", True, sheet, Color.Black)




            ColStart = 2

            Dbo.SqlCon.Open()
            SQL = "SELECT TOP 1  bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME AS F1_POL , POD1.NAME AS F1_POD,  BK.F1_ETA as F1_ETA, BK.F1_ETD  as F1_ETD   , C.ContainerNo, C.SizeIs, C.SealNo,SHIPPER.ClientName AS SHIPPER, C.VGM, BK.Commodity, POD1.NAME AS POD, PRT.NAME AS PORTIS, C.GateInDate,                 MV.VESSELNAME as MotherVessel , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.ClientName AS SHIPPER, BK.BLNO, CONSIGNEE.ClientName AS CONSIGNEE, C.VGM, BK.ServiceType, POD1.NAME AS POD, PRT.NAME AS PORTIS,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType, O.EtaMnl, O.EtdMnl   FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON convert(nvarchar(50),BK.Shipper) = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1'   LEFT JOIN TBL_OPERATIONS AS O ON BK.BKNO = O.BKNO AND  BK.Stat  = '1' WHERE    o.stat = '1' and        (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%'  AND C.CargoType = '" & KVal(cmbCargoType.Text) & "' AND  CONVERT(DATE,ETAMNL) = '" & Format(CDate(DtETAMnl.Value), "yyyy-MM-dd") & "' AND CONVERT(DATE,ETDMNL) = '" & Format(CDate(dtETDMnl.Value), "yyyy-MM-dd") & "' ORDER BY BK.BLNO, MV.VESSELNAME, BK.BKNO asc"
            SQL = "SELECT TOP 1  bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME AS F1_POL , POD1.NAME AS F1_POD,  BK.F1_ETA as F1_ETA, BK.F1_ETD  as F1_ETD   , C.ContainerNo, C.SizeIs, C.SealNo,SHIPPER.cardname AS SHIPPER, C.VGM, BK.Commodity, POD1.NAME AS POD, PRT.NAME AS PORTIS, C.GateInDate,                 MV.VESSELNAME as MotherVessel , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.cardname AS SHIPPER, BK.BLNO, CONSIGNEE.ClientName AS CONSIGNEE, C.VGM, BK.ServiceType, POD1.NAME AS POD, PRT.NAME AS PORTIS,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType, O.EtaMnl, O.EtdMnl   FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS SHIPPER ON convert(nvarchar(50),BK.Shipper) = convert(nvarchar(50),SHIPPER.cardcode) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1'   LEFT JOIN TBL_OPERATIONS AS O ON BK.BKNO = O.BKNO AND  BK.Stat  = '1' WHERE    o.stat = '1' and        (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%'  AND C.CargoType = '" & KVal(cmbCargoType.Text) & "' AND  CONVERT(DATE,ETAMNL) = '" & Format(CDate(DtETAMnl.Value), "yyyy-MM-dd") & "' AND CONVERT(DATE,ETDMNL) = '" & Format(CDate(dtETDMnl.Value), "yyyy-MM-dd") & "' ORDER BY BK.BLNO, MV.VESSELNAME, BK.BKNO asc"

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read
                InputTextCF(ColStart, HeaderRowStart, True, 15.75, 5.64, 14, "Arial Bold Italic", "L", "F/V " & Dbo.reader(1).ToString & "V-" & Dbo.reader(2).ToString, True, sheet, Color.Blue)
                HeaderRowStart += 1

                InputTextCF(ColStart, HeaderRowStart, True, 15.75, 5.64, 14, "Arial Bold Italic", "L", "REG NO: " & KVal(cmbRegno.Text), True, sheet, Color.Blue)
                HeaderRowStart += 1

                InputTextCF(ColStart, HeaderRowStart, True, 15.75, 5.64, 14, "Arial Bold Italic", "L", "ETA " & Dbo.reader(3).ToString & ": " & KVal(Format(CDate(Dbo.reader(34).ToString), "MMM. dd yyyy")), True, sheet, Color.Blue)
                HeaderRowStart += 1

                InputTextCF(ColStart, HeaderRowStart, True, 15.75, 5.64, 14, "Arial Bold Italic", "L", "ETD " & Dbo.reader(3).ToString & ": " & KVal(Format(CDate(Dbo.reader(35).ToString), "MMM. dd yyyy")), True, sheet, Color.Blue)
                HeaderRowStart += 1

                InputTextCF(ColStart, HeaderRowStart, True, 15.75, 5.64, 14, "Arial Bold Italic", "L", "BOOKING# " & KVal(CmbBookingNo.Text), True, sheet, Color.Blue)
                HeaderRowStart += 1

                InputTextCF(ColStart, HeaderRowStart, True, 15.75, 5.64, 14, "Arial Bold Italic", "L", "REF NO. " & KVal(cmbRefno.Text) & IIf(cmbCargoType.Text = "GENERAL", " (A)", " (B)"), True, sheet, Color.Blue)
                HeaderRowStart += 1


            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()



            InputTextRFC("A" & HeaderRowStart & ":J" & HeaderRowStart, True, 23.25, 5.64, 18, "Arial Bold Italic", "C", "LOADING SEQUENCE" & IIf(String.IsNullOrEmpty(cmbLoadingSequence.Text), "", " (" & KVal(cmbLoadingSequence.Text) & ")"), True, sheet, Color.Blue)



            InputTextRFC("A" & 1 & ":J" & 1, True, 30, 5.64, 26, "Cambria Bold", "C", "KYOWA SHIPPING LINE CO., LTD.", True, sheet, Color.Black)
            InputTextRFC("A" & 2 & ":J" & 2, True, 15, 5.64, 11, "Cambria Bold", "C", "10th flr.Sky 1 Tower, #68 Dasmariñas St.Binondo,Metro Manila", True, sheet, Color.Black)
            InputTextRFC("A" & 3 & ":J" & 3, True, 15, 5.64, 11, "Cambria Bold", "C", "Tel.No.243-02-01 to 12 /Fax Nos.242-2059,2442632,2422257", True, sheet, Color.Black)
            'InputTextRFC("A" & 4 & ":J" & 4, True, 30, 5.64, 24, "Arial Bold Italic", "C", "KYOWA SHIPPING LINE CO., LTD ", True, sheet, Color.Blue)

            xls.Visible = True




        End If
    End Sub
End Class