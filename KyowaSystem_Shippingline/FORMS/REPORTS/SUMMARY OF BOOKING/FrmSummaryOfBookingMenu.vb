Imports Microsoft.Office.Interop
Imports Microsoft
Public Class FrmSummaryOfBookingMenu

    Dim StartDetailsRow As Integer = 5
    Dim DetaisMaxRow As Integer = 0
    Private Sub FrmSummaryOfBookingMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call LoadStrCmb(cmbFV, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
        Call LoadStrCmb(cmbFeederCarrier, "SELECT ID, FEEDER_CARRIER FROM TBL_FEEDER_CARRIER WHERE STAT = '1'")


        With cmbSequence.Items
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

    Public Sub PopulateMvEta(row As Integer, col As Integer, sheet As Excel.Worksheet, MV As String, MVY As String, FV As String, FVY As String, DetailsStartRow As Integer)
        row = row + 2
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT    DISTINCT  MV.VESSELNAME as MotherVessel , MVoyage , PRT.NAME AS PORTIS, FORMAT(BK.FINAL_DEST_ETA,'yyyy-MM-dd') as FD_ETA, FORMAT(BK.FINAL_DEST_ETD,'yyyy-MM-dd') as FD_ETD  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & FV & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & FVY & "' AND ISNULL(MV.VESSELNAME,'') LIKE '" & MV & "' AND ISNULL(MVOYAGE,'') LIKE '" & MVY & "'  AND C.CARGOTYPE = '" & KVal(cmbCargoType.Text) & "'  GROUP BY MV.VESSELNAME  , MVoyage , PRT.NAME , FORMAT(BK.FINAL_DEST_ETA,'yyyy-MM-dd')  , FORMAT(BK.FINAL_DEST_ETD,'yyyy-MM-dd')   ORDER BY FORMAT(BK.FINAL_DEST_ETA,'yyyy-MM-dd') asc"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read

            Dim FinalEta, FinalEtd As DateTime
            Dim FinalEtaEtd As String = ""
            FinalEta = Dbo.reader(3).ToString
            FinalEtd = Dbo.reader(4).ToString

            If FinalEta.Year = FinalEtd.Year Then
                FinalEtaEtd = Format(FinalEta, "MMM. dd-") & Format(FinalEtd, "dd, yyyy")
            Else
                FinalEtaEtd = Format(FinalEta, "MMM. dd, yyyy") & Format(FinalEtd, "MMM. dd, yyyy")
            End If

            InputTextC(col, row, True, 15.75, 5.64, 12, "Cambria", "L", UCase("ETA " & Dbo.reader(2).ToString & ": " & FinalEtaEtd), False, sheet)
            row = row + 1

            DetailsStartRow = DetailsStartRow + 1

            If DetaisMaxRow < DetailsStartRow Then
                DetaisMaxRow = DetailsStartRow + 2
            End If
        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'return if done testing
        If cmbFV.SelectedIndex = -1 Then
            MsgBox("Invalid Feeder Vessel!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbSequence.SelectedIndex = -1 Then
            MsgBox("Invalid sequence!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbCargoType.SelectedIndex = -1 Then
            MsgBox("Invalid Cargo type!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbFeederCarrier.SelectedIndex = -1 Then
            MsgBox("Invalid feeder carrier!", MsgBoxStyle.Critical)
            Exit Sub
        End If



        If MsgBox("Generate summary of booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim _10DC = 0, _20DC = 0, _40DC = 0, _40HQ = 0, _40RF As Integer = 0

            Dim T_10DC = 0, T_20DC = 0, T_40DC = 0, T_40HQ = 0, T_40RF As Integer = 0

            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet
            xls.Visible = True

            Dim MvRowStart As Integer = 5
            Dim MvColStart As Integer = 5

            DetaisMaxRow = 0

            'HEADER
            'InputTextF("A1:J1", True, 15.75, 5.64, 9, "Cambria", "C", "KYOWA SHIPPING CO., LTD.", True, sheet)
            'InputTextF("A2:J2", True, 31.5, 5.64, 20, "Cambria", "C", "SUMMARY OF BOOKING", True, sheet)
            Dim Dbo As New SQLClass

            'FEEDER PART
            Dim FvRowStart As Integer = 5
            Dim FvColStart As Integer = 1

            'InputTextC(0, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "FEEDER VESSEL:", True, sheet)
            'FvRowStart = FvRowStart + 1
            'InputTextC(0, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "FEEDER VESSEL:", True, sheet)
            'FvRowStart = FvRowStart + 1
            'InputTextC(0, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "FEEDER VESSEL:", True, sheet)
            'FvRowStart = FvRowStart + 1
            'InputTextC(0, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "FEEDER VESSEL:", True, sheet)



            Dbo.SqlCon.Open()
            SQL = "SELECT    DISTINCT  v1.VESSELNAME, bk.FVoyage1st, POL1.NAME , POD1.NAME,   BK.F1_ETA as F1_ETA,  BK.F1_ETD as F1_ETD  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND C.CARGOTYPE = '" & KVal(cmbCargoType.Text) & "'  GROUP BY  v1.VESSELNAME, bk.FVoyage1st, POL1.NAME, POD1.NAME  ,  BK.F1_ETA   ,  BK.F1_ETD    ORDER BY  BK.F1_ETA  asc"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read
                InputTextC(FvColStart, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "FEEDER VESSEL:", True, sheet)
                InputTextC(FvColStart + 1, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "L", Dbo.reader(0).ToString & " V-" & Dbo.reader(1).ToString, True, sheet)

                'FOR ATA MICP
                'FvRowStart = FvRowStart + 1

                'InputTextC(FvColStart, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "ATA MICP:", True, sheet)
                'InputTextC(FvColStart + 1, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "L", "ATA MICP", True, sheet)

                FvRowStart = FvRowStart + 1


                Dim FVEtd As DateTime
                Dim FvEtdIs As String = ""

                FVEtd = Dbo.reader(5).ToString

                FvEtdIs = Format(CDate(Dbo.reader(5).ToString), "MMM. dd, yyyy (HHmm") & "HRS)"

                InputTextC(FvColStart, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "ETD " & Dbo.reader(2).ToString & ":", True, sheet)
                InputTextC(FvColStart + 1, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "L", UCase(FvEtdIs), True, sheet)

                FvRowStart = FvRowStart + 1


                Dim FVEtA As DateTime
                Dim FvEtAIs As String = ""

                FVEtA = Dbo.reader(4).ToString

                FvEtAIs = Format(CDate(Dbo.reader(4).ToString), "MMM. dd, yyyy (HHmm") & "HRS)"

                InputTextC(FvColStart, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "R", "ETD " & Dbo.reader(3).ToString & ":", True, sheet)
                InputTextC(FvColStart + 1, FvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "L", UCase(FvEtAIs), True, sheet)


            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()





            Dbo.SqlCon.Open()
            SQL = "Select MV.VESSELNAME As MotherVessel , MVoyage, BK.MV_ETA, BK.MV_ETD, POD1.NAME As POD , v1.VESSELNAME, BK.FVoyage1st   FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO And C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & UCase(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & UCase(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND C.CargoType ='" & KVal(cmbCargoType.Text) & "' ORDER BY BK.BLNO, MV.VESSELNAME, BK.BKNO asc"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read
                InputTextC(MvColStart, MvRowStart, True, 15.75, 5.64, 12, "Cambria Bold", "L", Dbo.reader(0).ToString & " V-" & Dbo.reader(1).ToString, True, sheet)

                Dim FinalEta, FinalEtd As DateTime
                Dim FinalEtaEtd As String = ""
                FinalEta = Dbo.reader(2).ToString
                FinalEtd = Dbo.reader(3).ToString

                If FinalEta.Year = FinalEtd.Year Then
                    FinalEtaEtd = Format(FinalEta, "MMM. dd-") & Format(FinalEtd, "dd, yyyy")
                Else
                    FinalEtaEtd = Format(FinalEta, "MMM. dd, yyyy") & Format(FinalEtd, "MMM. dd, yyyy")
                End If

                InputTextC(MvColStart, MvRowStart + 1, True, 15.75, 5.64, 12, "Cambria Bold", "L", "ETA " & Dbo.reader(4).ToString & ": " & FinalEtaEtd, True, sheet)

                Call PopulateMvEta(MvRowStart, MvColStart, sheet, Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(5).ToString, Dbo.reader(6).ToString, StartDetailsRow)


                MvColStart = MvColStart + 1
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

            DetaisMaxRow = DetaisMaxRow + 3


            Dim startRow As Integer = DetaisMaxRow
            Dim StartCol As Integer = 1
            Dim row As Integer = 0
            Dim StartDetailRows As Integer = 0
            Dim EndDetailRows As Integer = 0


            row = startRow

            'InputTextF("" & row & ":" & row, True, 31.5, 5.64, 9, "Cambria Italic", "C", "", True, sheet)

            InputTextF("A" & row & ":A" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "Vessel / Voyage", True, sheet)


            InputTextF("B" & row & ":B" & row, True, 15.75, 5.64, 9, "Cambria Italic", "C", "       Container       ", True, sheet)
            InputTextF("B" & row + 1 & ":B" & row + 1, True, 31.5, 5.64, 9, "Cambria Italic", "C", "Number", True, sheet)

            InputTextF("C" & row & ":C" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "Size / Type", True, sheet)


            InputTextF("D" & row & ":D" & row, True, 15.75, 5.64, 9, "Cambria Italic", "C", "       Seal       ", True, sheet)
            InputTextF("D" & row + 1 & ":D" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "Number", True, sheet)


            InputTextF("E" & row & ":E" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "      B/L      ", True, sheet)
            InputTextF("F" & row & ":F" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "      CONSIGNEE      ", True, sheet)
            InputTextF("G" & row & ":G" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "      V G M      ", True, sheet)

            InputTextF("H" & row & ":H" & row, True, 15.75, 5.64, 9, "Cambria Italic", "C", "       Svc. Type       ", True, sheet)
            InputTextF("H" & row + 1 & ":H" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "CY or CFS", True, sheet)

            InputTextF("I" & row & ":I" & row, True, 15.75, 5.64, 9, "Cambria Italic", "C", "       Port of       ", True, sheet)
            InputTextF("I" & row + 1 & ":I" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "Discharge", True, sheet)

            InputTextF("J" & row & ":J" & row, True, 15.75, 5.64, 9, "Cambria Italic", "C", "      Vessel Eta and      ", True, sheet)
            InputTextF("J" & row + 1 & ":J" & row + 1, True, 15.75, 5.64, 9, "Cambria Italic", "C", "Destination", True, sheet)



            row = row + 2

            StartDetailRows = row


            Dbo.SqlCon.Open()
            SQL = "SELECT     MV.VESSELNAME as MotherVessel , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, BK.BLNO, CONSIGNEE.ClientName AS CONSIGNEE, C.VGM, BK.ServiceType, POD1.NAME AS POD, PRT.NAME AS PORTIS,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType   FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND C.CARGOTYPE = '" & KVal(cmbCargoType.Text) & "' ORDER BY BK.BLNO, MV.VESSELNAME, BK.BKNO asc"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Dim MVCounter As Integer = 0
            Do While Dbo.reader.Read

                'COUNTER
                'SELECT COUNT(1) FROM   TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE 'KYOWA FALCON%' AND ISNULL(BK.FVoyage1st,'') LIKE 'KF001%' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%'  AND  MV.VESSELNAME = 'MING SUN' AND MVoyage = 'MS001'

                InputTextF("A" & row & ":A" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(0).ToString & " V-" & Dbo.reader(1).ToString, True, sheet)
                InputTextF("B" & row & ":B" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(4).ToString, True, sheet)

                If Dbo.reader(5).ToString = "10DC" Then
                    _10DC = _10DC + 1
                    T_10DC = T_10DC + 1
                ElseIf Dbo.reader(5).ToString = "20DC" Then
                    _20DC = _20DC + 1
                    T_20DC = T_20DC + 1
                ElseIf Dbo.reader(5).ToString = "40DC" Then
                    _40DC = _40DC + 1
                    T_40DC = T_40DC + 2
                ElseIf Dbo.reader(5).ToString = "40HQ" Then
                    _40HQ = _40HQ + 1
                    T_40HQ = T_40HQ + 2
                ElseIf Dbo.reader(5).ToString = "40RF" Then
                    _40RF = _40RF + 1
                    T_40HQ = T_40HQ + 2
                End If

                InputTextF("C" & row & ":C" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(5).ToString, True, sheet)
                InputTextF("D" & row & ":D" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(6).ToString, True, sheet)
                InputTextF("E" & row & ":E" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(7).ToString, True, sheet)
                InputTextF("F" & row & ":F" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(8).ToString, True, sheet)
                InputTextNum("G" & row & ":G" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(9).ToString, True, sheet, "N", "0.00")
                InputTextF("H" & row & ":H" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(10).ToString, True, sheet)
                InputTextF("I" & row & ":I" & row, True, 22.5, 5.64, 9, "Cambria", "C", Dbo.reader(11).ToString, True, sheet)

                Dim FinalEta, FinalEtd As DateTime
                Dim FinalEtaEtd As String = ""
                FinalEta = Dbo.reader(13).ToString
                FinalEtd = Dbo.reader(14).ToString

                If FinalEta.Year = FinalEtd.Year Then
                    FinalEtaEtd = Format(FinalEta, "MMM. dd-") & Format(FinalEtd, "dd, yyyy")
                Else
                    FinalEtaEtd = Format(FinalEta, "MMM. dd, yyyy") & Format(FinalEtd, "MMM. dd, yyyy")
                End If

                InputTextF("J" & row & ":J" & row, True, 22.5, 5.64, 9, "Cambria", "L", "ETA " & Dbo.reader(12).ToString & ": " & UCase(FinalEtaEtd), True, sheet)


                row = row + 1
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

            EndDetailRows = row

            row = row + 2

            InputTextF("A" & row & ":A" & row, True, 15.75, 5.64, 12, "Cambria Italic", "R", "No. of Cntr.", True, sheet)
            InputTextF("B" & row & ":B" & row, True, 15.75, 5.64, 12, "Cambria", "C", "10DC", True, sheet)
            InputTextF("C" & row & ":C" & row, True, 15.75, 5.64, 12, "Cambria", "C", "20DC", True, sheet)
            InputTextF("D" & row & ":D" & row, True, 15.75, 5.64, 12, "Cambria", "C", "40DC", True, sheet)
            InputTextF("E" & row & ":E" & row, True, 15.75, 5.64, 12, "Cambria", "C", "40HQ", True, sheet)
            InputTextF("F" & row & ":F" & row, True, 15.75, 5.64, 12, "Cambria", "C", "40RF", True, sheet)

            row = row + 1

            Dim TotalStartRow = 0, TotalEndRow = 0, SignatureRow As Integer = 0

            TotalStartRow = row

            SignatureRow = row + 2

            Dbo.SqlCon.Open()
            SQL = "SELECT  PRT.NAME as PORTIS, 
(SELECT    IIF(C1.SizeIs = '10DC',COUNT(C1.SIZEIS),0) AS '10DC' FROM TBL_BOOKING AS BK1 LEFT JOIN TBL_OUTPORT AS OP1 ON BK1.OptnMode = OP1.ID LEFT JOIN TBL_CLIENT AS SHIPPER1 ON BK1.Shipper = SHIPPER1.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE1 ON BK1.Consignee = CONSIGNEE1.ID LEFT JOIN TBL_CLIENT AS NOTIFY1 ON BK1.Notify = NOTIFY1.ID LEFT JOIN TBL_VESSEL AS V11 ON BK1.FeederVessel1st = V11.ID LEFT JOIN TBL_VESSEL AS V21 ON BK1.FeederVessel2nd = V21.ID LEFT JOIN TBL_VESSEL AS MV1 ON BK1.MotherVessel = MV1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL11 ON BK1.FeederPOL1st = POL11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD11 ON BK1.FeederPOD1st = POD11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL21 ON BK1.FeederVessel2ndPOL = POL21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD21 ON BK1.FeederVessel2ndPOD = POD21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL1 ON BK1.MotherVesselLoading = MVPOL1.ID LEFT JOIN TBL_TRADE AS TR1 ON BK1.TRADE = TR1.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST1 on bk1.SUB_TRADE = st1.ID LEFT JOIN TBL_PORTS AS PRT1 ON BK1.PORTS = PRT1.ID LEFT JOIN TBL_CONTAINER AS C1 ON BK1.BKNO = C1.BKNO AND C1.STAT = '1' WHERE          (BK1.Stat <> N'2')   AND V11.VESSELNAME LIKE V1.VESSELNAME AND ISNULL(BK1.FVoyage1st,'') LIKE BK.FVoyage1st AND ISNULL(MV1.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND  PRT1.NAME = PRT.NAME AND C1.SizeIs = '10DC' GROUP BY C1.SizeIs) AS _10DC,
(SELECT    IIF(C1.SizeIs = '20DC',COUNT(C1.SIZEIS),0) AS '20DC' FROM TBL_BOOKING AS BK1 LEFT JOIN TBL_OUTPORT AS OP1 ON BK1.OptnMode = OP1.ID LEFT JOIN TBL_CLIENT AS SHIPPER1 ON BK1.Shipper = SHIPPER1.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE1 ON BK1.Consignee = CONSIGNEE1.ID LEFT JOIN TBL_CLIENT AS NOTIFY1 ON BK1.Notify = NOTIFY1.ID LEFT JOIN TBL_VESSEL AS V11 ON BK1.FeederVessel1st = V11.ID LEFT JOIN TBL_VESSEL AS V21 ON BK1.FeederVessel2nd = V21.ID LEFT JOIN TBL_VESSEL AS MV1 ON BK1.MotherVessel = MV1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL11 ON BK1.FeederPOL1st = POL11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD11 ON BK1.FeederPOD1st = POD11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL21 ON BK1.FeederVessel2ndPOL = POL21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD21 ON BK1.FeederVessel2ndPOD = POD21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL1 ON BK1.MotherVesselLoading = MVPOL1.ID LEFT JOIN TBL_TRADE AS TR1 ON BK1.TRADE = TR1.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST1 on bk1.SUB_TRADE = st1.ID LEFT JOIN TBL_PORTS AS PRT1 ON BK1.PORTS = PRT1.ID LEFT JOIN TBL_CONTAINER AS C1 ON BK1.BKNO = C1.BKNO AND C1.STAT = '1' WHERE          (BK1.Stat <> N'2')   AND V11.VESSELNAME LIKE V1.VESSELNAME AND ISNULL(BK1.FVoyage1st,'') LIKE BK.FVoyage1st AND ISNULL(MV1.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND  PRT1.NAME = PRT.NAME AND C1.SizeIs = '20DC' GROUP BY C1.SizeIs) AS _20DC,
(SELECT    IIF(C1.SizeIs = '40DC',COUNT(C1.SIZEIS),0) AS '40DC' FROM TBL_BOOKING AS BK1 LEFT JOIN TBL_OUTPORT AS OP1 ON BK1.OptnMode = OP1.ID LEFT JOIN TBL_CLIENT AS SHIPPER1 ON BK1.Shipper = SHIPPER1.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE1 ON BK1.Consignee = CONSIGNEE1.ID LEFT JOIN TBL_CLIENT AS NOTIFY1 ON BK1.Notify = NOTIFY1.ID LEFT JOIN TBL_VESSEL AS V11 ON BK1.FeederVessel1st = V11.ID LEFT JOIN TBL_VESSEL AS V21 ON BK1.FeederVessel2nd = V21.ID LEFT JOIN TBL_VESSEL AS MV1 ON BK1.MotherVessel = MV1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL11 ON BK1.FeederPOL1st = POL11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD11 ON BK1.FeederPOD1st = POD11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL21 ON BK1.FeederVessel2ndPOL = POL21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD21 ON BK1.FeederVessel2ndPOD = POD21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL1 ON BK1.MotherVesselLoading = MVPOL1.ID LEFT JOIN TBL_TRADE AS TR1 ON BK1.TRADE = TR1.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST1 on bk1.SUB_TRADE = st1.ID LEFT JOIN TBL_PORTS AS PRT1 ON BK1.PORTS = PRT1.ID LEFT JOIN TBL_CONTAINER AS C1 ON BK1.BKNO = C1.BKNO AND C1.STAT = '1' WHERE          (BK1.Stat <> N'2')   AND V11.VESSELNAME LIKE V1.VESSELNAME AND ISNULL(BK1.FVoyage1st,'') LIKE BK.FVoyage1st AND ISNULL(MV1.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND  PRT1.NAME = PRT.NAME AND C1.SizeIs = '40DC' GROUP BY C1.SizeIs) AS _40DC,
(SELECT    IIF(C1.SizeIs = '40HQ',COUNT(C1.SIZEIS),0) AS '40HQ' FROM TBL_BOOKING AS BK1 LEFT JOIN TBL_OUTPORT AS OP1 ON BK1.OptnMode = OP1.ID LEFT JOIN TBL_CLIENT AS SHIPPER1 ON BK1.Shipper = SHIPPER1.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE1 ON BK1.Consignee = CONSIGNEE1.ID LEFT JOIN TBL_CLIENT AS NOTIFY1 ON BK1.Notify = NOTIFY1.ID LEFT JOIN TBL_VESSEL AS V11 ON BK1.FeederVessel1st = V11.ID LEFT JOIN TBL_VESSEL AS V21 ON BK1.FeederVessel2nd = V21.ID LEFT JOIN TBL_VESSEL AS MV1 ON BK1.MotherVessel = MV1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL11 ON BK1.FeederPOL1st = POL11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD11 ON BK1.FeederPOD1st = POD11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL21 ON BK1.FeederVessel2ndPOL = POL21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD21 ON BK1.FeederVessel2ndPOD = POD21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL1 ON BK1.MotherVesselLoading = MVPOL1.ID LEFT JOIN TBL_TRADE AS TR1 ON BK1.TRADE = TR1.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST1 on bk1.SUB_TRADE = st1.ID LEFT JOIN TBL_PORTS AS PRT1 ON BK1.PORTS = PRT1.ID LEFT JOIN TBL_CONTAINER AS C1 ON BK1.BKNO = C1.BKNO AND C1.STAT = '1' WHERE          (BK1.Stat <> N'2')   AND V11.VESSELNAME LIKE V1.VESSELNAME AND ISNULL(BK1.FVoyage1st,'') LIKE BK.FVoyage1st AND ISNULL(MV1.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND  PRT1.NAME = PRT.NAME AND C1.SizeIs = '40HQ' GROUP BY C1.SizeIs) AS _40HQ,
(SELECT    IIF(C1.SizeIs = '40RF',COUNT(C1.SIZEIS),0) AS '40RF' FROM TBL_BOOKING AS BK1 LEFT JOIN TBL_OUTPORT AS OP1 ON BK1.OptnMode = OP1.ID LEFT JOIN TBL_CLIENT AS SHIPPER1 ON BK1.Shipper = SHIPPER1.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE1 ON BK1.Consignee = CONSIGNEE1.ID LEFT JOIN TBL_CLIENT AS NOTIFY1 ON BK1.Notify = NOTIFY1.ID LEFT JOIN TBL_VESSEL AS V11 ON BK1.FeederVessel1st = V11.ID LEFT JOIN TBL_VESSEL AS V21 ON BK1.FeederVessel2nd = V21.ID LEFT JOIN TBL_VESSEL AS MV1 ON BK1.MotherVessel = MV1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL11 ON BK1.FeederPOL1st = POL11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD11 ON BK1.FeederPOD1st = POD11.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL21 ON BK1.FeederVessel2ndPOL = POL21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD21 ON BK1.FeederVessel2ndPOD = POD21.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL1 ON BK1.MotherVesselLoading = MVPOL1.ID LEFT JOIN TBL_TRADE AS TR1 ON BK1.TRADE = TR1.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST1 on bk1.SUB_TRADE = st1.ID LEFT JOIN TBL_PORTS AS PRT1 ON BK1.PORTS = PRT1.ID LEFT JOIN TBL_CONTAINER AS C1 ON BK1.BKNO = C1.BKNO AND C1.STAT = '1' WHERE          (BK1.Stat <> N'2')   AND V11.VESSELNAME LIKE V1.VESSELNAME AND ISNULL(BK1.FVoyage1st,'') LIKE BK.FVoyage1st AND ISNULL(MV1.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND  PRT1.NAME = PRT.NAME AND C1.SizeIs = '40RF' GROUP BY C1.SizeIs) AS _40RF
FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%'  AND C.CARGOTYPE = '" & KVal(cmbCargoType.Text) & "'  GROUP BY PRT.NAME , V1.VESSELNAME, BK.FVoyage1st ORDER BY PRT.NAME asc"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read
                InputTextF("A" & row & ":A" & row, True, 15.75, 5.64, 12, "Cambria Italic", "R", Dbo.reader(0).ToString, True, sheet)
                InputTextF("B" & row & ":B" & row, True, 15.75, 5.64, 12, "Cambria", "C", Dbo.reader(1).ToString, True, sheet)
                InputTextF("C" & row & ":C" & row, True, 15.75, 5.64, 12, "Cambria", "C", Dbo.reader(2).ToString, True, sheet)
                InputTextF("D" & row & ":D" & row, True, 15.75, 5.64, 12, "Cambria", "C", Dbo.reader(3).ToString, True, sheet)
                InputTextF("E" & row & ":E" & row, True, 15.75, 5.64, 12, "Cambria", "C", Dbo.reader(4).ToString, True, sheet)
                InputTextF("F" & row & ":F" & row, True, 15.75, 5.64, 12, "Cambria", "C", Dbo.reader(5).ToString, True, sheet)
                row = row + 1



                'If Signature = 0 Then
                '    sheet.Range("H" & row & ":I" & row).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                '    InputTextF("H" & row & ":I" & row, True, 15.75, 5.64, 12, "Cambria Italic", "C", "SKY INTERNATIONAL INC.", True, sheet)
                '    InputTextF("H" & row + 1 & ":I" & row + 1, True, 15.75, 5.64, 12, "Cambria Italic", "C", "As Agent", True, sheet)
                'End If
                'Signature = Signature + 1

            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()


            sheet.Range("B" & row & ":B" & row).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            InputTextF("B" & row & ":B" & row, True, 15.75, 5.64, 12, "Cambria Italic", "C", _10DC & "X10DC", True, sheet)
            sheet.Range("B" & row & ":B" & row).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble

            sheet.Range("C" & row & ":C" & row).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            InputTextF("C" & row & ":C" & row, True, 15.75, 5.64, 12, "Cambria Italic", "C", _20DC & "X20DC", True, sheet)
            sheet.Range("C" & row & ":C" & row).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble

            sheet.Range("D" & row & ":D" & row).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            InputTextF("D" & row & ":D" & row, True, 15.75, 5.64, 12, "Cambria Italic", "C", _40DC & "X40DC", True, sheet)
            sheet.Range("D" & row & ":D" & row).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble

            sheet.Range("E" & row & ":E" & row).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            InputTextF("E" & row & ":E" & row, True, 15.75, 5.64, 12, "Cambria Italic", "C", _40HQ & "X40HQ", True, sheet)
            sheet.Range("E" & row & ":E" & row).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble

            sheet.Range("F" & row & ":F" & row).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            InputTextF("F" & row & ":F" & row, True, 15.75, 5.64, 12, "Cambria Italic", "C", _40RF & "X40RF", True, sheet)
            sheet.Range("F" & row & ":F" & row).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlDouble

            TotalEndRow = row


            Dim TotalTeusStr = "", CutTotalTeus As String = ""

            Dim Teus10DCStr = "", Teus20DCStr = "", Teus40DCStr = "", Teus40HQStr = "", Teus40RFStr As String = ""


            Teus10DCStr = _10DC & "X10DC & "
            Teus20DCStr = _20DC & "X20DC & "
            Teus40DCStr = _40DC & "X40DC & "
            Teus40HQStr = _40HQ & "X40HQ & "
            Teus40RFStr = _40RF & "X40RF & "

            If _40RF = 0 Then
                sheet.Range("F" & TotalStartRow - 1 & ":F" & TotalEndRow).Delete(1)
                Teus40RFStr = ""
            End If

            If _40HQ = 0 Then
                sheet.Range("E" & TotalStartRow - 1 & ":E" & TotalEndRow).Delete(1)
                Teus40HQStr = ""
            End If

            If _40DC = 0 Then
                sheet.Range("D" & TotalStartRow - 1 & ":D" & TotalEndRow).Delete(1)
                Teus40DCStr = ""
            End If

            If _20DC = 0 Then
                sheet.Range("C" & TotalStartRow - 1 & ":C" & TotalEndRow).Delete(1)
                Teus20DCStr = ""
            End If

            If _10DC = 0 Then
                sheet.Range("B" & TotalStartRow - 1 & ":B" & TotalEndRow).Delete(1)
                Teus10DCStr = ""
            End If

            TotalTeusStr = "TOTAL: " & Teus10DCStr & Teus20DCStr & Teus40DCStr & Teus40HQStr & Teus40HQStr

            If VisualBasic.Right(TotalTeusStr, 2) = "& " Then
                TotalTeusStr = VisualBasic.Left(TotalTeusStr, Len(TotalTeusStr) - 2)
            End If

            Dim TotalTeus As Double = 0

            TotalTeus = Val(T_10DC) + Val(T_20DC) + Val(T_40DC) + Val(T_40HQ) + Val(T_40RF)

            TotalTeusStr = TotalTeusStr & "= " & TotalTeus & IIf(TotalTeus > 1, " TEU'S", "TEUS")

            sheet.Range("H" & SignatureRow & ":I" & SignatureRow).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                InputTextF("H" & SignatureRow & ":I" & SignatureRow, True, 15.75, 5.64, 12, "Cambria Italic", "C", "SKY INTERNATIONAL INC.", True, sheet)
                InputTextF("H" & SignatureRow + 1 & ":I" & SignatureRow + 1, True, 15.75, 5.64, 12, "Cambria Italic", "C", "As Agent", True, sheet)

                SignatureRow = SignatureRow + 2
                InputTextF("E" & SignatureRow & ":E" & SignatureRow, True, 15.75, 5.64, 12, "Cambria Italic", "C", TotalTeusStr, True, sheet)

                'If _20DC > 0 Then
                '    InputTextF("B" & row & ":B" & row, True, 31.5, 5.64, 9, "Cambria", "C", "20DC", True, sheet)
                'End If

                'InputTextF("" & row & ":" & row, True, 31.5, 5.64, 9, "Cambria Italic", "C", "", True, sheet)



                sheet.Columns("A:AZ").AutoFit()


                'For i As Integer = StartDetailRows To EndDetailRows
                'sheet.Range("A" & StartDetailRows & ":J" & EndDetailRows).BorderAround.LineStyle = Excel.XlLineStyle.xlContinuous
                sheet.Range("A" & StartDetailRows - 2 & ":" & "J" & EndDetailRows - 1).Borders.Weight = Excel.XlBorderWeight.xlThin
            'Next

            InputTextF("F1:I1", True, 25.5, 5.64, 20, "Cambria", "L", "KYOWA SHIPPING CO., LTD.", True, sheet)
            InputTextF("F2:I2", True, 25.5, 5.64, 20, "Cambria", "L", "    SUMMARY OF BOOKING", True, sheet)

            InputTextF("A1:A1", True, 25.5, 5.64, 12, "Cambria Italic", "L", "TO: DONGSHIN MARITIME AGENCY / MS. Y.H.CHO", True, sheet)
            InputTextF("A2:A2", True, 25.5, 5.64, 12, "Cambria Italic", "L", "KYOWA TOKYO/ATTN : KYOWA MARKETING / KYOWA OPERATION", True, sheet)
            InputTextF("A3:A3", True, 15.75, 5.64, 12, "Cambria Italic", "L", "FM : SKY INTERNATIONAL - MS. CHELSEA CHIAPCO", True, sheet)
            'InputTextF("A4:A4", True, 15.75, 5.64, 12, "Cambria Italic", "L", "REF. NO.: 010A (HYUNDAI) 03/18/2021", True, sheet)
            InputTextF("A4:A4", True, 15.75, 5.64, 12, "Cambria Italic", "L", "REF. NO.: " & KVal(cmbSequence.Text) & IIf(UCase(cmbCargoType.Text) = "GENERAL", "A", "B") & " (" & KVal(cmbFeederCarrier.Text) & ") " & Format(Now, "MM/dd/yyyy"), True, sheet)

            'xls.Visible = True
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class