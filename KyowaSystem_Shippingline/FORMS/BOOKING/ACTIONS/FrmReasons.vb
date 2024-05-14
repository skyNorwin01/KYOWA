Public Class FrmReasons
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub FrmReasons_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadStrCmb(cmbReasons, "SELECT ID, PARTICULAR  FROM TBL_REASONS WHERE STAT = '1' AND PARAM1 = '" & FrmBookingList.ActionMode & "' ORDER BY PARTICULAR ASC")
        'If FrmBookingList.ActionMode = "REBOOK" Then
        '    cmbReasons.Text = "REBOOK"
        'End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If FrmBookingList.ActionMode = "REBOOK" Then
            Call FrmInitialBooking.LoadAll()
            Call FrmInitialBooking.LoadOperationsCmb()

            With FrmBookingList
                LandingForm.Modeis = "REBOOK"

                MainSysref = .dtList.CurrentRow.Cells(1).Tag
                MainBkno = .dtList.CurrentRow.Cells(0).Tag

                With FrmInitialBooking
                    Call .LoadAll()
                    Call .LoadOperationsCmb()
                    .lblSysref.Text = MainSysref
                    .txtBKNO.Text = MainBkno


                    Dim Dbo As New SQLClass
                    Dbo.SqlCon.Open()
                    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> N'0') AND (TBL_BOOKING.Stat <> N'2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "')"
                    If FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                        'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.ClientName, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON convert(nvarchar(50),TBL_BOOKING.Shipper) = convert(nvarchar(50),Shipper.ClientName) LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),TBL_BOOKING.Consignee) = convert(nvarchar(50),Consignee.cardcode) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE  (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
                        SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

                    Else
                        SQL = "SELECT    TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, CONSIGNEE.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON  Shipper.id = TBL_BOOKING.Shipper LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),Consignee.cardcode) = convert(nvarchar(50),TBL_BOOKING.Consignee) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2')  AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

                    End If


                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.reader = Dbo.SQLCmd.ExecuteReader
                    Dim SHIPPER As String = ""
                    Do While Dbo.reader.Read
                        .txtBKNO.Text = Dbo.reader(1).ToString
                        .dtDate.Value = dtRebook.Value
                        .cmbOutPort.Text = Dbo.reader(3).ToString
                        If Dbo.reader(3).ToString = "MANILA_ONLY" Then
                            .txtOutportId.Text = "00001"
                        End If
                        'SHIPPER = Dbo.reader(4).ToString
                        '.cmbConsignee.Text = Dbo.reader(5).ToString
                        If FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                            SHIPPER = Dbo.reader(4).ToString & " - " & Dbo.reader(54).ToString
                        Else
                            SHIPPER = Dbo.reader(4).ToString
                        End If

                        If FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNI") Then
                            .cmbConsignee.Text = Dbo.reader(5).ToString & " - " & Dbo.reader(54).ToString
                        Else
                            .cmbConsignee.Text = Dbo.reader(5).ToString
                        End If


                        .cmbNotify.Text = Dbo.reader(6).ToString

                        .cmbFeederVessel.Text = Dbo.reader(7).ToString
                        .cmbFeederVoyage1.Text = Dbo.reader(8).ToString
                        .cmbLoading1.Text = Dbo.reader(9).ToString
                        .CmbPOD1.Text = Dbo.reader(10).ToString

                        If Dbo.reader(26).ToString = "D" Then
                            .CmbTransipment.Text = "DUAL TRANSSHIPMENT"
                        Else
                            .CmbTransipment.Text = "SINGLE TRANSSHIPMENT"
                        End If

                        .cmb2ndFeederVessel.Text = Dbo.reader(11).ToString
                        .cmbFeederVoyage2.Text = Dbo.reader(12).ToString
                        .cmbLoading2.Text = Dbo.reader(13).ToString
                        .cmbPOD2.Text = Dbo.reader(14).ToString

                        .cmbMotherVessel.Text = Dbo.reader(15).ToString
                        .cmbMotherVoyage.Text = Dbo.reader(16).ToString
                        .CmbMotherVesselLoading.Text = Dbo.reader(17).ToString
                        .cmbTrade.Text = Dbo.reader(18).ToString
                        .cmbSubTrade.Text = Dbo.reader(19).ToString
                        .cmbPorts.Text = Dbo.reader(20).ToString


                        .txtNumbersDesc.Text = Dbo.reader(21).ToString
                        .txtKgs.Text = Dbo.reader(22).ToString
                        .txtCbm.Text = Dbo.reader(23).ToString
                        If Dbo.reader(24).ToString = "P" Then
                            .rdPrepaid.Checked = True
                        ElseIf Dbo.reader(24).ToString = "C" Then
                            .rdCollect.Checked = True
                        End If
                        .cmbDepot.Text = Dbo.reader(27).ToString
                        .cmbReleasingChecker.Text = Dbo.reader(29).ToString
                        .txtTelNo.Text = Dbo.reader(28).ToString
                        .txtOperatingHours.Text = Dbo.reader(30).ToString
                        Dim OHStart() As String
                        Dim OperatingHoursIs As String = Dbo.reader(30).ToString


                        If Not String.IsNullOrEmpty(OperatingHoursIs) Then
                            If OperatingHoursIs = "24HRS" Then
                                .dtStartOH.Value = Now.Date & " " & "06:00 AM"
                                .dtEndOH.Value = Now.Date & " " & "06:00 AM"
                            Else
                                OHStart = OperatingHoursIs.Split("-")
                                .dtStartOH.Value = Now.Date & " " & OHStart(0)
                                .dtEndOH.Value = Now.Date & " " & OHStart(1)
                            End If

                        End If

                        'If Not String.IsNullOrEmpty(OperatingHoursIs) Then
                        '    OHStart = OperatingHoursIs.Split("-")
                        '    .dtStartOH.Value = Now.Date & " " & OHStart(0)
                        '    .dtEndOH.Value = Now.Date & " " & OHStart(1)
                        'End If


                        .dtEtaDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(31).ToString), Now, Dbo.reader(31).ToString)
                        .dtEtdDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(32).ToString), Now, Dbo.reader(32).ToString)
                        .dtClosingEndTime.Value = IIf(String.IsNullOrEmpty(Dbo.reader(33).ToString), Now, Dbo.reader(33).ToString)
                        .cmbDeliveryPort.Text = Dbo.reader(38).ToString
                        .txtViaPort.Text = Dbo.reader(35).ToString
                        .dtArrastreCutoff.Value = IIf(String.IsNullOrEmpty(Dbo.reader(36).ToString), Now, Dbo.reader(36).ToString)
                        .cmbCargoWeight.Text = Dbo.reader(37).ToString
                    Loop
                    .cmbShipper.Text = SHIPPER


                    Dbo.reader.Close()
                    Dbo.SqlCon.Close()
                    Call FrmBookingList.lOADContainers(MainSysref, MainBkno, SelStatIs)
                    Call FrmBookingList.LoadTruckers(MainSysref, MainBkno, SelStatIs)



                    .Button4.Visible = False



                    .pnlCS.Visible = True
                    .PnlOperations.Visible = True
                    .pnlCsSave.Visible = False
                    .pnlOpsSave.Visible = False
                    .btnAddTrucker.Enabled = True
                    .btnAdd.Enabled = True
                    .PnlRebook.Visible = True
                    .Width = "1178"
                    '.Height = "670"


                    .lblBookingInfo.Text = "REBOOKING"
                End With
                Call LoadForm(FrmInitialBooking, "REBOOK:" & MainBkno)
            End With
        End If


        If FrmBookingList.ActionMode = "CANCEL" Then
            If FrmBookingList.dtList.CurrentRow.Cells(21).Value <> "INITIAL" Then
                MsgBox("Cannot be cancelled!", MsgBoxStyle.Critical)
                Exit Sub
            End If
            If MsgBox("Are you sure you want to cancel this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_BOOKING SET REASON = '" & KVal(cmbReasons.Text) & "', STAT = '0', CancelledBy = '" & USER_ID & "', DateCancelled = '" & Now & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                'Call SetJob("UPDATE TBL_BOOKING SET STAT = '0' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '0' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call FrmBookingList.FrmBookingList_Load(e, e)
                MsgBox("Cancelled!", MsgBoxStyle.Information)
                Me.Dispose()
            End If
        End If
    End Sub
End Class