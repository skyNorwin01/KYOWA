

Public Class FrmLogin

    Public UserIdChangePass As String = ""
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown, TextBox2.KeyDown, Panel1.KeyDown, Panel1.KeyDown
        If e.KeyCode = Keys.Escape Then
            End
        End If
        If e.KeyCode = Keys.Enter Then
            Call btnLogin_Click(e, e)
        End If
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Public Sub CheckPassword(username As String, psswrd As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT FNAME, id, Designation, lname, LockAccess, Password, REFUND_TYPE, TransmittalAccess,EApproval, EmailAddress, EPass, DesignationLabel  FROM  TBL_USERS WHERE USERNAME = '" & username & "' AND PASSWORD = '" & psswrd & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        If Dbo.reader.Read Then
            Me.Hide()
            LandingForm.btnLogged.Text = "          " & Dbo.reader(0).ToString
            USER_ID = Dbo.reader(1).ToString
            FNAME = Dbo.reader(0).ToString
            LNAME = Dbo.reader(3).ToString
            UserDesignation = Dbo.reader(2).ToString
            LockAccess = Dbo.reader(4).ToString
            PasswordIs = Dbo.reader(5).ToString
            RefundAccessType = UCase(Dbo.reader(6).ToString)
            TransmittalAccess = Dbo.reader(7).ToString
            UserDesignationLabel = Dbo.reader(11).ToString
            EApprovalAccess = Dbo.reader(8).ToString
            UserEmail = Dbo.reader(9).ToString
            EPass = Dbo.reader(10).ToString
            ''UserAccessEApproval = GetRyzk("SELECT EApproval FROM TBL_USERS WHERE FNAME + ' ' + LNAME = '" & FNAME & " " & LNAME & "'", "L")
            ' UserAccessEApproval = Dbo.reader(8).ToString
            'UserEmail = Dbo.reader(9).ToString
            'UserEPass = Dbo.reader(10).ToString
            Call FrmUpdates.ShowDialog()
            With LandingForm
                .Text = "NEW KYOWA SYSTEM v2"
                '.Icon = My.Resources.nsfsLogo
                .Icon = My.Resources.icons8_ship_wheel_100__3_
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With



        Else
            MsgBox("Invalid password!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LogIn(User As TextBox, Psswrd As TextBox)
        Dim comparePass = "", CompareUsername As String = ""
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT  USERNAME, PASSWORD FROM TBL_USERS WHERE USERNAME = '" & TextBox1.Text & "' AND STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        If Dbo.reader.Read Then
            comparePass = String.Compare(Psswrd.Text, Dbo.reader(1).ToString, False)
            CompareUsername = String.Compare(User.Text, Dbo.reader(0).ToString)
            If comparePass = 0 And CompareUsername = 0 Then
                Call CheckPassword(User.Text, Psswrd.Text)
            Else
                MsgBox("Invalid User!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Else
            MsgBox("Invalid Username!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub



    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click



        'Exit Sub

        'MsgBox(My.Resources.ResourceManager.GetObject("imagename"))
        Call LogIn(TextBox1, TextBox2)


        'If GetrayzK("SELECT PASSWORD FROM TBL_USERS WHERE USERNAME = '" & TextBox1.Text & "' AND STAT = '1'") <> NoRecordFound Then
        '    If GetrayzK("SELECT USERNAME, PASSWORD FROM TBL_USERS WHERE USERNAME = '" & TextBox1.Text & "' AND PASSWORD = '" & TextBox2.Text & "'") <> NoRecordFound Then
        '        Me.Hide()
        '        FrmLandingForm.btnLogged.Text = "          " & GetrayzK("SELECT FNAME FROM TBL_USERS WHERE USERNAME = '" & TextBox1.Text & "' AND PASSWORD = '" & TextBox2.Text & "'")
        '        LoadForm(FrmLandingForm)

        '    Else
        '        MsgBox("Invalid user!", MsgBoxStyle.Critical)
        '        Exit Sub
        '    End If
        'Else
        '    MsgBox("Invalid user!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
        ''MsgBox("Product build part number: " & myBuildInfo.ProductBuildPart)
        'MsgBox("Product build part number: " & myBuildInfo.ProductVersion)

        'If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
        '    With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
        '        MsgBox("V" & .Major & "." & .Minor & "." & .Build & "." & .Revision)
        '    End With
        'End If
        'MsgBox(System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion.Revision)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        If GetRyzk("SELECT ID FROM TBL_USERS WHERE USERNAME = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", "L") = NoRecordFound Then
            MsgBox("Invalid user!", MsgBoxStyle.Critical)
            Exit Sub
        Else
            UserIdChangePass = GetRyzk("SELECT ID FROM TBL_USERS WHERE USERNAME = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", "L")
            FrmChangePass.lblID.Text = UserIdChangePass
        End If
        LoadForm(FrmChangePass, "CHANGE PASSWORD")
    End Sub
End Class