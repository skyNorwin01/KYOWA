Public Class frmBLRider


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Call SaveItems(SelSysref, SelBkNo, selBLno, cmbContainerNo.Text, Mid(KVal(txtSeal.Text), 10), txtMnN.Text, txtQty.Text, cmbPackingScheme.Text, cmbDescription.Text, USER_ID, Now, "1", cmbTypeOfPackages.Text, KVal(txtNetWeight.Text))
        Call LoadList(KVal(cmbContainerNo.Text), Mid(KVal(txtSeal.Text), 10))
        Call LoadTypeOfPackages()
        Call LoadDescriptions()
    End Sub

    Public Sub SaveItems(SYSREF, BKNO, BLNO, ContainerNo, SealNo, MnN, qty, PackagingScheme, DescriptionOfGoods, AddedBy, DateAdded, Stat, TypeOfPackages, NetWeight)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_RIDER(SYSREF, BKNO, BLNO, ContainerNo, SealNo, MnN, qty, PackagingScheme, DescriptionOfGoods, AddedBy, DateAdded,  Stat, TypeOfPackages, NetWeight)"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(BKNO) & "',  '" & KVal(BLNO) & "',  '" & KVal(ContainerNo) & "',  '" & KVal(SealNo) & "',  '" & KVal(MnN) & "',  '" & KVal(qty) & "',  '" & KVal(PackagingScheme) & "',  '" & KVal(DescriptionOfGoods) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "' ,  '" & KVal(Stat) & "', '" & KVal(TypeOfPackages) & "', '" & KVal(NetWeight) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadTypeOfPackages()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT DISTINCT TypeOfPackages FROM TBL_RIDER WHERE STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With cmbTypeOfPackages.Items
            .Clear()
            Do While Dbo.reader.Read
                .Add(Dbo.reader(0).ToString)
            Loop
        End With

        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        Dbo.SqlCon.Open()
        SQL = "SELECT DISTINCT PackagingScheme FROM TBL_RIDER WHERE STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With cmbPackingScheme.Items
            .Clear()
            Do While Dbo.reader.Read
                .Add(Dbo.reader(0).ToString)
            Loop
        End With

        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadDescriptions()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT DISTINCT DescriptionOfGoods FROM TBL_RIDER WHERE STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With cmbDescription.Items
            .Clear()
            Do While Dbo.reader.Read
                .Add(Dbo.reader(0).ToString)
            Loop
        End With

        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadList(Cntr As String, SealNo As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT ID, MnN, qty, PackagingScheme, TypeOfPackages, DescriptionOfGoods, NetWeight, ContainerNo, SealNO FROM TBL_RIDER WHERE Containerno = '" & Cntr & "' AND SealNo = '" & SealNo & "' and stat = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(KVal(Dbo.reader(1).ToString), KVal(Dbo.reader(2).ToString), KVal(Dbo.reader(3).ToString), KVal(Dbo.reader(4).ToString), KVal(Dbo.reader(5).ToString), KVal(Dbo.reader(6).ToString), KVal(Dbo.reader(7).ToString), KVal(Dbo.reader(8).ToString))
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(0).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub frmBLRider_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT DISTINCT CONTAINERNO FROM TBL_CONTAINER WHERE STAT = '1' AND BKNO = '" & SelBkNo & "' AND SYSREF = '" & SelSysref & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With cmbContainerNo.Items
            .Clear()
            Do While Dbo.reader.Read
                .Add(Dbo.reader(0).ToString)
            Loop
        End With

        Dbo.reader.Close()
        Dbo.SqlCon.Close()
        Call LoadTypeOfPackages()
        Call LoadDescriptions()
    End Sub

    Public Sub ClearBox()
        txtMnN.Text = ""
        txtQty.Text = ""
        cmbPackingScheme.Text = ""
        cmbTypeOfPackages.Text = ""
        cmbDescription.Text = ""
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call ClearBox()

    End Sub

    Private Sub cmbContainerNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbContainerNo.SelectedIndexChanged

    End Sub

    Private Sub cmbContainerNo_TextChanged(sender As Object, e As EventArgs) Handles cmbContainerNo.TextChanged
        If GetRyzk("SELECT SEALNO FROM TBL_CONTAINER WHERE CONTAINERNO = '" & KVal(cmbContainerNo.Text) & "' AND STAT = '1'", "L") = NoRecordFound Then
            txtSeal.Text = ""
        Else
            txtSeal.Text = "seal_no: " & GetRyzk("SELECT SEALNO FROM TBL_CONTAINER WHERE CONTAINERNO = '" & KVal(cmbContainerNo.Text) & "' AND STAT = '1'", "L")
        End If
        'MsgBox(Mid(KVal(txtSeal.Text), 10))
        Call LoadList(KVal(cmbContainerNo.Text), Mid(KVal(txtSeal.Text), 10))
    End Sub

    Private Sub frmBLRider_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    Private Sub dtList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellClick
        If e.ColumnIndex = 8 Then
            If MsgBox("Delete this item?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_RIDER SET STAT = '0', deletedby = '" & USER_ID & "', DateDeleted = '" & Now & "' WHERE ID = '" & dtList.CurrentRow.Cells(0).Tag & "'")
                dtList.Rows.Remove(dtList.CurrentRow)
                MsgBox("Deleted!", MsgBoxStyle.Information)
            End If

        End If
    End Sub
End Class