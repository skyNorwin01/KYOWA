
Public Class FrmInitialBooking

    Public EditContainersMode As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub LoadCommodity()
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT DISTINCT Commodity FROM TBL_BOOKING WHERE STAT = '1'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With cmbCommodity.Items
            .Clear()
            Do While Dbo.reader.Read
                .Add(Dbo.reader(0).ToString)
            Loop
        End With

        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Private Sub FrmInitialBooking_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'DOUBLE_CHECK_TRUCKER_DI_LUMALABAS
        btnAdd.ImageIndex = 0



        With cmbGeneralOrDg.Items
            .Clear()
            .Add("GENERAL")
            .Add("DANGEROUS")
        End With

        With cmbServiceType.Items
            .Clear()
            .Add("CY/CY")
            .Add("CFS")
        End With
        With cmbPkgType.Items
            .Clear()
            .Add("PKGS")
            .Add("CASES")
            .Add("BOXES")
            .Add("CNTR")
        End With
        With cmbContSize.Items
            .Clear()
            .Add("10DC")
            .Add("20DC")
            .Add("40DC")
            .Add("40HQ")
            .Add("20RF")
            .Add("40RF")
            .Add("CBM")
            .Add("KGS")
            .Add("20FR")
            .Add("40FR")
        End With
        With cmbCargoWeight.Items
            .Clear()
            .Add("24.5 TONS/40'HQ")
            .Add("22 TONS/20'DC")
        End With

        With CmbOptionPort.Items
            .Clear()
            .Add("MANILA:")
            .Add("OUTPORT:")
        End With

        With CmbTransipment.Items
            .Clear()
            .Add("SINGLE TRANSSHIPMENT")
            .Add("DUAL TRANSSHIPMENT")
        End With

        Call LoadCommodity()

        If LandingForm.Modeis = "NEW" Then
            lblSysref.Text = "SYS" & Format(Now, "MMddyyHHmmssfff")
            'Dim sql As String = "Select PARAM2 + PARAM1 +'-'+ PARAM3 FROM TBL_REFERENCE WHERE PARAM2 = 'BKN' AND PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L") & Format(CDbl(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'BKN' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")), "00000") & "-" & GetRyzk("SELECT YR FROM TBL_REFERENCE  WHERE PARAM2 = 'BKN' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'"
            'Dim sql As String = "Select PARAM2 + PARAM1 +'-'+ PARAM3 FROM TBL_REFERENCE WHERE PARAM2 = 'BKN' AND PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'"


            txtBKNO.Text = GetRyzk("SELECT PARAM2 + PARAM1 +'-'+ PARAM3 FROM TBL_REFERENCE WHERE PARAM2 = 'BKN' AND PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L") & Format(CDbl(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'BKN' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")), "00000") & "-" & GetRyzk("SELECT YR FROM TBL_REFERENCE  WHERE PARAM2 = 'BKN' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
            pnlOperatinHours.Visible = True
            Call LoadAll()
        ElseIf LandingForm.Modeis = "REBOOK" Then
            lblSysref.Text = "SYS" & Format(Now, "MMddyyHHmmssfff")
            txtBKNO.Text = GetRyzk("SELECT PARAM2 + PARAM1 +'-'+ PARAM3 FROM TBL_REFERENCE WHERE PARAM2 = 'BKN' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L") & Format(CDbl(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'BKN' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")), "00000") & "-" & GetRyzk("SELECT YR FROM TBL_REFERENCE  WHERE PARAM2 = 'BKN' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
            pnlOperatinHours.Visible = True
            txtNewBKNO.Text = txtBKNO.Text
            'Call LoadAll()
        ElseIf LandingForm.Modeis = "NEW OPERATIONS" Then
            Call LoadOperationsCmb()
        ElseIf LandingForm.Modeis = "EDIT" Then
            'Call LoadAll()
            'Call LoadAll()
            'Call LoadOperationsCmb()


        ElseIf LandingForm.Modeis = "VIEW" Then

        End If


        If Microsoft.VisualBasic.Left(txtBKNO.Text, 4) = "BKNI" Then
            TabPage1.Text = "Return"
            TabPage2.Enabled = False
        Else
            TabPage1.Text = "Depot"
            TabPage2.Enabled = True
        End If

        dtContainers.Columns(10).DisplayIndex = 6
    End Sub



    Public Sub LoadStrDepot(cmb As ComboBox, SQL As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
        Dbo.table = New DataTable
        Dbo.adapter.Fill(Dbo.table)

        Dbo.reader = Dbo.SQLCmd.ExecuteReader

        Dim _Depot As New List(Of Depot)

        Do While Dbo.reader.Read
            _Depot.Add(New Depot With {.Id = Dbo.reader(0).ToString, .Name = Dbo.reader(1).ToString, .AddressIs = Dbo.reader(2).ToString})
        Loop
        cmb.DataSource = _Depot
        cmb.DisplayMember = Dbo.table.Columns(1).ToString
        cmb.ValueMember = Dbo.table.Columns(0).ToString
        cmb.Text = ""
        cmb.SelectedIndex = -1
        Dbo.SqlCon.Close()
    End Sub

    Public Sub LoadOperationsCmb()
        Call LoadDepot(cmbDepot, "SELECT ID, NAME, ADDRESSIS, OperatingHrsStart, OperatingHrsEnd, Telno FROM TBL_DEPOT WHERE STAT = '1'")
        Call LoadStrCmb(cmbDeliveryPort, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY NAME ASC")
        Call LoadStrCmb(cmbTrucker, "SELECT ID, TRUCKER FROM TBL_TRUCKER WHERE STAT = '1'")
        txtTruckerId.Text = ""
        txtDepotId.Text = ""
        txtDeportAddress.Text = ""
        cmbTrucker.SelectedIndex = -1
        txtTelNo.Text = ""
    End Sub

    'Public Sub LoadStrCleintShipperAndConsignee()
    '    Dim Dbo As New SQLClass
    '    Dbo.SqlCon.Open()
    '    SQL = "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> '' ORDER BY CLIENTNAME ASC"
    '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
    '    Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
    '    Dbo.table = New DataTable
    '    Dbo.adapter.Fill(Dbo.table)

    '    Dbo.reader = Dbo.SQLCmd.ExecuteReader

    '    Dim _Client As New List(Of Client)

    '    Do While Dbo.reader.Read
    '        _Client.Add(New Client With {.ID = KVal(Dbo.reader(0).ToString), .CLIENTNAME = KVal(Dbo.reader(1).ToString), .Address = KVal(Dbo.reader(2).ToString)})
    '    Loop

    '    With cmbShipper
    '        .DataSource = _Client
    '        .DisplayMember = Dbo.table.Columns(1).ToString
    '        .ValueMember = Dbo.table.Columns(0).ToString
    '        .Text = ""
    '        .SelectedIndex = -1
    '    End With
    '    With cmbConsignee
    '        .DataSource = _Client
    '        .DisplayMember = Dbo.table.Columns(1).ToString
    '        .ValueMember = Dbo.table.Columns(0).ToString
    '        .Text = ""
    '        .SelectedIndex = -1
    '    End With
    '    With cmbNotify
    '        .DataSource = _Client
    '        .DisplayMember = Dbo.table.Columns(1).ToString
    '        .ValueMember = Dbo.table.Columns(0).ToString
    '        .Text = ""
    '        .SelectedIndex = -1
    '    End With




    '    Dbo.SqlCon.Close()
    'End Sub

    Public Sub LoadAll()


        'Dbo.SqlAcctgCon.Open()
        'SQL = "SELECT CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  + ' - ' + CARDCODE, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0'   ORDER BY CARDNAME"
        'Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlAcctgCon)
        'Dbo.reader = Dbo.SQLCmd.ExecuteReader
        'With cmbName.Items
        '    .Clear()
        '    Do While Dbo.reader.Read
        '        .Add(Dbo.reader(0).ToString)
        '    Loop
        'End With
        'Dbo.reader.Close()
        'Dbo.SqlAcctgCon.Close()

        'Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  + ' - ' + CARDCODE, Address FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0'   ORDER BY CARDNAME")
        ''Call LoadStrCleintAcctg(cmbShipper, "SELECT  ID, ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")


        'Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  + ' - ' + CARDCODE, Address FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0'   ORDER BY CARDNAME")
        'Call LoadStrCleintAcctg(cmbNotify, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  + ' - ' + CARDCODE, Address FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0'   ORDER BY CARDNAME")

        'If txtBKNO.Text.Contains("BKNE") Then
        '    Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
        '    Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
        'ElseIf txtBKNO.Text.Contains("BKNI") Then
        '    Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
        '    Call LoadStrCleint(cmbShipper, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
        'End If

        'abc
        If LandingForm.Modeis = "EDIT" Then
            If FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            ElseIf FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNI") Then
                Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbShipper, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            End If
        ElseIf LandingForm.Modeis = "NEW" Then
            If txtBKNO.Text.Contains("BKNE") Then
                Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            ElseIf txtBKNO.Text.Contains("BKNI") Then
                Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbShipper, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            End If
        ElseIf LandingForm.Modeis = "REBOOK" Then
            If FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            Else
                Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbShipper, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            End If
            'If txtBKNO.Text.Contains("BKNE") Then
            '    Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
            '    Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            'ElseIf txtBKNO.Text.Contains("BKNI") Then
            '    Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
            '    Call LoadStrCleint(cmbShipper, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            'End If
        ElseIf LandingForm.Modeis = "VIEW" Then
            If FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                Call LoadStrCleintAcctg(cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            ElseIf FrmBookingList.dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNI") Then
                Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                Call LoadStrCleint(cmbShipper, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
            End If

        End If



        'Call LoadStrCleintAcctg(cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
        'Call LoadStrCleintAcctg(cmbNotify, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")


        'Call LoadStrCleint(cmbShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")

        Call LoadStrCleint(cmbNotify, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")

        Call LoadStrCmbTrade(cmbTrade, "SELECT ID, NAME  FROM TBL_TRADE WHERE STAT = '1'")
        Call LoadStrCmb(cmbOutPort, "SELECT ID, OUTPORT FROM TBL_OUTPORT WHERE STAT = '1'")

        Call LoadStrCmb(cmbFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")

        Call LoadStrCmb(cmb2ndFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")

        Call LoadStrCmb(cmbMotherVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")

        Call LoadStrCmb(cmbTrucker, "SELECT ID, TRUCKER FROM TBL_TRUCKER WHERE STAT = '1'")

        'Call LoadStrCmbWithSame("SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1'" & IIf(LandingForm.ServiceIs = "I", " AND iSTAT = 1", " AND ESTAT = 1"))
        Dim xsql As String = "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE " & IIf(LandingForm.ServiceIs = "I", "  iSTAT = 1", " AND ESTAT = 1")
        Call LoadStrCmb(cmbLoading1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE  " & IIf(LandingForm.ServiceIs = "I", "  iSTAT = 1", "  ESTAT = 1"))
        Call LoadStrCmb(cmbLoading2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE  " & IIf(LandingForm.ServiceIs = "I", "  iSTAT = 1", "  ESTAT = 1"))
        Call LoadStrCmb(CmbMotherVesselLoading, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE " & IIf(LandingForm.ServiceIs = "I", "  iSTAT = 1", "  ESTAT = 1"))
        Call LoadStrCmb(CmbPOD1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE " & IIf(LandingForm.ServiceIs = "I", "  iSTAT = 1", "  ESTAT = 1"))
        Call LoadStrCmb(cmbPOD2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE " & IIf(LandingForm.ServiceIs = "I", "  iSTAT = 1", "  ESTAT = 1"))



        With cmbTagging.Items
            .Clear()
            .Add("N/A")
            .Add("INTERNAL")
        End With
        'Call LoadStrCleint(cmbShipper, "SELECT  ID , ClientName, Clientaddress  FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
        'Call LoadStrCleint(cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> '' ORDER BY CLIENTNAME ASC")
        'Call LoadStrCleint(cmbNotify, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> '' ORDER BY CLIENTNAME ASC")

        'Call LoadStrCmbTrade(cmbTrade, "SELECT ID, NAME  FROM TBL_TRADE WHERE STAT = '1' ORDER BY NAME ASC")
        'Call LoadStrCmb(cmbOutPort, "SELECT ID, OUTPORT FROM TBL_OUTPORT WHERE STAT = '1' ORDER BY OUTPORT ASC")

        'Call LoadStrCmb(cmbFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1' ORDER BY VESSELNAME ASC")
        'Call LoadStrCmb(cmbLoading1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY NAME ASC")
        'Call LoadStrCmb(cmb2ndFeederVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1' ORDER BY VESSELNAME ASC")
        'Call LoadStrCmb(cmbLoading2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY NAME ASC")
        'Call LoadStrCmb(cmbMotherVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1' ORDER BY VESSELNAME ASC")
        'Call LoadStrCmb(CmbMotherVesselLoading, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY NAME ASC")
        'Call LoadStrCmb(cmbTrucker, "SELECT ID, TRUCKER FROM TBL_TRUCKER WHERE STAT = '1' ORDER BY TRUCKER ASC")
        'Call LoadStrCmb(CmbPOD1, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY NAME ASC")
        'Call LoadStrCmb(cmbPOD2, "SELECT ID, NAME FROM TBL_LOADING_UNLOADING_PORT WHERE STAT = '1' ORDER BY NAME ASC")

        txtShipperId.Text = ""
        txtFeederId.Text = ""
        txtMotherVesselId.Text = ""
        txtLoadingCode.Text = ""
        txtTruckerId.Text = ""
        cmbTrade.Text = ""
        txtTradeId.Text = ""
        cmbTrade.Tag = ""
        cmbSubTrade.Tag = ""
        cmbPorts.Tag = ""
        cmbOutPort.SelectedIndex = -1
        CmbOptionPort.Text = "OUTPORT:"

    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If EditContainersMode = "Y" Then
            dtContainers.Rows.Remove(dtContainers.CurrentRow)
            EditContainersMode = ""
        End If
        With dtContainers
            .Rows.Add(txtContCount.Text, KVal(cmbContSize.Text), KVal(txtContNo.Text), KVal(txtSealNo.Text), KVal(cmbLoadingPlace.Text), Format(CDate(dtPulloutDateTime.Value), "MM/dd/yyyy HH:mm"), KVal(txtCount.Text), KVal(cmbPkgType.Text), KVal(txtContKgs.Text), KVal(txtContCbm.Text), Format(CDate(DtGateInDate.Value), "MM/dd/yyyy HH:mm"), KVal(txtVGM.Text), KVal(cmbGeneralOrDg.Text))
        End With
        btnAdd.ImageIndex = 0
        btnContCancel.Visible = False
        dtContainers.Enabled = True

    End Sub

    Private Sub btnAddTrucker_Click(sender As Object, e As EventArgs) Handles btnAddTrucker.Click

        If String.IsNullOrEmpty(txtTruckerId.Text) Then
            Exit Sub
        End If
        For i As Integer = 0 To dtTrucker.RowCount - 1
            If KVal(dtTrucker.Rows(i).Cells(1).Value) = KVal(cmbTrucker.Text) Then
                MsgBox("Trucker already existing!", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Next
        With dtTrucker
            .Rows.Add(txtTruckerId.Text, KVal(cmbTrucker.Text))
            dtTrucker.FirstDisplayedScrollingRowIndex = dtTrucker.RowCount - 1
        End With
    End Sub

    Private Sub dtContainers_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtContainers.CellContentClick
        If LandingForm.Modeis = "VIEW" Then
            MsgBox("Unable to edit due to view mode only", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If e.ColumnIndex = 13 Then
            If MsgBox("Delete this container?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtContainers.Rows.Remove(dtContainers.CurrentRow)
            End If
        End If
        If e.ColumnIndex = 14 Then
            EditContainersMode = "Y"
            btnAdd.ImageIndex = 1
            btnContCancel.Visible = True
            dtContainers.Enabled = False
            cmbContSize.Text = dtContainers.CurrentRow.Cells(1).Value
            txtContNo.Text = dtContainers.CurrentRow.Cells(2).Value
            txtSealNo.Text = dtContainers.CurrentRow.Cells(3).Value
            cmbLoadingPlace.Text = dtContainers.CurrentRow.Cells(4).Value
            dtPulloutDateTime.Value = dtContainers.CurrentRow.Cells(5).Value
            txtCount.Text = dtContainers.CurrentRow.Cells(6).Value
            cmbPkgType.Text = dtContainers.CurrentRow.Cells(7).Value
            txtContKgs.Text = dtContainers.CurrentRow.Cells(8).Value
            txtContCbm.Text = dtContainers.CurrentRow.Cells(9).Value
            DtGateInDate.Value = dtContainers.CurrentRow.Cells(10).Value
            txtVGM.Text = dtContainers.CurrentRow.Cells(11).Value
            cmbGeneralOrDg.Text = dtContainers.CurrentRow.Cells(12).Value

        End If
    End Sub

    Private Sub dtTrucker_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtTrucker.CellContentClick
        If LandingForm.Modeis = "VIEW" Then
            MsgBox("Unable to edit due to view mode only", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        If e.ColumnIndex = 2 Then
            If MsgBox("Delete this trucker?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                dtTrucker.Rows.Remove(dtTrucker.CurrentRow)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub



    Private Sub cmbShipper_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbShipper.SelectedIndexChanged, cmbShipper.TextChanged
        'If FrmBookingList.ActionMode = "EDIT" Then
        'If txtBKNO.Text.Contains("BKNE") Then
        '    With txtShipperId
        '        If sender.text = "" Then
        '            .Text = ""
        '            txtShipperAddress.Text = ""
        '            Exit Sub
        '        End If
        '        txtShipperAddress.Text = CType(sender.SelectedItem, Client).Address
        '        .Text = CType(sender.SelectedItem, Client).CardCode
        '        '.Text = Format(CInt(CType(sender.SelectedItem, Client).BPListID), "00000")
        '    End With
        'ElseIf txtBKNO.Text.Contains("BKNI") Then
        '    With txtShipperId
        '        If sender.text = "" Then
        '            .Text = ""
        '            txtShipperAddress.Text = ""
        '            Exit Sub
        '        End If
        '        txtShipperAddress.Text = CType(sender.SelectedItem, ClientKY).Clientaddress
        '        .Text = Format(CInt(CType(sender.SelectedItem, ClientKY).ID), "00000")
        '        '.Text = CType(sender.SelectedItem, ClientKY).ID
        '        '.Text = Format(CInt(CType(sender.SelectedItem, Client).BPListID), "00000")
        '    End With
        'End If
        'Else
        If txtBKNO.Text.Contains("BKNE") Then
                With txtShipperId
                    If sender.SelectedIndex = -1 Then
                        .Text = ""
                        txtShipperAddress.Text = ""
                        Exit Sub
                    End If
                    txtShipperAddress.Text = CType(sender.SelectedItem, Client).Address
                    .Text = CType(sender.SelectedItem, Client).CardCode
                    '.Text = Format(CInt(CType(sender.SelectedItem, Client).BPListID), "00000")
                End With
            ElseIf txtBKNO.Text.Contains("BKNI") Then
                With txtShipperId
                    If sender.SelectedIndex = -1 Then
                        .Text = ""
                        txtShipperAddress.Text = ""
                        Exit Sub
                    End If
                    txtShipperAddress.Text = CType(sender.SelectedItem, ClientKY).Clientaddress
                    .Text = Format(CInt(CType(sender.SelectedItem, ClientKY).ID), "00000")
                    '.Text = CType(sender.SelectedItem, ClientKY).ID
                    '.Text = Format(CInt(CType(sender.SelectedItem, Client).BPListID), "00000")
                End With
            End If
        'End If




    End Sub

    Public Sub cmbShipper_LostFocus(sender As Object, e As EventArgs) Handles cmbShipper.LostFocus
        'txtShipperAddress.Text = GetRyzk("SELECT CLIENTADDRESS  FROM TBL_CLIENT WHERE CLIENTNAME = '" & KVal(cmbShipper.Text) & "'", "L")
        'txtShipperId.Text = Format((CDbl(GetRyzk("SELECT ID FROM TBL_CLIENT WHERE CLIENTNAME = '" & KVal(cmbShipper.Text) & "'", "L"))), "00000")
    End Sub

    Private Sub cmbConsignee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbConsignee.SelectedIndexChanged, cmbConsignee.TextChanged
        If txtBKNO.Text.Contains("BKNE") Then
            With txtConsigneeId
                If sender.SelectedIndex = -1 Then
                    .Text = ""
                    txtConsigneeAddress.Text = ""
                    Exit Sub
                End If
                txtConsigneeAddress.Text = CType(sender.SelectedItem, ClientKY).Clientaddress
                .Text = Format(CInt(CType(sender.SelectedItem, ClientKY).ID), "00000")
            End With
        ElseIf txtBKNO.Text.Contains("BKNI") Then
            With txtConsigneeId
                If sender.SelectedIndex = -1 Then
                    .Text = ""
                    txtConsigneeAddress.Text = ""
                    Exit Sub
                End If
                txtConsigneeAddress.Text = CType(sender.SelectedItem, client).Address
                .Text = CType(sender.SelectedItem, Client).CardCode
            End With
        End If




    End Sub

    Public Sub cmbConsignee_LostFocus(sender As Object, e As EventArgs) Handles cmbConsignee.LostFocus
        'txtConsigneeAddress.Text = GetRyzk("SELECT CLIENTADDRESS FROM TBL_CLIENT WHERE CLIENTNAME = '" & KVal(cmbConsignee.Text) & "'", "L")
        'txtConsigneeId.Text = Format((CDbl(GetRyzk("SELECT ID FROM TBL_CLIENT WHERE CLIENTNAME = '" & KVal(cmbConsignee.Text) & "'", "L"))), "00000")

    End Sub

    Private Sub cmbNotify_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNotify.SelectedIndexChanged, cmbNotify.TextChanged
        With txtNotifyID
            If sender.SelectedIndex = -1 Then
                .Text = ""
                txtNotifyAddress.Text = ""
                Exit Sub
            End If
            txtNotifyAddress.Text = CType(sender.SelectedItem, ClientKY).Clientaddress
            .Text = Format(CInt(CType(sender.SelectedItem, ClientKY).ID), "00000")
            '.Text = Format(CInt(CType(sender.SelectedItem, Client).BPListID), "00000")
        End With

    End Sub

    Public Sub cmbNotify_LostFocus(sender As Object, e As EventArgs) Handles cmbNotify.LostFocus
        'txtNotifyAddress.Text = GetRyzk("SELECT CLIENTADDRESS  FROM TBL_CLIENT WHERE CLIENTNAME = '" & KVal(cmbNotify.Text) & "'", "L")
        'txtNotifyID.Text = Format((CDbl(GetRyzk("SELECT ID FROM TBL_CLIENT WHERE CLIENTNAME = '" & KVal(cmbNotify.Text) & "'", "L"))), "00000")

    End Sub

    Public Sub SaveDetailsOperations(SYSREF, BKNO, DEPOT, ReleasingChecker, OperatingHrs, EtaMnl, EtdMnl, CLosingStartTime, ClosingEndTime, ViaPort, ArrastreCutoff, MaxCargo, AddedBy, DateAdded, Stat, TelNo, DeliveryPort)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_OPERATIONS (SYSREF, BKNO, DEPOT, ReleasingChecker, OperatingHrs, EtaMnl, EtdMnl, CLosingStartTime, ClosingEndTime, ViaPort, ArrastreCutoff, MaxCargo, AddedBy, DateAdded, Stat, TelNo, DeliveryPort )"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(BKNO) & "',  '" & KVal(DEPOT) & "',  '" & KVal(ReleasingChecker) & "',  '" & KVal(OperatingHrs) & "',  '" & KVal(EtaMnl) & "',  '" & KVal(EtdMnl) & "',  '" & KVal(CLosingStartTime) & "',  '" & KVal(ClosingEndTime) & "',  '" & KVal(ViaPort) & "',  '" & KVal(ArrastreCutoff) & "',  '" & KVal(MaxCargo) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "', '" & KVal(TelNo) & "', '" & KVal(DeliveryPort) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub SaveTruckerOperations(SYSREF, BKNO, TRUCKER, AddedBy, DateAdded, Stat)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_TRUCKER_OPERATIONS (SYSREF, BKNO, TRUCKER, AddedBy, DateAdded, Stat)"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(BKNO) & "',  '" & KVal(TRUCKER) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click

        Dim StatIs As String = FrmBookingList.dtList.CurrentRow.Cells(2).Tag
        Dim BLNO = "", REFNO As String = ""

        If LandingForm.Modeis = "NEW_OPERATIONS" Then
            If MsgBox("Are you sure you want to save this operation details?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SaveDetailsOperations(lblSysref.Text, txtBKNO.Text, txtDepotId.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, dtEtaDate.Value, dtEtdDate.Value, dtClosingEndTime.Value, dtClosingEndTime.Value, txtViaPort.Text, dtArrastreCutoff.Value, cmbCargoWeight.Text, USER_ID, Now, StatIs, txtTelNo.Text, txtDeliveryPort.Text)
                With dtContainers
                    For i As Integer = 0 To .RowCount - 1
                        Call SaveContainers(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, StatIs, dtDate.Value, Now, USER_ID, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, SaveMoney(.Rows(i).Cells(6).Value), .Rows(i).Cells(7).Value, .Rows(i).Cells(8).Value, .Rows(i).Cells(9).Value, .Rows(i).Cells(10).Value, .Rows(i).Cells(11).Value, .Rows(i).Cells(12).Value)
                    Next
                End With
                With dtTrucker
                    For i As Integer = 0 To .RowCount - 1
                        Call SaveTruckerOperations(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, USER_ID, Now, StatIs)
                    Next
                End With
                MsgBox("Successfully saved!", MsgBoxStyle.Information)
                Me.Dispose()
            End If
            Exit Sub
        End If
        If MsgBox("Are you sure you want to modify this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            SelRefno = FrmBookingList.dtList.CurrentRow.Cells(24).Value
            selBLno = FrmBookingList.dtList.CurrentRow.Cells(25).Value

            Dim TermIs As String = ""
            If rdCollect.Checked = True Then
                TermIs = "C"
            ElseIf rdPrepaid.Checked = True Then
                TermIs = "P"
            End If


            'Call SetJob("UPDATE TBL_BOOKING SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
            'Call SAVEBookingRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtOutportId.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, cmbFeederVoyage1.Text, txtLoadingCode.Text, txt2ndFeederID.Text, cmbFeederVoyage2.Text, txtLoading2Code.Text, txtMotherVesselId.Text, cmbMotherVoyage.Text, txtMotherVesselLoadingCode.Text, cmbTrade.Tag, cmbSubTrade.Tag, cmbPorts.Tag, txtNumbersDesc.Text, txtKgs.Text, txtCbm.Text, txtOutportId.Text, TermIs, USER_ID, Now, StatIs, txtPOD1COde.Text, txtPOD2Code.Text, Microsoft.VisualBasic.Left(CmbTransipment.Text, 1), cmbCommodity.Text, selBLno, SelRefno, cmbPayableAt.Text)
            'Dim CurSeries As Integer = 0
            'CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
            'Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'")

            Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
            Call SaveDetailsOperations(lblSysref.Text, txtBKNO.Text, txtDepotId.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, dtEtaDate.Value, dtEtdDate.Value, dtClosingEndTime.Value, dtClosingEndTime.Value, txtViaPort.Text, dtArrastreCutoff.Value, cmbCargoWeight.Text, USER_ID, Now, StatIs, txtTelNo.Text, txtDeliveryPort.Text)

            Call SetJob("UPDATE TBL_CONTAINER SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
            With dtContainers
                For i As Integer = 0 To .RowCount - 1
                    Call SaveContainers(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, StatIs, dtDate.Value, Now, USER_ID, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, SaveMoney(.Rows(i).Cells(6).Value), .Rows(i).Cells(7).Value, .Rows(i).Cells(8).Value, .Rows(i).Cells(9).Value, .Rows(i).Cells(10).Value, .Rows(i).Cells(11).Value, .Rows(i).Cells(12).Value)
                Next
            End With

            Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
            With dtTrucker
                For i As Integer = 0 To .RowCount - 1
                    Call SaveTruckerOperations(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, USER_ID, Now, StatIs)
                Next
            End With


            'Call SetJob("UPDATE TBL_BOOKING SET  STAT = '4' , REASON = '" & KVal(FrmReasons.cmbReasons.Text) & "', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
            'Call SetJob("UPDATE TBL_BOOKING SET STAT = '4' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
            ' Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '4', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
            Call FrmBookingList.FrmBookingList_Load(e, e)





            MsgBox("Successfully modified!", MsgBoxStyle.Information)
            FrmReasons.Dispose()
            Me.Dispose()
            Exit Sub
        End If



        'If LandingForm.Modeis = "NEW" Then
        '    If MsgBox("Are you sure you want to save this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Call SaveBookingDetails(lblSysref.Text, lblBkNo.Text, cmbShipper.Text, txtShipperAddress.Text, cmbConsignee.Text, txtConsigneeAddress.Text, cmbNotify.Text, txtNotifyAddress.Text, cmbFeederVessel.Text, cmbMotherVessel.Text, cmbDestination.Text, txtMarksDesc.Text, dtPullOut.Value, cmbStuffingLoadingPlace.Text, "INITIAL", "1", dtDate.Value, Now, USER_ID, cmbDepot.Text, txtDeportAddress.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, txtEtaMnl.Text, txtClosingTime.Text, txtViaPort.Text, cmbLoading.Text, txtRemarks.Text)
        '        With dtContainers
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveContainers(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(2).Value, "1", dtDate.Value, Now, USER_ID)
        '            Next
        '        End With

        '        With dtTrucker
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveTrucker(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(1).Value, "1", dtDate.Value, Now, USER_ID)
        '            Next
        '        End With
        '        Dim CurSeries As Integer = 0
        '        CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
        '        Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'")
        '        FrmBookingList.Search(FrmBookingList.dtFrom.Value, FrmBookingList.dtTo.Value)
        '        MsgBox("Saved!", MsgBoxStyle.Information)
        '        LandingForm.Modeis = ""
        '        Me.Dispose()
        '    End If
        'Else
        '    If MsgBox("Are you sure you want to update this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Call SetJob("UPDATE TBL_BOOKING SET STAT = '2' WHERE STAT = '1' AND  SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & lblBkNo.Text & "'")
        '        Call SaveBookingDetails(lblSysref.Text, lblBkNo.Text, cmbShipper.Text, txtShipperAddress.Text, cmbConsignee.Text, txtConsigneeAddress.Text, cmbNotify.Text, txtNotifyAddress.Text, cmbFeederVessel.Text, cmbMotherVessel.Text, cmbDestination.Text, txtMarksDesc.Text, dtPullOut.Value, cmbStuffingLoadingPlace.Text, "INITIAL", "1", dtDate.Value, Now, USER_ID, cmbDepot.Text, txtDeportAddress.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, txtEtaMnl.Text, txtClosingTime.Text, txtViaPort.Text, cmbLoading.Text, txtRemarks.Text)
        '        Call SetJob("UPDATE TBL_CONTAINER SET STAT = '2' WHERE STAT = '1' AND  SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & lblBkNo.Text & "'")
        '        With dtContainers
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveContainers(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(2).Value, "1", dtDate.Value, Now, USER_ID)
        '            Next
        '        End With

        '        Call SetJob("UPDATE TBL_TRUCKER SET STAT = '2' WHERE STAT = '1' AND  SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & lblBkNo.Text & "'")
        '        With dtTrucker
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveTrucker(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(1).Value, "1", dtDate.Value, Now, USER_ID)
        '            Next
        '        End With
        '        FrmBookingList.Search(FrmBookingList.dtFrom.Value, FrmBookingList.dtTo.Value)
        '        MsgBox("Saved!", MsgBoxStyle.Information)
        '        LandingForm.Modeis = ""
        '        Me.Dispose()
        '    End If
        'End If


        'If LandingForm.Modeis = "EDIT_OPERATIONS" Then
        '    If MsgBox("Are you sure you want to modify this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Dim StatIs As String = FrmBookingList.dtList.CurrentRow.Cells(2).Tag
        '        Dim BLNO = "", REFNO As String = ""
        '        SelRefno = FrmBookingList.dtList.CurrentRow.Cells(24).Value
        '        selBLno = FrmBookingList.dtList.CurrentRow.Cells(25).Value

        '        Dim TermIs As String = ""
        '        If rdCollect.Checked = True Then
        '            TermIs = "C"
        '        ElseIf rdPrepaid.Checked = True Then
        '            TermIs = "P"
        '        End If


        '        'Call SetJob("UPDATE TBL_BOOKING SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
        '        'Call SAVEBookingRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtOutportId.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, cmbFeederVoyage1.Text, txtLoadingCode.Text, txt2ndFeederID.Text, cmbFeederVoyage2.Text, txtLoading2Code.Text, txtMotherVesselId.Text, cmbMotherVoyage.Text, txtMotherVesselLoadingCode.Text, cmbTrade.Tag, cmbSubTrade.Tag, cmbPorts.Tag, txtNumbersDesc.Text, txtKgs.Text, txtCbm.Text, txtOutportId.Text, TermIs, USER_ID, Now, StatIs, txtPOD1COde.Text, txtPOD2Code.Text, Microsoft.VisualBasic.Left(CmbTransipment.Text, 1), cmbCommodity.Text, selBLno, SelRefno, cmbPayableAt.Text)
        '        'Dim CurSeries As Integer = 0
        '        'CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
        '        'Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'")

        '        Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
        '        Call SaveDetailsOperations(lblSysref.Text, txtBKNO.Text, txtDepotId.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, dtEtaDate.Value, dtEtdDate.Value, dtClosingEndTime.Value, dtClosingEndTime.Value, txtViaPort.Text, dtArrastreCutoff.Value, cmbCargoWeight.Text, USER_ID, Now, StatIs, txtTelNo.Text, txtDeliveryPort.Text)

        '        Call SetJob("UPDATE TBL_CONTAINER SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
        '        With dtContainers
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveContainers(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, StatIs, dtDate.Value, Now, USER_ID, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, SaveMoney(.Rows(i).Cells(6).Value), .Rows(i).Cells(7).Value, SaveMoney(.Rows(i).Cells(8).Value), SaveMoney(.Rows(i).Cells(9).Value))
        '            Next
        '        End With

        '        Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
        '        With dtTrucker
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveTruckerOperations(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, USER_ID, Now, StatIs)
        '            Next
        '        End With


        '        'Call SetJob("UPDATE TBL_BOOKING SET  STAT = '4' , REASON = '" & KVal(FrmReasons.cmbReasons.Text) & "', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        'Call SetJob("UPDATE TBL_BOOKING SET STAT = '4' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        ' Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '4', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        Call FrmBookingList.FrmBookingList_Load(e, e)





        '        MsgBox("Successfully modified!", MsgBoxStyle.Information)
        '        FrmReasons.Dispose()
        '        Me.Dispose()
        '        Exit Sub
        '    End If
        '    Exit Sub
        'End If




        'If LandingForm.Modeis = "NEW_OPERATIONS" Then
        '    If MsgBox("Are you sure you want to save this operation details?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Call SaveDetailsOperations(lblSysref.Text, txtBKNO.Text, txtDepotId.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, dtEtaDate.Value, dtEtdDate.Value, dtClosingEndTime.Value, dtClosingEndTime.Value, txtViaPort.Text, dtArrastreCutoff.Value, cmbCargoWeight.Text, USER_ID, Now, "3", txtTelNo.Text, txtDeliveryPort.Text)
        '        With dtContainers
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveContainers(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, "3", dtDate.Value, Now, USER_ID, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, SaveMoney(.Rows(i).Cells(6).Value), .Rows(i).Cells(7).Value, SaveMoney(.Rows(i).Cells(8).Value), SaveMoney(.Rows(i).Cells(9).Value))
        '            Next
        '        End With
        '        With dtTrucker
        '            For i As Integer = 0 To .RowCount - 1
        '                Call SaveTruckerOperations(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, USER_ID, Now, "3")
        '            Next
        '        End With
        '        MsgBox("Successfully saved!", MsgBoxStyle.Information)
        '        Me.Dispose()
        '    End If

        'End If
        ''If LandingForm.Modeis = "NEW" Then
        ''    If MsgBox("Are you sure you want to save this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        ''        Call SaveBookingDetails(lblSysref.Text, lblBkNo.Text, cmbShipper.Text, txtShipperAddress.Text, cmbConsignee.Text, txtConsigneeAddress.Text, cmbNotify.Text, txtNotifyAddress.Text, cmbFeederVessel.Text, cmbMotherVessel.Text, cmbDestination.Text, txtMarksDesc.Text, dtPullOut.Value, cmbStuffingLoadingPlace.Text, "INITIAL", "1", dtDate.Value, Now, USER_ID, cmbDepot.Text, txtDeportAddress.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, txtEtaMnl.Text, txtClosingTime.Text, txtViaPort.Text, cmbLoading.Text, txtRemarks.Text)
        ''        With dtContainers
        ''            For i As Integer = 0 To .RowCount - 1
        ''                Call SaveContainers(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(2).Value, "1", dtDate.Value, Now, USER_ID)
        ''            Next
        ''        End With

        ''        With dtTrucker
        ''            For i As Integer = 0 To .RowCount - 1
        ''                Call SaveTrucker(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(1).Value, "1", dtDate.Value, Now, USER_ID)
        ''            Next
        ''        End With
        ''        Dim CurSeries As Integer = 0
        ''        CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
        ''        Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'")
        ''        FrmBookingList.Search(FrmBookingList.dtFrom.Value, FrmBookingList.dtTo.Value)
        ''        MsgBox("Saved!", MsgBoxStyle.Information)
        ''        LandingForm.Modeis = ""
        ''        Me.Dispose()
        ''    End If
        ''Else
        ''    If MsgBox("Are you sure you want to update this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        ''        Call SetJob("UPDATE TBL_BOOKING SET STAT = '2' WHERE STAT = '1' AND  SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & lblBkNo.Text & "'")
        ''        Call SaveBookingDetails(lblSysref.Text, lblBkNo.Text, cmbShipper.Text, txtShipperAddress.Text, cmbConsignee.Text, txtConsigneeAddress.Text, cmbNotify.Text, txtNotifyAddress.Text, cmbFeederVessel.Text, cmbMotherVessel.Text, cmbDestination.Text, txtMarksDesc.Text, dtPullOut.Value, cmbStuffingLoadingPlace.Text, "INITIAL", "1", dtDate.Value, Now, USER_ID, cmbDepot.Text, txtDeportAddress.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, txtEtaMnl.Text, txtClosingTime.Text, txtViaPort.Text, cmbLoading.Text, txtRemarks.Text)
        ''        Call SetJob("UPDATE TBL_CONTAINER SET STAT = '2' WHERE STAT = '1' AND  SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & lblBkNo.Text & "'")
        ''        With dtContainers
        ''            For i As Integer = 0 To .RowCount - 1
        ''                Call SaveContainers(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(2).Value, "1", dtDate.Value, Now, USER_ID)
        ''            Next
        ''        End With

        ''        Call SetJob("UPDATE TBL_TRUCKER SET STAT = '2' WHERE STAT = '1' AND  SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & lblBkNo.Text & "'")
        ''        With dtTrucker
        ''            For i As Integer = 0 To .RowCount - 1
        ''                Call SaveTrucker(lblSysref.Text, lblBkNo.Text, .Rows(i).Cells(1).Value, "1", dtDate.Value, Now, USER_ID)
        ''            Next
        ''        End With
        ''        FrmBookingList.Search(FrmBookingList.dtFrom.Value, FrmBookingList.dtTo.Value)
        ''        MsgBox("Saved!", MsgBoxStyle.Information)
        ''        LandingForm.Modeis = ""
        ''        Me.Dispose()
        ''    End If
        ''End If

    End Sub

    Public Sub SaveBookingDetails(Sysref, BKNO, Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, FeederVessel, MotherVessel, Destination, NumberDescription, DatePullOut, StuffingLoadingPlace, PARAM1, STAT, DateTrans, DateAdded, AddedBy, Depot, DepotAddress, ReleasingChecker, OperatingHours, EtaMnl, ClosingTime, ViaPort, LOADING, Remarks)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_BOOKING(Sysref, BKNO, Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, FeederVessel, MotherVessel, Destination, NumberDescription, DatePullOut, StuffingLoadingPlace, PARAM1, STAT, KGS, CBM, DateTrans, DateAdded, AddedBy, Depot, DepotAddress, ReleasingChecker, OperatingHours, EtaMnl, ClosingTime, ViaPort, LOADING, Remarks)"
        SQL = SQL + "VALUES('" & KVal(Sysref) & "',  '" & KVal(BKNO) & "',  '" & KVal(Shipper) & "',  '" & KVal(ShipperAddress) & "',  '" & KVal(Consignee) & "',  '" & KVal(ConsigneeAddress) & "',  '" & KVal(Notify) & "',  '" & KVal(NotifyAddress) & "',  '" & KVal(FeederVessel) & "',  '" & KVal(MotherVessel) & "',  '" & KVal(Destination) & "',  '" & KVal(NumberDescription) & "',  '" & KVal(DatePullOut) & "',  '" & KVal(StuffingLoadingPlace) & "',  '" & KVal(PARAM1) & "',  '" & KVal(STAT) & "', '" & KVal(txtKgs.Text) & "', '" & KVal(txtCbm.Text) & "', '" & KVal(DateTrans) & "', '" & KVal(DateAdded) & "' , '" & KVal(AddedBy) & "', '" & KVal(Depot) & "',  '" & KVal(DepotAddress) & "',  '" & KVal(ReleasingChecker) & "',  '" & KVal(OperatingHours) & "',  '" & KVal(EtaMnl) & "',  '" & KVal(ClosingTime) & "',  '" & KVal(ViaPort) & "', '" & KVal(LOADING) & "', '" & KVal(Remarks) & "' )"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub SaveContainers(Sysref, BKNO, Count, SizeIs, ContainerNo, SealNo, stat, DateTrans, DateAdded, AddedBy, LoadingPlace, DatePullout, CountIs, PackagingType, KGS, CBM, GateInDate, VGM, CargoType)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_CONTAINER ( Sysref, BKNO, Count, SizeIs, ContainerNo, SealNo, stat, DateTrans, DateAdded, AddedBy,LoadingPlace, DatePullout,CountIs, PackagingType, KGS, CBM, GateInDate, VGM, CargoType)"
        SQL = SQL + "VALUES('" & KVal(Sysref) & "',  '" & KVal(BKNO) & "',  '" & KVal(Count) & "',  '" & KVal(SizeIs) & "',  '" & KVal(ContainerNo) & "',  '" & KVal(SealNo) & "',  '" & KVal(stat) & "', '" & KVal(DateTrans) & "', '" & KVal(DateAdded) & "' , '" & KVal(AddedBy) & "','" & KVal(LoadingPlace) & "', '" & KVal(DatePullout) & "','" & KVal(CountIs) & "',  '" & KVal(PackagingType) & "',  '" & KVal(KGS) & "',  '" & KVal(CBM) & "', '" & KVal(GateInDate) & "', '" & KVal(VGM) & "','" & KVal(CargoType) & "' )"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub SaveTrucker(SYSREF, BKNO, TRUCKER, STAT, DateTrans, DateAdded, AddedBy)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_TRUCKER(SYSREF, BKNO, TRUCKER, STAT, DateTrans, DateAdded, AddedBy)"
        SQL = SQL + "VALUES('" & KVal(SYSREF) & "',  '" & KVal(BKNO) & "',  '" & KVal(TRUCKER) & "',  '" & KVal(STAT) & "', '" & KVal(DateTrans) & "', '" & KVal(DateAdded) & "' , '" & KVal(AddedBy) & "' )"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub FrmInitialBooking_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub cmbTrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrade.SelectedIndexChanged, cmbTrade.TextChanged
        Dim cTag As String = ""
        With sender
            If .SelectedIndex < 0 Then
                .Tag = ""
                cTag = ""
                txtTradeId.Text = ""
            Else
                .Tag = Format(CInt(sender.selectedvalue.ToString), "00000")
                cTag = CInt(sender.tag)
                txtTradeId.Text = IIf(String.IsNullOrEmpty(cTag), "", Format(CInt(cTag), "00000"))
            End If

        End With

        LoadStrCmb(cmbSubTrade, "SELECT ID, NAME FROM TBL_SUB_TRADE_OPTIONS WHERE STAT = '1' AND TRADE_ID = '" & cTag & "'")
    End Sub

    Private Sub cmbSubTrade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubTrade.SelectedIndexChanged, cmbSubTrade.TextChanged
        Dim cTag As String = ""
        With sender
            If .SelectedIndex < 0 Then
                .Tag = ""
                cTag = ""
            Else
                .Tag = Format(CInt(sender.selectedvalue.ToString), "00000")
                cTag = CInt(sender.tag)
            End If

        End With
        Dim SubTradeId As String = cmbSubTrade.Tag
        If String.IsNullOrEmpty(cmbSubTrade.Tag) Then
            SubTradeId = ""
            txtSubTradeId.Text = ""
        Else
            SubTradeId = cmbSubTrade.Tag
            txtSubTradeId.Text = IIf(String.IsNullOrEmpty(SubTradeId), "", Format(CInt(SubTradeId), "00000"))
        End If

        If String.IsNullOrEmpty(SubTradeId) Then
            SubTradeId = ""
        Else
            SubTradeId = CInt(SubTradeId)
        End If



        LoadStrCmb(cmbPorts, "SELECT ID, NAME FROM TBL_PORTS WHERE STAT = '1' AND SUB_TRADE_ID =  '" & SubTradeId & "'")
    End Sub

    Private Sub cmbFeederVessel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFeederVessel.SelectedIndexChanged, cmbFeederVessel.TextChanged
        With txtFeederId
            If sender.SelectedIndex = -1 Then
                .Text = ""
                Exit Sub
            End If
            .Text = Format(CInt(sender.selectedvalue.ToString), "00000")
        End With
    End Sub

    Private Sub cmbMotherVessel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMotherVessel.SelectedIndexChanged, cmbMotherVessel.TextChanged
        With txtMotherVesselId
            If sender.SelectedIndex = -1 Then
                .Text = ""
                Exit Sub
            End If
            .Text = Format(CInt(sender.selectedvalue.ToString), "00000")
        End With
    End Sub

    Private Sub cmbLoading1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoading1.SelectedIndexChanged, cmbLoading1.TextChanged
        If sender.SelectedIndex = -1 Then
            txtLoadingCode.Text = ""
            Exit Sub
        End If
        txtLoadingCode.Text = Format(CInt(sender.selectedvalue.ToString), "00000")
    End Sub

    Private Sub txtShipperId_TextChanged(sender As Object, e As EventArgs) Handles txtShipperId.TextChanged

    End Sub

    Private Sub txtConsigneeId_TextChanged(sender As Object, e As EventArgs) Handles txtConsigneeId.TextChanged

    End Sub

    Private Sub cmbTrucker_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrucker.SelectedIndexChanged, cmbTrucker.TextChanged
        With txtTruckerId
            If sender.SelectedIndex = -1 Then
                .Text = ""
                Exit Sub
            End If
            .Text = Format(CInt(sender.selectedvalue.ToString), "00000")
        End With

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub

    Private Sub btnSaveCs_Click(sender As Object, e As EventArgs) Handles btnSaveCs.Click


        'MsgBox(getClientAttgCode(cmbShipper.Text))
        'Exit Sub


        If LandingForm.Modeis = "" Then
            Exit Sub
        End If
        If LandingForm.Modeis = "EDIT" Then
            If MsgBox("Are you sure you want to modify this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim StatIs As String = FrmBookingList.dtList.CurrentRow.Cells(2).Tag
                Dim BLNO = "", REFNO As String = ""
                SelRefno = FrmBookingList.dtList.CurrentRow.Cells(24).Value
                selBLno = FrmBookingList.dtList.CurrentRow.Cells(25).Value

                Dim TermIs As String = ""
                If rdCollect.Checked = True Then
                    TermIs = "C"
                ElseIf rdPrepaid.Checked = True Then
                    TermIs = "P"
                End If


                Call SetJob("UPDATE TBL_BOOKING SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                Call SAVEBookingRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtOutportId.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, cmbFeederVoyage1.Text, txtLoadingCode.Text, txt2ndFeederID.Text, cmbFeederVoyage2.Text, txtLoading2Code.Text, txtMotherVesselId.Text, cmbMotherVoyage.Text, txtMotherVesselLoadingCode.Text, txtTradeId.Text, txtSubTradeId.Text, txtPortsId.Text, txtNumbersDesc.Text, txtKgs.Text, txtCbm.Text, txtOutportId.Text, TermIs, USER_ID, Now, StatIs, txtPOD1COde.Text, txtPOD2Code.Text, Microsoft.VisualBasic.Left(CmbTransipment.Text, 1), cmbCommodity.Text, selBLno, SelRefno, cmbPayableAt.Text, txtRegistryNumber.Text, dt1stVETA.Value, dt1stVETD.Value, dt2ndVETA.Value, dt2ndVETD.Value, dtMvETA.Value, dtMvETD.Value, txtCoLoaderBKNo.Text, dtFDEta.Value, dtFDEtd.Value, cmbServiceType.Text)
                'Dim CurSeries As Integer = 0
                'CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
                'Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'")

                '''''Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                '''''Call SaveDetailsOperations(lblSysref.Text, txtBKNO.Text, txtDepotId.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, dtEtaDate.Value, dtEtdDate.Value, dtClosingEndTime.Value, dtClosingEndTime.Value, txtViaPort.Text, dtArrastreCutoff.Value, cmbCargoWeight.Text, USER_ID, Now, StatIs, txtTelNo.Text, txtDeliveryPort.Text)

                '''''Call SetJob("UPDATE TBL_CONTAINER SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                '''''With dtContainers
                '''''    For i As Integer = 0 To .RowCount - 1
                '''''        Call SaveContainers(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, StatIs, dtDate.Value, Now, USER_ID, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, SaveMoney(.Rows(i).Cells(6).Value), .Rows(i).Cells(7).Value, SaveMoney(.Rows(i).Cells(8).Value), SaveMoney(.Rows(i).Cells(9).Value))
                '''''    Next
                '''''End With

                '''''Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                '''''With dtTrucker
                '''''    For i As Integer = 0 To .RowCount - 1
                '''''        Call SaveTruckerOperations(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, USER_ID, Now, StatIs)
                '''''    Next
                '''''End With


                'Call SetJob("UPDATE TBL_BOOKING SET  STAT = '4' , REASON = '" & KVal(FrmReasons.cmbReasons.Text) & "', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                'Call SetJob("UPDATE TBL_BOOKING SET STAT = '4' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                ' Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '4', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call FrmBookingList.FrmBookingList_Load(e, e)





                MsgBox("Successfully modified!", MsgBoxStyle.Information)
                FrmReasons.Dispose()
                Me.Dispose()
                LandingForm.Modeis = ""
                Exit Sub
            Else
                LandingForm.Modeis = ""
                Exit Sub
            End If
            LandingForm.Modeis = ""
            Exit Sub
        End If

        If LandingForm.Modeis = "NEW" Then
            If MsgBox("Are you sure you want to save this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim TermIs As String = ""
                If rdCollect.Checked = True Then
                    TermIs = "C"
                ElseIf rdPrepaid.Checked = True Then
                    TermIs = "P"
                End If

                'Call SaveRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, txtMotherVesselId.Text, cmbTrade.Tag, cmbSubTrade.Tag, cmbPorts.Tag, txtLoadingCode.Text, txtNumbersDesc.Text, SaveMoney(txtKgs.Text), SaveMoney(txtCbm.Text), Now, "3", TermIs, USER_ID, cmbFeederVoyage1.Text, cmbMotherVoyage.Text)
                Call SAVEBookingRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtOutportId.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, cmbFeederVoyage1.Text, txtLoadingCode.Text, txt2ndFeederID.Text, cmbFeederVoyage2.Text, txtLoading2Code.Text, txtMotherVesselId.Text, cmbMotherVoyage.Text, txtMotherVesselLoadingCode.Text, cmbTrade.Tag, cmbSubTrade.Tag, cmbPorts.Tag, txtNumbersDesc.Text, txtKgs.Text, txtCbm.Text, txtOutportId.Text, TermIs, USER_ID, Now, "3", txtPOD1COde.Text, txtPOD2Code.Text, Microsoft.VisualBasic.Left(CmbTransipment.Text, 1), cmbCommodity.Text, "", "", cmbPayableAt.Text, txtRegistryNumber.Text, dt1stVETA.Value, dt1stVETD.Value, dt2ndVETA.Value, dt2ndVETD.Value, dtMvETA.Value, dtMvETD.Value, txtCoLoaderBKNo.Text, dtFDEta.Value, dtFDEtd.Value, cmbServiceType.Text)
                Dim CurSeries As Integer = 0
                CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
                Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN'")
                MsgBox("Successfully saved!", MsgBoxStyle.Information)
                LandingForm.Modeis = ""
                Me.Dispose()
            End If
        End If


    End Sub
    Public Sub SAVEBookingRecord(Sysref, DateTrans, BKNO, OptnMode, Shipper, Consignee, Notify, FeederVessel1st, FVoyage1st, FeederPOL1st, FeederVessel2nd, FVoyage2nd, FeederVessel2ndPOL, MotherVessel, MVoyage, MotherVesselLoading, TRADE, SUB_TRADE, PORTS, NUMBERS_DESC, KGS, CBM, OutPort, TermsIs, AddedBy, DateAdded, Stat, FeederPOD1st, FeederVessel2ndPOD, Transshipment, Commodity, BLNO, REFNO, PayableAt, Regno, F1_ETA, F1_ETD, F2_ETA, F2_ETD, MV_ETA, MV_ETD, CoLoaderBkno, FINAL_DEST_ETA, FINAL_DEST_ETD, ServiceType)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_BOOKING(Sysref, DateTrans, BKNO, OptnMode, Shipper, Consignee, Notify, FeederVessel1st, FVoyage1st, FeederPOL1st, FeederVessel2nd, FVoyage2nd, FeederVessel2ndPOL, MotherVessel, MVoyage,MotherVesselLoading, TRADE, SUB_TRADE, PORTS, NUMBERS_DESC, KGS, CBM, OutPort, TermsIs, AddedBy, DateAdded, Stat, FeederPOD1st, FeederVessel2ndPOD, Transshipment, Commodity, BLNO, REFNO, PayableAt, RegNo,F1_ETA, F1_ETD, F2_ETA, F2_ETD, MV_ETA, MV_ETD, CoLoaderBkno, FINAL_DEST_ETA, FINAL_DEST_ETD, ServiceType)"
        SQL = SQL + "VALUES('" & KVal(Sysref) & "',  '" & KVal(DateTrans) & "',  '" & KVal(BKNO) & "',  '" & KVal(OptnMode) & "',  '" & KVal(Shipper) & "',  '" & KVal(Consignee) & "',  '" & KVal(Notify) & "',  '" & KVal(FeederVessel1st) & "',  '" & KVal(FVoyage1st) & "',  '" & KVal(FeederPOL1st) & "',  '" & KVal(FeederVessel2nd) & "',  '" & KVal(FVoyage2nd) & "',  '" & KVal(FeederVessel2ndPOL) & "',  '" & KVal(MotherVessel) & "',  '" & KVal(MVoyage) & "',  '" & KVal(MotherVesselLoading) & "',  '" & KVal(TRADE) & "',  '" & KVal(SUB_TRADE) & "',  '" & KVal(PORTS) & "',  '" & KVal(NUMBERS_DESC) & "',  '" & KVal(KGS) & "',  '" & KVal(CBM) & "',  '" & KVal(OutPort) & "',  '" & KVal(TermsIs) & "',  '" & KVal(AddedBy) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "', '" & KVal(FeederPOD1st) & "', '" & KVal(FeederVessel2ndPOD) & "', '" & KVal(Transshipment) & "', '" & KVal(Commodity) & "', '" & KVal(BLNO) & "' , '" & KVal(REFNO) & "', '" & KVal(cmbPayableAt.Text) & "', '" & KVal(Regno) & "','" & KVal(F1_ETA) & "',  '" & KVal(F1_ETD) & "',  '" & KVal(F2_ETA) & "',  '" & KVal(F2_ETD) & "',  '" & KVal(MV_ETA) & "',  '" & KVal(MV_ETD) & "',  '" & KVal(CoLoaderBkno) & "',  '" & KVal(FINAL_DEST_ETA) & "',  '" & KVal(FINAL_DEST_ETD) & "', '" & KVal(ServiceType) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Public Sub SaveRecord(Sysref, DateTrans, BKNO, Shipper, Consignee, Notify, FeederVessel, MotherVessel, TRADE, SUB_TRADE, PORTS, LOADING, NUMBERS_DESC, KGS, CBM, DateAdded, Stat, TermIs, AddedBy, FVoyage, MVoyage)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "INSERT INTO TBL_BOOKING(Sysref, DateTrans, BKNO, Shipper, Consignee, Notify, FeederVessel, MotherVessel, TRADE, SUB_TRADE, PORTS, LOADING,  NUMBERS_DESC, KGS, CBM, DateAdded, Stat, TermSIs, AddedBy, FVoyage, MVoyage)"
        SQL = SQL + "VALUES('" & KVal(Sysref) & "',  '" & KVal(DateTrans) & "',  '" & KVal(BKNO) & "',  '" & KVal(Shipper) & "',  '" & KVal(Consignee) & "',  '" & KVal(Notify) & "',  '" & KVal(FeederVessel) & "',  '" & KVal(MotherVessel) & "',  '" & KVal(TRADE) & "',  '" & KVal(SUB_TRADE) & "',  '" & KVal(PORTS) & "',  '" & KVal(LOADING) & "',   '" & KVal(NUMBERS_DESC) & "',  '" & KVal(KGS) & "', '" & KVal(CBM) & "',  '" & KVal(DateAdded) & "',  '" & KVal(Stat) & "', '" & KVal(TermIs) & "', '" & KVal(AddedBy) & "', '" & KVal(FVoyage) & "', '" & KVal(MVoyage) & "')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub cmbPorts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPorts.SelectedIndexChanged, cmbPorts.TextChanged
        Dim cTag As String = ""
        With sender
            If .SelectedIndex < 0 Then
                .Tag = ""
                cTag = ""
            Else
                .Tag = Format(CInt(sender.selectedvalue.ToString), "00000")
                cTag = CInt(sender.tag)

            End If

        End With
        If String.IsNullOrEmpty(cTag) Then
            cTag = ""
        Else
            cTag = Format(CInt(cTag), "00000")
        End If

        txtPortsId.Text = cTag

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles pnlCsSave.Paint

    End Sub

    Private Sub cmbDepot_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepot.SelectedIndexChanged, cmbDepot.TextChanged

        With txtDepotId
            If sender.SelectedIndex = -1 Then
                .Text = ""
                txtShipperAddress.Text = ""
                Exit Sub
            End If

            txtDeportAddress.Text = CType(sender.SelectedItem, Depot).AddressIs
            txtTelNo.Text = CType(sender.selecteditem, Depot).TelephoneNos
            dtStartOH.Value = CType(sender.selecteditem, Depot).OperatingHrsStart
            dtEndOH.Value = CType(sender.selecteditem, Depot).OperationHrsEnd
            .Text = Format(CInt(CType(sender.SelectedItem, Depot).Id), "00000")
        End With
    End Sub

    Private Sub dtStartOH_ValueChanged(sender As Object, e As EventArgs) Handles dtStartOH.ValueChanged, dtStartOH.TextChanged, dtEndOH.TextChanged
        'txtOperatingHours.Text = Format(CDate(dtStartOH.Value), "hh:mm tt") & "-" & Format(CDate(dtEndOH.Value), "hh:mm tt")
        txtOperatingHours.Text = IIf(Format(CDate(dtStartOH.Value), "hh:mm tt") = Format(CDate(dtEndOH.Value), "hh:mm tt"), "24hrs", Format(CDate(dtStartOH.Value), "hh:mm tt") & " - " & Format(CDate(dtEndOH.Value), "hh:mm tt"))
    End Sub

    Private Sub dtEndOH_ValueChanged(sender As Object, e As EventArgs) Handles dtEndOH.ValueChanged
        txtOperatingHours.Text = Format(CDate(dtStartOH.Value), "hh:mm tt") & " - " & Format(CDate(dtEndOH.Value), "hh:mm tt")
    End Sub

    Private Sub cmbOutPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOutPort.SelectedIndexChanged, cmbOutPort.TextChanged
        With txtOutportId
            If sender.TEXT = "MANILA_ONLY" Then
                txtOutportId.Text = "00001"
                CmbOptionPort.Text = "MANILA:"
            Else
                If sender.SelectedIndex = -1 Then
                    .Text = ""
                    Exit Sub
                End If
                .Text = Format(CInt(sender.selectedvalue.ToString), "00000")
            End If
        End With




    End Sub

    Private Sub FrmInitialBooking_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd

    End Sub

    Private Sub FrmInitialBooking_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Label47.Text = Me.Size.ToString
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub CmbOptionPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbOptionPort.SelectedIndexChanged, CmbOptionPort.TextChanged
        If CmbOptionPort.Text = "MANILA:" Then
            cmbOutPort.Text = "MANILA_ONLY"
            txtOutportId.Text = "00001"

            txtOutportId.Enabled = False
            cmbOutPort.Enabled = False
        ElseIf CmbOptionPort.Text = "OUTPORT:" Then
            txtOutportId.Enabled = True
            cmbOutPort.Enabled = True
            cmbOutPort.Text = ""
        Else
            txtOutportId.Text = ""
            cmbOutPort.Text = ""
            txtOutportId.Enabled = False
            cmbOutPort.Enabled = False
        End If
    End Sub

    Private Sub cmb2ndFeederVessel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb2ndFeederVessel.SelectedIndexChanged, cmb2ndFeederVessel.TextChanged
        With txt2ndFeederID
            If sender.SelectedIndex = -1 Then
                .Text = ""
                Exit Sub
            End If
            .Text = Format(CInt(sender.selectedvalue.ToString), "00000")
        End With
    End Sub

    Private Sub cmbLoading2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLoading2.SelectedIndexChanged, cmbLoading2.TextChanged
        If sender.SelectedIndex = -1 Then
            txtLoading2Code.Text = ""
            Exit Sub
        End If
        txtLoading2Code.Text = Format(CInt(sender.selectedvalue.ToString), "00000")
    End Sub

    Private Sub CmbPOD1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPOD1.SelectedIndexChanged, CmbPOD1.TextChanged
        If sender.SelectedIndex = -1 Then
            txtPOD1COde.Text = ""
            Exit Sub
        End If
        txtPOD1COde.Text = Format(CInt(sender.selectedvalue.ToString), "00000")
    End Sub

    Private Sub CmbMotherVesselLoading_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMotherVesselLoading.SelectedIndexChanged, CmbMotherVesselLoading.TextChanged
        If sender.SelectedIndex = -1 Then
            txtMotherVesselLoadingCode.Text = ""
            Exit Sub
        End If
        txtMotherVesselLoadingCode.Text = Format(CInt(sender.selectedvalue.ToString), "00000")
    End Sub

    Private Sub cmbPOD2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPOD2.SelectedIndexChanged, cmbPOD2.TextChanged
        If sender.SelectedIndex = -1 Then
            txtPOD2Code.Text = ""
            Exit Sub
        End If
        txtPOD2Code.Text = Format(CInt(sender.selectedvalue.ToString), "00000")
    End Sub

    Private Sub CmbTransipment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTransipment.SelectedIndexChanged, CmbTransipment.TextChanged
        If sender.text = "SINGLE TRANSSHIPMENT" Then
            pnlDualTrans.Enabled = False
            For Each c As Control In Me.pnlDualTrans.Controls
                If TypeOf c Is TextBox OrElse TypeOf c Is ComboBox Then
                    c.Text = ""
                End If
            Next
        ElseIf sender.text = "DUAL TRANSSHIPMENT" Then
            pnlDualTrans.Enabled = True
        Else
            pnlDualTrans.Enabled = False
        End If
    End Sub

    Private Sub cmbDeliveryPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDeliveryPort.SelectedIndexChanged, cmbDeliveryPort.TextChanged
        If sender.SelectedIndex = -1 Then
            txtDeliveryPort.Text = ""
            Exit Sub
        End If
        txtDeliveryPort.Text = Format(CInt(sender.selectedvalue.ToString), "00000")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim StatIs As String = FrmBookingList.dtList.CurrentRow.Cells(2).Tag
        Dim BLNO = "", REFNO As String = ""
        SelRefno = FrmBookingList.dtList.CurrentRow.Cells(24).Value
        selBLno = FrmBookingList.dtList.CurrentRow.Cells(25).Value

        If FrmBookingList.ActionMode = "REBOOK" Then
            If MsgBox("Are you sure you want to rebook this booking record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim TermIs As String = ""
                If rdCollect.Checked = True Then
                    TermIs = "C"
                ElseIf rdPrepaid.Checked = True Then
                    TermIs = "P"
                End If

                'Call SaveRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, txtMotherVesselId.Text, cmbTrade.Tag, cmbSubTrade.Tag, cmbPorts.Tag, txtLoadingCode.Text, txtNumbersDesc.Text, SaveMoney(txtKgs.Text), SaveMoney(txtCbm.Text), Now, "3", TermIs, USER_ID, cmbFeederVoyage1.Text, cmbMotherVoyage.Text)
                Call SAVEBookingRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtOutportId.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, cmbFeederVoyage1.Text, txtLoadingCode.Text, txt2ndFeederID.Text, cmbFeederVoyage2.Text, txtLoading2Code.Text, txtMotherVesselId.Text, cmbMotherVoyage.Text, txtMotherVesselLoadingCode.Text, cmbTrade.Tag, cmbSubTrade.Tag, cmbPorts.Tag, txtNumbersDesc.Text, txtKgs.Text, txtCbm.Text, txtOutportId.Text, TermIs, USER_ID, Now, "3", txtPOD1COde.Text, txtPOD2Code.Text, Microsoft.VisualBasic.Left(CmbTransipment.Text, 1), cmbCommodity.Text, "", "", cmbPayableAt.Text, txtRegistryNumber.Text, dt1stVETA.Value, dt1stVETD.Value, dt2ndVETA.Value, dt2ndVETD.Value, dtMvETA.Value, dtMvETD.Value, txtCoLoaderBKNo.Text, dtFDEta.Value, dtFDEtd.Value, cmbServiceType.Text)
                Dim CurSeries As Integer = 0
                CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
                Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN'")


                Call SaveDetailsOperations(lblSysref.Text, txtBKNO.Text, txtDepotId.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, dtEtaDate.Value, dtEtdDate.Value, dtClosingEndTime.Value, dtClosingEndTime.Value, txtViaPort.Text, dtArrastreCutoff.Value, cmbCargoWeight.Text, USER_ID, Now, "3", txtTelNo.Text, txtDeliveryPort.Text)
                With dtContainers
                    For i As Integer = 0 To .RowCount - 1
                        Call SaveContainers(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, "3", dtDate.Value, Now, USER_ID, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, SaveMoney(.Rows(i).Cells(6).Value), .Rows(i).Cells(7).Value, SaveMoney(.Rows(i).Cells(8).Value), SaveMoney(.Rows(i).Cells(9).Value), .Rows(i).Cells(10).Value, .Rows(i).Cells(11).Value, .Rows(i).Cells(12).Value)
                    Next
                End With
                With dtTrucker
                    For i As Integer = 0 To .RowCount - 1
                        Call SaveTruckerOperations(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, USER_ID, Now, "3")
                    Next
                End With


                Call SetJob("UPDATE TBL_BOOKING SET  STAT = '4' , REASON = '" & KVal(FrmReasons.cmbReasons.Text) & "', NEW_BKNO = '" & txtBKNO.Text & "', RebookedBy = '" & USER_ID & "', dateRebooked = '" & Now & "' WHERE SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "' AND STAT = '" & StatIs & "'")
                'Call SetJob("UPDATE TBL_BOOKING SET STAT = '4' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '4', NEW_BKNO = '" & txtBKNO.Text & "' WHERE  SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "' AND STAT = '" & StatIs & "'")
                Call FrmBookingList.FrmBookingList_Load(e, e)





                MsgBox("Successfully rebooked!", MsgBoxStyle.Information)
                FrmReasons.Dispose()
                Me.Dispose()
                Exit Sub
            End If
        ElseIf FrmBookingList.ActionMode = "EDIT" Then
            If MsgBox("Are you sure you want to modify this booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim TermIs As String = ""
                If rdCollect.Checked = True Then
                    TermIs = "C"
                ElseIf rdPrepaid.Checked = True Then
                    TermIs = "P"
                End If


                Call SetJob("UPDATE TBL_BOOKING SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                Call SAVEBookingRecord(lblSysref.Text, dtDate.Value, txtBKNO.Text, txtOutportId.Text, txtShipperId.Text, txtConsigneeId.Text, txtNotifyID.Text, txtFeederId.Text, cmbFeederVoyage1.Text, txtLoadingCode.Text, txt2ndFeederID.Text, cmbFeederVoyage2.Text, txtLoading2Code.Text, txtMotherVesselId.Text, cmbMotherVoyage.Text, txtMotherVesselLoadingCode.Text, cmbTrade.Tag, cmbSubTrade.Tag, cmbPorts.Tag, txtNumbersDesc.Text, txtKgs.Text, txtCbm.Text, txtOutportId.Text, TermIs, USER_ID, Now, StatIs, txtPOD1COde.Text, txtPOD2Code.Text, Microsoft.VisualBasic.Left(CmbTransipment.Text, 1), cmbCommodity.Text, selBLno, SelRefno, cmbPayableAt.Text, txtRegistryNumber.Text, dt1stVETA.Value, dt1stVETD.Value, dt2ndVETA.Value, dt2ndVETD.Value, dtMvETA.Value, dtMvETD.Value, txtCoLoaderBKNo.Text, dtFDEta.Value, dtFDEtd.Value, cmbServiceType.Text)
                'Dim CurSeries As Integer = 0
                'CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
                'Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM2 = 'BKN' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'")

                Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                Call SaveDetailsOperations(lblSysref.Text, txtBKNO.Text, txtDepotId.Text, cmbReleasingChecker.Text, txtOperatingHours.Text, dtEtaDate.Value, dtEtdDate.Value, dtClosingEndTime.Value, dtClosingEndTime.Value, txtViaPort.Text, dtArrastreCutoff.Value, cmbCargoWeight.Text, USER_ID, Now, StatIs, txtTelNo.Text, txtDeliveryPort.Text)

                Call SetJob("UPDATE TBL_CONTAINER SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                With dtContainers
                    For i As Integer = 0 To .RowCount - 1
                        Call SaveContainers(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, .Rows(i).Cells(1).Value, .Rows(i).Cells(2).Value, .Rows(i).Cells(3).Value, StatIs, dtDate.Value, Now, USER_ID, .Rows(i).Cells(4).Value, .Rows(i).Cells(5).Value, SaveMoney(.Rows(i).Cells(6).Value), .Rows(i).Cells(7).Value, SaveMoney(.Rows(i).Cells(8).Value), SaveMoney(.Rows(i).Cells(9).Value), .Rows(i).Cells(10).Value, .Rows(i).Cells(11).Value, .Rows(i).Cells(12).Value)
                    Next
                End With

                Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET STAT = '2' WHERE SYSREF = '" & lblSysref.Text & "' AND BKNO = '" & txtBKNO.Text & "' AND STAT = '" & StatIs & "'")
                With dtTrucker
                    For i As Integer = 0 To .RowCount - 1
                        Call SaveTruckerOperations(lblSysref.Text, txtBKNO.Text, .Rows(i).Cells(0).Value, USER_ID, Now, StatIs)
                    Next
                End With


                'Call SetJob("UPDATE TBL_BOOKING SET  STAT = '4' , REASON = '" & KVal(FrmReasons.cmbReasons.Text) & "', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                'Call SetJob("UPDATE TBL_BOOKING SET STAT = '4' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                ' Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '4', NEW_BKNO = '" & txtBKNO.Text & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call FrmBookingList.FrmBookingList_Load(e, e)





                MsgBox("Successfully modified!", MsgBoxStyle.Information)
                FrmReasons.Dispose()
                Me.Dispose()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub btnMaintenance_Click(sender As Object, e As EventArgs) Handles btnMaintenance.Click


        With cmsMaintenance
            .Show(sender, 0, 0 - cmsMaintenance.Height)
        End With

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click


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

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub rdPrepaid_CheckedChanged(sender As Object, e As EventArgs) Handles rdPrepaid.CheckedChanged
        If rdPrepaid.Checked = True Then
            cmbPayableAt.Text = "MANILA, PHILS"
        ElseIf rdCollect.Checked = True Then
            cmbPayableAt.Text = ""
        End If
    End Sub

    Private Sub rdCollect_CheckedChanged(sender As Object, e As EventArgs) Handles rdCollect.CheckedChanged
        If rdPrepaid.Checked = True Then
            cmbPayableAt.Text = "MANILA, PHILS"
        ElseIf rdCollect.Checked = True Then
            cmbPayableAt.Text = ""
        End If
    End Sub

    Private Sub txtTradeId_TextChanged(sender As Object, e As EventArgs) Handles txtTradeId.TextChanged

    End Sub

    Private Sub cmbTrucker_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbTrucker.KeyPress

    End Sub

    Private Sub cmbTrucker_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTrucker.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call btnAddTrucker_Click(e, e)
        End If
    End Sub

    Private Sub btnContCancel_Click(sender As Object, e As EventArgs) Handles btnContCancel.Click
        btnAdd.ImageIndex = 0
        btnContCancel.Visible = False
        dtContainers.Enabled = True


        cmbContSize.Text = ""
        txtContNo.Text = ""
        txtSealNo.Text = ""
        cmbLoadingPlace.Text = ""
        dtPulloutDateTime.Value = "01-01-1991"
        txtCount.Text = ""
        cmbPkgType.Text = ""
        txtContKgs.Text = ""
        txtContCbm.Text = ""
        DtGateInDate.Value = "01-01-1991"
        txtVGM.Text = ""
        cmbGeneralOrDg.Text = ""
        EditContainersMode = ""
    End Sub
End Class