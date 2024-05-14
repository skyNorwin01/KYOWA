Public Class FrmDeliveryOrder
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Public Sub SaveDO(BKNO, BLNO, Consignee, ArrivalManila, MV, MV_Voyage, Regno, MasterBL, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_DELIVERY_ORDER(BKNO, BLNO, Consignee, ArrivalManila, MV, MV_Voyage, Regno, MasterBL, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(BKNO) & "',  '" & KVal(BLNO) & "',  '" & KVal(Consignee) & "',  '" & KVal(ArrivalManila) & "',  '" & KVal(MV) & "',  '" & KVal(MV_Voyage) & "',  '" & KVal(Regno) & "',  '" & KVal(MasterBL) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If MsgBox("Generate Delivery Order?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Call SetJob("UPDATE TBL_DELIVERY_ORDER SET STAT = '0' WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'")
            Call SaveDO(SelBkNo, selBLno, KVal(cmbConsignee.Text), dtArrivalDate.Value, cmbMV.Text, cmbVoyage.Text, cmbRegno.Text, cmbMasterBL.Text, USER_ID, Now, "1")



            MainSysref = FrmBookingList.dtList.CurrentRow.Cells(1).Tag
            MainBkno = FrmBookingList.dtList.CurrentRow.Cells(0).Tag
            Dim Dbo As New SQLClass
            Dim objRep As New crDeliveryOrder

            Dbo.SqlCon.Open()
            SQL = "sp_deliveryOrder;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()



            objRep.SetParameterValue("BKNO", SelBkNo)




            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            'Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "' AND CONTSIZE LIKE '" & cmbVolume.Text & "%'  GROUP BY CONTSIZE  for xml path('') ", "L")
            'If ContSize = NoRecordFound Then
            '    ContSize = ""
            'End If



            With FrmPrintForm
                objRep.SummaryInfo.ReportTitle = UCase(KVal("DELIVERY ORDER"))
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)

                .crViewer.AllowedExportFormats = formats
                '.crViewer.Name = "ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(150)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With


            Me.Dispose()
        End If
    End Sub
End Class