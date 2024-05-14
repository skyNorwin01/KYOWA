Public Class FrmContainerBookingNumber

    Dim strValidity As String = ""
    Private Sub FrmContainerBookingNumber_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbValidityDate.Items
            .Clear()
            .Add("WEEK/S")
            .Add("DATE")
        End With
        cmbValidityDate.SelectedIndex = 0

        Call LoadStrCmb(CmbLeasing, "SELECT ID, NAME FROM TBL_LEASING_CONTAINER WHERE STAT = '1' ORDER BY NAME ASC")
        With cmbContSize.Items
            .Clear()
            .Add("10DC")
            .Add("20DC")
            .Add("40DC")
            .Add("40HQ")
            .Add("20RF")
            .Add("40RF")
            .Add("CBM")
            .Add("KGS")
            .Add("20FR")
            .Add("40FR")
        End With
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If cmbValidityDate.Text = "WEEK/S" Then
            strValidity = txtValidityDate.Text
        ElseIf cmbValidityDate.Text = "DATE" Then
            strValidity = Format(dtValidityDate.Value, "MM-dd-yyyy")
        Else
            strValidity = "0"
        End If

        With dtContainerListBooking
            .Rows.Add(CmbLeasing.Text, txtContCount.Text, KVal(cmbContSize.Text), KVal(txtContNo.Text), KVal(strValidity))
        End With
    End Sub

    Private Sub dtContainerListBooking_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtContainerListBooking.CellContentClick
        If e.ColumnIndex = 5 Then
            If MsgBox("Are you sure you want to delete this item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtContainerListBooking.Rows.Remove(dtContainerListBooking.CurrentRow)
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click


        If MsgBox("Are you sure you want to save?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_CONTAINER_BOOKING SET STAT = '2' WHERE STAT = '3' AND BKNO = '" & MainBkno & "' AND SYSREF = '" & MainSysref & "'")
            With dtContainerListBooking
                For i As Integer = 0 To dtContainerListBooking.RowCount - 1
                    Call SaveNewContainerBooking(MainSysref, MainBkno, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, USER_ID, Now, "3", .Rows(i).Cells(0).Value, .Rows(i).Cells(4).Value)
                Next
            End With
            MsgBox("Saved!", MsgBoxStyle.Information)
        End If

        'ATW_NAG_DODOUBLE_PAGES
    End Sub

    Public Sub SaveNewContainerBooking(SYSREF, BKNO, COUNTIS, ContSize, ContBookingNum, AddedBy, DateAdded, Stat, LeasingContainer, ValidityDate)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CONTAINER_BOOKING ( SYSREF, BKNO, COUNTIS, ContSize, ContBookingNum, AddedBy, DateAdded, Stat, LeasingContainer, ValidityDate)"
        SQL = SQL + "values('" & KVal(SYSREF) & "',  '" & KVal(BKNO) & "',  '" & KVal(COUNTIS) & "',  '" & KVal(ContSize) & "',  '" & KVal(ContBookingNum) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "', '" & KVal(LeasingContainer) & "', '" & KVal(ValidityDate) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub CmbLeasing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLeasing.SelectedIndexChanged, CmbLeasing.TextChanged
        'With sender
        '    If sender.SelectedIndex = -1 Then
        '        .Text = ""
        '        Exit Sub
        '    End If
        '    .tag = Format(CInt(sender.selectedvalue.ToString), "00000")
        'End With
    End Sub

    Private Sub cmbValidityDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbValidityDate.SelectedIndexChanged

    End Sub

    Private Sub cmbValidityDate_TextChanged(sender As Object, e As EventArgs) Handles cmbValidityDate.TextChanged
        If cmbValidityDate.Text = "WEEK/S" Then
            dtValidityDate.Visible = False
            txtValidityDate.Visible = True
        ElseIf cmbValidityDate.Text = "DATE" Then
            dtValidityDate.Visible = True
            txtValidityDate.Visible = False
        Else
            dtValidityDate.Visible = False
            txtValidityDate.Visible = False
        End If
    End Sub
End Class