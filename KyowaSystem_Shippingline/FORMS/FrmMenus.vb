Public Class FrmMenus

    Public IsForTemplateOnly As String = ""
    Private Sub btbInitialBookingFcl_Click(sender As Object, e As EventArgs) Handles btbInitialBookingFcl.Click
        LandingForm.Modeis = "NEW"
        LandingForm.BookingTypeIs = "F"
        With FrmInitialBooking
            .lblBookingInfo.Text = "INITIAL BOOKING DETAILS"
            .pnlCS.Visible = True
            .PnlOperations.Visible = False
            .pnlCS.Left = 10
            .Width = 655
        End With
        LoadForm(FrmInitialBooking, "INITIAL BOOKING - FCL")
    End Sub

    Private Sub btnInitialBookingLcl_Click(sender As Object, e As EventArgs) Handles btnInitialBookingLcl.Click
        LandingForm.Modeis = "NEW"
        LandingForm.BookingTypeIs = "L"
        With FrmInitialBooking
            .lblBookingInfo.Text = "INITIAL BOOKING DETAILS"
            .pnlCS.Visible = True
            .PnlOperations.Visible = False
            .pnlCS.Left = 10
            .Width = 655
        End With
        LoadForm(FrmInitialBooking, "INITIAL BOOKING - LCL")
    End Sub

    Private Sub btnBookingList_Click(sender As Object, e As EventArgs) Handles btnBookingList.Click
        FrmBookingList.dtFrom.Value = DateAdd(DateInterval.Day, -20, FrmBookingList.dtTo.Value)
        Call LoadForm(FrmBookingList, "BOOKING LIST")
    End Sub

    Private Sub btnMaintenance_Click(sender As Object, e As EventArgs) Handles btnMaintenance.Click


        With cmsMaintenance
            .Show(sender, 0, 0 - cmsMaintenance.Height)
        End With


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        LoadForm(FrmAddShipperConsigneeNotify, cmsMaintenance.Items(0).Text)
    End Sub

    Private Sub VESSELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VESSELToolStripMenuItem.Click
        LoadForm(FrmAddVessel, cmsMaintenance.Items(1).Text)
    End Sub

    Private Sub PORTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PORTSToolStripMenuItem.Click
        LoadForm(FrmAddPort, cmsMaintenance.Items(2).Text)
    End Sub

    Private Sub TRUCKERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TRUCKERToolStripMenuItem.Click
        LoadForm(FrmTrucker, cmsMaintenance.Items(3).Text)
    End Sub

    Private Sub DEPOTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DEPOTToolStripMenuItem.Click
        LoadForm(FrmAddDepot, cmsMaintenance.Items(4).Text)
    End Sub

    Private Sub OUTPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OUTPORTToolStripMenuItem.Click
        LoadForm(FrmAddOutPort, cmsMaintenance.Items(5).Text)
    End Sub

    Private Sub LEASINGCONTAINERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LEASINGCONTAINERSToolStripMenuItem.Click
        LoadForm(FrmAddLeasing, cmsMaintenance.Items(6).Text)
    End Sub

    Private Sub CHARGESTEMPLATESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHARGESTEMPLATESToolStripMenuItem.Click
        IsForTemplateOnly = "Y"
        frmSetCharges.pnlSettingsTemplate.Visible = True
        frmSetCharges.btnImportTemplateRates.Enabled = False
        LoadForm(frmSetCharges, cmsMaintenance.Items(7).Text)
    End Sub

    Private Sub FEEDERCARRIERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FEEDERCARRIERToolStripMenuItem.Click
        LoadForm(FrmAddFeederCarrier, cmsMaintenance.Items(8).Text)
    End Sub

    Private Sub CURRENCYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CURRENCYToolStripMenuItem.Click
        LoadForm(FrmAddCurrency, "ADD CURRENCY")
    End Sub

    Private Sub CHARGESTABLEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHARGESTABLEToolStripMenuItem.Click
        LoadForm(FrmAddCharges, "ADD CHARGES")
    End Sub

    Private Sub CONFIGURESPECIALCHARGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONFIGURESPECIALCHARGESToolStripMenuItem.Click
        LoadForm(frmAddSpecialCharges, "CONFIGURE SPECIAL CHARGES")
    End Sub
End Class