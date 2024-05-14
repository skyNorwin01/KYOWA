Imports System.Deployment.Application
Public Class LandingForm
    Public LogOutMode As Integer = 0
    Public Modeis As String = ""
    Public BookingTypeIs As String = ""
    Public ServiceIs As String = ""
    Dim doUpdate As Boolean = False
    Dim AD As ApplicationDeployment
    Private Sub LandingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btbInitialBookingFcl_Click(sender As Object, e As EventArgs) Handles btbInitialBookingFcl.Click
        Modeis = "NEW"
        BookingTypeIs = "F"
        LoadForm(FrmInitialBooking, "INITIAL BOOKING - FCL")


    End Sub

    Private Sub btnInitialBookingLcl_Click(sender As Object, e As EventArgs) Handles btnInitialBookingLcl.Click
        Modeis = "NEW"
        BookingTypeIs = "L"
        LoadForm(FrmInitialBooking, "INITIAL BOOKING - LCL")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ServiceIs = "I"
        LoadForm(FrmMenus, "IMPORT MENUS")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ServiceIs = "E"
        LoadForm(FrmMenus, "EXPORT MENUS")
    End Sub

    Private Sub btnBookingList_Click(sender As Object, e As EventArgs) Handles btnBookingList.Click
        Call LoadForm(FrmBookingList, "BOOKING LIST")
    End Sub

    Private Sub timerPanelNotif_Tick(sender As Object, e As EventArgs) Handles timerPanelNotif.Tick
        Try
            Dim info As UpdateCheckInfo = Nothing

            If (ApplicationDeployment.IsNetworkDeployed) Then
                AD = ApplicationDeployment.CurrentDeployment
                info = AD.CheckForDetailedUpdate()
                If (info.UpdateAvailable) Then
                    doUpdate = True

                    If (Not info.IsUpdateRequired) Then
                        pnlNotify.Visible = True
                        'Dim dr As DialogResult = MessageBox.Show("An update is available. Would you like to update the application now?", "Update Available", MessageBoxButtons.OKCancel)
                        'If (Not System.Windows.Forms.DialogResult.OK = dr) Then
                        '    doUpdate = False
                        'End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LBLUPDATE_Click(sender As Object, e As EventArgs) Handles LBLUPDATE.Click
        If (doUpdate) Then
            Try
                AD.Update()
                MessageBox.Show("The application has been upgraded, and will now restart.")
                Me.Dispose()
                Application.Restart()
            Catch dde As DeploymentDownloadException
                MessageBox.Show("Cannot install the latest version of the application. " & ControlChars.Lf & ControlChars.Lf & "Please check your network connection, or try again later.")
                Return
            End Try
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmUpdates.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        If MsgBox("Are you sure you want to logout?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            LogOutMode = 1
            End
        End If

    End Sub

    Private Sub LandingForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If LogOutMode = 0 Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub btnLogged_Click(sender As Object, e As EventArgs) Handles btnLogged.Click
        With cmsUsers
            .Show(btnLogged, 0, btnLogged.Height - 7)
        End With
    End Sub

    Private Sub btnEapproval_Click(sender As Object, e As EventArgs) Handles btnEapproval.Click
        Call LoadForm(FrmEapprovalList, "EAPPROVAL - LIST")
    End Sub
End Class