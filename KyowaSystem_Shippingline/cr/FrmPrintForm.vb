Public Class FrmPrintForm

    Private Sub FrmPrintForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim _series As String = ""
        If PrintModeIs = "REQUEST_FOR_PAYMENT" Then
            If PrintActionMode = "NEW" Then
                If MsgBox("Submit request for payment?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    '_series = Format(CInt(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM3 = 'RFP' AND PARAM1 = '" & FrmBookingList.SelServiceIs & "'", "L")), "00000")
                    _series = Format(CInt(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM3 = 'RFP'", "L")), "00000")

                    Call SetJob("UPDATE TBL_REQUEST_FOR_PAYMENT SET SERIES = '" & _series & "', SubmittedBy = '" & USER_ID & "', Datesubmitted = '" & Now & "' WHERE SYSREF = '" & stsID.Items(0).Text & "' AND SERIES = ''")

                    _series = CInt(_series) + 1
                    'Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & _series & "' WHERE    PARAM1 = '" & FrmBookingList.SelServiceIs & "' AND PARAM2 = 'MNL-' AND PARAM3 = 'RFP'")

                    Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & _series & "' WHERE  PARAM2 = 'MNL-' AND PARAM3 = 'RFP'")

                    MsgBox("Successfully submitted!", MsgBoxStyle.Information)
                    If stsID.Items(1).Text = "RFP" Then
                        FrmRequestForPayment.Dispose()
                        FrmRequestForPaymentList.LoadList()
                        Me.Dispose()
                        Exit Sub
                    End If
                    If stsID.Items(1).Text = "RFP-STORAGE" Then
                        FrmRequestForPaymentStorage.Dispose()
                        FrmRequestForPaymentList.LoadList()
                        Me.Dispose()
                        Exit Sub
                    End If
                    PrintModeIs = ""
                    Exit Sub
                End If
            End If
        End If
        If PrintModeIs = "REQUEST_FOR_PAYMENT_CY" Then
            If PrintActionMode = "NEW" Then
                If MsgBox("Submit request for payment for Container Yard?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    _series = Format(CInt(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM3 = 'RFP' AND PARAM1 = '" & FrmBookingList.SelServiceIs & "'", "L")), "00000")
                    Call SetJob("UPDATE TBL_CY_RFP SET SERIES = '" & _series & "', SubmittedBy = '" & USER_ID & "', Datesubmitted = '" & Now & "' WHERE REFNO = '" & stsID.Items(0).Text & "' AND BsNO = '" & stsID.Items(2).Text & "' AND SERIES is null")

                    _series = CInt(_series) + 1
                    Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & _series & "' WHERE    PARAM1 = '" & FrmBookingList.SelServiceIs & "' AND PARAM2 = 'MNL-' AND PARAM3 = 'RFP'")
                    MsgBox("Successfully submitted!", MsgBoxStyle.Information)

                    If UCase(stsID.Items(1).Text) = "RFP CY" Then
                        FrmRequestForPaymentCY.LoadList()
                        Me.Dispose()
                        Exit Sub
                    End If

                    'If stsID.Items(1).Text = "RFP" Then
                    '    FrmRequestForPayment.Dispose()
                    '    FrmRequestForPaymentList.LoadList()
                    '    Me.Dispose()
                    '    Exit Sub
                    'End If
                    'If stsID.Items(1).Text = "RFP-STORAGE" Then
                    '    FrmRequestForPaymentStorage.Dispose()
                    '    FrmRequestForPaymentList.LoadList()
                    '    Me.Dispose()
                    '    Exit Sub
                    'End If
                    'If UCase(stsID.Items(1).Text) = "RFP CY" Then
                    '    FrmRequestForPayment.Dispose()
                    '    FrmRequestForPaymentList.LoadList()
                    '    Me.Dispose()
                    '    Exit Sub
                    'End If
                    PrintModeIs = ""
                    Exit Sub
                End If
            End If
        End If
        If PrintModeIs = "MANIFEST" Then
            If FrmManifestMenus.rdSending.Checked = True Then
                If PrintActionMode = "NEW" Then
                    If MsgBox("Submit for eapproval?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        If FrmManifestMenus.chkBlno.Checked = True Then
                            Call SetJob("UPDATE TBL_BOOKING SET ManifestEApproveTag = '" & KVal(FrmManifestMenus.txtEAppSys.Text) & "', ManifestEApproveBy = '" & KVal(USER_ID) & "', ManifestEApproveDate = '" & Now & "', ManifestEApproveStat = '', ManifestEApproveReqStat = '1' WHERE STAT = '1' AND BLNO = '" & KVal(FrmManifestMenus.cmbBlNo.Text) & "'")

                            If FrmManifestMenus.chkEapproval.Checked = True Then
                                FrmManifestMenus.txtEAppSys.Text = "MNFST" & Format(Now, "yyMMddhhmmssff")
                            End If
                            MsgBox("Successfully submitted!", MsgBoxStyle.Information)
                            PrintModeIs = ""
                            Me.Dispose()
                            Exit Sub
                        Else
                            Call SelectRecords(FrmManifestMenus.cmbMVessel.Text, FrmManifestMenus.cmbPod.Text)
                            'BL.STAT = '1'  and convert(nvarchar(300),MV.VESSELNAME) = @MVessel and POD = @POD
                            'Call SetJob("UPDATE TBL_BOOKING SET ")

                            If FrmManifestMenus.chkEapproval.Checked = True Then
                                FrmManifestMenus.txtEAppSys.Text = "MNFST" & Format(Now, "yyMMddhhmmssff")
                            End If
                            MsgBox("Successfully submitted!", MsgBoxStyle.Information)
                            PrintModeIs = ""
                            Me.Dispose()
                            Exit Sub
                        End If
                        PrintModeIs = ""
                    End If
                    If FrmManifestMenus.chkEapproval.Checked = True Then
                        FrmManifestMenus.txtEAppSys.Text = "MNFST" & Format(Now, "yyMMddhhmmssff")
                    End If
                End If
            End If
        End If

    End Sub

    Public Sub SelectRecords(MV As String, Pod As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT  B.BKNO, BL.BLno, BL.Shipper, ShipperAddress, BL.Consignee, ConsigneeAddress, BL.Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel as MV, b.MotherVessel,   B.MVoyage ,   OceanVesselPOL, convert(nvarchar(400),POD) as POD_POD, BL.PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, BL.AddedBy, BL.DateAdded, BL.Stat, O.ViaPort, BL.LocalVessel, BL.LocalVesselPOL, convert(nvarchar(300),MV.VESSELNAME) AS VESSELNAME, CONVERT(NVARCHAR(100),MV.VESSELNAME) as VNAME, 'MAIN' as MAIN_A FROM TBL_BL AS BL LEFT JOIN TBL_BOOKING AS B ON BL.BLNO = B.BLNO AND B.STAT = '1' AND BL.STAT = '1' LEFT JOIN TBL_OPERATIONS AS O ON B.BKNO = O.BKNO AND O.Stat = '1' LEFT JOIN TBL_VESSEL AS MV ON MV.ID = B.MotherVessel WHERE   BL.STAT = '1'  and convert(nvarchar(300),MV.VESSELNAME) = '" & KVal(MV) & "' and POD = '" & KVal(Pod) & "'  AND B.BLNO LIKE '%'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        Do While Dbo.reader.Read
            Call SetJob("UPDATE TBL_BOOKING SET ManifestEApproveTag = '" & KVal(FrmManifestMenus.txtEAppSys.Text) & "', ManifestEApproveBy = '" & KVal(USER_ID) & "', ManifestEApproveDate = '" & Now & "', ManifestEApproveStat = '', ManifestEApproveReqStat = '1' WHERE STAT = '1' AND BLNO = '" & KVal(Dbo.reader(1).ToString) & "'")
        Loop
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub FrmPrintForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class