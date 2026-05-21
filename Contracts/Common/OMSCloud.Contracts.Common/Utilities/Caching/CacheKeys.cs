using System.Collections;
using System.Collections.Generic;

namespace OMSCloud.Contracts.Common.Utilities.Caching
{
    public static partial class CacheKeys
    {
        private static string KeySpliter = "-";
        private static string ValueSpliter = ":";

        #region Info Keys
        public static string DMS_COMP_DATEInfo = "DMS_COMP_DATEInfo";
        public static string BR_MAINInfo = "BR_MAINInfo";
        public static string MILG_UNIT_CODEInfo = "MILG_UNIT_CODEInfo";
        public static string MILG_UNITInfo = "MILG_UNITInfo";
        public static string TemplateSmsEntity = "TemplateSmsEntity";
        public static string CONT_DD_CNFGInfo = "CONT_DD_CNFGInfo";
        public static string CHRT_PRTY_CODEInfo = "CHRT_PRTY_CODEInfo";
        public static string ADDL_INTR_CNFG_CODEInfo = "ADDL_INTR_CNFG_CODEInfo";
        public static string ACCT_TYPE_CODEInfo = "ACCT_TYPE_CODEInfo";
        public static string ADDS_TYPE_CODEInfo = "ADDS_TYPE_CODEInfo";
        public static string BSNS_TYPE_CODEInfo = "BSNS_TYPE_CODEInfo";
        public static string CITY_CODEInfo = "CITY_CODEInfo";
        public static string BP_CLAS_CODEInfo = "BP_CLAS_CODEInfo";
        public static string CTRY_CODEInfo = "CTRY_CODEInfo";
        public static string BP_CRDT_RTNG_CODEInfo = "BP_CRDT_RTNG_CODEInfo";
        public static string DRVR_RTNG_CODEInfo = "DRVR_RTNG_CODEInfo";
        public static string INDY_SBTP_CODEInfo = "INDY_SBTP_CODEInfo";
        public static string INDY_TYPE_CODEInfo = "INDY_TYPE_CODEInfo";
        public static string LOAN_GRDE_CODEInfo = "LOAN_GRDE_CODEInfo";
        public static string OCPN_CODEInfo = "OCPN_CODEInfo";
        public static string PYMT_MODE_CODEInfo = "PYMT_MODE_CODEInfo";              
        public static string PHNE_TYPE_CODEInfo = "PHNE_TYPE_CODEInfo";
        public static string PRPY_TYPE_CODEInfo = "PRPY_TYPE_CODEInfo";
        public static string STAT_CODEInfo = "STAT_CODEInfo";
        public static string TITL_CODEInfo = "TITL_CODEInfo";
        public static string BP_MAINInfo = "BP_MAINInfo";
        public static string ASET_MAKE_CODEInfo = "ASET_MAKE_CODEInfo";
        public static string ASET_BRND_CODEInfo = "ASET_BRND_CODEInfo";
        public static string FINL_PROD_GRUPInfo = "FINL_PROD_GRUPInfo";
        public static string ROLE_CODEInfo = "ROLE_CODEInfo";
        public static string GENR_CODEInfo = "GENR_CODEInfo";
        public static string MRTL_STUS_CODEInfo = "MRTL_STUS_CODEInfo";
        public static string STRT_TYPE_CODEInfo = "STRT_TYPE_CODEInfo";
        public static string EMPT_TYPE_CODEInfo = "EMPT_TYPE_CODEInfo";
        public static string ASET_TYPE_CODEInfo = "ASET_TYPE_CODEInfo";
        public static string ASET_SBTP_CODEInfo = "ASET_SBTP_CODEInfo";
        public static string ASET_CDTN_CODEInfo = "ASET_CDTN_CODEInfo";
        public static string ASET_DIVN_CODEInfo = "ASET_DIVN_CODEInfo";
        public static string RISK_GRUPInfo = "RISK_GRUPInfo";
        public static string FINL_PRODInfo = "FINL_PRODInfo";
        public static string ASET_MODL_CODEInfo = "ASET_MODL_CODEInfo";
        public static string PYMT_FRQY_CODEInfo = "PYMT_FRQY_CODEInfo";
        public static string RPRT_DBSR_CODEInfo = "RPRT_DBSR_CODEInfo";
        public static string RNTL_MODE_CODEInfo = "RNTL_MODE_CODEInfo";
        public static string REQT_STUS_CODEInfo = "REQT_STUS_CODEInfo";
        public static string SITN_CODEInfo = "SITN_CODEInfo";
        public static string SALE_CHNL_CODEInfo = "SALE_CHNL_CODEInfo";
        public static string SCRT_QSTN_CODEInfo = "SCRT_QSTN_CODEInfo";
        public static string ACCY_CODEInfo = "ACCY_CODEInfo";
        public static string RLSP_CODEInfo = "RLSP_CODEInfo";
        public static string USER_RLSP_TYPE_CODEInfo = "USER_RLSP_TYPE_CODEInfo";
        public static string RLSP_TYPE_CODEInfo = "RLSP_TYPE_CODEInfo";
        public static string RLSP_LINK_TYPE_CODEInfo = "RLSP_LINK_TYPE_CODEInfo";
        public static string BP_DSGN_CODEInfo = "BP_DSGN_CODEInfo";
        public static string CHRG_TYPE_CODEInfo = "CHRG_TYPE_CODEInfo";
        public static string COMN_TYPE_CODEInfo = "COMN_TYPE_CODEInfo";
        public static string BP_DEPT_CODEInfo = "BP_DEPT_CODEInfo";
        public static string TPLE_TYPE_CODEInfo = "TPLE_TYPE_CODEInfo";
        public static string ACCOUNTING_FP_CODEInfo = "ACCOUNTING_FP_CODEInfo";
        public static string ASET_CLOR_CODEInfo = "ASET_CLOR_CODEInfo";
        public static string COLN_RSLT_CODEInfo = "COLN_RSLT_CODEInfo";
        public static string BASE_RATE_TYPE_CODEInfo = "BASE_RATE_TYPE_CODEInfo";
        public static string PBLE_TYPE_CODEInfo = "PBLE_TYPE_CODEInfo";
        public static string PBLE_TYPE_CODESTPInfo = "PBLE_TYPE_CODESTPInfo";
        public static string PBLE_TYPE_CODEINSRInfo = "PBLE_TYPE_CODEINSRInfo";
        public static string PBLE_TYPE_CODEINFO = "PBLETYPECODEINFO";
        public static string DIRY_WIND_TYPE_CODEInfo = "DIRY_WIND_TYPE_CODEInfo";
        public static string DIRY_ACTN_CODEInfo = "DIRY_ACTN_CODEInfo";
        public static string DIRY_TYPE_CODEInfo = "DIRY_TYPE_CODEInfo";
        public static string DIRY_CNFG_WIND_TRCKInfo = "DIRY_CNFG_WIND_TRCKInfo";
        public static string RPRT_CNFG_CODEInfo = "RPRT_CNFG_CODEInfo";
        
        public static string ROND_TYPE_CODEInfo = "ROND_TYPE_CODEInfo";
        public static string GL_ACCT_TYPEInfo = "GL_ACCT_TYPEInfo";
        public static string ROND_CLAS_CODEInfo = "ROND_CLAS_CODEInfo";
        public static string INFC_TYPE_CODEInfo = "INFC_TYPE_CODEInfo";
        public static string CRDT_CARD_TYPEInfo = "CRDT_CARD_TYPEInfo";
        public static string GEO_MAINInfo = "GEO_MAINInfo";
        public static string RDMP_EXPY_MODL_CODEInfo = "RDMP_EXPY_MODL_CODEInfo";
        public static string CountryGeoEntity = "CountryGeoEntity";
        public static string GEO_TYPE_CODEInfo = "GEO_TYPE_CODEInfo";
        public static string CSFL_ITEM_CODEInfo = "CSFL_ITEM_CODEInfo";
        public static string GEO_TPLE_DETLInfo = "GEO_TPLE_DETLInfo";
        public static string DTS_MODL_CODEInfo = "DTS_MODL_CODEInfo";
        public static string CRCY_RATE_SRCE_CODEInfo = "CRCY_RATE_SRCE_CODEInfo";
        public static string CLRL_CODEInfo = "CLRL_CODEInfo";
        public static string CLRL_SBTP_CODEInfo = "CLRL_SBTP_CODEInfo";
        public static string GEO_PRMT_CODEInfo = "GEO_PRMT_CODEInfo";
        public static string GEO_TYPE_DETLInfo = "GEO_TYPE_DETLInfo";
        public static string CNFG_SERV_TPLEInfo = "CNFG_SERV_TPLEInfo";
        public static string CMTE_CODEInfo = "CMTE_CODEInfo";
        public static string FINL_RATO_CALCInfo = "FINL_RATO_CALCInfo";
        public static string REPT_CHRS_EXPRInfo = "REPT_CHRS_EXPRInfo";
        public static string ASET_MODL_ASSNInfo = "ASET_MODL_ASSNInfo";
        public static string CRCY_LKUP_CODEInfo = "CRCY_LKUP_CODEInfo";
        public static string NTFY_TYPE_CODEInfo = "NTFY_TYPE_CODEInfo";
        public static string BP_BANKInfo = "BP_BANKInfo";
        public static string CLTR_TYPE_CODEInfo = "CLTR_TYPE_CODEInfo";
        public static string COMM_MTHD_CODEInfo = "COMM_MTHD_CODEInfo";
        public static string RV_TYPE_CODEInfo = "RV_TYPE_CODEInfo";
        public static string INPT_CODEInfo = "INPT_CODEInfo";
        public static string INTR_TYPE_CODEInfo = "INTR_TYPE_CODEInfo";
        public static string INSR_TYPE_CODEInfo = "INSR_TYPE_CODEInfo";        
        public static string INSRTYPECODEInfo = "INSRTYPECODEInfo";
        public static string BP_MNTC_SERV_ASSNInfo = "BP_MNTC_SERV_ASSNInfo";
        public static string TAX_CTGY_CODEInfo = "TAX_CTGY_CODEInfo";
        public static string RV_APP_TYPE_CODEInfo = "RV_APP_TYPE_CODEInfo";
        public static string INVC_TYPE_CODEInfo = "INVC_TYPE_CODEInfo";
        public static string RCPT_ACTN_CODEInfo = "RCPT_ACTN_CODEInfo";
        public static string WKF_TABL_TYPE_CODEInfo = "WKF_TABL_TYPE_CODEInfo";
        public static string CLTR_CODEInfo = "CLTR_CODEInfo";
        public static string PASW_SESN_CODEInfo = "PASW_SESN_CODEInfo";
        public static string ITFC_TYPE_CODEInfo = "ITFC_TYPE_CODEInfo";
        public static string FILE_TYPE_CODEInfo = "FILE_TYPE_CODEInfo";
        public static string LEGL_STUS_CODEInfo = "LEGL_STUS_CODEInfo";
        public static string SPRTR_TYPE_CODEInfo = "SPRTR_TYPE_CODEInfo";
        public static string STRT_NMBR_CMPT_CODEInfo = "STRT_NMBR_CMPT_CODEInfo";
        public static string GEO_MAINInfoTple = "GEO_MAINInfoTempl";
        public static string LN_INTR_DUE_CODEInfo = "LN_INTR_DUE_CODEInfo";
        public static string BP_MAINInfoDealer = "BP_MAINInfoDealer";
        public static string LN_FP_CHNG_CODEInfo = "LN_FP_CHNG_CODEInfo";
        public static string LN_ASET_LOCNInfo = "LN_ASET_LOCNInfo";
        public static string FINE_TYPE_INCM_CNFGInfo = "FINE_TYPE_INCM_CNFGInfo";

