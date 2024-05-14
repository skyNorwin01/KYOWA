Public Class FrmGenerateBlMenus


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim AddTag As String = ""



        If FrmBookingList.CorrectionNoticeRevised = "CNR-" Then
            AddTag = "CNR-"
        End If

        If rdRider.Checked = True Then

            Dim Dbo As New SQLClass
            Dim objRep As New crKyowaBlRider
            Dbo.SqlCon.Open()
            SQL = "sp_generateRider;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            objRep.SetParameterValue("BLNO", AddTag & selBLno)
            Dbo.SqlCon.Close()



            'objRep.SetParameterValue("BKNO", SelBkNo, objRep.Subreports(1).Name)
            'objRep.SetParameterValue("BLNO", selBLno, objRep.Subreports(2).Name)

            With FrmPrintForm
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(150)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
            Exit Sub
        End If


        If getCountOfCharges(AddTag & selBLno) > 6 Then

            If MsgBox("Generate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                MainSysref = SelSysref
                MainBkno = SelBkNo
                Dim HasRates As String = ""

                If rdPrincipal.Checked Then
                    HasRates = "Y"
                ElseIf rdDestination.Checked Then
                    HasRates = "N"
                ElseIf rdBilling.Checked Then
                    HasRates = "Y"
                ElseIf rdUnfreighted.Checked Then
                    HasRates = "N"
                End If

                Dim Dbo As New SQLClass
                Dim objRep = Nothing

                If rdWesPac.Checked And rdNONNego.Checked Then
                    objRep = New CrWespacNonNegoBL
                ElseIf rdWesPac.Checked And rdOBL.Checked Then
                    objRep = New CrWespacOBL
                Else
                    objRep = New CrKyowaBL_LC
                End If



                Dbo.SqlCon.Open()
                SQL = "spGenerateBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dim parPort As String = ""
                If rdCyCy.Checked = True Then
                    parPort = rdCyCy.Text
                ElseIf rdCfsCfs.Checked = True Then
                    parPort = rdCfsCfs.Text
                ElseIf rdCyCfs.Checked = True Then
                    parPort = "CFS - CFS - CFS"
                End If
                Dbo.SQLCmd.Parameters.AddWithValue("@paramPORT", KVal(parPort))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                If objRep.Subreports.Count > 0 Then
                    Dbo.SqlCon.Open()
                    SQL = "spGenerateMarksNosBL;1"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                    Dbo.SQLCmd.Parameters.Clear()

                    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                    Dbo.table = New DataTable
                    Dbo.adapter.Fill(Dbo.table)

                    objRep.Subreports(0).SetDataSource(Dbo.table)
                    Dbo.SqlCon.Close()




                    '---------------------
                    Dbo.SqlCon.Open()
                    SQL = "spGenerateContainerB;1"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                    Dbo.SQLCmd.Parameters.Clear()

                    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                    Dbo.table = New DataTable
                    Dbo.adapter.Fill(Dbo.table)

                    objRep.Subreports(1).SetDataSource(Dbo.table)
                    Dbo.SqlCon.Close()

                    '---------------------
                    Dbo.SqlCon.Open()
                    SQL = "spGenerateRatesBL;1"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                    Dbo.SQLCmd.Parameters.Clear()

                    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                    Dbo.table = New DataTable
                    Dbo.adapter.Fill(Dbo.table)

                    objRep.Subreports(2).SetDataSource(Dbo.table)
                    Dbo.SqlCon.Close()



                End If

                objRep.SetParameterValue("BLNO", AddTag & selBLno)
                objRep.SetParameterValue("HASRATES", HasRates)

                objRep.SetParameterValue("BLNO", AddTag & selBLno, objRep.Subreports(0).Name)
                objRep.SetParameterValue("BKNO", AddTag & SelBkNo, objRep.Subreports(1).Name)
                objRep.SetParameterValue("BLNO", AddTag & selBLno, objRep.Subreports(2).Name)

                'KYOWA OLD 
                If rdSending.Checked Then
                    objRep.SetParameterValue("PrintingOrSending", "SENDING")
                ElseIf rdPrinting.Checked Then
                    objRep.SetParameterValue("PrintingOrSending", "PRINTING")
                End If

                'If rdNONNego.Checked Then
                '    objRep.SetParameterValue("NegoOrNonNego", "NON-NEGO")
                'ElseIf rdOBL.Checked Then
                '    objRep.SetParameterValue("NegoOrNonNego", "OBL")
                'End If
                If rdNONNego.Checked Then
                    objRep.SetParameterValue("NEG", "NON-NEGO")
                ElseIf rdOBL.Checked Then
                    objRep.SetParameterValue("NEG", "OBL")
                End If




                If rdKyowaOld.Checked Then
                    objRep.SetParameterValue("FORM", "Kyowa (OLD)")
                ElseIf rdKyowaNew.Checked Then
                    objRep.SetParameterValue("FORM", "Kyowa (NEW)")
                ElseIf rdWesPac.Checked Then
                    objRep.SetParameterValue("FORM", "WesPac")
                ElseIf rdFSM.Checked Then
                    objRep.SetParameterValue("FORM", "FSM")
                End If





                If rdPrincipal.Checked Then
                    objRep.SetParameterValue("RatesFor", rdPrincipal.Text, objRep.Subreports(2).Name)
                ElseIf rdDestination.Checked Then
                    objRep.SetParameterValue("RatesFor", rdDestination.Text, objRep.Subreports(2).Name)
                ElseIf rdBilling.Checked Then
                    objRep.SetParameterValue("RatesFor", rdBilling.Text, objRep.Subreports(2).Name)
                ElseIf rdUnfreighted.Checked Then
                    objRep.SetParameterValue("RatesFor", rdUnfreighted.Text, objRep.Subreports(2).Name)
                End If


                If rdPrincipal.Checked Then
                    objRep.SetParameterValue("RatesFor", rdPrincipal.Text)
                ElseIf rdDestination.Checked Then
                    objRep.SetParameterValue("RatesFor", rdDestination.Text)
                ElseIf rdBilling.Checked Then
                    objRep.SetParameterValue("RatesFor", rdBilling.Text)
                ElseIf rdUnfreighted.Checked Then
                    objRep.SetParameterValue("RatesFor", rdUnfreighted.Text)
                End If
                'For i As Integer = 0 To 20
                '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
                'Next
                'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
                'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
                'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)



                With FrmPrintForm
                    .crViewer.ReportSource = objRep
                    .crViewer.Refresh()
                    .crViewer.ShowPrintButton = True
                    .crViewer.Zoom(150)
                    .WindowState = FormWindowState.Maximized
                    .ShowDialog()
                End With

            End If

            Exit Sub
        End If

        If MsgBox("Generate?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MainSysref = SelSysref
            MainBkno = SelBkNo
            Dim HasRates As String = ""

            If rdPrincipal.Checked Then
                HasRates = "Y"
            ElseIf rdDestination.Checked Then
                HasRates = "N"
            ElseIf rdBilling.Checked Then
                HasRates = "Y"
            ElseIf rdUnfreighted.Checked Then
                HasRates = "N"
            End If

            Dim Dbo As New SQLClass
            Dim objRep = Nothing

            If rdWesPac.Checked And rdNONNego.Checked Then
                objRep = New CrWespacNonNegoBL
            ElseIf rdWesPac.Checked And rdOBL.Checked Then
                objRep = New CrWespacOBL
            Else
                objRep = New CrKyowaBL_LC
            End If



            Dbo.SqlCon.Open()
            SQL = "spGenerateBL;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()
            Dim parPort As String = ""
            If rdCyCy.Checked = True Then
                parPort = rdCyCy.Text
            ElseIf rdCfsCfs.Checked = True Then
                parPort = rdCfsCfs.Text
            ElseIf rdCyCfs.Checked = True Then
                parPort = "CFS - CFS - CFS"
            End If
            Dbo.SQLCmd.Parameters.AddWithValue("@paramPORT", KVal(parPort))
            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()



            If objRep.Subreports.Count > 0 Then
                Dbo.SqlCon.Open()
                SQL = "spGenerateMarksNosBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports(0).SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()




                '---------------------
                Dbo.SqlCon.Open()
                SQL = "spGenerateContainerB;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports(1).SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                '---------------------
                Dbo.SqlCon.Open()
                SQL = "spGenerateRatesBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports(2).SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



            End If

            objRep.SetParameterValue("BLNO", AddTag & selBLno)
            objRep.SetParameterValue("HASRATES", HasRates)

            objRep.SetParameterValue("BLNO", AddTag & selBLno, objRep.Subreports(0).Name)
            objRep.SetParameterValue("BKNO", AddTag & SelBkNo, objRep.Subreports(1).Name)
            objRep.SetParameterValue("BLNO", AddTag & selBLno, objRep.Subreports(2).Name)

            'KYOWA OLD 
            If rdSending.Checked Then
                objRep.SetParameterValue("PrintingOrSending", "SENDING")
            ElseIf rdPrinting.Checked Then
                objRep.SetParameterValue("PrintingOrSending", "PRINTING")
            End If

            'If rdNONNego.Checked Then
            '    objRep.SetParameterValue("NegoOrNonNego", "NON-NEGO")
            'ElseIf rdOBL.Checked Then
            '    objRep.SetParameterValue("NegoOrNonNego", "OBL")
            'End If
            If rdNONNego.Checked Then
                objRep.SetParameterValue("NEG", "NON-NEGO")
            ElseIf rdOBL.Checked Then
                objRep.SetParameterValue("NEG", "OBL")
            End If




            If rdKyowaOld.Checked Then
                objRep.SetParameterValue("FORM", "Kyowa (OLD)")
            ElseIf rdKyowaNew.Checked Then
                objRep.SetParameterValue("FORM", "Kyowa (NEW)")
            ElseIf rdWesPac.Checked Then
                objRep.SetParameterValue("FORM", "WesPac")
            ElseIf rdFSM.Checked Then
                objRep.SetParameterValue("FORM", "FSM")
            End If





            If rdPrincipal.Checked Then
                objRep.SetParameterValue("RatesFor", rdPrincipal.Text, objRep.Subreports(2).Name)
            ElseIf rdDestination.Checked Then
                objRep.SetParameterValue("RatesFor", rdDestination.Text, objRep.Subreports(2).Name)
            ElseIf rdBilling.Checked Then
                objRep.SetParameterValue("RatesFor", rdBilling.Text, objRep.Subreports(2).Name)
            ElseIf rdUnfreighted.Checked Then
                objRep.SetParameterValue("RatesFor", rdUnfreighted.Text, objRep.Subreports(2).Name)
            End If

            If rdPrincipal.Checked Then
                objRep.SetParameterValue("RatesFor", rdPrincipal.Text)
            ElseIf rdDestination.Checked Then
                objRep.SetParameterValue("RatesFor", rdDestination.Text)
            ElseIf rdBilling.Checked Then
                objRep.SetParameterValue("RatesFor", rdBilling.Text)
            ElseIf rdUnfreighted.Checked Then
                objRep.SetParameterValue("RatesFor", rdUnfreighted.Text)
            End If

            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)



            With FrmPrintForm
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(150)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        End If
    End Sub



    Private Sub FrmGenerateBlMenus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class