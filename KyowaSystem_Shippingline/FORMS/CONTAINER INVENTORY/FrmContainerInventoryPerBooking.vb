Public Class FrmContainerInventoryPerBooking
    Private Sub FrmContainerInventoryPerBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtList.Columns(dtList.ColumnCount - 1).DisplayIndex = 0
        dtList.Columns(0).Visible = False
        lblSysref.Text = Me.Tag
        Call LoadList(Me.Tag)
    End Sub

    Public Sub LoadList(BKNO As String)
        Dim cntr As Integer = 1
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = " SELECT id, BookingNo, CONTAINER_NO, CONTAINER_TYPE, ArrivalManila, StatusOfContainer, ReturnToDepot, Remarks, Shipper, ContainerPullOut FROM TBL_CONTAINER_INVENTORY where BookingNo = '" & BKNO & "' ORDER BY ID ASC"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read
                Dim ArrivalManila = "", ReturnToDepot = "", ContainerPullout As String = ""
                ArrivalManila = Dbo.reader(4).ToString
                ReturnToDepot = Dbo.reader(6).ToString
                ContainerPullout = Dbo.reader(9).ToString

                If Not String.IsNullOrEmpty(ArrivalManila) Then
                    ArrivalManila = Format(CDate(Dbo.reader(4).ToString), "MM/dd/yyyy")
                End If
                If Not String.IsNullOrEmpty(ReturnToDepot) Then
                    ReturnToDepot = Format(CDate(Dbo.reader(6).ToString), "MM/dd/yyyy")
                End If
                If Not String.IsNullOrEmpty(ContainerPullout) Then
                    ContainerPullout = Format(CDate(Dbo.reader(9).ToString), "MM/dd/yyyy")
                End If




                .Rows.Add(Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, ArrivalManila, Dbo.reader(5).ToString, ReturnToDepot, Dbo.reader(7).ToString, Dbo.reader(8).ToString, ContainerPullout, cntr)
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(0).ToString
                cntr += 1
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()


    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    Private Sub dtList_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellEndEdit

    End Sub

    Private Sub dtList_KeyDown(sender As Object, e As KeyEventArgs) Handles dtList.KeyDown
        If e.KeyCode = Keys.Space Then
            Call LoadStrCleint(FrmContainerInventoryEditRow.cmbReleasetoShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")

            With FrmContainerInventoryEditRow
                .txtSize.Text = dtList.CurrentRow.Cells(2).Value
                .mtxtArrivalMnl.Text = dtList.CurrentRow.Cells(3).Value
                .cmbContainerStats.Text = dtList.CurrentRow.Cells(4).Value
                .mtxtReturdToDepot.Text = dtList.CurrentRow.Cells(5).Value
                .cmbRemarks.Text = dtList.CurrentRow.Cells(6).Value
                .cmbReleasetoShipper.Text = dtList.CurrentRow.Cells(7).Value
                .mtxtPullout.Text = dtList.CurrentRow.Cells(8).Value
                .Tag = dtList.CurrentRow.Cells(0).Tag
                .txtSize.Focus()
            End With


            LoadForm(FrmContainerInventoryEditRow, dtList.CurrentRow.Cells(1).Value)

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If dtList.RowCount = 0 Then
            FrmAddManualContainer.lblSysref.Text = "IMP-" & Format(Now, "MMddyyHHmmssfff")
        Else
            FrmAddManualContainer.lblSysref.Text = lblSysref.Text
        End If
        LoadForm(FrmAddManualContainer, "ADD IMPORT CONTAINERS")
    End Sub

    Private Sub FrmContainerInventoryPerBooking_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Call FrmContainerInventoryList.LoadList(FrmContainerInventoryList.txtValue.Text)
        Me.Dispose()
    End Sub
End Class