        public static string STRT_NMBR_CMPT_ABVNInfo1 = "STRT_NMBR_CMPT_ABVNInfo1";
        public static string RCVD_TYPE_CODEInfo = "RCVD_TYPE_CODEInfo";

        public static string SPNT_TYPE_CODEInfo = "SPNT_TYPE_CODEInfo";
        public static string OTO_BANK_FILE_CTGYInfo = "OTO_BANK_FILE_CTGYInfo";

        public static string REQT_FRWD_CODEInfoKey = "REQT_FRWD_CODEInfoKey";
        public static string REQT_FINL_FILDInfoKey = "REQT_FINL_FILDInfoKey";
        public static string OTP_CODEInfoKey = "OTP_CODEInfoKey";
        public static string OTP_GRNT_OPTN_CODEInfoKey = "OTP_GRNT_OPTN_CODEInfoKey"; 
        public static string REQT_MDFY_AREA_CNFGInfoKey = "REQT_MDFY_AREA_CNFGInfoKey";

        public static string CHNG_REQD_CODEInfoKey = "CHNG_REQD_CODEInfoKey";
        public static string INTR_ROLE_ASSNInfoKey = "INTR_ROLE_ASSNInfoKey";
        public static string DOCT_SETInfoKey = "DocumentSetKey";
        public static string MESG_TYPE_CODEInfo = "MESG_TYPE_CODEInfo";
        public static string RESN_TYPE_CODEInfo = "RESN_TYPE_CODEInfo";
        public static string BACS_TRSN_TYPE_CODEInfo = "BACS_TRSN_TYPE_CODEInfo";
        public static string ACTN_TYPE_CODEInfo = "ACTN_TYPE_CODEInfo";
        #endregion

        /// <summary>
        /// Keys that are related to Infos Should be as Name of Info like AMNT_CMPTInfo
        /// </summary>

        #region Made as Infos
        public static string VAT_TYPE_CODEInfo = "VAT_TYPE_CODEInfo";
        public static string FINL_RATO_GRUPInfo = "FINL_RATO_GRUPInfo";
        public static string AMNT_CMPT_CODEInfo = "AMNT_CMPT_CODEInfo";
        public static string ACTN_EVNT_CODEInfo = "ACTN_EVNT_CODEInfo";
        public static string TPLE_MAINInfo = "TPLE_MAINInfo";
        public static string REQT_EXECInfo = "REQT_EXECInfo";
        public static string CRCY_TYPE_CODEInfo = "CRCY_TYPE_CODEInfo";
        public static string RCPT_TYPE_CODEInfo = "RCPT_TYPE_CODEInfo";
        public static string INVC_GNTN_CNFGInfo = "INVC_GNTN_CNFGInfo";
        public static string SERV_CODEInfo = "SERV_CODEInfo";
        public static string INVC_GRUP_ITEMInfo = "INVC_GRUP_ITEMInfo";
        public static string SERV_GRUP_CODEInfo = "SERV_GRUP_CODEInfo";
        public static string AMNT_CMPT_DETLInfo = "AMNT_CMPT_DETLInfo";

        //temp
        public static string AMNT_CMPT_DETLInfoAll = "AMNT_CMPT_DETLInfoAll";


        public static string SD_CALC_CODEInfo = "SD_CALC_CODEInfo";
        public static string SD_CNFG_CODEInfo = "SD_CNFG_CODEInfo";
        public static string BP_SBDR_MAINInfo = "BP_SBDR_MAINInfo";
        public static string BP_SBDR_BRCHInfo = "BP_SBDR_BRCHInfo";
        public static string PASW_RESN_CODEInfo = "PASW_RESN_CODEInfo";
        public static string REGN_FINE_TYPEInfo = "REGN_FINE_TYPEInfo";
        public static string LTGN_TYPE_CODEInfo = "LTGN_TYPE_CODEInfo";
        public static string CMPT_FINE_TYPE_CODEInfo = "CMPT_FINE_TYPE_CODEInfo";
        public static string CORT_TYPE_CODEInfo = "CORT_TYPE_CODEInfo";
        public static string INPT_PRMTInfoKey = "INPT_PRMTInfoKey";
        public static string MDUL_CMPT_DETLInfoKey = "MDUL_CMPT_DETLInfoKey";
        public static string DPRN_MTHD_CODEInfoKey = "DPRN_MTHD_CODEInfoKey";
        public static string DPRN_CALC_CODEInfoKey = "DPRN_CALC_CODEInfoKey";
        public static string ACTN_CODEInfo = "ACTN_CODEInfo";
        public static string LTGN_DCSN_CODEInfo = "LTGN_DCSN_CODEInfo";
        public static string TAX_APBL_TYPE_CODEInfo = "TAX_APBL_TYPE_CODEInfo";
        public static string CHRG_CRTE_TYPE_CODEInfo = "CHRG_CRTE_TYPE_CODEInfo";
        public static string DIRY_CTGY_CODEInfo = "DIRY_CTGY_CODEInfo";

        #endregion

        #region NonInfo Keys

        public static string PasswordReasonCodeKey = "PasswordReasonCodeKey";
        public static string InterfaceRecordTypeKey = "InterfaceRecordTypeKey";
        public static string OTPDecisionkey = "OTPDecisionkey";

        public static string DocumentTypeKey = "DocumentTypeKey";
        public static string VerificationStatuskey = "VerificationStatuskey";
        public static string InterfaceSeparatorKey = "InterfaceSeparatorKey";
        public static string CautionMarkTypeKeyEnum = "CautionMarkTypeKeyEnum";
        public static string LitigationTypeRequestKeyEnum = "LitigationTypeRequestKeyEnum";
        public static string BankNameKey = "BankNameKey";

        public static string BankCodeLookupKey = "BankCodeLookup";
        public static string BankbranchCodeLookupKey = "BranchCodeLookup";

        public static string InsCompanyLookupKey = "InsCompanyLookup";
        public static string FinanceCompanyKey = "FinanceCompanyLookup";
        public static string FinanceCompanyBranchKey = "FinanceCompanyBranchLookup";

        public static string FinancialProductGroupByFPGIDKey = "FinancialProductGroupByFPGIDLookup";

        public static string FinancialProductByFPIDKey = "FinancialProductByFPIDLookup";
        public static string IntroducerKey = "IntroducerLookup";

        public static string CategoryTypeCodeKey = "CategoryTypeCodeKey";

        public static string AssetModelCodeKey = "AssetModelCodeLookup";

        public static string IntroducerBranchKey = "InroducerBranchLookup";
        public static string AssetMakeCodeLookup = "AssetMakeCodeLookup";
        public static string AssetBrandCodeLookupKey = "AssetBrandCodeLookup";


        public static string SubsidyTypeKey = "SubsidyTypeLookup";

        public static string StatusCodeKey = "STUS_CODEInfo";

        public static string ProcessingDateKey = "ProcessingDateLookup";
        public static string Search = "Search";
        public static string SearchTypeKey = "SearchTypeLookup";
        public static string SearchTypeColumnKey = "SearchTypeColumnLookup";
        public static string SearchResultKey = "SearchResultLookup";
        public static string SearchOperatorKey = "SearchOperatorLookup";

        public static string ReceiptPayamnetModeCodeKey = "ReceiptPaymentModeCodeLookup";
        public static string PayablePayamnetModeCodeKey = "PayablePayamentModeCodeKey";
        public static string RequestWiseRequestStatusKey = "RequestWiseRequestStatusLookup";


