Imports Microsoft.Office.Interop

Public Class FrmGenerateImportAndLeasedContainerMenu
    Dim rItemAfterHeader As Integer = 0
    Dim ItemHStart As Integer = 0
    Dim ItemHEnd As Integer = 0
    Dim RecapItemHStart As Integer = 0
    Dim RecapItemHEnd As Integer = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        'IMPORT_CONTAINERS_NALANG_KULANG_DITO_
        'INTERVIEW_FOR_MORE_PARA_PWEDE_MAGAWA_SA_BAHAY_OR_OFFICE
        'If MsgBox("Are you sure you want to generate Import and Leased Container report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        Dim xls As New Excel.Application
        Dim book As Excel.Workbook
        Dim sheet As Excel.Worksheet


        Dim RowStart As Integer = 6
        Dim ColStart As Integer = 7





        Dim Dbo As New SQLClass


        xls.Workbooks.Add()
        book = xls.ActiveWorkbook
        sheet = book.ActiveSheet


        'details
        Dbo.SqlCon.Open()
        'SQL = "SELECT DISTINCT D.NAME    FROM TBL_CONTAINER_BOOKING AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO LEFT JOIN TBL_OPERATIONS AS O ON C.BKNO = O .BKNO AND O.STAT <> '0' LEFT JOIN TBL_DEPOT AS D ON O.DEPOT = D.ID LEFT JOIN TBL_CLIENT AS CC ON B.Shipper = CC.ID LEFT JOIN TBL_PORTS AS PRT ON B.PORTS = PRT.ID   WHERE C.STAT <> '2' AND B.STAT <> '2' AND O.BKNO <> '2' AND D.NAME IS NOT NULL  ORDER BY D.NAME ASC"
        'SQL = "SELECT DISTINCT D.NAME, C.LeasingContainer, c.ContBookingNum, (SELECT DISTINCT   ValidityDate  + ', '   FROM TBL_CONTAINER_BOOKING AS C2 LEFT JOIN TBL_BOOKING AS B2 ON C2.BKNO = B2.BKNO LEFT JOIN TBL_OPERATIONS AS O2 ON C2.BKNO = O2.BKNO AND O2.STAT <> '0' LEFT JOIN TBL_DEPOT AS D2 ON O2.DEPOT = D2.ID LEFT JOIN TBL_CLIENT AS CC2 ON B.Shipper = CC2.ID LEFT JOIN TBL_PORTS AS PRT2 ON B2.PORTS = PRT2.ID    WHERE C2.STAT <> '2' AND B2.STAT <> '2' AND O2.BKNO <> '2' AND D2.NAME IS NOT NULL AND D2.NAME = d.NAME AND C2.LeasingContainer = c.LeasingContainer AND C2.ContBookingNum = c.ContBookingNum  FOR XML PATH('')) AS ValidityDate   FROM TBL_CONTAINER_BOOKING AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO LEFT JOIN TBL_OPERATIONS AS O ON C.BKNO = O .BKNO AND O.STAT <> '0' LEFT JOIN TBL_DEPOT AS D ON O.DEPOT = D.ID LEFT JOIN TBL_CLIENT AS CC ON B.Shipper = CC.ID LEFT JOIN TBL_PORTS AS PRT ON B.PORTS = PRT.ID   WHERE C.STAT <> '2' AND B.STAT <> '2' AND O.BKNO <> '2' AND D.NAME IS NOT NULL  ORDER BY D.NAME ASC"
        SQL = "SELECT DISTINCT D.NAME, C.LeasingContainer, (SELECT DISTINCT CONCAT(COUNT(C3.ContSize), 'X' ,C3.ContSize) + ', '   FROM TBL_CONTAINER_BOOKING AS C3 LEFT JOIN TBL_BOOKING AS B3  ON C3.BKNO = B3.BKNO LEFT JOIN TBL_OPERATIONS AS O3 ON C3.BKNO = O3.BKNO AND O3.STAT <> '0' LEFT JOIN TBL_DEPOT AS D3 ON O3.DEPOT = D3.ID LEFT JOIN TBL_CLIENT AS CC3 ON B3.Shipper = CC3.ID LEFT JOIN TBL_PORTS AS PRT3 ON B3.PORTS = PRT3.ID    WHERE C3.STAT <> '2' AND B3.STAT <> '2' AND O3.BKNO <> '2' AND D3.NAME IS NOT NULL   AND B.Stat <> '4' AND D3.NAME = D.NAME AND C3.LeasingContainer = C.LeasingContainer AND C3.ContBookingNum = C.ContBookingNum   GROUP BY C3.CONTSIZE    FOR XML PATH('')) AS  CONTSIZE , c.ContBookingNum, (SELECT DISTINCT   ValidityDate  + ', '   FROM TBL_CONTAINER_BOOKING AS C2 LEFT JOIN TBL_BOOKING AS B2 ON C2.BKNO = B2.BKNO LEFT JOIN TBL_OPERATIONS AS O2 ON C2.BKNO = O2.BKNO AND O2.STAT <> '0' LEFT JOIN TBL_DEPOT AS D2 ON O2.DEPOT = D2.ID LEFT JOIN TBL_CLIENT AS CC2 ON B.Shipper = CC2.ID LEFT JOIN TBL_PORTS AS PRT2 ON B2.PORTS = PRT2.ID    WHERE C2.STAT <> '2' AND B2.STAT <> '2' AND O2.BKNO <> '2' AND D2.NAME IS NOT NULL  AND D2.NAME = d.NAME AND C2.LeasingContainer = c.LeasingContainer AND C2.ContBookingNum = c.ContBookingNum  FOR XML PATH('')) AS ValidityDate   FROM TBL_CONTAINER_BOOKING AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO LEFT JOIN TBL_OPERATIONS AS O ON C.BKNO = O .BKNO AND O.STAT <> '0' LEFT JOIN TBL_DEPOT AS D ON O.DEPOT = D.ID LEFT JOIN TBL_CLIENT AS CC ON B.Shipper = CC.ID LEFT JOIN TBL_PORTS AS PRT ON B.PORTS = PRT.ID   WHERE C.STAT <> '2' AND B.STAT <> '2' AND O.BKNO <> '2'  AND B.Stat <> '4' AND D.NAME IS NOT NULL  ORDER BY D.NAME ASC"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read

            ItemHStart = RowStart

            InputTextComplete("A" & RowStart & ":E" & RowStart, True, 25.5, 0, 10, "Arial Black", "C", Dbo.reader(0).ToString, True, sheet, Color.Black, 6)
            RowStart += 1
            InputTextComplete("A" & RowStart & ":E" & RowStart, True, 25.5, 0, 10, "Arial Black", "C", Dbo.reader(1).ToString & " CNTR " & Dbo.reader(2).ToString & " BKG#" & Dbo.reader(3).ToString & " EXP: " & Dbo.reader(4).ToString, True, sheet, Color.Black, 6)
            RowStart += 1

            Call LoadItems(sheet, RowStart, Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(3).ToString)

            sheet.Range("A" & ItemHStart & ":" & "E" & ItemHEnd - 1).Borders.Weight = Excel.XlBorderWeight.xlThin

            rItemAfterHeader += 2
            RowStart = rItemAfterHeader

        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        sheet.Columns("A:E").AutoFit()



        RowStart = 6
        ColStart = 7


        'recap report
        RecapItemHStart = RowStart
        InputTextComplete("G" & RowStart & ":M" & RowStart, True, 25.5, 0, 10, "Arial Black", "C", "RECAP REPORT", True, sheet, Color.Black, 6)
        RowStart += 1
        InputTextComplete("G" & RowStart & ":I" & RowStart, True, 25.5, 33, 10, "Arial", "C", "LEASING COMPANY NAME", True, sheet, Color.Black, 0)
        InputTextComplete("J" & RowStart & ":J" & RowStart, True, 25.5, 0, 10, "Arial", "C", "20DC", True, sheet, Color.Black, 0)
        InputTextComplete("K" & RowStart & ":K" & RowStart, True, 25.5, 0, 10, "Arial", "C", "40HQ", True, sheet, Color.Black, 0)
        InputTextComplete("L" & RowStart & ":L" & RowStart, True, 25.5, 0, 10, "Arial", "C", "40DC", True, sheet, Color.Black, 0)
        InputTextComplete("M" & RowStart & ":M" & RowStart, True, 25.5, 0, 10, "Arial", "C", "SEAL", True, sheet, Color.Black, 0)
        RowStart += 1
        InputTextComplete("G" & RowStart & ":M" & RowStart, True, 25.5, 0, 10, "Arial Black", "L", "FJP DEPOT", True, sheet, Color.Black, 6)
        RowStart += 1

        Call LoadRecapItems(sheet, RowStart)
        sheet.Range("G" & RecapItemHStart & ":" & "M" & RecapItemHEnd).Borders.Weight = Excel.XlBorderWeight.xlThin



        sheet.Columns("G:M").AutoFit()




        xls.Visible = True


        'End If


    End Sub

    Public Sub LoadRecapItems(sheet As Excel.Worksheet, RowS As Integer)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT distinct C.ContBookingNum, C.ContSize , count(c.contsize)    FROM TBL_CONTAINER_BOOKING AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO AND C.STAT <> '0' AND B.STAT <> '0' LEFT JOIN TBL_OPERATIONS AS O ON C.BKNO = O .BKNO AND O.STAT <> '0' LEFT JOIN TBL_DEPOT AS D ON O.DEPOT = D.ID LEFT JOIN TBL_CLIENT AS CC ON B.Shipper = CC.ID LEFT JOIN TBL_PORTS AS PRT ON B.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS TC ON B.BKNO = TC.BKNO AND TC.STAT	<> '0'   WHERE C.STAT <> '2' AND B.STAT <> '2' AND O.BKNO <> '2' AND TC.STAT	<> '2'  AND O.STAT <> '2' AND B.Stat <> '4'    AND D.NAME IS NOT NULL  GROUP BY C.ContSize, C.ContBookingNum ORDER BY ContBookingNum, C.ContSize"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            InputTextComplete("G" & RowS & ":I" & RowS, True, 25.5, 45.14, 10, "Arial", "L", "Kyowa containers " & Dbo.reader(0).ToString, True, sheet, Color.Black, 0)

            If Dbo.reader(1).ToString = "20DC" Then
                InputTextComplete("J" & RowS & ":J" & RowS, True, 25.5, 0, 10, "Arial", "C", Dbo.reader(2).ToString, True, sheet, Color.Black, 0)
            ElseIf Dbo.reader(1).ToString = "40HQ" Then
                InputTextComplete("K" & RowS & ":K" & RowS, True, 25.5, 0, 10, "Arial", "C", Dbo.reader(2).ToString, True, sheet, Color.Black, 0)
            ElseIf Dbo.reader(1).ToString = "40DC" Then
                InputTextComplete("L" & RowS & ":L" & RowS, True, 25.5, 0, 10, "Arial", "C", Dbo.reader(2).ToString, True, sheet, Color.Black, 0)
            End If

            RowS += 1
        Loop

        InputTextComplete("G" & RowS & ":M" & RowS, True, 25.5, 20, 10, "Arial", "L", "", True, sheet, Color.Black, 6)
        RecapItemHEnd = RowS

        Dbo.reader.Close()
        Dbo.SqlCon.Close()


    End Sub
    Public Sub LoadItems(sheet As Excel.Worksheet, RowS As Integer, PortIs As String, LeasingCont As String, BkNum As String)

        Dim icntr As Integer = 1
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT distinct D.NAME, C.LeasingContainer, CC.ClientName, C.ContSize, C.ContBookingNum, TC.Containerno , PRT.NAME as PortIs, C.STAT, B.STAT  FROM TBL_CONTAINER_BOOKING AS C LEFT JOIN TBL_BOOKING AS B ON C.BKNO = B.BKNO LEFT JOIN TBL_OPERATIONS AS O ON C.BKNO = O .BKNO AND O.STAT <> '0' LEFT JOIN TBL_DEPOT AS D ON O.DEPOT = D.ID LEFT JOIN TBL_CLIENT AS CC ON B.Shipper = CC.ID LEFT JOIN TBL_PORTS AS PRT ON B.PORTS = PRT.ID LEFT JOIN TBL_CONTAINER AS TC ON B.BKNO = TC.BKNO AND TC.STAT	<> '2'   WHERE C.STAT <> '2' AND B.STAT <> '2' AND O.BKNO <> '2'  AND D.NAME IS NOT NULL  AND B.Stat <> '4'   AND D.NAME = '" & PortIs & "' AND C.LeasingContainer = '" & LeasingCont & "' AND C.ContBookingNum = '" & BkNum & "' ORDER BY D.NAME ASC"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            InputTextComplete("A" & RowS & ":A" & RowS, True, 25.5, 0, 10, "Arial", "C", icntr, True, sheet, Color.Black, 2)
            InputTextComplete("B" & RowS & ":B" & RowS, True, 25.5, 0, 10, "Arial", "C", Dbo.reader(2).ToString, True, sheet, Color.Black, 2)
            InputTextComplete("C" & RowS & ":C" & RowS, True, 25.5, 19, 10, "Arial", "C", "    " & Dbo.reader(3).ToString & "    ", True, sheet, Color.Black, 2)
            InputTextComplete("D" & RowS & ":D" & RowS, True, 25.5, 0, 10, "Arial", "C", Dbo.reader(4).ToString, True, sheet, Color.Black, 2)
            InputTextComplete("E" & RowS & ":E" & RowS, True, 25.5, 0, 10, "Arial", "C", Dbo.reader(6).ToString, True, sheet, Color.Black, 2)
            icntr += 1
            RowS += 1
        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        ItemHEnd = RowS
        rItemAfterHeader = RowS

    End Sub
End Class