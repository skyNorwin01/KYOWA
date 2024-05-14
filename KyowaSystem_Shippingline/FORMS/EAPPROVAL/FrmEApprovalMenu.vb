Imports System.ComponentModel
Imports System.Net.Mail
Imports MySql.Data.MySqlClient
Imports WinSCP

Public Class FrmEApprovalMenu
    Public FileNameIs = "", FileNameWithPath As String = ""
    Public FileNameIsA = "", FileNameWithPathA As String = ""
    Dim opfAttachment As New OpenFileDialog

    Public rfpInvBsno = "", rfpInfavorOf = "", rfpManualChecker = "", rfpSeries As String = ""

    Public Sub LoadRfpList(strSearch)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT DISTINCT R1.InvoiceNo, R1.InFavorOf,R1.SERIES FROM TBL_REQUEST_FOR_PAYMENT AS R1 WHERE ISNULL(R1.InvoiceNo,'') <> '' AND ISNULL(R1.InFavorOf,'') <> '' AND ISNULL(R1.SERIES,'') <> '' AND R1.STAT = '1'  AND R1.InvoiceNo LIKE  '%" & KVal(strSearch) & "%' " +
" UNION " +
        "SELECT  DISTINCT R2.BSNO, R2.INFAVOROF,R2.series FROM TBL_CY_RFP AS R2 WHERE ISNULL(R2.BSNO,'') <> '' AND ISNULL(R2.InFavorOf,'') <> '' AND ISNULL(R2.SERIES,'') <> ''  AND R2.STAT = '1'   AND R2.bsno LIKE  '%" & KVal(strSearch) & "%'  ORDER BY R1.SERIES DESC"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With DTrfp
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub LoadManifestList()
        SQL = " SELECT  CONVERT(NVARCHAR(100),MV.VESSELNAME) as VNAME, B.MVOYAGE, convert(nvarchar(400),POD) as POD_POD , B.MANIFESTEApproveTag, B.BKNO, BL.BLno, BL.Shipper, ShipperAddress, BL.Consignee, ConsigneeAddress, BL.Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel as MV, b.MotherVessel,   B.MVoyage ,   OceanVesselPOL, convert(nvarchar(400),POD) as POD_POD, BL.PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, BL.AddedBy, BL.DateAdded, BL.Stat, O.ViaPort, BL.LocalVessel, BL.LocalVesselPOL, convert(nvarchar(300),MV.VESSELNAME) AS VESSELNAME, CONVERT(NVARCHAR(100),MV.VESSELNAME) as VNAME, 'MAIN' as MAIN_A FROM TBL_BL AS BL LEFT JOIN TBL_BOOKING AS B ON BL.BLNO = B.BLNO AND B.STAT = '1' AND BL.STAT = '1' LEFT JOIN TBL_OPERATIONS AS O ON B.BKNO = O.BKNO AND O.Stat = '1' LEFT JOIN TBL_VESSEL AS MV ON MV.ID = B.MotherVessel WHERE   BL.STAT = '1'  and B.MANIFESTEapproveTag <> ''  AND B.BLNO LIKE '%'"
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtManifest
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub


    Private Sub FrmEApprovalMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadRfpList(txtSearch.Text)
        Call LoadManifestList()


        With cmbParticular.Items
            .Clear()
            .Add("REQUEST FOR PAYMENT")
            .Add("MANIFEST")
        End With



        If EApprovalAccess = "D" Then
            With cmbRequestTo.Items
                .Clear()
                .Add("LUDY ANDRESS")
                '.Add("RODERICK YU")
                .Add("RAYZ EUGENIO")
                '.Add("DUMMY DUMMYL")
            End With
        ElseIf EApprovalAccess = "M" Then
            'With cmbTo.Items
            '    .Clear()
            '    .Add("MARYANN AGPASA")
            '    .Add("IVY GREGORIO")
            '    .Add("WENG BAUTISTA")
            '    '.Add("RAYZ EUGENIO")
            'End With
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub

    Private Sub cmbParticular_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbParticular.SelectedIndexChanged
        If KVal(cmbParticular.Text) = "REQUEST FOR PAYMENT" Then
            TabControl1.SelectedIndex = 1
        ElseIf KVal(cmbParticular.Text) = "MANIFEST" Then
             TabControl1.SelectedIndex = 0
        End If
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click
        cmbParticular.Text = "REQUEST FOR PAYMENT"
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click
        cmbParticular.Text = "MANIFEST"
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        Dim opf As New OpenFileDialog
        'opf.Filter = "Files(*.pdf;*.jpg;*.jpeg)|*.pdf;*.jpg;*.jpeg"
        opf.Filter = "PDF Files(*.pdf)|*.pdf"
        'opf.Filter = ""
        If opf.ShowDialog = DialogResult.OK Then
            If opf.FileName.Contains("#") OrElse opf.FileName.Contains("+") Then
                MsgBox("Please remove special characters #|+ in filename.", MsgBoxStyle.Critical)
                opf.FileName = ""
                Exit Sub
            End If
            aPDFMain.src = opf.FileName
            FileNameIs = System.IO.Path.GetFileName(opf.FileName)
            FileNameWithPath = opf.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        opfAttachment.Filter = "PDF Files(*.pdf)|*.pdf"
        'opfAttachment.Filter = ""
        If opfAttachment.ShowDialog = DialogResult.OK Then
            If opfAttachment.FileName.Contains("#") OrElse opfAttachment.FileName.Contains("+") Then
                MsgBox("Please remove special characters #|+ in filename.", MsgBoxStyle.Critical)
                opfAttachment.FileName = ""
                Exit Sub
            End If
            aPDFSupp.src = opfAttachment.FileName
            FileNameIsA = System.IO.Path.GetFileName(opfAttachment.FileName)
            FileNameWithPathA = opfAttachment.FileName
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        aPDFMain.LoadFile("Empty")
        'aPDFMain.src = ""
        'FileNameIs = System.IO.Path.GetFileName("")
        'FileNameWithPath = ""

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        aPDFSupp.LoadFile("Empty")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSendRequest_Click(sender As Object, e As EventArgs) Handles btnSendRequest.Click
        If cmbParticular.SelectedIndex = -1 Then
            MsgBox("Invalid particular!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbRequestTo.SelectedIndex = -1 Then
            MsgBox("Invalid Request to!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If aPDFMain.src = "Empty" Then
            MsgBox("Please upload file first!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If aPDFMain.src = Nothing Then
            MsgBox("Please upload file first!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If KVal(cmbParticular.Text) = "REQUEST FOR PAYMENT" Then
            If ChkManualSignOfChecker.Checked = True Then
                If MsgBox("Are you sure that this request is checked manualy by checker" & UCase(cmbRequestTo.Text) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    rfpManualChecker = "YES"
                Else
                    rfpManualChecker = "NO"
                End If
            End If
            Dim strEmailIsTo = "", EmailsFrom = "", EmailCredential = "", EmailBackTo As String = ""
            If EApprovalAccess = "D" Then
                If MsgBox("Are you sure you want to send this request to " & vbCrLf & KVal(cmbRequestTo.Text) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Dim series = "0", PrintType As String = ""
                    'Dim wContainer = 0, VatExempt = 0, wAdditional As Integer = 0
                    'PrintType = ""
                    'wContainer = 0
                    'VatExempt = 0
                    'wAdditional = 0


                    If Not GetRyzk("Select SERIES FROM TBL_REFERENCE WHERE PARAM1 = 'ALL' AND PARAM2 = 'EAPPROVAL'", "L") = NoRecordFound Then
                        series = Format(CInt(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM1 = 'ALL'  AND PARAM2 = 'EAPPROVAL'", "L")), "0000")
                    End If

                    Dim RefTag As String = "RTG" & Format(Now, "MMddyyhhmmssfff")


                    EmailsFrom = UserEmail
                    Dim EmailsToIs As String = GetRyzk("SELECT EmailAddress FROM TBL_USERS WHERE FNAME + ' ' + LNAME = '" & KVal(cmbRequestTo.Text) & "'", "L")

                    strEmailIsTo = EmailsToIs


                    Try
                        Dim WithAdditional = 0, UrgentLevel As Integer = 0

                        If rd1.Checked = True Then
                            UrgentLevel = 1
                        ElseIf rd2.Checked = True Then
                            UrgentLevel = 2
                            'ElseIf rd3.Checked = True Then
                            '    UrgentLevel = 3
                            'ElseIf rd4.Checked = True Then
                            '    UrgentLevel = 4
                            'ElseIf rd5.Checked = True Then
                            '    UrgentLevel = 5
                        End If


                        'Dim ofd As New OpenFileDialog
                        'Dim a As String = ""
                        'If ofd.ShowDialog = DialogResult.OK Then
                        '    a = ofd.FileName
                        'End If
                        ' Setup session options
                        Dim sessionOptions As New SessionOptions
                        With sessionOptions
                            .Protocol = Protocol.Sftp
                            .HostName = "skyintl.com.ph"
                            .UserName = "root"
                            .Password = "sky123-18s13iN"
                            .SshHostKeyFingerprint = "ssh-rsa 2048 JHHcMVo8dGq8xu/voxcj/xuT0WQXigxtNzv/U/AMzJc"
                        End With

                        Using session As New Session
                            ' Connect
                            session.Open(sessionOptions)


                            session.CreateDirectory("/var/www/html/generalagent/sa/1/1/" & RefTag)
                            session.CreateDirectory("/var/www/html/generalagent/sa/1/1/0/" & RefTag)

                            'session.CreateDirectory("/var/www/html/skybest/NSFS/sa/1/1/" & RefTag)
                            'session.CreateDirectory("/var/www/html/skybest/NSFS/sa/1/1/0/" & RefTag)



                            'session.PutFiles(FileNameWithPathA, "/var/www/html/skybest/NSFS/sa/2/0/", False, transferOptions)


                            ' Upload files
                            Dim transferOptions As New TransferOptions
                            transferOptions.TransferMode = TransferMode.Binary

                            Dim transferResult As TransferOperationResult
                            transferResult =
                            session.PutFiles(FileNameWithPath, "/var/www/html/generalagent/sa/1/1/" & RefTag & "/", False, transferOptions)
                            session.PutFiles(FileNameWithPathA, "/var/www/html/generalagent/sa/1/1/0/" & RefTag & "/", False, transferOptions)

                            'session.PutFiles(FileNameWithPath, "/var/www/html/skybest/NSFS/sa/1/1/" & RefTag & "/", False, transferOptions)
                            'session.PutFiles(FileNameWithPathA, "/var/www/html/skybest/NSFS/sa/1/1/0/" & RefTag & "/", False, transferOptions)

                            ' Throw on any error
                            transferResult.Check()

                            ' Print results
                            'For Each transfer In transferResult.Transfers
                            '    MsgBox("Upload of {0} succeeded " & transfer.FileName, MsgBoxStyle.Information)
                            'Next
                        End Using
                        'FileNameIs = System.IO.Path.GetFileName(FileNameIs)
                        'request to manager
                        'Call SaveToWebServer(Me.Tag)
                        Dim ReqParam As String = rfpInvBsno

                        If ReqParam.Contains("-") Then
                            ReqParam = "BSNO"
                        Else
                            ReqParam = "INVOICE"
                        End If




                        'Email to MANAGER
                        Dim Smtp_Server As New SmtpClient
                        Dim e_mail As New MailMessage()
                        Smtp_Server.UseDefaultCredentials = False

                        Smtp_Server.Credentials = New Net.NetworkCredential(UserEmail, EPass)
                        Smtp_Server.Port = 587
                        Smtp_Server.EnableSsl = True
                        Smtp_Server.Host = "smtp.gmail.com"

                        e_mail = New MailMessage()
                        e_mail.From = New MailAddress(EmailsFrom)
                        e_mail.To.Add(strEmailIsTo)
                        Dim Subj As String = rfpInvBsno

                        If Subj.Contains("-") Then
                            Subj = "REQUEST FOR PAYMENT APPROVAL | BSNO: " & KVal(rfpInvBsno) & " | INFAVOR OF: " & KVal(rfpInfavorOf) & " | URG LVL: " & IIf(UrgentLevel = 1, "REGULAR", "URGENT")
                        Else
                            Subj = "REQUEST FOR PAYMENT APPROVAL | INVOICE NO: " & KVal(rfpInvBsno) & " | INFAVOR OF: " & KVal(rfpInfavorOf) & " | URG LVL: " & IIf(UrgentLevel = 1, "REGULAR", "URGENT")
                        End If

                        'e_mail.Subject = "REQUEST FOR PAYMENT APPROVAL | REF NO: " & KVal(lblRefno.Text) & " | BL NO: " & KVal(lblBlno.Text) & " | URG LVL: " & IIf(UrgentLevel = 1, "REGULAR", "URGENT")
                        e_mail.Subject = Subj


                        e_mail.IsBodyHtml = False
                        Dim eLink As String = ""
                        eLink = "Shortcut to e-approval portal:" & "https://www.generalagent.skyintl.com.ph/sa/home.php"
                        e_mail.Body = KValNCase(txtNote.Text & vbCrLf & vbCrLf & vbCrLf & vbCrLf & eLink)
                        Smtp_Server.Send(e_mail)

                        'Call SaveTheRequests(Me.Tag, lblBlno.Text, lblRefno.Text, WithAdditional, USER_ID, UCase(cmbTo.Text), "0", KValNCase(txtNote.Text), "", "0", lblRequestOption.Text, "", Now, "1", UrgentLevel, FileNameIs)
                        'Call SaveTheRequestsWeb(Me.Tag, lblBlno.Text, lblRefno.Text, WithAdditional, USER_ID, UCase(cmbTo.Text), "0", KValNCase(txtNote.Text), "", "0", lblRequestOption.Text, "", Now, "1", UrgentLevel, FileNameIs)

                        Call SaveTheRequestsWeb(RefTag, Me.Tag, rfpInvBsno, rfpInfavorOf, FNAME & " " & LNAME, UCase(cmbRequestTo.Text), "0", KValNCase(txtNote.Text), "", "0", "Request for Payment", "", Now, "1", UrgentLevel, FileNameIs, FileNameIsA, series, PrintType, rfpSeries, ReqParam)

                        Call SaveTheRequests(RefTag, Me.Tag, rfpInvBsno, rfpInfavorOf, USER_ID, UCase(cmbRequestTo.Text), "0", KValNCase(txtNote.Text), "", "0", "Request for Payment", "", Now, "1", UrgentLevel, FileNameIs, FileNameIsA, series, PrintType, rfpSeries, ReqParam)

                        Dim CurSeries As Integer = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM1 = 'ALL' AND PARAM2 = 'EAPPROVAL'", "L")
                        Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE PARAM1 = 'ALL' AND PARAM2 = 'EAPPROVAL'")


                        MsgBox("E-Approval request sent", MsgBoxStyle.Information)
                        'frmWorkfileApprovalList.btnSearch_Click(e, e)
                        Me.Dispose()
                    Catch error_t As Exception
                        MsgBox(error_t.ToString)
                    End Try
                End If
            End If
        End If
    End Sub


    Public Sub SaveTheRequests(RTG, sysref, BLNO, REFNO, AddedBy, RequestToManager, ReqToManagerApproveStat, ReqToManagerNote, RequestToExecom, ReqToExecomApproveStat, PARTICULAR, APPROVESTAT, DateAdded, STAT, ReqToManagerUrgentLevel, FileName, FileNameA, SeriesPrint, PrintType, rfp_series, PARAM1)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_REQUEST_E_APPROVAL(RTG,sysref, BLNO, REFNO, AddedBy, RequestToManager, ReqToManagerApproveStat, ReqToManagerNote, RequestToExecom, ReqToExecomApproveStat, PARTICULAR, APPROVESTAT, DateAdded, STAT, ReqToManagerUrgentLevel, FileName, FileNameA, SeriesPrint, PrintType, rfp_series, PARAM1)"
        SQL = SQL + "VALUES('" & KVal(RTG) & "', '" & KVal(sysref) & "', '" & KVal(BLNO) & "',  '" & KVal(REFNO) & "',  '" & KVal(AddedBy) & "',  '" & KVal(RequestToManager) & "',  '" & KVal(ReqToManagerApproveStat) & "',  '" & ReqToManagerNote & "',  '" & KVal(RequestToExecom) & "',  '" & KVal(ReqToExecomApproveStat) & "',  '" & KVal(PARTICULAR) & "',  '" & KVal(APPROVESTAT) & "',  '" & KVal(DateAdded) & "',  '" & KVal(STAT) & "', '" & KVal(ReqToManagerUrgentLevel) & "', '" & KValNCase(FileName) & "', '" & KValNCase(FileNameA) & "', '" & KVal(SeriesPrint) & "' , '" & KVal(PrintType) & "', '" & KVal(rfp_series) & "', '" & KVal(PARAM1) & "'  )"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub


    Public Sub SaveTheRequestsWeb(RTG, sysref, BLNO, REFNO, AddedBy, RequestToManager, ReqToManagerApproveStat, ReqToManagerNote, RequestToExecom, ReqToExecomApproveStat, PARTICULAR, APPROVESTAT, DateAdded, STAT, ReqToManagerUrgentLevel, FileName, FileNameA, SeriesPrint, PrintType, rfp_series, PARAM1)
        Dim Dbo2 As New SQLClass
        Dbo2.MysqlCon.Open()
        SQL = "INSERT INTO tbl_eapprove_n(RTG,sysref, blno, refno, AddedBy, RequestToManager, ReqToManagerApproveStat, ReqToManagerNote, RequestToExecom, ReqToExecomApproveStat, PARTICULAR, APPROVESTAT, DateAdded, STAT, ReqToManagerUrgentLevel, FileName, FileNameA, SeriesPrint,PrintType,rfp_series, PARAM1, fstat)"
        SQL = SQL + "VALUES(@RTG, @sysref, @BLNO, @REFNO, @AddedBy, @RequestToManager, @ReqToManagerApproveStat, @ReqToManagerNote, @RequestToExecom, @ReqToExecomApproveStat, @PARTICULAR, @APPROVESTAT, @DateAdded, @STAT, @ReqToManagerUrgentLevel, @FileName, @FileNameA,  @SeriesPrint, @PrintType,@rfp_series, @PARAM1,@fstat)"
        Dbo2.MysqlCmd = New MySql.Data.MySqlClient.MySqlCommand(SQL, Dbo2.MysqlCon)
        Dbo2.MysqlCmd.Parameters.Add("@RTG", MySqlDbType.VarChar).Value = RTG
        Dbo2.MysqlCmd.Parameters.Add("@sysref", MySqlDbType.VarChar).Value = sysref
        Dbo2.MysqlCmd.Parameters.Add("@BLNO", MySqlDbType.VarChar).Value = BLNO
        Dbo2.MysqlCmd.Parameters.Add("@REFNO", MySqlDbType.VarChar).Value = REFNO
        Dbo2.MysqlCmd.Parameters.Add("@AddedBy", MySqlDbType.VarChar).Value = AddedBy
        Dbo2.MysqlCmd.Parameters.Add("@RequestToManager", MySqlDbType.VarChar).Value = RequestToManager
        Dbo2.MysqlCmd.Parameters.Add("@ReqToManagerApproveStat", MySqlDbType.Int16).Value = ReqToManagerApproveStat
        Dbo2.MysqlCmd.Parameters.Add("@ReqToManagerNote", MySqlDbType.VarChar).Value = ReqToManagerNote
        Dbo2.MysqlCmd.Parameters.Add("@RequestToExecom", MySqlDbType.VarChar).Value = RequestToExecom
        Dbo2.MysqlCmd.Parameters.Add("@ReqToExecomApproveStat", MySqlDbType.Int16).Value = ReqToExecomApproveStat
        Dbo2.MysqlCmd.Parameters.Add("@PARTICULAR", MySqlDbType.VarChar).Value = PARTICULAR
        Dbo2.MysqlCmd.Parameters.Add("@APPROVESTAT", MySqlDbType.VarChar).Value = APPROVESTAT
        Dbo2.MysqlCmd.Parameters.Add("@DateAdded", MySqlDbType.DateTime).Value = DateAdded
        Dbo2.MysqlCmd.Parameters.Add("@STAT", MySqlDbType.Int16).Value = STAT
        Dbo2.MysqlCmd.Parameters.Add("@ReqToManagerUrgentLevel", MySqlDbType.VarChar).Value = ReqToManagerUrgentLevel
        Dbo2.MysqlCmd.Parameters.Add("@FileName", MySqlDbType.VarChar).Value = FileName
        Dbo2.MysqlCmd.Parameters.Add("@FileNameA", MySqlDbType.VarChar).Value = FileNameA

        Dbo2.MysqlCmd.Parameters.Add("@SeriesPrint", MySqlDbType.VarChar).Value = SeriesPrint
        Dbo2.MysqlCmd.Parameters.Add("@PrintType", MySqlDbType.VarChar).Value = PrintType
        Dbo2.MysqlCmd.Parameters.Add("@rfp_series", MySqlDbType.VarChar).Value = rfp_series
        Dbo2.MysqlCmd.Parameters.Add("@PARAM1", MySqlDbType.VarChar).Value = PARAM1
        Dbo2.MysqlCmd.Parameters.Add("@fstat", MySqlDbType.VarChar).Value = 0
        'Dbo2.MysqlCmd.Parameters.Add("@ReqToExecomApproveDate", MySqlDbType.DateTime).Value = DateAdded
        Dbo2.MysqlCmd.ExecuteNonQuery()
        Dbo2.MysqlCon.Close()
    End Sub

    Private Sub rd1_CheckedChanged(sender As Object, e As EventArgs) Handles rd1.CheckedChanged

    End Sub

    Private Sub rd2_CheckedChanged(sender As Object, e As EventArgs) Handles rd2.CheckedChanged

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Call LoadRfpList(txtSearch.Text)
    End Sub

    Private Sub dtManifest_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtManifest.CellContentClick

    End Sub

    Private Sub DTrfp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTrfp.CellContentClick

    End Sub

    Private Sub btnSendEManifest_Click(sender As Object, e As EventArgs) Handles btnSendEManifest.Click
        If cmbParticular.SelectedIndex = -1 Then
            MsgBox("Invalid particular!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If cmbRequestTo.SelectedIndex = -1 Then
            MsgBox("Invalid Request to!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If aPDFMain.src = "Empty" Then
            MsgBox("Please upload file first!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If aPDFMain.src = Nothing Then
            MsgBox("Please upload file first!", MsgBoxStyle.Critical)
            Exit Sub
        End If


        If KVal(cmbParticular.Text) = "MANIFEST" Then
            If ChkManualSignOfChecker.Checked = True Then
                If MsgBox("Are you sure that this request is checked manualy by checker" & UCase(cmbRequestTo.Text) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    rfpManualChecker = "YES"
                Else
                    rfpManualChecker = "NO"
                End If
            End If
            Dim strEmailIsTo = "", EmailsFrom = "", EmailCredential = "", EmailBackTo As String = ""
            If EApprovalAccess = "D" Then
                If MsgBox("Are you sure you want to send this MANIFEST to " & vbCrLf & KVal(cmbRequestTo.Text) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    Dim series = "0", PrintType As String = ""
                    'Dim wContainer = 0, VatExempt = 0, wAdditional As Integer = 0
                    'PrintType = ""
                    'wContainer = 0
                    'VatExempt = 0
                    'wAdditional = 0


                    If Not GetRyzk("Select SERIES FROM TBL_REFERENCE WHERE PARAM1 = 'ALL' AND PARAM2 = 'EAPPROVAL'", "L") = NoRecordFound Then
                        series = Format(CInt(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM1 = 'ALL'  AND PARAM2 = 'EAPPROVAL'", "L")), "0000")
                    End If

                    Dim RefTag As String = "MNFST" & Format(Now, "MMddyyhhmmssfff")


                    EmailsFrom = UserEmail
                    Dim EmailsToIs As String = GetRyzk("SELECT EmailAddress FROM TBL_USERS WHERE FNAME + ' ' + LNAME = '" & KVal(cmbRequestTo.Text) & "'", "L")

                    strEmailIsTo = EmailsToIs


                    Try
                        Dim WithAdditional = 0, UrgentLevel As Integer = 0

                        If rd1.Checked = True Then
                            UrgentLevel = 1
                        ElseIf rd2.Checked = True Then
                            UrgentLevel = 2
                            'ElseIf rd3.Checked = True Then
                            '    UrgentLevel = 3
                            'ElseIf rd4.Checked = True Then
                            '    UrgentLevel = 4
                            'ElseIf rd5.Checked = True Then
                            '    UrgentLevel = 5
                        End If


                        'Dim ofd As New OpenFileDialog
                        'Dim a As String = ""
                        'If ofd.ShowDialog = DialogResult.OK Then
                        '    a = ofd.FileName
                        'End If
                        ' Setup session options
                        Dim sessionOptions As New SessionOptions
                        With sessionOptions
                            .Protocol = Protocol.Sftp
                            .HostName = "skyintl.com.ph"
                            .UserName = "root"
                            .Password = "sky123-18s13iN"
                            .SshHostKeyFingerprint = "ssh-rsa 2048 JHHcMVo8dGq8xu/voxcj/xuT0WQXigxtNzv/U/AMzJc"
                        End With

                        Using session As New Session
                            ' Connect
                            session.Open(sessionOptions)


                            session.CreateDirectory("/var/www/html/generalagent/sa/1/1/" & RefTag)
                            session.CreateDirectory("/var/www/html/generalagent/sa/1/1/0/" & RefTag)

                            'session.CreateDirectory("/var/www/html/skybest/NSFS/sa/1/1/" & RefTag)
                            'session.CreateDirectory("/var/www/html/skybest/NSFS/sa/1/1/0/" & RefTag)



                            'session.PutFiles(FileNameWithPathA, "/var/www/html/skybest/NSFS/sa/2/0/", False, transferOptions)


                            ' Upload files
                            Dim transferOptions As New TransferOptions
                            transferOptions.TransferMode = TransferMode.Binary

                            Dim transferResult As TransferOperationResult
                            transferResult =
                            session.PutFiles(FileNameWithPath, "/var/www/html/generalagent/sa/1/1/" & RefTag & "/", False, transferOptions)
                            session.PutFiles(FileNameWithPathA, "/var/www/html/generalagent/sa/1/1/0/" & RefTag & "/", False, transferOptions)

                            'session.PutFiles(FileNameWithPath, "/var/www/html/skybest/NSFS/sa/1/1/" & RefTag & "/", False, transferOptions)
                            'session.PutFiles(FileNameWithPathA, "/var/www/html/skybest/NSFS/sa/1/1/0/" & RefTag & "/", False, transferOptions)

                            ' Throw on any error
                            transferResult.Check()

                            ' Print results
                            'For Each transfer In transferResult.Transfers
                            '    MsgBox("Upload of {0} succeeded " & transfer.FileName, MsgBoxStyle.Information)
                            'Next
                        End Using
                        'FileNameIs = System.IO.Path.GetFileName(FileNameIs)
                        'request to manager
                        'Call SaveToWebServer(Me.Tag)
                        Dim ReqParam As String = "MANIFEST"






                        'Email to MANAGER
                        Dim Smtp_Server As New SmtpClient
                        Dim e_mail As New MailMessage()
                        Smtp_Server.UseDefaultCredentials = False

                        Smtp_Server.Credentials = New Net.NetworkCredential(UserEmail, EPass)
                        Smtp_Server.Port = 587
                        Smtp_Server.EnableSsl = True
                        Smtp_Server.Host = "smtp.gmail.com"

                        e_mail = New MailMessage()
                        e_mail.From = New MailAddress(EmailsFrom)
                        e_mail.To.Add(strEmailIsTo)
                        Dim Subj As String = rfpInvBsno

                        If Subj.Contains("-") Then
                            Subj = "MANIFEST APPROVAL REQUEST | " & KVal(rfpInvBsno) & " | DESTINATION: " & KVal(rfpInfavorOf) & " | URG LVL: " & IIf(UrgentLevel = 1, "REGULAR", "URGENT")
                        Else
                            Subj = "MANIFEST APPROVAL REQUEST | " & KVal(rfpInvBsno) & " | DESTINATION: " & KVal(rfpInfavorOf) & " | URG LVL: " & IIf(UrgentLevel = 1, "REGULAR", "URGENT")
                        End If

                        'e_mail.Subject = "REQUEST FOR PAYMENT APPROVAL | REF NO: " & KVal(lblRefno.Text) & " | BL NO: " & KVal(lblBlno.Text) & " | URG LVL: " & IIf(UrgentLevel = 1, "REGULAR", "URGENT")
                        e_mail.Subject = Subj


                        e_mail.IsBodyHtml = False
                        Dim eLink As String = ""
                        eLink = "Shortcut to e-approval portal:" & "https://www.generalagent.skyintl.com.ph/sa/home.php"
                        e_mail.Body = KValNCase(txtNoteManifest.Text & vbCrLf & vbCrLf & vbCrLf & vbCrLf & eLink)
                        Smtp_Server.Send(e_mail)

                        'Call SaveTheRequests(Me.Tag, lblBlno.Text, lblRefno.Text, WithAdditional, USER_ID, UCase(cmbTo.Text), "0", KValNCase(txtNote.Text), "", "0", lblRequestOption.Text, "", Now, "1", UrgentLevel, FileNameIs)
                        'Call SaveTheRequestsWeb(Me.Tag, lblBlno.Text, lblRefno.Text, WithAdditional, USER_ID, UCase(cmbTo.Text), "0", KValNCase(txtNote.Text), "", "0", lblRequestOption.Text, "", Now, "1", UrgentLevel, FileNameIs)

                        Call SaveTheRequestsWeb(RefTag, Me.Tag, rfpInvBsno, rfpInfavorOf, FNAME & " " & LNAME, UCase(cmbRequestTo.Text), "0", KValNCase(txtNote.Text), "", "0", "Manifest", "", Now, "1", UrgentLevel, FileNameIs, FileNameIsA, series, PrintType, rfpSeries, ReqParam)

                        Call SaveTheRequests(RefTag, Me.Tag, rfpInvBsno, rfpInfavorOf, USER_ID, UCase(cmbRequestTo.Text), "0", KValNCase(txtNote.Text), "", "0", "Manifest", "", Now, "1", UrgentLevel, FileNameIs, FileNameIsA, series, PrintType, rfpSeries, ReqParam)

                        Dim CurSeries As Integer = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM1 = 'ALL' AND PARAM2 = 'EAPPROVAL'", "L")
                        Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE PARAM1 = 'ALL' AND PARAM2 = 'EAPPROVAL'")


                        MsgBox("E-Approval for manifest request sent", MsgBoxStyle.Information)
                        'frmWorkfileApprovalList.btnSearch_Click(e, e)
                        Me.Dispose()
                    Catch error_t As Exception
                        MsgBox(error_t.ToString)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub DTrfp_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTrfp.CellDoubleClick
        btnSelect_Click(e, e)
    End Sub

    Private Sub DTrfp_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DTrfp.CellEnter
        If DTrfp.RowCount = 0 Then
            Exit Sub
        End If
        rfpInvBsno = DTrfp.CurrentRow.Cells(0).Value
        rfpInfavorOf = DTrfp.CurrentRow.Cells(1).Value
        rfpSeries = DTrfp.CurrentRow.Cells(2).Value
    End Sub

    Private Sub TabPage1_MouseMove(sender As Object, e As MouseEventArgs) Handles TabPage1.MouseMove
        If Not TabControl1.SelectedIndex = 1 Then
            cmbParticular.Text = "MANIFEST"
        End If
    End Sub

    Private Sub TabControl1_MouseMove(sender As Object, e As MouseEventArgs) Handles TabControl1.MouseMove
        If Not TabControl1.SelectedIndex = 1 Then
            cmbParticular.Text = "MANIFEST"
        End If
        If Not TabControl1.SelectedIndex = 0 Then
            cmbParticular.Text = "REQUEST FOR PAYMENT"
        End If

    End Sub

    Private Sub dtManifest_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtManifest.CellEnter
        If dtManifest.RowCount = 0 Then
            Exit Sub
        End If
        rfpInvBsno = dtManifest.CurrentRow.Cells(0).Value & " V-" & dtManifest.CurrentRow.Cells(1).Value
        rfpInfavorOf = dtManifest.CurrentRow.Cells(2).Value
        rfpSeries = dtManifest.CurrentRow.Cells(3).Value
    End Sub

    'Private Sub TabPage2_MouseMove(sender As Object, e As MouseEventArgs) Handles TabPage2.MouseMove
    '    If Not TabControl1.SelectedIndex = 0 Then
    '        cmbParticular.Text = "REQUEST FOR PAYMENT"
    '    End If
    'End Sub

    'Private Sub TabPage1_MouseLeave(sender As Object, e As EventArgs) Handles TabPage1.MouseLeave
    '    If Not TabControl1.SelectedIndex = 1 Then
    '        cmbParticular.Text = "MANIFEST"
    '    End If
    'End Sub

    'Private Sub TabPage2_MouseLeave(sender As Object, e As EventArgs) Handles TabPage2.MouseLeave
    '    If Not TabControl1.SelectedIndex = 0 Then
    '        cmbParticular.Text = "REQUEST FOR PAYMENT"
    '    End If
    'End Sub

    'Private Sub TabPage1_LostFocus(sender As Object, e As EventArgs) Handles TabPage1.LostFocus
    '    If Not TabControl1.SelectedIndex = 1 Then
    '        cmbParticular.Text = "MANIFEST"
    '    End If
    'End Sub

    'Private Sub TabPage2_LostFocus(sender As Object, e As EventArgs) Handles TabPage2.LostFocus
    '    If Not TabControl1.SelectedIndex = 0 Then
    '        cmbParticular.Text = "REQUEST FOR PAYMENT"
    '    End If
    'End Sub
End Class