        public static string WKFTablesCodeKey = "WKFTablesCodeLookup";
        public static string ItemDataSourceCodeKey = "ItemDataSourceCodeKeyLookup";

        public static string ThirdPartyTypekey = "ThirdPartyLookup";
        public static string BusinessPartnerkey = "BusinessPartnerLookup";

        public static string ProposalTypeCodeKey = "ProposalTypeCodeLookup";
        public static string ApplicantTypeCodeKey = "ApplicantTypeCodeLookup";
        public static string WQRequestTypeCodeKey = "WQReqTypeCodeLkp";
        public static string RequestTypeCodeKey = "RequestTypeCodeLookup";

        public static string ResidenceTypeCodeKey = "ResidenceTypeCodeLookup";
        public static string AddressStatusCodeKey = "AddressStatusCodeLookup";
        public static string RequestExecutionStatusKey = "RequestExecutionStatusLookup";
        public static string ModuleCodeKey = "ModuleCodeLookup";
        public static string ReceiptComponentTemplateKey = "ReceiptComponentLookup";
        public static string ReceiptSubComponentTemplateKey = "ReceiptSubComponentLookup";
        public static string ProcessinDayCodeKey = "ProcessingDayLookup";
        public static string HolidayCodeKey = "HolidayLookup";

        // change Name of key "templateTypeKey" to "TPLE_TYPE_CODEInfo" by Iqra Khalid

        public static string ReceiptTemplateIdKey = "ReceiptTemplateIdLookup";
        public static string ApplicationStatusCodeKey = "ApplicationStatusCodeKey";
        public static string FPGroupValuesKey = "FPGroupValuesKey";
        public static string FPParameterKey = "FPParameterKey";
        public static string LanguageCodeKey = "LANG_CODEInfo";
        public static string CompanyConfigurationKey = "CompanyConfigurationKey";
        public static string UserGroupKey = "USER_GRUP_CODEInfo";
        public static string WorkflowUserKey = "WorkflowUserKey";
        public static string PasswordPolicyKey = "PASW_PLCY_CODEInfo";
        public static string AllCompaniesKey = "AllCompaniesKey";
        public static string AllCompanyBranchesKey = "AllCompanyBranchesKey";
        public static string AllGroupsKey = "AllGroupsKey";
        public static string AllUsersKey = "AllUsersKey";
        public static string ProductRequestTypeKey = "ProductRequestTypeKey";
        public static string ETMethodKey = "ETMethodKey";
        public static string IDTypeCodeKey = "ID_TYPE_CODEInfo";
        public static string AddressTemplateCodeKey = "AddressTemplateLookup";
        public static string FinancialParameterLookupKey = "FinancialParameterLookup";

        public static string SaleChannelLooKupKey = "SaleChannelLooKupKey";
        public static string ApplicationCodeKey = "ApplicationCode";
        public static string ManufacturerCodeKey = "ManufacturerCode";
        public static string SearchJoinClauseKey = "SearchJoinClauseKey";
        public static string IntroducerSalepersonKey = "InroducerSalepersonLookup";
        public static string PlateTypeKey = "PlateTypeLookup";
        public static string TransmissionTypeKey = "TransmissionTypeLookup";

        public static string CollectionActivityCodesKey = "CollectionActivityCodeLookup";
        public static string FPETMethodLookupKey = "FPETMethodLookupKey";
        public static string CollectionContactCodesKey = "CollectionContactCodesLookup";
        public static string CollectionBPCodesKey = "CollectionBPCodesKeyLookup";

        public static string ReasonCodeLookupKey = "ReasonCodeLookupKey";
        public static string TableSourceKey = "TableSourceLookupKey";
        public static string FunctionSourceKey = "FunctionSourceLookupKey";
        public static string ConfigSettlementTemplateTypeKey = "ConfigSettlementTemplateLookupKey";
        public static string BPRelationshipCategoryKey = "BPRelationshipCategoryLookupKey";
        public static string SearchWhereClausesKey = "SearchWhereClausesKey";
        public static string ItemSourceKey = "ITEM_SRCEInfo";       // Modified because of getting Updated Cache
        public static string BusinessRuleKey = "BSNS_RULEInfo";  // Modified because of getting Updated Cache
        public static string OperatorKey = "OperatorKeyLookupKey";
        public static string ConfigurationTemplateKey = "ConfigurationTemplateLookupKey";
        public static string AllFinancialProductKey = "AllFinancialProductKeyLookupKey";
        public static string AttachFPTemplateConfiguraitonKey = "AttachTemplateConfiguraitonLookUpKey";
        public static string FPConfigurationTemplateEntityKey = "ConfigurationTemplateEntityLookupKey";
        public static string FinanceTypeKey = "FinanceTypeLooKupKey";
        public static string CreditLineFinanceTypeKey = "CreditLineFinanceTypeLooKupKey";
        public static string ModelTypeLookupKey = "ModelTypeLookup";
        public static string BusinessRuleGroupLookupKey = "BusinessRuleGroupLookup";
        public static string RuleGroupDetailLookupKey = "RuleGroupDetailLookup";
        public static string BankAccountsKey = "BanksAccountKeyLookup";

        public static string BaseRateChartSourceKey = "BaseRateChartSourceLookup";
        public static string BusinessPartnerBanksKey = "BusinessPartnerBanksLookup";
        public static string AssetModelAssociationKey = "AssetModelAssociationLookup";
        public static string SecurityTreatmentKey = "SecurityTreatmentKeyLookup";
        public static string IncomRecognitionBasisKey = "IncomRecognitionBasisKey";
        public static string AccessoryFittingTypekey = "AccessortFittingLookup";
        public static string RequestExecutionStatus = "RequestExecutionStatusLookup";
        public static string BusinessPartnerTypekey = "BusinessPartnetTypeLookup";
        public static string RequestOpnionKey = "RequestOpnionLookup";
        public static string AssetTypeCodeTypeDetailKey = "AssetTypeCodeTypeDetailLookup";
        public static string TaxInclusiveIndKey = "TaxInclusiveIndKey";
        public static string ChargeStatusKey = "ChargeStatusKey";

        public static string ChargeTypeKey = "ChargeTypeKey";
        public static string ClaimITCKey = "ClaimITCKey";
        public static string TaxApplicationStatusKey = "TaxApplicationStatusKey";
        public static string AmortizationMethodKey = "AmortizationMethodKey";
        public static string InterstConfigEffectiveFromKey = "InterstConfigEffectiveFromKey";
        public static string RevisionFrequencyKey = "RevisionFrequencyKey";
        public static string RentalCalculationKey = "RentalCalculationKey";
        public static string RentalAmortizationMethodKey = "RentalAmortizationMethodKey";
        public static string REVSFinanceCodeKey = "REVSFinanceCodeKey";
        public static string RequestTypeEnumKey = "RequestTypeEnumKey";
        public static string ETCalculationMethodKey = "ETCalculationMethodKey";
        public static string ETFeeAmortizaqtionKey = "ETFeeAmortizaqtionKey";
        public static string GSTETPaneltyKey = "GSTETPaneltyKey";
        public static string IDTypeKey = "IDTypeKey";
        public static string ProductTypesKey = "ProductTypesKey";
        public static string OverPaymentAdjustmentMethodsKey = "OverPaymentAdjustmentMethodsKey";
        public static string PromiseStatusKey = "PromiseStatusKey";
        public static string ChargeAmortizationMethodKey = "ChargeAmortizationMethodLookupKey";
        public static string OwnerStatusKey = "OwnerStatusKey";

        public static string ConsumerAccountTypeKey = "ConsumerAccountTypeKey";
        public static string TaxAuthorityDepriciationMethodKey = "TaxAuthorityDepriciationMethodKey";
        public static string AmountTypeKey = "AmountTypeKey";
        public static string DistributionMethodKey = "DistributionMethodKey";
        public static string ITCCalculateStatusKey = "ITCCalculateStatusKey";
        public static string SettlementMethodsKey = "SettlementMethodsKey";

