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
   public class trip : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A7AttractionId = (short)(NumberUtil.Val( GetPar( "AttractionId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A7AttractionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridtrip_attraction") == 0 )
         {
            nRC_GXsfl_53 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_53"), "."));
            nGXsfl_53_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_53_idx"), "."));
            sGXsfl_53_idx = GetPar( "sGXsfl_53_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridtrip_attraction_newrow( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "Trip", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTripId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public trip( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public trip( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Trip", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00d0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TRIPID"+"'), id:'"+"TRIPID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTripId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTripId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTripId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A48TripId), 4, 0, ".", "")), StringUtil.LTrim( ((edtTripId_Enabled!=0) ? context.localUtil.Format( (decimal)(A48TripId), "ZZZ9") : context.localUtil.Format( (decimal)(A48TripId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTripId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTripId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTripDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTripDate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTripDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTripDate_Internalname, context.localUtil.Format(A49TripDate, "99/99/99"), context.localUtil.Format( A49TripDate, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTripDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTripDate_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Trip.htm");
         GxWebStd.gx_bitmap( context, edtTripDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTripDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Trip.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTripDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTripDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTripDescription_Internalname, StringUtil.RTrim( A50TripDescription), StringUtil.RTrim( context.localUtil.Format( A50TripDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTripDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTripDescription_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAttractiontable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleattraction_Internalname, "Attraction", "", "", lblTitleattraction_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridtrip_attraction( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Trip.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridtrip_attraction( )
      {
         /*  Grid Control  */
         Gridtrip_attractionContainer.AddObjectProperty("GridName", "Gridtrip_attraction");
         Gridtrip_attractionContainer.AddObjectProperty("Header", subGridtrip_attraction_Header);
         Gridtrip_attractionContainer.AddObjectProperty("Class", "Grid");
         Gridtrip_attractionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Backcolorstyle), 1, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("CmpContext", "");
         Gridtrip_attractionContainer.AddObjectProperty("InMasterPage", "false");
         Gridtrip_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrip_attractionColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")));
         Gridtrip_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", "")));
         Gridtrip_attractionContainer.AddColumnProperties(Gridtrip_attractionColumn);
         Gridtrip_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrip_attractionContainer.AddColumnProperties(Gridtrip_attractionColumn);
         Gridtrip_attractionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridtrip_attractionColumn.AddObjectProperty("Value", StringUtil.RTrim( A8AttractionName));
         Gridtrip_attractionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", "")));
         Gridtrip_attractionContainer.AddColumnProperties(Gridtrip_attractionColumn);
         Gridtrip_attractionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Selectedindex), 4, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Allowselection), 1, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Selectioncolor), 9, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Allowhovering), 1, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Hoveringcolor), 9, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Allowcollapsing), 1, 0, ".", "")));
         Gridtrip_attractionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridtrip_attraction_Collapsed), 1, 0, ".", "")));
         nGXsfl_53_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount14 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_14 = 1;
               ScanStart0A14( ) ;
               while ( RcdFound14 != 0 )
               {
                  init_level_properties14( ) ;
                  getByPrimaryKey0A14( ) ;
                  AddRow0A14( ) ;
                  ScanNext0A14( ) ;
               }
               ScanEnd0A14( ) ;
               nBlankRcdCount14 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0A14( ) ;
            standaloneModal0A14( ) ;
            sMode14 = Gx_mode;
            while ( nGXsfl_53_idx < nRC_GXsfl_53 )
            {
               bGXsfl_53_Refreshing = true;
               ReadRow0A14( ) ;
               edtAttractionId_Enabled = (int)(context.localUtil.CToN( cgiGet( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               edtAttractionName_Enabled = (int)(context.localUtil.CToN( cgiGet( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
               imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_53_idx+"Link");
               if ( ( nRcdExists_14 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0A14( ) ;
               }
               SendRow0A14( ) ;
               bGXsfl_53_Refreshing = false;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount14 = 5;
            nRcdExists_14 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0A14( ) ;
               while ( RcdFound14 != 0 )
               {
                  sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5314( ) ;
                  init_level_properties14( ) ;
                  standaloneNotModal0A14( ) ;
                  getByPrimaryKey0A14( ) ;
                  standaloneModal0A14( ) ;
                  AddRow0A14( ) ;
                  ScanNext0A14( ) ;
               }
               ScanEnd0A14( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode14 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx+1), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         InitAll0A14( ) ;
         init_level_properties14( ) ;
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
         nRcdDeleted_14 = 0;
         nBlankRcdCount14 = (short)(nBlankRcdUsr14+nBlankRcdCount14);
         fRowAdded = 0;
         while ( nBlankRcdCount14 > 0 )
         {
            standaloneNotModal0A14( ) ;
            standaloneModal0A14( ) ;
            AddRow0A14( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtAttractionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount14 = (short)(nBlankRcdCount14-1);
         }
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridtrip_attractionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridtrip_attraction", Gridtrip_attractionContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrip_attractionContainerData", Gridtrip_attractionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridtrip_attractionContainerData"+"V", Gridtrip_attractionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridtrip_attractionContainerData"+"V"+"\" value='"+Gridtrip_attractionContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z48TripId = (short)(context.localUtil.CToN( cgiGet( "Z48TripId"), ".", ","));
            Z49TripDate = context.localUtil.CToD( cgiGet( "Z49TripDate"), 0);
            Z50TripDescription = cgiGet( "Z50TripDescription");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_53 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_53"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTripId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTripId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRIPID");
               AnyError = 1;
               GX_FocusControl = edtTripId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A48TripId = 0;
               AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
            }
            else
            {
               A48TripId = (short)(context.localUtil.CToN( cgiGet( edtTripId_Internalname), ".", ","));
               AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtTripDate_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Trip Date"}), 1, "TRIPDATE");
               AnyError = 1;
               GX_FocusControl = edtTripDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A49TripDate = DateTime.MinValue;
               AssignAttri("", false, "A49TripDate", context.localUtil.Format(A49TripDate, "99/99/99"));
            }
            else
            {
               A49TripDate = context.localUtil.CToD( cgiGet( edtTripDate_Internalname), 1);
               AssignAttri("", false, "A49TripDate", context.localUtil.Format(A49TripDate, "99/99/99"));
            }
            A50TripDescription = cgiGet( edtTripDescription_Internalname);
            AssignAttri("", false, "A50TripDescription", A50TripDescription);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A48TripId = (short)(NumberUtil.Val( GetPar( "TripId"), "."));
               AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A13( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0A13( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0A14( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0A14( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               GetKey0A14( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  if ( RcdFound14 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0A14( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0A14( ) ;
                        CloseExtendedTableCursors0A14( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtAttractionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( nRcdDeleted_14 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0A14( ) ;
                        Load0A14( ) ;
                        BeforeValidate0A14( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0A14( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0A14( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0A14( ) ;
                              CloseExtendedTableCursors0A14( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttractionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName)) ;
            ChangePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A13( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z49TripDate = T000A6_A49TripDate[0];
               Z50TripDescription = T000A6_A50TripDescription[0];
            }
            else
            {
               Z49TripDate = A49TripDate;
               Z50TripDescription = A50TripDescription;
            }
         }
         if ( GX_JID == -2 )
         {
            Z48TripId = A48TripId;
            Z49TripDate = A49TripDate;
            Z50TripDescription = A50TripDescription;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0A13( )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A48TripId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
            A49TripDate = T000A7_A49TripDate[0];
            AssignAttri("", false, "A49TripDate", context.localUtil.Format(A49TripDate, "99/99/99"));
            A50TripDescription = T000A7_A50TripDescription[0];
            AssignAttri("", false, "A50TripDescription", A50TripDescription);
            ZM0A13( -2) ;
         }
         pr_default.close(5);
         OnLoadActions0A13( ) ;
      }

      protected void OnLoadActions0A13( )
      {
      }

      protected void CheckExtendedTable0A13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A49TripDate) || ( DateTimeUtil.ResetTime ( A49TripDate ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Trip Date is out of range", "OutOfRange", 1, "TRIPDATE");
            AnyError = 1;
            GX_FocusControl = edtTripDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0A13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A13( )
      {
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A48TripId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A48TripId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0A13( 2) ;
            RcdFound13 = 1;
            A48TripId = T000A6_A48TripId[0];
            AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
            A49TripDate = T000A6_A49TripDate[0];
            AssignAttri("", false, "A49TripDate", context.localUtil.Format(A49TripDate, "99/99/99"));
            A50TripDescription = T000A6_A50TripDescription[0];
            AssignAttri("", false, "A50TripDescription", A50TripDescription);
            Z48TripId = A48TripId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0A13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0A13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A48TripId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A48TripId[0] < A48TripId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A48TripId[0] > A48TripId ) ) )
            {
               A48TripId = T000A9_A48TripId[0];
               AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {A48TripId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000A10_A48TripId[0] > A48TripId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000A10_A48TripId[0] < A48TripId ) ) )
            {
               A48TripId = T000A10_A48TripId[0];
               AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTripId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A48TripId != Z48TripId )
               {
                  A48TripId = Z48TripId;
                  AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRIPID");
                  AnyError = 1;
                  GX_FocusControl = edtTripId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTripId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A13( ) ;
                  GX_FocusControl = edtTripId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A48TripId != Z48TripId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTripId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A13( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRIPID");
                     AnyError = 1;
                     GX_FocusControl = edtTripId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTripId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A13( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A48TripId != Z48TripId )
         {
            A48TripId = Z48TripId;
            AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRIPID");
            AnyError = 1;
            GX_FocusControl = edtTripId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTripId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRIPID");
            AnyError = 1;
            GX_FocusControl = edtTripId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTripDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTripDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTripDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTripDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0A13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTripDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A5 */
            pr_default.execute(3, new Object[] {A48TripId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trip"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( DateTimeUtil.ResetTime ( Z49TripDate ) != DateTimeUtil.ResetTime ( T000A5_A49TripDate[0] ) ) || ( StringUtil.StrCmp(Z50TripDescription, T000A5_A50TripDescription[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z49TripDate ) != DateTimeUtil.ResetTime ( T000A5_A49TripDate[0] ) )
               {
                  GXUtil.WriteLog("trip:[seudo value changed for attri]"+"TripDate");
                  GXUtil.WriteLogRaw("Old: ",Z49TripDate);
                  GXUtil.WriteLogRaw("Current: ",T000A5_A49TripDate[0]);
               }
               if ( StringUtil.StrCmp(Z50TripDescription, T000A5_A50TripDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("trip:[seudo value changed for attri]"+"TripDescription");
                  GXUtil.WriteLogRaw("Old: ",Z50TripDescription);
                  GXUtil.WriteLogRaw("Current: ",T000A5_A50TripDescription[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Trip"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A13( )
      {
         BeforeValidate0A13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A13( 0) ;
            CheckOptimisticConcurrency0A13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A11 */
                     pr_default.execute(9, new Object[] {A49TripDate, A50TripDescription});
                     A48TripId = T000A11_A48TripId[0];
                     AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Trip");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A13( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0A0( ) ;
                           }
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
               Load0A13( ) ;
            }
            EndLevel0A13( ) ;
         }
         CloseExtendedTableCursors0A13( ) ;
      }

      protected void Update0A13( )
      {
         BeforeValidate0A13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A12 */
                     pr_default.execute(10, new Object[] {A49TripDate, A50TripDescription, A48TripId});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Trip");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Trip"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A13( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption0A0( ) ;
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
            }
            EndLevel0A13( ) ;
         }
         CloseExtendedTableCursors0A13( ) ;
      }

      protected void DeferredUpdate0A13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A13( ) ;
            AfterConfirm0A13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A13( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0A14( ) ;
                  while ( RcdFound14 != 0 )
                  {
                     getByPrimaryKey0A14( ) ;
                     Delete0A14( ) ;
                     ScanNext0A14( ) ;
                  }
                  ScanEnd0A14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A13 */
                     pr_default.execute(11, new Object[] {A48TripId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Trip");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound13 == 0 )
                           {
                              InitAll0A13( ) ;
                              Gx_mode = "INS";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                           ResetCaption0A0( ) ;
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
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A13( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void ProcessNestedLevel0A14( )
      {
         nGXsfl_53_idx = 0;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            ReadRow0A14( ) ;
            if ( ( nRcdExists_14 != 0 ) || ( nIsMod_14 != 0 ) )
            {
               standaloneNotModal0A14( ) ;
               GetKey0A14( ) ;
               if ( ( nRcdExists_14 == 0 ) && ( nRcdDeleted_14 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0A14( ) ;
               }
               else
               {
                  if ( RcdFound14 != 0 )
                  {
                     if ( ( nRcdDeleted_14 != 0 ) && ( nRcdExists_14 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0A14( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_14 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0A14( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_14 == 0 )
                     {
                        GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtAttractionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtAttractionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( edtAttractionName_Internalname, StringUtil.RTrim( A8AttractionName)) ;
            ChangePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_14_"+sGXsfl_53_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", ""))) ;
            if ( nIsMod_14 != 0 )
            {
               ChangePostValue( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0A14( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_14 = 0;
         nIsMod_14 = 0;
         nRcdDeleted_14 = 0;
      }

      protected void ProcessLevel0A13( )
      {
         /* Save parent mode. */
         sMode13 = Gx_mode;
         ProcessNestedLevel0A14( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0A13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("trip",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("trip",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A13( )
      {
         /* Using cursor T000A14 */
         pr_default.execute(12);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A48TripId = T000A14_A48TripId[0];
            AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A13( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A48TripId = T000A14_A48TripId[0];
            AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
         }
      }

      protected void ScanEnd0A13( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0A13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A13( )
      {
         edtTripId_Enabled = 0;
         AssignProp("", false, edtTripId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTripId_Enabled), 5, 0), true);
         edtTripDate_Enabled = 0;
         AssignProp("", false, edtTripDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTripDate_Enabled), 5, 0), true);
         edtTripDescription_Enabled = 0;
         AssignProp("", false, edtTripDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTripDescription_Enabled), 5, 0), true);
      }

      protected void ZM0A14( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -3 )
         {
            Z48TripId = A48TripId;
            Z7AttractionId = A7AttractionId;
            Z8AttractionName = A8AttractionName;
         }
      }

      protected void standaloneNotModal0A14( )
      {
      }

      protected void standaloneModal0A14( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtAttractionId_Enabled = 0;
            AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
         else
         {
            edtAttractionId_Enabled = 1;
            AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         }
      }

      protected void Load0A14( )
      {
         /* Using cursor T000A15 */
         pr_default.execute(13, new Object[] {A48TripId, A7AttractionId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound14 = 1;
            A8AttractionName = T000A15_A8AttractionName[0];
            ZM0A14( -3) ;
         }
         pr_default.close(13);
         OnLoadActions0A14( ) ;
      }

      protected void OnLoadActions0A14( )
      {
      }

      protected void CheckExtendedTable0A14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal0A14( ) ;
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Attraction'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AttractionName = T000A4_A8AttractionName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0A14( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0A14( )
      {
      }

      protected void gxLoad_4( short A7AttractionId )
      {
         /* Using cursor T000A16 */
         pr_default.execute(14, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem("No matching 'Attraction'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8AttractionName = T000A16_A8AttractionName[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A8AttractionName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0A14( )
      {
         /* Using cursor T000A17 */
         pr_default.execute(15, new Object[] {A48TripId, A7AttractionId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey0A14( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A48TripId, A7AttractionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A14( 3) ;
            RcdFound14 = 1;
            InitializeNonKey0A14( ) ;
            A7AttractionId = T000A3_A7AttractionId[0];
            Z48TripId = A48TripId;
            Z7AttractionId = A7AttractionId;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0A14( ) ;
            Load0A14( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0A14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0A14( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0A14( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0A14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A48TripId, A7AttractionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TripAttraction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TripAttraction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A14( )
      {
         BeforeValidate0A14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A14( 0) ;
            CheckOptimisticConcurrency0A14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A18 */
                     pr_default.execute(16, new Object[] {A48TripId, A7AttractionId});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("TripAttraction");
                     if ( (pr_default.getStatus(16) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
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
               Load0A14( ) ;
            }
            EndLevel0A14( ) ;
         }
         CloseExtendedTableCursors0A14( ) ;
      }

      protected void Update0A14( )
      {
         BeforeValidate0A14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A14( ) ;
         }
         if ( ( nIsMod_14 != 0 ) || ( nIsDirty_14 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0A14( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0A14( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0A14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [TripAttraction] */
                        DeferredUpdate0A14( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0A14( ) ;
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
               EndLevel0A14( ) ;
            }
         }
         CloseExtendedTableCursors0A14( ) ;
      }

      protected void DeferredUpdate0A14( )
      {
      }

      protected void Delete0A14( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A14( ) ;
            AfterConfirm0A14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A19 */
                  pr_default.execute(17, new Object[] {A48TripId, A7AttractionId});
                  pr_default.close(17);
                  dsDefault.SmartCacheProvider.SetUpdated("TripAttraction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A14( )
      {
         standaloneModal0A14( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000A20 */
            pr_default.execute(18, new Object[] {A7AttractionId});
            A8AttractionName = T000A20_A8AttractionName[0];
            pr_default.close(18);
         }
      }

      protected void EndLevel0A14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A14( )
      {
         /* Scan By routine */
         /* Using cursor T000A21 */
         pr_default.execute(19, new Object[] {A48TripId});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound14 = 1;
            A7AttractionId = T000A21_A7AttractionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A14( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound14 = 1;
            A7AttractionId = T000A21_A7AttractionId[0];
         }
      }

      protected void ScanEnd0A14( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm0A14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A14( )
      {
         edtAttractionId_Enabled = 0;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
         edtAttractionName_Enabled = 0;
         AssignProp("", false, edtAttractionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionName_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void send_integrity_lvl_hashes0A14( )
      {
      }

      protected void send_integrity_lvl_hashes0A13( )
      {
      }

      protected void SubsflControlProps_5314( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_53_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_53_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_53_idx;
      }

      protected void SubsflControlProps_fel_5314( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_53_fel_idx;
         imgprompt_7_Internalname = "PROMPT_7_"+sGXsfl_53_fel_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_53_fel_idx;
      }

      protected void AddRow0A14( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         SendRow0A14( ) ;
      }

      protected void SendRow0A14( )
      {
         Gridtrip_attractionRow = GXWebRow.GetNew(context);
         if ( subGridtrip_attraction_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridtrip_attraction_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridtrip_attraction_Class, "") != 0 )
            {
               subGridtrip_attraction_Linesclass = subGridtrip_attraction_Class+"Odd";
            }
         }
         else if ( subGridtrip_attraction_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridtrip_attraction_Backstyle = 0;
            subGridtrip_attraction_Backcolor = subGridtrip_attraction_Allbackcolor;
            if ( StringUtil.StrCmp(subGridtrip_attraction_Class, "") != 0 )
            {
               subGridtrip_attraction_Linesclass = subGridtrip_attraction_Class+"Uniform";
            }
         }
         else if ( subGridtrip_attraction_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridtrip_attraction_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridtrip_attraction_Class, "") != 0 )
            {
               subGridtrip_attraction_Linesclass = subGridtrip_attraction_Class+"Odd";
            }
            subGridtrip_attraction_Backcolor = (int)(0x0);
         }
         else if ( subGridtrip_attraction_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridtrip_attraction_Backstyle = 1;
            if ( ((int)((nGXsfl_53_idx) % (2))) == 0 )
            {
               subGridtrip_attraction_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrip_attraction_Class, "") != 0 )
               {
                  subGridtrip_attraction_Linesclass = subGridtrip_attraction_Class+"Even";
               }
            }
            else
            {
               subGridtrip_attraction_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridtrip_attraction_Class, "") != 0 )
               {
                  subGridtrip_attraction_Linesclass = subGridtrip_attraction_Class+"Odd";
               }
            }
         }
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ATTRACTIONID_"+sGXsfl_53_idx+"'), id:'"+"ATTRACTIONID_"+sGXsfl_53_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_14_"+sGXsfl_53_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_14_" + sGXsfl_53_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 54,'',false,'" + sGXsfl_53_idx + "',53)\"";
         ROClassString = "Attribute";
         Gridtrip_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAttractionId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridtrip_attractionRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_7_Internalname,(string)sImgUrl,(string)imgprompt_7_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_7_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridtrip_attractionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionName_Internalname,StringUtil.RTrim( A8AttractionName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtAttractionName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)53,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridtrip_attractionRow);
         send_integrity_lvl_hashes0A14( ) ;
         GXCCtl = "Z7AttractionId_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7AttractionId), 4, 0, ".", "")));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_14), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_14), 4, 0, ".", "")));
         GXCCtl = "nIsMod_14_" + sGXsfl_53_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_14), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAttractionName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_7_"+sGXsfl_53_idx+"Link", StringUtil.RTrim( imgprompt_7_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridtrip_attractionContainer.AddRow(Gridtrip_attractionRow);
      }

      protected void ReadRow0A14( )
      {
         nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         edtAttractionId_Enabled = (int)(context.localUtil.CToN( cgiGet( "ATTRACTIONID_"+sGXsfl_53_idx+"Enabled"), ".", ","));
         edtAttractionName_Enabled = (int)(context.localUtil.CToN( cgiGet( "ATTRACTIONNAME_"+sGXsfl_53_idx+"Enabled"), ".", ","));
         imgprompt_7_Link = cgiGet( "PROMPT_7_"+sGXsfl_53_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "ATTRACTIONID_" + sGXsfl_53_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
            wbErr = true;
            A7AttractionId = 0;
         }
         else
         {
            A7AttractionId = (short)(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","));
         }
         A8AttractionName = cgiGet( edtAttractionName_Internalname);
         GXCCtl = "Z7AttractionId_" + sGXsfl_53_idx;
         Z7AttractionId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_14_" + sGXsfl_53_idx;
         nRcdDeleted_14 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_14_" + sGXsfl_53_idx;
         nRcdExists_14 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_14_" + sGXsfl_53_idx;
         nIsMod_14 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtAttractionId_Enabled = edtAttractionId_Enabled;
      }

      protected void ConfirmValues0A0( )
      {
         nGXsfl_53_idx = 0;
         sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
         SubsflControlProps_5314( ) ;
         while ( nGXsfl_53_idx < nRC_GXsfl_53 )
         {
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5314( ) ;
            ChangePostValue( "Z7AttractionId_"+sGXsfl_53_idx, cgiGet( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx)) ;
            DeletePostValue( "ZT_"+"Z7AttractionId_"+sGXsfl_53_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 182860), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202361510213180", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("trip.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z48TripId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48TripId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49TripDate", context.localUtil.DToC( Z49TripDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z50TripDescription", StringUtil.RTrim( Z50TripDescription));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_53", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_53_idx), 8, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("trip.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Trip" ;
      }

      public override string GetPgmdesc( )
      {
         return "Trip" ;
      }

      protected void InitializeNonKey0A13( )
      {
         A49TripDate = DateTime.MinValue;
         AssignAttri("", false, "A49TripDate", context.localUtil.Format(A49TripDate, "99/99/99"));
         A50TripDescription = "";
         AssignAttri("", false, "A50TripDescription", A50TripDescription);
         Z49TripDate = DateTime.MinValue;
         Z50TripDescription = "";
      }

      protected void InitAll0A13( )
      {
         A48TripId = 0;
         AssignAttri("", false, "A48TripId", StringUtil.LTrimStr( (decimal)(A48TripId), 4, 0));
         InitializeNonKey0A13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0A14( )
      {
         A8AttractionName = "";
      }

      protected void InitAll0A14( )
      {
         A7AttractionId = 0;
         InitializeNonKey0A14( ) ;
      }

      protected void StandaloneModalInsert0A14( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202361510213184", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("trip.js", "?202361510213184", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties14( )
      {
         edtAttractionId_Enabled = defedtAttractionId_Enabled;
         AssignProp("", false, edtAttractionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAttractionId_Enabled), 5, 0), !bGXsfl_53_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtTripId_Internalname = "TRIPID";
         edtTripDate_Internalname = "TRIPDATE";
         edtTripDescription_Internalname = "TRIPDESCRIPTION";
         lblTitleattraction_Internalname = "TITLEATTRACTION";
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         divAttractiontable_Internalname = "ATTRACTIONTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_7_Internalname = "PROMPT_7";
         subGridtrip_attraction_Internalname = "GRIDTRIP_ATTRACTION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Trip";
         edtAttractionName_Jsonclick = "";
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         imgprompt_7_Visible = 1;
         edtAttractionId_Jsonclick = "";
         subGridtrip_attraction_Class = "Grid";
         subGridtrip_attraction_Backcolorstyle = 0;
         subGridtrip_attraction_Allowcollapsing = 0;
         subGridtrip_attraction_Allowselection = 0;
         edtAttractionName_Enabled = 0;
         edtAttractionId_Enabled = 1;
         subGridtrip_attraction_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTripDescription_Jsonclick = "";
         edtTripDescription_Enabled = 1;
         edtTripDate_Jsonclick = "";
         edtTripDate_Enabled = 1;
         edtTripId_Jsonclick = "";
         edtTripId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridtrip_attraction_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5314( ) ;
         while ( nGXsfl_53_idx <= nRC_GXsfl_53 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0A14( ) ;
            standaloneModal0A14( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0A14( ) ;
            nGXsfl_53_idx = (int)(nGXsfl_53_idx+1);
            sGXsfl_53_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_53_idx), 4, 0), 4, "0");
            SubsflControlProps_5314( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridtrip_attractionContainer)) ;
         /* End function gxnrGridtrip_attraction_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTripDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Tripid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A49TripDate", context.localUtil.Format(A49TripDate, "99/99/99"));
         AssignAttri("", false, "A50TripDescription", StringUtil.RTrim( A50TripDescription));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z48TripId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48TripId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49TripDate", context.localUtil.Format(Z49TripDate, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z50TripDescription", StringUtil.RTrim( Z50TripDescription));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Attractionid( )
      {
         /* Using cursor T000A20 */
         pr_default.execute(18, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No matching 'Attraction'.", "ForeignKeyNotFound", 1, "ATTRACTIONID");
            AnyError = 1;
            GX_FocusControl = edtAttractionId_Internalname;
         }
         A8AttractionName = T000A20_A8AttractionName[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8AttractionName", StringUtil.RTrim( A8AttractionName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TRIPID","{handler:'Valid_Tripid',iparms:[{av:'A48TripId',fld:'TRIPID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRIPID",",oparms:[{av:'A49TripDate',fld:'TRIPDATE',pic:''},{av:'A50TripDescription',fld:'TRIPDESCRIPTION',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z48TripId'},{av:'Z49TripDate'},{av:'Z50TripDescription'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRIPDATE","{handler:'Valid_Tripdate',iparms:[]");
         setEventMetadata("VALID_TRIPDATE",",oparms:[]}");
         setEventMetadata("VALID_ATTRACTIONID","{handler:'Valid_Attractionid',iparms:[{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9'},{av:'A8AttractionName',fld:'ATTRACTIONNAME',pic:''}]");
         setEventMetadata("VALID_ATTRACTIONID",",oparms:[{av:'A8AttractionName',fld:'ATTRACTIONNAME',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Attractionname',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
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
         pr_default.close(18);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z49TripDate = DateTime.MinValue;
         Z50TripDescription = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A49TripDate = DateTime.MinValue;
         A50TripDescription = "";
         lblTitleattraction_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridtrip_attractionContainer = new GXWebGrid( context);
         Gridtrip_attractionColumn = new GXWebColumn();
         A8AttractionName = "";
         sMode14 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T000A7_A48TripId = new short[1] ;
         T000A7_A49TripDate = new DateTime[] {DateTime.MinValue} ;
         T000A7_A50TripDescription = new string[] {""} ;
         T000A8_A48TripId = new short[1] ;
         T000A6_A48TripId = new short[1] ;
         T000A6_A49TripDate = new DateTime[] {DateTime.MinValue} ;
         T000A6_A50TripDescription = new string[] {""} ;
         sMode13 = "";
         T000A9_A48TripId = new short[1] ;
         T000A10_A48TripId = new short[1] ;
         T000A5_A48TripId = new short[1] ;
         T000A5_A49TripDate = new DateTime[] {DateTime.MinValue} ;
         T000A5_A50TripDescription = new string[] {""} ;
         T000A11_A48TripId = new short[1] ;
         T000A14_A48TripId = new short[1] ;
         Z8AttractionName = "";
         T000A15_A48TripId = new short[1] ;
         T000A15_A8AttractionName = new string[] {""} ;
         T000A15_A7AttractionId = new short[1] ;
         T000A4_A8AttractionName = new string[] {""} ;
         T000A16_A8AttractionName = new string[] {""} ;
         T000A17_A48TripId = new short[1] ;
         T000A17_A7AttractionId = new short[1] ;
         T000A3_A48TripId = new short[1] ;
         T000A3_A7AttractionId = new short[1] ;
         T000A2_A48TripId = new short[1] ;
         T000A2_A7AttractionId = new short[1] ;
         T000A20_A8AttractionName = new string[] {""} ;
         T000A21_A48TripId = new short[1] ;
         T000A21_A7AttractionId = new short[1] ;
         Gridtrip_attractionRow = new GXWebRow();
         subGridtrip_attraction_Linesclass = "";
         ROClassString = "";
         sImgUrl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ49TripDate = DateTime.MinValue;
         ZZ50TripDescription = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.trip__default(),
            new Object[][] {
                new Object[] {
               T000A2_A48TripId, T000A2_A7AttractionId
               }
               , new Object[] {
               T000A3_A48TripId, T000A3_A7AttractionId
               }
               , new Object[] {
               T000A4_A8AttractionName
               }
               , new Object[] {
               T000A5_A48TripId, T000A5_A49TripDate, T000A5_A50TripDescription
               }
               , new Object[] {
               T000A6_A48TripId, T000A6_A49TripDate, T000A6_A50TripDescription
               }
               , new Object[] {
               T000A7_A48TripId, T000A7_A49TripDate, T000A7_A50TripDescription
               }
               , new Object[] {
               T000A8_A48TripId
               }
               , new Object[] {
               T000A9_A48TripId
               }
               , new Object[] {
               T000A10_A48TripId
               }
               , new Object[] {
               T000A11_A48TripId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A14_A48TripId
               }
               , new Object[] {
               T000A15_A48TripId, T000A15_A8AttractionName, T000A15_A7AttractionId
               }
               , new Object[] {
               T000A16_A8AttractionName
               }
               , new Object[] {
               T000A17_A48TripId, T000A17_A7AttractionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A20_A8AttractionName
               }
               , new Object[] {
               T000A21_A48TripId, T000A21_A7AttractionId
               }
            }
         );
      }

      private short nIsMod_14 ;
      private short Z48TripId ;
      private short Z7AttractionId ;
      private short nRcdDeleted_14 ;
      private short nRcdExists_14 ;
      private short GxWebError ;
      private short A7AttractionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A48TripId ;
      private short subGridtrip_attraction_Backcolorstyle ;
      private short subGridtrip_attraction_Allowselection ;
      private short subGridtrip_attraction_Allowhovering ;
      private short subGridtrip_attraction_Allowcollapsing ;
      private short subGridtrip_attraction_Collapsed ;
      private short nBlankRcdCount14 ;
      private short RcdFound14 ;
      private short nBlankRcdUsr14 ;
      private short GX_JID ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private short nIsDirty_14 ;
      private short subGridtrip_attraction_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ48TripId ;
      private int nRC_GXsfl_53 ;
      private int nGXsfl_53_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTripId_Enabled ;
      private int edtTripDate_Enabled ;
      private int edtTripDescription_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtAttractionId_Enabled ;
      private int edtAttractionName_Enabled ;
      private int subGridtrip_attraction_Selectedindex ;
      private int subGridtrip_attraction_Selectioncolor ;
      private int subGridtrip_attraction_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridtrip_attraction_Backcolor ;
      private int subGridtrip_attraction_Allbackcolor ;
      private int imgprompt_7_Visible ;
      private int defedtAttractionId_Enabled ;
      private int idxLst ;
      private long GRIDTRIP_ATTRACTION_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_53_idx="0001" ;
      private string Z50TripDescription ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTripId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtTripId_Jsonclick ;
      private string edtTripDate_Internalname ;
      private string edtTripDate_Jsonclick ;
      private string edtTripDescription_Internalname ;
      private string A50TripDescription ;
      private string edtTripDescription_Jsonclick ;
      private string divAttractiontable_Internalname ;
      private string lblTitleattraction_Internalname ;
      private string lblTitleattraction_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridtrip_attraction_Header ;
      private string A8AttractionName ;
      private string sMode14 ;
      private string edtAttractionId_Internalname ;
      private string edtAttractionName_Internalname ;
      private string imgprompt_7_Link ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode13 ;
      private string Z8AttractionName ;
      private string imgprompt_7_Internalname ;
      private string sGXsfl_53_fel_idx="0001" ;
      private string subGridtrip_attraction_Class ;
      private string subGridtrip_attraction_Linesclass ;
      private string ROClassString ;
      private string edtAttractionId_Jsonclick ;
      private string sImgUrl ;
      private string edtAttractionName_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridtrip_attraction_Internalname ;
      private string ZZ50TripDescription ;
      private DateTime Z49TripDate ;
      private DateTime A49TripDate ;
      private DateTime ZZ49TripDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_53_Refreshing=false ;
      private GXWebGrid Gridtrip_attractionContainer ;
      private GXWebRow Gridtrip_attractionRow ;
      private GXWebColumn Gridtrip_attractionColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000A7_A48TripId ;
      private DateTime[] T000A7_A49TripDate ;
      private string[] T000A7_A50TripDescription ;
      private short[] T000A8_A48TripId ;
      private short[] T000A6_A48TripId ;
      private DateTime[] T000A6_A49TripDate ;
      private string[] T000A6_A50TripDescription ;
      private short[] T000A9_A48TripId ;
      private short[] T000A10_A48TripId ;
      private short[] T000A5_A48TripId ;
      private DateTime[] T000A5_A49TripDate ;
      private string[] T000A5_A50TripDescription ;
      private short[] T000A11_A48TripId ;
      private short[] T000A14_A48TripId ;
      private short[] T000A15_A48TripId ;
      private string[] T000A15_A8AttractionName ;
      private short[] T000A15_A7AttractionId ;
      private string[] T000A4_A8AttractionName ;
      private string[] T000A16_A8AttractionName ;
      private short[] T000A17_A48TripId ;
      private short[] T000A17_A7AttractionId ;
      private short[] T000A3_A48TripId ;
      private short[] T000A3_A7AttractionId ;
      private short[] T000A2_A48TripId ;
      private short[] T000A2_A7AttractionId ;
      private string[] T000A20_A8AttractionName ;
      private short[] T000A21_A48TripId ;
      private short[] T000A21_A7AttractionId ;
      private GXWebForm Form ;
   }

   public class trip__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A6;
          prmT000A6 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A9;
          prmT000A9 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@TripDate",GXType.Date,8,0) ,
          new ParDef("@TripDescription",GXType.NChar,20,0)
          };
          Object[] prmT000A12;
          prmT000A12 = new Object[] {
          new ParDef("@TripDate",GXType.Date,8,0) ,
          new ParDef("@TripDescription",GXType.NChar,20,0) ,
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A13;
          prmT000A13 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          };
          Object[] prmT000A15;
          prmT000A15 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A16;
          prmT000A16 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A17;
          prmT000A17 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A18;
          prmT000A18 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A19;
          prmT000A19 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0) ,
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmT000A21;
          prmT000A21 = new Object[] {
          new ParDef("@TripId",GXType.Int16,4,0)
          };
          Object[] prmT000A20;
          prmT000A20 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [TripId], [AttractionId] FROM [TripAttraction] WITH (UPDLOCK) WHERE [TripId] = @TripId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT [TripId], [AttractionId] FROM [TripAttraction] WHERE [TripId] = @TripId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT [AttractionName] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT [TripId], [TripDate], [TripDescription] FROM [Trip] WITH (UPDLOCK) WHERE [TripId] = @TripId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A6", "SELECT [TripId], [TripDate], [TripDescription] FROM [Trip] WHERE [TripId] = @TripId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT TM1.[TripId], TM1.[TripDate], TM1.[TripDescription] FROM [Trip] TM1 WHERE TM1.[TripId] = @TripId ORDER BY TM1.[TripId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT [TripId] FROM [Trip] WHERE [TripId] = @TripId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A9", "SELECT TOP 1 [TripId] FROM [Trip] WHERE ( [TripId] > @TripId) ORDER BY [TripId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A10", "SELECT TOP 1 [TripId] FROM [Trip] WHERE ( [TripId] < @TripId) ORDER BY [TripId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A11", "INSERT INTO [Trip]([TripDate], [TripDescription]) VALUES(@TripDate, @TripDescription); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000A11)
             ,new CursorDef("T000A12", "UPDATE [Trip] SET [TripDate]=@TripDate, [TripDescription]=@TripDescription  WHERE [TripId] = @TripId", GxErrorMask.GX_NOMASK,prmT000A12)
             ,new CursorDef("T000A13", "DELETE FROM [Trip]  WHERE [TripId] = @TripId", GxErrorMask.GX_NOMASK,prmT000A13)
             ,new CursorDef("T000A14", "SELECT [TripId] FROM [Trip] ORDER BY [TripId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A15", "SELECT T1.[TripId], T2.[AttractionName], T1.[AttractionId] FROM ([TripAttraction] T1 INNER JOIN [Attraction] T2 ON T2.[AttractionId] = T1.[AttractionId]) WHERE T1.[TripId] = @TripId and T1.[AttractionId] = @AttractionId ORDER BY T1.[TripId], T1.[AttractionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A16", "SELECT [AttractionName] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A17", "SELECT [TripId], [AttractionId] FROM [TripAttraction] WHERE [TripId] = @TripId AND [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A18", "INSERT INTO [TripAttraction]([TripId], [AttractionId]) VALUES(@TripId, @AttractionId)", GxErrorMask.GX_NOMASK,prmT000A18)
             ,new CursorDef("T000A19", "DELETE FROM [TripAttraction]  WHERE [TripId] = @TripId AND [AttractionId] = @AttractionId", GxErrorMask.GX_NOMASK,prmT000A19)
             ,new CursorDef("T000A20", "SELECT [AttractionName] FROM [Attraction] WHERE [AttractionId] = @AttractionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A21", "SELECT [TripId], [AttractionId] FROM [TripAttraction] WHERE [TripId] = @TripId ORDER BY [TripId], [AttractionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A21,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
