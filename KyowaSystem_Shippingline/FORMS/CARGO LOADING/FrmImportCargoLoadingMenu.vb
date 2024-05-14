Imports Microsoft.Office.Interop

Public Class FrmImportCargoLoadingMenu
    Dim RateForIs = "", ReportForIs As String = ""
    Dim contTotal = 0, RateCountTotal As Integer = 0
    Dim TotalUSD = 0.00, TotalPHP As Double = 0.00
    Dim ERATEis As Double = 0.00
    Dim SumPHPTotal = 0.00, ConvertToPHP As Double = 0.00
    Dim RowStartBorder = 0, RowEndBorder As Integer = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet


        Dim RowStart As Integer = 6
        Dim ColStart As Integer = 1


        ReportForIs = ""

        If rdFCL.Checked = True Then
            ReportForIs = "F"
        Else
            ReportForIs = "L"
        End If



        If rdDestination.Checked = True Then
            RateForIs = "DESTINATION"
        ElseIf rdPrincipal.Checked = True Then
            RateForIs = "PRINCIPAL"
        ElseIf rdBilling.Checked = True Then
            RateForIs = "BILLING"
        End If





        Dim Dbo As New SQLClass


        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet


        xls.Visible = True

        RowStartBorder = RowStart - 1

        Dbo.SqlCon.Open()
        'SQL = "SELECT DISTINCT D.NAME    FROM TBL_CONTAINER_BOOKING AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO LEFT JOIN TBL_OPERATIONS AS O ON C.BKNO = O .BKNO AND O.STAT <> '0' LEFT JOIN TBL_DEPOT AS D ON O.DEPOT = D.ID LEFT JOIN TBL_CLIENT AS CC ON B.Shipper = CC.ID LEFT JOIN TBL_PORTS AS PRT ON B.PORTS = PRT.ID   WHERE C.STAT <> '2' AND B.STAT <> '2' AND O.BKNO <> '2' AND D.NAME IS NOT NULL  ORDER BY D.NAME ASC"
        'SQL = "SELECT DISTINCT D.NAME, C.LeasingContainer, c.ContBookingNum, (SELECT DISTINCT   ValidityDate  + ', '   FROM TBL_CONTAINER_BOOKING AS C2 LEFT JOIN TBL_BOOKING AS B2 ON C2.BKNO = B2.BKNO LEFT JOIN TBL_OPERATIONS AS O2 ON C2.BKNO = O2.BKNO AND O2.STAT <> '0' LEFT JOIN TBL_DEPOT AS D2 ON O2.DEPOT = D2.ID LEFT JOIN TBL_CLIENT AS CC2 ON B.Shipper = CC2.ID LEFT JOIN TBL_PORTS AS PRT2 ON B2.PORTS = PRT2.ID    WHERE C2.STAT <> '2' AND B2.STAT <> '2' AND O2.BKNO <> '2' AND D2.NAME IS NOT NULL AND D2.NAME = d.NAME AND C2.LeasingContainer = c.LeasingContainer AND C2.ContBookingNum = c.ContBookingNum  FOR XML PATH('')) AS ValidityDate   FROM TBL_CONTAINER_BOOKING AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO LEFT JOIN TBL_OPERATIONS AS O ON C.BKNO = O .BKNO AND O.STAT <> '0' LEFT JOIN TBL_DEPOT AS D ON O.DEPOT = D.ID LEFT JOIN TBL_CLIENT AS CC ON B.Shipper = CC.ID LEFT JOIN TBL_PORTS AS PRT ON B.PORTS = PRT.ID   WHERE C.STAT <> '2' AND B.STAT <> '2' AND O.BKNO <> '2' AND D.NAME IS NOT NULL  ORDER BY D.NAME ASC"
        SQL = "SELECT   MVPOL.NAME as MotherVesselPol, BK.BLNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE,   MV.VESSELNAME as MotherVessel, BK.MV_ETA, PRT.NAME AS PORTIS   ,'xxxxxxxxxxxxxxxxxx', BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE  ISNULL(BK.BLNO,'') <> ''       AND  (BK.Stat <> N'2') AND BK.BKNO LIKE  'BKN' ++ '" & LandingForm.ServiceIs & "' ++ '-' ++ '" & ReportForIs & "' ++ '%'   ORDER BY BK.BKNO DESC"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            TotalUSD = 0.00
            'contTotal = 0
            InputTextCFB(ColStart, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", Dbo.reader(0).ToString, True, sheet, Color.Black, 27)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", "     " & Dbo.reader(1).ToString & "     ", True, sheet, Color.Black, 0)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", Dbo.reader(2).ToString, True, sheet, Color.Black, 0)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", Dbo.reader(3).ToString, True, sheet, Color.Black, 0)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", Dbo.reader(4).ToString, True, sheet, Color.Black, 0)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", UCase(Format(CDate(Dbo.reader(5).ToString), "MMM dd") & "@ " & Format(CDate(Dbo.reader(5).ToString), "HHmm")), True, sheet, Color.Black, 0)
            ColStart += 1
            InputTextCFB(ColStart, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", Dbo.reader(6).ToString, True, sheet, Color.Black, 0)
            ColStart += 1
            Call DisplayContainers(Dbo.reader(10).ToString, RowStart, ColStart, sheet, Dbo.reader(1).ToString)
            ColStart += 1
            Call DisplayRates(Dbo.reader(1).ToString, RowStart, ColStart, sheet)



            ColStart = 1
            If contTotal < RateCountTotal Then
                RowStart = RateCountTotal
            ElseIf contTotal > RateCountTotal Then
                RowStart = contTotal
            ElseIf contTotal = RateCountTotal Then
                RowStart = RateCountTotal
            End If



            Dim II As Integer = 8
            InputTextCFB(II, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", "TOTAL", True, sheet, Color.Red, 27)
            II += 1
            InputTextCFB(II, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", "USD " & FormatMoneyN(TotalUSD), True, sheet, Color.Red, 27)
            II += 1
            InputTextCFB(II, RowStart, True, 19.5, 5.64, 10, "Trebuchet MS", "C", "PHP " & FormatMoneyN(SumPHPTotal), True, sheet, Color.Red, 27)

            RowStart += 1


        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        RowEndBorder = RowStart


        Dim colH As Integer = 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  PORT OF ORIGIN  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  BL NO.  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  SHIPPER  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  CONSIGNEE  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  VESSEL  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  ARRIVAL DATE  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  POD  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  CONTAINER NO.  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  CHARGES  " & vbCrLf & "COLLECTED  ", True, sheet, Color.Red, 27)
        colH += 1
        InputTextCFB(colH, RowStartBorder, True, 45, 5.64, 16, "Trebuchet MS", "C", "  OTHER INCOME  ", True, sheet, Color.Red, 27)

        sheet.Columns("A:Z").AutoFit()
        InputTextComplete("A" & RowStartBorder - 1 & ":J" & RowStartBorder - 1, True, 48, 0, 28, "Arial Black", "C", "SUMMARY OF IMPORT " & ReportForIs & "CL CARGO LOADING " & UCase(String.Concat(Format(CDate(dtFROM.Value), "MMMM"), "-", Format(CDate(DtTo.Value), "MMMM"), " Y", Format(CDate(DtTo.Value), "yyyy"))), True, sheet, Color.Red, 27)
        sheet.Range("A" & RowStartBorder - 1 & ":" & "J" & RowEndBorder).Borders.Weight = Excel.XlBorderWeight.xlThin






    End Sub

    Public Sub DisplayContainers(bkno As String, row As Integer, col As Integer, Sheet As Excel.Worksheet, blno As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT ContainerNo, SizeIs FROM TBL_CONTAINER WHERE (STAT <> '2' AND STAT <> '0' ) and bkno = '" & bkno & "'  "
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            InputTextCFB(col, row, True, 19.5, 5.64, 10, "Trebuchet MS", "C", Dbo.reader(0).ToString & " / " & Dbo.reader(1).ToString, True, Sheet, Color.Black, 0)
            row += 1
        Loop

        If GetRyzk("SELECT TOP 1 ERATE FROM TBL_RATES WHERE STAT = '1' AND BLNO = '" & blno & "'", "") = NoRecordFound Then
            ERATEis = 0
        Else
            ERATEis = GetRyzk("SELECT TOP 1 ERATE FROM TBL_RATES WHERE STAT = '1' AND BLNO = '" & blno & "'", "")
        End If
        InputTextCFB(col, row, True, 19.5, 5.64, 10, "Trebuchet MS", "C", "(E.R " & FormatMoneyN(ERATEis) & ")", True, Sheet, Color.Black, 0)

        contTotal = row
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub DisplayRates(blno As String, row As Integer, col As Integer, Sheet As Excel.Worksheet)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        'SQL = "SELECT  CH.CHARGES_CODE, R.Currency, R.DestinationRate,R.PrincipalRate,R.BillingRate FROM TBL_RATES AS R LEFT JOIN TBL_CHARGES_NAME AS CH ON R.CHARGES = CH.ID LEFT JOIN TBL_BOOKING AS B ON R.BLNO = B.BLNO AND B.STAT = '1'   WHERE R.Stat = '1' AND B.BLNO = '" & blno & "'"
        SQL = "SELECT  CH.CHARGES_CODE, CUR.Curr, R.DestinationRate,R.PrincipalRate,R.BillingRate FROM TBL_RATES AS R LEFT JOIN TBL_CHARGES_NAME AS CH ON R.CHARGES = CH.ID LEFT JOIN TBL_BOOKING AS B ON R.BLNO = B.BLNO LEFT JOIN TBL_CURRENCY AS CUR ON R.Currency = CUR.ID AND CUR.STAT = '1' AND B.STAT = '1'   WHERE R.Stat = '1' AND B.BLNO = '" & blno & "'  AND CUR.STAT = '1' AND (CUR.Curr = 'PHP' OR CUR.Curr = 'USD') "
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        ConvertToPHP = 0.00
        SumPHPTotal = 0.00
        Do While Dbo.reader.Read
            Dim rATEiS As Double = 0.00
            If rdDestination.Checked = True Then
                rATEiS = Dbo.reader(2).ToString
            ElseIf rdPrincipal.Checked = True Then
                rATEiS = Dbo.reader(3).ToString
            ElseIf rdBilling.Checked = True Then
                rATEiS = Dbo.reader(4).ToString
            End If

            If Not rATEiS = 0 Then
                If Dbo.reader(1).ToString = "USD" Then
                    TotalUSD += rATEiS
                    ConvertToPHP = (rATEiS * ERATEis)
                End If
                If Dbo.reader(1).ToString = "PHP" Then
                    TotalPHP += rATEiS
                    ConvertToPHP = rATEiS
                End If

                SumPHPTotal += ConvertToPHP


                InputTextCFB(col, row, True, 19.5, 5.64, 10, "Trebuchet MS", "C", Dbo.reader(0).ToString & " = " & Dbo.reader(1).ToString & " " & FormatMoneyN(rATEiS), True, Sheet, Color.Black, 0)
                InputTextCFB(col + 1, row, True, 19.5, 5.64, 10, "Trebuchet MS", "C", IIf(Dbo.reader(1).ToString = "USD", "PHP" & " " & FormatMoneyN(rATEiS * ERATEis), "PHP" & " " & FormatMoneyN(ConvertToPHP)), True, Sheet, Color.Black, 0)

                row += 1
            End If

        Loop
        RateCountTotal = row
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub FrmImportCargoLoadingMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class