        public static string CommissionPriorityKey = "CommissionPriorityKey";
        public static string DealerTypeKey = "DealerTypeKey";
        public static string ETPenaltyBasisKey = "ETPenaltyBasisKey";
        public static string PriortyKey = "PriortyLookupKey";
        public static string AllModulesLookupKey = "AllModulesLookupKey";
        public static string GSTStatusKey = "GSTStatusKey";
        public static string CommercialPaymentMethodKey = "CommercialPaymentMethodKey";
        public static string SubsidyCalculationMethodKey = "SubsidyCalculationMethodKey";
        public static string FPRentalModesKey = "FPRentalModesKey";
        public static string FPSubsidyTypeKey = "FPSubsidyTypeKey";
        public static string PeriodRateConversionMethodKey = "PeriodRateConversionMethodKey";
        public static string RVCalculationTypeKey = "RVCalculationTypeKey";
        public static string ETAllowedAfterKey = "ETAllowedAfterKey";
        public static string ETPaneltyAmountKey = "ETPaneltyAmountKey";
        public static string RoundingTypeKey = "RoundingTypeKey";
        public static string MiscReceiptActionsKey = "MiscReceiptActionsKey";
        public static string GSTapplicableonRVKey = "GSTapplicableonRVKey";
        public static string OverDueInterstRateMethodKey = "OverDueInterstRateMethodKey";
        public static string RVBaloonApplicableKey = "RVBaloonApplicableKey";
        public static string IRRCalculationMethodKey = "IRRCalculationMethodKey";
        public static string RentalTypesKey = "RentalTypesKey";
        public static string CommissionCalwBackPriorityKey = "CommissionCalwBackPriorityKey";
        public static string DecimalPercisionKey = "DecimalPercisionKey";
        public static string SuspenceReversalKey = "SuspenceReversalKey";
        public static string OwnerTypeKey = "OwnerTypeKeyLookup";
        public static string CommissionClawBackFrmKey = "CommissionClawBackFrmKeyLookup";
        public static string CommissionAmortizationMethodKey = "CommissionAmortizationMethodKeyLookup";
        public static string BindDaysinYearKey = "BindDaysinYearKeyLookup";
        public static string LatePaneltyTypeKey = "LatePaneltyTypeKeyLookup";
        public static string DepreciationMethodKey = "DepreciationMethodKeyLookup";
        public static string InternalAccountingKey = "InternalAccountingKeyLookup";
        public static string SecurityCalculationMethodKey = "SecurityCalculationMethodKeyLookup";
        public static string BusinessRuleObjectskey = "BusinessRuleObjectsLookup";
        public static string ChartsHeaderKey = "CHRT_HEDRInfo";
        public static string MarginTypeCodeKey = "MRGN_TYPE_CODEInfo";
        public static string BusinessRuleObjectsSelectedKey = "BusinessRuleObjectsSelectedLookup";
        public static string BusinessRulesModelsKey = "BusinessRulesModelsLookup";
        public static string SubsidyModelsKey = "SubsidyModelsLookup";
        public static string EventeCodeKey = "EventcodeLookup";
        public static string AmountCodeKey = "AmountCodeLookup";
        public static string AccountCodeKey = "AccountCodeLookup";
        public static string AccountingSystemKey = "AccountingSystemLookup";
        public static string ChartHeaderNamesKey = "ChartHeaderNamesKeyLookup";

        public static string WKFTableType = "WKFTableSQLType";
        public static string CultureLanguageCodeKey = "CultureLanguageKeyLookup";
        public static string CompanyApplicationLookupKey = "CompanyApplicationLookupKey";
        public static string GenAccountTypeLookupKey = "GenAccountTypeLookupKey";
        public static string GenAccountsLookupKey = "GenAccountsLookupKey";
        public static string AllAssetCodeInfo = "ASSET_MAIN_CODEInfo";
        public static string DocumentTypeCodeInfo = "DOCT_TYPE_CODEInfo";
        public static string POSCONFIGURATIONKey = "POSCONFIGURATIONLookupKey";
        public static string REQUIREDFORKey = "REQUIREDFORLookupKey";
        public static string DocGroup = "DTS_GRUP_CODEInfo";
        public static string DocCodeGroup = "DTS_DOCT_GRUPInfo";
        public static string NATIONALITY_CODEKey = "NATY_CODEInfo";
        public static string FINANCIALDETAILSKey = "FINANCIALDETAILSLookupKey";
        public static string ValueClassificationKey = "ValueClassificationKey";
        public static string VALU_CLAS_CODEInfo = "VALU_CLAS_CODEInfo";
        public static string ROLE_CCODEInfo = "ROLE_CCODEInfo";
        public static string SERV_TYPE_CODEInfo = "SERV_TYPE_CODEInfo";
        public static string ServiceSelectionTypekey = "ServiceSelectionTypekey";
        public static string FPServiceGroupTypeKey = "FPServiceGroupTypeKey";
        public static string EncumbranceStatusKey = "EncumbranceStatusLookupKey";
        public static string AllModulesStatusKey = "AllModulesStatusKey";
        public static string DTS_StatusTypeKey = "DTS_StatusTypeKey";
        public static string RatingCodeLookupKey = "RatingCodeKey";
        public static string BusinessRuleTypeKey = "BusinessRuleTypeLookup";
        public static string TempalteGEOTypeKey = "TempalteGEOTypeLookup";
        public static string CollateralSubTypes = "CollateralSubTypes";
        public static string VotingCmteRole = "VotingCmteRole";
        public static string VotingCmteStatus = "VotingCmteStatus";
        public static string CashflowTypeKey = "CashflowTypeKey";
        public static string MothTypeLookupKey = "MonthTypeLookupKey";
        public static string DecisionType = "DecisionType";
        public static string CollateralTypesKey = "CollateralTypesLookup";
        public static string AllSubsidariesKey = "AllSubsidariesKey";
        public static string RaceCodeKey = "RaceCodeLookup";
        public static string PropertyClassificationKey = "PropertyClassificationKey";
        public static string InOutypeLookupKey = "InOutypeLookupKey";
        public static string StorageTypeLookupKey = "StorageTypeLookupKey";
        public static string CustomerServiceLookupKey = "CustomerServiceLookupKey";


        public static string IDIssuePlaceLookupKey = "IDIssuePlaceKey";
        public static string CreditLineAmountTypeLookupKey = "CreditLineAmountTypeKey";
        public static string ReferenceTypeLookupKey = "ReferenceTypeKey";
        public static string EducationLocationLookupKey = "EducationLocationKey";
        public static string ImmovablePropertyTypeLookupKey = "ImmovablePropertyTypeLookupKey";
        public static string CreditLineTypeLookupKey = "CreditLineTypeKey";
        public static string ApplicatEducationLookupKey = "ApplicatEducationTypeKey";
        public static string InterestTypesKey = "InterestTypesKey";
        public static string VatTypesKey = "VatTypesKey";
        public static string LoanClassification = "LoanClassification";
        public static string BaseRateChartsKey = "BaseRateChartsKey";

        #endregion

        # region Lookup ReWrittenKeys
        public static string SRCH_COLM_TYPE_CODEInfo = "SRCH_COLM_TYPE_CODEInfo";
        public static string ITEM_SRCEInfo = "ITEM_SRCEInfo";

        public static string LN_INTR_CTGY_CODEInfo = "LN_INTR_CTGY_CODEInfo";
        public static string MDUL_STUS_CODEInfo = "MDUL_STUS_CODEInfo";
        public static string SRCH_TYPE_CODEInfo = "SRCH_TYPE_CODEInfo";
        public static string PRPL_TYPE_CODEInfo = "PRPL_TYPE_CODEInfo";
        public static string APLT_CODE_TYPEInfo = "APLT_CODE_TYPEInfo";
        public static string REQT_TYPE_CODEInfo = "REQT_TYPE_CODEInfo";
        public static string RESE_TYPE_CODEInfo = "RESE_TYPE_CODEInfo";
        public static string RCPT_CMPT_TPLEInfo = "RCPT_CMPT_TPLEInfo";
        public static string PRSG_DAYInfo = "PRSG_DAYInfo";
        public static string HLDY_MAINInfo = "HLDY_MAINInfo";
        public static string RCPT_TPLEInfo = "RCPT_TPLEInfo";
        public static string APPN_STUSInfo = "APPN_STUSInfo";
        public static string FINL_PRMT_MAINInfo = "FINL_PRMT_MAINInfo";
        public static string LANG_CODEInfo = "LANG_CODEInfo";
        public static string COMY_CNFGInfo = "COMY_CNFGInfo";
        public static string USER_GRUP_CODEInfo = "USER_GRUP_CODEInfo";
        public static string BP_SYS_USERInfo = "BP_SYS_USERInfo";
        public static string USER_TEAM_HRCYInfo = "USER_TEAM_HRCYInfo";
        public static string PASW_PLCY_CODEInfo = "PASW_PLCY_CODEInfo";
        public static string ET_MTHD_CODEInfo = "ET_MTHD_CODEInfo";
        public static string ID_TYPE_CODEInfo = "ID_TYPE_CODEInfo";
        public static string ADDS_TPLE_CODEInfo = "ADDS_TPLE_CODEInfo";
        public static string APPN_CODEInfo = "APPN_CODEInfo";
        public static string USER_RLSP_TYPE_CODE = "USER_RLSP_TYPE_CODEInfo";
        public static string ACTV_DRTY_CNFG = "ACTV_DRTY_CNFGInfo";
        public static string SRCH_JOIN_CLSEInfo = "SRCH_JOIN_CLSEInfo";
        public static string VHCL_PLTE_TYPE_CODEInfo = "VHCL_PLTE_TYPE_CODEInfo";
        public static string VHCL_TRMN_TYPE_CODEInfo = "VHCL_TRMN_TYPE_CODEInfo";
        public static string COLN_ACTY_CODEInfo = "COLN_ACTY_CODEInfo";
        public static string ET_CNFG_TPLEInfo = "ET_CNFG_TPLEInfo";
        public static string COLN_CNCT_CODEInfo = "COLN_CNCT_CODEInfo";
        public static string COLN_BP_CODEInfo = "COLN_BP_CODEInfo";
        public static string RESN_CODEInfo = "RESN_CODEInfo";
        public static string WKF_TABLInfo = "WKF_TABLInfo";
        public static string FNCN_SRCEInfo = "FNCN_SRCEInfo";
        public static string CNFG_STLT_TPLEInfo = "CNFG_STLT_TPLEInfo";
        public static string SRCH_TYPE_WHRE_CLUSInfo = "SRCH_TYPE_WHRE_CLUSInfo";
        public static string BSNS_RULEInfo = "BSNS_RULEInfo";
        public static string OPTR_SRCEInfo = "OPTR_SRCEInfo";
        public static string BR_OPTRInfo = "BR_OPTRInfo";
        public static string BR_OPTR_DTInfo = "BR_OPTR_DTInfo";
        public static string CNFG_TPLEInfo = "CNFG_TPLEInfo";
        public static string CNFG_ATCHInfo = "CNFG_ATCHInfo";
        public static string FINE_TYPE_CODEInfo = "FINE_TYPE_CODEInfo";
        public static string MODL_TYPE_CODEInfo = "MODL_TYPE_CODEInfo";
        public static string RULE_GRUPInfo = "RULE_GRUPInfo";
        public static string RULE_GRUP_DETLInfo = "RULE_GRUP_DETLInfo";
        public static string BASE_RATE_SRCE_CODEInfo = "BASE_RATE_SRCE_CODEInfo";
        public static string CHRT_HEDRInfo = "CHRT_HEDRInfo";
        public static string MDUL_CODEInfo = "MDUL_CODEInfo";
        public static string MRGN_TYPE_CODEInfo = "MRGN_TYPE_CODEInfo";
        public static string BSNS_RULE_OBJTInfo = "BSNS_RULE_OBJTInfo";
        public static string BSNS_RULE_MODLInfo = "BSNS_RULE_MODLInfo";
        public static string SBSD_MODL_CODEInfo = "SBSD_MODL_CODEInfo";
        public static string CMS_GL_EVNT_CODEInfo = "CMS_GL_EVNT_CODEInfo";
        public static string CMS_GL_AMNT_CODEInfo = "CMS_GL_AMNT_CODEInfo";
        public static string GL_ACCT_CODEInfo = "GL_ACCT_CODEInfo";
        public static string CMS_GL_SYSM_CODEInfo = " CMS_GL_SYSM_CODEInfo";
        public static string DOCT_TYPE_CODEInfo = "DOCT_TYPE_CODEInfo";
        public static string POS_CONFIGURATIONInfo = "POS_CONFIGURATIONInfo";
        public static string REQD_FORInfo = "REQD_FORInfo";
        public static string DTS_GRUP_CODEInfo = "DTS_GRUP_CODEInfo";
        public static string NATY_CODEInfo = "NATY_CODEInfo";
        public static string FINL_DETLInfo = "FINL_DETLInfo";
        public static string APPN_RTNG_CODEInfo = "APPN_RTNG_CODEInfo";
        public static string RACE_CODEInfo = "RACE_CODEInfo";
        public static string ID_ISUE_PLCEInfo = "ID_ISUE_PLCEInfo";
        public static string CRDT_LINE_AMNT_TYPEInfo = "CRDT_LINE_AMNT_TYPEInfo";
        public static string RFRN_TYPEInfo = "RFRN_TYPEInfo";
        public static string EDUN_LOCNInfo = "EDUN_LOCNInfo";
        public static string IMBL_PRPY_TYPEInfo = "IMBL_PRPY_TYPEInfo";
        public static string CRDT_LINE_TYPE_CODEInfo = "CRDT_LINE_TYPE_CODEInfo";
        public static string CRDT_LINE_CLAS_CODEInfo = "CRDT_LINE_CLAS_CODEInfo";
        public static string APLT_EDUN_CODEInfo = "APLT_EDUN_CODEInfo";
        public static string EVNT_BASE_CHRG_ENTITY = "EVNT_BASE_CHRG_ENTITY";
        # endregion

