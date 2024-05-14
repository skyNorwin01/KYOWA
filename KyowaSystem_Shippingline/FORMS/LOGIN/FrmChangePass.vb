Public Class FrmChangePass
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If Not txtChangePassword.Text = txtConfirmPassword.Text Then
            MsgBox("Password Mismatch!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to change password?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_USERS SET PASSWORD = '" & Replace(Trim(txtChangePassword.Text), "'", "''") & "', ChangePasswordDate = '" & Now & "' WHERE ID = '" & lblID.Text & "' ")
            MsgBox("Password Changed!", MsgBoxStyle.Information)
            End
        End If


    End Sub

    Private Sub FrmChangePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class