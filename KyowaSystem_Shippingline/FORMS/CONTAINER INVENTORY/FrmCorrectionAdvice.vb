Public Class FrmCorrectionAdvice
    Dim eXISTINGca As String = ""
    Private Sub FrmCorrectionAdvice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DOUBLE_CHECK_NEXT_UPDATE_TOMORROW_PANG_DAG_DAG
        Call LoadStrCmb(cmbCurrrency, "SELECT ID , CURR FROM TBL_CURRENCY WHERE STAT = '1' ORDER BY   CURR ASC")
        With dtList
            .Rows.Clear()

            If GetRyzk("SELECT SIZEIS, ContainerNo, Amount FROM TBL_CONTAINER_CORR_ADV WHERE BLNO = '" & KVal(cmbBlNo.Text) & "' AND STAT = '1' ", "") = NoRecordFound Then
                eXISTINGca = "N"
                Dim Dbo As New SQLClass
                Dbo.SqlCon.Open()
                SQL = "SELECT C.SizeIs , C.CONTAINERNO FROM TBL_CONTAINER AS C LEFT JOIN TBL_BOOKING AS B ON B.BKNO = C.BKNO WHERE (C.STAT  = '1' OR C.STAT <> '2') AND B.BLNO = '" & KVal(cmbBlNo.Text) & "' AND B.STAT = '" & (FrmBookingList.dtList.CurrentRow.Cells(2).Tag & "'")
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.reader = Dbo.SQLCmd.ExecuteReader
                Do While Dbo.reader.Read
                    .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString)
                Loop
                Dbo.reader.Close()
                Dbo.SqlCon.Close()
            Else
                eXISTINGca = "Y"
                Dim Dbo As New SQLClass
                Dbo.SqlCon.Open()
                SQL = "SELECT SIZEIS, ContainerNo, Amount, currency FROM TBL_CONTAINER_CORR_ADV WHERE BLNO = '" & KVal(cmbBlNo.Text) & "' AND STAT = '1' "
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.reader = Dbo.SQLCmd.ExecuteReader
                Do While Dbo.reader.Read
                    cmbCurrrency.Text = Dbo.reader(3).ToString
                    .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString)
                Loop
                Dbo.reader.Close()
                Dbo.SqlCon.Close()
            End If
        End With
    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    Private Sub dtList_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellLeave

    End Sub

    Private Sub dtList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellEndEdit
        If e.ColumnIndex = 2 Then
            If Not IsNumeric(dtList.CurrentRow.Cells(2).Value) Then
                dtList.CurrentRow.Cells(2).Value = "0.00"
                Exit Sub
            End If
            dtList.CurrentRow.Cells(2).Value = FormatMoneyN(dtList.CurrentRow.Cells(2).Value)
        End If
    End Sub

    Private Sub btnSaveCs_Click(sender As Object, e As EventArgs) Handles btnSaveCs.Click

        If cmbCurrrency.SelectedIndex = -1 Then
            MsgBox("Invalid currency!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        If MsgBox("Are you sure you want to save this C/A?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Call SetJob("UPDATE TBL_CONTAINER_CORR_ADV SET STAT = '0' WHERE STAT = '1' AND BLNO = '" & selBLno & "'")

            For i As Integer = 0 To dtList.RowCount - 1
                Call SaveCA(dtDate.Value, cmbBlNo.Text, dtList.Rows(i).Cells(0).Value, dtList.Rows(i).Cells(1).Value, SaveMoney(dtList.Rows(i).Cells(2).Value), USER_ID, Now, "1", cmbFrom.Text, cmbTo.Text, cmbVia.Text, cmbIssuedAt.Text, cmbShipper.Text, cmbConsignee.Text, cmbNotifyParty.Text, cmbPrepaid.Text, cmbCollect.Text, txtRefno.Text, cmbCurrrency.Text)
            Next

            If eXISTINGca = "N" Then
                Dim CurSeries As Integer = 0

                CurSeries = GetRyzk("SELECT  SERIES  FROM TBL_REFERENCE WHERE PARAM3 = 'CORR_ADV'", "")

                Call SetJob("UPDATE TBL_REFERENCE SET SERIES  = '" & CurSeries + 1 & "'  WHERE PARAM3 = 'CORR_ADV'")
            End If


            MsgBox("Successfully saved!", MsgBoxStyle.Information)
            Me.Dispose()
        End If
    End Sub

    Public Sub SaveCA(DateTrans, BLNO, SizeIs, ContainerNo, Amount, AddedBy, DateAdded, STAT, FromIs, ToIs, ViaIs, IssuedAt, Shipper, Consignee, NotifyParty, FreightPrepaid, FreightCollect, Refno, currency)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CONTAINER_CORR_ADV(DateTrans, BLNO, SizeIs, ContainerNo, Amount, AddedBy, DateAdded, STAT,FromIs, ToIs, ViaIs, IssuedAt, Shipper, Consignee, NotifyParty, FreightPrepaid, FreightCollect, Refno, currency)"
        SQL = SQL + "VALUES('" & DateTrans & "', '" & KVal(BLNO) & "',  '" & KVal(SizeIs) & "',  '" & KVal(ContainerNo) & "',  '" & KVal(Amount) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(STAT) & "','" & KVal(FromIs) & "',  '" & KVal(ToIs) & "',  '" & KVal(ViaIs) & "',  '" & KVal(IssuedAt) & "',  '" & KVal(Shipper) & "',  '" & KVal(Consignee) & "',  '" & KVal(NotifyParty) & "',  '" & KVal(FreightPrepaid) & "',  '" & KVal(FreightCollect) & "',  '" & KVal(Refno) & "', '" & KVal(currency) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
End Class