        #region Helper Methods
        public static string CreateRelatedKey(string CacheKey, string PostFix)
        {
            ///If Cache Key  is TITLE_CODEINFO
            ///PostFix is Sub
            ///Desired Output is TITLE_CODEInfo-Sub
            return CacheKey + KeySpliter + PostFix;
        }
        public static string CreateRelatedKey(string CacheKey, Hashtable keys)
        {
            string m_CaheKey = CacheKey;
            if (keys.Count > 0)
            {
                m_CaheKey += KeySpliter;
                foreach (DictionaryEntry entry in keys)
                {
                    m_CaheKey += entry.Key.ToString() + ValueSpliter + entry.Value.ToString();
                }
            }
            return m_CaheKey;
        }
        public static string CreateRelatedKey(string CacheKey, List<string> keysList)
        {
            string m_CaheKey = CacheKey;
            if (keysList.Count > 0)
            {
                m_CaheKey += KeySpliter;
                foreach (string entry in keysList)
                {
                    m_CaheKey += entry + KeySpliter;
                }
                //if in the end there is extra KeySpliter than remove it
                if (m_CaheKey.LastIndexOf(KeySpliter) == m_CaheKey.Length - 1)
                {
                    m_CaheKey = m_CaheKey.Substring(0, m_CaheKey.Length - 1);
                }
            }
            return m_CaheKey;
        }
        public static string CreateRelatedKey(string CacheKey, string key, Hashtable keys)
        {

            string m_CaheKey = CacheKey + KeySpliter + key;
            if (keys.Count > 0)
            {
                m_CaheKey += KeySpliter;
                foreach (DictionaryEntry entry in keys)
                {
                    if (entry.Key != null && entry.Value != null)
                    {
                        m_CaheKey += entry.Key.ToString() + ValueSpliter + entry.Value.ToString();
                    }
                    m_CaheKey += KeySpliter;
                }
                //if in the end there is extra KeySpliter than remove it
                if (m_CaheKey.LastIndexOf(KeySpliter) == m_CaheKey.Length - 1)
                {
                    m_CaheKey = m_CaheKey.Substring(0, m_CaheKey.Length - 1);
                }
            }
            return m_CaheKey;

        }

        // public static List<string> GetRelatedKeys(string CacheKey, List<string>
        #endregion

        #region Newly Added

        public static string FINE_MTRX_TYPE_CODEInfo = "FINE_MTRX_TYPE_CODEInfo";
        public static string MDUL_REQT_TYPEInfo = "MDUL_REQT_TYPEInfo";
        public static string NTFY_ROLE_ASCTInfo = "NTFY_ROLE_ASCTInfo";
        public static string COMYInfo = "COMYInfo";
        public static string YEAR_CODEInfo = "YEAR_CODEInfo";
        public static string STUS_CODEInfo = "STUS_CODEInfo";
        public static string CMS_GL_SYSTEM_CODEInfo = "CMS_GL_SYSTEM_CODEInfo";
        public static string APPN_ACESInfo = "APPN_ACESInfo";
        public static string CMS_GL_GEN_ACCT_TYPEInfo = "CMS_GL_GEN_ACCT_TYPEInfo";
        public static string CMS_GL_GEN_ACCTInfo = "CMS_GL_GEN_ACCTInfo";
        public static string ASET_MAINInfo = "ASET_MAINInfo";
        public static string FINL_CMPT_TPLE_ASOCInfo = "FINL_CMPT_TPLE_ASOCInfo";
        #endregion

        #region Entities Keys
        public static string BusinessRuleObjectsItem = "BusinessRuleObjectsItem";
        #endregion

        public static string BSNS_RULE_MODL_MAINInfo = "BSNS_RULE_MODL_MAINInfo";
        public const string ModelsKey = "ModelsLookupKey";
        public const string ActionsKey = "ActionLookupKey";
        public const string RulesKey = "RulesLookupKey";
        public const string ActionCodesKey = "ActionCodesLookupKey";
        public const string DIRY_SUBCInfo = "DIRY_SUBCInfo";
        public static string VRFN_CODEInfo = "VRFN_CODEInfo";
        
        public static string REGN_SRCEInfo = "REGN_SRCEInfo";
        public static string REGN_TYPEInfo = "REGN_TYPEInfo";
        public static string MDUL_RESN_ASSNInfo = "MDUL_RESN_ASSNInfo";
        public static string CheckListEnum = "CheckListEnum";
        public static string CRCY_RATE_CHRT_DETLInfo = "CRCY_RATE_CHRT_DETLInfo";
        public static string LN_PLAN_TYPE_CODEInfo = "LN_PLAN_TYPE_CODEInfo";

        public static string ASET_MODL_DETLInfo = "ASET_MODL_DETLInfo";
        public static string ASET_MODL_YEAR_CODEInfo = "ASET_MODL_YEAR_CODEInfo";

        public static string CLOR_TYPE_CODEInfo = "CLOR_TYPE_CODEInfo";
        public static string DPRN_TYPE_CODEInfo = "DPRN_TYPE_CODEInfo";


        public static string BP_GRUP_TYPE_CODEInfo = "BP_GRUP_TYPE_CODEInfo";
        public static string STLT_SRCE_CODEInfo = "STLT_SRCE_CODEInfo";
        public static string ADIT_EXCP_CODEInfo = "ADIT_EXCP_CODEInfo";
        public static string ADIT_CLAS_CODEInfo = "ADIT_CLAS_CODEInfo";

        public static string INTR_STRT_FROM_CODEInfo = "INTR_STRT_FROM_CODEInfo";
        public static string ADDS_STUS_TYPE_CODEInfo = "ADDS_STUS_TYPE_CODEInfo";
        public static string ACCY_OPTN_TYPE_CODEInfo = "ACCY_OPTN_TYPE_CODEInfo";
        public static string CDTN_TYPE_CODEInfo = "CDTN_TYPE_CODEInfo";
        public static string INVC_DLRY_TO_CODEInfo = "INVC_DLRY_TO_CODEInfo";
        public static string EXCP_TYPE_CODEInfo = "EXCP_TYPE_CODEInfo";
        public static string USGE_MODE_CODEInfo = "USGE_MODE_CODEInfo";
        public static string ADJT_TYPE_CODEInfo = "ADJT_TYPE_CODEInfo";
        public static string ADIT_CLAS_TYPE_CODEInfo = "ADIT_CLAS_TYPE_CODEInfo";

