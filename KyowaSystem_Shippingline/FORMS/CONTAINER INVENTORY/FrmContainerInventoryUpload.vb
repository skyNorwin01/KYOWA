Imports System
Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Public Class FrmContainerInventoryUpload



    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
        'OpenFileDialog1.Filter = "XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|XLS files (*.xls, *.xlt)|*.xls;*.xlt|CSV Files (*.csv)|*.csv"

        OpenFileDialog1.Filter = "Excel Files | *.xlsx; *.xls; *.xlsm;"

        If OpenFileDialog1.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then


            Dim conn As OleDbConnection


                Dim xl As New Excel.Application


                Dim fi As New FileInfo(OpenFileDialog1.FileName)
                Dim sConnectionStringz As String = "Provider=Microsoft.ACE.OLEDB.12.0;Extended Properties=Text;Data Source=" & OpenFileDialog1.FileName & ";" & "Extended Properties=Excel 12.0"
                'MsgBox(OpenFileDialog1.FileName)
                'Exit Sub
                conn = New OleDbConnection(sConnectionStringz)
                'Dim objConn As New OleDbConnection(sConnectionStringz)
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
                conn.Open()

                Dim dtSheets As DataTable =
              conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                Dim listSheet As New List(Of String)
                Dim drSheet As DataRow

                For Each drSheet In dtSheets.Rows

                    listSheet.Add(drSheet("TABLE_NAME").ToString())
                Next

                Dim strn As String = ""
                'show sheetname in textbox where multiline Is true
                'For Each sheet As String In listSheet
                '    dta = New OleDbDataAdapter("SELECT * FROM [" & sheet & "]", conn)
                '    dts = New DataSet


                '    dta.Fill(dts, "[" & sheet & "]")

                '    dtList.DataSource = dts
                '    dtList.DataMember = "[" & sheet & "]"
                'Next



                For Each sheet As String In listSheet
                    Dim strName As String = ""
                    If sheet.Contains("ONEWAY") Then
                        strName = "ONE WAY"
                    Else
                        strName = ""
                    End If
                    Dim DDbo As New SQLClass
                    DDbo.SQL = "SELECT * FROM [" & sheet & "]"
                    DDbo.OSQLCmd = New OleDbCommand(DDbo.SQL, conn)

                    'dta = New OleDbDataAdapter("SELECT * FROM [" & sheet & "]", conn)
                    'dts = New DataSet

                    DDbo.OReader = DDbo.OSQLCmd.ExecuteReader
                    Dim cntr As Integer = 1
                    Dim bkgIs = "", CntrType As String = ""
                    Do While DDbo.OReader.Read
                        If Not String.IsNullOrEmpty(DDbo.OReader(1).ToString) Then
                            If cntr = 1 Then
                                bkgIs = DDbo.OReader(4).ToString
                            End If
                            If DDbo.OReader(2).ToString = "20DV" Then
                                CntrType = "20DC"
                            ElseIf DDbo.OReader(2).ToString = "40HC" Then
                                CntrType = "40HQ"
                            ElseIf DDbo.OReader(2).ToString = "40DV" Then
                                CntrType = "40DC"
                            End If
                        dtList.Rows.Add(cntr, DDbo.OReader(1).ToString, CntrType, bkgIs, strName, LandingForm.ServiceIs)
                        cntr += 1
                            End If
                    Loop


                    'dta.Fill(dts, "[" & sheet & "]")

                    'dtList.DataSource = dts
                    'dtList.DataMember = "[" & sheet & "]"
                Next




                'xlwbook = xl.Workbooks.Open(OpenFileDialog1.FileName)
                'xlsheet = xlwbook.Sheets.Item(1)





                conn.Close()



        End If



        'Dim openFileDialog = New OpenFileDialog()
        'openFileDialog.Filter = "XLS files (*.xls, *.xlt)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm)|*.xlsx;*.xlsm;*.xltx;*.xltm|ODS files (*.ods, *.ots)|*.ods;*.ots|CSV files (*.csv, *.tsv)|*.csv;*.tsv|HTML files (*.html, *.htm)|*.html;*.htm"
        'openFileDialog.FilterIndex = 2

        'If (openFileDialog.ShowDialog() = DialogResult.OK) Then

        '    ' Form Level Declartaion
        '    'Change the excel name & path 
        '    Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" &
        '                   "Data Source=C:\MyExcel.xls;" &
        '                   "Extended Properties=""Excel 8.0;HDR=YES"""


        'End If


    End Sub

    Private Sub btnSaveCs_Click(sender As Object, e As EventArgs) Handles btnSaveCs.Click
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure you want to sync this records?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            With dtList
                For i As Integer = 0 To .RowCount - 1
                    If GetRyzk("SELECT CONTAINER_NO FROM TBL_CONTAINER_INVENTORY WHERE CONTAINER_NO = '" & KVal(.Rows(i).Cells(1).Value) & "'", "") = NoRecordFound Then
                        Call SaveRecords(.Rows(i).Cells(3).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, USER_ID, Now, "1", .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value)
                    End If
                Next
            End With
            FrmContainerInventoryList.FrmContainerInventoryList_Load(e, e)
            MsgBox("Successfully done!", MsgBoxStyle.Information)
            Me.Dispose()
        End If
    End Sub
    Public Sub SaveRecords(BookingNo, CONTAINER_NO, CONTAINER_TYPE, AddedBy, DateAdded, Stat, OneWay, TypeOfService)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CONTAINER_INVENTORY( BookingNo, CONTAINER_NO, CONTAINER_TYPE,AddedBy, DateAdded, Stat, OneWay, TypeOfService)"
        SQL = SQL + "VALUES('" & KVal(BookingNo) & "',  '" & KVal(CONTAINER_NO) & "',  '" & KVal(CONTAINER_TYPE) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "', '" & KVal(OneWay) & "', '" & KVal(TypeOfService) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub FrmContainerInventoryUpload_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmContainerInventoryUpload_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
End Class