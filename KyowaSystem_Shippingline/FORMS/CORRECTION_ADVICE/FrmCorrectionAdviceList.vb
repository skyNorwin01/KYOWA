Public Class FrmCorrectionAdviceList
    Private Sub FrmCorrectionAdviceList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cmbFilter.Items
            .Clear()
            .Add("REFNO")
            .Add("BLNO")
            .Add("SHIPPER")
            .Add("CONSIGNEE")
            .Add("DESTINATION")
            .Add("CANCELLED")
        End With

        Call LoadList("")
    End Sub

    Public Sub LoadList(str As String)

        '.Add("REFNO")
        '.Add("BLNO")
        '.Add("SHIPPER")
        '.Add("CONSIGNEE")
        '.Add("PORT")


        If cmbFilter.Text = "REFNO" Then
            SQL = "SELECT top 1 c2.ID, C2.DateTrans, C2.BLNO, C2.SizeIs, C2.ContainerNo, C2.Amount, C2.AddedBy, C2.DateAdded, C2.STAT, C2.FromIs, C2.ToIs, C2.ViaIs, C2.IssuedAt, C2.Shipper, C2.Consignee, C2.NotifyParty, C2.FreightPrepaid, C2.FreightCollect, C2.Refno,   (SELECT DISTINCT CONCAT('TOTAL AMOUNT = US$ ',FORMAT(c.Amount,'###,###,##0.00'),'/ ' , c.SizeIs) + 'zzz ' FROM  TBL_CONTAINER_CORR_ADV as c  WHERE c.BLNO =  c2.BLNO FOR XML PATH('')) as AmountIss, c2.FromIs, c2.ToIs, c2.ViaIs, c2.IssuedAt  FROM TBL_CONTAINER_CORR_ADV as c2 WHERE c2.STAT <> '2' AND C2.Refno like '%" & str & "%' ORDER BY C2.SizeIs ASC"
        ElseIf cmbFilter.Text = "BLNO" Then
            SQL = "SELECT top 1 c2.ID, C2.DateTrans, C2.BLNO, C2.SizeIs, C2.ContainerNo, C2.Amount, C2.AddedBy, C2.DateAdded, C2.STAT, C2.FromIs, C2.ToIs, C2.ViaIs, C2.IssuedAt, C2.Shipper, C2.Consignee, C2.NotifyParty, C2.FreightPrepaid, C2.FreightCollect, C2.Refno,   (SELECT DISTINCT CONCAT('TOTAL AMOUNT = US$ ',FORMAT(c.Amount,'###,###,##0.00'),'/ ' , c.SizeIs) + 'zzz ' FROM  TBL_CONTAINER_CORR_ADV as c  WHERE c.BLNO =  c2.BLNO FOR XML PATH('')) as AmountIss, c2.FromIs, c2.ToIs, c2.ViaIs, c2.IssuedAt  FROM TBL_CONTAINER_CORR_ADV as c2 WHERE c2.STAT <> '2' AND c2.BLNO like '%" & str & "%' ORDER BY C2.SizeIs ASC"
        ElseIf cmbFilter.Text = "SHIPPER" Then
            SQL = "SELECT top 1 c2.ID, C2.DateTrans, C2.BLNO, C2.SizeIs, C2.ContainerNo, C2.Amount, C2.AddedBy, C2.DateAdded, C2.STAT, C2.FromIs, C2.ToIs, C2.ViaIs, C2.IssuedAt, C2.Shipper, C2.Consignee, C2.NotifyParty, C2.FreightPrepaid, C2.FreightCollect, C2.Refno,   (SELECT DISTINCT CONCAT('TOTAL AMOUNT = US$ ',FORMAT(c.Amount,'###,###,##0.00'),'/ ' , c.SizeIs) + 'zzz ' FROM  TBL_CONTAINER_CORR_ADV as c  WHERE c.BLNO =  c2.BLNO FOR XML PATH('')) as AmountIss, c2.FromIs, c2.ToIs, c2.ViaIs, c2.IssuedAt  FROM TBL_CONTAINER_CORR_ADV as c2 WHERE c2.STAT <> '2' AND C2.Shipper like '%" & str & "%' ORDER BY C2.SizeIs ASC"
        ElseIf cmbFilter.Text = "CONSIGNEE" Then
            SQL = "SELECT top 1 c2.ID, C2.DateTrans, C2.BLNO, C2.SizeIs, C2.ContainerNo, C2.Amount, C2.AddedBy, C2.DateAdded, C2.STAT, C2.FromIs, C2.ToIs, C2.ViaIs, C2.IssuedAt, C2.Shipper, C2.Consignee, C2.NotifyParty, C2.FreightPrepaid, C2.FreightCollect, C2.Refno,   (SELECT DISTINCT CONCAT('TOTAL AMOUNT = US$ ',FORMAT(c.Amount,'###,###,##0.00'),'/ ' , c.SizeIs) + 'zzz ' FROM  TBL_CONTAINER_CORR_ADV as c  WHERE c.BLNO =  c2.BLNO FOR XML PATH('')) as AmountIss, c2.FromIs, c2.ToIs, c2.ViaIs, c2.IssuedAt  FROM TBL_CONTAINER_CORR_ADV as c2 WHERE c2.STAT <> '2' AND C2.Consignee like '%" & str & "%' ORDER BY C2.SizeIs ASC"
        ElseIf cmbFilter.Text = "DESTINATION" Then
            SQL = "SELECT top 1 c2.ID, C2.DateTrans, C2.BLNO, C2.SizeIs, C2.ContainerNo, C2.Amount, C2.AddedBy, C2.DateAdded, C2.STAT, C2.FromIs, C2.ToIs, C2.ViaIs, C2.IssuedAt, C2.Shipper, C2.Consignee, C2.NotifyParty, C2.FreightPrepaid, C2.FreightCollect, C2.Refno,   (SELECT DISTINCT CONCAT('TOTAL AMOUNT = US$ ',FORMAT(c.Amount,'###,###,##0.00'),'/ ' , c.SizeIs) + 'zzz ' FROM  TBL_CONTAINER_CORR_ADV as c  WHERE c.BLNO =  c2.BLNO FOR XML PATH('')) as AmountIss, c2.FromIs, c2.ToIs, c2.ViaIs, c2.IssuedAt  FROM TBL_CONTAINER_CORR_ADV as c2 WHERE c2.STAT <> '2' AND C2.ToIs like '%" & str & "%' ORDER BY C2.SizeIs ASC"
        ElseIf cmbFilter.Text = "CANCELLED" Then
            SQL = "SELECT top 1 c2.ID, C2.DateTrans, C2.BLNO, C2.SizeIs, C2.ContainerNo, C2.Amount, C2.AddedBy, C2.DateAdded, C2.STAT, C2.FromIs, C2.ToIs, C2.ViaIs, C2.IssuedAt, C2.Shipper, C2.Consignee, C2.NotifyParty, C2.FreightPrepaid, C2.FreightCollect, C2.Refno,   (SELECT DISTINCT CONCAT('TOTAL AMOUNT = US$ ',FORMAT(c.Amount,'###,###,##0.00'),'/ ' , c.SizeIs) + 'zzz ' FROM  TBL_CONTAINER_CORR_ADV as c  WHERE c.BLNO =  c2.BLNO FOR XML PATH('')) as AmountIss, c2.FromIs, c2.ToIs, c2.ViaIs, c2.IssuedAt  FROM TBL_CONTAINER_CORR_ADV as c2 WHERE c2.STAT <> '2' AND C2.stat ='0' ORDER BY C2.SizeIs ASC"
        Else
            SQL = "SELECT top 1 c2.ID, C2.DateTrans, C2.BLNO, C2.SizeIs, C2.ContainerNo, C2.Amount, C2.AddedBy, C2.DateAdded, C2.STAT, C2.FromIs, C2.ToIs, C2.ViaIs, C2.IssuedAt, C2.Shipper, C2.Consignee, C2.NotifyParty, C2.FreightPrepaid, C2.FreightCollect, C2.Refno,   (SELECT DISTINCT CONCAT('TOTAL AMOUNT = US$ ',FORMAT(c.Amount,'###,###,##0.00'),'/ ' , c.SizeIs) + 'zzz ' FROM  TBL_CONTAINER_CORR_ADV as c  WHERE c.BLNO =  c2.BLNO FOR XML PATH('')) as AmountIss, c2.FromIs, c2.ToIs, c2.ViaIs, c2.IssuedAt  FROM TBL_CONTAINER_CORR_ADV as c2 WHERE c2.STAT <> '2' AND BLNO like '%" & str & "%' ORDER BY C2.SizeIs ASC"
        End If


        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()

        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                Dim statIs As String = ""
                If Dbo.reader(8).ToString = "0" Then
                    statIs = "CANCELLED"
                End If
                .Rows.Add(Dbo.reader(1).ToString, Dbo.reader(18).ToString, Dbo.reader(2).ToString, Dbo.reader(13).ToString, Dbo.reader(14).ToString, Dbo.reader(15).ToString, Replace(Dbo.reader(19).ToString, "zzz", "   |   "), statIs, Dbo.reader(20).ToString, Dbo.reader(21).ToString, Dbo.reader(22).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        If MsgBox("Are you sure you want to cancel?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_CONTAINER_CORR_ADV SET STAT = '0' WHERE STAT = '1' AND BLNO = '" & dtList.CurrentRow.Cells(2).Value & "'")
            Call LoadList("")
            Exit Sub
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        With FrmCorrectionAdvice
            .txtRefno.Text = dtList.CurrentRow.Cells(1).Value
            .cmbBlNo.Text = dtList.CurrentRow.Cells(2).Value
            .cmbShipper.Text = dtList.CurrentRow.Cells(3).Value
            .cmbConsignee.Text = dtList.CurrentRow.Cells(4).Value
            .cmbNotifyParty.Text = dtList.CurrentRow.Cells(5).Value
            .cmbFrom.Text = dtList.CurrentRow.Cells(8).Value
            .cmbTo.Text = dtList.CurrentRow.Cells(9).Value
            .cmbVia.Text = dtList.CurrentRow.Cells(10).Value
            LoadForm(FrmCorrectionAdvice, "CORRECTION ADVICE - LIST")
        End With




    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call LoadList(txtValue.Text)
    End Sub
End Class