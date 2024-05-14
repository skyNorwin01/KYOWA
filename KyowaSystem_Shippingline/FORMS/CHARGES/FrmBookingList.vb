Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmBookingList


    Public ActionMode As String = ""
    Public OldBkno As String = ""
    Public CntrCount As Integer = 0
    Dim CountTotal = 0.00, kgs = 0.00, cbm As Double = 0.00
    Dim MainDetail As String = ""
    Public BLTermIs As String = ""

    Public SelectedTrade As String = "" '15
    Public SelectedSubTrade As String = "" '16
    Public ModeIs As String = ""
    Public SelServiceIs = "", SelBookingType As String = ""
    Public OneWayFreeUse As String = ""
    Public CorrectionNoticeRevised As String = ""

    Public Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call Search(dtFrom.Value, dtTo.Value)
    End Sub

    Public Sub Search(DtFrom As DateTime, DtTo As DateTime)


        'dtList.Columns(16).DisplayIndex = dtList.ColumnCount - 1
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        'SQL = "SELECT b.DateTrans, B.BKNO, C_Shipper.ClientName, C_Consignee.ClientName,C_Notify.ClientName,  V_F.VESSELNAME, b.fvoyage1st, FV2.VESSELNAME, B.FVoyage2nd , V_M.VESSELNAME, b.mvoyage, T.NAME, ST.NAME, P.NAME, B.KGS, B.CBM, B.TermsIs, B.Stat,b.BKNO, B.Sysref FROM TBL_BOOKING AS B LEFT JOIN TBL_CLIENT AS C_Shipper on b.Shipper = C_Shipper.ID LEFT JOIN TBL_CLIENT AS C_Consignee on b.Consignee = C_Consignee.id LEFT JOIN TBL_CLIENT AS C_Notify ON B.Notify = C_Notify.ID LEFT JOIN TBL_VESSEL AS V_F ON B.FeederVessel1st = V_F.ID LEFT JOIN TBL_VESSEL AS V_M ON B.MotherVessel = V_M.ID LEFT JOIN TBL_VESSEL AS FV2 ON B.FeederVessel2nd = FV2.ID  LEFT JOIN TBL_TRADE AS T ON B.TRADE = t.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST ON B.SUB_TRADE = ST.ID LEFT JOIN TBL_PORTS AS P ON B.PORTS = P.ID  WHERE (B.STAT <> '2' OR B.STAT <> '0') AND   B.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND CONVERT(DATE,B.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "'"
        'SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') ORDER BY BK.BKNO DESC"

        If LandingForm.ServiceIs = "E" Then
            'Select Case cmbCategory.Text
            '    Case "BOOKING NO."
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "REFNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "')  AND BK.REFNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "BLNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BLNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "SHIPPER"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND SHIPPER.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "CONSIGNEE"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND CONSIGNEE.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL  ORDER BY BK.BKNO DESC"
            '    Case "FEEDER & MOTHER VSL"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFVessel.Text) & "%' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbFVoyage.Text) & "%' AND ISNULL(MV.VESSELNAME,'') LIKE '" & KVal(cmbMVessel.Text) & "%' AND ISNULL(MVOYAGE,'') LIKE '" & KVal(CmbMVoyage.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "FLOAT"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')  AND BK.FloatRecord = '1' AND bm.CardName IS NOT NULL ORDER BY BK.BKNO DESC"
            'End Select
            'live
            Select Case cmbCategory.Text
                Case "BOOKING NO."
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
                Case "REFNO"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "')  AND BK.REFNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
                Case "BLNO"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BLNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
                Case "SHIPPER"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND bm.CardName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
                Case "CONSIGNEE"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND CONSIGNEE.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL  ORDER BY BK.ID DESC"
                Case "FEEDER & MOTHER VSL"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFVessel.Text) & "%' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbFVoyage.Text) & "%' AND ISNULL(MV.VESSELNAME,'') LIKE '" & KVal(cmbMVessel.Text) & "%' AND ISNULL(MVOYAGE,'') LIKE '" & KVal(CmbMVoyage.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
                Case "FLOAT"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')  AND BK.FloatRecord = '1' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            End Select

            'local
            'Select Case cmbCategory.Text
            '    Case "BOOKING NO."
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "REFNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "')  AND BK.REFNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "BLNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BLNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "SHIPPER"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND bm.CardName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "CONSIGNEE"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND CONSIGNEE.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL  ORDER BY BK.ID DESC"
            '    Case "FEEDER & MOTHER VSL"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFVessel.Text) & "%' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbFVoyage.Text) & "%' AND ISNULL(MV.VESSELNAME,'') LIKE '" & KVal(cmbMVessel.Text) & "%' AND ISNULL(MVOYAGE,'') LIKE '" & KVal(CmbMVoyage.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "FLOAT"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.CardName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.cardcode, bm.address, bk.shipper, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm on bm.cardcode = bk.Shipper WHERE          (BK.Stat <> N'2')  AND BK.FloatRecord = '1' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            'End Select

        ElseIf LandingForm.ServiceIs = "I" Then
            'Select Case cmbCategory.Text
            '    Case "BOOKING NO."
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "REFNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "')  AND BK.REFNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "BLNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BLNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "SHIPPER"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND SHIPPER.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "CONSIGNEE"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND CONSIGNEE.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL  ORDER BY BK.BKNO DESC"
            '    Case "FEEDER & MOTHER VSL"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFVessel.Text) & "%' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbFVoyage.Text) & "%' AND ISNULL(MV.VESSELNAME,'') LIKE '" & KVal(cmbMVessel.Text) & "%' AND ISNULL(MVOYAGE,'') LIKE '" & KVal(CmbMVoyage.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.BKNO DESC"
            '    Case "FLOAT"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')  AND BK.FloatRecord = '1' AND bm.CardName IS NOT NULL ORDER BY BK.BKNO DESC"
            'End Select
            'live
            Select Case cmbCategory.Text
                Case "BOOKING NO."
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
                Case "REFNO"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "')  AND BK.REFNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
                Case "BLNO"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BLNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
                Case "SHIPPER"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND bm.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
                Case "CONSIGNEE"

                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND CONSIGNEE.CardName  LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL  ORDER BY BK.ID DESC"
                Case "FEEDER & MOTHER VSL"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFVessel.Text) & "%' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbFVoyage.Text) & "%' AND ISNULL(MV.VESSELNAME,'') LIKE '" & KVal(cmbMVessel.Text) & "%' AND ISNULL(MVOYAGE,'') LIKE '" & KVal(CmbMVoyage.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
                Case "FLOAT"
                    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')  AND BK.FloatRecord = '1' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            End Select

            'local
            'Select Case cmbCategory.Text
            '    Case "BOOKING NO."
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "REFNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "')  AND BK.REFNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "BLNO"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BLNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "SHIPPER"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND bm.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "CONSIGNEE"

            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND CONSIGNEE.CardName  LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL  ORDER BY BK.ID DESC"
            '    Case "FEEDER & MOTHER VSL"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFVessel.Text) & "%' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbFVoyage.Text) & "%' AND ISNULL(MV.VESSELNAME,'') LIKE '" & KVal(cmbMVessel.Text) & "%' AND ISNULL(MVOYAGE,'') LIKE '" & KVal(CmbMVoyage.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' AND bm.ClientName IS NOT NULL ORDER BY BK.ID DESC"
            '    Case "FLOAT"
            '        SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, bm.ClientName AS SHIPPER, CONSIGNEE.cardname AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord, bm.ID, consignee.address, bk.consignee, bk.FeederVessel1st, bk.MotherVessel  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = convert(nvarchar(50),SHIPPER.ID) LEFT JOIN 
            '                [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS CONSIGNEE ON BK.Consignee = CONSIGNEE.cardcode LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID LEFT JOIN TBL_CLIENT as bm on bm.ID = bk.Shipper WHERE          (BK.Stat <> N'2')  AND BK.FloatRecord = '1' AND bm.CardName IS NOT NULL ORDER BY BK.ID DESC"
            'End Select


        End If



        'Case "BOOKING NO."
        '    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BKNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' ORDER BY BK.BKNO DESC"
        'Case "REFNO"
        '    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "')  AND BK.REFNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' ORDER BY BK.BKNO DESC"
        'Case "BLNO"
        '    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND BK.BLNO LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' ORDER BY BK.BKNO DESC"
        'Case "SHIPPER"
        '    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND SHIPPER.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' ORDER BY BK.BKNO DESC"
        'Case "CONSIGNEE"
        '    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')   AND (CONVERT(DATE, BK.DateTrans) BETWEEN '" & DtFrom & "' AND '" & DtTo & "') AND CONSIGNEE.ClientName LIKE '" & KVal(cmbValue.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%'  ORDER BY BK.BKNO DESC"
        'Case "FEEDER & MOTHER VSL"
        '    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')   AND V1.VESSELNAME LIKE '" & KVal(cmbFVessel.Text) & "%' AND ISNULL(BK.FVoyage1st,'') LIKE '" & KVal(cmbFVoyage.Text) & "%' AND ISNULL(MV.VESSELNAME,'') LIKE '" & KVal(cmbMVessel.Text) & "%' AND ISNULL(MVOYAGE,'') LIKE '" & KVal(CmbMVoyage.Text) & "%' AND BK.BKNO LIKE 'BKN" & LandingForm.ServiceIs & "-%' ORDER BY BK.BKNO DESC"
        'Case "FLOAT"
        '    SQL = "SELECT BK.DateTrans, OP.OUTPORT, BK.BKNO, SHIPPER.ClientName AS SHIPPER, CONSIGNEE.ClientName AS CONSIGNEE, NOTIFY.ClientName AS NOTIFY, V1.VESSELNAME as FeederVEsselName1st, BK.FVoyage1st as FeederVEsselVoyage1st, POL1.NAME + ' /' + POD1.NAME  as FeederVEssel1stPolPod, v2.VESSELNAME as FeederVEsselName2nd  , BK.FVoyage2nd ,  POL2.NAME + ' ' + POD2.NAME  as FeederVEsselPolPod2nd,   MV.VESSELNAME as MotherVessel , MVoyage , MVPOL.NAME as MotherVesselPol , TR.NAME as MotherVesselPolPod , st.NAME as subtrade, PRT.NAME AS PORTIS , BK.KGS, BK.CBM , BK.TermsIs, BK.Stat, BK.Sysref, BK.REASON, BK.REFNO, BK.BLNO, POD1.NAME as FeederPod, BK.FloatRecord  FROM TBL_BOOKING AS BK LEFT JOIN TBL_OUTPORT AS OP ON BK.OptnMode = OP.ID LEFT JOIN TBL_CLIENT AS SHIPPER ON BK.Shipper = SHIPPER.ID LEFT JOIN TBL_CLIENT AS CONSIGNEE ON BK.Consignee = CONSIGNEE.ID LEFT JOIN TBL_CLIENT AS NOTIFY ON BK.Notify = NOTIFY.ID LEFT JOIN TBL_VESSEL AS V1 ON BK.FeederVessel1st = V1.ID LEFT JOIN TBL_VESSEL AS V2 ON BK.FeederVessel2nd = V2.ID LEFT JOIN TBL_VESSEL AS MV ON BK.MotherVessel = MV.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL1 ON BK.FeederPOL1st = POL1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD1 ON BK.FeederPOD1st = POD1.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POL2 ON BK.FeederVessel2ndPOL = POL2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS POD2 ON BK.FeederVessel2ndPOD = POD2.ID LEFT JOIN TBL_LOADING_UNLOADING_PORT AS MVPOL ON BK.MotherVesselLoading = MVPOL.ID LEFT JOIN TBL_TRADE AS TR ON BK.TRADE = TR.ID LEFT JOIN TBL_SUB_TRADE_OPTIONS AS ST on bk.SUB_TRADE = st.ID LEFT JOIN TBL_PORTS AS PRT ON BK.PORTS = PRT.ID WHERE          (BK.Stat <> N'2')  AND BK.FloatRecord = '1' ORDER BY BK.BKNO DESC"
        'End Select


        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With dtList
            .Rows.Clear()
            Do While Dbo.reader.Read

                .Rows.Add(Format(CDate(Dbo.reader(0).ToString), "MM-dd-yyyy"))
                For i As Integer = 1 To 24
                    'If i = 9 Then
                    '    .Rows(.RowCount - 1).Cells(i).Value = FormatMoneyN(Dbo.reader(i - 2).ToString)
                    'ElseIf i = 10 Then
                    '    .Rows(.RowCount - 1).Cells(i).Value = FormatWDecimal(Dbo.reader(i).ToString, "0.000")
                    'Else
                    If i = 21 Then
                        If KVal(Dbo.reader(i).ToString) = "3" Then
                            .Rows(.RowCount - 1).Cells(i).Value = "INITIAL"
                            .Rows(.RowCount - 1).Cells(23).Value = ImageList4.Images(0)
                        ElseIf KVal(Dbo.reader(i).ToString) = "1" Then
                            .Rows(.RowCount - 1).Cells(i).Value = "CONFIRMED"
                            .Rows(.RowCount - 1).Cells(23).Value = ImageList4.Images(1)
                        ElseIf KVal(Dbo.reader(i).ToString) = "0" Then
                            .Rows(.RowCount - 1).Cells(i).Value = "CANCELLED"
                            .Rows(.RowCount - 1).Cells(23).Value = ImageList4.Images(2)
                        ElseIf KVal(Dbo.reader(i).ToString) = "4" Then
                            .Rows(.RowCount - 1).Cells(i).Value = "REBOOKED"
                            .Rows(.RowCount - 1).Cells(23).Value = ImageList4.Images(3)
                        End If
                        .Rows(.RowCount - 1).Cells(i).Style.Font = New Font("Calibri", 9, FontStyle.Bold)
                    ElseIf i = 22
                        .Rows(.RowCount - 1).Cells(i).Value = KVal(Dbo.reader(23).ToString)
                        .Rows(.RowCount - 1).Cells(i).Style.Font = New Font("Calibri", 9, FontStyle.Bold)
                    ElseIf i = 23 Then
                        .Rows(.RowCount - 1).Cells(24).Value = KVal(Dbo.reader(24).ToString)
                    ElseIf i = 24 Then
                        .Rows(.RowCount - 1).Cells(25).Value = KVal(Dbo.reader(25).ToString)
                    Else
                        .Rows(.RowCount - 1).Cells(i).Value = KValnQuote(Dbo.reader(i).ToString)
                    End If

                    'MsgBox(.Columns(i).HeaderText & " / " & Dbo.reader(i).ToString)
                    'End If

                Next
                If Dbo.reader(27).ToString = "1" Then
                    .Rows(.RowCount - 1).Cells(.ColumnCount - 1).Value = ImageList6.Images(0)
                Else
                    .Rows(.RowCount - 1).Cells(.ColumnCount - 1).Value = ImageList5.Images(1)
                End If

                .Rows(.RowCount - 1).Cells(26).Tag = Dbo.reader(27).ToString
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(2).ToString 'BKNO
                .Rows(.RowCount - 1).Cells(1).Tag = Dbo.reader(22).ToString 'SYSREF
                .Rows(.RowCount - 1).Cells(2).Tag = Dbo.reader(21).ToString 'STAT
                .Rows(.RowCount - 1).Cells(3).Tag = Dbo.reader(28).ToString 'CARDCODE
                .Rows(.RowCount - 1).Cells(4).Tag = Dbo.reader(29).ToString 'CARD_ADDRESS


                .Rows(.RowCount - 1).Cells(5).Tag = Dbo.reader(30).ToString 'shipper/consignee code
                .Rows(.RowCount - 1).Cells(6).Tag = Dbo.reader(31).ToString 'FirstFeederVessel Code
                .Rows(.RowCount - 1).Cells(7).Tag = Dbo.reader(32).ToString 'MotherVessel Code



            Loop
            If Not dtList.RowCount = 0 Then
                dtList.Rows(0).Cells(0).Selected = True
            End If
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

    End Sub

    Public Sub FrmBookingList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With cmbCategory.Items
            .Clear()
            .Add("BOOKING NO.")
            .Add("REFNO")
            .Add("BLNO")
            .Add("SHIPPER")
            .Add("CONSIGNEE")
            .Add("FEEDER & MOTHER VSL")
            .Add("FLOAT")
        End With
        cmbCategory.SelectedIndex = 0
        Call LoadStrCmb(cmbMVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
        Call LoadStrCmb(cmbFVessel, "SELECT ID, VESSELNAME FROM TBL_VESSEL WHERE STAT = '1'")
        dtList.Columns(2).DisplayIndex = 2
        dtList.Columns(24).DisplayIndex = 3
        dtList.Columns(25).DisplayIndex = 4
        'dtList.Columns(23).DisplayIndex = 3
        dtList.Columns(23).DisplayIndex = 0
        dtList.Columns(dtList.ColumnCount - 1).DisplayIndex = 0
        Call Search(dtFrom.Value, dtTo.Value)

        If LandingForm.ServiceIs = "E" Then
            ToolStripMenuItem16.Visible = True
            APPLYBLNOToolStripMenuItem.Visible = False
        Else
            ToolStripMenuItem16.Visible = False
            APPLYBLNOToolStripMenuItem.Visible = True
        End If


    End Sub

    Private Sub dtList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContentClick

    End Sub

    'Private Sub dtList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellDoubleClick
    '    With FrmInitialBooking
    '        LandingForm.Modeis = "EDIT"
    '        Call FrmInitialBooking.LoadAll()
    '        Dim Dbo As New SQLClass
    '        Dbo.SqlCon.Open()
    '        SQL = "SELECT Sysref, DateTrans, BKNO, Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, FeederVessel, MotherVessel, Destination, NumberDescription, DatePullOut, StuffingLoadingPlace, KGS, CBM, PARAM1, DateAdded, AddedBy, STAT ,Depot, DepotAddress, ReleasingChecker, OperatingHours, EtaMnl, ClosingTime, ViaPort, LOADING, REMARKS FROM TBL_BOOKING WHERE ID = '" & dtList.CurrentRow.Cells(0).Tag & "' AND STAT = '1'"
    '        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
    '        Dbo.reader = Dbo.SQLCmd.ExecuteReader
    '        Do While Dbo.reader.Read
    '            .dtDate.Value = Dbo.reader(1).ToString
    '            .cmbShipper.Text = Dbo.reader(3).ToString
    '            .txtShipperAddress.Text = Dbo.reader(4).ToString
    '            .cmbConsignee.Text = Dbo.reader(5).ToString
    '            .txtConsigneeAddress.Text = Dbo.reader(6).ToString
    '            .cmbNotify.Text = Dbo.reader(7).ToString
    '            .txtNotifyAddress.Text = Dbo.reader(8).ToString
    '            .cmbFeederVessel.Text = Dbo.reader(9).ToString
    '            .cmbMotherVessel.Text = Dbo.reader(10).ToString
    '            .cmbDestination.Text = Dbo.reader(11).ToString
    '            .txtMarksDesc.Text = Dbo.reader(12).ToString
    '            .txtKgs.Text = Dbo.reader(15).ToString
    '            .txtCbm.Text = Dbo.reader(16).ToString
    '            .dtPullOut.Value = Dbo.reader(13).ToString
    '            .cmbStuffingLoadingPlace.Text = Dbo.reader(14).ToString
    '            .lblSysref.Text = Dbo.reader(0).ToString
    '            .lblBkNo.Text = Dbo.reader(2).ToString
    '            .cmbDepot.Text = Dbo.reader(21).ToString
    '            .txtDeportAddress.Text = Dbo.reader(22).ToString
    '            .cmbReleasingChecker.Text = Dbo.reader(23).ToString
    '            .txtOperatingHours.Text = Dbo.reader(24).ToString
    '            .txtEtaMnl.Text = Dbo.reader(25).ToString
    '            .txtClosingTime.Text = Dbo.reader(26).ToString
    '            .txtViaPort.Text = Dbo.reader(27).ToString
    '            .cmbLoading.Text = Dbo.reader(28).ToString
    '            .txtRemarks.Text = Dbo.reader(29).ToString
    '        Loop
    '        Dbo.reader.Close()
    '        Dbo.SqlCon.Close()

    '        Call lOADContainers(.lblSysref.Text, .lblBkNo.Text)
    '        Call LoadTruckers(.lblSysref.Text, .lblBkNo.Text)
    '        Call .cmbShipper_LostFocus(e, e)
    '        Call .cmbConsignee_LostFocus(e, e)
    '        Call .cmbNotify_LostFocus(e, e)
    '        Call LoadForm(FrmInitialBooking, "EDIT BOOKING")
    '    End With
    'End Sub

    Public Sub lOADContainers(SYSREF As String, BKNO As String, StatIs As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT Count, SizeIs, ContainerNo, SealNo,ID, LoadingPlace, DatePullout,cOUNTiS, PackagingType, Kgs, Cbm, GateInDate, VGM, CargoType   FROM TBL_CONTAINER WHERE (STAT  = '1' OR STAT <> '2') AND  BKNO = '" & BKNO & "' AND SYSREF = '" & SYSREF & "'  AND STAT = '" & StatIs & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With FrmInitialBooking.dtContainers
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(5).ToString, Dbo.reader(6).ToString, Dbo.reader(7).ToString, Dbo.reader(8).ToString, Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(11).ToString, Dbo.reader(12).ToString, Dbo.reader(13).ToString)
                '.Rows(.RowCount - 1).Cells(11).Value = Dbo.reader(11).ToString
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(4).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub
    Public Sub LoadTruckers(SYSREF As String, BKNO As String, StatIs As String)
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT T.TRUCKER, TU.TRUCKER, T.ID FROM TBL_TRUCKER_OPERATIONS AS T LEFT JOIN TBL_TRUCKER AS TU ON T.TRUCKER = TU.ID WHERE (T.STAT <> '0' AND T.STAT <> '2') AND T.SYSREF = '" & SYSREF & "' AND T.BKNO = '" & BKNO & "' AND T.STAT = '" & StatIs & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With FrmInitialBooking.dtTrucker
            .Rows.Clear()

            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString)
                .Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(2).ToString
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    'Private Sub btnViewDetails_Click(sender As Object, e As EventArgs) Handles btnViewDetails.Click
    '    With FrmInitialBooking
    '        LandingForm.Modeis = "EDIT"
    '        Call FrmInitialBooking.LoadAll()
    '        Dim Dbo As New SQLClass
    '        Dbo.SqlCon.Open()
    '        SQL = "SELECT Sysref, DateTrans, BKNO, Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, FeederVessel, MotherVessel, Destination, NumberDescription, DatePullOut, StuffingLoadingPlace, KGS, CBM, PARAM1, DateAdded, AddedBy, STAT ,Depot, DepotAddress, ReleasingChecker, OperatingHours, EtaMnl, ClosingTime, ViaPort, LOADING, REMARKS FROM TBL_BOOKING WHERE ID = '" & dtList.CurrentRow.Cells(0).Tag & "' AND STAT = '1'"
    '        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
    '        Dbo.reader = Dbo.SQLCmd.ExecuteReader
    '        Do While Dbo.reader.Read
    '            .dtDate.Value = Dbo.reader(1).ToString
    '            .cmbShipper.Text = Dbo.reader(3).ToString
    '            .txtShipperAddress.Text = Dbo.reader(4).ToString
    '            .cmbConsignee.Text = Dbo.reader(5).ToString
    '            .txtConsigneeAddress.Text = Dbo.reader(6).ToString
    '            .cmbNotify.Text = Dbo.reader(7).ToString
    '            .txtNotifyAddress.Text = Dbo.reader(8).ToString
    '            .cmbFeederVessel.Text = Dbo.reader(9).ToString
    '            .cmbMotherVessel.Text = Dbo.reader(10).ToString
    '            .cmbDestination.Text = Dbo.reader(11).ToString
    '            .txtMarksDesc.Text = Dbo.reader(12).ToString
    '            .txtKgs.Text = Dbo.reader(15).ToString
    '            .txtCbm.Text = Dbo.reader(16).ToString
    '            .dtPullOut.Value = Dbo.reader(13).ToString
    '            .cmbStuffingLoadingPlace.Text = Dbo.reader(14).ToString
    '            .lblSysref.Text = Dbo.reader(0).ToString
    '            .lblBkNo.Text = Dbo.reader(2).ToString
    '            .cmbDepot.Text = Dbo.reader(21).ToString
    '            .txtDeportAddress.Text = Dbo.reader(22).ToString
    '            .cmbReleasingChecker.Text = Dbo.reader(23).ToString
    '            .txtOperatingHours.Text = Dbo.reader(24).ToString
    '            .txtEtaMnl.Text = Dbo.reader(25).ToString
    '            .txtClosingTime.Text = Dbo.reader(26).ToString
    '            .txtViaPort.Text = Dbo.reader(27).ToString
    '            .cmbLoading.Text = Dbo.reader(28).ToString
    '            .txtRemarks.Text = Dbo.reader(29).ToString
    '        Loop
    '        Dbo.reader.Close()
    '        Dbo.SqlCon.Close()

    '        Call lOADContainers(.lblSysref.Text, .lblBkNo.Text)
    '        Call LoadTruckers(.lblSysref.Text, .lblBkNo.Text)
    '        Call .cmbShipper_LostFocus(e, e)
    '        Call .cmbConsignee_LostFocus(e, e)
    '        Call .cmbNotify_LostFocus(e, e)
    '        Call LoadForm(FrmInitialBooking, "EDIT BOOKING")
    '    End With
    'End Sub

    Private Sub btnGenerateBookingAcknowledgement_Click(sender As Object, e As EventArgs) Handles btnGenerateBookingAcknowledgement.Click
        LoadForm(FrmATWMenu, "GENERATE ATW (VOLUME)")
        Exit Sub
        'SET_SUBREPORT_CONNECTION
        If MsgBox("Generate ATW?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MainSysref = dtList.CurrentRow.Cells(1).Tag
            MainBkno = dtList.CurrentRow.Cells(0).Tag
            Dim Dbo As New SQLClass
            Dim objRep As New crGenerateNewATW

            Dbo.SqlCon.Open()
            SQL = "sp_GenerateATW;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()

            If objRep.Subreports.Count > 0 Then
                Dim Dbo2 As New SQLClass
                Dbo2.SqlCon.Open()
                SQL = "spGetBookedContainer;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(0).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()

            End If

            objRep.SetParameterValue("Sysref", MainSysref)
            objRep.SetParameterValue("BKNO", MainBkno)
            objRep.SetParameterValue("Useris", FNAME)



            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
            If ContSize = NoRecordFound Then
                ContSize = ""
            End If



            With FrmPrintForm
                objRep.SummaryInfo.ReportTitle = UCase(KVal("ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort))
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)

                .crViewer.AllowedExportFormats = formats
                '.crViewer.Name = "ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(150)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        End If
    End Sub

    Private Sub btnApplyContBooking_Click(sender As Object, e As EventArgs) Handles btnApplyContBooking.Click
        'LoadForm(FrmInitialBooking, "OPERATIONS BOOKING")

        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT LeasingContainer, COUNTIS,CONTSIZE,CONTBOOKINGNUM FROM TBL_CONTAINER_BOOKING  WHERE SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "' AND (STAT <> '0' AND STAT <> '2')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With FrmContainerBookingNumber.dtContainerListBooking
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        LoadForm(FrmContainerBookingNumber, "CONTAINER BOOKING")
    End Sub

    Public Sub dtList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellClick
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag




        SelSysref = dtList.CurrentRow.Cells(1).Tag
        SelBkNo = dtList.CurrentRow.Cells(0).Tag

        '3 and 5
        SelServiceIs = Mid(SelBkNo, 4, 1)
        SelBookingType = Mid(SelBkNo, 6, 1)
        'MsgBox(SelServiceIs)
        'MsgBox(SelBookingType)

        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        SelShipper = dtList.CurrentRow.Cells(3).Value
        SelConsignee = dtList.CurrentRow.Cells(4).Value
        SelPort = dtList.CurrentRow.Cells(17).Value '17
        SelStatIs = dtList.CurrentRow.Cells(2).Tag
    End Sub

    Private Sub btnFillOperation_Click(sender As Object, e As EventArgs) Handles btnFillOperation.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        If Not GetRyzk("SELECT BKNO FROM TBL_OPERATIONS WHERE STAT = '" & dtList.CurrentRow.Cells(2).Tag & "' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'", "L") = NoRecordFound Then
            MsgBox("Operations Data already existing!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LandingForm.Modeis = "NEW_OPERATIONS"

        With FrmInitialBooking
            Call .LoadOperationsCmb()
            .lblSysref.Text = MainSysref
            .txtBKNO.Text = MainBkno
            .pnlCS.Visible = False
            .PnlOperations.Visible = True
            .PnlOperations.Left = 0
            .Width = 530
        End With

        Call LoadForm(FrmInitialBooking, "OPERATIONS")
    End Sub



    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        LandingForm.Modeis = "VIEW"

        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag

        With FrmInitialBooking
            Call .LoadAll()
            Call .LoadOperationsCmb()
            .lblSysref.Text = MainSysref
            .txtBKNO.Text = MainBkno

            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity, TBL_BOOKING.PayableAt  , TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE           FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity, TBL_BOOKING.PayableAt  , TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, shipper.cardcode           FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                        [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            'live
            If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.ClientName, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON convert(nvarchar(50),TBL_BOOKING.Shipper) = convert(nvarchar(50),Shipper.ClientName) LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),TBL_BOOKING.Consignee) = convert(nvarchar(50),Consignee.cardcode) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE  (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
                SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
                        [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            Else
                SQL = "SELECT    TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, CONSIGNEE.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON  Shipper.id = TBL_BOOKING.Shipper LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
                        [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),Consignee.cardcode) = convert(nvarchar(50),TBL_BOOKING.Consignee) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2')  AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            End If
            'local
            'If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
            '    'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.ClientName, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON convert(nvarchar(50),TBL_BOOKING.Shipper) = convert(nvarchar(50),Shipper.ClientName) LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),TBL_BOOKING.Consignee) = convert(nvarchar(50),Consignee.cardcode) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE  (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            '    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
            '            [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            'Else
            '    SQL = "SELECT    TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, CONSIGNEE.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON  Shipper.id = TBL_BOOKING.Shipper LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
            '            [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),Consignee.cardcode) = convert(nvarchar(50),TBL_BOOKING.Consignee) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2')  AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            'End If


            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Dim SHIPPER As String = ""
            Do While Dbo.reader.Read
                .txtBKNO.Text = Dbo.reader(1).ToString
                .dtDate.Value = Dbo.reader(2).ToString
                .cmbOutPort.Text = Dbo.reader(3).ToString
                If Dbo.reader(3).ToString = "MANILA_ONLY" Then
                    .txtOutportId.Text = "00001"
                End If
                If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                    SHIPPER = Dbo.reader(4).ToString & " - " & Dbo.reader(54).ToString
                Else
                    SHIPPER = Dbo.reader(4).ToString
                End If

                If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNI") Then
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
                .dtEtaDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(31).ToString), Now, Dbo.reader(31).ToString)
                .dtEtdDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(32).ToString), Now, Dbo.reader(32).ToString)
                .dtClosingEndTime.Value = IIf(String.IsNullOrEmpty(Dbo.reader(33).ToString), Now, Dbo.reader(33).ToString)
                .cmbDeliveryPort.Text = Dbo.reader(38).ToString
                .txtViaPort.Text = Dbo.reader(35).ToString
                .dtArrastreCutoff.Value = IIf(String.IsNullOrEmpty(Dbo.reader(36).ToString), Now, Dbo.reader(36).ToString)
                .cmbCargoWeight.Text = Dbo.reader(37).ToString
                .txtNewBKNO.Text = Dbo.reader(39).ToString
                If String.IsNullOrEmpty(Dbo.reader(40).ToString) Then
                    .txtRefno.Text = "N/A"
                    .txtRefno.ForeColor = Color.FromArgb(15, 86, 172)
                Else
                    .txtRefno.Text = Dbo.reader(40).ToString
                    .txtRefno.ForeColor = Color.Black
                End If

                .cmbCommodity.Text = Dbo.reader(41).ToString
                .cmbPayableAt.Text = Dbo.reader(42).ToString

                ', TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno
                .dt1stVETA.Value = Dbo.reader(44).ToString
                .dt1stVETD.Value = Dbo.reader(45).ToString

                .dt2ndVETA.Value = Dbo.reader(46).ToString
                .dt2ndVETD.Value = Dbo.reader(47).ToString

                .dtMvETA.Value = Dbo.reader(48).ToString
                .dtMvETD.Value = Dbo.reader(49).ToString

                .txtCoLoaderBKNo.Text = Dbo.reader(50).ToString
                .dtFDEta.Value = Dbo.reader(51).ToString
                .dtFDEtd.Value = Dbo.reader(52).ToString

                .cmbServiceType.Text = Dbo.reader(53).ToString

            Loop
            .cmbShipper.Text = SHIPPER


            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Call lOADContainers(MainSysref, MainBkno, SelStatIs)
            Call LoadTruckers(MainSysref, MainBkno, SelStatIs)







            .pnlCS.Visible = True
            .PnlOperations.Visible = True
            .pnlCsSave.Visible = False
            .pnlOpsSave.Visible = False
            .btnAddTrucker.Enabled = False
            .btnAdd.Enabled = False
            .Width = "1200"
            .Height = "670"

            If dtList.CurrentRow.Cells(21).Value = "INITIAL" Then
                .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            ElseIf dtList.CurrentRow.Cells(21).Value = "CANCELLED" Then
                .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
                .lblBookingInfo.ForeColor = Color.Red
            ElseIf dtList.CurrentRow.Cells(21).Value = "CONFIRMED" Then
                .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            ElseIf dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
                .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
                .lblBookingInfo.ForeColor = Color.Orange
                .pnlOldBKNO.Visible = True
            End If
        End With

        'With FrmInitialBooking
        '    For Each c As Control In .Panel2.Controls
        '        If TypeOf c Is ComboBox Then
        '            c.Enabled = False
        '            c.BackColor = Color.White
        '        End If

        '    Next
        'End With

        Call LoadForm(FrmInitialBooking, "VIEW:" & MainBkno)
    End Sub

    Private Sub btnCancelBooking_Click(sender As Object, e As EventArgs) Handles btnCancelBooking.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag




        SelSysref = dtList.CurrentRow.Cells(1).Tag
        SelBkNo = dtList.CurrentRow.Cells(0).Tag

        '3 and 5
        SelServiceIs = Mid(SelBkNo, 4, 1)
        SelBookingType = Mid(SelBkNo, 6, 1)
        'MsgBox(SelServiceIs)
        'MsgBox(SelBookingType)

        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        SelShipper = dtList.CurrentRow.Cells(3).Value
        SelConsignee = dtList.CurrentRow.Cells(4).Value
        SelPort = dtList.CurrentRow.Cells(17).Value '17
        SelStatIs = dtList.CurrentRow.Cells(2).Tag


        'MainSysref = dtList.CurrentRow.Cells(1).Tag
        'MainBkno = dtList.CurrentRow.Cells(0).Tag
        'If dtList.CurrentRow.Cells(15).Value <> "INITIAL" Then
        '    MsgBox("Unable to cancel!", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
        'If MsgBox("Are you sure you want to cancel booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Call SetJob("UPDATE TBL_BOOKING SET STAT = '0' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '    Call SetJob("UPDATE TBL_CONTAINER SET STAT = '0' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '    Call SetJob("UPDATE TBL_CONTAINER_BOOKING SET STAT = '0' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '    Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '0' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '    Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET STAT = '0' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '    Call btnSearch_Click(e, e)
        '    MsgBox("Booking Cancelled!", MsgBoxStyle.Information)

        'End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        'MainSysref = dtList.CurrentRow.Cells(1).Tag
        'MainBkno = dtList.CurrentRow.Cells(0).Tag
        'If dtList.CurrentRow.Cells(15).Value <> "INITIAL" Then
        '    MsgBox("Unable to confirm booking!", MsgBoxStyle.Critical)
        '    Exit Sub
        'ElseIf dtList.CurrentRow.Cells(15).Value = "INITIAL" Then
        '    If MsgBox("Are you sure you want to confirm booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Call SetJob("UPDATE TBL_BOOKING SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        Call SetJob("UPDATE TBL_CONTAINER SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        Call SetJob("UPDATE TBL_CONTAINER_BOOKING SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
        '        Call btnSearch_Click(e, e)
        '        MsgBox("Booking Confirmed!", MsgBoxStyle.Information)

        '    End If
        'End If

    End Sub

    Private Sub btnCancelBooking_MouseClick(sender As Object, e As MouseEventArgs) Handles btnCancelBooking.MouseClick
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag



        If e.Button = MouseButtons.Left Then
            With CMSAction
                .Items(0).Text = MainBkno
                .Items(0).Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
                .Show(sender, 0, 0 - CMSAction.Height)
            End With

        End If

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
            MsgBox("Unable to cancel!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ActionMode = "CANCEL"
        With FrmReasons
            .pnlRebook.Visible = False
            .cmbReasons.Enabled = True
            .cmbReasons.Text = ""
            .BtnSave.Text = "SAVE"
        End With
        LoadForm(FrmReasons, "CANCEL BOOKING")
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
            MsgBox("Unable to rebook!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        ActionMode = "REBOOK"
        OldBkno = dtList.CurrentRow.Cells(2).Value
        LandingForm.BookingTypeIs = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(dtList.CurrentRow.Cells(2).Value, 6), 1)
        With FrmReasons
            .cmbReasons.Enabled = True
            .pnlRebook.Visible = True
            .BtnSave.Text = "CONFIRM"
            .cmbReasons.Text = ""
            .dtRebook.Value = dtList.CurrentRow.Cells(0).Value
        End With
        LoadForm(FrmReasons, "REBOOK")
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        ActionMode = "CONFIRM"
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        If dtList.CurrentRow.Cells(21).Value <> "INITIAL" Then
            MsgBox("Unable to confirm booking!", MsgBoxStyle.Critical)
            Exit Sub
        ElseIf dtList.CurrentRow.Cells(21).Value = "INITIAL" Then
            If MsgBox("Are you sure you want to confirm booking?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                LandingForm.BookingTypeIs = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(dtList.CurrentRow.Cells(2).Value, 6), 1)
                Dim REFNO As String = ""
                REFNO = GetRyzk("SELECT PARAM2 + PARAM1 +'-'+ PARAM3 FROM TBL_REFERENCE WHERE PARAM2 = 'KYW' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L") & Format(CDbl(GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'KYW' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")), "00000") & "-" & GetRyzk("SELECT YR FROM TBL_REFERENCE  WHERE PARAM2 = 'KYW' AND  PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")
                Call SetJob("UPDATE TBL_BOOKING SET STAT = '1', REFNO = '" & REFNO & "', ConfirmedBy = '" & USER_ID & "', DateConfirmed = '" & Now & "' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call SetJob("UPDATE TBL_CONTAINER SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call SetJob("UPDATE TBL_CONTAINER_BOOKING SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call SetJob("UPDATE TBL_OPERATIONS SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")
                Call SetJob("UPDATE TBL_TRUCKER_OPERATIONS SET STAT = '1' WHERE STAT = '3' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'")

                Dim CurSeries As Integer = 0
                CurSeries = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'KYW' AND    PARAM1 = '" & LandingForm.ServiceIs & "' AND PARAM3 = '" & LandingForm.BookingTypeIs & "'", "L")

                Call SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(CurSeries) + 1 & "'  WHERE PARAM2 = 'KYW' AND    PARAM1 = '" & LandingForm.ServiceIs & "'  AND PARAM3 = '" & LandingForm.BookingTypeIs & "'")

                Call btnSearch_Click(e, e)
                MsgBox("Booking Confirmed!", MsgBoxStyle.Information)

            End If
        End If
    End Sub

    Private Sub FrmBookingList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        If dtList.CurrentRow.Cells(21).Value <> "CONFIRMED" Then
            MsgBox("This booking is not yet confirmed!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If dtList.CurrentRow.Cells(25).Value <> "" Then
            MsgBox("Already has BLNO", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to generate BLNO for this booking number?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim BLNOis As String = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'MNL-'", "L")
            BLNOis = Format(CInt(BLNOis), "0000000")
            SetJob("Update TBL_BOOKING SET BLNO = '" & GetRyzk("SELECT PARAM2 FROM TBL_REFERENCE WHERE PARAM2 = 'MNL-'", "L") & BLNOis & "' WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'")
            SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(BLNOis) + 1 & "' WHERE PARAM2 = 'MNL-'")
            Call btnSearch_Click(e, e)
            MsgBox("Successfully generated!", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''''KYW-B
        ''''If dtList.CurrentRow.Cells(25).Value <> "" Then
        ''''    MsgBox("Already has BLNO", MsgBoxStyle.Critical)
        ''''    Exit Sub
        ''''End If
        ''''If MsgBox("Are you sure you want to generate BLNO for this booking number?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        ''''    Dim BLNOis As String = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'KYW-B-'", "L")
        ''''    BLNOis = Format(CInt(BLNOis), "00000")
        ''''    SetJob("Update TBL_BOOKING SET BLNO = '" & GetRyzk("SELECT PARAM2 FROM TBL_REFERENCE WHERE PARAM2 = 'KYW-B-'", "L") & BLNOis & "' WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'")
        ''''    SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(BLNOis) + 1 & "' WHERE PARAM2 = 'KYW-B-'")
        ''''    Call btnSearch_Click(e, e)
        ''''    MsgBox("Successfully generated!", MsgBoxStyle.Information)
        ''''    Exit Sub
        ''''End If
        '''''LoadForm(FrmBLForm, "BL")
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to set charges.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        frmSetCharges.pnlSettingsTemplate.Visible = False
        SelSysref = dtList.CurrentRow.Cells(1).Tag
        SelBkNo = dtList.CurrentRow.Cells(0).Tag
        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        SelectedTrade = dtList.CurrentRow.Cells(15).Value
        SelectedSubTrade = dtList.CurrentRow.Cells(16).Value

        Dim strChargesTemplate As String = ""
        strChargesTemplate = GetRyzk("SELECT * FROM TBL_CHARGES_TEMPLATE WHERE STAT = '1' AND Destination  = '" & SelectedTrade & "' AND Port = '" & SelectedSubTrade & "'", "L")

        If strChargesTemplate = NoRecordFound Then
            frmSetCharges.btnImportTemplateRates.Enabled = False
        Else
            frmSetCharges.btnImportTemplateRates.Enabled = True
        End If


        Call LoadForm(frmSetCharges, "SET CHARGES")
    End Sub

    Private Sub EDITBLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EDITBLToolStripMenuItem.Click
        'If dtList.CurrentRow.Cells(25).Value = "" Then
        '    MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        'With FrmBLForm
        '    CntrCount = 0
        '    CountTotal = 0.00
        '    kgs = 0.00
        '    cbm = 0.00
        '    MainDetail = ""
        '    BLTermIs = dtList.CurrentRow.Cells(20).Value
        '    With FrmBLForm.dtDescriptions
        '        .Rows.Clear()

        '        For i As Integer = 0 To 20
        '            .Rows.Add()
        '        Next
        '    End With


        '    If GetRyzk("SELECT BLNO FROM TBL_MARKS_AND_NUMBERS WHERE BLNO = '" & selBLno & "' AND STAT = '1'", "L") = NoRecordFound Then

        '        .txtBL.Text = selBLno
        '        Dim Dbo As New SQLClass
        '        Dbo.SqlCon.Open()
        '        'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
        '        SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
        '        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '        Dbo.SQLCmd.ExecuteNonQuery()
        '        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        '        Do While Dbo.reader.Read
        '            .lblOutRef.Text = selBLno
        '            .txtBL.Text = selBLno
        '            .lblTypeShipment.Text = SelBkNo
        '            .txtFromPortCode.Text = Dbo.reader(26).ToString
        '            .txtToPortCode.Text = Dbo.reader(27).ToString
        '            .txtShipper.Text = KVal(Dbo.reader(5).ToString)
        '            .txtShipperAddress.Text = KVal(Dbo.reader(6).ToString)
        '            .txtConsignee.Text = KVal(Dbo.reader(7).ToString)
        '            .txtConsigneeAddress.Text = KVal(Dbo.reader(8).ToString)
        '            .txtNotify1.Text = KVal(Dbo.reader(9).ToString)
        '            .txtNotifyAddress1.Text = KVal(Dbo.reader(10).ToString)
        '            .txtLocalVessel.Text = KVal(Dbo.reader(11).ToString) & " V-" & Dbo.reader(12).ToString
        '            .txtLocalVesselPOL.Text = Dbo.reader(13).ToString
        '            .txtOceanVessel.Text = KVal(Dbo.reader(19).ToString) & " V-" & Dbo.reader(20).ToString
        '            .txtOceanVesselPOL.Text = Dbo.reader(21).ToString
        '            If String.IsNullOrEmpty(Dbo.reader(24).ToString) Then
        '                .txtPortOfDischarge.Text = Dbo.reader(23).ToString
        '            Else
        '                .txtPortOfDischarge.Text = Dbo.reader(24).ToString
        '            End If
        '            If Dbo.reader(25).ToString = "C" Then
        '                .txtPayableAt.Text = Dbo.reader(28).ToString
        '            ElseIf Dbo.reader(25).ToString = "P" Then
        '                If String.IsNullOrEmpty(Dbo.reader(28).ToString) Then
        '                    .txtPayableAt.Text = ""
        '                Else
        '                    .txtPayableAt.Text = Dbo.reader(28).ToString
        '                End If
        '            End If
        '            .txtNosOfBL.Text = "THREE (3)"
        '            .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
        '            .dtOnBoardDate.Value = Now

        '        Loop
        '        Dbo.reader.Close()
        '        Dbo.SqlCon.Close()

        '        Call LoadContainersBL(SelBkNo)

        '        With .dtDescriptions
        '            .Rows(0).Cells(1).Value = CntrCount & " " & "CNTRS"
        '            Dim cntrAll As String = Replace(GetRyzk("SELECT  CONVERT(NVARCHAR,COUNT(SizeIs)) + 'X' + SizeIs + ' Z ' FROM TBL_CONTAINER WHERE BKNO = '" & SelBkNo & "' AND STAT = '1'GROUP BY SizeIs FOR XML PATH ('')", "L"), "Z", "& ")
        '            If Microsoft.VisualBasic.Right(cntrAll, 3) = "&  " Then
        '                cntrAll = Microsoft.VisualBasic.Mid(cntrAll, 1, Len(cntrAll) - 3)
        '            End If
        '            .Rows(1).Cells(2).Value = cntrAll & " CONTAINER(S) STC:"
        '            .Rows(0).Cells(2).Value = """" & "SHIPPER'S LOAD COUNT AND SEAL" & """" & "                         AS DECLARED"
        '            .Rows(1).Cells(0).Value = ""
        '            .Rows(1).Cells(1).Value = CountTotal
        '            .Rows(1).Cells(3).Value = FormatMoney(kgs)
        '            .Rows(2).Cells(3).Value = "KGS."

        '            .Rows(1).Cells(4).Value = FormatMoney(cbm)
        '            .Rows(2).Cells(4).Value = "CBM."

        '            .Rows(2).Cells(1).Value = MainDetail

        '            .Rows.Insert(1, "")
        '        End With








        '    Else



        '        Dim Dbo As New SQLClass
        '        Dbo.SqlCon.Open()
        '        SQL = "SELECT  Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel, OceanVesselPOL, POD, PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, AddedBy, DateAdded, Stat FROM TBL_BL WHERE BLNO = '" & selBLno & "' AND REFNO = '" & SelRefno & "' AND STAT  = '1'"
        '        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '        Dbo.SQLCmd.ExecuteNonQuery()
        '        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        '        Do While Dbo.reader.Read
        '            .lblOutRef.Text = SelRefno
        '            .txtBL.Text = selBLno
        '            .lblTypeShipment.Text = SelBkNo
        '            .txtShipper.Text = KVal(Dbo.reader(0).ToString)
        '            .txtShipperAddress.Text = KVal(Dbo.reader(1).ToString)
        '            .txtConsignee.Text = KVal(Dbo.reader(2).ToString)
        '            .txtConsigneeAddress.Text = KVal(Dbo.reader(3).ToString)
        '            .txtNotify1.Text = KVal(Dbo.reader(4).ToString)
        '            .txtNotifyAddress1.Text = KVal(Dbo.reader(5).ToString)
        '            .txtLocalVessel.Text = KVal(Dbo.reader(6).ToString)
        '            .txtLocalVesselPOL.Text = Dbo.reader(7).ToString
        '            .txtOceanVessel.Text = Dbo.reader(8).ToString
        '            .txtOceanVesselPOL.Text = Dbo.reader(9).ToString
        '            .txtPortOfDischarge.Text = Dbo.reader(10).ToString
        '            .txtPayableAt.Text = Dbo.reader(11).ToString
        '            .txtNosOfBL.Text = Dbo.reader(12).ToString
        '            .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
        '            .dtOnBoardDate.Value = Dbo.reader(14).ToString
        '            .txtFromPortCode.Text = Dbo.reader(15).ToString
        '            .txtToPortCode.Text = Dbo.reader(16).ToString
        '        Loop
        '        Dbo.reader.Close()
        '        Dbo.SqlCon.Close()



        '        Call LoadContainersBL(SelBkNo)

        '        With .dtDescriptions
        '            '.Rows.Clear()

        '            Dbo.SqlCon.Open()
        '            SQL = "SELECT MARK,PKGNos,DescriptionIs,KGS,CBM FROM TBL_MARKS_AND_NUMBERS WHERE STAT = '1' AND BLNO = '" & selBLno & "'   AND REFNO = '" & SelRefno & "' ORDER BY ID ASC"
        '            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        '            Dbo.reader = Dbo.SQLCmd.ExecuteReader
        '            .Rows.Clear()

        '            Do While Dbo.reader.Read
        '                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString)
        '            Loop
        '            Dbo.reader.Close()
        '            Dbo.SqlCon.Close()
        '        End With



        '    End If
        'End With

        'LoadForm(FrmBLForm, "BL FORM")
    End Sub

    Private Sub PRINTINGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRINTINGToolStripMenuItem.Click
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        LoadForm(FrmGenerateBlMenus, "BL MENUS")
    End Sub

    Private Sub RIDERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RIDERToolStripMenuItem.Click
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If selBLno = "" Then
            MsgBox("No BLNO assigned!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        With frmBLRider
            .lblRefno.Text = SelRefno
            .lblBlno.Text = selBLno
            .lblShipper.Text = SelShipper
            .lblConsignee.Text = SelConsignee
        End With
        LoadForm(frmBLRider, "BL RIDER")

    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Exit Sub
        If dtList.CurrentRow.Cells(2).Tag = "4" Then
            MsgBox("Unable to modify!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        LandingForm.Modeis = "EDIT"
        ActionMode = "EDIT"


        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag

        With FrmInitialBooking
            Call .LoadAll()
            Call .LoadOperationsCmb()
            .lblSysref.Text = MainSysref
            .txtBKNO.Text = MainBkno

            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Dim SHIPPER As String = ""
            Do While Dbo.reader.Read
                .txtBKNO.Text = Dbo.reader(1).ToString
                .dtDate.Value = Dbo.reader(2).ToString
                .cmbOutPort.Text = Dbo.reader(3).ToString
                If Dbo.reader(3).ToString = "MANILA_ONLY" Then
                    .txtOutportId.Text = "00001"
                End If
                SHIPPER = Dbo.reader(4).ToString
                .cmbConsignee.Text = Dbo.reader(5).ToString
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
                .dtEtaDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(31).ToString), Now, Dbo.reader(31).ToString)
                .dtEtdDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(32).ToString), Now, Dbo.reader(32).ToString)
                .dtClosingEndTime.Value = IIf(String.IsNullOrEmpty(Dbo.reader(33).ToString), Now, Dbo.reader(33).ToString)
                .cmbDeliveryPort.Text = Dbo.reader(38).ToString
                .txtViaPort.Text = Dbo.reader(35).ToString
                .dtArrastreCutoff.Value = IIf(String.IsNullOrEmpty(Dbo.reader(36).ToString), Now, Dbo.reader(36).ToString)
                .cmbCargoWeight.Text = Dbo.reader(37).ToString
                .txtNewBKNO.Text = Dbo.reader(39).ToString
                If String.IsNullOrEmpty(Dbo.reader(40).ToString) Then
                    .txtRefno.Text = "N/A"
                    .txtRefno.ForeColor = Color.FromArgb(15, 86, 172)
                Else
                    .txtRefno.Text = Dbo.reader(40).ToString
                    .txtRefno.ForeColor = Color.Black
                End If

                .cmbCommodity.Text = Dbo.reader(41).ToString
                .cmbPayableAt.Text = Dbo.reader(42).ToString
            Loop
            .cmbShipper.Text = SHIPPER


            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Call lOADContainers(MainSysref, MainBkno, SelStatIs)
            Call LoadTruckers(MainSysref, MainBkno, SelStatIs)


            .Button4.Visible = False







            .Button4.Visible = False
            .PnlRebook.Visible = True

            .pnlCS.Visible = True
            .PnlOperations.Visible = True
            .pnlCsSave.Visible = False
            .pnlOpsSave.Visible = False
            .btnAddTrucker.Enabled = True
            .btnAdd.Enabled = True
            .Width = "1053"
            .Height = "741"

            'If dtList.CurrentRow.Cells(21).Value = "INITIAL" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            'ElseIf dtList.CurrentRow.Cells(21).Value = "CANCELLED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            '    .lblBookingInfo.ForeColor = Color.Red
            'ElseIf dtList.CurrentRow.Cells(21).Value = "CONFIRMED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            'ElseIf dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & "ED" & " BOOKING DETAILS"
            '    .lblBookingInfo.ForeColor = Color.Orange
            '    .pnlOldBKNO.Visible = True
            'End If
        End With

        'With FrmInitialBooking
        '    For Each c As Control In .Panel2.Controls
        '        If TypeOf c Is ComboBox Then
        '            c.Enabled = False
        '            c.BackColor = Color.White
        '        End If

        '    Next
        'End With

        Call LoadForm(FrmInitialBooking, "EDIT:" & MainBkno)
    End Sub

    Private Sub MANIFESTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MANIFESTToolStripMenuItem.Click
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'Dim FeederPoolPod As String = Trim(dtList.CurrentRow.Cells(8).Value)
        'Dim FeederPod As String() = FeederPoolPod.Split("/")
        With FrmManifestMenus
            .cmbMVessel.Text = Trim(dtList.CurrentRow.Cells(12).Value)
            .cmbPod.Text = Trim(dtList.CurrentRow.Cells(17).Value)
            .cmbBlNo.Text = Trim(dtList.CurrentRow.Cells(25).Value)
        End With
        Call LoadForm(FrmManifestMenus, "MANIFEST")
    End Sub

    Private Sub CUSTOMERSERVICEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CUSTOMERSERVICEToolStripMenuItem.Click
        If dtList.CurrentRow.Cells(2).Tag = "4" Then
            MsgBox("Unable to modify!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        LandingForm.Modeis = "EDIT"
        ActionMode = "EDIT"


        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag

        With FrmInitialBooking
            Call .LoadAll()




            'Call .LoadOperationsCmb()
            .lblSysref.Text = MainSysref
            .txtBKNO.Text = MainBkno

            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE           FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            'live
            If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.ClientName, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON convert(nvarchar(50),TBL_BOOKING.Shipper) = convert(nvarchar(50),Shipper.ClientName) LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),TBL_BOOKING.Consignee) = convert(nvarchar(50),Consignee.cardcode) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE  (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
                SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
                        [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            Else
                SQL = "SELECT    TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, CONSIGNEE.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON  Shipper.id = TBL_BOOKING.Shipper LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
                        [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),Consignee.cardcode) = convert(nvarchar(50),TBL_BOOKING.Consignee) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2')  AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            End If

            'local
            'If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
            '    'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.ClientName, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON convert(nvarchar(50),TBL_BOOKING.Shipper) = convert(nvarchar(50),Shipper.ClientName) LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),TBL_BOOKING.Consignee) = convert(nvarchar(50),Consignee.cardcode) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE  (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            '    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, SHIPPER.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
            '            [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            'Else
            '    SQL = "SELECT    TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.cardname AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt, TBL_BOOKING.RegNo, TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno, TBL_BOOKING.FINAL_DEST_ETA, TBL_BOOKING.FINAL_DEST_ETD, TBL_BOOKING.SERVICETYPE, CONSIGNEE.CARDCODE, TBL_BOOKING.kyowaTagging                FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON  Shipper.id = TBL_BOOKING.Shipper LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
            '            [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON convert(nvarchar(50),Consignee.cardcode) = convert(nvarchar(50),TBL_BOOKING.Consignee) LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2')  AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            'End If



            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Dim SHIPPER As String = ""
            Dim ic As Integer = 0

            Do While Dbo.reader.Read

                .cmbTagging.SelectedIndex = .cmbTagging.FindStringExact(Dbo.reader(55).ToString)

                If .cmbTagging.SelectedIndex = -1 Then
                    .cmbTagging.SelectedIndex = .cmbTagging.FindStringExact("N/A")
                End If
                'If ic = 0 Then
                '    If Dbo.reader(1).ToString.Contains("BKNE") Then
                '        Call LoadStrCleintAcctg(FrmInitialBooking.cmbShipper, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                '        Call LoadStrCleint(FrmInitialBooking.cmbConsignee, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                '    ElseIf Dbo.reader(1).ToString.Contains("BKNE") Then
                '        Call LoadStrCleintAcctg(FrmInitialBooking.cmbConsignee, "SELECT BPListID, CASE WHEN NICKNAME IS NULL OR nickName = ''   THEN CardName ELSE nickName END  ++ ' - ' ++ CARDCODE as NICKNAME, Address, CARDCODE FROM              tblR_BPMasterData WHERE ((SUBSTRING(CARDCODE,1,2)) LIKE 'C%[0-9]%' OR (SUBSTRING(CARDCODE,1,2)) LIKE 'CN%') AND hideFromExternal = '0' and accessibleToKyowaSystem = '1'  ORDER BY CARDNAME")
                '        Call LoadStrCleint(FrmInitialBooking.cmbShipper, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                '    End If
                '    Call LoadStrCleint(FrmInitialBooking.cmbNotify, "SELECT ID, ClientName, Clientaddress FROM TBL_CLIENT WHERE CLIENTNAME IS NOT NULL AND CLIENTNAME <> ''")
                '    ic = 1
                'End If

                .txtBKNO.Text = Dbo.reader(1).ToString

                'If ic = 0 Then
                '    Call .LoadAll()
                '    ic = 1
                'End If

                .dtDate.Value = Dbo.reader(2).ToString
                .cmbOutPort.Text = Dbo.reader(3).ToString
                If Dbo.reader(3).ToString = "MANILA_ONLY" Then
                    .txtOutportId.Text = "00001"
                End If
                If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNE") Then
                    SHIPPER = Dbo.reader(4).ToString & " - " & Dbo.reader(54).ToString
                Else
                    SHIPPER = Dbo.reader(4).ToString
                End If

                If dtList.CurrentRow.Cells(2).Value.ToString.Contains("BKNI") Then
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
                .dtEtaDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(31).ToString), Now, Dbo.reader(31).ToString)
                .dtEtdDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(32).ToString), Now, Dbo.reader(32).ToString)
                .dtClosingEndTime.Value = IIf(String.IsNullOrEmpty(Dbo.reader(33).ToString), Now, Dbo.reader(33).ToString)
                .cmbDeliveryPort.Text = Dbo.reader(38).ToString
                .txtViaPort.Text = Dbo.reader(35).ToString
                .dtArrastreCutoff.Value = IIf(String.IsNullOrEmpty(Dbo.reader(36).ToString), Now, Dbo.reader(36).ToString)
                .cmbCargoWeight.Text = Dbo.reader(37).ToString
                .txtNewBKNO.Text = Dbo.reader(39).ToString
                If String.IsNullOrEmpty(Dbo.reader(40).ToString) Then
                    .txtRefno.Text = "N/A"
                    .txtRefno.ForeColor = Color.FromArgb(15, 86, 172)
                Else
                    .txtRefno.Text = Dbo.reader(40).ToString
                    .txtRefno.ForeColor = Color.Black
                End If

                .cmbCommodity.Text = Dbo.reader(41).ToString
                .cmbPayableAt.Text = Dbo.reader(42).ToString
                .txtRegistryNumber.Text = Dbo.reader(43).ToString
                ', TBL_BOOKING.F1_ETA, TBL_BOOKING.F1_ETD, TBL_BOOKING.F2_ETA, TBL_BOOKING.F2_ETD, TBL_BOOKING.MV_ETA, TBL_BOOKING.MV_ETD, TBL_BOOKING.CoLoaderBkno
                .dt1stVETA.Value = Dbo.reader(44).ToString
                .dt1stVETD.Value = Dbo.reader(45).ToString

                .dt2ndVETA.Value = Dbo.reader(46).ToString
                .dt2ndVETD.Value = Dbo.reader(47).ToString

                .dtMvETA.Value = Dbo.reader(48).ToString
                .dtMvETD.Value = Dbo.reader(49).ToString

                .txtCoLoaderBKNo.Text = Dbo.reader(50).ToString


                .dtFDEta.Value = Dbo.reader(51).ToString
                .dtFDEtd.Value = Dbo.reader(52).ToString

                .cmbServiceType.Text = Dbo.reader(53).ToString
            Loop
            .cmbShipper.Text = SHIPPER


            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Call lOADContainers(MainSysref, MainBkno, SelStatIs)
            Call LoadTruckers(MainSysref, MainBkno, SelStatIs)






            .Button4.Visible = False
            .PnlRebook.Visible = True

            .pnlCS.Visible = True
            .PnlOperations.Visible = True
            .pnlCsSave.Visible = False
            .pnlOpsSave.Visible = False
            .btnAddTrucker.Enabled = True
            .btnAdd.Enabled = True


            .Width = "1053"
            .Height = "741"

            .pnlCsSave.Visible = True
            .PnlRebook.Visible = False

            With FrmInitialBooking
                .lblBookingInfo.Text = "MODIFY - CS"
                .pnlCS.Visible = True
                .PnlOperations.Visible = False
                .pnlCS.Left = 10
                .Width = 670
            End With

            'If dtList.CurrentRow.Cells(21).Value = "INITIAL" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            'ElseIf dtList.CurrentRow.Cells(21).Value = "CANCELLED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            '    .lblBookingInfo.ForeColor = Color.Red
            'ElseIf dtList.CurrentRow.Cells(21).Value = "CONFIRMED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            'ElseIf dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & "ED" & " BOOKING DETAILS"
            '    .lblBookingInfo.ForeColor = Color.Orange
            '    .pnlOldBKNO.Visible = True
            'End If
        End With

        'With FrmInitialBooking
        '    For Each c As Control In .Panel2.Controls
        '        If TypeOf c Is ComboBox Then
        '            c.Enabled = False
        '            c.BackColor = Color.White
        '        End If

        '    Next
        'End With
        Call LoadForm(FrmInitialBooking, "EDIT:" & MainBkno)

    End Sub

    Private Sub DOCUMENTATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DOCUMENTATIONToolStripMenuItem.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        Dim StatIs As String = dtList.CurrentRow.Cells(2).Tag
        If GetRyzk("SELECT BKNO FROM TBL_OPERATIONS WHERE STAT = '" & dtList.CurrentRow.Cells(2).Tag & "' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'", "L") = NoRecordFound Then
            MsgBox("Please fill operation first!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        If dtList.CurrentRow.Cells(2).Tag = "4" Then
            MsgBox("Unable to modify!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        LandingForm.Modeis = "EDIT_OPERATIONS"
        ActionMode = "EDIT"


        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag

        With FrmInitialBooking
            Call .LoadAll()
            Call .LoadOperationsCmb()
            .lblSysref.Text = MainSysref
            .txtBKNO.Text = MainBkno

            Dim Dbo As New SQLClass
            Dbo.SqlCon.Open()
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity, TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "')"

            '12-20-22
            'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO and OP.Stat <> '2' LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE            (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "') AND TBL_BOOKING.STAT = '" & StatIs & "'"
            'live
            If LandingForm.ServiceIs = "E" Then
                SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
                        [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO and OP.Stat <> '2' LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE            (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "') AND TBL_BOOKING.STAT = '" & StatIs & "'"

            ElseIf LandingForm.ServiceIs = "I" Then
                SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.CARDNAME AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
                        [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON TBL_BOOKING.Consignee = Consignee.CARDCODE LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO and OP.Stat <> '2' LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE            (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "') AND TBL_BOOKING.STAT = '" & StatIs & "'"

            End If


            'local
            'If LandingForm.ServiceIs = "E" Then
            '    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.cardname AS Shipper, Consignee.ClientName AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
            '            [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Shipper ON TBL_BOOKING.Shipper = Shipper.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO and OP.Stat <> '2' LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE            (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "') AND TBL_BOOKING.STAT = '" & StatIs & "'"

            'ElseIf LandingForm.ServiceIs = "I" Then
            '    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Consignee.CARDNAME AS Consignee,                          Notify.ClientName AS Notify, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          V1stPOD.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs, TBL_BOOKING.NUMBERS_DESC, TBL_BOOKING.KGS, TBL_BOOKING.CBM, TBL_BOOKING.TermsIs, TBL_BOOKING.Stat, TBL_BOOKING.TRANSSHIPMENT, D.NAME AS DEPOT , OP.TelNo, OP.ReleasingChecker, OP.OperatingHrs, OP.EtaMnl, OP.EtdMnl, OP.CLosingStartTime, OP.DeliveryPort, OP.ViaPort, OP.ArrastreCutoff, OP.MaxCargo, LUP.NAME AS DeliveryPort, TBL_BOOKING.NEW_BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.commodity , TBL_BOOKING.PayableAt          FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN         TBL_LOADING_UNLOADING_PORT AS V1stPOD ON TBL_BOOKING.FeederPOD1st = V1stPOD.ID left join                TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
            '            [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON TBL_BOOKING.Consignee = Consignee.CARDCODE LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO and OP.Stat <> '2' LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID   WHERE            (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = N'" & MainSysref & "') AND (TBL_BOOKING.BKNO = N'" & MainBkno & "') AND TBL_BOOKING.STAT = '" & StatIs & "'"

            'End If

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            Dim SHIPPER As String = ""
            Do While Dbo.reader.Read
                .txtBKNO.Text = Dbo.reader(1).ToString
                .dtDate.Value = Dbo.reader(2).ToString
                .cmbOutPort.Text = Dbo.reader(3).ToString
                If Dbo.reader(3).ToString = "MANILA_ONLY" Then
                    .txtOutportId.Text = "00001"
                End If
                SHIPPER = Dbo.reader(4).ToString
                .cmbConsignee.Text = Dbo.reader(5).ToString
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
                .dtEtaDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(31).ToString), Now, Dbo.reader(31).ToString)
                .dtEtdDate.Value = IIf(String.IsNullOrEmpty(Dbo.reader(32).ToString), Now, Dbo.reader(32).ToString)
                .dtClosingEndTime.Value = IIf(String.IsNullOrEmpty(Dbo.reader(33).ToString), Now, Dbo.reader(33).ToString)
                .cmbDeliveryPort.Text = Dbo.reader(38).ToString
                .txtViaPort.Text = Dbo.reader(35).ToString
                .dtArrastreCutoff.Value = IIf(String.IsNullOrEmpty(Dbo.reader(36).ToString), Now, Dbo.reader(36).ToString)
                .cmbCargoWeight.Text = Dbo.reader(37).ToString
                .txtNewBKNO.Text = Dbo.reader(39).ToString
                If String.IsNullOrEmpty(Dbo.reader(40).ToString) Then
                    .txtRefno.Text = "N/A"
                    .txtRefno.ForeColor = Color.FromArgb(15, 86, 172)
                Else
                    .txtRefno.Text = Dbo.reader(40).ToString
                    .txtRefno.ForeColor = Color.Black
                End If

                .cmbCommodity.Text = Dbo.reader(41).ToString
                .cmbPayableAt.Text = Dbo.reader(42).ToString
            Loop
            .cmbShipper.Text = SHIPPER


            Dbo.reader.Close()
            Dbo.SqlCon.Close()
            Call lOADContainers(MainSysref, MainBkno, StatIs)
            Call LoadTruckers(MainSysref, MainBkno, StatIs)






            .Button4.Visible = False
            .PnlRebook.Visible = True

            .pnlCS.Visible = True
            .PnlOperations.Visible = True
            .pnlCsSave.Visible = False

            .btnAddTrucker.Enabled = True
            .btnAdd.Enabled = True
            .Width = "1053"
            .Height = "741"

            .pnlCsSave.Visible = True
            .PnlRebook.Visible = False
            .pnlOpsSave.Visible = True

            'With FrmInitialBooking
            '    .lblBookingInfo.Text = "MODIFY - OPERATIONS"
            '    .pnlCS.Visible = True
            '    .PnlOperations.Visible = False
            '    .pnlCS.Left = 10
            '    .Width = 540
            'End With

            'LandingForm.Modeis = "NEW_OPERATIONS"

            With FrmInitialBooking
                'Call .LoadOperationsCmb()
                .lblSysref.Text = MainSysref
                .txtBKNO.Text = MainBkno
                .pnlCS.Visible = False
                .PnlOperations.Visible = True
                .PnlOperations.Left = 0
                .Width = 530
            End With


            Call LoadForm(FrmInitialBooking, "EDIT:" & MainBkno)

            'If dtList.CurrentRow.Cells(21).Value = "INITIAL" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            'ElseIf dtList.CurrentRow.Cells(21).Value = "CANCELLED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            '    .lblBookingInfo.ForeColor = Color.Red
            'ElseIf dtList.CurrentRow.Cells(21).Value = "CONFIRMED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & " BOOKING DETAILS"
            'ElseIf dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
            '    .lblBookingInfo.Text = dtList.CurrentRow.Cells(21).Value & "ED" & " BOOKING DETAILS"
            '    .lblBookingInfo.ForeColor = Color.Orange
            '    .pnlOldBKNO.Visible = True
            'End If]
        End With

        'With FrmInitialBooking
        '    For Each c As Control In .Panel2.Controls
        '        If TypeOf c Is ComboBox Then
        '            c.Enabled = False
        '            c.BackColor = Color.White
        '        End If

        '    Next
        'End With

    End Sub


    Public Sub LoadContainersBL(bk As String)

        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT ContainerNo, SizeIs, CountIs, PackagingType, Kgs, CBM, SealNo FROM TBL_CONTAINER WHERE STAT = '1' AND BKNO = '" & bk & "'"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.SQLCmd.ExecuteNonQuery()
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With FrmBLForm.dtContainers
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, Dbo.reader(5).ToString, Dbo.reader(6).ToString)
                CountTotal = CountTotal + SaveMoney(Dbo.reader(2).ToString)
                kgs = kgs + SaveMoney(Dbo.reader(4).ToString)
                cbm = cbm + SaveMoney(Dbo.reader(5).ToString)
                MainDetail = Dbo.reader(3).ToString
                CntrCount = CntrCount + 1
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()
    End Sub

    Private Sub CMSAction_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles CMSAction.Opening

    End Sub

    Private Sub TSREPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TSREPORTToolStripMenuItem.Click
        FrmGenerateTSReport.ShowDialog()
    End Sub

    Private Sub BOOKINGLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BOOKINGLISTToolStripMenuItem.Click
        FrmGenerateBookingList.ShowDialog()
    End Sub

    Private Sub CHARGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CHARGESToolStripMenuItem.Click
        LoadForm(FrmRequestForPayment, "REQUEST FOR PAYMENT - CHARGES")
    End Sub

    Private Sub STORAGEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STORAGEToolStripMenuItem.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag




        SelSysref = dtList.CurrentRow.Cells(1).Tag
        SelBkNo = dtList.CurrentRow.Cells(0).Tag

        '3 and 5
        SelServiceIs = Mid(SelBkNo, 4, 1)
        SelBookingType = Mid(SelBkNo, 6, 1)
        'MsgBox(SelServiceIs)
        'MsgBox(SelBookingType)

        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        SelShipper = dtList.CurrentRow.Cells(3).Value
        SelConsignee = dtList.CurrentRow.Cells(4).Value
        SelPort = dtList.CurrentRow.Cells(17).Value '17
        SelStatIs = dtList.CurrentRow.Cells(2).Tag
    End Sub

    Private Sub cmbCategory_TextChanged(sender As Object, e As EventArgs) Handles cmbCategory.TextChanged, cmbCategory.SelectedIndexChanged

        Select Case cmbCategory.Text
            Case "BOOKING NO."
                cmbValue.Text = "BKN" & LandingForm.ServiceIs & "-"
                pnlAdvanceSearch.Visible = False
                dtFrom.Enabled = True
                dtTo.Enabled = True
            Case "REFNO"
                cmbValue.Text = "KYW" & LandingForm.ServiceIs & "-"
                pnlAdvanceSearch.Visible = False
                dtFrom.Enabled = True
                dtTo.Enabled = True
            Case "BLNO"
                cmbValue.Text = "MNL-"
                pnlAdvanceSearch.Visible = False
                dtFrom.Enabled = True
                dtTo.Enabled = True
            Case "SHIPPER"
                cmbValue.Text = ""
                pnlAdvanceSearch.Visible = False
                dtFrom.Enabled = True
                dtTo.Enabled = True
            Case "CONSIGNEE"
                cmbValue.Text = ""
                pnlAdvanceSearch.Visible = False
                dtFrom.Enabled = True
                dtTo.Enabled = True
            Case "FEEDER & MOTHER VSL"
                cmbValue.Text = ""
                pnlAdvanceSearch.Visible = True
                dtFrom.Enabled = False
                dtTo.Enabled = False
        End Select

    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        If dtList.CurrentRow.Cells(21).Value <> "CONFIRMED" Then
            MsgBox("This booking is not yet confirmed!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If dtList.CurrentRow.Cells(25).Value <> "" Then
            MsgBox("Already has BLNO", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to generate BLNO for this booking number?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim qry As String = "SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & Me.SelServiceIs & "' AND PARAM3 = '" & Me.SelBookingType & "'"
            Dim BLNOis As String = GetRyzk(qry, "L")

            BLNOis = Format(CInt(BLNOis), "0000000")
            SetJob("Update TBL_BOOKING SET BLNO = '" & GetRyzk("SELECT PARAM2 FROM TBL_REFERENCE WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & Me.SelServiceIs & "' AND PARAM3 = '" & Me.SelBookingType & "'", "L") & BLNOis & "' WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'")
            SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(BLNOis) + 1 & "' WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & Me.SelServiceIs & "'")
            Call btnSearch_Click(e, e)
            MsgBox("Successfully generated!", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        CorrectionNoticeRevised = ""
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to set charges.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        frmSetCharges.pnlSettingsTemplate.Visible = False
        SelSysref = dtList.CurrentRow.Cells(1).Tag
        SelBkNo = dtList.CurrentRow.Cells(0).Tag
        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        SelectedTrade = dtList.CurrentRow.Cells(15).Value
        SelectedSubTrade = dtList.CurrentRow.Cells(16).Value

        Dim strChargesTemplate As String = ""
        strChargesTemplate = GetRyzk("SELECT * FROM TBL_CHARGES_TEMPLATE WHERE STAT = '1' AND Destination  = '" & SelectedTrade & "' AND Port = '" & SelectedSubTrade & "'", "L")

        If strChargesTemplate = NoRecordFound Then
            frmSetCharges.btnImportTemplateRates.Enabled = False
        Else
            frmSetCharges.btnImportTemplateRates.Enabled = True
        End If


        Call LoadForm(frmSetCharges, "SET CHARGES")
    End Sub

    Private Sub DETAILSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DETAILSToolStripMenuItem.Click
        CorrectionNoticeRevised = ""
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With FrmBLForm
            .pnlCrn.Visible = False
            .txtCrn.Text = ""
            CntrCount = 0
            CountTotal = 0.00
            kgs = 0.00
            cbm = 0.00
            MainDetail = ""
            BLTermIs = dtList.CurrentRow.Cells(20).Value
            With FrmBLForm.dtDescriptions
                .Rows.Clear()

                For i As Integer = 0 To 20
                    .Rows.Add()
                Next
            End With


            If GetRyzk("SELECT BLNO FROM TBL_MARKS_AND_NUMBERS WHERE BLNO = '" & selBLno & "' AND STAT = '1'", "L") = NoRecordFound Then

                .txtBL.Text = selBLno
                Dim Dbo As New SQLClass
                Dbo.SqlCon.Open()
                'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                ''live
                If LandingForm.ServiceIs = "E" Then
                    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, bm.cardname AS Shipper, bm.address as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm ON TBL_BOOKING.Shipper = bm.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2')  AND (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                ElseIf LandingForm.ServiceIs = "I" Then
                    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, bm.ClientName AS Shipper, bm.Clientaddress as ShipperAddress, Consignee.CARDNAME AS Consignee, Consignee.ADDRESS as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT as bm ON TBL_BOOKING.Shipper = bm.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
                            [192.168.10.87].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON TBL_BOOKING.Consignee = Consignee.CARDCODE LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2')  AND (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                End If

                'local
                'If LandingForm.ServiceIs = "E" Then
                '    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, bm.cardname AS Shipper, bm.address as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         
                '  [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] as bm ON TBL_BOOKING.Shipper = bm.cardcode LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2')  AND (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                'ElseIf LandingForm.ServiceIs = "I" Then
                '    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, bm.ClientName AS Shipper, bm.Clientaddress as ShipperAddress, Consignee.CARDNAME AS Consignee, Consignee.ADDRESS as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT as bm ON TBL_BOOKING.Shipper = bm.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         
                '  [DESKTOP-NSDPC98].[ACCT_TEST].[DBO].[tblR_BPMasterData] AS Consignee ON TBL_BOOKING.Consignee = Consignee.CARDCODE LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2')  AND (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                'End If

                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.SQLCmd.ExecuteNonQuery()
                Dbo.reader = Dbo.SQLCmd.ExecuteReader
                Do While Dbo.reader.Read
                    .lblOutRef.Text = selBLno
                    .txtBL.Text = selBLno
                    .lblTypeShipment.Text = SelBkNo
                    .txtFromPortCode.Text = Dbo.reader(26).ToString
                    .txtToPortCode.Text = Dbo.reader(27).ToString
                    .txtShipper.Text = KVal(Dbo.reader(5).ToString)
                    .txtShipperAddress.Text = KVal(Dbo.reader(6).ToString)
                    .txtConsignee.Text = KVal(Dbo.reader(7).ToString)
                    .txtConsigneeAddress.Text = KVal(Dbo.reader(8).ToString)
                    .txtNotify1.Text = KVal(Dbo.reader(9).ToString)
                    .txtNotifyAddress1.Text = KVal(Dbo.reader(10).ToString)
                    .txtLocalVessel.Text = KVal(Dbo.reader(11).ToString) & " V-" & Dbo.reader(12).ToString
                    .txtLocalVesselPOL.Text = Dbo.reader(13).ToString
                    .txtOceanVessel.Text = KVal(Dbo.reader(19).ToString) & " V-" & Dbo.reader(20).ToString
                    .txtOceanVesselPOL.Text = Dbo.reader(21).ToString
                    If String.IsNullOrEmpty(Dbo.reader(24).ToString) Then
                        .txtPortOfDischarge.Text = Dbo.reader(23).ToString
                    Else
                        .txtPortOfDischarge.Text = Dbo.reader(24).ToString
                    End If
                    If Dbo.reader(25).ToString = "C" Then
                        .txtPayableAt.Text = Dbo.reader(28).ToString
                    ElseIf Dbo.reader(25).ToString = "P" Then
                        If String.IsNullOrEmpty(Dbo.reader(28).ToString) Then
                            .txtPayableAt.Text = ""
                        Else
                            .txtPayableAt.Text = Dbo.reader(28).ToString
                        End If
                    End If
                    .txtNosOfBL.Text = "THREE (3)"
                    .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
                    .dtOnBoardDate.Value = Now

                Loop
                Dbo.reader.Close()
                Dbo.SqlCon.Close()

                Call LoadContainersBL(SelBkNo)

                With .dtDescriptions
                    .Rows(0).Cells(1).Value = CntrCount & " " & "CNTRS"
                    Dim cntrAll As String = Replace(GetRyzk("SELECT  CONVERT(NVARCHAR,COUNT(SizeIs)) + 'X' + SizeIs + ' Z ' FROM TBL_CONTAINER WHERE BKNO = '" & SelBkNo & "' AND STAT = '1'GROUP BY SizeIs FOR XML PATH ('')", "L"), "Z", "& ")
                    If Microsoft.VisualBasic.Right(cntrAll, 3) = "&  " Then
                        cntrAll = Microsoft.VisualBasic.Mid(cntrAll, 1, Len(cntrAll) - 3)
                    End If
                    .Rows(1).Cells(2).Value = cntrAll & " CONTAINER(S) STC:"
                    .Rows(0).Cells(2).Value = """" & "SHIPPER'S LOAD COUNT AND SEAL" & """" & "                         AS DECLARED"
                    .Rows(1).Cells(0).Value = ""
                    .Rows(2).Cells(1).Value = CountTotal
                    .Rows(2).Cells(3).Value = FormatMoney(kgs)
                    .Rows(3).Cells(3).Value = "KGS."

                    .Rows(2).Cells(4).Value = FormatMoney(cbm)
                    .Rows(3).Cells(4).Value = "CBM."

                    .Rows(3).Cells(1).Value = MainDetail

                    .Rows.Insert(1, "")
                End With








            Else



                Dim Dbo As New SQLClass
                Dbo.SqlCon.Open()
                SQL = "SELECT  Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel, OceanVesselPOL, POD, PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, AddedBy, DateAdded, Stat, DateIssue FROM TBL_BL WHERE BLNO = '" & selBLno & "' AND REFNO = '" & SelRefno & "' AND STAT  = '1'"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.ExecuteNonQuery()
                Dbo.reader = Dbo.SQLCmd.ExecuteReader
                Do While Dbo.reader.Read
                    .lblOutRef.Text = SelRefno
                    .txtBL.Text = selBLno
                    .lblTypeShipment.Text = SelBkNo
                    .txtShipper.Text = KVal(Dbo.reader(0).ToString)
                    .txtShipperAddress.Text = KVal(Dbo.reader(1).ToString)
                    .txtConsignee.Text = KVal(Dbo.reader(2).ToString)
                    .txtConsigneeAddress.Text = KVal(Dbo.reader(3).ToString)
                    .txtNotify1.Text = KVal(Dbo.reader(4).ToString)
                    .txtNotifyAddress1.Text = KVal(Dbo.reader(5).ToString)
                    .txtLocalVessel.Text = KVal(Dbo.reader(6).ToString)
                    .txtLocalVesselPOL.Text = Dbo.reader(7).ToString
                    .txtOceanVessel.Text = Dbo.reader(8).ToString
                    .txtOceanVesselPOL.Text = Dbo.reader(9).ToString
                    .txtPortOfDischarge.Text = Dbo.reader(10).ToString
                    .txtPayableAt.Text = Dbo.reader(11).ToString
                    .txtNosOfBL.Text = Dbo.reader(12).ToString
                    .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
                    .dtOnBoardDate.Value = Dbo.reader(14).ToString
                    .txtFromPortCode.Text = Dbo.reader(15).ToString
                    .txtToPortCode.Text = Dbo.reader(16).ToString
                    If String.IsNullOrEmpty(Dbo.reader(20).ToString) Then
                        .DtDateIssue.Value = Now
                    Else
                        .DtDateIssue.Value = Dbo.reader(20).ToString
                    End If

                Loop
                Dbo.reader.Close()
                Dbo.SqlCon.Close()



                Call LoadContainersBL(SelBkNo)

                With .dtDescriptions
                    '.Rows.Clear()

                    Dbo.SqlCon.Open()
                    SQL = "SELECT MARK,PKGNos,DescriptionIs,KGS,CBM, Description1 FROM TBL_MARKS_AND_NUMBERS WHERE STAT = '1' AND BLNO = '" & selBLno & "'   AND REFNO = '" & SelRefno & "' ORDER BY ID ASC"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.reader = Dbo.SQLCmd.ExecuteReader
                    .Rows.Clear()

                    Do While Dbo.reader.Read
                        .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString, "", Dbo.reader(5).ToString)
                    Loop
                    Dbo.reader.Close()
                    Dbo.SqlCon.Close()
                End With



            End If
        End With

        LoadForm(FrmBLForm, "BL FORM")
    End Sub

    Private Sub BLRIDERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BLRIDERToolStripMenuItem.Click
        CorrectionNoticeRevised = ""
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If selBLno = "" Then
            MsgBox("No BLNO assigned!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        With frmBLRider
            .lblRefno.Text = SelRefno
            .lblBlno.Text = selBLno
            .lblShipper.Text = SelShipper
            .lblConsignee.Text = SelConsignee
        End With
        LoadForm(frmBLRider, "BL RIDER")
    End Sub

    Private Sub PRINTBLRIDERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRINTBLRIDERToolStripMenuItem.Click
        CorrectionNoticeRevised = ""
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        LoadForm(FrmGenerateBlMenus, "BL MENUS")
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        'FrmRequestForPayment.txtSysref.Text = "RC-S" & Format(Now, "yyMMddhhmmssff")
        'LoadForm(FrmRequestForPayment, "REQUEST FOR PAYMENT - CHARGES")
    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem25.Click
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'Dim FeederPoolPod As String = Trim(dtList.CurrentRow.Cells(8).Value)
        'Dim FeederPod As String() = FeederPoolPod.Split("/")
        With FrmManifestMenus
            .cmbMVessel.Text = Trim(dtList.CurrentRow.Cells(12).Value)
            .cmbPod.Text = Trim(dtList.CurrentRow.Cells(17).Value)
            .cmbBlNo.Text = Trim(dtList.CurrentRow.Cells(25).Value)
        End With
        Call LoadForm(FrmManifestMenus, "MANIFEST")
    End Sub

    Private Sub LISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LISTToolStripMenuItem.Click
        Call LoadForm(FrmRequestForPaymentList, "REQUEST FOR PAYMENT - LIST")
    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        'FrmRequestForPaymentStorage.txtSysref.Text = "RS-S" & Format(Now, "yyMMddhhmmssff")
        'LoadForm(FrmRequestForPaymentStorage, "REQUEST FOR PAYMENT - STORAGE")
    End Sub

    Private Sub SUMMARYOFBOOKINGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUMMARYOFBOOKINGToolStripMenuItem.Click
        LoadForm(FrmSummaryOfBookingMenu, "SUMMARY OF BOOKING")
    End Sub

    Private Sub ToolStripMenuItem28_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem28.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag




        SelSysref = dtList.CurrentRow.Cells(1).Tag
        SelBkNo = dtList.CurrentRow.Cells(0).Tag

        '3 and 5
        SelServiceIs = Mid(SelBkNo, 4, 1)
        SelBookingType = Mid(SelBkNo, 6, 1)
        'MsgBox(SelServiceIs)
        'MsgBox(SelBookingType)

        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        SelShipper = dtList.CurrentRow.Cells(3).Value
        SelConsignee = dtList.CurrentRow.Cells(4).Value
        SelPort = dtList.CurrentRow.Cells(17).Value '17
        SelStatIs = dtList.CurrentRow.Cells(2).Tag
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        If Not GetRyzk("SELECT BKNO FROM TBL_OPERATIONS WHERE STAT = '" & dtList.CurrentRow.Cells(2).Tag & "' AND SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "'", "L") = NoRecordFound Then
            MsgBox("Operations Data already existing!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        LandingForm.Modeis = "NEW_OPERATIONS"

        With FrmInitialBooking
            Call .LoadOperationsCmb()
            .lblSysref.Text = MainSysref
            .txtBKNO.Text = MainBkno
            .pnlCS.Visible = False
            .PnlOperations.Visible = True
            .PnlOperations.Left = 0
            .Width = 530
        End With

        Call LoadForm(FrmInitialBooking, "OPERATIONS")
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        'LoadForm(FrmInitialBooking, "OPERATIONS BOOKING")

        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        Dim Dbo As New SQLClass
        Dbo.SqlCon.Open()
        SQL = "SELECT LeasingContainer, COUNTIS,CONTSIZE,CONTBOOKINGNUM, ValidityDate FROM TBL_CONTAINER_BOOKING  WHERE SYSREF = '" & MainSysref & "' AND BKNO = '" & MainBkno & "' AND (STAT <> '0' AND STAT <> '2')"
        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
        Dbo.reader = Dbo.SQLCmd.ExecuteReader
        With FrmContainerBookingNumber.dtContainerListBooking
            .Rows.Clear()
            Do While Dbo.reader.Read
                .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Dbo.reader(2).ToString, Dbo.reader(3).ToString, Dbo.reader(4).ToString)
            Loop
        End With
        Dbo.reader.Close()
        Dbo.SqlCon.Close()

        LoadForm(FrmContainerBookingNumber, "CONTAINER BOOKING")
    End Sub

    Private Sub ToolStripMenuItem32_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem32.Click
        LoadForm(FrmATWMenu, "GENERATE ATW (VOLUME)")
        Exit Sub
        'SET_SUBREPORT_CONNECTION
        If MsgBox("Generate ATW?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            MainSysref = dtList.CurrentRow.Cells(1).Tag
            MainBkno = dtList.CurrentRow.Cells(0).Tag
            Dim Dbo As New SQLClass
            Dim objRep As New crGenerateNewATW

            Dbo.SqlCon.Open()
            SQL = "sp_GenerateATW;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()

            If objRep.Subreports.Count > 0 Then
                Dim Dbo2 As New SQLClass
                Dbo2.SqlCon.Open()
                SQL = "spGetBookedContainer;1"
                Dbo2.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo2.SqlCon)
                Dbo2.SQLCmd.CommandType = CommandType.StoredProcedure
                'Dbo2.SQLCmd.Parameters.Clear()
                'Dbo2.SQLCmd.Parameters.AddWithValue("@SYSREF", sysref)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@REFNO", refno)
                'Dbo2.SQLCmd.Parameters.AddWithValue("@BLNO", BLNO)
                Dbo2.adapter2 = New SqlClient.SqlDataAdapter(Dbo2.SQLCmd)
                Dbo2.table2 = New DataTable
                Dbo2.adapter2.Fill(Dbo2.table2)
                objRep.Subreports(0).SetDataSource(Dbo2.table2)

                Dbo2.SqlCon.Close()

            End If

            objRep.SetParameterValue("Sysref", MainSysref)
            objRep.SetParameterValue("BKNO", MainBkno)
            objRep.SetParameterValue("Useris", FNAME)



            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
            If ContSize = NoRecordFound Then
                ContSize = ""
            End If



            With FrmPrintForm
                objRep.SummaryInfo.ReportTitle = UCase(KVal("ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort))
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)

                .crViewer.AllowedExportFormats = formats
                '.crViewer.Name = "ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(150)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        End If
    End Sub

    Private Sub ToolStripMenuItem38_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem38.Click
        FrmGenerateBookingList.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem39_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem39.Click
        FrmGenerateTSReport.ShowDialog()
    End Sub

    Private Sub dtList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellDoubleClick
        btnView_Click(e, e)
    End Sub



    Private Sub Button2_MouseClick(sender As Object, e As MouseEventArgs) Handles Button2.MouseClick
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag



        If e.Button = MouseButtons.Left Then
            With CmsOperations
                .Items(0).Text = MainBkno
                .Items(0).Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
                .Show(sender, 0, 0 - CmsOperations.Height)
            End With

        End If
    End Sub

    Private Sub LOADINGSEQUENCEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOADINGSEQUENCEToolStripMenuItem.Click
        LoadForm(FrmGenerateLoadingSequence, "LOADING SEQUENCE")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        With FrmMenus.cmsMaintenance
            .Show(sender, 0, 0 - FrmMenus.cmsMaintenance.Height)
        End With

    End Sub

    Private Sub GENERALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERALToolStripMenuItem.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPayment.rfpMode = "ADD"
        FrmRequestForPayment.cmbRFPType.Text = "CHARGES"
        FrmRequestForPayment.cmbRFPSubType.Text = "GENERAL"
        FrmRequestForPayment.txtSysref.Text = "RC-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPayment, "REQUEST FOR PAYMENT - CHARGES - GENERAL")
    End Sub

    Private Sub DANGEROUSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DANGEROUSToolStripMenuItem.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPayment.lblCode.Text = ""
        FrmRequestForPayment.rfpMode = "ADD"
        FrmRequestForPayment.cmbRFPType.Text = "CHARGES"
        FrmRequestForPayment.cmbRFPSubType.Text = "DANGEROUS"
        FrmRequestForPayment.txtSysref.Text = "RC-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPayment, "REQUEST FOR PAYMENT - CHARGES - DANGEROUS")
    End Sub

    Private Sub GENERALToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GENERALToolStripMenuItem1.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPaymentStorage.rfpMode = "ADD"
        FrmRequestForPaymentStorage.cmbRFPType.Text = "STORAGE"
        FrmRequestForPaymentStorage.cmbRFPSubType.Text = "GENERAL"
        FrmRequestForPaymentStorage.txtSysref.Text = "RS-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPaymentStorage, "REQUEST FOR PAYMENT - STORAGE - GENERAL")
    End Sub

    Private Sub DANGEROUSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DANGEROUSToolStripMenuItem1.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPaymentStorage.rfpMode = "ADD"
        FrmRequestForPaymentStorage.cmbRFPType.Text = "STORAGE"
        FrmRequestForPaymentStorage.cmbRFPSubType.Text = "DANGEROUS"
        FrmRequestForPaymentStorage.txtSysref.Text = "RS-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPaymentStorage, "REQUEST FOR PAYMENT - STORAGE - DANGEROUS")
    End Sub

    Private Sub GENERALToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles GENERALToolStripMenuItem2.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPayment.rfpMode = "ADD"
        FrmRequestForPayment.cmbRFPType.Text = "FLATRACK"
        FrmRequestForPayment.cmbRFPSubType.Text = "GENERAL"
        FrmRequestForPayment.txtSysref.Text = "RF-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPayment, "REQUEST FOR PAYMENT - FLATRACK - GENERAL")
    End Sub

    Private Sub DANGEROUSToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DANGEROUSToolStripMenuItem2.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPayment.rfpMode = "ADD"
        FrmRequestForPayment.cmbRFPType.Text = "FLATRACK"
        FrmRequestForPayment.cmbRFPSubType.Text = "DANGEROUS"
        FrmRequestForPayment.txtSysref.Text = "RF-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPayment, "REQUEST FOR PAYMENT - FLATRACK - DANGEROUS")
    End Sub

    Private Sub GENERALToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles GENERALToolStripMenuItem3.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPaymentStorage.rfpMode = "ADD"
        FrmRequestForPaymentStorage.cmbRFPType.Text = "SHUTOUT"
        FrmRequestForPaymentStorage.cmbRFPSubType.Text = "GENERAL"
        FrmRequestForPaymentStorage.txtSysref.Text = "RH-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPaymentStorage, "REQUEST FOR PAYMENT - SHUTOUT - GENERAL")
    End Sub

    Private Sub DANGEROUSToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles DANGEROUSToolStripMenuItem3.Click
        PrintActionMode = "NEW"
        PrintModeIs = "REQUEST_FOR_PAYMENT"
        FrmRequestForPaymentStorage.rfpMode = "ADD"
        FrmRequestForPaymentStorage.cmbRFPType.Text = "SHUTOUT"
        FrmRequestForPaymentStorage.cmbRFPSubType.Text = "DANGEROUS"
        FrmRequestForPaymentStorage.txtSysref.Text = "RH-S" & Format(Now, "yyMMddhhmmssff")
        LoadForm(FrmRequestForPaymentStorage, "REQUEST FOR PAYMENT - SHUTOUT - DANGEROUS")
    End Sub

    Private Sub DATAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DATAToolStripMenuItem.Click
        FrmCorrectionAdvice.cmbBlNo.Text = dtList.CurrentRow.Cells(25).Value
        FrmCorrectionAdvice.cmbShipper.Text = dtList.CurrentRow.Cells(3).Value
        FrmCorrectionAdvice.cmbConsignee.Text = dtList.CurrentRow.Cells(4).Value
        FrmCorrectionAdvice.cmbNotifyParty.Text = dtList.CurrentRow.Cells(5).Value
        FrmCorrectionAdvice.cmbTo.Text = dtList.CurrentRow.Cells(17).Value

        Dim CurSeries As String = ""

        CurSeries = GetRyzk("SELECT concat(format(SERIES,'00'), '/20',YR) FROM TBL_REFERENCE WHERE PARAM3 = 'CORR_ADV'", "")
        FrmCorrectionAdvice.txtRefno.Text = CurSeries
        LoadForm(FrmCorrectionAdvice, "CORRECTION ADVICE - DATA")
    End Sub

    Private Sub UPLOADDATAToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MODIFYDATAToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GENERATECONTAINERINVENTORYToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PRINTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRINTToolStripMenuItem.Click
        If MsgBox("Are you sure you want to generate C/A for this reference?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            'MainSysref = txtSysref.Text
            'MainBkno = dtList.CurrentRow.Cells(0).Tag
            Dim Dbo As New SQLClass
            Dim objRep As New CrCorrectionAdvice


            Dbo.SqlCon.Open()
            SQL = "spCorrectionAdvice;1"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.SQLCmd.CommandType = CommandType.StoredProcedure
            Dbo.SQLCmd.Parameters.Clear()

            Dbo.adapter = New SqlClient.SqlDataAdapter(Dbo.SQLCmd)
            Dbo.table = New DataTable
            Dbo.adapter.Fill(Dbo.table)

            objRep.SetDataSource(Dbo.table)
            Dbo.SqlCon.Close()


            'objRep.SetParameterValue("sysref", MainSysref)
            objRep.SetParameterValue("BLNO", dtList.CurrentRow.Cells(25).Value)





            'For i As Integer = 0 To 20
            '    MsgBox(i & " / " & objRep.DataDefinition.FormulaFields(i).Text.ToString)
            'Next
            'TotalAmountIs = objRep.DataDefinition.FormulaFields(3).Text.ToString
            'TotalAmountIs = objRep.DataDefinition.FormulaFields.Item(3).Text
            'MsgBox(objRep.DataDefinition.FormulaFields.Item(3).)

            'Dim ContSize As String = GetRyzk("SELECT concat(SUM(COUNTIS) ,'X' ,ContSize)  FROM TBL_CONTAINER_BOOKING WHERE (STAT <> '2' AND STAT <> '0') AND BKNO = '" & MainBkno & "'  GROUP BY CONTSIZE  for xml path('') ", "L")
            'If ContSize = NoRecordFound Then
            '    ContSize = ""
            'End If



            With FrmPrintForm
                With .stsID
                    '.Items(0).Text = txtSysref.Text
                    .Items(1).Text = "CORRECTION_ADVICE"
                End With

                'objRep.SummaryInfo.ReportTitle = UCase(KVal("ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort))
                Dim formats As Integer
                formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat)
                .crViewer.EnableDrillDown = False
                .crViewer.AllowedExportFormats = formats
                '.crViewer.Name = "ATW ISSUANCE FOR " & ContSize & "-" & SelShipper & "-" & SelPort
                .crViewer.ReportSource = objRep
                .crViewer.Refresh()
                .crViewer.ShowPrintButton = True
                .crViewer.Zoom(150)
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With
        End If
    End Sub

    Private Sub ONEWAYFREEUSEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONEWAYFREEUSEToolStripMenuItem.Click

    End Sub

    Private Sub UPLOADToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPLOADToolStripMenuItem.Click
        OneWayFreeUse = "Y"
        LoadForm(FrmContainerInventoryUpload, "CONTAINER INVENTORY - UPLOAD")
    End Sub

    Private Sub MODIFYDATAToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MODIFYDATAToolStripMenuItem1.Click
        OneWayFreeUse = "Y"
        FrmContainerInventoryList.dtList.Height = 420
        FrmContainerInventoryList.btnGenerateExcel.Visible = False
        With FrmContainerInventoryList
            .dtList.Columns(2).Visible = True
            .dtList.Columns(3).Visible = False
            .dtList.Columns(4).Visible = True
            .dtList.Columns(4).ReadOnly = False
            .dtList.Columns(5).Visible = True

            .dtList.Columns(6).Visible = True
            .dtList.Columns(7).Visible = True
        End With
        LoadForm(FrmContainerInventoryList, "CONTAINER INVENTORY - LIST")
    End Sub

    Private Sub GENERATECONTAINERREPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERATECONTAINERREPORTToolStripMenuItem.Click
        OneWayFreeUse = "Y"
        With FrmContainerInventoryList
            .dtList.Height = 380
            .dtList.Columns(2).Visible = False
            .dtList.Columns(3).Visible = True
            .dtList.Columns(4).Visible = True
            .dtList.Columns(4).ReadOnly = True
            .dtList.Columns(5).Visible = True

            .dtList.Columns(6).Visible = False
            .dtList.Columns(7).Visible = False

            .btnGenerateExcel.Visible = True
        End With

        LoadForm(FrmContainerInventoryList, "CONTAINER INVENTORY - GENERATE REPORT")
    End Sub

    Private Sub GENERATEIMPORTANDLEASEDCONTAINERREPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERATEIMPORTANDLEASEDCONTAINERREPORTToolStripMenuItem.Click
        OneWayFreeUse = ""
        LoadForm(FrmGenerateImportAndLeasedContainerMenu, "IMPORT AND LEASED CONTAINER")
    End Sub

    Private Sub IMPORTCONTAINERSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTCONTAINERSToolStripMenuItem.Click
        OneWayFreeUse = ""
        FrmContainerInventoryPerBooking.pnlImportContainers.Visible = True
        LoadForm(FrmContainerInventoryPerBooking, "IMPORT CONTAINERS")
    End Sub

    Private Sub MODIFYDATAToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles MODIFYDATAToolStripMenuItem.Click
        OneWayFreeUse = ""
        FrmContainerInventoryList.dtList.Height = 420
        FrmContainerInventoryList.btnGenerateExcel.Visible = False
        With FrmContainerInventoryList
            .dtList.Columns(2).Visible = True
            .dtList.Columns(3).Visible = False
            .dtList.Columns(4).Visible = True
            .dtList.Columns(4).ReadOnly = False
            .dtList.Columns(5).Visible = True

            .dtList.Columns(6).Visible = True
            .dtList.Columns(7).Visible = True
        End With
        LoadForm(FrmContainerInventoryList, "CONTAINER INVENTORY - LIST")
    End Sub

    Private Sub GENERATEIMPORTCONTAINERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERATEIMPORTCONTAINERToolStripMenuItem.Click
        OneWayFreeUse = ""
        With FrmContainerInventoryList
            .dtList.Height = 380
            .dtList.Columns(2).Visible = False
            .dtList.Columns(3).Visible = True
            .dtList.Columns(4).Visible = True
            .dtList.Columns(4).ReadOnly = True
            .dtList.Columns(5).Visible = True

            .dtList.Columns(6).Visible = False
            .dtList.Columns(7).Visible = False

            .btnGenerateExcel.Visible = True
        End With

        LoadForm(FrmContainerInventoryList, "CONTAINER INVENTORY - GENERATE REPORT")
    End Sub

    Private Sub CORRECTBLsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CORRECTBLsToolStripMenuItem.Click
        CorrectionNoticeRevised = "CNR-"

        If Not GetRyzk("SELECT BLNO FROM TBL_MARKS_AND_NUMBERS WHERE BLNO = 'CNR-" & selBLno & "' AND STAT = '1'", "L") = NoRecordFound Then

            If dtList.CurrentRow.Cells(25).Value = "" Then
                MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            With FrmBLForm

                CntrCount = 0
                CountTotal = 0.00
                kgs = 0.00
                cbm = 0.00
                MainDetail = ""
                BLTermIs = dtList.CurrentRow.Cells(20).Value
                With FrmBLForm.dtDescriptions
                    .Rows.Clear()

                    For i As Integer = 0 To 20
                        .Rows.Add()
                    Next
                End With

                .txtBL.Text = selBLno
                .pnlCrn.Visible = True
                .txtCrn.Text = "CRN-" & .txtBL.Text

                If GetRyzk("SELECT BLNO FROM TBL_MARKS_AND_NUMBERS WHERE BLNO = 'CNR-" & selBLno & "' AND STAT = '1'", "L") = NoRecordFound Then
                    MsgBox("Unable to proceed no BL found!", MsgBoxStyle.Critical)
                    Exit Sub

                    Dim Dbo As New SQLClass
                    Dbo.SqlCon.Open()
                    'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                    SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.SQLCmd.ExecuteNonQuery()
                    Dbo.reader = Dbo.SQLCmd.ExecuteReader
                    Do While Dbo.reader.Read
                        .lblOutRef.Text = selBLno
                        .txtBL.Text = selBLno
                        .lblTypeShipment.Text = SelBkNo
                        .txtFromPortCode.Text = Dbo.reader(26).ToString
                        .txtToPortCode.Text = Dbo.reader(27).ToString
                        .txtShipper.Text = KVal(Dbo.reader(5).ToString)
                        .txtShipperAddress.Text = KVal(Dbo.reader(6).ToString)
                        .txtConsignee.Text = KVal(Dbo.reader(7).ToString)
                        .txtConsigneeAddress.Text = KVal(Dbo.reader(8).ToString)
                        .txtNotify1.Text = KVal(Dbo.reader(9).ToString)
                        .txtNotifyAddress1.Text = KVal(Dbo.reader(10).ToString)
                        .txtLocalVessel.Text = KVal(Dbo.reader(11).ToString) & " V-" & Dbo.reader(12).ToString
                        .txtLocalVesselPOL.Text = Dbo.reader(13).ToString
                        .txtOceanVessel.Text = KVal(Dbo.reader(19).ToString) & " V-" & Dbo.reader(20).ToString
                        .txtOceanVesselPOL.Text = Dbo.reader(21).ToString
                        If String.IsNullOrEmpty(Dbo.reader(24).ToString) Then
                            .txtPortOfDischarge.Text = Dbo.reader(23).ToString
                        Else
                            .txtPortOfDischarge.Text = Dbo.reader(24).ToString
                        End If
                        If Dbo.reader(25).ToString = "C" Then
                            .txtPayableAt.Text = Dbo.reader(28).ToString
                        ElseIf Dbo.reader(25).ToString = "P" Then
                            If String.IsNullOrEmpty(Dbo.reader(28).ToString) Then
                                .txtPayableAt.Text = ""
                            Else
                                .txtPayableAt.Text = Dbo.reader(28).ToString
                            End If
                        End If
                        .txtNosOfBL.Text = "THREE (3)"
                        .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
                        .dtOnBoardDate.Value = Now

                    Loop
                    Dbo.reader.Close()
                    Dbo.SqlCon.Close()

                    Call LoadContainersBL(SelBkNo)

                    With .dtDescriptions
                        .Rows(0).Cells(1).Value = CntrCount & " " & "CNTRS"
                        Dim cntrAll As String = Replace(GetRyzk("SELECT  CONVERT(NVARCHAR,COUNT(SizeIs)) + 'X' + SizeIs + ' Z ' FROM TBL_CONTAINER WHERE BKNO = '" & SelBkNo & "' AND STAT = '1'GROUP BY SizeIs FOR XML PATH ('')", "L"), "Z", "& ")
                        If Microsoft.VisualBasic.Right(cntrAll, 3) = "&  " Then
                            cntrAll = Microsoft.VisualBasic.Mid(cntrAll, 1, Len(cntrAll) - 3)
                        End If
                        .Rows(1).Cells(2).Value = cntrAll & " CONTAINER(S) STC:"
                        .Rows(0).Cells(2).Value = """" & "SHIPPER'S LOAD COUNT AND SEAL" & """" & "                         AS DECLARED"
                        .Rows(1).Cells(0).Value = ""
                        .Rows(2).Cells(1).Value = CountTotal
                        .Rows(2).Cells(3).Value = FormatMoney(kgs)
                        .Rows(3).Cells(3).Value = "KGS."

                        .Rows(2).Cells(4).Value = FormatMoney(cbm)
                        .Rows(3).Cells(4).Value = "CBM."

                        .Rows(3).Cells(1).Value = MainDetail

                        .Rows.Insert(1, "")
                    End With








                Else



                    Dim Dbo As New SQLClass
                    Dbo.SqlCon.Open()
                    SQL = "SELECT  Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel, OceanVesselPOL, POD, PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, AddedBy, DateAdded, Stat, DateIssue FROM TBL_BL WHERE BLNO = 'CNR-" & selBLno & "' AND REFNO = 'CNR-" & SelRefno & "' AND STAT  = '1'"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.SQLCmd.ExecuteNonQuery()
                    Dbo.reader = Dbo.SQLCmd.ExecuteReader
                    Do While Dbo.reader.Read
                        .lblOutRef.Text = SelRefno
                        .txtBL.Text = selBLno
                        .lblTypeShipment.Text = SelBkNo
                        .txtShipper.Text = KVal(Dbo.reader(0).ToString)
                        .txtShipperAddress.Text = KVal(Dbo.reader(1).ToString)
                        .txtConsignee.Text = KVal(Dbo.reader(2).ToString)
                        .txtConsigneeAddress.Text = KVal(Dbo.reader(3).ToString)
                        .txtNotify1.Text = KVal(Dbo.reader(4).ToString)
                        .txtNotifyAddress1.Text = KVal(Dbo.reader(5).ToString)
                        .txtLocalVessel.Text = KVal(Dbo.reader(6).ToString)
                        .txtLocalVesselPOL.Text = Dbo.reader(7).ToString
                        .txtOceanVessel.Text = Dbo.reader(8).ToString
                        .txtOceanVesselPOL.Text = Dbo.reader(9).ToString
                        .txtPortOfDischarge.Text = Dbo.reader(10).ToString
                        .txtPayableAt.Text = Dbo.reader(11).ToString
                        .txtNosOfBL.Text = Dbo.reader(12).ToString
                        .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
                        .dtOnBoardDate.Value = Dbo.reader(14).ToString
                        .txtFromPortCode.Text = Dbo.reader(15).ToString
                        .txtToPortCode.Text = Dbo.reader(16).ToString
                        If String.IsNullOrEmpty(Dbo.reader(20).ToString) Then
                            .DtDateIssue.Value = Now
                        Else
                            .DtDateIssue.Value = Dbo.reader(20).ToString
                        End If

                    Loop
                    Dbo.reader.Close()
                    Dbo.SqlCon.Close()



                    Call LoadContainersBL(SelBkNo)

                    With .dtDescriptions
                        '.Rows.Clear()
                        Dim i As Integer = 0
                        Dbo.SqlCon.Open()
                        SQL = "SELECT MARK,PKGNos,DescriptionIs,KGS,CBM, Description1 FROM TBL_MARKS_AND_NUMBERS WHERE STAT = '1' AND BLNO = '" & selBLno & "'   AND REFNO = '" & SelRefno & "' ORDER BY ID ASC"
                        Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                        Dbo.reader = Dbo.SQLCmd.ExecuteReader
                        .Rows.Clear()

                        Do While Dbo.reader.Read
                            Dim Desc As String = Dbo.reader(2).ToString
                            If Dbo.reader(2).ToString.Contains("CONTAINER(S) STC:") Then
                                Desc = Dbo.reader(2).ToString '& "                                    ""FREIGHT COLLECT"""
                            End If
                            .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Desc, IIf(i = 6, """FREIGHT COLLECT""", Dbo.reader(3).ToString), Dbo.reader(4).ToString, "", Dbo.reader(5).ToString)
                            i += 1
                        Loop
                        If i = 6 Then
                            .Rows.Add("", "", "", IIf(i = 6, """FREIGHT COLLECT""", ""), "", "", "")
                        End If
                        Dbo.reader.Close()
                        Dbo.SqlCon.Close()
                    End With



                End If
            End With

            LoadForm(FrmBLForm, "BL FORM")

            Exit Sub
        End If


        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With FrmBLForm

            CntrCount = 0
            CountTotal = 0.00
            kgs = 0.00
            cbm = 0.00
            MainDetail = ""
            BLTermIs = dtList.CurrentRow.Cells(20).Value
            With FrmBLForm.dtDescriptions
                .Rows.Clear()

                For i As Integer = 0 To 20
                    .Rows.Add()
                Next
            End With

            .txtBL.Text = selBLno
            .pnlCrn.Visible = True
            .txtCrn.Text = "CRN-" & .txtBL.Text

            If GetRyzk("SELECT BLNO FROM TBL_MARKS_AND_NUMBERS WHERE BLNO = '" & selBLno & "' AND STAT = '1'", "L") = NoRecordFound Then
                MsgBox("Unable to proceed no BL found!", MsgBoxStyle.Critical)
                Exit Sub

                Dim Dbo As New SQLClass
                Dbo.SqlCon.Open()
                'SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOD1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                         TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                SQL = "SELECT      TBL_BOOKING.Sysref, TBL_BOOKING.BKNO, TBL_BOOKING.REFNO, TBL_BOOKING.DateTrans, TBL_OUTPORT.OUTPORT AS OutPortIs, Shipper.ClientName AS Shipper, Shipper.Clientaddress as ShipperAddress, Consignee.ClientName AS Consignee, Consignee.Clientaddress as ConsigneeAddress,                          Notify.ClientName AS Notify, Notify.Clientaddress as NotifyAddress, Vessel1st.VESSELNAME AS Vessel1stName, TBL_BOOKING.FVoyage1st AS Vessel1stVoyage, TBL_LOADING_UNLOADING_PORT_3.NAME AS Vessel1stPOL,                          TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel1stPOD, Vessel2nd.VESSELNAME AS Vessel2ndName, TBL_BOOKING.FVoyage2nd AS Vessel2ndVoyage,                          TBL_LOADING_UNLOADING_PORT_1.NAME AS Vessel2ndPOL, TBL_LOADING_UNLOADING_PORT_4.NAME AS Vessel2ndPOD, MotherVessel.VESSELNAME AS MotherVesselName,                          TBL_BOOKING.MVoyage AS Mother2ndVoyage, TBL_LOADING_UNLOADING_PORT_2.NAME AS MotherVesselLoading, TBL_TRADE.NAME AS TradeName, TBL_SUB_TRADE_OPTIONS.NAME AS SubTradeName,                          TBL_PORTS.NAME AS PortIs           , TBL_BOOKING.TermsIs , TBL_LOADING_UNLOADING_PORT_3.CodeIs  as FromPortCode ,                                                      (CASE WHEN TBL_PORTS.NAME IS NULL THEN (case when TBL_SUB_TRADE_OPTIONS.CODEIS is null then (CASE WHEN TBL_LOADING_UNLOADING_PORT_4.NAME IS NULL THEN ('') ELSE TBL_LOADING_UNLOADING_PORT_4.CODEIS END) else TBL_SUB_TRADE_OPTIONS.CODEIS end) ELSE TBL_PORTS.CODEIS END ) AS DESTCode, TBL_BOOKING.PayableAt    FROM            TBL_BOOKING LEFT JOIN                         TBL_SUB_TRADE_OPTIONS ON TBL_BOOKING.SUB_TRADE = TBL_SUB_TRADE_OPTIONS.ID LEFT JOIN                         TBL_OUTPORT ON TBL_BOOKING.OptnMode = TBL_OUTPORT.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_3 ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT_3.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_4 ON TBL_BOOKING.FeederVessel2ndPOD = TBL_LOADING_UNLOADING_PORT_4.ID LEFT JOIN                         TBL_PORTS ON TBL_BOOKING.PORTS = TBL_PORTS.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_2 ON TBL_BOOKING.MotherVesselLoading = TBL_LOADING_UNLOADING_PORT_2.ID LEFT JOIN                         TBL_TRADE ON TBL_BOOKING.TRADE = TBL_TRADE.ID LEFT JOIN                        TBL_VESSEL AS Vessel2nd ON TBL_BOOKING.FeederVessel2nd = Vessel2nd.ID LEFT JOIN                         TBL_VESSEL AS MotherVessel ON TBL_BOOKING.MotherVessel = MotherVessel.ID LEFT JOIN                         TBL_CLIENT AS Shipper ON TBL_BOOKING.Shipper = Shipper.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT AS TBL_LOADING_UNLOADING_PORT_1 ON TBL_BOOKING.FeederVessel2ndPOL = TBL_LOADING_UNLOADING_PORT_1.ID LEFT JOIN                         TBL_VESSEL AS Vessel1st ON TBL_BOOKING.FeederVessel1st = Vessel1st.ID LEFT JOIN                         TBL_LOADING_UNLOADING_PORT ON TBL_BOOKING.FeederPOL1st = TBL_LOADING_UNLOADING_PORT.ID LEFT JOIN                         TBL_CLIENT AS Notify ON TBL_BOOKING.Notify = Notify.ID LEFT JOIN                         TBL_CLIENT AS Consignee ON TBL_BOOKING.Consignee = Consignee.ID LEFT JOIN TBL_OPERATIONS AS OP on op.SYSREF = TBL_BOOKING.Sysref AND OP.BKNO = TBL_BOOKING.BKNO LEFT JOIN TBL_DEPOT AS D ON OP.DEPOT = D.ID  LEFT JOIN TBL_LOADING_UNLOADING_PORT AS LUP ON OP.DeliveryPort = LUP.ID  WHERE         (TBL_BOOKING.Stat <> '2') AND  (TBL_BOOKING.Sysref = '" & SelSysref & "') AND (TBL_BOOKING.BKNO = '" & SelBkNo & "') and tbl_booking.blno = '" & selBLno & "'"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.ExecuteNonQuery()
                Dbo.reader = Dbo.SQLCmd.ExecuteReader
                Do While Dbo.reader.Read
                    .lblOutRef.Text = selBLno
                    .txtBL.Text = selBLno
                    .lblTypeShipment.Text = SelBkNo
                    .txtFromPortCode.Text = Dbo.reader(26).ToString
                    .txtToPortCode.Text = Dbo.reader(27).ToString
                    .txtShipper.Text = KVal(Dbo.reader(5).ToString)
                    .txtShipperAddress.Text = KVal(Dbo.reader(6).ToString)
                    .txtConsignee.Text = KVal(Dbo.reader(7).ToString)
                    .txtConsigneeAddress.Text = KVal(Dbo.reader(8).ToString)
                    .txtNotify1.Text = KVal(Dbo.reader(9).ToString)
                    .txtNotifyAddress1.Text = KVal(Dbo.reader(10).ToString)
                    .txtLocalVessel.Text = KVal(Dbo.reader(11).ToString) & " V-" & Dbo.reader(12).ToString
                    .txtLocalVesselPOL.Text = Dbo.reader(13).ToString
                    .txtOceanVessel.Text = KVal(Dbo.reader(19).ToString) & " V-" & Dbo.reader(20).ToString
                    .txtOceanVesselPOL.Text = Dbo.reader(21).ToString
                    If String.IsNullOrEmpty(Dbo.reader(24).ToString) Then
                        .txtPortOfDischarge.Text = Dbo.reader(23).ToString
                    Else
                        .txtPortOfDischarge.Text = Dbo.reader(24).ToString
                    End If
                    If Dbo.reader(25).ToString = "C" Then
                        .txtPayableAt.Text = Dbo.reader(28).ToString
                    ElseIf Dbo.reader(25).ToString = "P" Then
                        If String.IsNullOrEmpty(Dbo.reader(28).ToString) Then
                            .txtPayableAt.Text = ""
                        Else
                            .txtPayableAt.Text = Dbo.reader(28).ToString
                        End If
                    End If
                    .txtNosOfBL.Text = "THREE (3)"
                    .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
                    .dtOnBoardDate.Value = Now

                Loop
                Dbo.reader.Close()
                Dbo.SqlCon.Close()

                Call LoadContainersBL(SelBkNo)

                With .dtDescriptions
                    .Rows(0).Cells(1).Value = CntrCount & " " & "CNTRS"
                    Dim cntrAll As String = Replace(GetRyzk("SELECT  CONVERT(NVARCHAR,COUNT(SizeIs)) + 'X' + SizeIs + ' Z ' FROM TBL_CONTAINER WHERE BKNO = '" & SelBkNo & "' AND STAT = '1'GROUP BY SizeIs FOR XML PATH ('')", "L"), "Z", "& ")
                    If Microsoft.VisualBasic.Right(cntrAll, 3) = "&  " Then
                        cntrAll = Microsoft.VisualBasic.Mid(cntrAll, 1, Len(cntrAll) - 3)
                    End If
                    .Rows(1).Cells(2).Value = cntrAll & " CONTAINER(S) STC:"
                    .Rows(0).Cells(2).Value = """" & "SHIPPER'S LOAD COUNT AND SEAL" & """" & "                         AS DECLARED"
                    .Rows(1).Cells(0).Value = ""
                    .Rows(2).Cells(1).Value = CountTotal
                    .Rows(2).Cells(3).Value = FormatMoney(kgs)
                    .Rows(3).Cells(3).Value = "KGS."

                    .Rows(2).Cells(4).Value = FormatMoney(cbm)
                    .Rows(3).Cells(4).Value = "CBM."

                    .Rows(3).Cells(1).Value = MainDetail

                    .Rows.Insert(1, "")
                End With








            Else



                Dim Dbo As New SQLClass
                Dbo.SqlCon.Open()
                SQL = "SELECT  Shipper, ShipperAddress, Consignee, ConsigneeAddress, Notify, NotifyAddress, LocalVessel, LocalVesselPOL, OceanVessel, OceanVesselPOL, POD, PayableAt, NosOfBL,PlaceDateIssue, OnBoardDate, PortFromCode, PortToCode, AddedBy, DateAdded, Stat, DateIssue FROM TBL_BL WHERE BLNO = '" & selBLno & "' AND REFNO = '" & SelRefno & "' AND STAT  = '1'"
                Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                Dbo.SQLCmd.ExecuteNonQuery()
                Dbo.reader = Dbo.SQLCmd.ExecuteReader
                Do While Dbo.reader.Read
                    .lblOutRef.Text = SelRefno
                    .txtBL.Text = selBLno
                    .lblTypeShipment.Text = SelBkNo
                    .txtShipper.Text = KVal(Dbo.reader(0).ToString)
                    .txtShipperAddress.Text = KVal(Dbo.reader(1).ToString)
                    .txtConsignee.Text = KVal(Dbo.reader(2).ToString)
                    .txtConsigneeAddress.Text = KVal(Dbo.reader(3).ToString)
                    .txtNotify1.Text = KVal(Dbo.reader(4).ToString)
                    .txtNotifyAddress1.Text = KVal(Dbo.reader(5).ToString)
                    .txtLocalVessel.Text = KVal(Dbo.reader(6).ToString)
                    .txtLocalVesselPOL.Text = Dbo.reader(7).ToString
                    .txtOceanVessel.Text = Dbo.reader(8).ToString
                    .txtOceanVesselPOL.Text = Dbo.reader(9).ToString
                    .txtPortOfDischarge.Text = Dbo.reader(10).ToString
                    .txtPayableAt.Text = Dbo.reader(11).ToString
                    .txtNosOfBL.Text = Dbo.reader(12).ToString
                    .txtPlaceDateIssue.Text = Dbo.reader(13).ToString
                    .dtOnBoardDate.Value = Dbo.reader(14).ToString
                    .txtFromPortCode.Text = Dbo.reader(15).ToString
                    .txtToPortCode.Text = Dbo.reader(16).ToString
                    If String.IsNullOrEmpty(Dbo.reader(20).ToString) Then
                        .DtDateIssue.Value = Now
                    Else
                        .DtDateIssue.Value = Dbo.reader(20).ToString
                    End If

                Loop
                Dbo.reader.Close()
                Dbo.SqlCon.Close()



                Call LoadContainersBL(SelBkNo)

                With .dtDescriptions
                    '.Rows.Clear()
                    Dim i As Integer = 0

                    Dbo.SqlCon.Open()
                    SQL = "SELECT MARK,PKGNos,DescriptionIs,KGS,CBM, Description1 FROM TBL_MARKS_AND_NUMBERS WHERE STAT = '1' AND BLNO = '" & selBLno & "'   AND REFNO = '" & SelRefno & "' ORDER BY ID ASC"
                    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
                    Dbo.reader = Dbo.SQLCmd.ExecuteReader
                    .Rows.Clear()

                    Do While Dbo.reader.Read
                        Dim Desc As String = Dbo.reader(2).ToString
                        If Dbo.reader(2).ToString.Contains("CONTAINER(S) STC:") Then
                            Desc = Dbo.reader(2).ToString ' & "                                    ""FREIGHT COLLECT"""
                        End If
                        .Rows.Add(Dbo.reader(0).ToString, Dbo.reader(1).ToString, Desc, IIf(i = 5, """FREIGHT COLLECT""", Dbo.reader(3).ToString), Dbo.reader(4).ToString, "", Dbo.reader(5).ToString)
                        i += 1
                    Loop
                    If i = 6 Then
                        .Rows.Add("", "", "", IIf(i = 6, """FREIGHT COLLECT""", ""), "", "", "")
                    End If
                    Dbo.reader.Close()
                    Dbo.SqlCon.Close()
                End With



            End If
        End With

        LoadForm(FrmBLForm, "BL FORM")
    End Sub

    Private Sub PRINTCORRECTEDBLsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRINTCORRECTEDBLsToolStripMenuItem.Click
        CorrectionNoticeRevised = "CNR-"
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to proceed.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        LoadForm(FrmGenerateBlMenus, "BL MENUS")
    End Sub

    Private Sub CORRECTCHARGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CORRECTCHARGESToolStripMenuItem.Click
        CorrectionNoticeRevised = "CNR-"
        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No blno assigned! Unable to set charges.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        frmSetCharges.pnlSettingsTemplate.Visible = False
        SelSysref = dtList.CurrentRow.Cells(1).Tag
        SelBkNo = dtList.CurrentRow.Cells(0).Tag
        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        SelectedTrade = dtList.CurrentRow.Cells(15).Value
        SelectedSubTrade = dtList.CurrentRow.Cells(16).Value

        Dim strChargesTemplate As String = ""
        strChargesTemplate = GetRyzk("SELECT * FROM TBL_CHARGES_TEMPLATE WHERE STAT = '1' AND Destination  = '" & SelectedTrade & "' AND Port = '" & SelectedSubTrade & "'", "L")

        If strChargesTemplate = NoRecordFound Then
            frmSetCharges.btnImportTemplateRates.Enabled = False
        Else
            frmSetCharges.btnImportTemplateRates.Enabled = True
        End If


        Call LoadForm(frmSetCharges, "SET CHARGES")
    End Sub

    Private Sub ToolStripMenuItem55_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem55.Click
        FrmGenerateBookingList.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem56_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem56.Click
        FrmGenerateTSReport.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        With CmsCS
            INITIALBOOKINGToolStripMenuItem.DropDownItems(0).Text = "FCL " & IIf(LandingForm.ServiceIs = "I", "(IMPORT)", "(EXPORT)")
            INITIALBOOKINGToolStripMenuItem.DropDownItems(1).Text = "LCL " & IIf(LandingForm.ServiceIs = "I", "(IMPORT)", "(EXPORT)")
            '.Items(0).Text = "FCL " & IIf(LandingForm.ServiceIs = "I", "(IMPORT)", "(EXPORT)")
            '.Items(1).Text = "LCL " & IIf(LandingForm.ServiceIs = "I", "(IMPORT)", "(EXPORT)")
        End With
    End Sub

    Private Sub LISTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LISTToolStripMenuItem1.Click
        LoadForm(FrmCorrectionAdviceList, "CORRECTION ADVICE - LIST")
    End Sub

    Private Sub FCLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FCLToolStripMenuItem.Click
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

    Private Sub LCLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LCLToolStripMenuItem.Click
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

    Private Sub MODIFYBLNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MODIFYBLNOToolStripMenuItem.Click
        If dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
            With FrmNewBLNO
                .txtFromBl.Text = dtList.CurrentRow.Cells(25).Value
            End With
            LoadForm(FrmNewBLNO, "NEW BLNO")
            Exit Sub
        End If


        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No BLNO found!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not dtList.CurrentRow.Cells(26).Tag = "1" Then
            MsgBox("Only floated references are valid for modification of BL!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If GetRyzk("SELECT * FROM TBL_BOOKING WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'", "") = NoRecordFound Then
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_MARKS_AND_NUMBERS WHERE STAT = '1' AND BLNO = '" & dtList.CurrentRow.Cells(25).Value & "'", "") = NoRecordFound Then
            MsgBox("This record has marks and numbers already!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_BL WHERE STAT = '1' AND BLNO = '" & dtList.CurrentRow.Cells(25).Value & "'", "") = NoRecordFound Then
            MsgBox("This record has OBL/NON-NEGO!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_RATES WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'", "") = NoRecordFound Then
            MsgBox("This BLNO already has charges. Please delete all charges first!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With FrmNewBLNO
            .txtFromBl.Text = dtList.CurrentRow.Cells(25).Value
        End With
        LoadForm(FrmNewBLNO, "NEW BLNO")


    End Sub

    Private Sub FLOATRECORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FLOATRECORDToolStripMenuItem.Click
        'If dtList.CurrentRow.Cells(21).Value = "REBOOKED" Then
        '    If MsgBox("Are you sure you want to float bl record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '        Call SetJob("UPDATE TBL_BOOKING SET FloatRecord = '1', FloatDate = '" & Now & "', FloatBy = '" & USER_ID & "' WHERE REFNO = '" & SelRefno & "' AND STAT <> '2' ")

        '        dtList.CurrentRow.Cells(26).Value = ImageList6.Images(0)
        '        dtList.CurrentRow.Cells(26).Tag = 1
        '        MsgBox("This record is now floated", MsgBoxStyle.Exclamation)
        '    End If
        '    Exit Sub
        'End If

        If dtList.CurrentRow.Cells(26).Tag = "1" Then
            MsgBox("This record is already float!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No BLNO found!", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If GetRyzk("SELECT * FROM TBL_BOOKING WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'", "") = NoRecordFound Then
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_MARKS_AND_NUMBERS WHERE STAT = '1' AND BLNO = '" & dtList.CurrentRow.Cells(25).Value & "'", "") = NoRecordFound Then
            MsgBox("This record has marks and numbers already!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_BL WHERE STAT = '1' AND BLNO = '" & dtList.CurrentRow.Cells(25).Value & "'", "") = NoRecordFound Then
            MsgBox("This record has OBL/NON-NEGO!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_RATES WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'", "") = NoRecordFound Then
            MsgBox("This BLNO already has charges. Please delete all charges first!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to float this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Call SetJob("UPDATE TBL_BOOKING SET FloatRecord = '1', FloatDate = '" & Now & "', FloatBy = '" & USER_ID & "' WHERE REFNO = '" & SelRefno & "' AND STAT <> '2' ")

            dtList.CurrentRow.Cells(26).Value = ImageList6.Images(0)
            dtList.CurrentRow.Cells(26).Tag = 1
            MsgBox("This record is now floated", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub UNFLOATRECORDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UNFLOATRECORDToolStripMenuItem.Click
        If dtList.CurrentRow.Cells(26).Tag = "0" Then
            MsgBox("This record is already unfloat status!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If String.IsNullOrEmpty(dtList.CurrentRow.Cells(26).Tag) Then
            MsgBox("This record is already unfloat status!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If dtList.CurrentRow.Cells(25).Value = "" Then
            MsgBox("No BLNO found!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If GetRyzk("SELECT * FROM TBL_BOOKING WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'", "") = NoRecordFound Then
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_MARKS_AND_NUMBERS WHERE STAT = '1' AND BLNO = '" & dtList.CurrentRow.Cells(25).Value & "'", "") = NoRecordFound Then
            MsgBox("This record has marks and numbers already!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_BL WHERE STAT = '1' AND BLNO = '" & dtList.CurrentRow.Cells(25).Value & "'", "") = NoRecordFound Then
            MsgBox("This record has OBL/NON-NEGO!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If Not GetRyzk("SELECT * FROM TBL_RATES WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'", "") = NoRecordFound Then
            MsgBox("This BLNO already has charges. Please delete all charges first!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If dtList.CurrentRow.Cells(26).Tag = "1" Then
            If MsgBox("Are you sure you want to unfloat this record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Call SetJob("UPDATE TBL_BOOKING SET FloatRecord = '0', unFloatRecord = '0', unFloatDate = '" & Now & "', unFloatBy = '" & USER_ID & "' WHERE REFNO = '" & SelRefno & "' AND STAT <> '2' ")

                dtList.CurrentRow.Cells(26).Value = ImageList5.Images(1)
                dtList.CurrentRow.Cells(26).Tag = 0
                MsgBox("This record is now unfloated", MsgBoxStyle.Exclamation)
            End If
        End If


    End Sub

    Private Sub FCLToolStripMenuItem1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub LCLToolStripMenuItem1_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub SUMMARYOFIMPORTCARGOLOADINGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SUMMARYOFIMPORTCARGOLOADINGToolStripMenuItem.Click
        LoadForm(FrmImportCargoLoadingMenu, "CARGO LOADING")
    End Sub

    Private Sub DELIVERYORDERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DELIVERYORDERToolStripMenuItem.Click
        With FrmDeliveryOrder
            .cmbConsignee.Text = SelConsignee
            .dtArrivalDate.Value = Now
            .cmbMV.Text = Me.dtList.CurrentRow.Cells(12).Value
            .cmbVoyage.Text = Me.dtList.CurrentRow.Cells(13).Value
            .cmbRegno.Text = ""
            .cmbMasterBL.Text = ""
        End With

        If Not GetRyzk("SELECT * FROM TBL_DELIVERY_ORDER WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'", "") = NoRecordFound Then
            With FrmDeliveryOrder
                .cmbConsignee.Text = GetRyzk("SELECT CONSIGNEE FROM TBL_DELIVERY_ORDER WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'", "")
                .dtArrivalDate.Value = GetRyzk("SELECT ARRIVALMANILA FROM TBL_DELIVERY_ORDER WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'", "")
                .cmbMV.Text = GetRyzk("SELECT MV FROM TBL_DELIVERY_ORDER WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'", "")
                .cmbVoyage.Text = GetRyzk("SELECT MV_VOYAGE FROM TBL_DELIVERY_ORDER WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'", "")
                .cmbRegno.Text = GetRyzk("SELECT REGNO FROM TBL_DELIVERY_ORDER WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'", "")
                .cmbMasterBL.Text = GetRyzk("SELECT MASTERBL FROM TBL_DELIVERY_ORDER WHERE STAT = '1' AND BLNO = '" & selBLno & "' AND BKNO = '" & SelBkNo & "'", "")
            End With
        End If

        LoadForm(FrmDeliveryOrder, "DELIVERY ORDER")
    End Sub

    Private Sub APPLYBLNOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles APPLYBLNOToolStripMenuItem.Click
        If dtList.CurrentRow.Cells(21).Value <> "CONFIRMED" Then
            MsgBox("This booking is not yet confirmed!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If dtList.CurrentRow.Cells(25).Value <> "" Then
            MsgBox("Already has BLNO", MsgBoxStyle.Critical)
            Exit Sub
        End If
        'apply_blno_import
        LoadForm(frmApplyBlno, "APPLY BLNO")
        'If MsgBox("Are you sure you want to apply BLNO for this booking number?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
        '    Dim BLNOis As String = GetRyzk("SELECT SERIES FROM TBL_REFERENCE WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & Me.SelServiceIs & "' AND PARAM3 = '" & Me.SelBookingType & "'", "L")
        '    BLNOis = Format(CInt(BLNOis), "0000000")
        '    SetJob("Update TBL_BOOKING SET BLNO = '" & GetRyzk("SELECT PARAM2 FROM TBL_REFERENCE WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & Me.SelServiceIs & "' AND PARAM3 = '" & Me.SelBookingType & "'", "L") & BLNOis & "' WHERE STAT = '1' AND SYSREF = '" & dtList.CurrentRow.Cells(1).Tag & "'")
        '    SetJob("UPDATE TBL_REFERENCE SET SERIES = '" & CInt(BLNOis) + 1 & "' WHERE PARAM2 = 'MNL-' AND PARAM1 = '" & Me.SelServiceIs & "'")
        '    Call btnSearch_Click(e, e)
        '    MsgBox("Successfully generated!", MsgBoxStyle.Information)
        '    Exit Sub
        'End If
    End Sub

    Private Sub CALCULATESPECIALCHARGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CALCULATESPECIALCHARGESToolStripMenuItem.Click
        With FrmSpecialChargesMenu
            selBLno = dtList.CurrentRow.Cells(25).Value
            SelConsignee = dtList.CurrentRow.Cells(4).Value
            selFeederVsl = dtList.CurrentRow.Cells(6).Value
            SelMotherVessel = dtList.CurrentRow.Cells(12).Value
            .cmbConsignee.Text = SelConsignee
            .cmbFeederVessel.Text = selFeederVsl
            .cmbFVoyage.Text = dtList.CurrentRow.Cells(7).Value
            .cmbMV.Text = SelMotherVessel
            .cmbMVVoyage.Text = dtList.CurrentRow.Cells(13).Value
            .txtBLNO.Text = selBLno

        End With
        LoadForm(FrmSpecialChargesMenu, "CALCULATE")
    End Sub

    Private Sub Button2_LostFocus(sender As Object, e As EventArgs) Handles Button2.LostFocus

    End Sub

    Private Sub RELEASECONTAINERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RELEASECONTAINERToolStripMenuItem.Click
        strDemmurageDetention = "DEM"
        LoadForm(FrmContainerRelease, "CONTAINER DISCHARGE")
    End Sub

    Private Sub CONTAINERPULLOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTAINERPULLOUTToolStripMenuItem.Click
        strDemmurageDetention = "DET"
        LoadForm(FrmContainerRelease, "CONTAINER DETENTION")
    End Sub

    Private Sub CONTAINERYARDRFPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTAINERYARDRFPToolStripMenuItem.Click
        'LoadForm(FrmNewRequestForPaymentForCy, "CY RFP")
        LoadForm(FrmRequestForPaymentCY, "CY RFP")
    End Sub

    Private Sub TRANSFERBOOKINGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TRANSFERBOOKINGToolStripMenuItem.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value

        LoadForm(FrmTransferBooking, "TRANSFER BOOKING")
    End Sub

    Private Sub GENERATEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERATEToolStripMenuItem.Click

    End Sub

    Private Sub ONHIREUNITSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ONHIREUNITSToolStripMenuItem.Click
        LoadForm(FrmOnhireUnits, "ON-HIRE UNITS")
    End Sub

    Private Sub ToolStripMenuItem58_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem58.Click

    End Sub

    Private Sub DAMAGEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DAMAGEToolStripMenuItem.Click
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag
        selBLno = dtList.CurrentRow.Cells(25).Value
        SelRefno = dtList.CurrentRow.Cells(24).Value
        Call LoadForm(frmDamage, "CONTAINER DAMAGE")
    End Sub

    Private Sub DETENTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DETENTIONToolStripMenuItem.Click

    End Sub

    Private Sub STORAGECHARGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STORAGECHARGESToolStripMenuItem.Click
        ' dtList.CurrentRow.Cells().Value
        With frmOtherCharges
            .cmbCategory.Text = "STORAGE CHARGES"
            .cmbCategory.Enabled = False
            .txtShipper.Text = dtList.CurrentRow.Cells(3).Value & vbCrLf & dtList.CurrentRow.Cells(4).Tag

            .txtShipper.Tag = dtList.CurrentRow.Cells(5).Tag
            .cmbFeederVessel.Tag = dtList.CurrentRow.Cells(6).Tag
            .cmbMotherVessel.Tag = dtList.CurrentRow.Cells(7).Tag

            .txtBLNo.Text = dtList.CurrentRow.Cells(25).Value
            .txtBKNo.Text = dtList.CurrentRow.Cells(2).Value
            .txtRefno.Text = dtList.CurrentRow.Cells(24).Value
            .cmbFeederVessel.Text = dtList.CurrentRow.Cells(6).Value
            .txtFeederVesselVoyage.Text = dtList.CurrentRow.Cells(7).Value
            .cmbMotherVessel.Text = dtList.CurrentRow.Cells(12).Value
            .txtMotherVesselVoyage.Text = dtList.CurrentRow.Cells(13).Value
            .TabControl1.SelectedIndex = 0
            lOADContainersforOtherCharges(dtList.CurrentRow.Cells(1).Tag, dtList.CurrentRow.Cells(0).Tag, "1", dtList.CurrentRow.Cells(24).Value, dtList.CurrentRow.Cells(25).Value, frmOtherCharges.dtStorage, "S")

        End With
        Call LoadForm(frmOtherCharges, "STORAGE CHARGES")
    End Sub

    Public Sub lOADContainersforOtherCharges(SYSREF As String, BKNO As String, StatIs As String, refno As String, blno As String, dt As DataGridView, tagIs As String)

        Dim Dbo As New SQLClass
        Dim colCurr As DataGridViewComboBoxColumn

        If tagIs = "S" Then
            colCurr = frmOtherCharges.dtStorage.Columns.Item(4)


            Dbo.SqlCon.Open()
            SQL = "select curr from tbl_currency where stat = '1'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            colCurr.Items.Clear()

            Do While Dbo.reader.Read
                colCurr.Items.Add(Dbo.reader(0).ToString)
            Loop
            'frmOtherCharges.dtStorage.Rows(0).Cells(4).Value = ""
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

        ElseIf tagIs = "T" Then

            colCurr = frmOtherCharges.dtTrucking.Columns.Item(4)


            Dbo.SqlCon.Open()
            SQL = "select curr from tbl_currency where stat = '1'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            colCurr.Items.Clear()

            Do While Dbo.reader.Read
                colCurr.Items.Add(Dbo.reader(0).ToString)
            Loop
            'frmOtherCharges.dtStorage.Rows(0).Cells(4).Value = ""
            Dbo.reader.Close()
            Dbo.SqlCon.Close()


            Dim colCurr2 As DataGridViewComboBoxColumn
            colCurr2 = frmOtherCharges.dtTrucking.Columns.Item(6)

            Dbo.SqlCon.Open()
            SQL = "select curr from tbl_currency where stat = '1'"
            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            colCurr2.Items.Clear()

            Do While Dbo.reader.Read
                colCurr2.Items.Add(Dbo.reader(0).ToString)
            Loop
            'frmOtherCharges.dtStorage.Rows(0).Cells(4).Value = ""
            Dbo.reader.Close()
            Dbo.SqlCon.Close()
        End If

        If tagIs = "S" Then


            Dbo.SqlCon.Open()
            'SQL = "SELECT  ID, ChargesCode, ChargesName, refno, bkno, blno, Shipper, feederVessel, motherVessel, containerNo, sizeIs, gateIn, startBillDate, endBillDate, nosOfDay, RateIs, eRate, dateAdded, addedBy, stat, curr, feedervesselvoyage, mothervesselvoyage FROM  TBL_OTHER_CHARGES WHERE (STAT  = '1' OR STAT <> '2') AND  BKNO = '" & BKNO & "' AND refno = '" & refno & "' and BLNO = '" & blno & "'  AND STAT = '1' AND CHARGESNAME = 'STORAGE CHARGES'"
            SQL = "select o.ID, o.ChargesCode, o.ChargesName, o.refno, o.bkno, o.blno, o.Shipper, o.feederVessel, o.motherVessel, c.containerNo, c.sizeIs, o.gateIn, o.startBillDate, o.endBillDate, o.nosOfDay, o.RateIs, o.eRate, o.dateAdded, o.addedBy, o.stat, o.curr, o.feedervesselvoyage, o.mothervesselvoyage, o.truckingWaitFee, o.truckingWaitFeeCurr from TBL_CONTAINER as c left join TBL_OTHER_CHARGES as o on c.ContainerNo = o.containerno and c.BKNO = o.bkno and o.ChargesName = 'STORAGE CHARGES' and o.stat = '1'  WHERE  c.BKNO = '" & BKNO & "'  AND c.STAT = '1' "

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With frmOtherCharges.dtStorage


                .Rows.Clear()
                Do While Dbo.reader.Read
                    .Rows.Add(True, Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(15).ToString, Dbo.reader(20).ToString, ShowDateAsKyowa(Dbo.reader(11).ToString), ShowDateAsKyowa(Dbo.reader(12).ToString), ShowDateAsKyowa(Dbo.reader(13).ToString), Dbo.reader(14).ToString, "SAVE", "DELETE")
                    '.Rows(.RowCount - 1).Cells(11).Value = Dbo.reader(11).ToString
                    '.Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(4).ToString
                    frmOtherCharges.txtER.Text = Dbo.reader(16).ToString
                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

            'If Not frmOtherCharges.dtStorage.RowCount > 0 Then

            '    Dbo.SqlCon.Open()
            '    SQL = "SELECT  ContainerNo, SizeIs FROM TBL_CONTAINER WHERE (STAT  = '1' OR STAT <> '2') AND  BKNO = '" & BKNO & "' AND SYSREF = '" & SYSREF & "'  AND STAT = '" & StatIs & "'"
            '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            '    Dbo.reader = Dbo.SQLCmd.ExecuteReader
            '    With frmOtherCharges.dtStorage


            '        .Rows.Clear()
            '        Do While Dbo.reader.Read
            '            .Rows.Add(False, Dbo.reader(0).ToString, Dbo.reader(1).ToString, "", "", "", "", "", "", "SAVE", "DELETE")
            '            '.Rows(.RowCount - 1).Cells(11).Value = Dbo.reader(11).ToString
            '            '.Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(4).ToString
            '        Loop
            '    End With
            '    Dbo.reader.Close()
            '    Dbo.SqlCon.Close()
            'End If
        ElseIf tagIs = "T" Then


            Dbo.SqlCon.Open()
            'SQL = "SELECT  ID, ChargesCode, ChargesName, refno, bkno, blno, Shipper, feederVessel, motherVessel, containerNo, sizeIs, gateIn, startBillDate, endBillDate, nosOfDay, RateIs, eRate, dateAdded, addedBy, stat, curr, feedervesselvoyage, mothervesselvoyage, truckingWaitFee,TruckingWaitFeeCurr  FROM  TBL_OTHER_CHARGES WHERE (STAT  = '1' OR STAT <> '2') AND  BKNO = '" & BKNO & "' AND refno = '" & refno & "' and BLNO = '" & blno & "'  AND STAT = '1' AND CHARGESNAME = 'TRUCKING CHARGES'"
            SQL = "select o.ID, o.ChargesCode, o.ChargesName, o.refno, o.bkno, o.blno, o.Shipper, o.feederVessel, o.motherVessel, c.containerNo, c.sizeIs, o.gateIn, o.startBillDate, o.endBillDate, o.nosOfDay, o.RateIs, o.eRate, o.dateAdded, o.addedBy, o.stat, o.curr, o.feedervesselvoyage, o.mothervesselvoyage, o.truckingWaitFee, o.truckingWaitFeeCurr from TBL_CONTAINER as c left join TBL_OTHER_CHARGES as o on c.ContainerNo = o.containerno and c.BKNO = o.bkno and o.ChargesName = 'TRUCKING CHARGES' and o.stat = '1'  WHERE  c.BKNO = '" & BKNO & "'  AND c.STAT = '1' "

            Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            Dbo.reader = Dbo.SQLCmd.ExecuteReader
            With frmOtherCharges.dtTrucking


                .Rows.Clear()
                Do While Dbo.reader.Read
                    .Rows.Add(True, Dbo.reader(9).ToString, Dbo.reader(10).ToString, Dbo.reader(15).ToString, Dbo.reader(20).ToString, Dbo.reader(23).ToString, Dbo.reader(24).ToString, "SAVE", "DELETE")
                    '.Rows(.RowCount - 1).Cells(11).Value = Dbo.reader(11).ToString
                    '.Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(4).ToString
                    frmOtherCharges.txtER.Text = Dbo.reader(16).ToString
                Loop
            End With
            Dbo.reader.Close()
            Dbo.SqlCon.Close()

            'If Not frmOtherCharges.dtTrucking.RowCount > 0 Then

            '    Dbo.SqlCon.Open()
            '    SQL = "SELECT  ContainerNo, SizeIs FROM TBL_CONTAINER WHERE (STAT  = '1' OR STAT <> '2') AND  BKNO = '" & BKNO & "' AND SYSREF = '" & SYSREF & "'  AND STAT = '" & StatIs & "'"
            '    Dbo.SQLCmd = New SqlClient.SqlCommand(SQL, Dbo.SqlCon)
            '    Dbo.reader = Dbo.SQLCmd.ExecuteReader
            '    With frmOtherCharges.dtTrucking


            '        .Rows.Clear()
            '        Do While Dbo.reader.Read
            '            .Rows.Add(False, Dbo.reader(0).ToString, Dbo.reader(1).ToString, "", "", "", "", "SAVE", "DELETE")
            '            '.Rows(.RowCount - 1).Cells(11).Value = Dbo.reader(11).ToString
            '            '.Rows(.RowCount - 1).Cells(0).Tag = Dbo.reader(4).ToString
            '        Loop
            '    End With
            '    Dbo.reader.Close()
            '    Dbo.SqlCon.Close()
            'End If
        End If


    End Sub

    Private Sub TRUCKINGCHARGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TRUCKINGCHARGESToolStripMenuItem.Click
        With frmOtherCharges
            .cmbCategory.Text = "TRUCKING CHARGES"
            .cmbCategory.Enabled = False
            .txtShipper.Text = dtList.CurrentRow.Cells(3).Value & vbCrLf & dtList.CurrentRow.Cells(4).Tag

            .txtShipper.Tag = dtList.CurrentRow.Cells(5).Tag
            .cmbFeederVessel.Tag = dtList.CurrentRow.Cells(6).Tag
            .cmbMotherVessel.Tag = dtList.CurrentRow.Cells(7).Tag

            .txtBLNo.Text = dtList.CurrentRow.Cells(25).Value
            .txtBKNo.Text = dtList.CurrentRow.Cells(2).Value
            .txtRefno.Text = dtList.CurrentRow.Cells(24).Value
            .cmbFeederVessel.Text = dtList.CurrentRow.Cells(6).Value
            .txtFeederVesselVoyage.Text = dtList.CurrentRow.Cells(7).Value
            .cmbMotherVessel.Text = dtList.CurrentRow.Cells(12).Value
            .txtMotherVesselVoyage.Text = dtList.CurrentRow.Cells(13).Value
            lOADContainersforOtherCharges(dtList.CurrentRow.Cells(1).Tag, dtList.CurrentRow.Cells(0).Tag, "1", dtList.CurrentRow.Cells(24).Value, dtList.CurrentRow.Cells(25).Value, frmOtherCharges.dtStorage, "T")
            .TabControl1.SelectedIndex = 1
        End With
        Call LoadForm(frmOtherCharges, "TRUCKING CHARGES")
    End Sub

    Private Sub GENERATESPECIALCHARGESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERATESPECIALCHARGESToolStripMenuItem.Click
        Call LoadForm(frmGenerateSpecialCharges, "SPECIAL CHARGES")
    End Sub

    Private Sub cmbFVoyage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFVoyage.SelectedIndexChanged

    End Sub

    Private Sub cmbValue_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch_Click(e, e)
        End If
    End Sub

    Private Sub Button1_MouseClick(sender As Object, e As MouseEventArgs) Handles Button1.MouseClick



        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag



        If e.Button = MouseButtons.Left Then
            With cmsDocumentations
                .Items(0).Text = MainBkno
                .Items(0).Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
                .Show(sender, 0, 0 - cmsDocumentations.Height)
            End With

        End If
    End Sub

    Private Sub Button4_MouseClick(sender As Object, e As MouseEventArgs) Handles Button4.MouseClick
        If dtList.RowCount = 0 Then
            Exit Sub
        End If
        MainSysref = dtList.CurrentRow.Cells(1).Tag
        MainBkno = dtList.CurrentRow.Cells(0).Tag



        If e.Button = MouseButtons.Left Then
            With CmsCS
                .Items(0).Text = MainBkno
                .Items(0).Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
                .Show(sender, 0, 0 - CmsCS.Height)
            End With

        End If
    End Sub

    Private Sub dtList_CellContextMenuStripChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtList.CellContextMenuStripChanged

    End Sub
End Class