Imports Microsoft.Office.Interop
Imports Microsoft
Public Class FrmGenerateOnhireUnitsMenu
    Private Sub FrmGenerateOnhireUnitsMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadStrCmb(cmbCy, "SELECT DISTINCT CYNAME,  CYNAME FROM TBL_ONHIRE_UNITS WHERE STAT = '1'")
        Call LoadStrCmb(cmbBookingNo, "SELECT DISTINCT BKNO, BKNO FROM TBL_ONHIRE_UNITS WHERE STAT = '1'")

    End Sub

    Private Sub cmbBookingNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBookingNo.SelectedIndexChanged
        cmbOnhire.Text = GetRyzk("SELECT DISTINCT onhire_company + ' ' + NosOfContainer FROM TBL_ONHIRE_UNITS WHERE STAT = '1' AND CYNAME = '" & KVal(cmbCy.Text) & "' AND BKNO = '" & KVal(cmbBookingNo.Text) & "'", "")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SQL = "SELECT cyname, BKNO, ONHIRE_COMPANY, NOSOFCONTAINER,VALIDITY_DATE,  Shipper, SIZE, LCT, ContainerNo, PulloutDate FROM TBL_ONHIRE_UNITS WHERE STAT = '1' AND CYNAME = '" & KVal(cmbCy.Text) & "' AND BKNO = '" & KVal(cmbBookingNo.Text) & "' AND CONVERT(DATE,VALIDITY_DATE) BETWEEN '" & dtValidity.Value & "' AND '" & dtValidity.Value & "'"
        If GetRyzk(SQL, "") = NoRecordFound Then
            MsgBox("No record found!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Generate on-hire units report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim d7 = "", d9 As String = ""

            Dim _10DC = 0, _20DC = 0, _40DC = 0, _40HQ = 0, _40RF As Integer = 0

            Dim T_10DC = 0, T_20DC = 0, T_40DC = 0, T_40HQ = 0, T_40RF As Integer = 0

            Dim RowStart As Integer = 9
            Dim ColStart As Integer = 2
            Dim itemCount As Integer = 1
            Dim HeaderRowStart As Integer = 7
            Dim DetailStartRow = 0, DetailRowEnd As Integer = 0

            Dim strcyName = "", strOnHireUnit = "", strBKNO = "", strValidityDate = "", strNosOfContainer As String = ""


            Dim Dbo As New SQLClass


            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet




            ColStart = 1

            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 9, "Arial Black", "C", "NOS.", False, sheet, Color.Black, 6)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 9, "Arial Black", "C", "SHIPPER.", False, sheet, Color.Black, 6)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 9, "Arial Black", "C", "    SIZE    ", False, sheet, Color.Black, 6)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 9, "Arial Black", "C", "    LCT OF FV    ", False, sheet, Color.Black, 6)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 9, "Arial Black", "C", "    CONTAINER NO.    ", False, sheet, Color.Black, 6)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 18, 5.64, 9, "Arial Black", "C", "    PULL-OUT DATE    ", False, sheet, Color.Black, 6)


            'ColStart += 1
            'InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "COMMODITY", False, sheet, Color.Black, 44)
            'ColStart += 1
            'InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "DESTINATION", False, sheet, Color.Black, 44)
            'ColStart += 1
            'InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "GATE-IN", False, sheet, Color.Black, 44)
            'ColStart += 1
            'InputTextCFB(ColStart, RowStart, True, 18, 5.64, 8, "Arial Black", "C", "STORAGE", False, sheet, Color.Black, 44)


            RowStart += 1

            ColStart = 1

            DetailStartRow = RowStart


            Dbo.SqlCon.Open()
            'SQL = "SELECT  bk.CoLoaderBkno , v1.VESSELNAME, bk.FVoyage1st, POL1.NAME AS F1_POL , POD1.NAME AS F1_POD,  BK.F1_ETA as F1_ETA, BK.F1_ETD  as F1_ETD   , C.ContainerNo, C.SizeIs, C.SealNo,SHIPPER.ClientName AS SHIPPER, C.VGM, BK.Commodity, POD1.NAME AS POD, PRT.NAME AS PORTIS, C.GateInDate,                 MV.VESSELNAME as MotherVessel , MVoyage , BK.MV_ETA, BK.MV_ETD  , C.ContainerNo, C.SizeIs, C.SealNo, C.GateInDate , SHIPPER.ClientName AS SHIPPER, BK.BLNO, CONSIGNEE.ClientName AS CONSIGNEE, C.VGM, BK.ServiceType, POD1.NAME AS POD, PRT.NAME AS PORTIS,BK.FINAL_DEST_ETA, BK.FINAL_DEST_ETD, C.CargoType   FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS C ON BK.BKNO = C.BKNO AND C.STAT = '1' WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFV.Text) & "' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbVoy.Text) & "' AND ISNULL(MV.VESSELNAME,'') LIKE '%' AND ISNULL(MVOYAGE,'') LIKE '%' AND C.CargoType = '" & KVal(cmbCargoType.Text) & "' ORDER BY BK.BLNO, MV.VESSELNAME, BK.BKNO asc"

            SQL = "SELECT cyname, BKNO, ONHIRE_COMPANY, NOSOFCONTAINER,VALIDITY_DATE,  Shipper, SIZE, LCT, ContainerNo, PulloutDate FROM TBL_ONHIRE_UNITS WHERE STAT = '1' AND CYNAME = '" & KVal(cmbCy.Text) & "' AND BKNO = '" & KVal(cmbBookingNo.Text) & "' AND CONVERT(DATE,VALIDITY_DATE) BETWEEN '" & dtValidity.Value & "' AND '" & dtValidity.Value & "'"

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read

                If Not Dbo.reader(7).ToString = "/  /       :" Then
                    d7 = Format(CDate(Dbo.reader(7).ToString), "MM/dd/yyyy hh:mm")
                End If
                If Not Dbo.reader(9).ToString = "/  /       :" Then
                    d9 = Format(CDate(Dbo.reader(9).ToString), "MM/dd/yyyy hh:mm")
                End If

                InputTextCFB(ColStart, RowStart, True, 23.25, 5.64, 8, "Arial Black", "C", itemCount, False, sheet, Color.Black, 6)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 23.25, 5.64, 12, "Cambria", "C", Dbo.reader(5).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 23.25, 5.64, 12, "Cambria", "C", Dbo.reader(6).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 23.25, 5.64, 12, "Cambria", "C", d7, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 23.25, 5.64, 12, "Cambria", "C", Dbo.reader(8).ToString, False, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCFB(ColStart, RowStart, True, 23.25, 5.64, 12, "Cambria", "C", d9, False, sheet, Color.Black, 0)




                ColStart = 1
                itemCount += 1
                RowStart += 1

                strcyName = Dbo.reader(0).ToString
                strOnHireUnit = Dbo.reader(2).ToString
                strBKNO = Dbo.reader(1).ToString
                strValidityDate = Dbo.reader(4).ToString
                strNosOfContainer = Dbo.reader(3).ToString

            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

            DetailRowEnd = RowStart




            InputTextRFC("A" & HeaderRowStart & ":F" & HeaderRowStart, True, 25, 5.64, 20, "Cambria bold", "C", KVal(strcyName), True, sheet, Color.Black)
            HeaderRowStart += 1
            InputTextRFC("A" & HeaderRowStart & ":F" & HeaderRowStart, True, 15.75, 5.64, 12, "Cambria bold", "C", KVal(strOnHireUnit & "   " & KVal(strNosOfContainer)) & "   " & KVal(strBKNO) & "   VALIDITY:" & (Format(CDate(strValidityDate), "MM/dd/yyyy")), True, sheet, Color.Black)
            'HeaderRowStart += 1
            'InputTextRFC("A" & HeaderRowStart & ":F" & HeaderRowStart, True, 15.75, 5.64, 12, "Cambria bold", "C", KVal(strBKNO) & "   " & (Format(CDate(strValidityDate), "MM/dd/yyyy")), True, sheet, Color.Black)

            sheet.Range("A" & HeaderRowStart - 1 & ":" & "F" & DetailRowEnd - 1).Borders.Weight = Excel.XlBorderWeight.xlThin




            InputTextRFC("A" & 2 & ":F" & 2, True, 30, 5.64, 26, "Cambria Bold", "C", "KYOWA SHIPPING LINE CO., LTD.", True, sheet, Color.Black)
            InputTextRFC("A" & 3 & ":F" & 3, True, 15, 5.64, 11, "Cambria Bold", "C", "10th flr.Sky 1 Tower, #68 Dasmariñas St.Binondo,Metro Manila", True, sheet, Color.Black)
            InputTextRFC("A" & 4 & ":F" & 4, True, 15, 5.64, 11, "Cambria Bold", "C", "Tel.No.243-02-01 to 12 /Fax Nos.242-2059,2442632,2422257", True, sheet, Color.Black)

            sheet.Columns("A:AZ").AutoFit()
            xls.Visible = True
        End If

    End Sub

    Private Sub cmbCy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCy.SelectedIndexChanged
        cmbOnhire.Text = GetRyzk("SELECT DISTINCT onhire_company + ' ' + NosOfContainer FROM TBL_ONHIRE_UNITS WHERE STAT = '1' AND CYNAME = '" & KVal(cmbCy.Text) & "' AND BKNO = '" & KVal(cmbBookingNo.Text) & "'", "")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class