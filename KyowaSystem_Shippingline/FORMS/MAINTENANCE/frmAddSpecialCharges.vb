Public Class frmAddSpecialCharges
    Private Sub frmAddSpecialCharges_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtChargesValues.Columns(4).DisplayIndex = 3
        'Call LoadStrCmb(cmbPlace, "SELECT CODEIS , NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY   NAME ASC")
        'Call LoadStrCmb(cmbSize, "SELECT ID , SIZEIS FROM TBL_CONTAINER_SIZE WHERE STAT = '1'  ORDER BY   SIZEIS ASC")
        Call LoadCmbCharges(cmbCharges, "SELECT ID, CHARGES_NAME, CHARGES_CODE FROM TBL_CHARGES_NAME WHERE STAT = '1' ORDER BY CHARGES_NAME ASC")



        With cmbParameter.Items
            .Clear()
            .Add("DAY/S")
        End With
        With cmbParameter2.Items
            .Clear()
            .Add("DAY/S")
        End With

        Call LoadStrCmb(cmbSize2, "SELECT ID , SIZEIS FROM TBL_CONTAINER_SIZE WHERE showSTAT = '1'  ORDER BY   SIZEIS ASC")
        Call LoadStrCmb(cmbCategory, "SELECT ID , SIZEIS FROM TBL_CONTAINER_SIZE WHERE showSTAT = '1'  ORDER BY   SIZEIS ASC")
        Call LoadStrCmb(cmbCurrency, "SELECT ID , CURR FROM TBL_CURRENCY WHERE STAT = '1' ORDER BY   CURR ASC")

        Call LoadListCharges()
        dtChargesValues.Rows.Clear()

        With cmbSequence.Items
            .Clear()
            For i As Integer = 1 To 5
                .Add(i)
            Next
        End With


    End Sub

    Public Sub SaveFreetime(CCODE, ChargeName, Freetime, Parameter, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_FREETIME(CCODE, ChargeName, Freetime, Parameter,   AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(CCODE) & "',  '" & KVal(ChargeName) & "',  '" & KVal(Freetime) & "',  '" & KVal(Parameter) & "' ,  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub cmbCharges_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCharges.SelectedIndexChanged, cmbCharges.TextChanged
        With txtCodeIs
            If sender.SelectedIndex = -1 Then
                .Text = ""
                txtCodeIs.Tag = ""
                Exit Sub
            End If
            .Tag = Format(CInt(CType(sender.SelectedItem, Charges).itemListID), "00000")
            txtCodeIs.Text = CType(sender.SelectedItem, Charges).itemCode
        End With
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbCharges.SelectedIndex = -1 Then
            MsgBox("Invalid charges!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbParameter.SelectedIndex = -1 Then
            MsgBox("Invalid parameter!", MsgBoxStyle.Critical)
            Exit Sub
        End If



        If Not IsNumeric(txtFreetime.Text) Then
            MsgBox("Invalid freetime!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        'If String.IsNullOrEmpty(cmbCharges.Text) Then
        '    MsgBox("Invalid charges!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        'If String.IsNullOrEmpty(cmbParameter.Text) Then
        '    MsgBox("Invalid parameter!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        'If String.IsNullOrEmpty(cmbSize.Text) Then
        '    MsgBox("Invalid parameter!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If


        If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SaveFreetime(txtCodeIs.Text, cmbCharges.Text, txtFreetime.Text, cmbParameter.Text, USER_ID, Now, "1")
            Call LoadListCharges()
            MsgBox("Saved!", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Public Sub LoadListCharges()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT ID, CCODE, ChargeName, Freetime, Parameter, Size FROM TBL_FREETIME WHERE STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtCharges
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, Dbo.reader(5).ToString)
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(0).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For i As Integer = 0 To dtChargesValues.RowCount - 1
            If dtChargesValues.Rows(i).Cells(0).Value = cmbSequence.Text And dtChargesValues.Rows(i).Cells(1).Value = txtQTY.Text And dtChargesValues.Rows(i).Cells(2).Value = cmbParameter2.Text And dtChargesValues.Rows(i).Cells(3).Value = cmbCurrency.Text And dtChargesValues.Rows(i).Cells(4).Value = cmbSize2.Text And FormatMoney(dtChargesValues.Rows(i).Cells(5).Value) = FormatMoney(txtAmount.Text) Then
                MsgBox("Already existing!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Next

        For i As Integer = 0 To dtChargesValues.RowCount - 1
            If dtChargesValues.Rows(i).Cells(0).Value = cmbSequence.Text Then
                MsgBox("Already has sequence no" & cmbSequence.Text, MsgBoxStyle.Critical)
                Exit Sub
            End If
        Next





        If cmbSequence.SelectedIndex = -1 Then
            MsgBox("Invalid sequence!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not IsNumeric(txtQTY.Text) Then
            MsgBox("Invalid nos of parameter!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbParameter2.SelectedIndex = -1 Then
            MsgBox("Invalid parameter!", MsgBoxStyle.Critical)
            Exit Sub
        End If



        If cmbCurrency.SelectedIndex = -1 Then
            MsgBox("Invalid currency!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbSize2.SelectedIndex = -1 Then
            MsgBox("Invalid size!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not IsNumeric(txtAmount.Text) Then
            MsgBox("Invalid amount!", MsgBoxStyle.Critical)
            Exit Sub
        End If




        If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SaveOverFreetime(SaveMoney(cmbSequence.Text), dtCharges.CurrentRow.Cells(0).Value, dtCharges.CurrentRow.Cells(1).Value, txtQTY.Text, cmbParameter2.Text, cmbCurrency.Text, cmbSize2.Text, SaveMoney(txtAmount.Text), USER_ID, Now, "1")
            Call LoadListOverFreetime()
            MsgBox("Saved!", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub


    Public Sub LoadListOverFreetime()
        Call selectCharges()
        'Dim Dbo As New SQLClass
        'Dbo.SqlCon.Open()
        'SQL = "SELECT CCODE, ChargeName, SequenceIs, qty, Parameter, Currency, Size, Amount, AddedBy, DateAdded, STAT,id FROM TBL_OVER_FREETIME WHERE STAT = '1'  AND CHARGENAME = '" & dtCharges.CurrentRow.Cells(1).Value & "' AND CCODE = '" & dtCharges.CurrentRow.Cells(0).Value & "' AND SIZE = '" & KVal(cmbCategory.Text) & "'"
        'Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        'Dbo.SQLCmd.ExecuteNonQuery()
        'Dbo.reader = Dbo.SQLCmd.ExecuteReader
        'With dtChargesValues
        '    .Rows.Clear()
        '    Do While Dbo.reader.Read
        '        .Rows.Add(Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, Dbo.reader(5).ToString, Dbo.reader(6).ToString, Dbo.reader(7).ToString)
        '        .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(9).ToString
        '    Loop
        'End With
        'Dbo.reader.Close()
        'Dbo.SqlCon.Close()
    End Sub
    Public Sub SaveOverFreetime(SequenceIs, CCODE, ChargeName, qty, Parameter, Currency, Size, Amount, AddedBy, DateAdded, STAT)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_OVER_FREETIME(SequenceIs, CCODE, ChargeName, qty, Parameter, Currency, Size, Amount, AddedBy, DateAdded, STAT)"
        SQL = SQL + "VALUES('" & KVal(SequenceIs) & "', '" & KVal(CCODE) & "',  '" & KVal(ChargeName) & "',  '" & KVal(qty) & "',  '" & KVal(Parameter) & "',  '" & KVal(Currency) & "',  '" & KVal(Size) & "',  '" & KVal(Amount) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(STAT) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub dtCharges_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtCharges.CellContentClick

        Call selectCharges()


    End Sub
    Public Sub selectCharges()
        If dtCharges.RowCount = 0 Then
            Exit Sub
        End If
        If dtCharges.RowCount = 0 Then
            LblSelectedCharges.Text = ""
            Exit Sub
        End If
        LblSelectedCharges.Text = dtCharges.CurrentRow.Cells(1).Value
        'cmbSize2.Text = dtCharges.CurrentRow.Cells(4).Value
        'cmbSize2.Enabled = False


        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT CCODE, ChargeName, SequenceIs, qty, Parameter, Currency, Size, Amount, ID FROM TBL_OVER_FREETIME WHERE STAT = '1' AND CHARGENAME = '" & dtCharges.CurrentRow.Cells(1).Value & "' AND CCODE = '" & dtCharges.CurrentRow.Cells(0).Value & "' AND SIZE = '" & KVal(cmbCategory.Text) & "' "
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtChargesValues
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, Dbo.reader(5).ToString, Dbo.reader(6).ToString, FormatMoneyN(Dbo.reader(7).ToString))
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(8).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()


    End Sub
    Private Sub dtChargesValues_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtChargesValues.CellContentClick

    End Sub

    Private Sub frmAddSpecialCharges_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtAmount_LostFocus(sender As Object, e As EventArgs) Handles txtAmount.LostFocus
        txtAmount.Text = FormatMoney(txtAmount.Text)
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.SelectedIndexChanged

    End Sub

    Private Sub cmbCategory_TextChanged(sender As Object, e As EventArgs) Handles cmbCategory.TextChanged
        cmbSize2.Text = cmbCategory.Text
        Call selectCharges()
    End Sub

    Private Sub cmbSize2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSize2.SelectedIndexChanged, cmbSize2.TextChanged
        cmbCategory.Text = cmbSize2.Text
    End Sub

    'Public Sub LoadSizes()
    '    Dim Dbo As New SQLClass
    '    Dbo.SqlCon.Open()
    '    SQL = ""

    'End Sub
End Class