        public static string WKF_ENTY_MAPInfo = "WKF_ENTY_MAPInfo";
        public static string CRDT_TYPE_CODEInfoKey = "CRDT_TYPE_CODEInfoKey";
        public static string GEO_TPLE_MAININFOKey = "GEO_TPLE_MAININFOKey";
        public static string CHRG_TYPE_CODEInfoKey = "CHRG_TYPE_CODEInfoKey";
        public static string STNR_CLAS_TYPE_CODEInfoKey = "STNR_CLAS_TYPE_CODEInfoKey";
        public static string BP_ADDSInfoKey = "BP_ADDSInfoKey";
        public static string RCPT_JRNL_TYPE_CODEInfo = "RCPT_JRNL_TYPE_CODEInfo";
        public static string ADVR_SRCE_CODEInfoKey = "ADVR_SRCE_CODEInfoKey";
        public static string FINE_SRCE_CODEInfoKey = "FINE_SRCE_CODEInfoKey";
        public static string UserControlSecurityKey = "UserControlSecurityKey";
        public static string MandatorySecurityKey = "MandatorySecurityKey";
        public static string LocalizedControlsKey = "LocalizedControlsKey";
        public static string SRCH_TYPE_GRUP_CLUSInfoKey = "SRCH_TYPE_GRUP_CLUSInfoKey";
        public static string SRCH_TYPE_HAVG_CLUSInfoKey = "SRCH_TYPE_HAVG_CLUSInfoKey";
        public static string ProductTypeKey = "ProductTypeKey";
        public static string ComparisonTypeKey = "ComparisonTypeKey";
        public static string ExecutionTypeKey = "ExecutionTypeKey";
        public static string RPRT_CTGY_CODEInfoKey = "RPRT_CTGY_CODEInfoKey";

        public static string ADIT_CKLT_CODEInfoKey = "ADIT_CKLT_CODEInfoKey";
        public static string TemplateInfoKey = "TemplateInfoKey";
        public static string StationaryTemplateInfoKey = "StationaryTemplateInfoKey";

        public static string CMS_GL_EVNT_CODEInfoKey = "CMS_GL_EVNT_CODEInfoKey";
        public static string CONT_ADDSInfo = "CONT_ADDSInfo";
        //public static string CHRT_PRTY_CODEInfo = "CHRT_PRTY_CODEInfo";
        public static string RESE_CODEInfo = "RESE_CODEInfo";
        public static string REQT_STUS_CMPTInfo = "REQT_STUS_CMPTInfo";
        public static string FIX_VRBL_TYP_CODEInfo = "FIX_VRBL_TYP_CODEInfo";
        public static string RVSN_FRQY_CODEInfo = "RVSN_FRQY_CODEInfo";
        public static string RNTL_CALC_MTHD_CODEInfo = "RNTL_CALC_MTHD_CODEInfo";
        public static string RATE_CNVN_MTHD_CODEInfo = "RATE_CNVN_MTHD_CODEInfo";
        public static string AMRT_MTHD_CODEInfo = "AMRT_MTHD_CODEInfo";
        public static string RV_AMNT_TYP_CODEInfo = "RV_AMNT_TYP_CODEInfo";
        public static string CHRG_AMRT_MTHD_CODEInfo = "CHRG_AMRT_MTHD_CODEInfo";
        public static string ITNL_ACCT_MTHD_CODEInfo = "ITNL_ACCT_MTHD_CODEInfo";
        public static string SBDR_AMRT_MTHD_CODEInfo = "SBDR_AMRT_MTHD_CODEInfo";
        public static string SBDR_TYPE_CODEInfo = "SBDR_TYPE_CODEInfo";
        public static string SBSD_TYPE_CODEInfo = "SBSR_TYPE_CODEInfo";
        public static string SBSD_AMRT_MTHD_CODEInfo = "SBSD_AMRT_MTHD_CODEInfo";


        public static string AMNT_CMPT_PBLE_ASSNInfo = "AMNT_CMPT_PBLE_ASSNInfo";
        public static string TAX_RV_APBL_CODEInfo = "TAX_RV_APBL_CODEInfo";
        public static string ASET_MODL_ACCYInfo = "ASET_MODL_ACCYInfo";
        public static string AuctionerTypeKey = "AuctionerTypeKey";
        public static string USGE_TYPE_CODEInfo = "USGE_TYPE_CODEInfo";
        public static string STLT_MODL_CODEInfo = "STLT_MODL_CODEInfo";
        public static string ACNR_TYPE_CODEInfo = "ACNR_TYPE_CODEInfo";
        public static string TAX_INCL_EXCL_CODEInfo = "TAX_INCL_EXCL_CODEInfo";
        public static string ET_ALWD_AFTR_CODEInfo = "ET_ALWD_AFTR_CODEInfo";
        public static string COMM_CLBK_PRTY_CODEInfo = "COMM_CLBK_PRTY_CODEInfo";
        public static string ET_PNTY_AMNT_CODEInfo = "ET_PNTY_AMNT_CODEInfo";
        public static string ET_PNTY_BSIS_CODEInfo = "ET_PNTY_BSIS_CODEInfo";
        public static string COMM_CLBK_FROM_CODEInfo = "COMM_CLBK_FROM_CODEInfo";
        public static string COMM_CLBK_TO_CODEInfo = "COMM_CLBK_TO_CODEInfo";
        public static string LATE_PYMT_PNTY_CODEInfo = "LATE_PYMT_PNTY_CODEInfo";
        public static string COMM_AMRT_MTHD_CODEInfo = "COMM_AMRT_MTHD_CODEInfo";
        public static string STLT_MTHD_CODEInfo = "STLT_MTHD_CODEInfo";
        public static string OVER_PYMT_ADJT_CODEInfo = "OVER_PYMT_ADJT_CODEInfo";
        public static string ASET_CLOR_CODEInfoKey = "ASET_CLOR_CODEInfo";
        public static string ROLE_CODEInfoKey = "ROLE_CODEInfoKey";
        public static string ROLE_CODE_DETLInfoKey = "ROLE_CODE_DETLInfoKey";
        public static string DEPT_TYPE_CODEInfo = "DEPT_TYPE_CODEInfo";
        public static string CNCT_PRSN_TYPE_CODEInfo = "CNCT_PRSN_TYPE_CODEInfo";

        public static string AMNT_CMPT_CNFG_DETLInfo = "AMNT_CMPT_CNFG_DETLInfo";
        public static string AMNT_CLAS_CODEInfo = "AMNT_CLAS_CODEInfo";
        public static string AMNT_TYPE_CODEInfo = "AMNT_TYPE_CODEInfo";
        public static string AMNT_FINL_CMPT_MAPGInfo = "AMNT_FINL_CMPT_MAPGInfo";

        public static string ENCB_STUS_CODEInfo = "ENCB_STUS_CODEInfo";
        public static string ADDS_STUS_CODEInfo = "ADDS_STUS_CODEInfo";
        public static string MNTH_TYPE_CODEInfo = "MNTH_TYPE_CODEInfo";
        public static string TAX_APPN_STUS_CODEInfo = "TAX_APPN_STUS_CODEInfo";
        public static string REQT_OPIN_CODEInfo = "REQT_OPIN_CODEInfo";
        public static string PRTY_CODEInfo = "PRTY_CODEInfo";
        public static string DTS_STUS_TYPE_CODEInfo = "DTS_STUS_TYPE_CODEInfo";
        public static string DCSN_TYPE_CODEInfo = "DCSN_TYPE_CODEInfo";
        public static string CSFL_TYPE_CODEInfo = "CSFL_TYPE_CODEInfo";

        public static string ROLE_CODE_INDVKey = "ROLE_CODE_INDVKey";
        public static string ROLE_CODE_COMPKey = "ROLE_CODE_COMPKey";
        public static string BSNS_NTRE_CODEInfo = "BSNS_NTRE_CODEInfo";
        public static string RNTL_TYPE_CODEInfo = "RNTL_TYPE_CODEInfo";
        public static string AUDT_CHCK_LIST_CODEInfo = "AUDT_CHCK_LIST_CODEInfo";

        public static string VTNG_CMTE_ROLE_CODEInfo = "VTNG_CMTE_ROLE_CODEInfo";
        public static string VTNG_CMTE_STUS_CODEInfo = "VTNG_CMTE_STUS_CODEInfo";
        public static string CAUN_MARK_TYPE_CODEInfo = "CAUN_MARK_TYPE_CODEInfo";
        public static string CMPN_TYPE_CODEInfo = "CMPN_TYPE_CODEInfo";
        public static string EXEC_TYPE_CODEInfo = "EXEC_TYPE_CODEInfo";
        public static string BSNS_RULE_TYPE_CODEInfo = "BSNS_RULE_TYPE_CODEInfo";
        public static string BP_MTCH_CRTAInfo = "BP_MTCH_CRTAInfo";

        public static string TMPL_CNFGInfo = "TMPL_CNFGInfo";
        public static string LOAN_CLAS_CODEInfo = "LOAN_CLAS_CODEInfo";
        public static string PRVN_TYPE_CODEInfo = "PRVN_TYPE_CODEInfo";
        public static string STNR_TYPE_CODEInfo = "STNR_TYPE_CODEInfo";
        public static string CHRG_CNFG_DETLInfo = "CHRG_CNFG_DETLInfo";
        public static string PBLE_TYPE_CNFGInfo = "PBLE_TYPE_CNFGInfo";
        public static string PYMT_TYPE_CODEInfo = "PYMT_TYPE_CODEInfo";
        public static string PYMT_PRPS_CODEInfo = "PYMT_PRPS_CODEInfo";
            
