Imports Microsoft.Office.Interop
Imports Microsoft
Public Class FrmSpecialChargesMenu
    Private Sub FrmSpecialChargesMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call LoadChargesCategory()
        Call LoadContainers()

        With cmbDiscount
            .Items.Clear()
            For i As Integer = 0 To 100
                .Items.Add(i)
            Next
        End With

        If Not dtContainer.RowCount = 0 Then
            For i As Integer = 0 To dtContainer.RowCount - 1
                dtContainer.Rows(i).Cells(0).Value = True
            Next
        End If


    End Sub

    Public Sub CalcGrandTotal()
        txtGrandTotal.Text = SaveMoney(0)
        For i As Integer = 0 To dtList.RowCount - 1
            txtGrandTotal.Text = FormatMoney(SaveMoney(txtGrandTotal.Text) + SaveMoney(dtList.Rows(i).Cells(12).Value))
        Next
    End Sub
    Public Sub LoadChargesCategory()
        Call LoadCmbChargesFreetime(cmbCategory, "SELECT DISTINCT ID, CHARGENAME, CCODE FROM TBL_FREETIME WHERE STAT = '1' ORDER BY CHARGENAME ASC")
        'Call LoadCmbChargesFreetime(cmbCategory, "SELECT DISTINCT CHARGENAME, CCODE FROM TBL_FREETIME WHERE STAT = '1' ORDER BY CHARGENAME ASC")

    End Sub

    Public Sub LoadContainers()
        If strDemmurageDetention = "DEM" Then

            dtList.Columns(3).HeaderText = "DEMURRAGE START DATE"
            dtList.Columns(4).HeaderText = "DEMURRAGE END DATE"
            dtList.Columns(5).HeaderText = "RATES OF DEMURRAGE"

            cmbContainers.Items.Clear()

            Dim StatIs As String = FrmBookingList.dtList.CurrentRow.Cells(2).Tag
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT Count, SizeIs, ContainerNo, SealNo,ID, LoadingPlace, DatePullout,cOUNTiS, PackagingType, Kgs, Cbm, GateInDate, VGM, CargoType,DateDischarged    FROM TBL_CONTAINER WHERE (STAT  = '1' OR STAT <> '2') AND  BKNO = '" & SelBkNo & "' AND SYSREF = '" & SelSysref & "'  AND STAT = '" & StatIs & "'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With dtContainer
                .Rows.Clear()
                Do While Dbo.reader.Read
                    Dim DateDischarge As String = ""
                    If String.IsNullOrEmpty(Dbo.reader(14).ToString) Then
                        DateDischarge = ""
                    Else
                        DateDischarge = Format(CDate(Dbo.reader(14).ToString), "yyyy-MM-dd")
                    End If
                    .Rows.Add(False, Dbo.reader(2).ToString, Dbo.reader(1).ToString, DateDischarge)
                    '.Rows(.RowCount - 1).Cells(11).Value = Dbo.reader(11).ToString
                    .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(4).ToString
                    If Not String.IsNullOrEmpty(DateDischarge) Then
                        cmbContainers.Items.Add(Dbo.reader(2).ToString & "|" & Dbo.reader(1).ToString & "|" & DateDischarge)
                    End If

                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Exit Sub
        End If

        If strDemmurageDetention = "DET" Then

            dtList.Columns(3).HeaderText = "DETENTION START DATE"
            dtList.Columns(4).HeaderText = "DETENTION END DATE"
            dtList.Columns(5).HeaderText = "RATES OF DETENTION"

            cmbContainers.Items.Clear()

            Dim StatIs As String = FrmBookingList.dtList.CurrentRow.Cells(2).Tag
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT Count, SizeIs, ContainerNo, SealNo,ID, LoadingPlace, DatePullout,cOUNTiS, PackagingType, Kgs, Cbm, GateInDate, VGM, CargoType, DateReleased    FROM TBL_CONTAINER WHERE (STAT  = '1' OR STAT <> '2') AND  BKNO = '" & SelBkNo & "' AND SYSREF = '" & SelSysref & "'  AND STAT = '" & StatIs & "'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With dtContainer
                .Rows.Clear()
                Do While Dbo.reader.Read
                    Dim DateDischarge As String = ""
                    If String.IsNullOrEmpty(Dbo.reader(14).ToString) Then
                        DateDischarge = ""
                    Else
                        DateDischarge = Format(CDate(Dbo.reader(14).ToString), "yyyy-MM-dd")
                    End If
                    .Rows.Add(False, Dbo.reader(2).ToString, Dbo.reader(1).ToString, DateDischarge)
                    '.Rows(.RowCount - 1).Cells(11).Value = Dbo.reader(11).ToString
                    .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(4).ToString
                    If Not String.IsNullOrEmpty(DateDischarge) Then
                        cmbContainers.Items.Add(Dbo.reader(2).ToString & "|" & Dbo.reader(1).ToString & "|" & DateDischarge)
                    End If

                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Exit Sub
        End If




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If cmbCategory.SelectedIndex = -1 Then
            MsgBox("Invalid category!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        'If Not IsNumeric(cmberate.Text) Then
        '    MsgBox("Invalid ERate!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If


        If cmbDiscount.SelectedIndex = -1 Then
            MsgBox("Invalid discount!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim cmb As String = KVal(cmbContainers.Text)
        Dim Cntr() As String
        Cntr = cmb.Split("|")


        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet

        Dim DetailRowStart = 0, DetailRowEnd As Integer = 0

        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet
        'xls.Visible = True

        Dim RStart As Integer = 9
        DetailRowStart = 9
        Dim CStart As Integer = 1

        InputTextComplete("E" & 8 & ":J" & 8, True, 15, 0, 9, "Trebuchet MS", "R", "VESSEL:" & KVal(cmbFeederVessel.Text) & " V-" & cmbFVoyage.Text & "/" & KVal(cmbMV.Text) & " V-" & cmbMVVoyage.Text, True, sheet, Color.Black, 0)

        Dim FreetimeSet As String = ""
        FreetimeSet = GetRyzk("SELECT FREETIME FROM TBL_FREETIME WHERE CHARGENAME = '" & KVal(cmbCategory.Text) & "' AND SIZE = '" & KVal(Cntr(1)) & "' AND STAT = '1'", "")




        InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 10, "Cambria", "C", "DATE: " & Format(Now, "MMMM dd, yyyy"), True, sheet, Color.Black, 0)
        InputTextComplete("B" & RStart & ":G" & RStart, True, 25.5, 0, 18, "Cambria", "C", KVal(cmbConsignee.Text), True, sheet, Color.Black, 0)
        If strDemmurageDetention = "DEM" Then
            InputTextComplete("H" & RStart & ":J" & RStart, True, 25.5, 0, 18, "Cambria", "C", "DEMURRAGE", True, sheet, Color.Black, 0)
        ElseIf strDemmurageDetention = "DET" Then
            InputTextComplete("H" & RStart & ":J" & RStart, True, 25.5, 0, 18, "Cambria", "C", "DETENTION", True, sheet, Color.Black, 0)
        End If


        RStart += 1

        Dim CntrCount As String = ""
        'Dim sqlis As String = "SELECT CONCAT(', ',count(ContainerNo),'X',c.SizeIs)   FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.Sysref = B.Sysref AND C.BKNO = B.BKNO  AND C.STAT = '1' AND B.STAT = '1' WHERE C.STAT = '1' AND B.BLNO = '" & KVal(txtBLNO.Text) & "' GROUP BY C.SizeIs  for XML PATH('') "
        'CntrCount = GetRyzk("SELECT CONCAT(', ',count(ContainerNo),'X',c.SizeIs)   FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.Sysref = B.Sysref AND C.BKNO = B.BKNO  AND C.STAT = '1' AND B.STAT = '1' WHERE C.STAT = '1' AND B.BLNO = '" & KVal(txtBLNO.Text) & "' GROUP BY C.SizeIs  for XML PATH('') ", "")

        CntrCount = "1"


        'InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 18, "Cambria", "C", Microsoft.VisualBasic.Mid(CntrCount, 2), True, sheet, Color.Black, 6)
        If strDemmurageDetention = "DEM" Then
            InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 18, "Cambria", "C", CntrCount & "X" & KVal(Cntr(1)), True, sheet, Color.Black, 6)
            InputTextComplete("B" & RStart & ":B" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   FREETIME DATE   ", True, sheet, Color.Black, 0)
            InputTextComplete("C" & RStart & ":C" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   DEMURRAGE DATE   ", True, sheet, Color.Black, 0)
            InputTextComplete("D" & RStart & ":D" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   RATES OF DEMURRAGE   ", True, sheet, Color.Black, 0)
            InputTextComplete("E" & RStart & ":E" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL PER DAY   ", True, sheet, Color.Black, 0)
            InputTextComplete("F" & RStart & ":F" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   NOS.OF DAY   ", True, sheet, Color.Black, 0)
            InputTextComplete("G" & RStart & ":G" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL PER " & FreetimeSet & " DAYS   ", True, sheet, Color.Black, 0)
            InputTextComplete("H" & RStart & ":H" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   NOS. OF CONTAINER   ", True, sheet, Color.Black, 0)
            InputTextComplete("I" & RStart & ":I" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "                         ", True, sheet, Color.Black, 0)
            InputTextComplete("J" & RStart & ":J" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL   ", True, sheet, Color.Black, 0)
        ElseIf strDemmurageDetention = "DET" Then
            InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 18, "Cambria", "C", CntrCount & "X" & KVal(Cntr(1)), True, sheet, Color.Black, 6)
            InputTextComplete("B" & RStart & ":B" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   FREETIME DATE   ", True, sheet, Color.Black, 0)
            InputTextComplete("C" & RStart & ":C" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   DETENTION DATE   ", True, sheet, Color.Black, 0)
            InputTextComplete("D" & RStart & ":D" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   RATES OF DETENTION   ", True, sheet, Color.Black, 0)
            InputTextComplete("E" & RStart & ":E" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL PER DAY   ", True, sheet, Color.Black, 0)
            InputTextComplete("F" & RStart & ":F" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   NOS.OF DAY   ", True, sheet, Color.Black, 0)
            InputTextComplete("G" & RStart & ":G" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL PER " & FreetimeSet & " DAYS   ", True, sheet, Color.Black, 0)
            InputTextComplete("H" & RStart & ":H" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   NOS. OF CONTAINER   ", True, sheet, Color.Black, 0)
            InputTextComplete("I" & RStart & ":I" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "                         ", True, sheet, Color.Black, 0)
            InputTextComplete("J" & RStart & ":J" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL   ", True, sheet, Color.Black, 0)
        End If


        RStart += 1

        InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "BL#" & KVal(txtBLNO.Text), True, sheet, Color.Black, 6)





        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, RatesOfCharges, ERate, TotalPerDay, NosOfDay, TotalPerNosOfDay, NosOfContainer, PHP, TOTAL, Series, AddedBy, DateAdded, Stat, Discount, DatePaid, PaidUserBy FROM TBL_CALC_OVER_FREETIME  WHERE STAT = '1' AND CONTAINER_NO = '" & KVal(Cntr(0)) & "' AND SIZEIS = '" & KVal(Cntr(1)) & "' AND CHARGES_TYPE = '" & KVal(cmbCategory.Text) & "' AND BLNO = '" & KVal(txtBLNO.Text) & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            Dim Freetime As String = ""
            If Dbo.reader(4).ToString = "0" Then
                Freetime = ""
            Else
                Freetime = "(" & Dbo.reader(4).ToString & " days freetime)"
            End If




            Dim DemDate As String = ""
            Dim DemDateStart As String = ""
            Dim DemDateEnd As String = ""

            DemDateStart = Dbo.reader(5).ToString
            DemDateEnd = Dbo.reader(6).ToString


            If CDate(Dbo.reader(5).ToString).Month = CDate(Dbo.reader(6).ToString).Month Then
                If CDate(Dbo.reader(5).ToString).Year = CDate(Dbo.reader(6).ToString).Year Then
                    DemDateStart = Dbo.reader(5).ToString
                    DemDateStart = Format(CDate(DemDateStart), "MM/dd")
                    DemDateEnd = Dbo.reader(6).ToString
                    DemDateEnd = Format(CDate(DemDateEnd), "dd/yyyy")

                    DemDate = DemDateStart & "-" & DemDateEnd

                End If
            ElseIf CDate(Dbo.reader(5).ToString).Month <> CDate(Dbo.reader(6).ToString).Month Then
                If CDate(Dbo.reader(5).ToString).Year = CDate(Dbo.reader(6).ToString).Year Then
                    DemDateStart = Dbo.reader(5).ToString
                    DemDateStart = Format(CDate(DemDateStart), "MM/dd")
                    DemDateEnd = Dbo.reader(6).ToString
                    DemDateEnd = Format(CDate(DemDateEnd), "MM/dd/yyyy")

                    DemDate = DemDateStart & "-" & DemDateEnd

                End If
            End If


            Dim ErRates As String = ""
            ErRates = Dbo.reader(7).ToString & " X " & Dbo.reader(8).ToString & "ER ="


            InputTextComplete("B" & RStart & ":B" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", Freetime, False, sheet, Color.Black, 0)
            InputTextComplete("C" & RStart & ":C" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", DemDate, False, sheet, Color.Black, 0)
            InputTextComplete("D" & RStart & ":D" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", ErRates, False, sheet, Color.Black, 0)
            InputTextComplete("E" & RStart & ":E" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", Dbo.reader(9).ToString, False, sheet, Color.Black, 0)
            InputTextComplete("F" & RStart & ":F" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", Dbo.reader(10).ToString & " DAYS", False, sheet, Color.Black, 0)
            InputTextComplete("G" & RStart & ":G" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", Dbo.reader(11).ToString, False, sheet, Color.Black, 0)
            InputTextComplete("H" & RStart & ":H" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", Dbo.reader(12).ToString, False, sheet, Color.Black, 0)
            InputTextComplete("I" & RStart & ":I" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", Dbo.reader(13).ToString, False, sheet, Color.Black, 0)
            InputTextComplete("J" & RStart & ":J" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", FormatMoney(Dbo.reader(14).ToString), False, sheet, Color.Black, 0)


            RStart += 1
        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        If cmbDiscount.Text = 0 Then
            Dim SealNo As String = ""
            SealNo = GetRyzk("SELECT TOP 1 SEALNO FROM TBL_CONTAINER WHERE STAT = '1' AND ContainerNo = '" & KVal(Cntr(0)) & "'", "")
            InputTextComplete("A" & RStart & ":B" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "CONTAINER NO.: " & KVal(Cntr(0)) & "/ " & SealNo, True, sheet, Color.Black, 0)
            InputTextComplete("H" & RStart & ":I" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "GRAND TOTAL", True, sheet, Color.Black, 0)
            InputTextComplete("J" & RStart & ":J" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "PHP " & FormatMoney(txtGrandTotal.Text), True, sheet, Color.Black, 0)
        Else
            Dim SealNo As String = ""
            SealNo = GetRyzk("SELECT TOP 1 SEALNO FROM TBL_CONTAINER WHERE STAT = '1' AND ContainerNo = '" & KVal(Cntr(0)) & "'", "")
            InputTextComplete("A" & RStart & ":B" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "CONTAINER NO.: " & KVal(Cntr(0)) & "/ " & SealNo, True, sheet, Color.Black, 0)
            InputTextComplete("H" & RStart & ":I" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "GRAND TOTAL", True, sheet, Color.Black, 0)
            InputTextComplete("J" & RStart & ":J" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "PHP " & FormatMoney(txtGrandTotal.Text), True, sheet, Color.Black, 0)
            RStart += 1
            InputTextComplete("H" & RStart & ":I" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "PAID (" & cmbDiscount.Text & "% DISCOUNT)", True, sheet, Color.Black, 0)
            InputTextComplete("J" & RStart & ":J" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "PHP " & FormatMoney(txtGTotalDiscount.Text), True, sheet, Color.Black, 0)
        End If
        DetailRowEnd = RStart
        sheet.Columns("A:J").AutoFit()
        sheet.Range("A" & DetailRowStart & ":" & "j" & DetailRowEnd).Borders.Weight = Excel.XlBorderWeight.xlThin


        RStart += 3

        InputTextComplete("B" & RStart & ":B" & RStart, True, 15, 0, 10, "Trebuchet MS", "R", "PREPARED BY: ", True, sheet, Color.Black, 0)
        InputTextComplete("C" & RStart & ":C" & RStart, True, 15, 0, 10, "Trebuchet MS", "L", FNAME & " " & LNAME, True, sheet, Color.Black, 0)


        InputTextComplete("G" & RStart & ":G" & RStart, True, 15, 0, 10, "Trebuchet MS", "R", "APPROVED BY: ", True, sheet, Color.Black, 0)
        InputTextComplete("H" & RStart & ":H" & RStart, True, 15, 0, 10, "Trebuchet MS", "L", "ANITA CHAVEZ", True, sheet, Color.Black, 0)

        RStart += 1

        InputTextComplete("C" & RStart & ":C" & RStart, True, 15, 0, 10, "Trebuchet MS", "L", UserDesignationLabel, True, sheet, Color.Black, 0)

        InputTextComplete("H" & RStart & ":H" & RStart, True, 15, 0, 10, "Trebuchet MS", "L", "ACCOUNTING MANAGER", True, sheet, Color.Black, 0)


        RStart += 1

        InputTextComplete("C" & RStart & ":C" & RStart, True, 15, 0, 10, "Trebuchet MS", "L", "KYOWA SHIPPING LINE CO. LTD", True, sheet, Color.Black, 0)
        InputTextComplete("H" & RStart & ":H" & RStart, True, 15, 0, 10, "Trebuchet MS", "L", "SKYBEST LOGISTICS CORP.", True, sheet, Color.Black, 0)


        InputTextComplete("C" & 2 & ":G" & 3, True, 25.5, 0, 36, "Cooper Black", "C", "KYOWA SHIPPING CO., LTD", False, sheet, Color.Black, 0)
        InputTextComplete("C" & 4 & ":G" & 4, True, 25.5, 0, 11, "Cooper Black", "C", "10th flr.Sky 1 Tower, #68 Dasmariñas St.Binondo,Metro Manila", False, sheet, Color.Black, 0)
        InputTextComplete("C" & 5 & ":G" & 5, True, 25.5, 0, 11, "Cooper Black", "C", "Tel.No. 5310-8568 /Fax Nos. 8516-1302", False, sheet, Color.Black, 0)
        InputTextComplete("C" & 6 & ":G" & 6, True, 25.5, 0, 12, "Sanskrit Text", "C", "General Agent - Skybest Logistics Corp.", False, sheet, Color.Red, 0)




        xls.Visible = True
        Exit Sub

        'With dtContainer
        '    If .RowCount = 0 Then
        '        MsgBox("This bl has no container!", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If

        '    Dim ii As Integer = 0

        '    For i As Integer = 0 To .RowCount - 1
        '        If .Rows(i).Cells(0).Value = True Then
        '            ii += 1
        '        End If
        '    Next

        '    If Not ii > 0 Then
        '        MsgBox("Please select container first!", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If
        'End With



        'If MsgBox("Generate calculated " & KVal(cmbCategory.Text) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Dim xls As New Excel.Application
        '    Dim book As Excel.Workbook
        '    Dim sheet As Excel.Worksheet



        '    xls.Workbooks.Add()
        '    book = xls.ActiveWorkbook
        '    sheet = book.ActiveSheet
        '    xls.Visible = True

        '    Dim RStart As Integer = 9
        '    Dim CStart As Integer = 1





        '    InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 10, "Cambria", "C", "DATE: " & Format(Now, "MMMM dd, yyyy"), True, sheet, Color.Black, 0)
        '    InputTextComplete("B" & RStart & ":G" & RStart, True, 25.5, 0, 18, "Cambria", "C", KVal(cmbConsignee.Text), True, sheet, Color.Black, 0)

        '    RStart += 1

        '    Dim CntrCount As String = ""
        '    CntrCount = GetRyzk("SELECT CONCAT(', ',count(ContainerNo),'X',c.SizeIs)   FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON C.Sysref = B.Sysref AND C.BKNO = B.BKNO  AND C.STAT = '1' AND B.STAT = '1' WHERE C.STAT = '1' AND B.BLNO = '" & KVal(txtBLNO.Text) & "' GROUP BY C.SizeIs  for XML PATH('') ", "")

        '    InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 18, "Cambria", "C", Microsoft.VisualBasic.Mid(CntrCount, 2), True, sheet, Color.Black, 6)
        '    InputTextComplete("B" & RStart & ":B" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   FREETIME DATE   ", True, sheet, Color.Black, 0)
        '    InputTextComplete("C" & RStart & ":C" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   DEMURRAGE DATE   ", True, sheet, Color.Black, 0)
        '    InputTextComplete("D" & RStart & ":D" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   RATES OF DEMURRAGE   ", True, sheet, Color.Black, 0)
        '    InputTextComplete("E" & RStart & ":E" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL PER DAY   ", True, sheet, Color.Black, 0)
        '    InputTextComplete("F" & RStart & ":F" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   NOS.OF DAY   ", True, sheet, Color.Black, 0)
        '    InputTextComplete("G" & RStart & ":G" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL PER 7 DAYS   ", True, sheet, Color.Black, 0)
        '    InputTextComplete("H" & RStart & ":H" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   NOS. OF CONTAINER   ", True, sheet, Color.Black, 0)
        '    InputTextComplete("I" & RStart & ":I" & RStart, True, 25.5, 0, 10, "Arial Black", "C", "   TOTAL   ", True, sheet, Color.Black, 0)

        '    RStart += 1

        '    InputTextComplete("A" & RStart & ":A" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "BL#" & KVal(txtBLNO.Text), True, sheet, Color.Black, 6)

        '    Dim Dbo As New SQLClass
        '    Dbo.SqlCon.Open()
        '    SQL = ""



        '    InputTextComplete("A" & RStart & ":B" & RStart, True, 25.5, 0, 10, "Trebuchet MS", "C", "BL#" & KVal(txtBLNO.Text), True, sheet, Color.Black, 6)







        '    sheet.Columns("A:I").AutoFit()


        'End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim DateToday As DateTime = dtTo.Value
        Dim DateCont As DateTime = Now
        Dim CalDate As Integer = 0
        Dim GetFreetime As Integer = 0
        Dim ValToCompute As Integer = 0
        Dim iSeqDays As Integer = 0

        For i1 As Integer = 0 To dtContainer.RowCount - 1
            If dtContainer.Rows(i1).Cells(0).Value = True Then
                If String.IsNullOrEmpty(dtContainer.Rows(i1).Cells(3).Value) Then
                    MsgBox("Invalid Date for this container " & dtContainer.Rows(i1).Cells(1).Value, MsgBoxStyle.Critical)
                    Exit Sub
                End If

                DateCont = dtContainer.Rows(i1).Cells(3).Value

                CalDate = DateDiff(DateInterval.Day, DateCont, dtTo.Value)

                'CalDate -= 7
                MsgBox("Full no Freetime " & CalDate)

                GetFreetime = GetRyzk("SELECT FREETIME FROM TBL_FREETIME WHERE CHARGENAME = '" & KVal(cmbCategory.Text) & "' AND SIZE = '" & dtContainer.Rows(i1).Cells(2).Value & "' AND STAT = '1'", "")

                MsgBox("Freetime " & GetFreetime)


                ValToCompute = CalDate - GetFreetime

                MsgBox("Value to compute " & ValToCompute)

                Dim seq As Integer = 0

                seq = GetRyzk("SELECT max(sequenceis) FROM TBL_OVER_FREETIME WHERE CHARGENAME =  '" & KVal(cmbCategory.Text) & "' AND SIZE = '" & dtContainer.Rows(i1).Cells(2).Value & "' AND STAT = '1'", "")

                MsgBox("sequence " & seq)

                For iSeq As Integer = 1 To seq
                    MsgBox(iSeq)
                    iSeqDays = GetRyzk("SELECT qty FROM TBL_OVER_FREETIME WHERE CHARGENAME =  '" & KVal(cmbCategory.Text) & "' AND SIZE = '" & dtContainer.Rows(i1).Cells(2).Value & "' AND STAT = '1' AND SEQUENCEIS = '" & iSeq & "'", "")

                    MsgBox(iSeqDays)




                Next



            End If
        Next

        'Dim FreeTime As String = ""
        'Dim RateIs As Double = 0.00
        'If MsgBox("Are you sure you want to calculate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    For i As Integer = 0 To dtContainer.RowCount - 1
        '        If dtContainer.Rows(i).Cells(0).Value = True Then
        '            FreeTime = GetRyzk("SELECT FREETIME FROM TBL_FREETIME WHERE CHARGENAME = '" & KVal(cmbCategory.Text) & "' AND STAT = '1' AND SIZE = '" & dtContainer.Rows(i).Cells(2).Value & "'", "")
        '            RateIs = GetRyzk("", "")
        '            'Call SaveCalculatedFreetime(cmbCategory.Text, SelRefno, txtBLNO.Text, dtContainer.Rows(i).Cells(1).Value, FreeTime, dtContainer.Rows(i).Cells(2).Value, dtTo.Value,)
        '        End If

        '    Next
        'End If
    End Sub

    Public Sub SaveCalculatedFreeTime(CATEGORYIS, BLNO, CONTAINER_NO, SIZEIS, RATE, DATE_RUN, DateAdded, AddedBy, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_OVER_FREETIME_M(CATEGORYIS, BLNO, CONTAINER_NO, SIZEIS, RATE, DATE_RUN, DateAdded, AddedBy, Stat)"
        SQL = SQL + "VALUES('" & KVal(CATEGORYIS) & "',  '" & KVal(BLNO) & "',  '" & KVal(CONTAINER_NO) & "',  '" & KVal(SIZEIS) & "',  '" & KVal(RATE) & "',  '" & KVal(DATE_RUN) & "',  '" & KVal(DateAdded) & "',  '" & KVal(AddedBy) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub SaveCalculatedFreetime(CHARGES_TYPE, REFNO, BLNO, CONTAINER_NO, FREETIME, ChargeDateStart, ChargeDateEnd, Rate, ERate, RatesOfCharge, NosOfContainer, Series, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TABLENAME(CHARGES_TYPE, REFNO, BLNO, CONTAINER_NO, FREETIME, ChargeDateStart, ChargeDateEnd, Rate, ERate, RatesOfCharge, NosOfContainer, Series, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(CHARGES_TYPE) & "',  '" & KVal(REFNO) & "',  '" & KVal(BLNO) & "',  '" & KVal(CONTAINER_NO) & "',  '" & KVal(FREETIME) & "',  '" & KVal(ChargeDateStart) & "',  '" & KVal(ChargeDateEnd) & "',  '" & KVal(Rate) & "',  '" & KVal(ERate) & "',  '" & KVal(RatesOfCharge) & "',  '" & KVal(NosOfContainer) & "',  '" & KVal(Series) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged
        'DETENTION_INPUTING_CHARGES
    End Sub

    Private Sub cmbCategory_TextChanged(sender As Object, e As EventArgs) Handles cmbCategory.TextChanged
        Call LoadList()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If String.IsNullOrEmpty(cmbCategory.Text) Then
            MsgBox("Invalid category!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'Exit Sub
        Dim DateCont As DateTime = Now
        Dim CalDate As Integer = 0
        Dim cmb As String = KVal(cmbContainers.Text)
        Dim Cntr() As String
        Dim Freetime As Integer = 0
        Cntr = cmb.Split("|")
        With dtList
            If dtList.RowCount = 0 Then
                Freetime = GetRyzk("SELECT FREETIME FROM TBL_FREETIME WHERE CHARGENAME = '" & KVal(cmbCategory.Text) & "' AND SIZE = '" & KVal(Cntr(1)) & "' AND STAT = '1'", "")
                DateCont = Cntr(2)

                CalDate = DateDiff(DateInterval.Day, DateCont, Now)
                .Rows.Add(Cntr(0), Cntr(1), Freetime, Cntr(2), Format(Now, "yyyy-MM-dd"), "", "", "", CalDate - Freetime, "", "", "", "", "SAVE", "DEL")
                Exit Sub
            End If
            .Rows.Add(Cntr(0), Cntr(1), 0, Format(Now, "yyyy-MM-dd"), Format(Now, "yyyy-MM-dd"), "", "", "", CalDate - Freetime, "", "", "", "", "SAVE", "DEL")
        End With
    End Sub

    Private Sub FrmSpecialChargesMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    Private Sub dtList_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellLeave

    End Sub

    Private Sub dtList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellEndEdit
        dtList.CurrentRow.Cells(8).Value = Val(DateDiff(DateInterval.Day, dtList.CurrentRow.Cells(3).Value, (dtList.CurrentRow.Cells(4).Value)) + 1)
        If e.ColumnIndex = 6 Or e.ColumnIndex = 5 Or e.ColumnIndex = 4 Then
            CalculatePerDay()
        End If
        Call CalcGrandTotal()
    End Sub

    Public Sub CalculatePerDay()
        Dim str As String = ""
        If String.IsNullOrEmpty(dtList.CurrentRow.Cells(5).Value) Then
            str = "USD 0.00"
        Else
            str = dtList.CurrentRow.Cells(5).Value
        End If


        Dim StrVal() As String
        StrVal = str.Split(" ")

        Dim ColRate = 0.00, ColErate As Double = 0.00
        If Not IsNumeric(StrVal(1)) Then
            ColRate = 0.00
        Else
            ColRate = StrVal(1)
        End If
        If Not IsNumeric(dtList.CurrentRow.Cells(6).Value) Then
            ColErate = 0.00
        Else
            ColErate = dtList.CurrentRow.Cells(6).Value
        End If
        dtList.CurrentRow.Cells(7).Value = "PHP " & FormatMoney(Val(ColRate) * Val(ColErate))
        dtList.CurrentRow.Cells(9).Value = "PHP " & FormatMoney((Val(ColRate) * Val(ColErate)) * dtList.CurrentRow.Cells(8).Value)
        dtList.CurrentRow.Cells(10).Value = "1"
        dtList.CurrentRow.Cells(11).Value = "PHP"
        dtList.CurrentRow.Cells(12).Value = FormatMoney((Val(ColRate) * Val(ColErate)) * dtList.CurrentRow.Cells(8).Value)

    End Sub
    Private Sub dtList_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellEnter
        With dtRates
            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            SQL = "SELECT SequenceIs,  Amount, Currency FROM TBL_OVER_FREETIME WHERE CHARGENAME = '" & KVal(cmbCategory.Text) & "' AND SIZE = '" & dtList.CurrentRow.Cells(1).Value & "' AND STAT = '1'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, FormatMoney(Dbo.reader(1).ToString), Dbo.reader(2).ToString)
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End With
    End Sub

    Private Sub dtRates_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRates.CellContentClick

    End Sub

    Private Sub dtErate_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dtRates_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtRates.CellDoubleClick
        dtList.CurrentRow.Cells(5).Value = dtRates.CurrentRow.Cells(2).Value & " " & dtRates.CurrentRow.Cells(1).Value
    End Sub
    Public Sub SaveThisRecord(CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, RatesOfCharges, ERate, TotalPerDay, NosOfDay, TotalPerNosOfDay, NosOfContainer, PHP, TOTAL, Series, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CALC_OVER_FREETIME(CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, RatesOfCharges, ERate, TotalPerDay, NosOfDay, TotalPerNosOfDay, NosOfContainer, PHP, TOTAL, Series, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(CHARGES_TYPE) & "',  '" & KVal(BLNO) & "',  '" & KVal(CONTAINER_NO) & "',  '" & KVal(SizeIs) & "',  '" & KVal(FREETIME) & "',  '" & KVal(ChargeDateStart) & "',  '" & KVal(ChargeDateEnd) & "',  '" & KVal(RatesOfCharges) & "',  '" & KVal(ERate) & "',  '" & KVal(TotalPerDay) & "',  '" & KVal(NosOfDay) & "',  '" & KVal(TotalPerNosOfDay) & "',  '" & KVal(NosOfContainer) & "',  '" & KVal(PHP) & "',  '" & KVal(TOTAL) & "',  '" & KVal(Series) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub dtList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellClick
        'Dim Rates As String
        'Dim xRates() As String
        If e.ColumnIndex = 13 Then
            If MsgBox("Save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                With dtList.CurrentRow
                    'Rates = .Cells(5).Value
                    'xRates = Rates.Split(" ")
                    'Call SaveRecord(cmbCategory.Text, txtBLNO.Text, .Cells(0).Value, .Cells(1).Value, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, xRates(0), SaveMoney(xRates(1)), SaveMoney(.Cells(6).Value), SaveMoney(.Cells(10).Value), "", USER_ID, Now, "1")
                    Call SaveThisRecord(cmbCategory.Text, txtBLNO.Text, .Cells(0).Value, .Cells(1).Value, SaveMoney(.Cells(2).Value), .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, SaveMoney(.Cells(6).Value), .Cells(7).Value, SaveMoney(.Cells(8).Value), .Cells(9).Value, SaveMoney(.Cells(10).Value), .Cells(11).Value, SaveMoney(.Cells(12).Value), "", USER_ID, Now, "1")
                End With
            End If
        End If
        If e.ColumnIndex = 14 Then
            If MsgBox("Delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtList.Rows.Remove(dtList.CurrentRow)
                Call CalcGrandTotal()
            End If
        End If
    End Sub

    Public Sub SaveRecord(CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, Currency, Rate, ERate, NosOfContainer, Series, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CALCULATED_OVER_FREETIME(CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, Currency, Rate, ERate, NosOfContainer, Series, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(CHARGES_TYPE) & "',  '" & KVal(BLNO) & "',  '" & KVal(CONTAINER_NO) & "',  '" & KVal(SizeIs) & "',  '" & KVal(FREETIME) & "',  '" & KVal(ChargeDateStart) & "',  '" & KVal(ChargeDateEnd) & "',  '" & KVal(Currency) & "',  '" & KVal(Rate) & "',  '" & KVal(ERate) & "',  '" & KVal(NosOfContainer) & "',  '" & KVal(Series) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub cmbContainers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbContainers.SelectedIndexChanged

    End Sub

    Private Sub cmbContainers_TextChanged(sender As Object, e As EventArgs) Handles cmbContainers.TextChanged
        Call LoadList()

    End Sub

    Public Sub LoadList()




        If KVal(cmbCategory.Text) = "DEMURRAGE CHARGE" Then
            strDemmurageDetention = "DEM"
        ElseIf KVal(cmbCategory.Text) = "DETENTION CHARGE" Then
            strDemmurageDetention = "DET"
        End If

        If strDemmurageDetention = "DEM" Then
            dtContainer.Columns(3).HeaderText = "DateDischarge"

            dtList.Columns(3).HeaderText = "DEMURRAGE START DATE"
            dtList.Columns(4).HeaderText = "DEMURRAGE END DATE"
            dtList.Columns(5).HeaderText = "RATES OF DEMURRAGE"


        Else
            dtContainer.Columns(3).HeaderText = "DateRelease"


            dtList.Columns(3).HeaderText = "DETENTION START DATE"
            dtList.Columns(4).HeaderText = "DETENTION END DATE"
            dtList.Columns(5).HeaderText = "RATES OF DETENTION"

        End If


        If strDemmurageDetention = "DEM" Then

            If String.IsNullOrEmpty(cmbContainers.Text) Then

                SQL = "SELECT CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, RatesOfCharges, ERate, TotalPerDay, NosOfDay, TotalPerNosOfDay, NosOfContainer, PHP, TOTAL, Series,AddedBy, DateAdded, Stat, id FROM  TBL_CALC_OVER_FREETIME WHERE STAT = '1' AND CONTAINER_NO = '' AND SIZEIS = '' AND CHARGES_TYPE = '' AND BLNO = ''"
            Else
                Dim cmb As String = KVal(cmbContainers.Text)
                Dim Cntr() As String
                Cntr = cmb.Split("|")
                SQL = "SELECT CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, RatesOfCharges, ERate, TotalPerDay, NosOfDay, TotalPerNosOfDay, NosOfContainer, PHP, TOTAL, Series,AddedBy, DateAdded, Stat, id FROM  TBL_CALC_OVER_FREETIME WHERE STAT = '1' AND CONTAINER_NO = '" & KVal(Cntr(0)) & "' AND SIZEIS = '" & KVal(Cntr(1)) & "' AND CHARGES_TYPE = '" & KVal(cmbCategory.Text) & "' AND BLNO = '" & KVal(txtBLNO.Text) & "'"
            End If

            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.ExecuteNonQuery()
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With dtList
                .Rows.Clear()
                Do While Dbo.reader.Read
                    .Rows.Add(Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, Format(CDate(Dbo.reader(5).ToString), "yyyy-MM-dd"), Format(CDate(Dbo.reader(6).ToString), "yyyy-MM-dd"), Dbo.reader(7).ToString, FormatMoney(Dbo.reader(8).ToString), Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString, Dbo.reader(12).ToString, Dbo.reader(13).ToString, FormatMoney(Dbo.reader(14).ToString), "SAVE", "DEL", Dbo.reader(15).ToString)
                    .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(19).ToString
                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Call CalcGrandTotal()
            Exit Sub
        End If

        If strDemmurageDetention = "DET" Then

            If String.IsNullOrEmpty(cmbContainers.Text) Then

                SQL = "SELECT CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, RatesOfCharges, ERate, TotalPerDay, NosOfDay, TotalPerNosOfDay, NosOfContainer, PHP, TOTAL, Series,AddedBy, DateAdded, Stat, id FROM  TBL_CALC_OVER_FREETIME WHERE STAT = '1' AND CONTAINER_NO = '' AND SIZEIS = '' AND CHARGES_TYPE = '' AND BLNO = ''"
            Else
                Dim cmb As String = KVal(cmbContainers.Text)
                Dim Cntr() As String
                Cntr = cmb.Split("|")
                SQL = "SELECT CHARGES_TYPE, BLNO, CONTAINER_NO, SizeIs, FREETIME, ChargeDateStart, ChargeDateEnd, RatesOfCharges, ERate, TotalPerDay, NosOfDay, TotalPerNosOfDay, NosOfContainer, PHP, TOTAL, Series,AddedBy, DateAdded, Stat, id FROM  TBL_CALC_OVER_FREETIME WHERE STAT = '1' AND CONTAINER_NO = '" & KVal(Cntr(0)) & "' AND SIZEIS = '" & KVal(Cntr(1)) & "' AND CHARGES_TYPE = '" & KVal(cmbCategory.Text) & "' AND BLNO = '" & KVal(txtBLNO.Text) & "'"
            End If

            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.ExecuteNonQuery()
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With dtList
                .Rows.Clear()
                Do While Dbo.reader.Read
                    .Rows.Add(Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, Format(CDate(Dbo.reader(5).ToString), "yyyy-MM-dd"), Format(CDate(Dbo.reader(6).ToString), "yyyy-MM-dd"), Dbo.reader(7).ToString, FormatMoney(Dbo.reader(8).ToString), Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString, Dbo.reader(12).ToString, Dbo.reader(13).ToString, FormatMoney(Dbo.reader(14).ToString), "SAVE", "DEL", Dbo.reader(15).ToString)
                    .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(19).ToString
                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Call CalcGrandTotal()
        End If

    End Sub

    Private Sub txtGrandTotal_TextChanged(sender As Object, e As EventArgs) Handles txtGrandTotal.TextChanged

    End Sub

    Private Sub cmbDiscount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount.SelectedIndexChanged
        Dim gtotal As Double = SaveMoney(txtGrandTotal.Text)
        Dim gDiscount As Double = SaveMoney(cmbDiscount.Text)


        txtGTotalDiscount.Text =FormatMoney( gtotal - (Val(gtotal) / 100) * Val(gDiscount))
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        Dim iCounter As Integer = 0
        Call LoadList()
        If MsgBox("Are you sure you want to mark as paid this records?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim CurSeries As Integer = 0
            CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = 'I' AND PARAM2 = 'SPECIAL_CHARGES_SERIES' AND PARAM3 = 'I'", "L")

            For i As Integer = 0 To dtList.RowCount - 1
                If String.IsNullOrEmpty(dtList.Rows(i).Cells(15).Value) Then
                    Call SetJob("UPDATE TBL_CALC_OVER_FREETIME SET Series = '" & CurSeries & "',  GTotal = '" & SaveMoney(txtGrandTotal.Text) & "', Discount = '" & KVal(cmbDiscount.Text) & "', GTotalLessDiscount = '" & SaveMoney(txtGTotalDiscount.Text) & "', DatePaid = '" & Now & "', PaidUserBy = '" & USER_ID & "' WHERE ID = '" & dtList.Rows(i).Cells(0).Tag & "'")
                    iCounter += 1
                End If
            Next

            If iCounter > 0 Then
                Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = 'I' AND PARAM2 = 'SPECIAL_CHARGES_SERIES' AND PARAM3 = 'I'")
            End If
            Call LoadList()
        End If
    End Sub


End Class