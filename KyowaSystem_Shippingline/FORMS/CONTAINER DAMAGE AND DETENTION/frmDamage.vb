Public Class frmDamage
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Dispose()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub
    Public Sub LoadList()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT DescIs, ManHour, LaborCost, MaterialCost FROM TBL_DAMAGE where stat = '1' and sysref = '" & SelSysref & "' and refno = '" & SelRefno & "' and blno = '" & selBLno & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, SaveMoney(Dbo.reader(1).ToString), SaveMoney(Dbo.reader(2).ToString), SaveMoney(Dbo.reader(3).ToString))
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ALWAYS MULTIPY TO 180
        If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SaveProc(SelSysref, SelBkNo, SelRefno, selBLno, txtContainerNO.Text, cmbTypeSize.Text, cmbLine.Text, txtEIR.Text, dtDateIn.Value, KValNCase(cmbDesc.Text), SaveMoney(txtManHour.Text), SaveMoney(txtLaborCost.Text), SaveMoney(txtMaterialCost.Text), USER_ID, Now, "1")
            Call LoadList()
        End If
    End Sub

    Public Sub SaveProc(SYSREF, bkNo, refno, blno, containerNo, sizeIs, Line, eir, dateIn, DescIs, ManHour, LaborCost, MaterialCost, addedBy, dateAdded, stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_DAMAGE(SYSREF, bkNo, refno, blno, containerNo, sizeIs, Line, eir, dateIn, DescIs, ManHour, LaborCost, MaterialCost, addedBy, dateAdded, stat)"
        SQL = SQL + "VALUES(@SYSREF,@bkNo,@refno,@blno,@containerNo,@sizeIs,@Line,@eir,@dateIn,@DescIs,@ManHour,@LaborCost,@MaterialCost,@addedBy,@dateAdded,@stat)"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.Parameters.Add("@SYSREF", SqlDbType.VarChar).Value = KVal(SYSREF)
        Dbo.SQLCmd.Parameters.Add("@bkNo", SqlDbType.VarChar).Value = KVal(bkNo)
        Dbo.SQLCmd.Parameters.Add("@refno", SqlDbType.VarChar).Value = KVal(refno)
        Dbo.SQLCmd.Parameters.Add("@blno", SqlDbType.VarChar).Value = KVal(blno)
        Dbo.SQLCmd.Parameters.Add("@containerNo", SqlDbType.VarChar).Value = KVal(containerNo)
        Dbo.SQLCmd.Parameters.Add("@sizeIs", SqlDbType.VarChar).Value = KVal(sizeIs)
        Dbo.SQLCmd.Parameters.Add("@Line", SqlDbType.VarChar).Value = KVal(Line)
        Dbo.SQLCmd.Parameters.Add("@eir", SqlDbType.VarChar).Value = KVal(eir)
        Dbo.SQLCmd.Parameters.Add("@dateIn", SqlDbType.VarChar).Value = KVal(dateIn)
        Dbo.SQLCmd.Parameters.Add("@DescIs", SqlDbType.VarChar).Value = KVal(DescIs)
        Dbo.SQLCmd.Parameters.Add("@ManHour", SqlDbType.VarChar).Value = KVal(ManHour)
        Dbo.SQLCmd.Parameters.Add("@LaborCost", SqlDbType.VarChar).Value = KVal(LaborCost)
        Dbo.SQLCmd.Parameters.Add("@MaterialCost", SqlDbType.VarChar).Value = KVal(MaterialCost)
        Dbo.SQLCmd.Parameters.Add("@addedBy", SqlDbType.VarChar).Value = KVal(addedBy)
        Dbo.SQLCmd.Parameters.Add("@dateAdded", SqlDbType.VarChar).Value = KVal(dateAdded)
        Dbo.SQLCmd.Parameters.Add("@stat", SqlDbType.VarChar).Value = KVal(stat)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub frmDamage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class