        public static string STRT_NMBR_CNFG_CODEInfo = "STRT_NMBR_CNFG_CODEInfo";

        public static string CMS_GL_EVNT_ASSNInfo = "CMS_GL_EVNT_ASSNInfo";

        public static string GEO_EVNT_CMPT_CODEInfo = "GEO_EVNT_CMPT_CODEInfo";

        public static string CRTE_TYPE_CODEInfo = "CRTE_TYPE_CODEInfo";
        public static string CHKL_TYPE_CODEInfo = "CHKL_TYPE_CODEInfo";
        public static string DPRN_CALC_TYPEInfo = "DPRN_CALC_TYPEInfo";

        public static string DPRN_TAX_CNFGInfo = "DPRN_TAX_CNFGInfo";
        public static string DPRN_CALC_BSISInfo = "DPRN_CALC_BSISInfo";
        public static string DPRN_CALC_MTHDInfo = "DPRN_CALC_MTHDInfo";
        //;public static string DPRN_CALC_TYPEInfo = "DPRN_CALC_TYPEInfo";
        public static string DPRN_AMNT_CALC_CNFGInfo = "DPRN_AMNT_CALC_CNFGInfo";
        public static string DPRN_AMNT_CNFGInfo = "DPRN_AMNT_CNFGInfo";
        public static string DPRN_TERM_CNFGInfo = "DPRN_TERM_CNFGInfo";
        public static string DPRN_LMIT_CNFGInfo = "DPRN_LMIT_CNFGInfo";
        public static string DPRN_STOP_CNFGInfo = "DPRN_STOP_CNFGInfo";
        public static string BP_RLSPInfo = "BP_RLSPInfo";
        public static string DPRN_ASET_SBTP_CNFGInfo = "DPRN_ASET_SBTP_CNFGInfo";
        public static string TAX_TYPE_CODEInfo = "TAX_TYPE_CODEInfo";
        public static string TAX_TYPE_CODE_All = "TAX_TYPE_CODE_All";

        public static string TAX_AMNT_CMPT_ASSNInfo = "TAX_AMNT_CMPT_ASSNInfo";
        public static string TAX_CHRG_CMPT_ASSNInfo = "TAX_CHRG_CMPT_ASSNInfo";
        public static string TAX_PBLE_CMPT_ASSNInfo = "TAX_PBLE_CMPT_ASSNInfo";
        public static string GRCE_PRDE_TYPE_CODEInfo = "GRCE_PRDE_TYPE_CODEInfo";
        public static string RMTN_TYPE_CODEInfo = "RMTN_TYPE_CODEInfo";
        public static string TRMN_TYPE_CODEInfo = "TRMN_TYPE_CODEInfo";

        public static string InterfaceTypeKey = "InterfaceTypeKey";
        public static string REGD_ADDR_PRTY_CODEInfo = "REGD_ADDR_PRTY_CODEInfo";
        public static string ReasonTypesKey = "ReasonTypesKey";
        public static string WriteOffTypeKey = "WriteOffTypeKey";
        public static string FreeInsuranceKey = "FreeInsuranceKey";
        public static string InsuranceYearKey = "InsuranceYearKey";
        public static string InsuranceMethodKey = "InsuranceMethodKey";

        public static string InsuranceHandlingKey = "InsuranceHandlingKey";
        public static string ParameterWindowTypeKey = "ParameterWindowTypeKey";
        public static string TAX_CALC_TYPE_CODEInfo = "TAX_CALC_TYPE_CODEInfo";
        public static string TAX_OPTR_CODEInfo = "TAX_OPTR_CODEInfo";
        public static string ADTR_TYPE_CODEInfo = "ADTR_TYPE_CODEInfo";
        public static string EVNT_NTFY_BSNS_RULEInfo = "EVNT_NTFY_BSNS_RULEInfo";
        public static string ASSET_MODEL_YEAR = "ASSET_MODEL_YEARInfo";
        public static string DATE_FRMT_CODEInfo = "DATE_FRMT_CODEInfo";
        public static string CMPT_DCSN_CODEInfo = "CMPT_DCSN_CODEInfo";

        public static string FRMA_TYPE_CODEInfo = "FRMA_TYPE_CODEInfo";

        public static string INTR_BILG_CODEInfo = "INTR_BILG_CODEInfo";

        public static string PNLT_CALC_CODEInfo = "PNLT_CALC_CODEInfo";

        public static string PNLT_CALC_AMNT_CODEInfo = "PNLT_CALC_AMNT_CODEInfo";

        public static string OFST_TYPE_CODEInfo = "OFST_TYPE_CODEInfo";

        public static string OFST_FROM_CODEInfo = "OFST_FROM_CODEInfo";

        public static string RBAT_CALC_MTHD_CODEInfo = "RBAT_CALC_MTHD_CODEInfo";

        public static string CRDT_VLDT_TYPEInfo = "CRDT_VLDT_TYPEInfo";
        
        public static string OFST_DAY_TYPE_CODEInfo = "OFST_DAY_TYPE_CODEInfo";

        public static string INVC_SRES_CODEInfo = "INVC_SRES_CODEInfo";

        public static string INTR_RATE_BSIS_CODEInfo = "INTR_RATE_BSIS_CODEInfo";

        public static string GRCE_PERD_CODEInfo = "GRCE_PERD_CODEInfo";

        public static string DELR_INTR_BSIS_CODEInfo = "DELR_INTR_BSIS_CODEInfo";

        public static string CURT_BILG_CODEInfo = "CURT_BILG_CODEInfo";

        public static string CRDT_VRFN_BSIS_CODEInfo = "CRDT_VRFN_BSIS_CODEInfo";

        public static string CRDT_UTLZ_BSIS_CODEInfo = "CRDT_UTLZ_BSIS_CODEInfo";

        public static string CRDT_TRCK_BSIS_CODEInfo = "CRDT_TRCK_BSIS_CODEInfo";

        public static string CRDT_CRCY_BSIS_CODEInfo = "CRDT_CRCY_BSIS_CODEInfo";

        public static string CRDT_ASET_BSIS_CODEInfo = "CRDT_ASET_BSIS_CODEInfo";

        public static string CALC_AMNT_CODEInfo = "CALC_AMNT_CODEInfo";

        public static string PNLT_RATE_BSIS_CODEInfo = "PNLT_RATE_BSIS_CODEInfo";

        public static string PRAM_TYPE_CODEInfo = "PRAM_TYPE_CODEInfo";

        public static string PRCL_BILG_CODEInfo = "PRCL_BILG_CODEInfo";

        public static string RBAT_BILG_CODEInfo = "RBAT_BILG_CODEInfo";

        public static string RBAT_TYPE_CODEInfo = "RBAT_TYPE_CODEInfo";

        public static string RECL_OPTN_CODEInfo = "RECL_OPTN_CODEInfo";

        public static string PNLT_CALC_OPTN_CODEInfo = "PNLT_CALC_OPTN_CODEInfo";
        
        public static string PNLT_CALC_OPTN_CODE_MLInfo = "PNLT_CALC_OPTN_CODE_MLInfo";

        public static string REQT_IMPR_CODEInfo = "REQT_IMPR_CODEInfo";

        public static string LOAN_BSIS_CODEInfo = "LOAN_BSIS_CODEInfo";

        public static string CALC_DSPL_FEE_CODEInfo = "CALC_DSPL_FEE_CODEInfo";

        public static string TPLE_AMNT_CMPTInfo = "TPLE_AMNT_CMPTInfo";

        public static string LN_RCBL_PAIDInfo = "LN_RCBL_PAIDInfo";

        public static string ARTE_TYPE_CODEInfo = "ARTE_TYPE_CODEInfo";

        public static string RBAT_CTGY_CODEInfo = "RBAT_CTGY_CODEInfo";

        public static string EVNT_CODEInfo = "EVNT_CODEInfo";

        public static string EVNT_TYPE_CODEInfo = "EVNT_TYPE_CODEInfo";

        public static string GL_AMNT_CODEInfo = "GL_AMNT_CODEInfo";

        public static string GL_EVNT_ASSNInfo = "GL_EVNT_ASSNInfo";

        //IntHub
        public static string IH_GL_EVNT_ASSNInfo = "IH_GL_EVNT_ASSNInfo";
        public static string IH_MESG_FLOWInfo = "IH_MESG_FLOWInfo";
        public static string IH_POLG_CNFGInfo = "IH_POLG_CNFGInfo";
        public static string IH_MainEventKey = "IH_MainEventKey";
        public static string IH_AllEventKey = "IH_AllEventKey";
        
        //
        public static string GL_GEN_ACCT_TYPEInfo = "GL_GEN_ACCT_TYPEInfo";

        public static string GL_GEN_ACCTInfo = "GL_GEN_ACCTInfo";

        public static string GL_SYSM_CODEInfo = "GL_SYSM_CODEInfo";

        public static string GL_ACCT_ETNL_CODEInfo = "GL_ACCT_ETNL_CODEInfo";

        public static string BP_CHRTInfo = "BP_CHRTInfo";

        public static string GL_ACCT_ITNL_CODEInfo = "GL_ACCT_ITNL_CODEInfo";
        public static string BP_GL_ACCT_ITNL_CODEInfo = "BP_GL_ACCT_ITNL_CODEInfo";

        public static string LN_CHRG_CNFGInfo = "LN_CHRG_CNFGInfo";

