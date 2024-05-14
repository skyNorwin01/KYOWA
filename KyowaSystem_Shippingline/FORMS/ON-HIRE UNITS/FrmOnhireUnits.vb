Imports Microsoft.Office.Interop
Imports Microsoft
Public Class FrmOnhireUnits
    Public selItemRow As Integer = 0
    Public ModeIs As String = ""

    Private Sub FrmOnhireUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With cmbCategory.Items
            .Clear()
            .Add("CY")
            .Add("ON-HIRE UNIT")
            .Add("BOOKING NO")
            .Add("SHIPPER")
            .Add("CONTAINER NO")
        End With

        'MsgBox(dtList.RowCount - 1)
        'dtList.Rows.Clear()
        Call LoadList(cmbValue.Text)

        'FrmOnhireUnitEditRow.Show()
        FrmOnhireUnitEditRow.Hide()
        'Call LoadStrCmb(FrmOnhireUnitEditRow.cmbCy, "SELECT DISTINCT CYNAME,  CYNAME FROM TBL_ONHIRE_UNITS WHERE STAT = '1'")
        Call LoadStrCmb(FrmOnhireUnitEditRow.cmbOnHireUnits, "SELECT DISTINCT onhire_company, onhire_company  FROM TBL_ONHIRE_UNITS WHERE STAT = '1'")
        Call LoadStrCmb(FrmOnhireUnitEditRow.cmbShipper, "SELECT DISTINCT clientname, clientname  FROM TBL_CLIENT WHERE STAT = '1'")
        Call LoadDepot(FrmOnhireUnitEditRow.cmbCy, "SELECT NAME, NAME, ADDRESSIS, OperatingHrsStart, OperatingHrsEnd, Telno FROM TBL_DEPOT WHERE STAT = '1'")



    End Sub
    Public Sub LoadList(str As String)

        '.Add("CY")
        '.Add("ON-HIRE UNIT")
        '.Add("BOOKING NO")
        '.Add("SHIPPER")
        '.Add("CONTAINER NO")


        Dim strQry As String = ""

        If cmbCategory.Text = "CY" Then
            strQry = " AND CYNAME LIKE '%" & KVal(cmbValue.Text) & "%' "
        ElseIf cmbCategory.Text = "ON-HIRE UNIT" Then
            strQry = " AND Onhire_company LIKE '%" & KVal(cmbValue.Text) & "%' "
        ElseIf cmbCategory.Text = "BOOKING NO" Then
            strQry = " AND bKNO LIKE '%" & KVal(cmbValue.Text) & "%' "
        ElseIf cmbCategory.Text = "SHIPPER" Then
            strQry = " AND Shipper LIKE '%" & KVal(cmbValue.Text) & "%' "
        ElseIf cmbCategory.Text = "CONTAINER NO" Then
            strQry = " AND ContainerNo LIKE '%" & KVal(cmbValue.Text) & "%' "
        Else
            strQry = ""
        End If

        Dim d4 = "", d7 = "", d9 As String = ""
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT CYNAME,Onhire_company, NosOfContainer, bKNO,validity_date, Shipper, Size, LCT, ContainerNo, PulloutDate, ID FROM TBL_ONHIRE_UNITS WHERE STAT = '1' " & strQry & " ORDER BY ID DESC"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                If Not Dbo.reader(4).ToString = "/  /       :" Then
                    d4 = Format(CDate(Dbo.reader(4).ToString), "MM/dd/yyyy hh:mm")
                End If
                If Not Dbo.reader(7).ToString = "/  /       :" Then
                    d7 = Format(CDate(Dbo.reader(7).ToString), "MM/dd/yyyy hh:mm")
                End If
                If Not Dbo.reader(9).ToString = "/  /       :" Then
                    d9 = Format(CDate(Dbo.reader(9).ToString), "MM/dd/yyyy hh:mm")
                End If
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, d4, Dbo.reader(5).ToString, Dbo.reader(6).ToString, d7, Dbo.reader(8).ToString, d9)
                .Rows(.RowCount - 2).Cells(0).Tag = Dbo.reader(10).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    Private Sub dtList_KeyDown(sender As Object, e As KeyEventArgs) Handles dtList.KeyDown
        If e.KeyCode = Keys.Space Then

            Dim ForNewOrForEdit As Integer = 0
            For i As Integer = 0 To dtList.ColumnCount - 1
                If Not String.IsNullOrEmpty(dtList.CurrentRow.Cells(i).Value) Then
                    ForNewOrForEdit = ForNewOrForEdit + 1
                End If
            Next

            If ForNewOrForEdit = 0 Then
                ModeIs = "NEW"
            Else
                ModeIs = "EDIT"
                selItemRow = dtList.CurrentRow.Index
            End If

            'Call LoadStrCleint(FrmContainerInventoryEditRow.cmbReleasetoShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")

            With FrmOnhireUnitEditRow
                .cmbCy.Text = dtList.CurrentRow.Cells(0).Value
                .cmbOnHireUnits.Text = dtList.CurrentRow.Cells(1).Value
                .mtxtContainer.Text = dtList.CurrentRow.Cells(2).Value
                .txtBookingNo.Text = dtList.CurrentRow.Cells(3).Value
                .mTxtValidity.Text = dtList.CurrentRow.Cells(4).Value
                .cmbShipper.Text = dtList.CurrentRow.Cells(5).Value
                .cmbSize.Text = dtList.CurrentRow.Cells(6).Value
                .txtLctOfFV.Text = dtList.CurrentRow.Cells(7).Value
                .txtContainer.Text = dtList.CurrentRow.Cells(8).Value
                .mTxtPullout.Text = dtList.CurrentRow.Cells(9).Value
                .Tag = dtList.CurrentRow.Cells(0).Tag
                .cmbCy.Focus()
            End With


            LoadForm(FrmOnhireUnitEditRow, dtList.CurrentRow.Cells(1).Value)

        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'dtList.Rows(dtList.RowCount - 1).Selected = True
        With FrmOnhireUnitEditRow
            .cmbCy.Text = ""
            .cmbOnHireUnits.Text = ""
            .mtxtContainer.Text = ""
            .txtBookingNo.Text = ""
            .mTxtValidity.Text = ""
            .cmbShipper.Text = ""
            .cmbSize.Text = ""
            .txtLctOfFV.Text = ""
            .txtContainer.Text = ""
            .mTxtPullout.Text = ""
            .Tag = ""
            .cmbCy.Focus()
        End With
        ModeIs = "NEW"
        LoadForm(FrmOnhireUnitEditRow, "NEW RECORD")
    End Sub

    Private Sub dtList_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellEnter
        'MsgBox(dtList.CurrentRow.Cells(0).Tag)
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_ONHIRE_UNITS SET STAT = '0', DeletedBy = '" & USER_ID & "', DateDeleted = '" & Now & "' WHERE STAT = '1' AND ID = '" & dtList.CurrentRow.Cells(0).Tag & "'")
            dtList.Rows.Remove(dtList.CurrentRow)
            MsgBox("Deleted!", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        LoadForm(FrmGenerateOnhireUnitsMenu, "GENERATE ON-HIRE UNITS")
    End Sub

    Private Sub FrmOnhireUnits_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FrmOnhireUnitEditRow.Dispose()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call LoadList(cmbValue.Text)
    End Sub
End Class