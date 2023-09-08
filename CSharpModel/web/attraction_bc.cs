using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class attraction_bc : GXHttpHandler, IGxSilentTrn
   {
      public attraction_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public attraction_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z7AttractionId = A7AttractionId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 4) ;
                  ZM022( 5) ;
                  ZM022( 6) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z8AttractionName = A8AttractionName;
            Z18AttractionAddress = A18AttractionAddress;
            Z9CountryId = A9CountryId;
            Z15CityId = A15CityId;
            Z11CategoryId = A11CategoryId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z10CountryName = A10CountryName;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z16CityName = A16CityName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z12CategoryName = A12CategoryName;
         }
         if ( GX_JID == -2 )
         {
            Z7AttractionId = A7AttractionId;
            Z8AttractionName = A8AttractionName;
            Z13AttractionPhoto = A13AttractionPhoto;
            Z40000AttractionPhoto_GXI = A40000AttractionPhoto_GXI;
            Z18AttractionAddress = A18AttractionAddress;
            Z9CountryId = A9CountryId;
            Z15CityId = A15CityId;
            Z11CategoryId = A11CategoryId;
            Z10CountryName = A10CountryName;
            Z16CityName = A16CityName;
            Z12CategoryName = A12CategoryName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00027 */
         pr_default.execute(5, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
            A8AttractionName = BC00027_A8AttractionName[0];
            A10CountryName = BC00027_A10CountryName[0];
            A16CityName = BC00027_A16CityName[0];
            A12CategoryName = BC00027_A12CategoryName[0];
            A40000AttractionPhoto_GXI = BC00027_A40000AttractionPhoto_GXI[0];
            A18AttractionAddress = BC00027_A18AttractionAddress[0];
            A9CountryId = BC00027_A9CountryId[0];
            A15CityId = BC00027_A15CityId[0];
            A11CategoryId = BC00027_A11CategoryId[0];
            n11CategoryId = BC00027_n11CategoryId[0];
            A13AttractionPhoto = BC00027_A13AttractionPhoto[0];
            ZM022( -2) ;
         }
         pr_default.close(5);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00028 */
         pr_default.execute(6, new Object[] {A8AttractionName, A7AttractionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Attraction Name"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(6);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A8AttractionName)) )
         {
            GX_msglist.addItem("The attraction name must not be empty", 0, "");
         }
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A9CountryId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Country'.", "ForeignKeyNotFound", 1, "COUNTRYID");
            AnyError = 1;
         }
         A10CountryName = BC00024_A10CountryName[0];
         pr_default.close(2);
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A9CountryId, A15CityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'City'.", "ForeignKeyNotFound", 1, "CITYID");
            AnyError = 1;
         }
         A16CityName = BC00025_A16CityName[0];
         pr_default.close(3);
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {n11CategoryId, A11CategoryId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A11CategoryId) ) )
            {
               GX_msglist.addItem("No matching 'Category'.", "ForeignKeyNotFound", 1, "CATEGORYID");
               AnyError = 1;
            }
         }
         A12CategoryName = BC00026_A12CategoryName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00029 */
         pr_default.execute(7, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 2) ;
            RcdFound2 = 1;
            A7AttractionId = BC00023_A7AttractionId[0];
            A8AttractionName = BC00023_A8AttractionName[0];
            A40000AttractionPhoto_GXI = BC00023_A40000AttractionPhoto_GXI[0];
            A18AttractionAddress = BC00023_A18AttractionAddress[0];
            A9CountryId = BC00023_A9CountryId[0];
            A15CityId = BC00023_A15CityId[0];
            A11CategoryId = BC00023_A11CategoryId[0];
            n11CategoryId = BC00023_n11CategoryId[0];
            A13AttractionPhoto = BC00023_A13AttractionPhoto[0];
            Z7AttractionId = A7AttractionId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_020( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A7AttractionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Attraction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z8AttractionName, BC00022_A8AttractionName[0]) != 0 ) || ( StringUtil.StrCmp(Z18AttractionAddress, BC00022_A18AttractionAddress[0]) != 0 ) || ( Z9CountryId != BC00022_A9CountryId[0] ) || ( Z15CityId != BC00022_A15CityId[0] ) || ( Z11CategoryId != BC00022_A11CategoryId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Attraction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000210 */
                     pr_default.execute(8, new Object[] {A8AttractionName, A13AttractionPhoto, A40000AttractionPhoto_GXI, A18AttractionAddress, A9CountryId, A15CityId, n11CategoryId, A11CategoryId});
                     A7AttractionId = BC000210_A7AttractionId[0];
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Attraction");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000211 */
                     pr_default.execute(9, new Object[] {A8AttractionName, A18AttractionAddress, A9CountryId, A15CityId, n11CategoryId, A11CategoryId, A7AttractionId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Attraction");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Attraction"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000212 */
            pr_default.execute(10, new Object[] {A13AttractionPhoto, A40000AttractionPhoto_GXI, A7AttractionId});
            pr_default.close(10);
            dsDefault.SmartCacheProvider.SetUpdated("Attraction");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000213 */
                  pr_default.execute(11, new Object[] {A7AttractionId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("Attraction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000214 */
            pr_default.execute(12, new Object[] {A9CountryId});
            A10CountryName = BC000214_A10CountryName[0];
            pr_default.close(12);
            /* Using cursor BC000215 */
            pr_default.execute(13, new Object[] {A9CountryId, A15CityId});
            A16CityName = BC000215_A16CityName[0];
            pr_default.close(13);
            /* Using cursor BC000216 */
            pr_default.execute(14, new Object[] {n11CategoryId, A11CategoryId});
            A12CategoryName = BC000216_A12CategoryName[0];
            pr_default.close(14);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000217 */
            pr_default.execute(15, new Object[] {A7AttractionId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Attraction"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC000218 */
            pr_default.execute(16, new Object[] {A7AttractionId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Attraction"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000219 */
         pr_default.execute(17, new Object[] {A7AttractionId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound2 = 1;
            A7AttractionId = BC000219_A7AttractionId[0];
            A8AttractionName = BC000219_A8AttractionName[0];
            A10CountryName = BC000219_A10CountryName[0];
            A16CityName = BC000219_A16CityName[0];
            A12CategoryName = BC000219_A12CategoryName[0];
            A40000AttractionPhoto_GXI = BC000219_A40000AttractionPhoto_GXI[0];
            A18AttractionAddress = BC000219_A18AttractionAddress[0];
            A9CountryId = BC000219_A9CountryId[0];
            A15CityId = BC000219_A15CityId[0];
            A11CategoryId = BC000219_A11CategoryId[0];
            n11CategoryId = BC000219_n11CategoryId[0];
            A13AttractionPhoto = BC000219_A13AttractionPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound2 = 1;
            A7AttractionId = BC000219_A7AttractionId[0];
            A8AttractionName = BC000219_A8AttractionName[0];
            A10CountryName = BC000219_A10CountryName[0];
            A16CityName = BC000219_A16CityName[0];
            A12CategoryName = BC000219_A12CategoryName[0];
            A40000AttractionPhoto_GXI = BC000219_A40000AttractionPhoto_GXI[0];
            A18AttractionAddress = BC000219_A18AttractionAddress[0];
            A9CountryId = BC000219_A9CountryId[0];
            A15CityId = BC000219_A15CityId[0];
            A11CategoryId = BC000219_A11CategoryId[0];
            n11CategoryId = BC000219_n11CategoryId[0];
            A13AttractionPhoto = BC000219_A13AttractionPhoto[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcAttraction) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcAttraction, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A8AttractionName = "";
         A9CountryId = 0;
         A10CountryName = "";
         A15CityId = 0;
         A16CityName = "";
         A11CategoryId = 0;
         n11CategoryId = false;
         A12CategoryName = "";
         A13AttractionPhoto = "";
         A40000AttractionPhoto_GXI = "";
         A18AttractionAddress = "";
         Z8AttractionName = "";
         Z18AttractionAddress = "";
         Z9CountryId = 0;
         Z15CityId = 0;
         Z11CategoryId = 0;
      }

      protected void InitAll022( )
      {
         A7AttractionId = 0;
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow2( SdtAttraction obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Attractionname = A8AttractionName;
         obj2.gxTpr_Countryid = A9CountryId;
         obj2.gxTpr_Countryname = A10CountryName;
         obj2.gxTpr_Cityid = A15CityId;
         obj2.gxTpr_Cityname = A16CityName;
         obj2.gxTpr_Categoryid = A11CategoryId;
         obj2.gxTpr_Categoryname = A12CategoryName;
         obj2.gxTpr_Attractionphoto = A13AttractionPhoto;
         obj2.gxTpr_Attractionphoto_gxi = A40000AttractionPhoto_GXI;
         obj2.gxTpr_Attractionaddress = A18AttractionAddress;
         obj2.gxTpr_Attractionid = A7AttractionId;
         obj2.gxTpr_Attractionid_Z = Z7AttractionId;
         obj2.gxTpr_Attractionname_Z = Z8AttractionName;
         obj2.gxTpr_Countryid_Z = Z9CountryId;
         obj2.gxTpr_Countryname_Z = Z10CountryName;
         obj2.gxTpr_Cityid_Z = Z15CityId;
         obj2.gxTpr_Cityname_Z = Z16CityName;
         obj2.gxTpr_Categoryid_Z = Z11CategoryId;
         obj2.gxTpr_Categoryname_Z = Z12CategoryName;
         obj2.gxTpr_Attractionaddress_Z = Z18AttractionAddress;
         obj2.gxTpr_Attractionphoto_gxi_Z = Z40000AttractionPhoto_GXI;
         obj2.gxTpr_Categoryid_N = (short)(Convert.ToInt16(n11CategoryId));
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtAttraction obj2 )
      {
         obj2.gxTpr_Attractionid = A7AttractionId;
         return  ;
      }

      public void RowToVars2( SdtAttraction obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A8AttractionName = obj2.gxTpr_Attractionname;
         A9CountryId = obj2.gxTpr_Countryid;
         A10CountryName = obj2.gxTpr_Countryname;
         A15CityId = obj2.gxTpr_Cityid;
         A16CityName = obj2.gxTpr_Cityname;
         A11CategoryId = obj2.gxTpr_Categoryid;
         n11CategoryId = false;
         A12CategoryName = obj2.gxTpr_Categoryname;
         A13AttractionPhoto = obj2.gxTpr_Attractionphoto;
         A40000AttractionPhoto_GXI = obj2.gxTpr_Attractionphoto_gxi;
         A18AttractionAddress = obj2.gxTpr_Attractionaddress;
         A7AttractionId = obj2.gxTpr_Attractionid;
         Z7AttractionId = obj2.gxTpr_Attractionid_Z;
         Z8AttractionName = obj2.gxTpr_Attractionname_Z;
         Z9CountryId = obj2.gxTpr_Countryid_Z;
         Z10CountryName = obj2.gxTpr_Countryname_Z;
         Z15CityId = obj2.gxTpr_Cityid_Z;
         Z16CityName = obj2.gxTpr_Cityname_Z;
         Z11CategoryId = obj2.gxTpr_Categoryid_Z;
         Z12CategoryName = obj2.gxTpr_Categoryname_Z;
         Z18AttractionAddress = obj2.gxTpr_Attractionaddress_Z;
         Z40000AttractionPhoto_GXI = obj2.gxTpr_Attractionphoto_gxi_Z;
         n11CategoryId = (bool)(Convert.ToBoolean(obj2.gxTpr_Categoryid_N));
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A7AttractionId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7AttractionId = A7AttractionId;
         }
         ZM022( -2) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars2( bcAttraction, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z7AttractionId = A7AttractionId;
         }
         ZM022( -2) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A7AttractionId != Z7AttractionId )
               {
                  A7AttractionId = Z7AttractionId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update022( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A7AttractionId != Z7AttractionId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcAttraction, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcAttraction) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcAttraction, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcAttraction) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtAttraction auxBC = new SdtAttraction(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A7AttractionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAttraction);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcAttraction, 1) ;
         UpdateImpl( ) ;
         VarsToRow2( bcAttraction) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcAttraction, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow2( bcAttraction) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcAttraction, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A7AttractionId != Z7AttractionId )
            {
               A7AttractionId = Z7AttractionId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A7AttractionId != Z7AttractionId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
         context.RollbackDataStores("attraction_bc",pr_default);
         VarsToRow2( bcAttraction) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcAttraction.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAttraction.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAttraction )
         {
            bcAttraction = (SdtAttraction)(sdt);
            if ( StringUtil.StrCmp(bcAttraction.gxTpr_Mode, "") == 0 )
            {
               bcAttraction.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcAttraction) ;
            }
            else
            {
               RowToVars2( bcAttraction, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAttraction.gxTpr_Mode, "") == 0 )
            {
               bcAttraction.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcAttraction, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtAttraction Attraction_BC
      {
         get {
            return bcAttraction ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z8AttractionName = "";
         A8AttractionName = "";
         Z18AttractionAddress = "";
         A18AttractionAddress = "";
         Z10CountryName = "";
         A10CountryName = "";
         Z16CityName = "";
         A16CityName = "";
         Z12CategoryName = "";
         A12CategoryName = "";
         Z13AttractionPhoto = "";
         A13AttractionPhoto = "";
         Z40000AttractionPhoto_GXI = "";
         A40000AttractionPhoto_GXI = "";
         BC00027_A7AttractionId = new short[1] ;
         BC00027_A8AttractionName = new string[] {""} ;
         BC00027_A10CountryName = new string[] {""} ;
         BC00027_A16CityName = new string[] {""} ;
         BC00027_A12CategoryName = new string[] {""} ;
         BC00027_A40000AttractionPhoto_GXI = new string[] {""} ;
         BC00027_A18AttractionAddress = new string[] {""} ;
         BC00027_A9CountryId = new short[1] ;
         BC00027_A15CityId = new short[1] ;
         BC00027_A11CategoryId = new short[1] ;
         BC00027_n11CategoryId = new bool[] {false} ;
         BC00027_A13AttractionPhoto = new string[] {""} ;
         BC00028_A8AttractionName = new string[] {""} ;
         BC00024_A10CountryName = new string[] {""} ;
         BC00025_A16CityName = new string[] {""} ;
         BC00026_A12CategoryName = new string[] {""} ;
         BC00029_A7AttractionId = new short[1] ;
         BC00023_A7AttractionId = new short[1] ;
         BC00023_A8AttractionName = new string[] {""} ;
         BC00023_A40000AttractionPhoto_GXI = new string[] {""} ;
         BC00023_A18AttractionAddress = new string[] {""} ;
         BC00023_A9CountryId = new short[1] ;
         BC00023_A15CityId = new short[1] ;
         BC00023_A11CategoryId = new short[1] ;
         BC00023_n11CategoryId = new bool[] {false} ;
         BC00023_A13AttractionPhoto = new string[] {""} ;
         sMode2 = "";
         BC00022_A7AttractionId = new short[1] ;
         BC00022_A8AttractionName = new string[] {""} ;
         BC00022_A40000AttractionPhoto_GXI = new string[] {""} ;
         BC00022_A18AttractionAddress = new string[] {""} ;
         BC00022_A9CountryId = new short[1] ;
         BC00022_A15CityId = new short[1] ;
         BC00022_A11CategoryId = new short[1] ;
         BC00022_n11CategoryId = new bool[] {false} ;
         BC00022_A13AttractionPhoto = new string[] {""} ;
         BC000210_A7AttractionId = new short[1] ;
         BC000214_A10CountryName = new string[] {""} ;
         BC000215_A16CityName = new string[] {""} ;
         BC000216_A12CategoryName = new string[] {""} ;
         BC000217_A48TripId = new short[1] ;
         BC000217_A7AttractionId = new short[1] ;
         BC000218_A44SupplierId = new short[1] ;
         BC000218_A7AttractionId = new short[1] ;
         BC000219_A7AttractionId = new short[1] ;
         BC000219_A8AttractionName = new string[] {""} ;
         BC000219_A10CountryName = new string[] {""} ;
         BC000219_A16CityName = new string[] {""} ;
         BC000219_A12CategoryName = new string[] {""} ;
         BC000219_A40000AttractionPhoto_GXI = new string[] {""} ;
         BC000219_A18AttractionAddress = new string[] {""} ;
         BC000219_A9CountryId = new short[1] ;
         BC000219_A15CityId = new short[1] ;
         BC000219_A11CategoryId = new short[1] ;
         BC000219_n11CategoryId = new bool[] {false} ;
         BC000219_A13AttractionPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.attraction_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A7AttractionId, BC00022_A8AttractionName, BC00022_A40000AttractionPhoto_GXI, BC00022_A18AttractionAddress, BC00022_A9CountryId, BC00022_A15CityId, BC00022_A11CategoryId, BC00022_n11CategoryId, BC00022_A13AttractionPhoto
               }
               , new Object[] {
               BC00023_A7AttractionId, BC00023_A8AttractionName, BC00023_A40000AttractionPhoto_GXI, BC00023_A18AttractionAddress, BC00023_A9CountryId, BC00023_A15CityId, BC00023_A11CategoryId, BC00023_n11CategoryId, BC00023_A13AttractionPhoto
               }
               , new Object[] {
               BC00024_A10CountryName
               }
               , new Object[] {
               BC00025_A16CityName
               }
               , new Object[] {
               BC00026_A12CategoryName
               }
               , new Object[] {
               BC00027_A7AttractionId, BC00027_A8AttractionName, BC00027_A10CountryName, BC00027_A16CityName, BC00027_A12CategoryName, BC00027_A40000AttractionPhoto_GXI, BC00027_A18AttractionAddress, BC00027_A9CountryId, BC00027_A15CityId, BC00027_A11CategoryId,
               BC00027_n11CategoryId, BC00027_A13AttractionPhoto
               }
               , new Object[] {
               BC00028_A8AttractionName
               }
               , new Object[] {
               BC00029_A7AttractionId
               }
               , new Object[] {
               BC000210_A7AttractionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000214_A10CountryName
               }
               , new Object[] {
               BC000215_A16CityName
               }
               , new Object[] {
               BC000216_A12CategoryName
               }
               , new Object[] {
               BC000217_A48TripId, BC000217_A7AttractionId
               }
               , new Object[] {
               BC000218_A44SupplierId, BC000218_A7AttractionId
               }
               , new Object[] {
               BC000219_A7AttractionId, BC000219_A8AttractionName, BC000219_A10CountryName, BC000219_A16CityName, BC000219_A12CategoryName, BC000219_A40000AttractionPhoto_GXI, BC000219_A18AttractionAddress, BC000219_A9CountryId, BC000219_A15CityId, BC000219_A11CategoryId,
               BC000219_n11CategoryId, BC000219_A13AttractionPhoto
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z7AttractionId ;
      private short A7AttractionId ;
      private short GX_JID ;
      private short Z9CountryId ;
      private short A9CountryId ;
      private short Z15CityId ;
      private short A15CityId ;
      private short Z11CategoryId ;
      private short A11CategoryId ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z8AttractionName ;
      private string A8AttractionName ;
      private string Z10CountryName ;
      private string A10CountryName ;
      private string Z16CityName ;
      private string A16CityName ;
      private string Z12CategoryName ;
      private string A12CategoryName ;
      private string sMode2 ;
      private bool returnInSub ;
      private bool n11CategoryId ;
      private bool mustCommit ;
      private string Z18AttractionAddress ;
      private string A18AttractionAddress ;
      private string Z40000AttractionPhoto_GXI ;
      private string A40000AttractionPhoto_GXI ;
      private string Z13AttractionPhoto ;
      private string A13AttractionPhoto ;
      private SdtAttraction bcAttraction ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00027_A7AttractionId ;
      private string[] BC00027_A8AttractionName ;
      private string[] BC00027_A10CountryName ;
      private string[] BC00027_A16CityName ;
      private string[] BC00027_A12CategoryName ;
      private string[] BC00027_A40000AttractionPhoto_GXI ;
      private string[] BC00027_A18AttractionAddress ;
      private short[] BC00027_A9CountryId ;
      private short[] BC00027_A15CityId ;
      private short[] BC00027_A11CategoryId ;
      private bool[] BC00027_n11CategoryId ;
      private string[] BC00027_A13AttractionPhoto ;
      private string[] BC00028_A8AttractionName ;
      private string[] BC00024_A10CountryName ;
      private string[] BC00025_A16CityName ;
      private string[] BC00026_A12CategoryName ;
      private short[] BC00029_A7AttractionId ;
      private short[] BC00023_A7AttractionId ;
      private string[] BC00023_A8AttractionName ;
      private string[] BC00023_A40000AttractionPhoto_GXI ;
      private string[] BC00023_A18AttractionAddress ;
      private short[] BC00023_A9CountryId ;
      private short[] BC00023_A15CityId ;
      private short[] BC00023_A11CategoryId ;
      private bool[] BC00023_n11CategoryId ;
      private string[] BC00023_A13AttractionPhoto ;
      private short[] BC00022_A7AttractionId ;
      private string[] BC00022_A8AttractionName ;
      private string[] BC00022_A40000AttractionPhoto_GXI ;
      private string[] BC00022_A18AttractionAddress ;
      private short[] BC00022_A9CountryId ;
      private short[] BC00022_A15CityId ;
      private short[] BC00022_A11CategoryId ;
      private bool[] BC00022_n11CategoryId ;
      private string[] BC00022_A13AttractionPhoto ;
      private short[] BC000210_A7AttractionId ;
      private string[] BC000214_A10CountryName ;
      private string[] BC000215_A16CityName ;
      private string[] BC000216_A12CategoryName ;
      private short[] BC000217_A48TripId ;
      private short[] BC000217_A7AttractionId ;
      private short[] BC000218_A44SupplierId ;
      private short[] BC000218_A7AttractionId ;
      private short[] BC000219_A7AttractionId ;
      private string[] BC000219_A8AttractionName ;
      private string[] BC000219_A10CountryName ;
      private string[] BC000219_A16CityName ;
      private string[] BC000219_A12CategoryName ;
      private string[] BC000219_A40000AttractionPhoto_GXI ;
      private string[] BC000219_A18AttractionAddress ;
      private short[] BC000219_A9CountryId ;
      private short[] BC000219_A15CityId ;
      private short[] BC000219_A11CategoryId ;
      private bool[] BC000219_n11CategoryId ;
      private string[] BC000219_A13AttractionPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class attraction_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AttractionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="Attraction", Fld="AttractionPhoto"} ,
          new ParDef("@AttractionAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@AttractionName",GXType.NChar,50,0) ,
          new ParDef("@AttractionAddress",GXType.NVarChar,1024,0) ,
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0) ,
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@AttractionPhoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@AttractionPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Attraction", Fld="AttractionPhoto"} ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0)
          };
          Object[] prmBC000215;
          prmBC000215 = new Object[] {
          new ParDef("@CountryId",GXType.Int16,4,0) ,
          new ParDef("@CityId",GXType.Int16,4,0)
          };
          Object[] prmBC000216;
          prmBC000216 = new Object[] {
          new ParDef("@CategoryId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000217;
          prmBC000217 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC000218;
          prmBC000218 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmBC000219;
          prmBC000219 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [AttractionId], [AttractionName], [AttractionPhoto_GXI], [AttractionAddress], [CountryId], [CityId], [CategoryId], [AttractionPhoto] FROM [Attraction] WITH (UPDLOCK) WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [AttractionId], [AttractionName], [AttractionPhoto_GXI], [AttractionAddress], [CountryId], [CityId], [CategoryId], [AttractionPhoto] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "SELECT TM1.[AttractionId], TM1.[AttractionName], T2.[CountryName], T3.[CityName], T4.[CategoryName], TM1.[AttractionPhoto_GXI], TM1.[AttractionAddress], TM1.[CountryId], TM1.[CityId], TM1.[CategoryId], TM1.[AttractionPhoto] FROM ((([Attraction] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) INNER JOIN [CountryCity] T3 ON T3.[CountryId] = TM1.[CountryId] AND T3.[CityId] = TM1.[CityId]) LEFT JOIN [Category] T4 ON T4.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[AttractionId] = @AttractionId ORDER BY TM1.[AttractionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "SELECT [AttractionName] FROM [Attraction] WHERE ([AttractionName] = @AttractionName) AND (Not ( [AttractionId] = @AttractionId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00029", "SELECT [AttractionId] FROM [Attraction] WHERE [AttractionId] = @AttractionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000210", "INSERT INTO [Attraction]([AttractionName], [AttractionPhoto], [AttractionPhoto_GXI], [AttractionAddress], [CountryId], [CityId], [CategoryId]) VALUES(@AttractionName, @AttractionPhoto, @AttractionPhoto_GXI, @AttractionAddress, @CountryId, @CityId, @CategoryId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000210)
             ,new CursorDef("BC000211", "UPDATE [Attraction] SET [AttractionName]=@AttractionName, [AttractionAddress]=@AttractionAddress, [CountryId]=@CountryId, [CityId]=@CityId, [CategoryId]=@CategoryId  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmBC000211)
             ,new CursorDef("BC000212", "UPDATE [Attraction] SET [AttractionPhoto]=@AttractionPhoto, [AttractionPhoto_GXI]=@AttractionPhoto_GXI  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmBC000212)
             ,new CursorDef("BC000213", "DELETE FROM [Attraction]  WHERE [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmBC000213)
             ,new CursorDef("BC000214", "SELECT [CountryName] FROM [Country] WHERE [CountryId] = @CountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000215", "SELECT [CityName] FROM [CountryCity] WHERE [CountryId] = @CountryId AND [CityId] = @CityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000215,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000216", "SELECT [CategoryName] FROM [Category] WHERE [CategoryId] = @CategoryId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000216,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000217", "SELECT TOP 1 [TripId], [AttractionId] FROM [TripAttraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000217,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000218", "SELECT TOP 1 [SupplierId], [AttractionId] FROM [SupplierAttraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000218,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000219", "SELECT TM1.[AttractionId], TM1.[AttractionName], T2.[CountryName], T3.[CityName], T4.[CategoryName], TM1.[AttractionPhoto_GXI], TM1.[AttractionAddress], TM1.[CountryId], TM1.[CityId], TM1.[CategoryId], TM1.[AttractionPhoto] FROM ((([Attraction] TM1 INNER JOIN [Country] T2 ON T2.[CountryId] = TM1.[CountryId]) INNER JOIN [CountryCity] T3 ON T3.[CountryId] = TM1.[CountryId] AND T3.[CityId] = TM1.[CityId]) LEFT JOIN [Category] T4 ON T4.[CategoryId] = TM1.[CategoryId]) WHERE TM1.[AttractionId] = @AttractionId ORDER BY TM1.[AttractionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000219,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(6));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getMultimediaUri(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((bool[]) buf[10])[0] = rslt.wasNull(10);
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(6));
                return;
       }
    }

 }

}
