Public Class FrmATWMenu
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cmbVolume.SelectedIndex = -1 Then
            MsgBox("Invalid volume!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Generate ATW for " & cmbVolume.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            MainSysref = FrmBookingList.dtList.CurrentRow.Cells(1).Tag
            MainBkno = FrmBookingList.dtList.CurrentRow.Cells(0).Tag
            Dim Dbo As New SQLClass
            Dim objRep As New crGenerateNewATW

            Dbo.SqlCon.Open()
            SQL = "sp_GenerateATW;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.SQLCmd.Parameters.AddWithValue("@BKNO", MainBkno)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()

            If objRep.Subreports.Count > 0 Then
                Dim Dbo2 As New SQLClass
                Dbo2.SqlCon.Open()
                SQL = "spGetBookedContainer;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo2.SQLCmd.Parameters.AddWithValue("@CONTSIZE", cmbVolume.Text)
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(0).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()

            End If

            objRep.SetParameterValue("Sysref", MainSysref)
            objRep.SetParameterValue("BKNO", MainBkno)
            objRep.SetParameterValue("Useris", FNAME)



            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "' AND CONTSIZE LIKE '" & cmbVolume.Text & "%'  GROUP BY CONTSIZE  for xml path('') ", "L")
            If ContSize = NoRecordFound Then
                ContSize = ""
            End If



            With FrmPrintForm
                objRep.SummaryInfo.ReportTitle = UCase(KVal("ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort))
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

    Private Sub FrmATWMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadVolumes(SelBkNo, cmbVolume.Text, SelStatIs)

    End Sub

    Public Sub LoadVolumes(bkno As String, ContSize As String, StatIs As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT contsize FROM TBL_CONTAINER_BOOKING WHERE     (Stat <> '2' AND Stat <> '0') AND CONTSIZE LIKE '" & ContSize & "%'  AND BKNO = '" & bkno & "' AND STAT = '" & StatIs & "' GROUP BY CONTSIZE"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With cmbVolume.Items
            .Clear()
            Do While Dbo.reader.Read
                .Add(Dbo.reader(0).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
End Class