        public static string ITFC_BPInfo = "ITFC_BPInfo";
        public static string DFLT_ASET_CLASInfo = "DFLT_ASET_CLASInfo";
        public static string ADIT_TYPE_CODEInfo = "ADIT_TYPE_CODEInfo";
        public static string CHRG_CLAS_CODEInfo = "CHRG_CLAS_CODEInfo";
        public static string CHRG_CALC_BSIS_CODEInfo = "CHRG_CALC_BSIS_CODEInfo";
        public static string CHRG_CALC_MTHD_CODEInfo = "CHRG_CALC_MTHD_CODEInfo";
        public static string CHRG_DUE_CODEInfo = "CHRG_DUE_CODEInfo";
        public static string VHCL_STYL_TYPE_CODEInfo = "VHCL_STYL_TYPE_CODEInfo";
        public static string USER_GRUP_ASSNInfo = "USER_GRUP_ASSNInfo";

        public static string LN_TERM_CODEInfo = "LN_TERM_CODEInfo";
        public static string STRT_NMBR_CNFG_DETLInfo = "STRT_NMBR_CNFG_DETLInfo";
        public static string STRT_NMBR_CMPT_ABVNInfo = "STRT_NMBR_CMPT_ABVNInfo";
        public static string LN_OVRD_CALC_BSIS_CODEInfo = "LN_OVRD_CALC_BSIS_CODEInfo";

        public static string DTS_MODL_DOCT_STUS = "DTS_MODL_DOCT_STUS";
        public static string LN_REQT_DETL = "LN_REQT_DETL";
        public static string RPRT_CTGY_CODEInfo = "RPRT_CTGY_CODEInfo";
        public static string ITEM_SRCE_ACCTInfo = "ITEM_SRCE_ACCTInfo";

        public static string INTR_PERD_CODEInfo = "INTR_PERD_CODEInfo";
        public static string PRSG_DATEInfo = "PRSG_DATEInfo";

        public static string NonFactoringProducts = "NonFacotingProducts";
        public static string ALCN_TYPE_CODEInfo = "ALCN_TYPE_CODEInfo";

        public static string RATE_CHRT_RVSNInfo = "RATE_CHRT_RVSNInfo";
        public static string FINE_TYPE_DPRN_DETLInfo = "FINE_TYPE_DPRN_DETLInfo";

        public static string BPM_CNFG_ATCHInfo = "BPM_CNFG_ATCHInfo";
        public static string SBSD_RCPT_CNFGInfo = "SBSD_RCPT_CNFGInfo";

        public static string CRDT_LINE_DVSN_CODEInfo = "CRDT_LINE_DVSN_CODEInfo";

        public static string PYMT_DUE_TYP_CODEInfo = "PYMT_DUE_TYP_CODEInfo";
        public static string PYMT_DUE_TYP_CODE_MLInfo = "PYMT_DUE_TYP_CODE_MLInfo";

        public static string VIR_TYPE_CODEInfo = "VIR_TYPE_CODEInfo";
        public static string CRCY_RATE_SRCE_DETLInfo = "CRCY_RATE_SRCE_DETLInfo";
        #region  Calculation
        public static string PaymentFrequencyKey = "PYMT_FREQ_CODE";
        #endregion

        #region TAX
        public static string TAX_TYPE_GEO_DETLInfo = "TAX_TYPE_GEO_DETLInfo";
        public static string TAX_RNTL_BASEInfo = "TAX_RNTL_BASEInfo";
        public static string AMNT_CMPT_ASSN_COMYInfo = "AMNT_CMPT_ASSN_COMYInfo";
        public static string TAX_CHRG_ASSN_COMYInfo = "TAX_CHRG_ASSN_COMYInfo";
        public static string TAX_PBLE_ASSN_COMYInfo = "TAX_PBLE_ASSN_COMYInfo";
        public static string GEO_TAX_TYPE_ASSNInfo = "GEO_TAX_TYPE_ASSNInfo";
        public static string BP_ADDS_CNFG_CODEInfo = "BP_ADDS_CNFG_CODEInfo";
        #endregion
        
        public static string OTO_PLIC_CTGY_CODEInfo = "OTO_PLIC_CTGY_CODEInfo";
        public static string OTO_CRDT_PURP_CODEInfo = "OTO_CRDT_PURP_CODEInfo";
        public static string OTO_RGNS_CODEInfo = "OTO_RGNS_CODEInfo";
        public static string OTO_ADDL_INSR_CODEInfo = "OTO_ADDL_INSR_CODEInfo";
        public static string OTO_AGRM_CODEInfo = "OTO_AGRM_CODEInfo";
        
       // public static string OTO_APLT_CTGY_CODEInfo = "OTO_APLT_CTGY_CODEInfo";
       //  public static string OTO_RLGN_CODEInfo = "OTO_RLGN_CODEInfo";
       // public static string OTO_DBTR_CTGY_CODEInfo = "OTO_DBTR_CTGY_CODEInfo";
       // public static string OTO_ECNM_SCTR_CODEInfo = "OTO_ECNM_SCTR_CODEInfo";
        public static string OTO_BPKB_OWNR_CODEInfo = "OTO_BPKB_OWNR_CODEInfo";
		public static string OTOInsurancePolicySrchTypeKey = "OTOInsurancePolicySrchTypeKey";
        public static string OTOLiveStatusType = "OTOLiveStatusType";
        public static string CHRG_PBLE_CNFG_DETLInfo = "CHRG_PBLE_CNFG_DETLInfo";
        public static string STUS_HRCYInfo = "STUS_HRCYInfo";
        public static string AUDT_TRAL_REQT_CNFGInfo = "AUDT_TRAL_REQT_CNFGInfo";
        public static string AUDT_TRAL_MENU_CNFGInfo = "AUDT_TRAL_MENU_CNFGInfo";

        public static string CDC_TBLE_LISTInfo = "CDC_TBLE_LISTInfo";
        public static string NGTV_INTR_CNFG_CODEInfo = "NGTV_INTR_CNFG_CODEInfo";
        public static string MDUL_CMPT_BPInfoKey = "MDUL_CMPT_BPInfoKey";
        public static string DATE_TYPE_CODEInfo = "DATE_TYPE_CODEInfo";
        public static string TPLE_ASET_DETL_ATCHInfo = "TPLE_ASET_DETL_ATCHInfo";
        public static string CHRG_DIVN_CODEInfo = "CHRG_DIVN_CODEInfo";
        public static string CHRG_CALC_MTHD_CODEInfo_CMS = "CHRG_CALC_MTHD_CODEInfo_CMS";
        public static string INTR_ROLE_ASSNInfo = "INTR_ROLE_ASSNInfo";
        public static string RBAT_CALC_TYPE_CODEInfo = "RBAT_CALC_TYPE_CODEInfo";
        public static string NTRE_TYPE_CODEInfo = "NTRE_TYPE_CODEInfo";
        public static string INSR_TYPE_PBLE_ASSNInfo = "INSR_TYPE_PBLE_ASSNInfo";
        public static string GL_ACCT_OTHR_CODEInfo = "GL_ACCT_OTHR_CODEInfo";
        public static string STN_MODL_CODEInfo = "STN_MODL_CODEInfo";
        public static string EVNT_PROP_TYPE_ATCHInfo = "EVNT_PROP_TYPE_ATCHInfo";
        public static string EVNT_PROP_TYPE_CODEInfo = "EVNT_PROP_TYPE_CODEInfo";
        public static string FINL_CNFG_CMPTInfo = "FINL_CNFG_CMPTInfo";
        public static string REQT_EVNT_ASSNInfo = "REQT_EVNT_ASSNInfo";
        public static string NTFY_EVNT_ASSNInfo = "NTFY_EVNT_ASSNInfo";
        public static string NTFY_SBSC_CNFGInfo = "NTFY_SBSC_CNFGInfo";
        public static string NTFY_SBSC_CNFG_DETLInfo = "NTFY_SBSC_CNFG_DETLInfo";

        public static string SIC_SCTN_CODEInfo = "SIC_SCTN_CODEInfo";    
        public static string SIC_TYPE_CODEInfo = "SIC_TYPE_CODEInfo";   
        public static string MD_DT_DFInfo = "MD_DT_DFInfo"; //metadata formats

        public static string BRDX_DAYS_CODEInfo = "BRDX_DAYS_CODEInfo";

        public static string IH_SRVC_TYPE_CODEInfo = "IH_SRVC_TYPE_CODEInfo";
        public static string IH_SRVC_SRCE_CODEInfo = "IH_SRVC_SRCE_CODEInfo";
        public static string IH_SRVC_MTHDInfo = "IH_SRVC_MTHDInfo";
        public static string MD_ITEM_SRCEInfo = "MD_ITEM_SRCEInfo";
        public static string Mesg_CodeInfo = "Mesg_CodeInfo";

        public static string BRKG_CTGY_CODEInfo = "BRKG_CTGY_CODEInfo";
        public static string RSTT_CNFGInfo = "RSTT_CNFGInfo";

        public static string PLCY_TYPE_CODEInfo = "PLCY_TYPE_CODEInfo";
        public static string PLCY_TRMS_CODEInfo = "PLCY_TRMS_CODEInfo";
        public static string DELY_DAYS_CODEInfo = "DELY_DAYS_CODEInfo";
        public static string RTRN_OF_PRIM_CODEInfo = "RTRN_OF_PRIM_CODEInfo";
        public static string FINE_TRMS_CODEInfo = "FINE_TRMS_CODEInfo";

        public static string BTCH_TYPE_CODEInfo = "BTCH_TYPE_CODEInfo";
        public static string SYS_BTCH_PRCS_CNFGInfo = "SYS_BTCH_PRCS_CNFGInfo";
       
    }
}
