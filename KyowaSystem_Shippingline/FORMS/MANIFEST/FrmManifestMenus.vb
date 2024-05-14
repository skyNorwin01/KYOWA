Public Class FrmManifestMenus

    Dim sysrefEapprove As String = ""

    Private Sub chkBlno_CheckedChanged(sender As Object, e As EventArgs) Handles chkBlno.CheckedChanged
        With cmbBlNo
            If chkBlno.Checked = True Then
                .Text = selBLno
                .Enabled = True
                .BackColor = Color.White
            Else
                .Text = ""
                .Enabled = False
                .BackColor = Color.Gainsboro
            End If
        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim RTAG_MNFST_a As String = ""
        Dim RTAG_MNFST_b As String = ""
        'Dim splitMV As String = ""

        'RTAG_MNFST_a = GetRyzk("SELECT   B.BKNO, BL.BLno, BL.Shipper, ShipperAddress, BL.Consignee, ConsigneeAddress, BL.Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel as MV, b.MotherVessel,   B.MVoyage ,   OceanVesselPOL, convert(nvarchar(400),POD) as POD_POD, BL.PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, BL.AddedBy, BL.DateAdded, BL.Stat, O.ViaPort, BL.LocalVessel, BL.LocalVesselPOL, convert(nvarchar(300),MV.VESSELNAME) AS VESSELNAME, CONVERT(NVARCHAR(100),MV.VESSELNAME) as VNAME, 'MAIN' as MAIN_A, isnull((SELECT convert(nvarchar(50), rfp_series) FROM TBL_REQUEST_E_APPROVAL WHERE PARAM1 = 'MANIFEST' AND STAT = '1' AND  REQTOMANAGERAPPROVESTAT = '1' AND rfp_series = B.ManifestEApproveTag),'X') AS RTG_TAG , convert(nvarchar(50),isnull((SELECT convert(nvarchar(50), rfp_series) FROM TBL_REQUEST_E_APPROVAL WHERE PARAM1 = 'MANIFEST' AND STAT = '1' AND  REQTOMANAGERAPPROVESTAT = '1' AND rfp_series = B.ManifestEApproveTag),'X')) AS XRN FROM TBL_BL AS BL LEFT JOIN TBL_BOOKING AS B ON BL.BLNO = B.BLNO AND B.STAT = '1' AND BL.STAT = '1' LEFT JOIN TBL_OPERATIONS AS O ON B.BKNO = O.BKNO AND O.Stat = '1' LEFT JOIN TBL_VESSEL AS MV ON MV.ID = B.MotherVessel WHERE   BL.STAT = '1'   and convert(nvarchar(300),MV.VESSELNAME) = '" & KVal(cmbMVessel.Text) & "' and POD = '" & KVal(cmbPod.Text) & "'  AND B.BLNO LIKE '" & KVal(cmbBlNo.Text) & "%'", "")

        RTAG_MNFST_b = GetRyzk("SELECT rfp_series FROM TBL_REQUEST_E_APPROVAL WHERE BLNO LIKE '" & KVal(cmbMVessel.Text) & "%' AND REFNO = '" & KVal(cmbPod.Text) & "' AND ReqToManagerApproveStat = '1'", "")
        RTAG_MNFST_a = GetRyzk("SELECT ManifestEApproveTag FROM TBL_BOOKING WHERE        (ManifestEApproveTag = '" & RTAG_MNFST_b & "')", "")

        If RTAG_MNFST_a = NoRecordFound Then
            RTAG_MNFST_a = "X"
        End If

        If rdSending.Checked = True And rdWestpac.Checked = True Then
            Dim RateFor = "", FclLcl = "", FormIs = "", PrintOption As String = ""

            If rdPrinting.Checked = True Then
                PrintOption = "P"
            ElseIf rdSending.Checked = True
                PrintOption = "S"
            Else
                PrintOption = "P"
            End If

            If rdPrincipal.Checked = True Then
                RateFor = "PRINCIPAL"
            ElseIf rdDestination.Checked = True Then
                RateFor = "DESTINATION"
            End If

            If rdFcl.Checked = True Then
                FclLcl = "FCL"
            ElseIf rdLcl.Checked = True Then
                FclLcl = "LCL"
            End If

            If rdKyowa.Checked = True Then
                FormIs = "KYOWA"
            ElseIf rdWestpac.Checked = True Then
                FormIs = "WESPAC"
            ElseIf rdFSM.Checked = True Then
                FormIs = "FSM"
            End If

            Dim Dbo As New SQLClass
            Dim objRep As New crManifest_SENDING_KYOWA_BL
            Dbo.SqlCon.Open()
            SQL = "spManifest;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()
            Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)


            Dbo.SqlCon.Close()


            'For i As Integer = 0 To 6
            '    MsgBox(objRep.Subreports(i).Name)
            'Next

            'Exit Sub

            If objRep.Subreports.Count > 0 Then

                'For i = 0 To objRep.Subreports.Count - 1
                '    MsgBox(objRep.Subreports(i).Name)
                'Next


                'Exit Sub



                'crFclRemarks
                'MsgBox(objRep.Subreports(1).Name)
                Dbo.SqlCon.Open()
                SQL = "spFCLRemarks;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crFCLRemarks").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()


                '---------------------
                'CrManifestContainer
                'MsgBox(objRep.Subreports(2).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestContainer;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestContainer").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                '---------------------
                'crRecapitulation
                'MsgBox(objRep.Subreports(6).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRecap;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestRecap").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()




                '---------------------
                'CrRecapVolumes
                'MsgBox(objRep.Subreports(5).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestVolumes;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestVolume").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()





                'MsgBox(objRep.Subreports(3).Name)
                'CrMnN
                Dbo.SqlCon.Open()
                SQL = "spGenerateMnN;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crMnN").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                '---------------------
                'crRates
                'MsgBox(objRep.Subreports(4).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRatesBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crRates").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()


                'ShipperConsignee
                Dbo.SqlCon.Open()
                SQL = "spManifestShipperConsignee;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crShipperConsignee").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()


                '`ERROR HERE
                Dbo.SqlCon.Open()
                SQL = "sp_cr_rates_bl;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@Vessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table2 = New DataTable
                Dbo.adapter.Fill(Dbo.table2)

                objRep.Subreports(7).SetDataSource(Dbo.table2)
                Dbo.SqlCon.Close()


            End If

            objRep.SetDataSource(Dbo.table)
            objRep.SetParameterValue("PrintOption", PrintOption)
            objRep.SetParameterValue("FormIs", FormIs)
            objRep.SetParameterValue("DestinationIs", KVal(cmbPod.Text))
            objRep.SetParameterValue("RateFor", RateFor)
            objRep.SetParameterValue("TypeOfForm", "FSM")

            objRep.SetParameterValue("RTAG_MNFST", RTAG_MNFST_a)

            objRep.SetParameterValue("FclLcl", FclLcl)
            'objRep.SetParameterValue("MVessel", KVal(cmbMVessel.Text))

            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crRates").Name)

            objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports("crFCLRemarks").Name)


            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crManifestRecap").Name)
            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(7).Name)


            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(3).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(4).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(1).Name)

            'objRep.SetParameterValue("VesselIs", "%", objRep.Subreports(6).Name)
            'objRep.SetParameterValue("PodIs", "%", objRep.Subreports(6).Name)


            'objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports(1).Name)



            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(4).Name)
            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(6).Name)


            'objRep.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape

            objRep.SummaryInfo.ReportTitle = KVal(cmbMVessel.Text) & " " & KVal(cmbPod.Text) & " " & KVal(cmbBlNo.Text) & "-MNFST"

            With FrmPrintForm
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)
                '.crViewer.AllowedExportFormats =
                .crViewer.EnableDrillDown = False
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(100)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
            Exit Sub
        End If


        If rdSending.Checked = True And rdKyowa.Checked = True Then

            'MsgBox("Please wait!", MsgBoxStyle.Information)
            'Exit Sub
            'If rdRider.Checked = True Then
            Dim RateFor = "", FclLcl = "", FormIs = "", PrintOption As String = ""

            If rdPrinting.Checked = True Then
                PrintOption = "P"
            ElseIf rdSending.Checked = True
                PrintOption = "S"
            Else
                PrintOption = "P"
            End If

            If rdPrincipal.Checked = True Then
                RateFor = "PRINCIPAL"
            ElseIf rdDestination.Checked = True Then
                RateFor = "DESTINATION"
            End If

            If rdFcl.Checked = True Then
                FclLcl = "FCL"
            ElseIf rdLcl.Checked = True Then
                FclLcl = "LCL"
            End If

            If rdKyowa.Checked = True Then
                FormIs = "KYOWA"
            ElseIf rdWestpac.Checked = True Then
                FormIs = "WESPAC"
            ElseIf rdFSM.Checked = True Then
                FormIs = "FSM"
            End If

            Dim Dbo As New SQLClass
            Dim objRep As New crManifest_SENDING_KYOWA_BL
            Dbo.SqlCon.Open()
            SQL = "spManifest;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()
            Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)


            Dbo.SqlCon.Close()


            'For i As Integer = 0 To 6
            '    MsgBox(objRep.Subreports(i).Name)
            'Next

            'Exit Sub

            If objRep.Subreports.Count > 0 Then

                'For i = 0 To objRep.Subreports.Count - 1
                '    MsgBox(objRep.Subreports(i).Name)
                'Next


                'Exit Sub



                'crFclRemarks
                'MsgBox(objRep.Subreports(1).Name)
                Dbo.SqlCon.Open()
                SQL = "spFCLRemarks;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crFCLRemarks").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()


                '---------------------
                'CrManifestContainer
                'MsgBox(objRep.Subreports(2).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestContainer;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestContainer").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                '---------------------
                'crRecapitulation
                'MsgBox(objRep.Subreports(6).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRecap;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestRecap").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()




                '---------------------
                'CrRecapVolumes
                'MsgBox(objRep.Subreports(5).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestVolumes;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestVolume").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()





                'MsgBox(objRep.Subreports(3).Name)
                'CrMnN
                Dbo.SqlCon.Open()
                SQL = "spGenerateMnN;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crMnN").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                '---------------------
                'crRates
                'MsgBox(objRep.Subreports(4).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRatesBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crRates").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                'ShipperConsignee
                Dbo.SqlCon.Open()
                SQL = "spManifestShipperConsignee;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crShipperConsignee").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                Dbo.SqlCon.Open()
                SQL = "sp_cr_rates_bl;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@Vessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table2 = New DataTable
                Dbo.adapter.Fill(Dbo.table2)

                objRep.Subreports(7).SetDataSource(Dbo.table2)
                Dbo.SqlCon.Close()


            End If

            objRep.SetDataSource(Dbo.table)
            objRep.SetParameterValue("PrintOption", PrintOption)
            objRep.SetParameterValue("FormIs", FormIs)
            objRep.SetParameterValue("DestinationIs", KVal(cmbPod.Text))
            objRep.SetParameterValue("RateFor", RateFor)
            objRep.SetParameterValue("TypeOfForm", "FSM")

            objRep.SetParameterValue("RTAG_MNFST", RTAG_MNFST_a)


            objRep.SetParameterValue("FclLcl", FclLcl)
            'objRep.SetParameterValue("MVessel", KVal(cmbMVessel.Text))

            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crRates").Name)

            objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports("crFCLRemarks").Name)


            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crManifestRecap").Name)
            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(7).Name)



            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(3).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(4).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(1).Name)

            'objRep.SetParameterValue("VesselIs", "%", objRep.Subreports(6).Name)
            'objRep.SetParameterValue("PodIs", "%", objRep.Subreports(6).Name)


            'objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports(1).Name)



            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(4).Name)
            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(6).Name)


            'objRep.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape

            objRep.SummaryInfo.ReportTitle = KVal(cmbMVessel.Text) & " " & KVal(cmbPod.Text) & " " & KVal(cmbBlNo.Text) & "-MNFST"

            With FrmPrintForm
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)
                .crViewer.EnableDrillDown = False
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(100)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
            Exit Sub
        End If


        If rdSending.Checked = True And rdFSM.Checked = True Then

            'MsgBox("Please wait!", MsgBoxStyle.Information)
            'Exit Sub
            'If rdRider.Checked = True Then
            Dim RateFor = "", FclLcl = "", FormIs = "", PrintOption As String = ""

            If rdPrinting.Checked = True Then
                PrintOption = "P"
            ElseIf rdSending.Checked = True
                PrintOption = "S"
            Else
                PrintOption = "P"
            End If

            If rdPrincipal.Checked = True Then
                RateFor = "PRINCIPAL"
            ElseIf rdDestination.Checked = True Then
                RateFor = "DESTINATION"
            End If

            If rdFcl.Checked = True Then
                FclLcl = "FCL"
            ElseIf rdLcl.Checked = True Then
                FclLcl = "LCL"
            End If

            If rdKyowa.Checked = True Then
                FormIs = "KYOWA"
            ElseIf rdWestpac.Checked = True Then
                FormIs = "WESPAC"
            ElseIf rdFSM.Checked = True Then
                FormIs = "FSM"
            End If

            Dim Dbo As New SQLClass
            Dim objRep As New crManifest_SENDING_KYOWA_BL
            Dbo.SqlCon.Open()
            SQL = "spManifest;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()
            Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)


            Dbo.SqlCon.Close()


            'For i As Integer = 0 To 6
            '    MsgBox(objRep.Subreports(i).Name)
            'Next

            'Exit Sub

            If objRep.Subreports.Count > 0 Then

                'For i = 0 To objRep.Subreports.Count - 1
                '    MsgBox(objRep.Subreports(i).Name)
                'Next


                'Exit Sub



                'crFclRemarks
                'MsgBox(objRep.Subreports(1).Name)
                Dbo.SqlCon.Open()
                SQL = "spFCLRemarks;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crFCLRemarks").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()


                '---------------------
                'CrManifestContainer
                'MsgBox(objRep.Subreports(2).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestContainer;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestContainer").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                '---------------------
                'crRecapitulation
                'MsgBox(objRep.Subreports(6).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRecap;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestRecap").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()




                '---------------------
                'CrRecapVolumes
                'MsgBox(objRep.Subreports(5).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestVolumes;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestVolume").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()





                'MsgBox(objRep.Subreports(3).Name)
                'CrMnN
                Dbo.SqlCon.Open()
                SQL = "spGenerateMnN;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crMnN").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                '---------------------
                'crRates
                'MsgBox(objRep.Subreports(4).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRatesBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crRates").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                'ShipperConsignee
                Dbo.SqlCon.Open()
                SQL = "spManifestShipperConsignee;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crShipperConsignee").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                Dbo.SqlCon.Open()
                SQL = "sp_cr_rates_bl;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@Vessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table2 = New DataTable
                Dbo.adapter.Fill(Dbo.table2)

                objRep.Subreports(7).SetDataSource(Dbo.table2)
                Dbo.SqlCon.Close()



            End If

            objRep.SetDataSource(Dbo.table)
            objRep.SetParameterValue("PrintOption", PrintOption)
            objRep.SetParameterValue("FormIs", FormIs)
            objRep.SetParameterValue("DestinationIs", KVal(cmbPod.Text))
            objRep.SetParameterValue("RateFor", RateFor)

            objRep.SetParameterValue("TypeOfForm", "FSM")

            objRep.SetParameterValue("RTAG_MNFST", RTAG_MNFST_a)


            objRep.SetParameterValue("FclLcl", FclLcl)
            'objRep.SetParameterValue("MVessel", KVal(cmbMVessel.Text))

            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crRates").Name)
            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("cr_bl_rates").Name)
            objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports("crFCLRemarks").Name)


            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crManifestRecap").Name)

            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(7).Name)


            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(3).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(4).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(1).Name)

            'objRep.SetParameterValue("VesselIs", "%", objRep.Subreports(6).Name)
            'objRep.SetParameterValue("PodIs", "%", objRep.Subreports(6).Name)


            'objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports(1).Name)



            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(4).Name)
            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(6).Name)


            'objRep.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape

            objRep.SummaryInfo.ReportTitle = KVal(cmbMVessel.Text) & " " & KVal(cmbPod.Text) & " " & KVal(cmbBlNo.Text) & "-MNFST"
            With FrmPrintForm
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)
                .crViewer.EnableDrillDown = False
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(100)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
            Exit Sub
        End If



        If rdWestpac.Checked = True Then



            'MsgBox("Please wait!", MsgBoxStyle.Information)
            'Exit Sub
            'If rdRider.Checked = True Then
            Dim RateFor = "", FclLcl = "", FormIs = "", PrintOption As String = ""

            If rdPrinting.Checked = True Then
                PrintOption = "P"
            ElseIf rdSending.Checked = True
                PrintOption = "S"
            Else
                PrintOption = "P"
            End If

            If rdPrincipal.Checked = True Then
                RateFor = "PRINCIPAL"
            ElseIf rdDestination.Checked = True Then
                RateFor = "DESTINATION"
            End If

            If rdFcl.Checked = True Then
                FclLcl = "FCL"
            ElseIf rdLcl.Checked = True Then
                FclLcl = "LCL"
            End If

            If rdKyowa.Checked = True Then
                FormIs = "KYOWA"
            ElseIf rdWestpac.Checked = True Then
                FormIs = "WESPAC"
            ElseIf rdFSM.Checked = True Then
                FormIs = "FSM"
            End If

            Dim Dbo As New SQLClass
            'Dim objRep As New crManifest_WESPAC
            Dim objRep As New crManifest
            Dbo.SqlCon.Open()
            SQL = "spManifest;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()
            Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)


            Dbo.SqlCon.Close()


            'For i As Integer = 0 To 6
            '    MsgBox(objRep.Subreports(i).Name)
            'Next

            'Exit Sub

            If objRep.Subreports.Count > 0 Then

                'For i = 0 To objRep.Subreports.Count - 1
                '    MsgBox(objRep.Subreports(i).Name)
                'Next


                'Exit Sub



                'crFclRemarks
                'MsgBox(objRep.Subreports(1).Name)
                Dbo.SqlCon.Open()
                SQL = "spFCLRemarks;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crFCLRemarks").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()


                '---------------------
                'CrManifestContainer
                'MsgBox(objRep.Subreports(2).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestContainer;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestContainer").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                '---------------------
                'crRecapitulation
                'MsgBox(objRep.Subreports(6).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRecap;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestRecap").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()




                '---------------------
                'CrRecapVolumes
                'MsgBox(objRep.Subreports(5).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestVolumes;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestVolume").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()





                'MsgBox(objRep.Subreports(3).Name)
                'CrMnN
                Dbo.SqlCon.Open()
                SQL = "spGenerateMnN;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crMnN").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                '---------------------
                'crRates
                'MsgBox(objRep.Subreports(4).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRatesBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crRates").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                'ShipperConsignee
                Dbo.SqlCon.Open()
                SQL = "spManifestShipperConsignee;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crShipperConsignee").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()





            End If

            objRep.SetDataSource(Dbo.table)
            objRep.SetParameterValue("PrintOption", PrintOption)
            objRep.SetParameterValue("FormIs", FormIs)
            objRep.SetParameterValue("DestinationIs", KVal(cmbPod.Text))
            objRep.SetParameterValue("RateFor", RateFor)
            objRep.SetParameterValue("TypeOfForm", "FSM")

            objRep.SetParameterValue("FclLcl", FclLcl)
            'objRep.SetParameterValue("MVessel", KVal(cmbMVessel.Text))

            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crRates").Name)
            objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports("crFCLRemarks").Name)


            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crManifestRecap").Name)



            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(3).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(4).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(1).Name)

            'objRep.SetParameterValue("VesselIs", "%", objRep.Subreports(6).Name)
            'objRep.SetParameterValue("PodIs", "%", objRep.Subreports(6).Name)


            'objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports(1).Name)



            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(4).Name)
            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(6).Name)


            'objRep.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape


            With FrmPrintForm
                .crViewer.EnableDrillDown = False
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(100)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
            Exit Sub
            'End If


        Else

            'MsgBox("Please wait!", MsgBoxStyle.Information)
            'Exit Sub
            'If rdRider.Checked = True Then
            Dim RateFor = "", FclLcl = "", FormIs = "", PrintOption As String = ""

            If rdPrinting.Checked = True Then
                PrintOption = "P"
            ElseIf rdSending.Checked = True
                PrintOption = "S"
            Else
                PrintOption = "P"
            End If

            If rdPrincipal.Checked = True Then
                RateFor = "PRINCIPAL"
            ElseIf rdDestination.Checked = True Then
                RateFor = "DESTINATION"
            End If

            If rdFcl.Checked = True Then
                FclLcl = "FCL"
            ElseIf rdLcl.Checked = True Then
                FclLcl = "LCL"
            End If

            If rdKyowa.Checked = True Then
                FormIs = "KYOWA"
            ElseIf rdWestpac.Checked = True Then
                FormIs = "WESPAC"
            ElseIf rdFSM.Checked = True Then
                FormIs = "FSM"
            End If

            Dim Dbo As New SQLClass
            Dim objRep As New crManifest
            Dbo.SqlCon.Open()
            SQL = "spManifest;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()
            Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
            Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)


            Dbo.SqlCon.Close()


            'For i As Integer = 0 To 6
            '    MsgBox(objRep.Subreports(i).Name)
            'Next

            'Exit Sub

            If objRep.Subreports.Count > 0 Then

                'For i = 0 To objRep.Subreports.Count - 1
                '    MsgBox(objRep.Subreports(i).Name)
                'Next


                'Exit Sub



                'crFclRemarks
                'MsgBox(objRep.Subreports(1).Name)
                Dbo.SqlCon.Open()
                SQL = "spFCLRemarks;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crFCLRemarks").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()


                '---------------------
                'CrManifestContainer
                'MsgBox(objRep.Subreports(2).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestContainer;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestContainer").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                '---------------------
                'crRecapitulation
                'MsgBox(objRep.Subreports(6).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRecap;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestRecap").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()




                '---------------------
                'CrRecapVolumes
                'MsgBox(objRep.Subreports(5).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestVolumes;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crManifestVolume").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()





                'MsgBox(objRep.Subreports(3).Name)
                'CrMnN
                Dbo.SqlCon.Open()
                SQL = "spGenerateMnN;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crMnN").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()



                '---------------------
                'crRates
                'MsgBox(objRep.Subreports(4).Name)
                Dbo.SqlCon.Open()
                SQL = "spManifestRatesBL;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()

                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crRates").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()

                'ShipperConsignee
                Dbo.SqlCon.Open()
                SQL = "spManifestShipperConsignee;1"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
                Dbo.SQLCmd.Parameters.Clear()
                Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.SQLCmd.Parameters.AddWithValue("@BLNO", KVal(cmbBlNo.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
                'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
                Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
                Dbo.table = New DataTable
                Dbo.adapter.Fill(Dbo.table)

                objRep.Subreports("crShipperConsignee").SetDataSource(Dbo.table)
                Dbo.SqlCon.Close()





            End If

            objRep.SetDataSource(Dbo.table)
            objRep.SetParameterValue("PrintOption", PrintOption)
            objRep.SetParameterValue("FormIs", FormIs)
            objRep.SetParameterValue("DestinationIs", KVal(cmbPod.Text))
            objRep.SetParameterValue("RateFor", RateFor)
            objRep.SetParameterValue("TypeOfForm", "FSM")

            If rdSending.Checked = True Then
                objRep.SetParameterValue("RTAG_MNFST", RTAG_MNFST_a)
            End If


            objRep.SetParameterValue("FclLcl", FclLcl)
            'objRep.SetParameterValue("MVessel", KVal(cmbMVessel.Text))

            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crRates").Name)
            objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports("crFCLRemarks").Name)


            objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports("crManifestRecap").Name)



            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(3).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(4).Name)
            'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(1).Name)

            'objRep.SetParameterValue("VesselIs", "%", objRep.Subreports(6).Name)
            'objRep.SetParameterValue("PodIs", "%", objRep.Subreports(6).Name)


            'objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports(1).Name)



            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(4).Name)
            'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(6).Name)


            'objRep.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape


            With FrmPrintForm
                .crViewer.EnableDrillDown = False
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(100)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
            Exit Sub
            'End If
        End If





        '--------------------------------------------------------------------------------------------------




        ''MsgBox("Please wait!", MsgBoxStyle.Information)
        ''Exit Sub
        ''If rdRider.Checked = True Then
        'Dim RateFor = "", FclLcl = "", FormIs As String = ""
        'If rdPrincipal.Checked = True Then
        '    RateFor = "PRINCIPAL"
        'ElseIf rdDestination.Checked = True Then
        '    RateFor = "DESTINATION"
        'End If

        'If rdFcl.Checked = True Then
        '    FclLcl = "FCL"
        'ElseIf rdLcl.Checked = True Then
        '    FclLcl = "LCL"
        'End If

        'If rdKyowa.Checked = True Then
        '    FormIs = "KYOWA"
        'ElseIf rdWestpac.Checked = True Then
        '    FormIs = "WESPAC"
        'ElseIf rdFSM.Checked = True Then
        '    FormIs = "FSM"
        'End If

        'Dim Dbo As New SQLClass
        'Dim objRep As New crManifest
        'Dbo.SqlCon.Open()
        'SQL = "spManifest;1"
        'Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        'Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        'Dbo.SQLCmd.Parameters.Clear()
        ''Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
        ''Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
        'Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        'Dbo.table = New DataTable
        'Dbo.adapter.Fill(Dbo.table)


        'Dbo.SqlCon.Close()


        ''For i As Integer = 0 To 6
        ''    MsgBox(objRep.Subreports(i).Name)
        ''Next

        ''Exit Sub

        'If objRep.Subreports.Count > 0 Then
        '    'MsgBox(objRep.Subreports(0).Name)
        '    'ShipperConsignee
        '    Dbo.SqlCon.Open()
        '    SQL = "spManifestShipperConsignee;1"
        '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        '    Dbo.SQLCmd.Parameters.Clear()
        '    'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
        '    'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
        '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        '    Dbo.table = New DataTable
        '    Dbo.adapter.Fill(Dbo.table)

        '    objRep.Subreports(0).SetDataSource(Dbo.table)
        '    Dbo.SqlCon.Close()

        '    '---------------------
        '    'MsgBox(objRep.Subreports(3).Name)
        '    'CrMnN
        '    Dbo.SqlCon.Open()
        '    SQL = "spGenerateMnN;1"
        '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        '    Dbo.SQLCmd.Parameters.Clear()

        '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        '    Dbo.table = New DataTable
        '    Dbo.adapter.Fill(Dbo.table)

        '    objRep.Subreports(3).SetDataSource(Dbo.table)
        '    Dbo.SqlCon.Close()


        '    '---------------------
        '    'crRates
        '    'MsgBox(objRep.Subreports(4).Name)
        '    Dbo.SqlCon.Open()
        '    SQL = "spManifestRatesBL;1"
        '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        '    Dbo.SQLCmd.Parameters.Clear()

        '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        '    Dbo.table = New DataTable
        '    Dbo.adapter.Fill(Dbo.table)

        '    objRep.Subreports(4).SetDataSource(Dbo.table)
        '    Dbo.SqlCon.Close()


        '    '---------------------
        '    'crFclRemarks
        '    'MsgBox(objRep.Subreports(1).Name)
        '    Dbo.SqlCon.Open()
        '    SQL = "spFCLRemarks;1"
        '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        '    Dbo.SQLCmd.Parameters.Clear()
        '    'Dbo.SQLCmd.Parameters.AddWithValue("@POD", KVal(cmbPod.Text))
        '    'Dbo.SQLCmd.Parameters.AddWithValue("@MVessel", KVal(cmbMVessel.Text))
        '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        '    Dbo.table = New DataTable
        '    Dbo.adapter.Fill(Dbo.table)

        '    objRep.Subreports(1).SetDataSource(Dbo.table)
        '    Dbo.SqlCon.Close()



        '    '---------------------
        '    'CrManifestContainer
        '    'MsgBox(objRep.Subreports(2).Name)
        '    Dbo.SqlCon.Open()
        '    SQL = "spManifestContainer;1"
        '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        '    Dbo.SQLCmd.Parameters.Clear()

        '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        '    Dbo.table = New DataTable
        '    Dbo.adapter.Fill(Dbo.table)

        '    objRep.Subreports(2).SetDataSource(Dbo.table)
        '    Dbo.SqlCon.Close()



        '    '---------------------
        '    'crRecapitulation
        '    'MsgBox(objRep.Subreports(6).Name)
        '    Dbo.SqlCon.Open()
        '    SQL = "spManifestRecap;1"
        '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        '    Dbo.SQLCmd.Parameters.Clear()

        '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        '    Dbo.table = New DataTable
        '    Dbo.adapter.Fill(Dbo.table)

        '    objRep.Subreports(6).SetDataSource(Dbo.table)
        '    Dbo.SqlCon.Close()



        '    '---------------------
        '    'CrRecapVolumes
        '    'MsgBox(objRep.Subreports(5).Name)
        '    Dbo.SqlCon.Open()
        '    SQL = "spManifestVolumes;1"
        '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '    Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
        '    Dbo.SQLCmd.Parameters.Clear()

        '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        '    Dbo.table = New DataTable
        '    Dbo.adapter.Fill(Dbo.table)

        '    objRep.Subreports(5).SetDataSource(Dbo.table)
        '    Dbo.SqlCon.Close()



        'End If

        'objRep.SetDataSource(Dbo.table)
        'objRep.SetParameterValue("FormIs", FormIs)
        'objRep.SetParameterValue("DestinationIs", KVal(cmbPod.Text))
        ''objRep.SetParameterValue("BLNO", KVal(cmbBlNo.Text))
        ''objRep.SetParameterValue("MVessel", KVal(cmbMVessel.Text))
        'objRep.SetParameterValue("RateFor", RateFor)
        'objRep.SetParameterValue("TypeOfForm", "FSM")

        'objRep.SetParameterValue("FclLcl", FclLcl)




        ''objRep.SetParameterValue("Pm-spManifestMain;1.BLno", "MNL-0000004", objRep.Subreports(0).Name)
        'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(3).Name)
        'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(4).Name)
        'objRep.SetParameterValue("Pm-spManifest;1.BLno", "MNL-0000004", objRep.Subreports(1).Name)

        'objRep.SetParameterValue("VesselIs", "%", objRep.Subreports(6).Name)
        'objRep.SetParameterValue("PodIs", "%", objRep.Subreports(6).Name)


        'objRep.SetParameterValue("FclLcl", FclLcl, objRep.Subreports(1).Name)

        ''objRep.SetParameterValue("BLNO", selBLno)
        ''objRep.SetParameterValue("HASRATES", HasRates)
        ''objRep.SetParameterValue("BLNO", KVal(cmbBlNo.Text), objRep.Subreports(3).Name)
        ''objRep.SetParameterValue("BLNO", KVal(cmbBlNo.Text), objRep.Subreports(4).Name)

        'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(4).Name)
        'objRep.SetParameterValue("RateFor", RateFor, objRep.Subreports(6).Name)

        ''objRep.SetParameterValue("BLNO", selBLno, objRep.Subreports(2).Name)


        ''objRep.SetParameterValue("BKNO", SelBkNo, objRep.Subreports(1).Name)
        ''objRep.SetParameterValue("BLNO", selBLno, objRep.Subreports(2).Name)

        'objRep.SetParameterValue("MVessel", KVal(cmbMVessel.Text))

        'With FrmPrintForm
        '    .crViewer.ReportSource = objRep
        '    .crViewer.Refresh()
        '    .crViewer.ShowPrintButton = True
        '    .crViewer.Zoom(150)
        '    .WindowState = FormWindowState.Maximized
        '    .ShowDialog()
        'End With
        'Exit Sub
        ''End If
    End Sub

    Private Sub FrmManifestMenus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkBlno.Checked = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub chkEapproval_CheckedChanged(sender As Object, e As EventArgs) Handles chkEapproval.CheckedChanged

        If chkEapproval.Checked = True Then
            txtEAppSys.Enabled = True
            sysrefEapprove = "MNFST" & Format(Now, "yyMMddhhmmssff")
            txtEAppSys.Text = sysrefEapprove
            PrintModeIs = "MANIFEST"
            PrintActionMode = "NEW"

        Else
            txtEAppSys.Enabled = False
            txtEAppSys.Text = ""
            PrintModeIs = ""
            PrintActionMode = ""
        End If
    End Sub
End Class