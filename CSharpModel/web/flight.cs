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
   public class flight : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A19FlightId = (short)(NumberUtil.Val( GetPar( "FlightId"), "."));
            AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A19FlightId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A22FlightDepartureAirportId = (short)(NumberUtil.Val( GetPar( "FlightDepartureAirportId"), "."));
            AssignAttri("", false, "A22FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlightDepartureAirportId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A22FlightDepartureAirportId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A26FlightDepartureCountryId = (short)(NumberUtil.Val( GetPar( "FlightDepartureCountryId"), "."));
            AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A26FlightDepartureCountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A26FlightDepartureCountryId = (short)(NumberUtil.Val( GetPar( "FlightDepartureCountryId"), "."));
            AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
            A28FlightDepartureCityId = (short)(NumberUtil.Val( GetPar( "FlightDepartureCityId"), "."));
            AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A28FlightDepartureCityId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A26FlightDepartureCountryId, A28FlightDepartureCityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A24FlightArrivalAirportId = (short)(NumberUtil.Val( GetPar( "FlightArrivalAirportId"), "."));
            AssignAttri("", false, "A24FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A24FlightArrivalAirportId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A24FlightArrivalAirportId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A30FlightArrivalCountryId = (short)(NumberUtil.Val( GetPar( "FlightArrivalCountryId"), "."));
            AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A30FlightArrivalCountryId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A30FlightArrivalCountryId = (short)(NumberUtil.Val( GetPar( "FlightArrivalCountryId"), "."));
            AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
            A32FlightArrivalCityId = (short)(NumberUtil.Val( GetPar( "FlightArrivalCityId"), "."));
            AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A32FlightArrivalCityId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A30FlightArrivalCountryId, A32FlightArrivalCityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A37AirlineId = (short)(NumberUtil.Val( GetPar( "AirlineId"), "."));
            n37AirlineId = false;
            AssignAttri("", false, "A37AirlineId", StringUtil.LTrimStr( (decimal)(A37AirlineId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A37AirlineId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridflight_seat") == 0 )
         {
            nRC_GXsfl_138 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_138"), "."));
            nGXsfl_138_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_138_idx"), "."));
            sGXsfl_138_idx = GetPar( "sGXsfl_138_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridflight_seat_newrow( ) ;
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
            Form.Meta.addItem("description", "Flight", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public flight( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public flight( IGxContext context )
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
         cmbFlightSeatChar = new GXCombobox();
         cmbFlightSeatLocation = new GXCombobox();
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Flight", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Flight.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLIGHTID"+"'), id:'"+"FLIGHTID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Flight.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19FlightId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightId_Enabled!=0) ? context.localUtil.Format( (decimal)(A19FlightId), "ZZZ9") : context.localUtil.Format( (decimal)(A19FlightId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightDepartureAirportId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureAirportId_Internalname, "Departure Airport Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureAirportId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22FlightDepartureAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightDepartureAirportId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22FlightDepartureAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(A22FlightDepartureAirportId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureAirportId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureAirportId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_22_Internalname, sImgUrl, imgprompt_22_Link, "", "", context.GetTheme( ), imgprompt_22_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightDepartureAirportName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureAirportName_Internalname, "Departure Airport Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureAirportName_Internalname, StringUtil.RTrim( A23FlightDepartureAirportName), StringUtil.RTrim( context.localUtil.Format( A23FlightDepartureAirportName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureAirportName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureAirportName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightDepartureCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26FlightDepartureCountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightDepartureCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A26FlightDepartureCountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A26FlightDepartureCountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightDepartureCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCountryName_Internalname, StringUtil.RTrim( A27FlightDepartureCountryName), StringUtil.RTrim( context.localUtil.Format( A27FlightDepartureCountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightDepartureCityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCityId_Internalname, "City Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlightDepartureCityId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightDepartureCityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A28FlightDepartureCityId), "ZZZ9") : context.localUtil.Format( (decimal)(A28FlightDepartureCityId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCityId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightDepartureCityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDepartureCityName_Internalname, "City Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightDepartureCityName_Internalname, StringUtil.RTrim( A29FlightDepartureCityName), StringUtil.RTrim( context.localUtil.Format( A29FlightDepartureCityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDepartureCityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDepartureCityName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightArrivalAirportId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalAirportId_Internalname, "Arrival Airport Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalAirportId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24FlightArrivalAirportId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightArrivalAirportId_Enabled!=0) ? context.localUtil.Format( (decimal)(A24FlightArrivalAirportId), "ZZZ9") : context.localUtil.Format( (decimal)(A24FlightArrivalAirportId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalAirportId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalAirportId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_24_Internalname, sImgUrl, imgprompt_24_Link, "", "", context.GetTheme( ), imgprompt_24_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightArrivalAirportName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalAirportName_Internalname, "Arrival Airport Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalAirportName_Internalname, StringUtil.RTrim( A25FlightArrivalAirportName), StringUtil.RTrim( context.localUtil.Format( A25FlightArrivalAirportName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalAirportName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalAirportName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightArrivalCountryId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCountryId_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCountryId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30FlightArrivalCountryId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightArrivalCountryId_Enabled!=0) ? context.localUtil.Format( (decimal)(A30FlightArrivalCountryId), "ZZZ9") : context.localUtil.Format( (decimal)(A30FlightArrivalCountryId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCountryId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCountryId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightArrivalCountryName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCountryName_Internalname, StringUtil.RTrim( A31FlightArrivalCountryName), StringUtil.RTrim( context.localUtil.Format( A31FlightArrivalCountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightArrivalCityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCityId_Internalname, "City Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32FlightArrivalCityId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightArrivalCityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A32FlightArrivalCityId), "ZZZ9") : context.localUtil.Format( (decimal)(A32FlightArrivalCityId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCityId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightArrivalCityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightArrivalCityName_Internalname, "City Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightArrivalCityName_Internalname, StringUtil.RTrim( A33FlightArrivalCityName), StringUtil.RTrim( context.localUtil.Format( A33FlightArrivalCityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightArrivalCityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightArrivalCityName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightPrice_Internalname, "Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A34FlightPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtFlightPrice_Enabled!=0) ? context.localUtil.Format( A34FlightPrice, "ZZZZZ9.99") : context.localUtil.Format( A34FlightPrice, "ZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightPrice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Praise", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightDiscountPercentage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightDiscountPercentage_Internalname, "Discount Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFlightDiscountPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35FlightDiscountPercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtFlightDiscountPercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A35FlightDiscountPercentage), "ZZ9") : context.localUtil.Format( (decimal)(A35FlightDiscountPercentage), "ZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightDiscountPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightDiscountPercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, 0, true, "Percentage", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAirlineId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineId_Internalname, "Airline Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAirlineId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37AirlineId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAirlineId_Enabled!=0) ? context.localUtil.Format( (decimal)(A37AirlineId), "ZZZ9") : context.localUtil.Format( (decimal)(A37AirlineId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Flight.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_37_Internalname, sImgUrl, imgprompt_37_Link, "", "", context.GetTheme( ), imgprompt_37_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAirlineName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineName_Internalname, "Airline Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAirlineName_Internalname, StringUtil.RTrim( A38AirlineName), StringUtil.RTrim( context.localUtil.Format( A38AirlineName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtAirlineDiscountPercentage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAirlineDiscountPercentage_Internalname, "Airline Discount Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAirlineDiscountPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A39AirlineDiscountPercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtAirlineDiscountPercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A39AirlineDiscountPercentage), "ZZ9") : context.localUtil.Format( (decimal)(A39AirlineDiscountPercentage), "ZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAirlineDiscountPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAirlineDiscountPercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, 0, true, "Percentage", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightFinalPrice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightFinalPrice_Internalname, "Final Price", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightFinalPrice_Internalname, StringUtil.LTrim( StringUtil.NToC( A36FlightFinalPrice, 9, 2, ".", "")), StringUtil.LTrim( ((edtFlightFinalPrice_Enabled!=0) ? context.localUtil.Format( A36FlightFinalPrice, "ZZZZZ9.99") : context.localUtil.Format( A36FlightFinalPrice, "ZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightFinalPrice_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightFinalPrice_Enabled, 0, "text", "", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Price", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFlightCapacity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFlightCapacity_Internalname, "Capacity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFlightCapacity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A42FlightCapacity), 4, 0, ".", "")), StringUtil.LTrim( ((edtFlightCapacity_Enabled!=0) ? context.localUtil.Format( (decimal)(A42FlightCapacity), "ZZZ9") : context.localUtil.Format( (decimal)(A42FlightCapacity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFlightCapacity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFlightCapacity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSeattable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleseat_Internalname, "Seat", "", "", lblTitleseat_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridflight_seat( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Flight.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridflight_seat( )
      {
         /*  Grid Control  */
         Gridflight_seatContainer.AddObjectProperty("GridName", "Gridflight_seat");
         Gridflight_seatContainer.AddObjectProperty("Header", subGridflight_seat_Header);
         Gridflight_seatContainer.AddObjectProperty("Class", "Grid");
         Gridflight_seatContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Backcolorstyle), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("CmpContext", "");
         Gridflight_seatContainer.AddObjectProperty("InMasterPage", "false");
         Gridflight_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflight_seatColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FlightSeatId), 4, 0, ".", "")));
         Gridflight_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", "")));
         Gridflight_seatContainer.AddColumnProperties(Gridflight_seatColumn);
         Gridflight_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflight_seatColumn.AddObjectProperty("Value", StringUtil.RTrim( A43FlightSeatChar));
         Gridflight_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", "")));
         Gridflight_seatContainer.AddColumnProperties(Gridflight_seatColumn);
         Gridflight_seatColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridflight_seatColumn.AddObjectProperty("Value", StringUtil.RTrim( A41FlightSeatLocation));
         Gridflight_seatColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", "")));
         Gridflight_seatContainer.AddColumnProperties(Gridflight_seatColumn);
         Gridflight_seatContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Selectedindex), 4, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Allowselection), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Selectioncolor), 9, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Allowhovering), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Hoveringcolor), 9, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Allowcollapsing), 1, 0, ".", "")));
         Gridflight_seatContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridflight_seat_Collapsed), 1, 0, ".", "")));
         nGXsfl_138_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount10 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_10 = 1;
               ScanStart0510( ) ;
               while ( RcdFound10 != 0 )
               {
                  init_level_properties10( ) ;
                  getByPrimaryKey0510( ) ;
                  AddRow0510( ) ;
                  ScanNext0510( ) ;
               }
               ScanEnd0510( ) ;
               nBlankRcdCount10 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B42FlightCapacity = A42FlightCapacity;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            standaloneNotModal0510( ) ;
            standaloneModal0510( ) ;
            sMode10 = Gx_mode;
            while ( nGXsfl_138_idx < nRC_GXsfl_138 )
            {
               bGXsfl_138_Refreshing = true;
               ReadRow0510( ) ;
               edtFlightSeatId_Enabled = (int)(context.localUtil.CToN( cgiGet( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
               cmbFlightSeatChar.Enabled = (int)(context.localUtil.CToN( cgiGet( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled"), ".", ","));
               AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
               cmbFlightSeatLocation.Enabled = (int)(context.localUtil.CToN( cgiGet( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled"), ".", ","));
               AssignProp("", false, cmbFlightSeatLocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0), !bGXsfl_138_Refreshing);
               if ( ( nRcdExists_10 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0510( ) ;
               }
               SendRow0510( ) ;
               bGXsfl_138_Refreshing = false;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A42FlightCapacity = B42FlightCapacity;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount10 = 5;
            nRcdExists_10 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0510( ) ;
               while ( RcdFound10 != 0 )
               {
                  sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_13810( ) ;
                  init_level_properties10( ) ;
                  standaloneNotModal0510( ) ;
                  getByPrimaryKey0510( ) ;
                  standaloneModal0510( ) ;
                  AddRow0510( ) ;
                  ScanNext0510( ) ;
               }
               ScanEnd0510( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode10 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx+1), 4, 0), 4, "0");
         SubsflControlProps_13810( ) ;
         InitAll0510( ) ;
         init_level_properties10( ) ;
         B42FlightCapacity = A42FlightCapacity;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         nRcdExists_10 = 0;
         nIsMod_10 = 0;
         nRcdDeleted_10 = 0;
         nBlankRcdCount10 = (short)(nBlankRcdUsr10+nBlankRcdCount10);
         fRowAdded = 0;
         while ( nBlankRcdCount10 > 0 )
         {
            standaloneNotModal0510( ) ;
            standaloneModal0510( ) ;
            AddRow0510( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtFlightSeatId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount10 = (short)(nBlankRcdCount10-1);
         }
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         A42FlightCapacity = B42FlightCapacity;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridflight_seatContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridflight_seat", Gridflight_seatContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridflight_seatContainerData", Gridflight_seatContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridflight_seatContainerData"+"V", Gridflight_seatContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridflight_seatContainerData"+"V"+"\" value='"+Gridflight_seatContainer.GridValuesHidden()+"'/>") ;
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
            Z19FlightId = (short)(context.localUtil.CToN( cgiGet( "Z19FlightId"), ".", ","));
            Z34FlightPrice = context.localUtil.CToN( cgiGet( "Z34FlightPrice"), ".", ",");
            Z35FlightDiscountPercentage = (short)(context.localUtil.CToN( cgiGet( "Z35FlightDiscountPercentage"), ".", ","));
            Z37AirlineId = (short)(context.localUtil.CToN( cgiGet( "Z37AirlineId"), ".", ","));
            n37AirlineId = ((0==A37AirlineId) ? true : false);
            Z22FlightDepartureAirportId = (short)(context.localUtil.CToN( cgiGet( "Z22FlightDepartureAirportId"), ".", ","));
            Z24FlightArrivalAirportId = (short)(context.localUtil.CToN( cgiGet( "Z24FlightArrivalAirportId"), ".", ","));
            O42FlightCapacity = (short)(context.localUtil.CToN( cgiGet( "O42FlightCapacity"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_138 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_138"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTID");
               AnyError = 1;
               GX_FocusControl = edtFlightId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A19FlightId = 0;
               AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
            }
            else
            {
               A19FlightId = (short)(context.localUtil.CToN( cgiGet( edtFlightId_Internalname), ".", ","));
               AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightDepartureAirportId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightDepartureAirportId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTDEPARTUREAIRPORTID");
               AnyError = 1;
               GX_FocusControl = edtFlightDepartureAirportId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22FlightDepartureAirportId = 0;
               AssignAttri("", false, "A22FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlightDepartureAirportId), 4, 0));
            }
            else
            {
               A22FlightDepartureAirportId = (short)(context.localUtil.CToN( cgiGet( edtFlightDepartureAirportId_Internalname), ".", ","));
               AssignAttri("", false, "A22FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlightDepartureAirportId), 4, 0));
            }
            A23FlightDepartureAirportName = cgiGet( edtFlightDepartureAirportName_Internalname);
            AssignAttri("", false, "A23FlightDepartureAirportName", A23FlightDepartureAirportName);
            A26FlightDepartureCountryId = (short)(context.localUtil.CToN( cgiGet( edtFlightDepartureCountryId_Internalname), ".", ","));
            AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
            A27FlightDepartureCountryName = cgiGet( edtFlightDepartureCountryName_Internalname);
            AssignAttri("", false, "A27FlightDepartureCountryName", A27FlightDepartureCountryName);
            A28FlightDepartureCityId = (short)(context.localUtil.CToN( cgiGet( edtFlightDepartureCityId_Internalname), ".", ","));
            AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A28FlightDepartureCityId), 4, 0));
            A29FlightDepartureCityName = cgiGet( edtFlightDepartureCityName_Internalname);
            AssignAttri("", false, "A29FlightDepartureCityName", A29FlightDepartureCityName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightArrivalAirportId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightArrivalAirportId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTARRIVALAIRPORTID");
               AnyError = 1;
               GX_FocusControl = edtFlightArrivalAirportId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A24FlightArrivalAirportId = 0;
               AssignAttri("", false, "A24FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A24FlightArrivalAirportId), 4, 0));
            }
            else
            {
               A24FlightArrivalAirportId = (short)(context.localUtil.CToN( cgiGet( edtFlightArrivalAirportId_Internalname), ".", ","));
               AssignAttri("", false, "A24FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A24FlightArrivalAirportId), 4, 0));
            }
            A25FlightArrivalAirportName = cgiGet( edtFlightArrivalAirportName_Internalname);
            AssignAttri("", false, "A25FlightArrivalAirportName", A25FlightArrivalAirportName);
            A30FlightArrivalCountryId = (short)(context.localUtil.CToN( cgiGet( edtFlightArrivalCountryId_Internalname), ".", ","));
            AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
            A31FlightArrivalCountryName = cgiGet( edtFlightArrivalCountryName_Internalname);
            AssignAttri("", false, "A31FlightArrivalCountryName", A31FlightArrivalCountryName);
            A32FlightArrivalCityId = (short)(context.localUtil.CToN( cgiGet( edtFlightArrivalCityId_Internalname), ".", ","));
            AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A32FlightArrivalCityId), 4, 0));
            A33FlightArrivalCityName = cgiGet( edtFlightArrivalCityName_Internalname);
            AssignAttri("", false, "A33FlightArrivalCityName", A33FlightArrivalCityName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightPrice_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightPrice_Internalname), ".", ",") > 999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTPRICE");
               AnyError = 1;
               GX_FocusControl = edtFlightPrice_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A34FlightPrice = 0;
               AssignAttri("", false, "A34FlightPrice", StringUtil.LTrimStr( A34FlightPrice, 9, 2));
            }
            else
            {
               A34FlightPrice = context.localUtil.CToN( cgiGet( edtFlightPrice_Internalname), ".", ",");
               AssignAttri("", false, "A34FlightPrice", StringUtil.LTrimStr( A34FlightPrice, 9, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFlightDiscountPercentage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightDiscountPercentage_Internalname), ".", ",") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FLIGHTDISCOUNTPERCENTAGE");
               AnyError = 1;
               GX_FocusControl = edtFlightDiscountPercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A35FlightDiscountPercentage = 0;
               AssignAttri("", false, "A35FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A35FlightDiscountPercentage), 3, 0));
            }
            else
            {
               A35FlightDiscountPercentage = (short)(context.localUtil.CToN( cgiGet( edtFlightDiscountPercentage_Internalname), ".", ","));
               AssignAttri("", false, "A35FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A35FlightDiscountPercentage), 3, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAirlineId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAirlineId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A37AirlineId = 0;
               n37AirlineId = false;
               AssignAttri("", false, "A37AirlineId", StringUtil.LTrimStr( (decimal)(A37AirlineId), 4, 0));
            }
            else
            {
               A37AirlineId = (short)(context.localUtil.CToN( cgiGet( edtAirlineId_Internalname), ".", ","));
               n37AirlineId = false;
               AssignAttri("", false, "A37AirlineId", StringUtil.LTrimStr( (decimal)(A37AirlineId), 4, 0));
            }
            n37AirlineId = ((0==A37AirlineId) ? true : false);
            A38AirlineName = cgiGet( edtAirlineName_Internalname);
            AssignAttri("", false, "A38AirlineName", A38AirlineName);
            A39AirlineDiscountPercentage = (short)(context.localUtil.CToN( cgiGet( edtAirlineDiscountPercentage_Internalname), ".", ","));
            AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A39AirlineDiscountPercentage), 3, 0));
            A36FlightFinalPrice = context.localUtil.CToN( cgiGet( edtFlightFinalPrice_Internalname), ".", ",");
            AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
            A42FlightCapacity = (short)(context.localUtil.CToN( cgiGet( edtFlightCapacity_Internalname), ".", ","));
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
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
               A19FlightId = (short)(NumberUtil.Val( GetPar( "FlightId"), "."));
               AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
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
               InitAll056( ) ;
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
         DisableAttributes056( ) ;
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

      protected void CONFIRM_0510( )
      {
         s42FlightCapacity = O42FlightCapacity;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         nGXsfl_138_idx = 0;
         while ( nGXsfl_138_idx < nRC_GXsfl_138 )
         {
            ReadRow0510( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               GetKey0510( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  if ( RcdFound10 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0510( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0510( ) ;
                        CloseExtendedTableCursors0510( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O42FlightCapacity = A42FlightCapacity;
                        n42FlightCapacity = false;
                        AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtFlightSeatId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( nRcdDeleted_10 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0510( ) ;
                        Load0510( ) ;
                        BeforeValidate0510( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0510( ) ;
                           O42FlightCapacity = A42FlightCapacity;
                           n42FlightCapacity = false;
                           AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0510( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0510( ) ;
                              CloseExtendedTableCursors0510( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O42FlightCapacity = A42FlightCapacity;
                              n42FlightCapacity = false;
                              AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtFlightSeatId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtFlightSeatId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( cmbFlightSeatChar_Internalname, StringUtil.RTrim( A43FlightSeatChar)) ;
            ChangePostValue( cmbFlightSeatLocation_Internalname, StringUtil.RTrim( A41FlightSeatLocation)) ;
            ChangePostValue( "ZT_"+"Z40FlightSeatId_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z43FlightSeatChar_"+sGXsfl_138_idx, StringUtil.RTrim( Z43FlightSeatChar)) ;
            ChangePostValue( "ZT_"+"Z41FlightSeatLocation_"+sGXsfl_138_idx, StringUtil.RTrim( Z41FlightSeatLocation)) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ".", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", ""))) ;
            }
         }
         O42FlightCapacity = s42FlightCapacity;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         /* Start of After( level) rules */
         if ( A42FlightCapacity < 8 )
         {
            GX_msglist.addItem("The seat quantity mustn't be less than eight", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
      }

      protected void ResetCaption050( )
      {
      }

      protected void ZM056( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z34FlightPrice = T00055_A34FlightPrice[0];
               Z35FlightDiscountPercentage = T00055_A35FlightDiscountPercentage[0];
               Z37AirlineId = T00055_A37AirlineId[0];
               Z22FlightDepartureAirportId = T00055_A22FlightDepartureAirportId[0];
               Z24FlightArrivalAirportId = T00055_A24FlightArrivalAirportId[0];
            }
            else
            {
               Z34FlightPrice = A34FlightPrice;
               Z35FlightDiscountPercentage = A35FlightDiscountPercentage;
               Z37AirlineId = A37AirlineId;
               Z22FlightDepartureAirportId = A22FlightDepartureAirportId;
               Z24FlightArrivalAirportId = A24FlightArrivalAirportId;
            }
         }
         if ( GX_JID == -6 )
         {
            Z19FlightId = A19FlightId;
            Z34FlightPrice = A34FlightPrice;
            Z35FlightDiscountPercentage = A35FlightDiscountPercentage;
            Z37AirlineId = A37AirlineId;
            Z22FlightDepartureAirportId = A22FlightDepartureAirportId;
            Z24FlightArrivalAirportId = A24FlightArrivalAirportId;
            Z42FlightCapacity = A42FlightCapacity;
            Z23FlightDepartureAirportName = A23FlightDepartureAirportName;
            Z26FlightDepartureCountryId = A26FlightDepartureCountryId;
            Z28FlightDepartureCityId = A28FlightDepartureCityId;
            Z27FlightDepartureCountryName = A27FlightDepartureCountryName;
            Z29FlightDepartureCityName = A29FlightDepartureCityName;
            Z25FlightArrivalAirportName = A25FlightArrivalAirportName;
            Z30FlightArrivalCountryId = A30FlightArrivalCountryId;
            Z32FlightArrivalCityId = A32FlightArrivalCityId;
            Z31FlightArrivalCountryName = A31FlightArrivalCountryName;
            Z33FlightArrivalCityName = A33FlightArrivalCityName;
            Z38AirlineName = A38AirlineName;
            Z39AirlineDiscountPercentage = A39AirlineDiscountPercentage;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_22_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLIGHTDEPARTUREAIRPORTID"+"'), id:'"+"FLIGHTDEPARTUREAIRPORTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_24_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FLIGHTARRIVALAIRPORTID"+"'), id:'"+"FLIGHTARRIVALAIRPORTID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_37_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"AIRLINEID"+"'), id:'"+"AIRLINEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load056( )
      {
         /* Using cursor T000516 */
         pr_default.execute(12, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
            A23FlightDepartureAirportName = T000516_A23FlightDepartureAirportName[0];
            AssignAttri("", false, "A23FlightDepartureAirportName", A23FlightDepartureAirportName);
            A27FlightDepartureCountryName = T000516_A27FlightDepartureCountryName[0];
            AssignAttri("", false, "A27FlightDepartureCountryName", A27FlightDepartureCountryName);
            A29FlightDepartureCityName = T000516_A29FlightDepartureCityName[0];
            AssignAttri("", false, "A29FlightDepartureCityName", A29FlightDepartureCityName);
            A25FlightArrivalAirportName = T000516_A25FlightArrivalAirportName[0];
            AssignAttri("", false, "A25FlightArrivalAirportName", A25FlightArrivalAirportName);
            A31FlightArrivalCountryName = T000516_A31FlightArrivalCountryName[0];
            AssignAttri("", false, "A31FlightArrivalCountryName", A31FlightArrivalCountryName);
            A33FlightArrivalCityName = T000516_A33FlightArrivalCityName[0];
            AssignAttri("", false, "A33FlightArrivalCityName", A33FlightArrivalCityName);
            A34FlightPrice = T000516_A34FlightPrice[0];
            AssignAttri("", false, "A34FlightPrice", StringUtil.LTrimStr( A34FlightPrice, 9, 2));
            A35FlightDiscountPercentage = T000516_A35FlightDiscountPercentage[0];
            AssignAttri("", false, "A35FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A35FlightDiscountPercentage), 3, 0));
            A38AirlineName = T000516_A38AirlineName[0];
            AssignAttri("", false, "A38AirlineName", A38AirlineName);
            A39AirlineDiscountPercentage = T000516_A39AirlineDiscountPercentage[0];
            AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A39AirlineDiscountPercentage), 3, 0));
            A37AirlineId = T000516_A37AirlineId[0];
            n37AirlineId = T000516_n37AirlineId[0];
            AssignAttri("", false, "A37AirlineId", StringUtil.LTrimStr( (decimal)(A37AirlineId), 4, 0));
            A22FlightDepartureAirportId = T000516_A22FlightDepartureAirportId[0];
            AssignAttri("", false, "A22FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlightDepartureAirportId), 4, 0));
            A24FlightArrivalAirportId = T000516_A24FlightArrivalAirportId[0];
            AssignAttri("", false, "A24FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A24FlightArrivalAirportId), 4, 0));
            A26FlightDepartureCountryId = T000516_A26FlightDepartureCountryId[0];
            AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
            A28FlightDepartureCityId = T000516_A28FlightDepartureCityId[0];
            AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A28FlightDepartureCityId), 4, 0));
            A30FlightArrivalCountryId = T000516_A30FlightArrivalCountryId[0];
            AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
            A32FlightArrivalCityId = T000516_A32FlightArrivalCityId[0];
            AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A32FlightArrivalCityId), 4, 0));
            A42FlightCapacity = T000516_A42FlightCapacity[0];
            n42FlightCapacity = T000516_n42FlightCapacity[0];
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            ZM056( -6) ;
         }
         pr_default.close(12);
         OnLoadActions056( ) ;
      }

      protected void OnLoadActions056( )
      {
         O42FlightCapacity = A42FlightCapacity;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         if ( A39AirlineDiscountPercentage >= A35FlightDiscountPercentage )
         {
            A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A39AirlineDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
         }
         else
         {
            A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A35FlightDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
         }
      }

      protected void CheckExtendedTable056( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000514 */
         pr_default.execute(11, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A42FlightCapacity = T000514_A42FlightCapacity[0];
            n42FlightCapacity = T000514_n42FlightCapacity[0];
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         else
         {
            nIsDirty_6 = 1;
            A42FlightCapacity = 0;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         pr_default.close(11);
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A22FlightDepartureAirportId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightDepartureAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23FlightDepartureAirportName = T00057_A23FlightDepartureAirportName[0];
         AssignAttri("", false, "A23FlightDepartureAirportName", A23FlightDepartureAirportName);
         A26FlightDepartureCountryId = T00057_A26FlightDepartureCountryId[0];
         AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
         A28FlightDepartureCityId = T00057_A28FlightDepartureCityId[0];
         AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A28FlightDepartureCityId), 4, 0));
         pr_default.close(5);
         /* Using cursor T00059 */
         pr_default.execute(7, new Object[] {A26FlightDepartureCountryId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECOUNTRYID");
            AnyError = 1;
         }
         A27FlightDepartureCountryName = T00059_A27FlightDepartureCountryName[0];
         AssignAttri("", false, "A27FlightDepartureCountryName", A27FlightDepartureCountryName);
         pr_default.close(7);
         /* Using cursor T000510 */
         pr_default.execute(8, new Object[] {A26FlightDepartureCountryId, A28FlightDepartureCityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECITYID");
            AnyError = 1;
         }
         A29FlightDepartureCityName = T000510_A29FlightDepartureCityName[0];
         AssignAttri("", false, "A29FlightDepartureCityName", A29FlightDepartureCityName);
         pr_default.close(8);
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A24FlightArrivalAirportId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightArrivalAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25FlightArrivalAirportName = T00058_A25FlightArrivalAirportName[0];
         AssignAttri("", false, "A25FlightArrivalAirportName", A25FlightArrivalAirportName);
         A30FlightArrivalCountryId = T00058_A30FlightArrivalCountryId[0];
         AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
         A32FlightArrivalCityId = T00058_A32FlightArrivalCityId[0];
         AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A32FlightArrivalCityId), 4, 0));
         pr_default.close(6);
         /* Using cursor T000511 */
         pr_default.execute(9, new Object[] {A30FlightArrivalCountryId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCOUNTRYID");
            AnyError = 1;
         }
         A31FlightArrivalCountryName = T000511_A31FlightArrivalCountryName[0];
         AssignAttri("", false, "A31FlightArrivalCountryName", A31FlightArrivalCountryName);
         pr_default.close(9);
         /* Using cursor T000512 */
         pr_default.execute(10, new Object[] {A30FlightArrivalCountryId, A32FlightArrivalCityId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCITYID");
            AnyError = 1;
         }
         A33FlightArrivalCityName = T000512_A33FlightArrivalCityName[0];
         AssignAttri("", false, "A33FlightArrivalCityName", A33FlightArrivalCityName);
         pr_default.close(10);
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {n37AirlineId, A37AirlineId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A37AirlineId) ) )
            {
               GX_msglist.addItem("No matching 'Airlane'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A38AirlineName = T00056_A38AirlineName[0];
         AssignAttri("", false, "A38AirlineName", A38AirlineName);
         A39AirlineDiscountPercentage = T00056_A39AirlineDiscountPercentage[0];
         AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A39AirlineDiscountPercentage), 3, 0));
         pr_default.close(4);
         if ( A39AirlineDiscountPercentage >= A35FlightDiscountPercentage )
         {
            nIsDirty_6 = 1;
            A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A39AirlineDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
         }
         else
         {
            nIsDirty_6 = 1;
            A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A35FlightDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
         }
      }

      protected void CloseExtendedTableCursors056( )
      {
         pr_default.close(11);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( short A19FlightId )
      {
         /* Using cursor T000518 */
         pr_default.execute(13, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A42FlightCapacity = T000518_A42FlightCapacity[0];
            n42FlightCapacity = T000518_n42FlightCapacity[0];
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         else
         {
            A42FlightCapacity = 0;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A42FlightCapacity), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_8( short A22FlightDepartureAirportId )
      {
         /* Using cursor T000519 */
         pr_default.execute(14, new Object[] {A22FlightDepartureAirportId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightDepartureAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A23FlightDepartureAirportName = T000519_A23FlightDepartureAirportName[0];
         AssignAttri("", false, "A23FlightDepartureAirportName", A23FlightDepartureAirportName);
         A26FlightDepartureCountryId = T000519_A26FlightDepartureCountryId[0];
         AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
         A28FlightDepartureCityId = T000519_A28FlightDepartureCityId[0];
         AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A28FlightDepartureCityId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A23FlightDepartureAirportName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A26FlightDepartureCountryId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlightDepartureCityId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_10( short A26FlightDepartureCountryId )
      {
         /* Using cursor T000520 */
         pr_default.execute(15, new Object[] {A26FlightDepartureCountryId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECOUNTRYID");
            AnyError = 1;
         }
         A27FlightDepartureCountryName = T000520_A27FlightDepartureCountryName[0];
         AssignAttri("", false, "A27FlightDepartureCountryName", A27FlightDepartureCountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A27FlightDepartureCountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_11( short A26FlightDepartureCountryId ,
                                short A28FlightDepartureCityId )
      {
         /* Using cursor T000521 */
         pr_default.execute(16, new Object[] {A26FlightDepartureCountryId, A28FlightDepartureCityId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECITYID");
            AnyError = 1;
         }
         A29FlightDepartureCityName = T000521_A29FlightDepartureCityName[0];
         AssignAttri("", false, "A29FlightDepartureCityName", A29FlightDepartureCityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A29FlightDepartureCityName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_9( short A24FlightArrivalAirportId )
      {
         /* Using cursor T000522 */
         pr_default.execute(17, new Object[] {A24FlightArrivalAirportId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightArrivalAirportId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25FlightArrivalAirportName = T000522_A25FlightArrivalAirportName[0];
         AssignAttri("", false, "A25FlightArrivalAirportName", A25FlightArrivalAirportName);
         A30FlightArrivalCountryId = T000522_A30FlightArrivalCountryId[0];
         AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
         A32FlightArrivalCityId = T000522_A32FlightArrivalCityId[0];
         AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A32FlightArrivalCityId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A25FlightArrivalAirportName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30FlightArrivalCountryId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A32FlightArrivalCityId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_12( short A30FlightArrivalCountryId )
      {
         /* Using cursor T000523 */
         pr_default.execute(18, new Object[] {A30FlightArrivalCountryId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCOUNTRYID");
            AnyError = 1;
         }
         A31FlightArrivalCountryName = T000523_A31FlightArrivalCountryName[0];
         AssignAttri("", false, "A31FlightArrivalCountryName", A31FlightArrivalCountryName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A31FlightArrivalCountryName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_13( short A30FlightArrivalCountryId ,
                                short A32FlightArrivalCityId )
      {
         /* Using cursor T000524 */
         pr_default.execute(19, new Object[] {A30FlightArrivalCountryId, A32FlightArrivalCityId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCITYID");
            AnyError = 1;
         }
         A33FlightArrivalCityName = T000524_A33FlightArrivalCityName[0];
         AssignAttri("", false, "A33FlightArrivalCityName", A33FlightArrivalCityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A33FlightArrivalCityName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_7( short A37AirlineId )
      {
         /* Using cursor T000525 */
         pr_default.execute(20, new Object[] {n37AirlineId, A37AirlineId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A37AirlineId) ) )
            {
               GX_msglist.addItem("No matching 'Airlane'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A38AirlineName = T000525_A38AirlineName[0];
         AssignAttri("", false, "A38AirlineName", A38AirlineName);
         A39AirlineDiscountPercentage = T000525_A39AirlineDiscountPercentage[0];
         AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A39AirlineDiscountPercentage), 3, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A38AirlineName))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A39AirlineDiscountPercentage), 3, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey056( )
      {
         /* Using cursor T000526 */
         pr_default.execute(21, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM056( 6) ;
            RcdFound6 = 1;
            A19FlightId = T00055_A19FlightId[0];
            AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
            A34FlightPrice = T00055_A34FlightPrice[0];
            AssignAttri("", false, "A34FlightPrice", StringUtil.LTrimStr( A34FlightPrice, 9, 2));
            A35FlightDiscountPercentage = T00055_A35FlightDiscountPercentage[0];
            AssignAttri("", false, "A35FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A35FlightDiscountPercentage), 3, 0));
            A37AirlineId = T00055_A37AirlineId[0];
            n37AirlineId = T00055_n37AirlineId[0];
            AssignAttri("", false, "A37AirlineId", StringUtil.LTrimStr( (decimal)(A37AirlineId), 4, 0));
            A22FlightDepartureAirportId = T00055_A22FlightDepartureAirportId[0];
            AssignAttri("", false, "A22FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlightDepartureAirportId), 4, 0));
            A24FlightArrivalAirportId = T00055_A24FlightArrivalAirportId[0];
            AssignAttri("", false, "A24FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A24FlightArrivalAirportId), 4, 0));
            Z19FlightId = A19FlightId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load056( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey056( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey056( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey056( ) ;
         if ( RcdFound6 == 0 )
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
         RcdFound6 = 0;
         /* Using cursor T000527 */
         pr_default.execute(22, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( T000527_A19FlightId[0] < A19FlightId ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( T000527_A19FlightId[0] > A19FlightId ) ) )
            {
               A19FlightId = T000527_A19FlightId[0];
               AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000528 */
         pr_default.execute(23, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( T000528_A19FlightId[0] > A19FlightId ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( T000528_A19FlightId[0] < A19FlightId ) ) )
            {
               A19FlightId = T000528_A19FlightId[0];
               AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey056( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A42FlightCapacity = O42FlightCapacity;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert056( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A19FlightId != Z19FlightId )
               {
                  A19FlightId = Z19FlightId;
                  AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FLIGHTID");
                  AnyError = 1;
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A42FlightCapacity = O42FlightCapacity;
                  n42FlightCapacity = false;
                  AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  A42FlightCapacity = O42FlightCapacity;
                  n42FlightCapacity = false;
                  AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                  Update056( ) ;
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A19FlightId != Z19FlightId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  A42FlightCapacity = O42FlightCapacity;
                  n42FlightCapacity = false;
                  AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                  GX_FocusControl = edtFlightId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert056( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FLIGHTID");
                     AnyError = 1;
                     GX_FocusControl = edtFlightId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     A42FlightCapacity = O42FlightCapacity;
                     n42FlightCapacity = false;
                     AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                     GX_FocusControl = edtFlightId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert056( ) ;
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
         if ( A19FlightId != Z19FlightId )
         {
            A19FlightId = Z19FlightId;
            AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FLIGHTID");
            AnyError = 1;
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A42FlightCapacity = O42FlightCapacity;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFlightId_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FLIGHTID");
            AnyError = 1;
            GX_FocusControl = edtFlightId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart056( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd056( ) ;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
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
         ScanStart056( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound6 != 0 )
            {
               ScanNext056( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd056( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency056( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00054 */
            pr_default.execute(2, new Object[] {A19FlightId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Flight"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( Z34FlightPrice != T00054_A34FlightPrice[0] ) || ( Z35FlightDiscountPercentage != T00054_A35FlightDiscountPercentage[0] ) || ( Z37AirlineId != T00054_A37AirlineId[0] ) || ( Z22FlightDepartureAirportId != T00054_A22FlightDepartureAirportId[0] ) || ( Z24FlightArrivalAirportId != T00054_A24FlightArrivalAirportId[0] ) )
            {
               if ( Z34FlightPrice != T00054_A34FlightPrice[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightPrice");
                  GXUtil.WriteLogRaw("Old: ",Z34FlightPrice);
                  GXUtil.WriteLogRaw("Current: ",T00054_A34FlightPrice[0]);
               }
               if ( Z35FlightDiscountPercentage != T00054_A35FlightDiscountPercentage[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightDiscountPercentage");
                  GXUtil.WriteLogRaw("Old: ",Z35FlightDiscountPercentage);
                  GXUtil.WriteLogRaw("Current: ",T00054_A35FlightDiscountPercentage[0]);
               }
               if ( Z37AirlineId != T00054_A37AirlineId[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"AirlineId");
                  GXUtil.WriteLogRaw("Old: ",Z37AirlineId);
                  GXUtil.WriteLogRaw("Current: ",T00054_A37AirlineId[0]);
               }
               if ( Z22FlightDepartureAirportId != T00054_A22FlightDepartureAirportId[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightDepartureAirportId");
                  GXUtil.WriteLogRaw("Old: ",Z22FlightDepartureAirportId);
                  GXUtil.WriteLogRaw("Current: ",T00054_A22FlightDepartureAirportId[0]);
               }
               if ( Z24FlightArrivalAirportId != T00054_A24FlightArrivalAirportId[0] )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightArrivalAirportId");
                  GXUtil.WriteLogRaw("Old: ",Z24FlightArrivalAirportId);
                  GXUtil.WriteLogRaw("Current: ",T00054_A24FlightArrivalAirportId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Flight"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM056( 0) ;
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000529 */
                     pr_default.execute(24, new Object[] {A34FlightPrice, A35FlightDiscountPercentage, n37AirlineId, A37AirlineId, A22FlightDepartureAirportId, A24FlightArrivalAirportId});
                     A19FlightId = T000529_A19FlightId[0];
                     AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
                     pr_default.close(24);
                     dsDefault.SmartCacheProvider.SetUpdated("Flight");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel056( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption050( ) ;
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
               Load056( ) ;
            }
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void Update056( )
      {
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable056( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm056( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate056( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000530 */
                     pr_default.execute(25, new Object[] {A34FlightPrice, A35FlightDiscountPercentage, n37AirlineId, A37AirlineId, A22FlightDepartureAirportId, A24FlightArrivalAirportId, A19FlightId});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("Flight");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Flight"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate056( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel056( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption050( ) ;
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
            EndLevel056( ) ;
         }
         CloseExtendedTableCursors056( ) ;
      }

      protected void DeferredUpdate056( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate056( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency056( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls056( ) ;
            AfterConfirm056( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete056( ) ;
               if ( AnyError == 0 )
               {
                  A42FlightCapacity = O42FlightCapacity;
                  n42FlightCapacity = false;
                  AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                  ScanStart0510( ) ;
                  while ( RcdFound10 != 0 )
                  {
                     getByPrimaryKey0510( ) ;
                     Delete0510( ) ;
                     ScanNext0510( ) ;
                     O42FlightCapacity = A42FlightCapacity;
                     n42FlightCapacity = false;
                     AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                  }
                  ScanEnd0510( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000531 */
                     pr_default.execute(26, new Object[] {A19FlightId});
                     pr_default.close(26);
                     dsDefault.SmartCacheProvider.SetUpdated("Flight");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound6 == 0 )
                           {
                              InitAll056( ) ;
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
                           ResetCaption050( ) ;
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel056( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls056( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000533 */
            pr_default.execute(27, new Object[] {A19FlightId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               A42FlightCapacity = T000533_A42FlightCapacity[0];
               n42FlightCapacity = T000533_n42FlightCapacity[0];
               AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            }
            else
            {
               A42FlightCapacity = 0;
               n42FlightCapacity = false;
               AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            }
            pr_default.close(27);
            /* Using cursor T000534 */
            pr_default.execute(28, new Object[] {A22FlightDepartureAirportId});
            A23FlightDepartureAirportName = T000534_A23FlightDepartureAirportName[0];
            AssignAttri("", false, "A23FlightDepartureAirportName", A23FlightDepartureAirportName);
            A26FlightDepartureCountryId = T000534_A26FlightDepartureCountryId[0];
            AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
            A28FlightDepartureCityId = T000534_A28FlightDepartureCityId[0];
            AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A28FlightDepartureCityId), 4, 0));
            pr_default.close(28);
            /* Using cursor T000535 */
            pr_default.execute(29, new Object[] {A26FlightDepartureCountryId});
            A27FlightDepartureCountryName = T000535_A27FlightDepartureCountryName[0];
            AssignAttri("", false, "A27FlightDepartureCountryName", A27FlightDepartureCountryName);
            pr_default.close(29);
            /* Using cursor T000536 */
            pr_default.execute(30, new Object[] {A26FlightDepartureCountryId, A28FlightDepartureCityId});
            A29FlightDepartureCityName = T000536_A29FlightDepartureCityName[0];
            AssignAttri("", false, "A29FlightDepartureCityName", A29FlightDepartureCityName);
            pr_default.close(30);
            /* Using cursor T000537 */
            pr_default.execute(31, new Object[] {A24FlightArrivalAirportId});
            A25FlightArrivalAirportName = T000537_A25FlightArrivalAirportName[0];
            AssignAttri("", false, "A25FlightArrivalAirportName", A25FlightArrivalAirportName);
            A30FlightArrivalCountryId = T000537_A30FlightArrivalCountryId[0];
            AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
            A32FlightArrivalCityId = T000537_A32FlightArrivalCityId[0];
            AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A32FlightArrivalCityId), 4, 0));
            pr_default.close(31);
            /* Using cursor T000538 */
            pr_default.execute(32, new Object[] {A30FlightArrivalCountryId});
            A31FlightArrivalCountryName = T000538_A31FlightArrivalCountryName[0];
            AssignAttri("", false, "A31FlightArrivalCountryName", A31FlightArrivalCountryName);
            pr_default.close(32);
            /* Using cursor T000539 */
            pr_default.execute(33, new Object[] {A30FlightArrivalCountryId, A32FlightArrivalCityId});
            A33FlightArrivalCityName = T000539_A33FlightArrivalCityName[0];
            AssignAttri("", false, "A33FlightArrivalCityName", A33FlightArrivalCityName);
            pr_default.close(33);
            /* Using cursor T000540 */
            pr_default.execute(34, new Object[] {n37AirlineId, A37AirlineId});
            A38AirlineName = T000540_A38AirlineName[0];
            AssignAttri("", false, "A38AirlineName", A38AirlineName);
            A39AirlineDiscountPercentage = T000540_A39AirlineDiscountPercentage[0];
            AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A39AirlineDiscountPercentage), 3, 0));
            pr_default.close(34);
            if ( A39AirlineDiscountPercentage >= A35FlightDiscountPercentage )
            {
               A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A39AirlineDiscountPercentage/ (decimal)(100)));
               AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
            }
            else
            {
               A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A35FlightDiscountPercentage/ (decimal)(100)));
               AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
            }
         }
      }

      protected void ProcessNestedLevel0510( )
      {
         s42FlightCapacity = O42FlightCapacity;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         nGXsfl_138_idx = 0;
         while ( nGXsfl_138_idx < nRC_GXsfl_138 )
         {
            ReadRow0510( ) ;
            if ( ( nRcdExists_10 != 0 ) || ( nIsMod_10 != 0 ) )
            {
               standaloneNotModal0510( ) ;
               GetKey0510( ) ;
               if ( ( nRcdExists_10 == 0 ) && ( nRcdDeleted_10 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0510( ) ;
               }
               else
               {
                  if ( RcdFound10 != 0 )
                  {
                     if ( ( nRcdDeleted_10 != 0 ) && ( nRcdExists_10 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0510( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_10 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0510( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_10 == 0 )
                     {
                        GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtFlightSeatId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O42FlightCapacity = A42FlightCapacity;
               n42FlightCapacity = false;
               AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            }
            ChangePostValue( edtFlightSeatId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( cmbFlightSeatChar_Internalname, StringUtil.RTrim( A43FlightSeatChar)) ;
            ChangePostValue( cmbFlightSeatLocation_Internalname, StringUtil.RTrim( A41FlightSeatLocation)) ;
            ChangePostValue( "ZT_"+"Z40FlightSeatId_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FlightSeatId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z43FlightSeatChar_"+sGXsfl_138_idx, StringUtil.RTrim( Z43FlightSeatChar)) ;
            ChangePostValue( "ZT_"+"Z41FlightSeatLocation_"+sGXsfl_138_idx, StringUtil.RTrim( Z41FlightSeatLocation)) ;
            ChangePostValue( "nRcdDeleted_10_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_10_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_10_"+sGXsfl_138_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ".", ""))) ;
            if ( nIsMod_10 != 0 )
            {
               ChangePostValue( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         if ( A42FlightCapacity < 8 )
         {
            GX_msglist.addItem("The seat quantity mustn't be less than eight", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
         InitAll0510( ) ;
         if ( AnyError != 0 )
         {
            O42FlightCapacity = s42FlightCapacity;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         nRcdExists_10 = 0;
         nIsMod_10 = 0;
         nRcdDeleted_10 = 0;
      }

      protected void ProcessLevel056( )
      {
         /* Save parent mode. */
         sMode6 = Gx_mode;
         ProcessNestedLevel0510( ) ;
         if ( AnyError != 0 )
         {
            O42FlightCapacity = s42FlightCapacity;
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel056( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete056( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(34);
            pr_default.close(28);
            pr_default.close(31);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(32);
            pr_default.close(33);
            pr_default.close(27);
            context.CommitDataStores("flight",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(34);
            pr_default.close(28);
            pr_default.close(31);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(32);
            pr_default.close(33);
            pr_default.close(27);
            context.RollbackDataStores("flight",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart056( )
      {
         /* Using cursor T000541 */
         pr_default.execute(35);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound6 = 1;
            A19FlightId = T000541_A19FlightId[0];
            AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext056( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound6 = 1;
            A19FlightId = T000541_A19FlightId[0];
            AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
         }
      }

      protected void ScanEnd056( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm056( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert056( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate056( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete056( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete056( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate056( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes056( )
      {
         edtFlightId_Enabled = 0;
         AssignProp("", false, edtFlightId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightId_Enabled), 5, 0), true);
         edtFlightDepartureAirportId_Enabled = 0;
         AssignProp("", false, edtFlightDepartureAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureAirportId_Enabled), 5, 0), true);
         edtFlightDepartureAirportName_Enabled = 0;
         AssignProp("", false, edtFlightDepartureAirportName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureAirportName_Enabled), 5, 0), true);
         edtFlightDepartureCountryId_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCountryId_Enabled), 5, 0), true);
         edtFlightDepartureCountryName_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCountryName_Enabled), 5, 0), true);
         edtFlightDepartureCityId_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCityId_Enabled), 5, 0), true);
         edtFlightDepartureCityName_Enabled = 0;
         AssignProp("", false, edtFlightDepartureCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDepartureCityName_Enabled), 5, 0), true);
         edtFlightArrivalAirportId_Enabled = 0;
         AssignProp("", false, edtFlightArrivalAirportId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalAirportId_Enabled), 5, 0), true);
         edtFlightArrivalAirportName_Enabled = 0;
         AssignProp("", false, edtFlightArrivalAirportName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalAirportName_Enabled), 5, 0), true);
         edtFlightArrivalCountryId_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCountryId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCountryId_Enabled), 5, 0), true);
         edtFlightArrivalCountryName_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCountryName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCountryName_Enabled), 5, 0), true);
         edtFlightArrivalCityId_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCityId_Enabled), 5, 0), true);
         edtFlightArrivalCityName_Enabled = 0;
         AssignProp("", false, edtFlightArrivalCityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightArrivalCityName_Enabled), 5, 0), true);
         edtFlightPrice_Enabled = 0;
         AssignProp("", false, edtFlightPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightPrice_Enabled), 5, 0), true);
         edtFlightDiscountPercentage_Enabled = 0;
         AssignProp("", false, edtFlightDiscountPercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightDiscountPercentage_Enabled), 5, 0), true);
         edtAirlineId_Enabled = 0;
         AssignProp("", false, edtAirlineId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineId_Enabled), 5, 0), true);
         edtAirlineName_Enabled = 0;
         AssignProp("", false, edtAirlineName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineName_Enabled), 5, 0), true);
         edtAirlineDiscountPercentage_Enabled = 0;
         AssignProp("", false, edtAirlineDiscountPercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAirlineDiscountPercentage_Enabled), 5, 0), true);
         edtFlightFinalPrice_Enabled = 0;
         AssignProp("", false, edtFlightFinalPrice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightFinalPrice_Enabled), 5, 0), true);
         edtFlightCapacity_Enabled = 0;
         AssignProp("", false, edtFlightCapacity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightCapacity_Enabled), 5, 0), true);
      }

      protected void ZM0510( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z41FlightSeatLocation = T00053_A41FlightSeatLocation[0];
            }
            else
            {
               Z41FlightSeatLocation = A41FlightSeatLocation;
            }
         }
         if ( GX_JID == -15 )
         {
            Z19FlightId = A19FlightId;
            Z40FlightSeatId = A40FlightSeatId;
            Z43FlightSeatChar = A43FlightSeatChar;
            Z41FlightSeatLocation = A41FlightSeatLocation;
         }
      }

      protected void standaloneNotModal0510( )
      {
      }

      protected void standaloneModal0510( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtFlightSeatId_Enabled = 0;
            AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
         else
         {
            edtFlightSeatId_Enabled = 1;
            AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            cmbFlightSeatChar.Enabled = 0;
            AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
         else
         {
            cmbFlightSeatChar.Enabled = 1;
            AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         }
      }

      protected void Load0510( )
      {
         /* Using cursor T000542 */
         pr_default.execute(36, new Object[] {A19FlightId, A40FlightSeatId, A43FlightSeatChar});
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound10 = 1;
            A41FlightSeatLocation = T000542_A41FlightSeatLocation[0];
            ZM0510( -15) ;
         }
         pr_default.close(36);
         OnLoadActions0510( ) ;
      }

      protected void OnLoadActions0510( )
      {
         if ( IsIns( )  )
         {
            A42FlightCapacity = (short)(O42FlightCapacity+1);
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A42FlightCapacity = O42FlightCapacity;
               n42FlightCapacity = false;
               AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A42FlightCapacity = (short)(O42FlightCapacity-1);
                  n42FlightCapacity = false;
                  AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable0510( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         standaloneModal0510( ) ;
         if ( ! ( ( StringUtil.StrCmp(A43FlightSeatChar, "A") == 0 ) || ( StringUtil.StrCmp(A43FlightSeatChar, "B") == 0 ) || ( StringUtil.StrCmp(A43FlightSeatChar, "C") == 0 ) || ( StringUtil.StrCmp(A43FlightSeatChar, "D") == 0 ) || ( StringUtil.StrCmp(A43FlightSeatChar, "E") == 0 ) || ( StringUtil.StrCmp(A43FlightSeatChar, "F") == 0 ) ) )
         {
            GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_138_idx;
            GX_msglist.addItem("Field Flight Seat Char is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbFlightSeatChar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A41FlightSeatLocation, "W") == 0 ) || ( StringUtil.StrCmp(A41FlightSeatLocation, "M") == 0 ) || ( StringUtil.StrCmp(A41FlightSeatLocation, "A") == 0 ) ) )
         {
            GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_138_idx;
            GX_msglist.addItem("Field Flight Seat Location is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbFlightSeatLocation_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  )
         {
            nIsDirty_10 = 1;
            A42FlightCapacity = (short)(O42FlightCapacity+1);
            n42FlightCapacity = false;
            AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_10 = 1;
               A42FlightCapacity = O42FlightCapacity;
               n42FlightCapacity = false;
               AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_10 = 1;
                  A42FlightCapacity = (short)(O42FlightCapacity-1);
                  n42FlightCapacity = false;
                  AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
               }
            }
         }
      }

      protected void CloseExtendedTableCursors0510( )
      {
      }

      protected void enableDisable0510( )
      {
      }

      protected void GetKey0510( )
      {
         /* Using cursor T000543 */
         pr_default.execute(37, new Object[] {A19FlightId, A40FlightSeatId, A43FlightSeatChar});
         if ( (pr_default.getStatus(37) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(37);
      }

      protected void getByPrimaryKey0510( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A19FlightId, A40FlightSeatId, A43FlightSeatChar});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0510( 15) ;
            RcdFound10 = 1;
            InitializeNonKey0510( ) ;
            A40FlightSeatId = T00053_A40FlightSeatId[0];
            A43FlightSeatChar = T00053_A43FlightSeatChar[0];
            A41FlightSeatLocation = T00053_A41FlightSeatLocation[0];
            Z19FlightId = A19FlightId;
            Z40FlightSeatId = A40FlightSeatId;
            Z43FlightSeatChar = A43FlightSeatChar;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0510( ) ;
            Load0510( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0510( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0510( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0510( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0510( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A19FlightId, A40FlightSeatId, A43FlightSeatChar});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FlightSeat"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z41FlightSeatLocation, T00052_A41FlightSeatLocation[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z41FlightSeatLocation, T00052_A41FlightSeatLocation[0]) != 0 )
               {
                  GXUtil.WriteLog("flight:[seudo value changed for attri]"+"FlightSeatLocation");
                  GXUtil.WriteLogRaw("Old: ",Z41FlightSeatLocation);
                  GXUtil.WriteLogRaw("Current: ",T00052_A41FlightSeatLocation[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FlightSeat"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0510( )
      {
         BeforeValidate0510( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0510( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0510( 0) ;
            CheckOptimisticConcurrency0510( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0510( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0510( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000544 */
                     pr_default.execute(38, new Object[] {A19FlightId, A40FlightSeatId, A43FlightSeatChar, A41FlightSeatLocation});
                     pr_default.close(38);
                     dsDefault.SmartCacheProvider.SetUpdated("FlightSeat");
                     if ( (pr_default.getStatus(38) == 1) )
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
               Load0510( ) ;
            }
            EndLevel0510( ) ;
         }
         CloseExtendedTableCursors0510( ) ;
      }

      protected void Update0510( )
      {
         BeforeValidate0510( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0510( ) ;
         }
         if ( ( nIsMod_10 != 0 ) || ( nIsDirty_10 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0510( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0510( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0510( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000545 */
                        pr_default.execute(39, new Object[] {A41FlightSeatLocation, A19FlightId, A40FlightSeatId, A43FlightSeatChar});
                        pr_default.close(39);
                        dsDefault.SmartCacheProvider.SetUpdated("FlightSeat");
                        if ( (pr_default.getStatus(39) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FlightSeat"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0510( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0510( ) ;
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
               EndLevel0510( ) ;
            }
         }
         CloseExtendedTableCursors0510( ) ;
      }

      protected void DeferredUpdate0510( )
      {
      }

      protected void Delete0510( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0510( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0510( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0510( ) ;
            AfterConfirm0510( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0510( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000546 */
                  pr_default.execute(40, new Object[] {A19FlightId, A40FlightSeatId, A43FlightSeatChar});
                  pr_default.close(40);
                  dsDefault.SmartCacheProvider.SetUpdated("FlightSeat");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0510( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0510( )
      {
         standaloneModal0510( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A42FlightCapacity = (short)(O42FlightCapacity+1);
               n42FlightCapacity = false;
               AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A42FlightCapacity = O42FlightCapacity;
                  n42FlightCapacity = false;
                  AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A42FlightCapacity = (short)(O42FlightCapacity-1);
                     n42FlightCapacity = false;
                     AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
                  }
               }
            }
         }
      }

      protected void EndLevel0510( )
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

      public void ScanStart0510( )
      {
         /* Scan By routine */
         /* Using cursor T000547 */
         pr_default.execute(41, new Object[] {A19FlightId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound10 = 1;
            A40FlightSeatId = T000547_A40FlightSeatId[0];
            A43FlightSeatChar = T000547_A43FlightSeatChar[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0510( )
      {
         /* Scan next routine */
         pr_default.readNext(41);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound10 = 1;
            A40FlightSeatId = T000547_A40FlightSeatId[0];
            A43FlightSeatChar = T000547_A43FlightSeatChar[0];
         }
      }

      protected void ScanEnd0510( )
      {
         pr_default.close(41);
      }

      protected void AfterConfirm0510( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0510( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0510( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0510( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0510( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0510( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0510( )
      {
         edtFlightSeatId_Enabled = 0;
         AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
         cmbFlightSeatChar.Enabled = 0;
         AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         cmbFlightSeatLocation.Enabled = 0;
         AssignProp("", false, cmbFlightSeatLocation_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0), !bGXsfl_138_Refreshing);
      }

      protected void send_integrity_lvl_hashes0510( )
      {
      }

      protected void send_integrity_lvl_hashes056( )
      {
      }

      protected void SubsflControlProps_13810( )
      {
         edtFlightSeatId_Internalname = "FLIGHTSEATID_"+sGXsfl_138_idx;
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR_"+sGXsfl_138_idx;
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION_"+sGXsfl_138_idx;
      }

      protected void SubsflControlProps_fel_13810( )
      {
         edtFlightSeatId_Internalname = "FLIGHTSEATID_"+sGXsfl_138_fel_idx;
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR_"+sGXsfl_138_fel_idx;
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION_"+sGXsfl_138_fel_idx;
      }

      protected void AddRow0510( )
      {
         nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_13810( ) ;
         SendRow0510( ) ;
      }

      protected void SendRow0510( )
      {
         Gridflight_seatRow = GXWebRow.GetNew(context);
         if ( subGridflight_seat_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridflight_seat_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
            {
               subGridflight_seat_Linesclass = subGridflight_seat_Class+"Odd";
            }
         }
         else if ( subGridflight_seat_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridflight_seat_Backstyle = 0;
            subGridflight_seat_Backcolor = subGridflight_seat_Allbackcolor;
            if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
            {
               subGridflight_seat_Linesclass = subGridflight_seat_Class+"Uniform";
            }
         }
         else if ( subGridflight_seat_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridflight_seat_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
            {
               subGridflight_seat_Linesclass = subGridflight_seat_Class+"Odd";
            }
            subGridflight_seat_Backcolor = (int)(0x0);
         }
         else if ( subGridflight_seat_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridflight_seat_Backstyle = 1;
            if ( ((int)((nGXsfl_138_idx) % (2))) == 0 )
            {
               subGridflight_seat_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
               {
                  subGridflight_seat_Linesclass = subGridflight_seat_Class+"Even";
               }
            }
            else
            {
               subGridflight_seat_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridflight_seat_Class, "") != 0 )
               {
                  subGridflight_seat_Linesclass = subGridflight_seat_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_138_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 139,'',false,'" + sGXsfl_138_idx + "',138)\"";
         ROClassString = "Attribute";
         Gridflight_seatRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFlightSeatId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FlightSeatId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A40FlightSeatId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,139);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFlightSeatId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtFlightSeatId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)138,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_138_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 140,'',false,'" + sGXsfl_138_idx + "',138)\"";
         GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_138_idx;
         cmbFlightSeatChar.Name = GXCCtl;
         cmbFlightSeatChar.WebTags = "";
         cmbFlightSeatChar.addItem("A", "A", 0);
         cmbFlightSeatChar.addItem("B", "B", 0);
         cmbFlightSeatChar.addItem("C", "C", 0);
         cmbFlightSeatChar.addItem("D", "D", 0);
         cmbFlightSeatChar.addItem("E", "E", 0);
         cmbFlightSeatChar.addItem("F", "F", 0);
         if ( cmbFlightSeatChar.ItemCount > 0 )
         {
            A43FlightSeatChar = cmbFlightSeatChar.getValidValue(A43FlightSeatChar);
         }
         /* ComboBox */
         Gridflight_seatRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlightSeatChar,(string)cmbFlightSeatChar_Internalname,StringUtil.RTrim( A43FlightSeatChar),(short)1,(string)cmbFlightSeatChar_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbFlightSeatChar.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,140);\"",(string)"",(bool)true,(short)1});
         cmbFlightSeatChar.CurrentValue = StringUtil.RTrim( A43FlightSeatChar);
         AssignProp("", false, cmbFlightSeatChar_Internalname, "Values", (string)(cmbFlightSeatChar.ToJavascriptSource()), !bGXsfl_138_Refreshing);
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_10_" + sGXsfl_138_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 141,'',false,'" + sGXsfl_138_idx + "',138)\"";
         if ( ( cmbFlightSeatLocation.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_138_idx;
            cmbFlightSeatLocation.Name = GXCCtl;
            cmbFlightSeatLocation.WebTags = "";
            cmbFlightSeatLocation.addItem("W", "Window", 0);
            cmbFlightSeatLocation.addItem("M", "Middle", 0);
            cmbFlightSeatLocation.addItem("A", "Aisle", 0);
            if ( cmbFlightSeatLocation.ItemCount > 0 )
            {
               A41FlightSeatLocation = cmbFlightSeatLocation.getValidValue(A41FlightSeatLocation);
            }
         }
         /* ComboBox */
         Gridflight_seatRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbFlightSeatLocation,(string)cmbFlightSeatLocation_Internalname,StringUtil.RTrim( A41FlightSeatLocation),(short)1,(string)cmbFlightSeatLocation_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbFlightSeatLocation.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"",(string)"",(bool)true,(short)1});
         cmbFlightSeatLocation.CurrentValue = StringUtil.RTrim( A41FlightSeatLocation);
         AssignProp("", false, cmbFlightSeatLocation_Internalname, "Values", (string)(cmbFlightSeatLocation.ToJavascriptSource()), !bGXsfl_138_Refreshing);
         context.httpAjaxContext.ajax_sending_grid_row(Gridflight_seatRow);
         send_integrity_lvl_hashes0510( ) ;
         GXCCtl = "Z40FlightSeatId_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FlightSeatId), 4, 0, ".", "")));
         GXCCtl = "Z43FlightSeatChar_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z43FlightSeatChar));
         GXCCtl = "Z41FlightSeatLocation_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z41FlightSeatLocation));
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_10), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_10_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_10), 4, 0, ".", "")));
         GXCCtl = "nIsMod_10_" + sGXsfl_138_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_10), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtFlightSeatId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatChar.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbFlightSeatLocation.Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridflight_seatContainer.AddRow(Gridflight_seatRow);
      }

      protected void ReadRow0510( )
      {
         nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_13810( ) ;
         edtFlightSeatId_Enabled = (int)(context.localUtil.CToN( cgiGet( "FLIGHTSEATID_"+sGXsfl_138_idx+"Enabled"), ".", ","));
         cmbFlightSeatChar.Enabled = (int)(context.localUtil.CToN( cgiGet( "FLIGHTSEATCHAR_"+sGXsfl_138_idx+"Enabled"), ".", ","));
         cmbFlightSeatLocation.Enabled = (int)(context.localUtil.CToN( cgiGet( "FLIGHTSEATLOCATION_"+sGXsfl_138_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtFlightSeatId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFlightSeatId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "FLIGHTSEATID_" + sGXsfl_138_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtFlightSeatId_Internalname;
            wbErr = true;
            A40FlightSeatId = 0;
         }
         else
         {
            A40FlightSeatId = (short)(context.localUtil.CToN( cgiGet( edtFlightSeatId_Internalname), ".", ","));
         }
         cmbFlightSeatChar.Name = cmbFlightSeatChar_Internalname;
         cmbFlightSeatChar.CurrentValue = cgiGet( cmbFlightSeatChar_Internalname);
         A43FlightSeatChar = cgiGet( cmbFlightSeatChar_Internalname);
         cmbFlightSeatLocation.Name = cmbFlightSeatLocation_Internalname;
         cmbFlightSeatLocation.CurrentValue = cgiGet( cmbFlightSeatLocation_Internalname);
         A41FlightSeatLocation = cgiGet( cmbFlightSeatLocation_Internalname);
         GXCCtl = "Z40FlightSeatId_" + sGXsfl_138_idx;
         Z40FlightSeatId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z43FlightSeatChar_" + sGXsfl_138_idx;
         Z43FlightSeatChar = cgiGet( GXCCtl);
         GXCCtl = "Z41FlightSeatLocation_" + sGXsfl_138_idx;
         Z41FlightSeatLocation = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_10_" + sGXsfl_138_idx;
         nRcdDeleted_10 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_10_" + sGXsfl_138_idx;
         nRcdExists_10 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_10_" + sGXsfl_138_idx;
         nIsMod_10 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defcmbFlightSeatChar_Enabled = cmbFlightSeatChar.Enabled;
         defedtFlightSeatId_Enabled = edtFlightSeatId_Enabled;
      }

      protected void ConfirmValues050( )
      {
         nGXsfl_138_idx = 0;
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_13810( ) ;
         while ( nGXsfl_138_idx < nRC_GXsfl_138 )
         {
            nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_13810( ) ;
            ChangePostValue( "Z40FlightSeatId_"+sGXsfl_138_idx, cgiGet( "ZT_"+"Z40FlightSeatId_"+sGXsfl_138_idx)) ;
            DeletePostValue( "ZT_"+"Z40FlightSeatId_"+sGXsfl_138_idx) ;
            ChangePostValue( "Z43FlightSeatChar_"+sGXsfl_138_idx, cgiGet( "ZT_"+"Z43FlightSeatChar_"+sGXsfl_138_idx)) ;
            DeletePostValue( "ZT_"+"Z43FlightSeatChar_"+sGXsfl_138_idx) ;
            ChangePostValue( "Z41FlightSeatLocation_"+sGXsfl_138_idx, cgiGet( "ZT_"+"Z41FlightSeatLocation_"+sGXsfl_138_idx)) ;
            DeletePostValue( "ZT_"+"Z41FlightSeatLocation_"+sGXsfl_138_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202361510213177", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("flight.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z19FlightId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19FlightId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34FlightPrice", StringUtil.LTrim( StringUtil.NToC( Z34FlightPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z35FlightDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35FlightDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37AirlineId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22FlightDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22FlightDepartureAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24FlightArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24FlightArrivalAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O42FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O42FlightCapacity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_138", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_138_idx), 8, 0, ".", "")));
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
         return formatLink("flight.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Flight" ;
      }

      public override string GetPgmdesc( )
      {
         return "Flight" ;
      }

      protected void InitializeNonKey056( )
      {
         A36FlightFinalPrice = 0;
         AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrimStr( A36FlightFinalPrice, 9, 2));
         A22FlightDepartureAirportId = 0;
         AssignAttri("", false, "A22FlightDepartureAirportId", StringUtil.LTrimStr( (decimal)(A22FlightDepartureAirportId), 4, 0));
         A23FlightDepartureAirportName = "";
         AssignAttri("", false, "A23FlightDepartureAirportName", A23FlightDepartureAirportName);
         A26FlightDepartureCountryId = 0;
         AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrimStr( (decimal)(A26FlightDepartureCountryId), 4, 0));
         A27FlightDepartureCountryName = "";
         AssignAttri("", false, "A27FlightDepartureCountryName", A27FlightDepartureCountryName);
         A28FlightDepartureCityId = 0;
         AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrimStr( (decimal)(A28FlightDepartureCityId), 4, 0));
         A29FlightDepartureCityName = "";
         AssignAttri("", false, "A29FlightDepartureCityName", A29FlightDepartureCityName);
         A24FlightArrivalAirportId = 0;
         AssignAttri("", false, "A24FlightArrivalAirportId", StringUtil.LTrimStr( (decimal)(A24FlightArrivalAirportId), 4, 0));
         A25FlightArrivalAirportName = "";
         AssignAttri("", false, "A25FlightArrivalAirportName", A25FlightArrivalAirportName);
         A30FlightArrivalCountryId = 0;
         AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrimStr( (decimal)(A30FlightArrivalCountryId), 4, 0));
         A31FlightArrivalCountryName = "";
         AssignAttri("", false, "A31FlightArrivalCountryName", A31FlightArrivalCountryName);
         A32FlightArrivalCityId = 0;
         AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrimStr( (decimal)(A32FlightArrivalCityId), 4, 0));
         A33FlightArrivalCityName = "";
         AssignAttri("", false, "A33FlightArrivalCityName", A33FlightArrivalCityName);
         A34FlightPrice = 0;
         AssignAttri("", false, "A34FlightPrice", StringUtil.LTrimStr( A34FlightPrice, 9, 2));
         A35FlightDiscountPercentage = 0;
         AssignAttri("", false, "A35FlightDiscountPercentage", StringUtil.LTrimStr( (decimal)(A35FlightDiscountPercentage), 3, 0));
         A37AirlineId = 0;
         n37AirlineId = false;
         AssignAttri("", false, "A37AirlineId", StringUtil.LTrimStr( (decimal)(A37AirlineId), 4, 0));
         n37AirlineId = ((0==A37AirlineId) ? true : false);
         A38AirlineName = "";
         AssignAttri("", false, "A38AirlineName", A38AirlineName);
         A39AirlineDiscountPercentage = 0;
         AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrimStr( (decimal)(A39AirlineDiscountPercentage), 3, 0));
         A42FlightCapacity = 0;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         O42FlightCapacity = A42FlightCapacity;
         n42FlightCapacity = false;
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrimStr( (decimal)(A42FlightCapacity), 4, 0));
         Z34FlightPrice = 0;
         Z35FlightDiscountPercentage = 0;
         Z37AirlineId = 0;
         Z22FlightDepartureAirportId = 0;
         Z24FlightArrivalAirportId = 0;
      }

      protected void InitAll056( )
      {
         A19FlightId = 0;
         AssignAttri("", false, "A19FlightId", StringUtil.LTrimStr( (decimal)(A19FlightId), 4, 0));
         InitializeNonKey056( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0510( )
      {
         A41FlightSeatLocation = "";
         Z41FlightSeatLocation = "";
      }

      protected void InitAll0510( )
      {
         A40FlightSeatId = 0;
         A43FlightSeatChar = "";
         InitializeNonKey0510( ) ;
      }

      protected void StandaloneModalInsert0510( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202361510213188", true, true);
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
         context.AddJavascriptSource("flight.js", "?202361510213188", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties10( )
      {
         cmbFlightSeatChar.Enabled = defcmbFlightSeatChar_Enabled;
         AssignProp("", false, cmbFlightSeatChar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFlightSeatChar.Enabled), 5, 0), !bGXsfl_138_Refreshing);
         edtFlightSeatId_Enabled = defedtFlightSeatId_Enabled;
         AssignProp("", false, edtFlightSeatId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFlightSeatId_Enabled), 5, 0), !bGXsfl_138_Refreshing);
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
         edtFlightId_Internalname = "FLIGHTID";
         edtFlightDepartureAirportId_Internalname = "FLIGHTDEPARTUREAIRPORTID";
         edtFlightDepartureAirportName_Internalname = "FLIGHTDEPARTUREAIRPORTNAME";
         edtFlightDepartureCountryId_Internalname = "FLIGHTDEPARTURECOUNTRYID";
         edtFlightDepartureCountryName_Internalname = "FLIGHTDEPARTURECOUNTRYNAME";
         edtFlightDepartureCityId_Internalname = "FLIGHTDEPARTURECITYID";
         edtFlightDepartureCityName_Internalname = "FLIGHTDEPARTURECITYNAME";
         edtFlightArrivalAirportId_Internalname = "FLIGHTARRIVALAIRPORTID";
         edtFlightArrivalAirportName_Internalname = "FLIGHTARRIVALAIRPORTNAME";
         edtFlightArrivalCountryId_Internalname = "FLIGHTARRIVALCOUNTRYID";
         edtFlightArrivalCountryName_Internalname = "FLIGHTARRIVALCOUNTRYNAME";
         edtFlightArrivalCityId_Internalname = "FLIGHTARRIVALCITYID";
         edtFlightArrivalCityName_Internalname = "FLIGHTARRIVALCITYNAME";
         edtFlightPrice_Internalname = "FLIGHTPRICE";
         edtFlightDiscountPercentage_Internalname = "FLIGHTDISCOUNTPERCENTAGE";
         edtAirlineId_Internalname = "AIRLINEID";
         edtAirlineName_Internalname = "AIRLINENAME";
         edtAirlineDiscountPercentage_Internalname = "AIRLINEDISCOUNTPERCENTAGE";
         edtFlightFinalPrice_Internalname = "FLIGHTFINALPRICE";
         edtFlightCapacity_Internalname = "FLIGHTCAPACITY";
         lblTitleseat_Internalname = "TITLESEAT";
         edtFlightSeatId_Internalname = "FLIGHTSEATID";
         cmbFlightSeatChar_Internalname = "FLIGHTSEATCHAR";
         cmbFlightSeatLocation_Internalname = "FLIGHTSEATLOCATION";
         divSeattable_Internalname = "SEATTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_22_Internalname = "PROMPT_22";
         imgprompt_24_Internalname = "PROMPT_24";
         imgprompt_37_Internalname = "PROMPT_37";
         subGridflight_seat_Internalname = "GRIDFLIGHT_SEAT";
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
         Form.Caption = "Flight";
         cmbFlightSeatLocation_Jsonclick = "";
         cmbFlightSeatChar_Jsonclick = "";
         edtFlightSeatId_Jsonclick = "";
         subGridflight_seat_Class = "Grid";
         subGridflight_seat_Backcolorstyle = 0;
         subGridflight_seat_Allowcollapsing = 0;
         subGridflight_seat_Allowselection = 0;
         cmbFlightSeatLocation.Enabled = 1;
         cmbFlightSeatChar.Enabled = 1;
         edtFlightSeatId_Enabled = 1;
         subGridflight_seat_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFlightCapacity_Jsonclick = "";
         edtFlightCapacity_Enabled = 0;
         edtFlightFinalPrice_Jsonclick = "";
         edtFlightFinalPrice_Enabled = 0;
         edtAirlineDiscountPercentage_Jsonclick = "";
         edtAirlineDiscountPercentage_Enabled = 0;
         edtAirlineName_Jsonclick = "";
         edtAirlineName_Enabled = 0;
         imgprompt_37_Visible = 1;
         imgprompt_37_Link = "";
         edtAirlineId_Jsonclick = "";
         edtAirlineId_Enabled = 1;
         edtFlightDiscountPercentage_Jsonclick = "";
         edtFlightDiscountPercentage_Enabled = 1;
         edtFlightPrice_Jsonclick = "";
         edtFlightPrice_Enabled = 1;
         edtFlightArrivalCityName_Jsonclick = "";
         edtFlightArrivalCityName_Enabled = 0;
         edtFlightArrivalCityId_Jsonclick = "";
         edtFlightArrivalCityId_Enabled = 0;
         edtFlightArrivalCountryName_Jsonclick = "";
         edtFlightArrivalCountryName_Enabled = 0;
         edtFlightArrivalCountryId_Jsonclick = "";
         edtFlightArrivalCountryId_Enabled = 0;
         edtFlightArrivalAirportName_Jsonclick = "";
         edtFlightArrivalAirportName_Enabled = 0;
         imgprompt_24_Visible = 1;
         imgprompt_24_Link = "";
         edtFlightArrivalAirportId_Jsonclick = "";
         edtFlightArrivalAirportId_Enabled = 1;
         edtFlightDepartureCityName_Jsonclick = "";
         edtFlightDepartureCityName_Enabled = 0;
         edtFlightDepartureCityId_Jsonclick = "";
         edtFlightDepartureCityId_Enabled = 0;
         edtFlightDepartureCountryName_Jsonclick = "";
         edtFlightDepartureCountryName_Enabled = 0;
         edtFlightDepartureCountryId_Jsonclick = "";
         edtFlightDepartureCountryId_Enabled = 0;
         edtFlightDepartureAirportName_Jsonclick = "";
         edtFlightDepartureAirportName_Enabled = 0;
         imgprompt_22_Visible = 1;
         imgprompt_22_Link = "";
         edtFlightDepartureAirportId_Jsonclick = "";
         edtFlightDepartureAirportId_Enabled = 1;
         edtFlightId_Jsonclick = "";
         edtFlightId_Enabled = 1;
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

      protected void gxnrGridflight_seat_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_13810( ) ;
         while ( nGXsfl_138_idx <= nRC_GXsfl_138 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0510( ) ;
            standaloneModal0510( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0510( ) ;
            nGXsfl_138_idx = (int)(nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_13810( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridflight_seatContainer)) ;
         /* End function gxnrGridflight_seat_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "FLIGHTSEATCHAR_" + sGXsfl_138_idx;
         cmbFlightSeatChar.Name = GXCCtl;
         cmbFlightSeatChar.WebTags = "";
         cmbFlightSeatChar.addItem("A", "A", 0);
         cmbFlightSeatChar.addItem("B", "B", 0);
         cmbFlightSeatChar.addItem("C", "C", 0);
         cmbFlightSeatChar.addItem("D", "D", 0);
         cmbFlightSeatChar.addItem("E", "E", 0);
         cmbFlightSeatChar.addItem("F", "F", 0);
         if ( cmbFlightSeatChar.ItemCount > 0 )
         {
            A43FlightSeatChar = cmbFlightSeatChar.getValidValue(A43FlightSeatChar);
         }
         GXCCtl = "FLIGHTSEATLOCATION_" + sGXsfl_138_idx;
         cmbFlightSeatLocation.Name = GXCCtl;
         cmbFlightSeatLocation.WebTags = "";
         cmbFlightSeatLocation.addItem("W", "Window", 0);
         cmbFlightSeatLocation.addItem("M", "Middle", 0);
         cmbFlightSeatLocation.addItem("A", "Aisle", 0);
         if ( cmbFlightSeatLocation.ItemCount > 0 )
         {
            A41FlightSeatLocation = cmbFlightSeatLocation.getValidValue(A41FlightSeatLocation);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtFlightDepartureAirportId_Internalname;
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

      public void Valid_Flightid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000533 */
         pr_default.execute(27, new Object[] {A19FlightId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A42FlightCapacity = T000533_A42FlightCapacity[0];
            n42FlightCapacity = T000533_n42FlightCapacity[0];
         }
         else
         {
            A42FlightCapacity = 0;
            n42FlightCapacity = false;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A22FlightDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22FlightDepartureAirportId), 4, 0, ".", "")));
         AssignAttri("", false, "A24FlightArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24FlightArrivalAirportId), 4, 0, ".", "")));
         AssignAttri("", false, "A34FlightPrice", StringUtil.LTrim( StringUtil.NToC( A34FlightPrice, 9, 2, ".", "")));
         AssignAttri("", false, "A35FlightDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A35FlightDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A37AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37AirlineId), 4, 0, ".", "")));
         AssignAttri("", false, "A42FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A42FlightCapacity), 4, 0, ".", "")));
         AssignAttri("", false, "A23FlightDepartureAirportName", StringUtil.RTrim( A23FlightDepartureAirportName));
         AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26FlightDepartureCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlightDepartureCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A27FlightDepartureCountryName", StringUtil.RTrim( A27FlightDepartureCountryName));
         AssignAttri("", false, "A29FlightDepartureCityName", StringUtil.RTrim( A29FlightDepartureCityName));
         AssignAttri("", false, "A25FlightArrivalAirportName", StringUtil.RTrim( A25FlightArrivalAirportName));
         AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30FlightArrivalCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32FlightArrivalCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A31FlightArrivalCountryName", StringUtil.RTrim( A31FlightArrivalCountryName));
         AssignAttri("", false, "A33FlightArrivalCityName", StringUtil.RTrim( A33FlightArrivalCityName));
         AssignAttri("", false, "A38AirlineName", StringUtil.RTrim( A38AirlineName));
         AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39AirlineDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrim( StringUtil.NToC( A36FlightFinalPrice, 9, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z19FlightId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19FlightId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22FlightDepartureAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22FlightDepartureAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24FlightArrivalAirportId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24FlightArrivalAirportId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z34FlightPrice", StringUtil.LTrim( StringUtil.NToC( Z34FlightPrice, 9, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z35FlightDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z35FlightDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z37AirlineId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z37AirlineId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42FlightCapacity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23FlightDepartureAirportName", StringUtil.RTrim( Z23FlightDepartureAirportName));
         GxWebStd.gx_hidden_field( context, "Z26FlightDepartureCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26FlightDepartureCountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28FlightDepartureCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28FlightDepartureCityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27FlightDepartureCountryName", StringUtil.RTrim( Z27FlightDepartureCountryName));
         GxWebStd.gx_hidden_field( context, "Z29FlightDepartureCityName", StringUtil.RTrim( Z29FlightDepartureCityName));
         GxWebStd.gx_hidden_field( context, "Z25FlightArrivalAirportName", StringUtil.RTrim( Z25FlightArrivalAirportName));
         GxWebStd.gx_hidden_field( context, "Z30FlightArrivalCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30FlightArrivalCountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z32FlightArrivalCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32FlightArrivalCityId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31FlightArrivalCountryName", StringUtil.RTrim( Z31FlightArrivalCountryName));
         GxWebStd.gx_hidden_field( context, "Z33FlightArrivalCityName", StringUtil.RTrim( Z33FlightArrivalCityName));
         GxWebStd.gx_hidden_field( context, "Z38AirlineName", StringUtil.RTrim( Z38AirlineName));
         GxWebStd.gx_hidden_field( context, "Z39AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z39AirlineDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z36FlightFinalPrice", StringUtil.LTrim( StringUtil.NToC( Z36FlightFinalPrice, 9, 2, ".", "")));
         AssignAttri("", false, "O42FlightCapacity", StringUtil.LTrim( StringUtil.NToC( (decimal)(O42FlightCapacity), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Flightdepartureairportid( )
      {
         /* Using cursor T000534 */
         pr_default.execute(28, new Object[] {A22FlightDepartureAirportId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTUREAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightDepartureAirportId_Internalname;
         }
         A23FlightDepartureAirportName = T000534_A23FlightDepartureAirportName[0];
         A26FlightDepartureCountryId = T000534_A26FlightDepartureCountryId[0];
         A28FlightDepartureCityId = T000534_A28FlightDepartureCityId[0];
         pr_default.close(28);
         /* Using cursor T000535 */
         pr_default.execute(29, new Object[] {A26FlightDepartureCountryId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECOUNTRYID");
            AnyError = 1;
         }
         A27FlightDepartureCountryName = T000535_A27FlightDepartureCountryName[0];
         pr_default.close(29);
         /* Using cursor T000536 */
         pr_default.execute(30, new Object[] {A26FlightDepartureCountryId, A28FlightDepartureCityId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Departure Airport'.", "ForeignKeyNotFound", 1, "FLIGHTDEPARTURECITYID");
            AnyError = 1;
         }
         A29FlightDepartureCityName = T000536_A29FlightDepartureCityName[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23FlightDepartureAirportName", StringUtil.RTrim( A23FlightDepartureAirportName));
         AssignAttri("", false, "A26FlightDepartureCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26FlightDepartureCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A28FlightDepartureCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FlightDepartureCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A27FlightDepartureCountryName", StringUtil.RTrim( A27FlightDepartureCountryName));
         AssignAttri("", false, "A29FlightDepartureCityName", StringUtil.RTrim( A29FlightDepartureCityName));
      }

      public void Valid_Flightarrivalairportid( )
      {
         /* Using cursor T000537 */
         pr_default.execute(31, new Object[] {A24FlightArrivalAirportId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALAIRPORTID");
            AnyError = 1;
            GX_FocusControl = edtFlightArrivalAirportId_Internalname;
         }
         A25FlightArrivalAirportName = T000537_A25FlightArrivalAirportName[0];
         A30FlightArrivalCountryId = T000537_A30FlightArrivalCountryId[0];
         A32FlightArrivalCityId = T000537_A32FlightArrivalCityId[0];
         pr_default.close(31);
         /* Using cursor T000538 */
         pr_default.execute(32, new Object[] {A30FlightArrivalCountryId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCOUNTRYID");
            AnyError = 1;
         }
         A31FlightArrivalCountryName = T000538_A31FlightArrivalCountryName[0];
         pr_default.close(32);
         /* Using cursor T000539 */
         pr_default.execute(33, new Object[] {A30FlightArrivalCountryId, A32FlightArrivalCityId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem("No matching 'Flight Arrival Airport'.", "ForeignKeyNotFound", 1, "FLIGHTARRIVALCITYID");
            AnyError = 1;
         }
         A33FlightArrivalCityName = T000539_A33FlightArrivalCityName[0];
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25FlightArrivalAirportName", StringUtil.RTrim( A25FlightArrivalAirportName));
         AssignAttri("", false, "A30FlightArrivalCountryId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30FlightArrivalCountryId), 4, 0, ".", "")));
         AssignAttri("", false, "A32FlightArrivalCityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32FlightArrivalCityId), 4, 0, ".", "")));
         AssignAttri("", false, "A31FlightArrivalCountryName", StringUtil.RTrim( A31FlightArrivalCountryName));
         AssignAttri("", false, "A33FlightArrivalCityName", StringUtil.RTrim( A33FlightArrivalCityName));
      }

      public void Valid_Airlineid( )
      {
         n37AirlineId = false;
         /* Using cursor T000540 */
         pr_default.execute(34, new Object[] {n37AirlineId, A37AirlineId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A37AirlineId) ) )
            {
               GX_msglist.addItem("No matching 'Airlane'.", "ForeignKeyNotFound", 1, "AIRLINEID");
               AnyError = 1;
               GX_FocusControl = edtAirlineId_Internalname;
            }
         }
         A38AirlineName = T000540_A38AirlineName[0];
         A39AirlineDiscountPercentage = T000540_A39AirlineDiscountPercentage[0];
         pr_default.close(34);
         if ( A39AirlineDiscountPercentage >= A35FlightDiscountPercentage )
         {
            A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A39AirlineDiscountPercentage/ (decimal)(100)));
         }
         else
         {
            A36FlightFinalPrice = (decimal)(A34FlightPrice*(1-A35FlightDiscountPercentage/ (decimal)(100)));
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A38AirlineName", StringUtil.RTrim( A38AirlineName));
         AssignAttri("", false, "A39AirlineDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A39AirlineDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A36FlightFinalPrice", StringUtil.LTrim( StringUtil.NToC( A36FlightFinalPrice, 9, 2, ".", "")));
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
         setEventMetadata("VALID_FLIGHTID","{handler:'Valid_Flightid',iparms:[{av:'A19FlightId',fld:'FLIGHTID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_FLIGHTID",",oparms:[{av:'A22FlightDepartureAirportId',fld:'FLIGHTDEPARTUREAIRPORTID',pic:'ZZZ9'},{av:'A24FlightArrivalAirportId',fld:'FLIGHTARRIVALAIRPORTID',pic:'ZZZ9'},{av:'A34FlightPrice',fld:'FLIGHTPRICE',pic:'ZZZZZ9.99'},{av:'A35FlightDiscountPercentage',fld:'FLIGHTDISCOUNTPERCENTAGE',pic:'ZZ9'},{av:'A37AirlineId',fld:'AIRLINEID',pic:'ZZZ9'},{av:'A42FlightCapacity',fld:'FLIGHTCAPACITY',pic:'ZZZ9'},{av:'A23FlightDepartureAirportName',fld:'FLIGHTDEPARTUREAIRPORTNAME',pic:''},{av:'A26FlightDepartureCountryId',fld:'FLIGHTDEPARTURECOUNTRYID',pic:'ZZZ9'},{av:'A28FlightDepartureCityId',fld:'FLIGHTDEPARTURECITYID',pic:'ZZZ9'},{av:'A27FlightDepartureCountryName',fld:'FLIGHTDEPARTURECOUNTRYNAME',pic:''},{av:'A29FlightDepartureCityName',fld:'FLIGHTDEPARTURECITYNAME',pic:''},{av:'A25FlightArrivalAirportName',fld:'FLIGHTARRIVALAIRPORTNAME',pic:''},{av:'A30FlightArrivalCountryId',fld:'FLIGHTARRIVALCOUNTRYID',pic:'ZZZ9'},{av:'A32FlightArrivalCityId',fld:'FLIGHTARRIVALCITYID',pic:'ZZZ9'},{av:'A31FlightArrivalCountryName',fld:'FLIGHTARRIVALCOUNTRYNAME',pic:''},{av:'A33FlightArrivalCityName',fld:'FLIGHTARRIVALCITYNAME',pic:''},{av:'A38AirlineName',fld:'AIRLINENAME',pic:''},{av:'A39AirlineDiscountPercentage',fld:'AIRLINEDISCOUNTPERCENTAGE',pic:'ZZ9'},{av:'A36FlightFinalPrice',fld:'FLIGHTFINALPRICE',pic:'ZZZZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z19FlightId'},{av:'Z22FlightDepartureAirportId'},{av:'Z24FlightArrivalAirportId'},{av:'Z34FlightPrice'},{av:'Z35FlightDiscountPercentage'},{av:'Z37AirlineId'},{av:'Z42FlightCapacity'},{av:'Z23FlightDepartureAirportName'},{av:'Z26FlightDepartureCountryId'},{av:'Z28FlightDepartureCityId'},{av:'Z27FlightDepartureCountryName'},{av:'Z29FlightDepartureCityName'},{av:'Z25FlightArrivalAirportName'},{av:'Z30FlightArrivalCountryId'},{av:'Z32FlightArrivalCityId'},{av:'Z31FlightArrivalCountryName'},{av:'Z33FlightArrivalCityName'},{av:'Z38AirlineName'},{av:'Z39AirlineDiscountPercentage'},{av:'Z36FlightFinalPrice'},{av:'O42FlightCapacity'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_FLIGHTDEPARTUREAIRPORTID","{handler:'Valid_Flightdepartureairportid',iparms:[{av:'A22FlightDepartureAirportId',fld:'FLIGHTDEPARTUREAIRPORTID',pic:'ZZZ9'},{av:'A26FlightDepartureCountryId',fld:'FLIGHTDEPARTURECOUNTRYID',pic:'ZZZ9'},{av:'A28FlightDepartureCityId',fld:'FLIGHTDEPARTURECITYID',pic:'ZZZ9'},{av:'A23FlightDepartureAirportName',fld:'FLIGHTDEPARTUREAIRPORTNAME',pic:''},{av:'A27FlightDepartureCountryName',fld:'FLIGHTDEPARTURECOUNTRYNAME',pic:''},{av:'A29FlightDepartureCityName',fld:'FLIGHTDEPARTURECITYNAME',pic:''}]");
         setEventMetadata("VALID_FLIGHTDEPARTUREAIRPORTID",",oparms:[{av:'A23FlightDepartureAirportName',fld:'FLIGHTDEPARTUREAIRPORTNAME',pic:''},{av:'A26FlightDepartureCountryId',fld:'FLIGHTDEPARTURECOUNTRYID',pic:'ZZZ9'},{av:'A28FlightDepartureCityId',fld:'FLIGHTDEPARTURECITYID',pic:'ZZZ9'},{av:'A27FlightDepartureCountryName',fld:'FLIGHTDEPARTURECOUNTRYNAME',pic:''},{av:'A29FlightDepartureCityName',fld:'FLIGHTDEPARTURECITYNAME',pic:''}]}");
         setEventMetadata("VALID_FLIGHTDEPARTURECOUNTRYID","{handler:'Valid_Flightdeparturecountryid',iparms:[]");
         setEventMetadata("VALID_FLIGHTDEPARTURECOUNTRYID",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTDEPARTURECITYID","{handler:'Valid_Flightdeparturecityid',iparms:[]");
         setEventMetadata("VALID_FLIGHTDEPARTURECITYID",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTARRIVALAIRPORTID","{handler:'Valid_Flightarrivalairportid',iparms:[{av:'A24FlightArrivalAirportId',fld:'FLIGHTARRIVALAIRPORTID',pic:'ZZZ9'},{av:'A30FlightArrivalCountryId',fld:'FLIGHTARRIVALCOUNTRYID',pic:'ZZZ9'},{av:'A32FlightArrivalCityId',fld:'FLIGHTARRIVALCITYID',pic:'ZZZ9'},{av:'A25FlightArrivalAirportName',fld:'FLIGHTARRIVALAIRPORTNAME',pic:''},{av:'A31FlightArrivalCountryName',fld:'FLIGHTARRIVALCOUNTRYNAME',pic:''},{av:'A33FlightArrivalCityName',fld:'FLIGHTARRIVALCITYNAME',pic:''}]");
         setEventMetadata("VALID_FLIGHTARRIVALAIRPORTID",",oparms:[{av:'A25FlightArrivalAirportName',fld:'FLIGHTARRIVALAIRPORTNAME',pic:''},{av:'A30FlightArrivalCountryId',fld:'FLIGHTARRIVALCOUNTRYID',pic:'ZZZ9'},{av:'A32FlightArrivalCityId',fld:'FLIGHTARRIVALCITYID',pic:'ZZZ9'},{av:'A31FlightArrivalCountryName',fld:'FLIGHTARRIVALCOUNTRYNAME',pic:''},{av:'A33FlightArrivalCityName',fld:'FLIGHTARRIVALCITYNAME',pic:''}]}");
         setEventMetadata("VALID_FLIGHTARRIVALCOUNTRYID","{handler:'Valid_Flightarrivalcountryid',iparms:[]");
         setEventMetadata("VALID_FLIGHTARRIVALCOUNTRYID",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTARRIVALCITYID","{handler:'Valid_Flightarrivalcityid',iparms:[]");
         setEventMetadata("VALID_FLIGHTARRIVALCITYID",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTPRICE","{handler:'Valid_Flightprice',iparms:[]");
         setEventMetadata("VALID_FLIGHTPRICE",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTDISCOUNTPERCENTAGE","{handler:'Valid_Flightdiscountpercentage',iparms:[]");
         setEventMetadata("VALID_FLIGHTDISCOUNTPERCENTAGE",",oparms:[]}");
         setEventMetadata("VALID_AIRLINEID","{handler:'Valid_Airlineid',iparms:[{av:'A37AirlineId',fld:'AIRLINEID',pic:'ZZZ9'},{av:'A34FlightPrice',fld:'FLIGHTPRICE',pic:'ZZZZZ9.99'},{av:'A39AirlineDiscountPercentage',fld:'AIRLINEDISCOUNTPERCENTAGE',pic:'ZZ9'},{av:'A35FlightDiscountPercentage',fld:'FLIGHTDISCOUNTPERCENTAGE',pic:'ZZ9'},{av:'A38AirlineName',fld:'AIRLINENAME',pic:''},{av:'A36FlightFinalPrice',fld:'FLIGHTFINALPRICE',pic:'ZZZZZ9.99'}]");
         setEventMetadata("VALID_AIRLINEID",",oparms:[{av:'A38AirlineName',fld:'AIRLINENAME',pic:''},{av:'A39AirlineDiscountPercentage',fld:'AIRLINEDISCOUNTPERCENTAGE',pic:'ZZ9'},{av:'A36FlightFinalPrice',fld:'FLIGHTFINALPRICE',pic:'ZZZZZ9.99'}]}");
         setEventMetadata("VALID_AIRLINEDISCOUNTPERCENTAGE","{handler:'Valid_Airlinediscountpercentage',iparms:[]");
         setEventMetadata("VALID_AIRLINEDISCOUNTPERCENTAGE",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTCAPACITY","{handler:'Valid_Flightcapacity',iparms:[]");
         setEventMetadata("VALID_FLIGHTCAPACITY",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTSEATID","{handler:'Valid_Flightseatid',iparms:[]");
         setEventMetadata("VALID_FLIGHTSEATID",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTSEATCHAR","{handler:'Valid_Flightseatchar',iparms:[]");
         setEventMetadata("VALID_FLIGHTSEATCHAR",",oparms:[]}");
         setEventMetadata("VALID_FLIGHTSEATLOCATION","{handler:'Valid_Flightseatlocation',iparms:[]");
         setEventMetadata("VALID_FLIGHTSEATLOCATION",",oparms:[]}");
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
         pr_default.close(3);
         pr_default.close(34);
         pr_default.close(28);
         pr_default.close(31);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z43FlightSeatChar = "";
         Z41FlightSeatLocation = "";
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
         sImgUrl = "";
         A23FlightDepartureAirportName = "";
         A27FlightDepartureCountryName = "";
         A29FlightDepartureCityName = "";
         A25FlightArrivalAirportName = "";
         A31FlightArrivalCountryName = "";
         A33FlightArrivalCityName = "";
         A38AirlineName = "";
         lblTitleseat_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridflight_seatContainer = new GXWebGrid( context);
         Gridflight_seatColumn = new GXWebColumn();
         A43FlightSeatChar = "";
         A41FlightSeatLocation = "";
         sMode10 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         Z23FlightDepartureAirportName = "";
         Z27FlightDepartureCountryName = "";
         Z29FlightDepartureCityName = "";
         Z25FlightArrivalAirportName = "";
         Z31FlightArrivalCountryName = "";
         Z33FlightArrivalCityName = "";
         Z38AirlineName = "";
         T000516_A19FlightId = new short[1] ;
         T000516_A23FlightDepartureAirportName = new string[] {""} ;
         T000516_A27FlightDepartureCountryName = new string[] {""} ;
         T000516_A29FlightDepartureCityName = new string[] {""} ;
         T000516_A25FlightArrivalAirportName = new string[] {""} ;
         T000516_A31FlightArrivalCountryName = new string[] {""} ;
         T000516_A33FlightArrivalCityName = new string[] {""} ;
         T000516_A34FlightPrice = new decimal[1] ;
         T000516_A35FlightDiscountPercentage = new short[1] ;
         T000516_A38AirlineName = new string[] {""} ;
         T000516_A39AirlineDiscountPercentage = new short[1] ;
         T000516_A37AirlineId = new short[1] ;
         T000516_n37AirlineId = new bool[] {false} ;
         T000516_A22FlightDepartureAirportId = new short[1] ;
         T000516_A24FlightArrivalAirportId = new short[1] ;
         T000516_A26FlightDepartureCountryId = new short[1] ;
         T000516_A28FlightDepartureCityId = new short[1] ;
         T000516_A30FlightArrivalCountryId = new short[1] ;
         T000516_A32FlightArrivalCityId = new short[1] ;
         T000516_A42FlightCapacity = new short[1] ;
         T000516_n42FlightCapacity = new bool[] {false} ;
         T000514_A42FlightCapacity = new short[1] ;
         T000514_n42FlightCapacity = new bool[] {false} ;
         T00057_A23FlightDepartureAirportName = new string[] {""} ;
         T00057_A26FlightDepartureCountryId = new short[1] ;
         T00057_A28FlightDepartureCityId = new short[1] ;
         T00059_A27FlightDepartureCountryName = new string[] {""} ;
         T000510_A29FlightDepartureCityName = new string[] {""} ;
         T00058_A25FlightArrivalAirportName = new string[] {""} ;
         T00058_A30FlightArrivalCountryId = new short[1] ;
         T00058_A32FlightArrivalCityId = new short[1] ;
         T000511_A31FlightArrivalCountryName = new string[] {""} ;
         T000512_A33FlightArrivalCityName = new string[] {""} ;
         T00056_A38AirlineName = new string[] {""} ;
         T00056_A39AirlineDiscountPercentage = new short[1] ;
         T000518_A42FlightCapacity = new short[1] ;
         T000518_n42FlightCapacity = new bool[] {false} ;
         T000519_A23FlightDepartureAirportName = new string[] {""} ;
         T000519_A26FlightDepartureCountryId = new short[1] ;
         T000519_A28FlightDepartureCityId = new short[1] ;
         T000520_A27FlightDepartureCountryName = new string[] {""} ;
         T000521_A29FlightDepartureCityName = new string[] {""} ;
         T000522_A25FlightArrivalAirportName = new string[] {""} ;
         T000522_A30FlightArrivalCountryId = new short[1] ;
         T000522_A32FlightArrivalCityId = new short[1] ;
         T000523_A31FlightArrivalCountryName = new string[] {""} ;
         T000524_A33FlightArrivalCityName = new string[] {""} ;
         T000525_A38AirlineName = new string[] {""} ;
         T000525_A39AirlineDiscountPercentage = new short[1] ;
         T000526_A19FlightId = new short[1] ;
         T00055_A19FlightId = new short[1] ;
         T00055_A34FlightPrice = new decimal[1] ;
         T00055_A35FlightDiscountPercentage = new short[1] ;
         T00055_A37AirlineId = new short[1] ;
         T00055_n37AirlineId = new bool[] {false} ;
         T00055_A22FlightDepartureAirportId = new short[1] ;
         T00055_A24FlightArrivalAirportId = new short[1] ;
         sMode6 = "";
         T000527_A19FlightId = new short[1] ;
         T000528_A19FlightId = new short[1] ;
         T00054_A19FlightId = new short[1] ;
         T00054_A34FlightPrice = new decimal[1] ;
         T00054_A35FlightDiscountPercentage = new short[1] ;
         T00054_A37AirlineId = new short[1] ;
         T00054_n37AirlineId = new bool[] {false} ;
         T00054_A22FlightDepartureAirportId = new short[1] ;
         T00054_A24FlightArrivalAirportId = new short[1] ;
         T000529_A19FlightId = new short[1] ;
         T000533_A42FlightCapacity = new short[1] ;
         T000533_n42FlightCapacity = new bool[] {false} ;
         T000534_A23FlightDepartureAirportName = new string[] {""} ;
         T000534_A26FlightDepartureCountryId = new short[1] ;
         T000534_A28FlightDepartureCityId = new short[1] ;
         T000535_A27FlightDepartureCountryName = new string[] {""} ;
         T000536_A29FlightDepartureCityName = new string[] {""} ;
         T000537_A25FlightArrivalAirportName = new string[] {""} ;
         T000537_A30FlightArrivalCountryId = new short[1] ;
         T000537_A32FlightArrivalCityId = new short[1] ;
         T000538_A31FlightArrivalCountryName = new string[] {""} ;
         T000539_A33FlightArrivalCityName = new string[] {""} ;
         T000540_A38AirlineName = new string[] {""} ;
         T000540_A39AirlineDiscountPercentage = new short[1] ;
         T000541_A19FlightId = new short[1] ;
         T000542_A19FlightId = new short[1] ;
         T000542_A40FlightSeatId = new short[1] ;
         T000542_A43FlightSeatChar = new string[] {""} ;
         T000542_A41FlightSeatLocation = new string[] {""} ;
         T000543_A19FlightId = new short[1] ;
         T000543_A40FlightSeatId = new short[1] ;
         T000543_A43FlightSeatChar = new string[] {""} ;
         T00053_A19FlightId = new short[1] ;
         T00053_A40FlightSeatId = new short[1] ;
         T00053_A43FlightSeatChar = new string[] {""} ;
         T00053_A41FlightSeatLocation = new string[] {""} ;
         T00052_A19FlightId = new short[1] ;
         T00052_A40FlightSeatId = new short[1] ;
         T00052_A43FlightSeatChar = new string[] {""} ;
         T00052_A41FlightSeatLocation = new string[] {""} ;
         T000547_A19FlightId = new short[1] ;
         T000547_A40FlightSeatId = new short[1] ;
         T000547_A43FlightSeatChar = new string[] {""} ;
         Gridflight_seatRow = new GXWebRow();
         subGridflight_seat_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ23FlightDepartureAirportName = "";
         ZZ27FlightDepartureCountryName = "";
         ZZ29FlightDepartureCityName = "";
         ZZ25FlightArrivalAirportName = "";
         ZZ31FlightArrivalCountryName = "";
         ZZ33FlightArrivalCityName = "";
         ZZ38AirlineName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.flight__default(),
            new Object[][] {
                new Object[] {
               T00052_A19FlightId, T00052_A40FlightSeatId, T00052_A43FlightSeatChar, T00052_A41FlightSeatLocation
               }
               , new Object[] {
               T00053_A19FlightId, T00053_A40FlightSeatId, T00053_A43FlightSeatChar, T00053_A41FlightSeatLocation
               }
               , new Object[] {
               T00054_A19FlightId, T00054_A34FlightPrice, T00054_A35FlightDiscountPercentage, T00054_A37AirlineId, T00054_n37AirlineId, T00054_A22FlightDepartureAirportId, T00054_A24FlightArrivalAirportId
               }
               , new Object[] {
               T00055_A19FlightId, T00055_A34FlightPrice, T00055_A35FlightDiscountPercentage, T00055_A37AirlineId, T00055_n37AirlineId, T00055_A22FlightDepartureAirportId, T00055_A24FlightArrivalAirportId
               }
               , new Object[] {
               T00056_A38AirlineName, T00056_A39AirlineDiscountPercentage
               }
               , new Object[] {
               T00057_A23FlightDepartureAirportName, T00057_A26FlightDepartureCountryId, T00057_A28FlightDepartureCityId
               }
               , new Object[] {
               T00058_A25FlightArrivalAirportName, T00058_A30FlightArrivalCountryId, T00058_A32FlightArrivalCityId
               }
               , new Object[] {
               T00059_A27FlightDepartureCountryName
               }
               , new Object[] {
               T000510_A29FlightDepartureCityName
               }
               , new Object[] {
               T000511_A31FlightArrivalCountryName
               }
               , new Object[] {
               T000512_A33FlightArrivalCityName
               }
               , new Object[] {
               T000514_A42FlightCapacity, T000514_n42FlightCapacity
               }
               , new Object[] {
               T000516_A19FlightId, T000516_A23FlightDepartureAirportName, T000516_A27FlightDepartureCountryName, T000516_A29FlightDepartureCityName, T000516_A25FlightArrivalAirportName, T000516_A31FlightArrivalCountryName, T000516_A33FlightArrivalCityName, T000516_A34FlightPrice, T000516_A35FlightDiscountPercentage, T000516_A38AirlineName,
               T000516_A39AirlineDiscountPercentage, T000516_A37AirlineId, T000516_n37AirlineId, T000516_A22FlightDepartureAirportId, T000516_A24FlightArrivalAirportId, T000516_A26FlightDepartureCountryId, T000516_A28FlightDepartureCityId, T000516_A30FlightArrivalCountryId, T000516_A32FlightArrivalCityId, T000516_A42FlightCapacity,
               T000516_n42FlightCapacity
               }
               , new Object[] {
               T000518_A42FlightCapacity, T000518_n42FlightCapacity
               }
               , new Object[] {
               T000519_A23FlightDepartureAirportName, T000519_A26FlightDepartureCountryId, T000519_A28FlightDepartureCityId
               }
               , new Object[] {
               T000520_A27FlightDepartureCountryName
               }
               , new Object[] {
               T000521_A29FlightDepartureCityName
               }
               , new Object[] {
               T000522_A25FlightArrivalAirportName, T000522_A30FlightArrivalCountryId, T000522_A32FlightArrivalCityId
               }
               , new Object[] {
               T000523_A31FlightArrivalCountryName
               }
               , new Object[] {
               T000524_A33FlightArrivalCityName
               }
               , new Object[] {
               T000525_A38AirlineName, T000525_A39AirlineDiscountPercentage
               }
               , new Object[] {
               T000526_A19FlightId
               }
               , new Object[] {
               T000527_A19FlightId
               }
               , new Object[] {
               T000528_A19FlightId
               }
               , new Object[] {
               T000529_A19FlightId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000533_A42FlightCapacity, T000533_n42FlightCapacity
               }
               , new Object[] {
               T000534_A23FlightDepartureAirportName, T000534_A26FlightDepartureCountryId, T000534_A28FlightDepartureCityId
               }
               , new Object[] {
               T000535_A27FlightDepartureCountryName
               }
               , new Object[] {
               T000536_A29FlightDepartureCityName
               }
               , new Object[] {
               T000537_A25FlightArrivalAirportName, T000537_A30FlightArrivalCountryId, T000537_A32FlightArrivalCityId
               }
               , new Object[] {
               T000538_A31FlightArrivalCountryName
               }
               , new Object[] {
               T000539_A33FlightArrivalCityName
               }
               , new Object[] {
               T000540_A38AirlineName, T000540_A39AirlineDiscountPercentage
               }
               , new Object[] {
               T000541_A19FlightId
               }
               , new Object[] {
               T000542_A19FlightId, T000542_A40FlightSeatId, T000542_A43FlightSeatChar, T000542_A41FlightSeatLocation
               }
               , new Object[] {
               T000543_A19FlightId, T000543_A40FlightSeatId, T000543_A43FlightSeatChar
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000547_A19FlightId, T000547_A40FlightSeatId, T000547_A43FlightSeatChar
               }
            }
         );
      }

      private short Z19FlightId ;
      private short Z35FlightDiscountPercentage ;
      private short Z37AirlineId ;
      private short Z22FlightDepartureAirportId ;
      private short Z24FlightArrivalAirportId ;
      private short O42FlightCapacity ;
      private short Z40FlightSeatId ;
      private short nRcdDeleted_10 ;
      private short nRcdExists_10 ;
      private short nIsMod_10 ;
      private short GxWebError ;
      private short A19FlightId ;
      private short A22FlightDepartureAirportId ;
      private short A26FlightDepartureCountryId ;
      private short A28FlightDepartureCityId ;
      private short A24FlightArrivalAirportId ;
      private short A30FlightArrivalCountryId ;
      private short A32FlightArrivalCityId ;
      private short A37AirlineId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A35FlightDiscountPercentage ;
      private short A39AirlineDiscountPercentage ;
      private short A42FlightCapacity ;
      private short subGridflight_seat_Backcolorstyle ;
      private short A40FlightSeatId ;
      private short subGridflight_seat_Allowselection ;
      private short subGridflight_seat_Allowhovering ;
      private short subGridflight_seat_Allowcollapsing ;
      private short subGridflight_seat_Collapsed ;
      private short nBlankRcdCount10 ;
      private short RcdFound10 ;
      private short B42FlightCapacity ;
      private short nBlankRcdUsr10 ;
      private short s42FlightCapacity ;
      private short GX_JID ;
      private short Z42FlightCapacity ;
      private short Z26FlightDepartureCountryId ;
      private short Z28FlightDepartureCityId ;
      private short Z30FlightArrivalCountryId ;
      private short Z32FlightArrivalCityId ;
      private short Z39AirlineDiscountPercentage ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private short Gx_BScreen ;
      private short nIsDirty_10 ;
      private short subGridflight_seat_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ19FlightId ;
      private short ZZ22FlightDepartureAirportId ;
      private short ZZ24FlightArrivalAirportId ;
      private short ZZ35FlightDiscountPercentage ;
      private short ZZ37AirlineId ;
      private short ZZ42FlightCapacity ;
      private short ZZ26FlightDepartureCountryId ;
      private short ZZ28FlightDepartureCityId ;
      private short ZZ30FlightArrivalCountryId ;
      private short ZZ32FlightArrivalCityId ;
      private short ZZ39AirlineDiscountPercentage ;
      private short ZO42FlightCapacity ;
      private int nRC_GXsfl_138 ;
      private int nGXsfl_138_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFlightId_Enabled ;
      private int edtFlightDepartureAirportId_Enabled ;
      private int imgprompt_22_Visible ;
      private int edtFlightDepartureAirportName_Enabled ;
      private int edtFlightDepartureCountryId_Enabled ;
      private int edtFlightDepartureCountryName_Enabled ;
      private int edtFlightDepartureCityId_Enabled ;
      private int edtFlightDepartureCityName_Enabled ;
      private int edtFlightArrivalAirportId_Enabled ;
      private int imgprompt_24_Visible ;
      private int edtFlightArrivalAirportName_Enabled ;
      private int edtFlightArrivalCountryId_Enabled ;
      private int edtFlightArrivalCountryName_Enabled ;
      private int edtFlightArrivalCityId_Enabled ;
      private int edtFlightArrivalCityName_Enabled ;
      private int edtFlightPrice_Enabled ;
      private int edtFlightDiscountPercentage_Enabled ;
      private int edtAirlineId_Enabled ;
      private int imgprompt_37_Visible ;
      private int edtAirlineName_Enabled ;
      private int edtAirlineDiscountPercentage_Enabled ;
      private int edtFlightFinalPrice_Enabled ;
      private int edtFlightCapacity_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtFlightSeatId_Enabled ;
      private int subGridflight_seat_Selectedindex ;
      private int subGridflight_seat_Selectioncolor ;
      private int subGridflight_seat_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridflight_seat_Backcolor ;
      private int subGridflight_seat_Allbackcolor ;
      private int defcmbFlightSeatChar_Enabled ;
      private int defedtFlightSeatId_Enabled ;
      private int idxLst ;
      private long GRIDFLIGHT_SEAT_nFirstRecordOnPage ;
      private decimal Z34FlightPrice ;
      private decimal A34FlightPrice ;
      private decimal A36FlightFinalPrice ;
      private decimal Z36FlightFinalPrice ;
      private decimal ZZ34FlightPrice ;
      private decimal ZZ36FlightFinalPrice ;
      private string sPrefix ;
      private string Z43FlightSeatChar ;
      private string Z41FlightSeatLocation ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_138_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFlightId_Internalname ;
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
      private string edtFlightId_Jsonclick ;
      private string edtFlightDepartureAirportId_Internalname ;
      private string edtFlightDepartureAirportId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_22_Internalname ;
      private string imgprompt_22_Link ;
      private string edtFlightDepartureAirportName_Internalname ;
      private string A23FlightDepartureAirportName ;
      private string edtFlightDepartureAirportName_Jsonclick ;
      private string edtFlightDepartureCountryId_Internalname ;
      private string edtFlightDepartureCountryId_Jsonclick ;
      private string edtFlightDepartureCountryName_Internalname ;
      private string A27FlightDepartureCountryName ;
      private string edtFlightDepartureCountryName_Jsonclick ;
      private string edtFlightDepartureCityId_Internalname ;
      private string edtFlightDepartureCityId_Jsonclick ;
      private string edtFlightDepartureCityName_Internalname ;
      private string A29FlightDepartureCityName ;
      private string edtFlightDepartureCityName_Jsonclick ;
      private string edtFlightArrivalAirportId_Internalname ;
      private string edtFlightArrivalAirportId_Jsonclick ;
      private string imgprompt_24_Internalname ;
      private string imgprompt_24_Link ;
      private string edtFlightArrivalAirportName_Internalname ;
      private string A25FlightArrivalAirportName ;
      private string edtFlightArrivalAirportName_Jsonclick ;
      private string edtFlightArrivalCountryId_Internalname ;
      private string edtFlightArrivalCountryId_Jsonclick ;
      private string edtFlightArrivalCountryName_Internalname ;
      private string A31FlightArrivalCountryName ;
      private string edtFlightArrivalCountryName_Jsonclick ;
      private string edtFlightArrivalCityId_Internalname ;
      private string edtFlightArrivalCityId_Jsonclick ;
      private string edtFlightArrivalCityName_Internalname ;
      private string A33FlightArrivalCityName ;
      private string edtFlightArrivalCityName_Jsonclick ;
      private string edtFlightPrice_Internalname ;
      private string edtFlightPrice_Jsonclick ;
      private string edtFlightDiscountPercentage_Internalname ;
      private string edtFlightDiscountPercentage_Jsonclick ;
      private string edtAirlineId_Internalname ;
      private string edtAirlineId_Jsonclick ;
      private string imgprompt_37_Internalname ;
      private string imgprompt_37_Link ;
      private string edtAirlineName_Internalname ;
      private string A38AirlineName ;
      private string edtAirlineName_Jsonclick ;
      private string edtAirlineDiscountPercentage_Internalname ;
      private string edtAirlineDiscountPercentage_Jsonclick ;
      private string edtFlightFinalPrice_Internalname ;
      private string edtFlightFinalPrice_Jsonclick ;
      private string edtFlightCapacity_Internalname ;
      private string edtFlightCapacity_Jsonclick ;
      private string divSeattable_Internalname ;
      private string lblTitleseat_Internalname ;
      private string lblTitleseat_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridflight_seat_Header ;
      private string A43FlightSeatChar ;
      private string A41FlightSeatLocation ;
      private string sMode10 ;
      private string edtFlightSeatId_Internalname ;
      private string cmbFlightSeatChar_Internalname ;
      private string cmbFlightSeatLocation_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z23FlightDepartureAirportName ;
      private string Z27FlightDepartureCountryName ;
      private string Z29FlightDepartureCityName ;
      private string Z25FlightArrivalAirportName ;
      private string Z31FlightArrivalCountryName ;
      private string Z33FlightArrivalCityName ;
      private string Z38AirlineName ;
      private string sMode6 ;
      private string sGXsfl_138_fel_idx="0001" ;
      private string subGridflight_seat_Class ;
      private string subGridflight_seat_Linesclass ;
      private string ROClassString ;
      private string edtFlightSeatId_Jsonclick ;
      private string cmbFlightSeatChar_Jsonclick ;
      private string cmbFlightSeatLocation_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridflight_seat_Internalname ;
      private string ZZ23FlightDepartureAirportName ;
      private string ZZ27FlightDepartureCountryName ;
      private string ZZ29FlightDepartureCityName ;
      private string ZZ25FlightArrivalAirportName ;
      private string ZZ31FlightArrivalCountryName ;
      private string ZZ33FlightArrivalCityName ;
      private string ZZ38AirlineName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n37AirlineId ;
      private bool wbErr ;
      private bool n42FlightCapacity ;
      private bool bGXsfl_138_Refreshing=false ;
      private GXWebGrid Gridflight_seatContainer ;
      private GXWebRow Gridflight_seatRow ;
      private GXWebColumn Gridflight_seatColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFlightSeatChar ;
      private GXCombobox cmbFlightSeatLocation ;
      private IDataStoreProvider pr_default ;
      private short[] T000516_A19FlightId ;
      private string[] T000516_A23FlightDepartureAirportName ;
      private string[] T000516_A27FlightDepartureCountryName ;
      private string[] T000516_A29FlightDepartureCityName ;
      private string[] T000516_A25FlightArrivalAirportName ;
      private string[] T000516_A31FlightArrivalCountryName ;
      private string[] T000516_A33FlightArrivalCityName ;
      private decimal[] T000516_A34FlightPrice ;
      private short[] T000516_A35FlightDiscountPercentage ;
      private string[] T000516_A38AirlineName ;
      private short[] T000516_A39AirlineDiscountPercentage ;
      private short[] T000516_A37AirlineId ;
      private bool[] T000516_n37AirlineId ;
      private short[] T000516_A22FlightDepartureAirportId ;
      private short[] T000516_A24FlightArrivalAirportId ;
      private short[] T000516_A26FlightDepartureCountryId ;
      private short[] T000516_A28FlightDepartureCityId ;
      private short[] T000516_A30FlightArrivalCountryId ;
      private short[] T000516_A32FlightArrivalCityId ;
      private short[] T000516_A42FlightCapacity ;
      private bool[] T000516_n42FlightCapacity ;
      private short[] T000514_A42FlightCapacity ;
      private bool[] T000514_n42FlightCapacity ;
      private string[] T00057_A23FlightDepartureAirportName ;
      private short[] T00057_A26FlightDepartureCountryId ;
      private short[] T00057_A28FlightDepartureCityId ;
      private string[] T00059_A27FlightDepartureCountryName ;
      private string[] T000510_A29FlightDepartureCityName ;
      private string[] T00058_A25FlightArrivalAirportName ;
      private short[] T00058_A30FlightArrivalCountryId ;
      private short[] T00058_A32FlightArrivalCityId ;
      private string[] T000511_A31FlightArrivalCountryName ;
      private string[] T000512_A33FlightArrivalCityName ;
      private string[] T00056_A38AirlineName ;
      private short[] T00056_A39AirlineDiscountPercentage ;
      private short[] T000518_A42FlightCapacity ;
      private bool[] T000518_n42FlightCapacity ;
      private string[] T000519_A23FlightDepartureAirportName ;
      private short[] T000519_A26FlightDepartureCountryId ;
      private short[] T000519_A28FlightDepartureCityId ;
      private string[] T000520_A27FlightDepartureCountryName ;
      private string[] T000521_A29FlightDepartureCityName ;
      private string[] T000522_A25FlightArrivalAirportName ;
      private short[] T000522_A30FlightArrivalCountryId ;
      private short[] T000522_A32FlightArrivalCityId ;
      private string[] T000523_A31FlightArrivalCountryName ;
      private string[] T000524_A33FlightArrivalCityName ;
      private string[] T000525_A38AirlineName ;
      private short[] T000525_A39AirlineDiscountPercentage ;
      private short[] T000526_A19FlightId ;
      private short[] T00055_A19FlightId ;
      private decimal[] T00055_A34FlightPrice ;
      private short[] T00055_A35FlightDiscountPercentage ;
      private short[] T00055_A37AirlineId ;
      private bool[] T00055_n37AirlineId ;
      private short[] T00055_A22FlightDepartureAirportId ;
      private short[] T00055_A24FlightArrivalAirportId ;
      private short[] T000527_A19FlightId ;
      private short[] T000528_A19FlightId ;
      private short[] T00054_A19FlightId ;
      private decimal[] T00054_A34FlightPrice ;
      private short[] T00054_A35FlightDiscountPercentage ;
      private short[] T00054_A37AirlineId ;
      private bool[] T00054_n37AirlineId ;
      private short[] T00054_A22FlightDepartureAirportId ;
      private short[] T00054_A24FlightArrivalAirportId ;
      private short[] T000529_A19FlightId ;
      private short[] T000533_A42FlightCapacity ;
      private bool[] T000533_n42FlightCapacity ;
      private string[] T000534_A23FlightDepartureAirportName ;
      private short[] T000534_A26FlightDepartureCountryId ;
      private short[] T000534_A28FlightDepartureCityId ;
      private string[] T000535_A27FlightDepartureCountryName ;
      private string[] T000536_A29FlightDepartureCityName ;
      private string[] T000537_A25FlightArrivalAirportName ;
      private short[] T000537_A30FlightArrivalCountryId ;
      private short[] T000537_A32FlightArrivalCityId ;
      private string[] T000538_A31FlightArrivalCountryName ;
      private string[] T000539_A33FlightArrivalCityName ;
      private string[] T000540_A38AirlineName ;
      private short[] T000540_A39AirlineDiscountPercentage ;
      private short[] T000541_A19FlightId ;
      private short[] T000542_A19FlightId ;
      private short[] T000542_A40FlightSeatId ;
      private string[] T000542_A43FlightSeatChar ;
      private string[] T000542_A41FlightSeatLocation ;
      private short[] T000543_A19FlightId ;
      private short[] T000543_A40FlightSeatId ;
      private string[] T000543_A43FlightSeatChar ;
      private short[] T00053_A19FlightId ;
      private short[] T00053_A40FlightSeatId ;
      private string[] T00053_A43FlightSeatChar ;
      private string[] T00053_A41FlightSeatLocation ;
      private short[] T00052_A19FlightId ;
      private short[] T00052_A40FlightSeatId ;
      private string[] T00052_A43FlightSeatChar ;
      private string[] T00052_A41FlightSeatLocation ;
      private short[] T000547_A19FlightId ;
      private short[] T000547_A40FlightSeatId ;
      private string[] T000547_A43FlightSeatChar ;
      private GXWebForm Form ;
   }

   public class flight__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new UpdateCursor(def[38])
         ,new UpdateCursor(def[39])
         ,new UpdateCursor(def[40])
         ,new ForEachCursor(def[41])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000516;
          prmT000516 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightDepartureCityId",GXType.Int16,4,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalCityId",GXType.Int16,4,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000518;
          prmT000518 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000519;
          prmT000519 = new Object[] {
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000520;
          prmT000520 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000521;
          prmT000521 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightDepartureCityId",GXType.Int16,4,0)
          };
          Object[] prmT000522;
          prmT000522 = new Object[] {
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000523;
          prmT000523 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000524;
          prmT000524 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalCityId",GXType.Int16,4,0)
          };
          Object[] prmT000525;
          prmT000525 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000526;
          prmT000526 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000527;
          prmT000527 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000528;
          prmT000528 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000529;
          prmT000529 = new Object[] {
          new ParDef("@FlightPrice",GXType.Decimal,9,2) ,
          new ParDef("@FlightDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000530;
          prmT000530 = new Object[] {
          new ParDef("@FlightPrice",GXType.Decimal,9,2) ,
          new ParDef("@FlightDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0) ,
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000531;
          prmT000531 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000541;
          prmT000541 = new Object[] {
          };
          Object[] prmT000542;
          prmT000542 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000543;
          prmT000543 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000544;
          prmT000544 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0) ,
          new ParDef("@FlightSeatLocation",GXType.NChar,1,0)
          };
          Object[] prmT000545;
          prmT000545 = new Object[] {
          new ParDef("@FlightSeatLocation",GXType.NChar,1,0) ,
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000546;
          prmT000546 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatId",GXType.Int16,4,0) ,
          new ParDef("@FlightSeatChar",GXType.NChar,1,0)
          };
          Object[] prmT000547;
          prmT000547 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000533;
          prmT000533 = new Object[] {
          new ParDef("@FlightId",GXType.Int16,4,0)
          };
          Object[] prmT000534;
          prmT000534 = new Object[] {
          new ParDef("@FlightDepartureAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000535;
          prmT000535 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000536;
          prmT000536 = new Object[] {
          new ParDef("@FlightDepartureCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightDepartureCityId",GXType.Int16,4,0)
          };
          Object[] prmT000537;
          prmT000537 = new Object[] {
          new ParDef("@FlightArrivalAirportId",GXType.Int16,4,0)
          };
          Object[] prmT000538;
          prmT000538 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0)
          };
          Object[] prmT000539;
          prmT000539 = new Object[] {
          new ParDef("@FlightArrivalCountryId",GXType.Int16,4,0) ,
          new ParDef("@FlightArrivalCityId",GXType.Int16,4,0)
          };
          Object[] prmT000540;
          prmT000540 = new Object[] {
          new ParDef("@AirlineId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation] FROM [FlightSeat] WITH (UPDLOCK) WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation] FROM [FlightSeat] WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT [FlightId], [FlightPrice], [FlightDiscountPercentage], [AirlineId], [FlightDepartureAirportId] AS FlightDepartureAirportId, [FlightArrivalAirportId] AS FlightArrivalAirportId FROM [Flight] WITH (UPDLOCK) WHERE [FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [FlightId], [FlightPrice], [FlightDiscountPercentage], [AirlineId], [FlightDepartureAirportId] AS FlightDepartureAirportId, [FlightArrivalAirportId] AS FlightArrivalAirportId FROM [Flight] WHERE [FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airlane] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT [AirportName] AS FlightDepartureAirportName, [CountryId] AS FlightDepartureCountryId, [CityId] AS FlightDepartureCityId FROM [Airport] WHERE [AirportId] = @FlightDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00058", "SELECT [AirportName] AS FlightArrivalAirportName, [CountryId] AS FlightArrivalCountryId, [CityId] AS FlightArrivalCityId FROM [Airport] WHERE [AirportId] = @FlightArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00059", "SELECT [CountryName] AS FlightDepartureCountryName FROM [Country] WHERE [CountryId] = @FlightDepartureCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000510", "SELECT [CityName] AS FlightDepartureCityName FROM [CountryCity] WHERE [CountryId] = @FlightDepartureCountryId AND [CityId] = @FlightDepartureCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000511", "SELECT [CountryName] AS FlightArrivalCountryName FROM [Country] WHERE [CountryId] = @FlightArrivalCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000512", "SELECT [CityName] AS FlightArrivalCityName FROM [CountryCity] WHERE [CountryId] = @FlightArrivalCountryId AND [CityId] = @FlightArrivalCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000514", "SELECT COALESCE( T1.[FlightCapacity], 0) AS FlightCapacity FROM (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] WITH (UPDLOCK) GROUP BY [FlightId] ) T1 WHERE T1.[FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000516", "SELECT TM1.[FlightId], T3.[AirportName] AS FlightDepartureAirportName, T4.[CountryName] AS FlightDepartureCountryName, T5.[CityName] AS FlightDepartureCityName, T6.[AirportName] AS FlightArrivalAirportName, T7.[CountryName] AS FlightArrivalCountryName, T8.[CityName] AS FlightArrivalCityName, TM1.[FlightPrice], TM1.[FlightDiscountPercentage], T9.[AirlineName], T9.[AirlineDiscountPercentage], TM1.[AirlineId], TM1.[FlightDepartureAirportId] AS FlightDepartureAirportId, TM1.[FlightArrivalAirportId] AS FlightArrivalAirportId, T3.[CountryId] AS FlightDepartureCountryId, T3.[CityId] AS FlightDepartureCityId, T6.[CountryId] AS FlightArrivalCountryId, T6.[CityId] AS FlightArrivalCityId, COALESCE( T2.[FlightCapacity], 0) AS FlightCapacity FROM (((((((([Flight] TM1 LEFT JOIN (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] GROUP BY [FlightId] ) T2 ON T2.[FlightId] = TM1.[FlightId]) INNER JOIN [Airport] T3 ON T3.[AirportId] = TM1.[FlightDepartureAirportId]) INNER JOIN [Country] T4 ON T4.[CountryId] = T3.[CountryId]) INNER JOIN [CountryCity] T5 ON T5.[CountryId] = T3.[CountryId] AND T5.[CityId] = T3.[CityId]) INNER JOIN [Airport] T6 ON T6.[AirportId] = TM1.[FlightArrivalAirportId]) INNER JOIN [Country] T7 ON T7.[CountryId] = T6.[CountryId]) INNER JOIN [CountryCity] T8 ON T8.[CountryId] = T6.[CountryId] AND T8.[CityId] = T6.[CityId]) LEFT JOIN [Airlane] T9 ON T9.[AirlineId] = TM1.[AirlineId]) WHERE TM1.[FlightId] = @FlightId ORDER BY TM1.[FlightId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000518", "SELECT COALESCE( T1.[FlightCapacity], 0) AS FlightCapacity FROM (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] WITH (UPDLOCK) GROUP BY [FlightId] ) T1 WHERE T1.[FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000519", "SELECT [AirportName] AS FlightDepartureAirportName, [CountryId] AS FlightDepartureCountryId, [CityId] AS FlightDepartureCityId FROM [Airport] WHERE [AirportId] = @FlightDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000520", "SELECT [CountryName] AS FlightDepartureCountryName FROM [Country] WHERE [CountryId] = @FlightDepartureCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000520,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000521", "SELECT [CityName] AS FlightDepartureCityName FROM [CountryCity] WHERE [CountryId] = @FlightDepartureCountryId AND [CityId] = @FlightDepartureCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000521,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000522", "SELECT [AirportName] AS FlightArrivalAirportName, [CountryId] AS FlightArrivalCountryId, [CityId] AS FlightArrivalCityId FROM [Airport] WHERE [AirportId] = @FlightArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000522,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000523", "SELECT [CountryName] AS FlightArrivalCountryName FROM [Country] WHERE [CountryId] = @FlightArrivalCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000523,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000524", "SELECT [CityName] AS FlightArrivalCityName FROM [CountryCity] WHERE [CountryId] = @FlightArrivalCountryId AND [CityId] = @FlightArrivalCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000524,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000525", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airlane] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000525,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000526", "SELECT [FlightId] FROM [Flight] WHERE [FlightId] = @FlightId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000526,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000527", "SELECT TOP 1 [FlightId] FROM [Flight] WHERE ( [FlightId] > @FlightId) ORDER BY [FlightId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000527,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000528", "SELECT TOP 1 [FlightId] FROM [Flight] WHERE ( [FlightId] < @FlightId) ORDER BY [FlightId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000528,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000529", "INSERT INTO [Flight]([FlightPrice], [FlightDiscountPercentage], [AirlineId], [FlightDepartureAirportId], [FlightArrivalAirportId]) VALUES(@FlightPrice, @FlightDiscountPercentage, @AirlineId, @FlightDepartureAirportId, @FlightArrivalAirportId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000529)
             ,new CursorDef("T000530", "UPDATE [Flight] SET [FlightPrice]=@FlightPrice, [FlightDiscountPercentage]=@FlightDiscountPercentage, [AirlineId]=@AirlineId, [FlightDepartureAirportId]=@FlightDepartureAirportId, [FlightArrivalAirportId]=@FlightArrivalAirportId  WHERE [FlightId] = @FlightId", GxErrorMask.GX_NOMASK,prmT000530)
             ,new CursorDef("T000531", "DELETE FROM [Flight]  WHERE [FlightId] = @FlightId", GxErrorMask.GX_NOMASK,prmT000531)
             ,new CursorDef("T000533", "SELECT COALESCE( T1.[FlightCapacity], 0) AS FlightCapacity FROM (SELECT COUNT(*) AS FlightCapacity, [FlightId] FROM [FlightSeat] WITH (UPDLOCK) GROUP BY [FlightId] ) T1 WHERE T1.[FlightId] = @FlightId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000533,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000534", "SELECT [AirportName] AS FlightDepartureAirportName, [CountryId] AS FlightDepartureCountryId, [CityId] AS FlightDepartureCityId FROM [Airport] WHERE [AirportId] = @FlightDepartureAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000534,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000535", "SELECT [CountryName] AS FlightDepartureCountryName FROM [Country] WHERE [CountryId] = @FlightDepartureCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000535,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000536", "SELECT [CityName] AS FlightDepartureCityName FROM [CountryCity] WHERE [CountryId] = @FlightDepartureCountryId AND [CityId] = @FlightDepartureCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000536,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000537", "SELECT [AirportName] AS FlightArrivalAirportName, [CountryId] AS FlightArrivalCountryId, [CityId] AS FlightArrivalCityId FROM [Airport] WHERE [AirportId] = @FlightArrivalAirportId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000537,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000538", "SELECT [CountryName] AS FlightArrivalCountryName FROM [Country] WHERE [CountryId] = @FlightArrivalCountryId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000538,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000539", "SELECT [CityName] AS FlightArrivalCityName FROM [CountryCity] WHERE [CountryId] = @FlightArrivalCountryId AND [CityId] = @FlightArrivalCityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000539,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000540", "SELECT [AirlineName], [AirlineDiscountPercentage] FROM [Airlane] WHERE [AirlineId] = @AirlineId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000540,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000541", "SELECT [FlightId] FROM [Flight] ORDER BY [FlightId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000541,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000542", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation] FROM [FlightSeat] WHERE [FlightId] = @FlightId and [FlightSeatId] = @FlightSeatId and [FlightSeatChar] = @FlightSeatChar ORDER BY [FlightId], [FlightSeatId], [FlightSeatChar] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000542,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000543", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar] FROM [FlightSeat] WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar ",true, GxErrorMask.GX_NOMASK, false, this,prmT000543,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000544", "INSERT INTO [FlightSeat]([FlightId], [FlightSeatId], [FlightSeatChar], [FlightSeatLocation]) VALUES(@FlightId, @FlightSeatId, @FlightSeatChar, @FlightSeatLocation)", GxErrorMask.GX_NOMASK,prmT000544)
             ,new CursorDef("T000545", "UPDATE [FlightSeat] SET [FlightSeatLocation]=@FlightSeatLocation  WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar", GxErrorMask.GX_NOMASK,prmT000545)
             ,new CursorDef("T000546", "DELETE FROM [FlightSeat]  WHERE [FlightId] = @FlightId AND [FlightSeatId] = @FlightSeatId AND [FlightSeatChar] = @FlightSeatChar", GxErrorMask.GX_NOMASK,prmT000546)
             ,new CursorDef("T000547", "SELECT [FlightId], [FlightSeatId], [FlightSeatChar] FROM [FlightSeat] WHERE [FlightId] = @FlightId ORDER BY [FlightId], [FlightSeatId], [FlightSeatChar] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000547,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((string[]) buf[2])[0] = rslt.getString(3, 50);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 50);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((short[]) buf[15])[0] = rslt.getShort(15);
                ((short[]) buf[16])[0] = rslt.getShort(16);
                ((short[]) buf[17])[0] = rslt.getShort(17);
                ((short[]) buf[18])[0] = rslt.getShort(18);
                ((short[]) buf[19])[0] = rslt.getShort(19);
                ((bool[]) buf[20])[0] = rslt.wasNull(19);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 32 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 36 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                return;
             case 37 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                return;
             case 41 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                return;
       }
    }

 }

}
