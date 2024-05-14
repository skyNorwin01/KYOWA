Imports Microsoft.Office.Interop
Public Class FrmContainerInventoryList
    Public Sub FrmContainerInventoryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbFilter.Items
            .Clear()
            .Add("BOOKING NO")
            .Add("CONTAINRE YARD")
        End With
        'Call LoadDepot(, "SELECT ID, NAME, ADDRESSIS, OperatingHrsStart, OperatingHrsEnd, Telno FROM TBL_DEPOT WHERE STAT = '1'")

        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT ID, NAME, ADDRESSIS, OperatingHrsStart, OperatingHrsEnd, Telno FROM TBL_DEPOT WHERE STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            Dim ColDepot As DataGridViewComboBoxColumn
            ColDepot = dtList.Columns.Item(2)
            ColDepot.Items.Clear()
            Do While Dbo.reader.Read
                ColDepot.Items.Add(Dbo.reader(1).ToString)
            Loop
        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
        Call LoadList(txtValue.Text)
    End Sub

    Public Sub LoadList(str As String)
        Dim OneWay As String = ""
        If FrmBookingList.OneWayFreeUse = "Y" Then
            OneWay = "ONE WAY"
        Else
            OneWay = "0"
        End If

        Dim Dbo As New SQLClass
        If cmbFilter.Text = "BOOKING NO" Then
            Dbo.SQL = "SELECT BookingNo, isnull(CY,''), NosOfSeal, REFNO FROM TBL_CONTAINER_INVENTORY WHERE STAT = '1' AND BOOKINGNO LIKE '%" & KVal(str) & "%' AND TYPEOFSERVICE = '" & LandingForm.ServiceIs & "' AND ONEWAY = '" & OneWay & "'    GROUP BY BookingNo, CY, NosOfSeal, REFNO"
        ElseIf cmbFilter.Text = "CONTAINRE YARD" Then
            Dbo.SQL = "SELECT BookingNo, isnull(CY,''), NosOfSeal, REFNO FROM TBL_CONTAINER_INVENTORY WHERE STAT = '1'  AND isnull(CY,'') LIKE '%" & KVal(str) & "%'  AND TYPEOFSERVICE = '" & LandingForm.ServiceIs & "' AND ONEWAY = '" & OneWay & "'    GROUP BY BookingNo, CY, NosOfSeal, REFNO"
        Else
            Dbo.SQL = "SELECT BookingNo, isnull(CY,''), NosOfSeal, REFNO FROM TBL_CONTAINER_INVENTORY WHERE STAT = '1'  AND BookingNo LIKE '%" & KVal(str) & "%'  AND TYPEOFSERVICE = '" & LandingForm.ServiceIs & "' AND ONEWAY = '" & OneWay & "'    GROUP BY BookingNo, CY, NosOfSeal, REFNO"
        End If

        With dtList
            .Rows.Clear()
            Dim cntr As Integer = 1



            Dbo.SqlCon.Open()

            Dbo.SQLCmd = New SqlClient.SqlCommand(Dbo.SQL, Dbo.SqlCon)
            Dbo.SQLCmd.ExecuteNonQuery()
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read
                .Rows.Add(cntr, Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString)
                cntr += 1
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End With
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    Private Sub dtList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellClick
        btnGenerateExcel.Text = "GENERATE CONTAINER INVENTORY FOR " & vbCrLf & dtList.CurrentRow.Cells(1).Value

        'If dtList.CurrentRow.Cells(1).Value Then
        If dtList.CurrentRow.Cells(1).Value.ToString.Contains("IMP-") Then
            FrmContainerInventoryPerBooking.pnlImportContainers.Visible = True
        Else
            FrmContainerInventoryPerBooking.pnlImportContainers.Visible = False
        End If
        'End If

        If e.ColumnIndex = 2 Then
            dtList.CurrentRow.Cells(2).Selected = True

            'dtList.CurrentCell = dtList.CurrentRow.Cells(2)
            'dtList.BeginEdit(True)
            'dtList.CurrentRow.Cells(2).IsInEditMode = DataGridViewEditMode.EditOnEnter
        End If

        If e.ColumnIndex = 6 Then
            If MsgBox("Are you sure you want to set this cy for this booking number?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_CONTAINER_INVENTORY SET CY = '" & KVal(dtList.CurrentRow.Cells(2).Value) & "', NosOfSeal = '" & KVal(dtList.CurrentRow.Cells(4).Value) & "', Refno = '" & KVal(dtList.CurrentRow.Cells(5).Value) & "', CyNosOfSealRefnoDateUpdated = '" & Now & "', CyNosOfSealRefnoUpdateBy = '" & USER_ID & "' WHERE BOOKINGNO = '" & KVal(dtList.CurrentRow.Cells(1).Value) & "' AND STAT = '1'")
                Call FrmContainerInventoryList_Load(e, e)
                MsgBox("Saved!", MsgBoxStyle.Information)
            End If
        End If
        If e.ColumnIndex = 7 Then
            FrmContainerInventoryPerBooking.Tag = dtList.CurrentRow.Cells(1).Value

            LoadForm(FrmContainerInventoryPerBooking, "CONTAINER INVENTORY")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadForm(FrmContainerInventoryUpload, "UPLOAD FILE")
    End Sub

    Private Sub dtList_SelectionChanged(sender As Object, e As EventArgs) Handles dtList.SelectionChanged
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        btnGenerateExcel.Text = "GENERATE CONTAINER INVENTORY FOR " & vbCrLf & dtList.CurrentRow.Cells(1).Value
    End Sub

    Private Sub btnGenerateExcel_Click(sender As Object, e As EventArgs) Handles btnGenerateExcel.Click
        If MsgBox("Generate container inventory for booking no. " & dtList.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            Dim Refno As String = ""
            Dim _10DCReturn = 0, _20DCReturn = 0, _40DCReturn = 0, _40HQReturn = 0, _40RFReturn As Integer = 0
            Dim _10DCStocks = 0, _20DCStocks = 0, _40DCStocks = 0, _40HQStocks = 0, _40RFStocks As Integer = 0
            Dim _10DCStats = 0, _20DCStats = 0, _40DCStats = 0, _40HQStats = 0, _40RFStats As Integer = 0
            Dim _10DC = 0, _20DC = 0, _40DC = 0, _40HQ = 0, _40RF As Integer = 0


            Dim AllCntrCountStats As String = ""
            Dim _10DCStrStats = "", _20DCStrStats = "", _40DCStrStats = "", _40HQStrStats = "", _40RFStrStats As String = ""


            Dim AllCntrCount As String = ""
            Dim _10DCStr = "", _20DCStr = "", _40DCStr = "", _40HQStr = "", _40RFStr As String = ""



            'Dim T_10DC = 0, T_20DC = 0, T_40DC = 0, T_40HQ = 0, T_40RF As Integer = 0

            Dim RowStart As Integer = 6
            Dim ColStart As Integer = 1
            'Dim itemCount As Integer = 1
            'Dim HeaderRowStart As Integer = 7
            Dim DetailStartRow = 0, DetailRowEnd As Integer = 0
            Dim CyName As String = ""
            Dim NosOfSeal As Double = 0


            Dim Dbo As New SQLClass


            xls.Workbooks.Add()
            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet


            Dim OneWay As String = ""
            If GetRyzk("SELECT TOP 1 ONEWAY FROM TBL_CONTAINER_INVENTORY WHERE BookingNo = '" & dtList.CurrentRow.Cells(1).Value & "' AND CY <> ''", "") = NoRecordFound Then
                OneWay = ""
            Else
                OneWay = "( " & GetRyzk("SELECT TOP 1 ONEWAY FROM TBL_CONTAINER_INVENTORY WHERE BookingNo = '" & dtList.CurrentRow.Cells(1).Value & "' AND CY <> ''", "") & " FREE-USE ) "
            End If



            RowStart += 1

            InputTextComplete("A" & RowStart & ":B" & RowStart, True, 25.5, 47.43, 10, "Arial", "C", "CONTAINER NOS.", True, sheet, Color.Black, 2)
            ColStart += 2
            InputTextCompleteIntRange(ColStart, RowStart, True, 25.5, 5.64, 10, "Arial", "C", "   SIZE   ", True, sheet, Color.Black, 2)
            ColStart += 1
            InputTextCompleteIntRange(ColStart, RowStart, True, 25.5, 5.64, 10, "Arial", "C", "   EST. ARRIVAL MANILA   ", True, sheet, Color.Black, 2)
            ColStart += 1
            InputTextCompleteIntRange(ColStart, RowStart, True, 25.5, 5.64, 10, "Arial", "C", "   STATUS OF CONTAINER   ", True, sheet, Color.Black, 2)
            ColStart += 1
            InputTextCompleteIntRange(ColStart, RowStart, True, 25.5, 5.64, 10, "Arial", "C", "   RETURN TO DEPOT   ", True, sheet, Color.Black, 2)
            ColStart += 1
            InputTextCompleteIntRange(ColStart, RowStart, True, 25.5, 5.64, 10, "Arial", "C", "   REMARKS   ", True, sheet, Color.Black, 2)
            ColStart += 1
            InputTextCompleteIntRange(ColStart, RowStart, True, 25.5, 5.64, 10, "Arial", "C", "   RELEASE TO SHIPPER   ", True, sheet, Color.Black, 2)
            RowStart += 1

            ColStart = 1

            DetailStartRow = RowStart
            Dim cntr As Integer = 1
            Dbo.SqlCon.Open()
            Dbo.SQL = "  SELECT id, BookingNo, CONTAINER_NO, CONTAINER_TYPE, ArrivalManila, StatusOfContainer, ReturnToDepot, Remarks, Shipper, ContainerPullOut, CY, NosOfSeal, REFNO FROM TBL_CONTAINER_INVENTORY where BookingNo = '" & dtList.CurrentRow.Cells(1).Value & "'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(Dbo.SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Do While Dbo.reader.Read
                CyName = Dbo.reader(10).ToString
                NosOfSeal = Dbo.reader(11).ToString
                Refno = Dbo.reader(12).ToString
                Dim ArrivalManila As String = Dbo.reader(4).ToString
                Dim ReturnToDepot As String = Dbo.reader(6).ToString
                Dim Pullout As String = Dbo.reader(9).ToString

                If Not String.IsNullOrEmpty(ArrivalManila) Then
                    ArrivalManila = Format(CDate(Dbo.reader(4).ToString), "MM/dd/yyyy")
                End If

                If Not String.IsNullOrEmpty(ReturnToDepot) Then
                    ReturnToDepot = Format(CDate(Dbo.reader(6).ToString), "MM/dd/yyyy")
                End If

                If Not String.IsNullOrEmpty(Pullout) Then
                    Pullout = " (PO " & Format(CDate(Dbo.reader(9).ToString), "MM/dd/yyyy") & ")"
                End If

                If Dbo.reader(3).ToString = "10DC" Then
                    _10DC = _10DC + 1

                ElseIf Dbo.reader(3).ToString = "20DC" Then
                    _20DC = _20DC + 1

                ElseIf Dbo.reader(3).ToString = "40DC" Then
                    _40DC = _40DC + 1

                ElseIf Dbo.reader(3).ToString = "40HQ" Then
                    _40HQ = _40HQ + 1

                ElseIf Dbo.reader(3).ToString = "40RF" Then
                    _40RF = _40RF + 1

                End If

                'stats
                If Not String.IsNullOrEmpty(Dbo.reader(5).ToString) Then
                    If Dbo.reader(3).ToString = "10DC" Then
                        _10DCStats = _10DCStats + 1

                    ElseIf Dbo.reader(3).ToString = "20DC" Then
                        _20DCStats = _20DCStats + 1

                    ElseIf Dbo.reader(3).ToString = "40DC" Then
                        _40DCStats = _40DCStats + 1

                    ElseIf Dbo.reader(3).ToString = "40HQ" Then
                        _40HQStats = _40HQStats + 1

                    ElseIf Dbo.reader(3).ToString = "40RF" Then
                        _40RFStats = _40RFStats + 1

                    End If

                End If

                'stocks
                Dim stocksName As String = Dbo.reader(7).ToString
                If stocksName.Contains("AVL") Then
                    If Dbo.reader(3).ToString = "10DC" Then
                        _10DCStocks = _10DCStocks + 1

                    ElseIf Dbo.reader(3).ToString = "20DC" Then
                        _20DCStocks = _20DCStocks + 1

                    ElseIf Dbo.reader(3).ToString = "40DC" Then
                        _40DCStocks = _40DCStocks + 1

                    ElseIf Dbo.reader(3).ToString = "40HQ" Then
                        _40HQStocks = _40HQStocks + 1

                    ElseIf Dbo.reader(3).ToString = "40RF" Then
                        _40RFStocks = _40RFStocks + 1

                    End If

                End If


                'return
                If Not String.IsNullOrEmpty(Dbo.reader(6).ToString) Then
                    If Dbo.reader(3).ToString = "10DC" Then
                        _10DCReturn = _10DCReturn + 1

                    ElseIf Dbo.reader(3).ToString = "20DC" Then
                        _20DCReturn = _20DCReturn + 1

                    ElseIf Dbo.reader(3).ToString = "40DC" Then
                        _40DCReturn = _40DCReturn + 1

                    ElseIf Dbo.reader(3).ToString = "40HQ" Then
                        _40HQReturn = _40HQReturn + 1

                    ElseIf Dbo.reader(3).ToString = "40RF" Then
                        _40RFReturn = _40RFReturn + 1

                    End If

                End If

                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", cntr, True, sheet, Color.Black, 6)
                ColStart += 1

                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", Dbo.reader(2).ToString, True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", Dbo.reader(3).ToString, True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", ArrivalManila, True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", Dbo.reader(5).ToString, True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", ReturnToDepot, True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", Dbo.reader(7).ToString, True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextCompleteIntRange(ColStart, RowStart, True, 15.5, 0, 10, "Quattrocento Sans", "C", Dbo.reader(8).ToString & Pullout, True, sheet, Color.Black, 0)
                ColStart += 1

                RowStart += 1
                ColStart = 1
                cntr += 1
            Loop
            Dbo.reader.Close()
            Dbo.SqlCon.Close()


            InputTextComplete("A" & RowStart & ":" & "H" & RowStart, True, 15, 0, 8, "Arial Black", "C", "", True, sheet, Color.Black, 6)

            RowStart += 1

            DetailRowEnd = RowStart

            sheet.Range("A" & DetailStartRow - 2 & ":" & "H" & DetailRowEnd - 1).Borders.Weight = Excel.XlBorderWeight.xlThin

            ColStart = 1
            RowStart += 2

            Dim SummaryRowStart = 0, SummaryRowEnd As Integer = 0
            SummaryRowStart = RowStart


            _10DCStr = _10DC & "X10DC & "
            _20DCStr = _20DC & "X20DC & "
            _40DCStr = _40DC & "X40DC & "
            _40HQStr = _40HQ & "X40HQ & "
            _40RFStr = _40RF & "X40RF & "

            If _40RF = 0 Then
                _40RFStr = ""
            End If

            If _40HQ = 0 Then
                _40HQStr = ""
            End If

            If _40DC = 0 Then
                _40DCStr = ""
            End If

            If _20DC = 0 Then
                _20DCStr = ""
            End If

            If _10DC = 0 Then
                _10DCStr = ""
            End If

            AllCntrCount = _10DCStr & _20DCStr & _40DCStr & _40HQStr & _40RFStr
            If Microsoft.VisualBasic.Right(AllCntrCount, 2) = "& " Then
                AllCntrCount = Microsoft.VisualBasic.Left(AllCntrCount, Len(AllCntrCount) - 2)
            End If



            'stats


            _10DCStrStats = _10DCStats & "X10DC & "
            _20DCStrStats = _20DCStats & "X20DC & "
            _40DCStrStats = _40DCStats & "X40DC & "
            _40HQStrStats = _40HQStats & "X40HQ & "
            _40RFStrStats = _40RFStats & "X40RF & "

            If _40RFStats = 0 Then
                _40RFStrStats = ""
            End If

            If _40HQStats = 0 Then
                _40HQStrStats = ""
            End If

            If _40DCStats = 0 Then
                _40DCStrStats = ""
            End If

            If _20DCStats = 0 Then
                _20DCStrStats = ""
            End If

            If _10DCStats = 0 Then
                _10DCStrStats = ""
            End If

            AllCntrCountStats = _10DCStrStats & _20DCStrStats & _40DCStrStats & _40HQStrStats & _40RFStrStats
            If Microsoft.VisualBasic.Right(AllCntrCountStats, 2) = "& " Then
                AllCntrCountStats = Microsoft.VisualBasic.Left(AllCntrCountStats, Len(AllCntrCountStats) - 2)
            End If


            'Stocks avl
            Dim AllCntrCountStocks As String = ""
            Dim _10DCStrStocks = "", _20DCStrStocks = "", _40DCStrStocks = "", _40HQStrStocks = "", _40RFStrStocks As String = ""


            _10DCStrStocks = _10DCStocks & "X10DC & "
            _20DCStrStocks = _20DCStocks & "X20DC & "
            _40DCStrStocks = _40DCStocks & "X40DC & "
            _40HQStrStocks = _40HQStocks & "X40HQ & "
            _40RFStrStocks = _40RFStocks & "X40RF & "

            If _40RFStocks = 0 Then
                _40RFStrStocks = ""
            End If

            If _40HQStocks = 0 Then
                _40HQStrStocks = ""
            End If

            If _40DCStocks = 0 Then
                _40DCStrStocks = ""
            End If

            If _20DCStocks = 0 Then
                _20DCStrStocks = ""
            End If

            If _10DCStocks = 0 Then
                _10DCStrStocks = ""
            End If

            AllCntrCountStocks = _10DCStrStocks & _20DCStrStocks & _40DCStrStocks & _40HQStrStocks & _40RFStrStocks
            If Microsoft.VisualBasic.Right(AllCntrCountStocks, 2) = "& " Then
                AllCntrCountStocks = Microsoft.VisualBasic.Left(AllCntrCountStocks, Len(AllCntrCountStocks) - 2)
            End If




            'Return
            Dim AllCntrReturn As String = ""
            Dim _10DCStrReturn = "", _20DCStrReturn = "", _40DCStrReturn = "", _40HQStrReturn = "", _40RFStrReturn As String = ""


            _10DCStrReturn = _10DCReturn & "X10DC & "
            _20DCStrReturn = _20DCReturn & "X20DC & "
            _40DCStrReturn = _40DCReturn & "X40DC & "
            _40HQStrReturn = _40HQReturn & "X40HQ & "
            _40RFStrReturn = _40RFReturn & "X40RF & "

            If _40RFReturn = 0 Then
                _40RFStrReturn = ""
            End If

            If _40HQReturn = 0 Then
                _40HQStrReturn = ""
            End If

            If _40DCReturn = 0 Then
                _40DCStrReturn = ""
            End If

            If _20DCReturn = 0 Then
                _20DCStrReturn = ""
            End If

            If _10DCReturn = 0 Then
                _10DCStrReturn = ""
            End If

            AllCntrReturn = _10DCStrReturn & _20DCStrReturn & _40DCStrReturn & _40HQStrReturn & _40RFStrReturn
            If Microsoft.VisualBasic.Right(AllCntrReturn, 2) = "& " Then
                AllCntrReturn = Microsoft.VisualBasic.Left(AllCntrReturn, Len(AllCntrReturn) - 2)
            End If




            If dtList.CurrentRow.Cells(1).Value.ToString.Contains("IMP-") Then
                InputTextComplete("A" & RowStart & ":D" & RowStart, True, 32, 0, 12, "Arial Black", "C", "SUMMARY OF BKG#" & dtList.CurrentRow.Cells(1).Value & "   " & AllCntrCount, True, sheet, Color.Black, 6)
                RowStart += 1


                InputTextComplete("A" & RowStart & ":B" & RowStart, True, 32, 0, 10, "Arial", "C", "KYOWA CONTAINER", True, sheet, Color.Black, 0)
                ColStart += 1

                InputTextComplete("C" & RowStart & ":C" & RowStart, True, 32, 0, 10, "Arial", "C", AllCntrCount, True, sheet, Color.Black, 0)
                ColStart += 1

                InputTextComplete("D" & RowStart & ":D" & RowStart, True, 32, 0, 10, "Arial", "C", "TOTAL NOS. OF SEAL (" & NosOfSeal & ")", True, sheet, Color.Black, 0)
                RowStart += 1

                InputTextComplete("A" & RowStart & ":D" & RowStart, True, 5.25, 0, 10, "Arial", "C", "", True, sheet, Color.Black, 16)




                SummaryRowEnd = RowStart

                'RowStart += 2

                'InputTextComplete("A" & RowStart & ":D" & RowStart, True, 36, 0, 23, "Arial Black", "C", "TOTAL UNITS = " & AllCntrCountStocks, True, sheet, Color.Black, 0)




                sheet.Columns("A:A").AutoFit()
                sheet.Columns("C:AZ").AutoFit()



                sheet.Range("A" & SummaryRowStart & ":" & "D" & SummaryRowEnd).Borders.Weight = Excel.XlBorderWeight.xlThin






                InputTextComplete("A" & 3 & ":H" & 3, True, 28.5, 0, 15, "Arial Black", "C", KValNoEnter(CyName), True, sheet, Color.Black, 0)


                Dim cyAddress = "", cyOperatingHours As String = ""
                If GetRyzk("SELECT ADDRESSIS FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "") = NoRecordFound Then
                    cyAddress = ""
                Else
                    cyAddress = GetRyzk("SELECT ADDRESSIS FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "")
                End If

                InputTextComplete("A" & 4 & ":H" & 4, True, 15, 0, 8, "Arial Black", "C", KValNoEnter(cyAddress), True, sheet, Color.Black, 0)


                If GetRyzk("SELECT CONCAT(FORMAT(OperatingHrsStart,'hh:mmtt'),'-',FORMAT(OperatingHrsEnd,'hh:mmtt')) FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "") = NoRecordFound Then
                    cyOperatingHours = ""
                Else
                    cyOperatingHours = GetRyzk("SELECT CONCAT(FORMAT(OperatingHrsStart,'hh:mmtt'),'-',FORMAT(OperatingHrsEnd,'hh:mmtt')) FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "")
                End If


                InputTextComplete("A" & 5 & ":H" & 5, True, 15, 0, 8, "Arial Black", "C", KValNoEnter("OPERATING HOURS: " & cyOperatingHours), True, sheet, Color.Black, 0)


                InputTextComplete("A" & 6 & ":H" & 6, True, 28.5, 0, 10, "Arial", "C", KValNoEnter("BKG: " & dtList.CurrentRow.Cells(1).Value & " " & OneWay & AllCntrCount & " KYOWA OWN CONTAINER = " & dtList.CurrentRow.Cells(3).Value), True, sheet, Color.Black, 6)





            Else


                InputTextComplete("A" & RowStart & ":D" & RowStart, True, 32, 0, 12, "Arial Black", "C", "SUMMARY   " & AllCntrCount, True, sheet, Color.Black, 6)
                RowStart += 1

                InputTextComplete("A" & RowStart & ":B" & RowStart, True, 32, 0, 10, "Arial", "C", "KYOWA CONTAINER BKG#" & dtList.CurrentRow.Cells(1).Value, True, sheet, Color.Black, 0)
                ColStart += 1

                InputTextComplete("C" & RowStart & ":C" & RowStart, True, 32, 0, 10, "Arial", "C", AllCntrCount, True, sheet, Color.Black, 0)
                ColStart += 1

                InputTextComplete("D" & RowStart & ":D" & RowStart, True, 32, 0, 10, "Arial", "C", "TOTAL NOS. OF SEAL", True, sheet, Color.Black, 0)
                RowStart += 1

                InputTextComplete("A" & RowStart & ":D" & RowStart, True, 5.25, 0, 10, "Arial", "C", "", True, sheet, Color.Black, 16)
                RowStart += 1
                InputTextComplete("D" & RowStart & ":D" & RowStart + 2, True, 32, 0, 10, "Arial", "C", NosOfSeal, True, sheet, Color.Black, 0)
                InputTextComplete("A" & RowStart & ":B" & RowStart, True, 20, 0, 10, "Arial", "C", "RETURNED TO DEPOT", True, sheet, Color.Black, 0)
                InputTextComplete("C" & RowStart & ":C" & RowStart, True, 20, 0, 10, "Arial", "C", AllCntrReturn, True, sheet, Color.Black, 0)

                RowStart += 1
                InputTextComplete("A" & RowStart & ":B" & RowStart, True, 20, 0, 10, "Arial", "C", "BALANCE  (N/A ReturnToDepot)", True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextComplete("C" & RowStart & ":C" & RowStart, True, 20, 0, 10, "Arial", "C", AllCntrCountStats, True, sheet, Color.Black, 0)
                RowStart += 1
                InputTextComplete("A" & RowStart & ":B" & RowStart, True, 20, 0, 10, "Arial", "C", "STOCKS AVL", True, sheet, Color.Black, 0)
                ColStart += 1
                InputTextComplete("C" & RowStart & ":C" & RowStart, True, 20, 0, 10, "Arial", "C", AllCntrCountStocks, True, sheet, Color.Black, 0)
                SummaryRowEnd = RowStart

                RowStart += 2

                InputTextComplete("A" & RowStart & ":D" & RowStart, True, 36, 0, 23, "Arial Black", "C", "TOTAL UNITS = " & AllCntrCountStocks, True, sheet, Color.Black, 0)




                sheet.Columns("A:A").AutoFit()
                sheet.Columns("C:AZ").AutoFit()



                sheet.Range("A" & SummaryRowStart & ":" & "D" & SummaryRowEnd).Borders.Weight = Excel.XlBorderWeight.xlThin






                InputTextComplete("A" & 3 & ":H" & 3, True, 28.5, 0, 15, "Arial Black", "C", KValNoEnter(CyName), True, sheet, Color.Black, 0)


                Dim cyAddress = "", cyOperatingHours As String = ""
                If GetRyzk("SELECT ADDRESSIS FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "") = NoRecordFound Then
                    cyAddress = ""
                Else
                    cyAddress = GetRyzk("SELECT ADDRESSIS FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "")
                End If

                InputTextComplete("A" & 4 & ":H" & 4, True, 15, 0, 8, "Arial Black", "C", KValNoEnter(cyAddress), True, sheet, Color.Black, 0)


                If GetRyzk("SELECT CONCAT(FORMAT(OperatingHrsStart,'hh:mmtt'),'-',FORMAT(OperatingHrsEnd,'hh:mmtt')) FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "") = NoRecordFound Then
                    cyOperatingHours = ""
                Else
                    cyOperatingHours = GetRyzk("SELECT CONCAT(FORMAT(OperatingHrsStart,'hh:mmtt'),'-',FORMAT(OperatingHrsEnd,'hh:mmtt')) FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "")
                End If


                InputTextComplete("A" & 5 & ":H" & 5, True, 15, 0, 8, "Arial Black", "C", KValNoEnter("OPERATING HOURS: " & cyOperatingHours), True, sheet, Color.Black, 0)


                InputTextComplete("A" & 6 & ":H" & 6, True, 28.5, 0, 10, "Arial", "C", KValNoEnter(AllCntrCount & " KYOWA OWN CONTAINER = " & dtList.CurrentRow.Cells(3).Value), True, sheet, Color.Black, 6)


            End If



            'InputTextComplete("A" & RowStart & ":D" & RowStart, True, 32, 0, 12, "Arial Black", "C", "SUMMARY OF BKG#" & dtList.CurrentRow.Cells(1).Value & "   " & AllCntrCount, True, sheet, Color.Black, 6)
            'RowStart += 1
            'InputTextComplete("A" & RowStart & ":B" & RowStart, True, 32, 0, 10, "Arial", "C", "KYOWA CONTAINER BKG#" & dtList.CurrentRow.Cells(1).Value, True, sheet, Color.Black, 0)
            'ColStart += 1

            'InputTextComplete("C" & RowStart & ":C" & RowStart, True, 32, 0, 10, "Arial", "C", AllCntrCount, True, sheet, Color.Black, 0)
            'ColStart += 1
            'InputTextComplete("D" & RowStart & ":D" & RowStart, True, 32, 0, 10, "Arial", "C", "TOTAL NOS. OF SEAL", True, sheet, Color.Black, 0)
            'RowStart += 1

            'InputTextComplete("A" & RowStart & ":D" & RowStart, True, 5.25, 0, 10, "Arial", "C", "", True, sheet, Color.Black, 16)
            'RowStart += 1
            'InputTextComplete("D" & RowStart & ":D" & RowStart + 2, True, 32, 0, 10, "Arial", "C", NosOfSeal, True, sheet, Color.Black, 0)
            'InputTextComplete("A" & RowStart & ":B" & RowStart, True, 20, 0, 10, "Arial", "C", "RETURNED TO DEPOT", True, sheet, Color.Black, 0)
            'InputTextComplete("C" & RowStart & ":C" & RowStart, True, 20, 0, 10, "Arial", "C", AllCntrReturn, True, sheet, Color.Black, 0)

            'RowStart += 1
            'InputTextComplete("A" & RowStart & ":B" & RowStart, True, 20, 0, 10, "Arial", "C", "BALANCE  (N/A ReturnToDepot)", True, sheet, Color.Black, 0)
            'ColStart += 1
            'InputTextComplete("C" & RowStart & ":C" & RowStart, True, 20, 0, 10, "Arial", "C", AllCntrCountStats, True, sheet, Color.Black, 0)
            'RowStart += 1
            'InputTextComplete("A" & RowStart & ":B" & RowStart, True, 20, 0, 10, "Arial", "C", "STOCKS AVL", True, sheet, Color.Black, 0)
            'ColStart += 1
            'InputTextComplete("C" & RowStart & ":C" & RowStart, True, 20, 0, 10, "Arial", "C", AllCntrCountStocks, True, sheet, Color.Black, 0)
            'SummaryRowEnd = RowStart

            'RowStart += 2

            'InputTextComplete("A" & RowStart & ":D" & RowStart, True, 36, 0, 23, "Arial Black", "C", "TOTAL UNITS = " & AllCntrCountStocks, True, sheet, Color.Black, 0)




            'sheet.Columns("A:A").AutoFit()
            'sheet.Columns("C:AZ").AutoFit()



            'sheet.Range("A" & SummaryRowStart & ":" & "D" & SummaryRowEnd).Borders.Weight = Excel.XlBorderWeight.xlThin






            'InputTextComplete("A" & 3 & ":H" & 3, True, 28.5, 0, 15, "Arial Black", "C", KValNoEnter(CyName), True, sheet, Color.Black, 0)


            'Dim cyAddress = "", cyOperatingHours As String = ""
            'If GetRyzk("SELECT ADDRESSIS FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "") = NoRecordFound Then
            '    cyAddress = ""
            'Else
            '    cyAddress = GetRyzk("SELECT ADDRESSIS FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "")
            'End If

            'InputTextComplete("A" & 4 & ":H" & 4, True, 15, 0, 8, "Arial Black", "C", KValNoEnter(cyAddress), True, sheet, Color.Black, 0)


            'If GetRyzk("SELECT CONCAT(FORMAT(OperatingHrsStart,'hh:mmtt'),'-',FORMAT(OperatingHrsEnd,'hh:mmtt')) FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "") = NoRecordFound Then
            '    cyOperatingHours = ""
            'Else
            '    cyOperatingHours = GetRyzk("SELECT CONCAT(FORMAT(OperatingHrsStart,'hh:mmtt'),'-',FORMAT(OperatingHrsEnd,'hh:mmtt')) FROM TBL_DEPOT WHERE NAME = '" & CyName & "'", "")
            'End If


            'InputTextComplete("A" & 5 & ":H" & 5, True, 15, 0, 8, "Arial Black", "C", KValNoEnter("OPERATING HOURS: " & cyOperatingHours), True, sheet, Color.Black, 0)


            'InputTextComplete("A" & 6 & ":H" & 6, True, 28.5, 0, 10, "Arial", "C", KValNoEnter("BKG: " & dtList.CurrentRow.Cells(1).Value & " " & OneWay & AllCntrCount & " KYOWA OWN CONTAINER = " & dtList.CurrentRow.Cells(3).Value), True, sheet, Color.Black, 6)
            InputTextComplete("A" & 1 & ":A" & 1, True, 15, 0, 10, "Cambria", "L", "REFNO: " & Refno, True, sheet, Color.Black, 0)
            InputTextComplete("A" & 2 & ":A" & 2, True, 15, 0, 10, "Cambria", "L", "DATE: " & Format(Now, "MMM dd, yyyy"), True, sheet, Color.Black, 0)
            xls.Visible = True

        End If
    End Sub

    Private Sub dtList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellEndEdit
        dtList.CurrentRow.Cells(3).Value = dtList.CurrentRow.Cells(2).Value
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call LoadList(txtValue.Text)
    End Sub
End Class