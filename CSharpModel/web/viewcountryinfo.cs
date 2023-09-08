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
   public class viewcountryinfo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public viewcountryinfo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public viewcountryinfo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CountryId )
      {
         this.AV5CountryId = aP0_CountryId;
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "CountryId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "CountryId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "CountryId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_27 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_27"), "."));
               nGXsfl_27_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_27_idx"), "."));
               sGXsfl_27_idx = GetPar( "sGXsfl_27_idx");
               AV10update = GetPar( "update");
               AV11newTrip = GetPar( "newTrip");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               AV6AttractionNameForm = GetPar( "AttractionNameForm");
               AV7AttractionNameTo = GetPar( "AttractionNameTo");
               AV13cityName = GetPar( "cityName");
               AV10update = GetPar( "update");
               AV11newTrip = GetPar( "newTrip");
               AV9totalTrips = (short)(NumberUtil.Val( GetPar( "totalTrips"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( AV6AttractionNameForm, AV7AttractionNameTo, AV13cityName, AV10update, AV11newTrip, AV9totalTrips) ;
               AddString( context.getJSONResponse( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               nRC_GXsfl_48 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_48"), "."));
               nGXsfl_48_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_48_idx"), "."));
               sGXsfl_48_idx = GetPar( "sGXsfl_48_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid2_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               AV6AttractionNameForm = GetPar( "AttractionNameForm");
               AV7AttractionNameTo = GetPar( "AttractionNameTo");
               AV13cityName = GetPar( "cityName");
               AV14totalAttractions = (short)(NumberUtil.Val( GetPar( "totalAttractions"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid2_refresh( AV6AttractionNameForm, AV7AttractionNameTo, AV13cityName, AV14totalAttractions) ;
               AddString( context.getJSONResponse( )) ;
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
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               AV5CountryId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV5CountryId", StringUtil.LTrimStr( (decimal)(AV5CountryId), 4, 0));
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA132( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START132( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 182860), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20236151336577", false, true);
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("viewcountryinfo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5CountryId,4,0))}, new string[] {"CountryId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         GxWebStd.gx_hidden_field( context, "GXH_vATTRACTIONNAMEFORM", StringUtil.RTrim( AV6AttractionNameForm));
         GxWebStd.gx_hidden_field( context, "GXH_vATTRACTIONNAMETO", StringUtil.RTrim( AV7AttractionNameTo));
         GxWebStd.gx_hidden_field( context, "GXH_vCITYNAME", StringUtil.RTrim( AV13cityName));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_27", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_27), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_48", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_48), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CountryId), 4, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE132( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT132( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("viewcountryinfo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5CountryId,4,0))}, new string[] {"CountryId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ViewCountryInfo" ;
      }

      public override string GetPgmdesc( )
      {
         return "View Country Info" ;
      }

      protected void WB130( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCountryName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCountryName_Internalname, "Country Name", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCountryName_Internalname, StringUtil.RTrim( A10CountryName), StringUtil.RTrim( context.localUtil.Format( A10CountryName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCountryName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCountryName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ViewCountryInfo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            wb_table1_11_132( true) ;
         }
         else
         {
            wb_table1_11_132( false) ;
         }
         return  ;
      }

      protected void wb_table1_11_132e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            wb_table2_40_132( true) ;
         }
         else
         {
            wb_table2_40_132( false) ;
         }
         return  ;
      }

      protected void wb_table2_40_132e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 48 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START132( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "View Country Info", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP130( ) ;
      }

      protected void WS132( )
      {
         START132( ) ;
         EVT132( ) ;
      }

      protected void EVT132( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRID1.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VNEWTRIP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VNEWTRIP.CLICK") == 0 ) )
                           {
                              nGXsfl_27_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
                              SubsflControlProps_272( ) ;
                              A7AttractionId = (short)(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","));
                              A8AttractionName = cgiGet( edtAttractionName_Internalname);
                              A13AttractionPhoto = cgiGet( edtAttractionPhoto_Internalname);
                              AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40002AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_27_Refreshing);
                              AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavTrips_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTrips_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTRIPS");
                                 GX_FocusControl = edtavTrips_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV8trips = 0;
                                 AssignAttri("", false, edtavTrips_Internalname, StringUtil.LTrimStr( (decimal)(AV8trips), 4, 0));
                              }
                              else
                              {
                                 AV8trips = (short)(context.localUtil.CToN( cgiGet( edtavTrips_Internalname), ".", ","));
                                 AssignAttri("", false, edtavTrips_Internalname, StringUtil.LTrimStr( (decimal)(AV8trips), 4, 0));
                              }
                              AV10update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV17Update_GXI : context.convertURL( context.PathToRelativeUrl( AV10update))), !bGXsfl_27_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV10update), true);
                              AV11newTrip = cgiGet( edtavNewtrip_Internalname);
                              AssignAttri("", false, edtavNewtrip_Internalname, AV11newTrip);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E11132 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID1.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E12132 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13132 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VNEWTRIP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E14132 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Attractionnameform Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vATTRACTIONNAMEFORM"), AV6AttractionNameForm) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Attractionnameto Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vATTRACTIONNAMETO"), AV7AttractionNameTo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cityname Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCITYNAME"), AV13cityName) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRID2.REFRESH") == 0 ) )
                           {
                              nGXsfl_48_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
                              SubsflControlProps_483( ) ;
                              A15CityId = (short)(context.localUtil.CToN( cgiGet( edtCityId_Internalname), ".", ","));
                              A16CityName = cgiGet( edtCityName_Internalname);
                              AV12attractions = (short)(context.localUtil.CToN( cgiGet( edtavAttractions_Internalname), ".", ","));
                              AssignAttri("", false, edtavAttractions_Internalname, StringUtil.LTrimStr( (decimal)(AV12attractions), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E15133 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID2.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E16132 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE132( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA132( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavAttractionnameform_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_272( ) ;
         while ( nGXsfl_27_idx <= nRC_GXsfl_27 )
         {
            sendrow_272( ) ;
            nGXsfl_27_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_27_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
            sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
            SubsflControlProps_272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_483( ) ;
         while ( nGXsfl_48_idx <= nRC_GXsfl_48 )
         {
            sendrow_483( ) ;
            nGXsfl_48_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_48_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_48_idx+1);
            sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
            SubsflControlProps_483( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxgrGrid1_refresh( string AV6AttractionNameForm ,
                                        string AV7AttractionNameTo ,
                                        string AV13cityName ,
                                        string AV10update ,
                                        string AV11newTrip ,
                                        short AV9totalTrips )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         E12132 ();
         GRID1_nCurrentRecord = 0;
         RF132( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void gxgrGrid2_refresh( string AV6AttractionNameForm ,
                                        string AV7AttractionNameTo ,
                                        string AV13cityName ,
                                        short AV14totalAttractions )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         E12132 ();
         GRID2_nCurrentRecord = 0;
         RF133( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ATTRACTIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF132( ) ;
         RF133( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrips_Enabled = 0;
         AssignProp("", false, edtavTrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrips_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavNewtrip_Enabled = 0;
         AssignProp("", false, edtavNewtrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNewtrip_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavTotaltrips_Enabled = 0;
         AssignProp("", false, edtavTotaltrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaltrips_Enabled), 5, 0), true);
         edtavTotalattractions_Enabled = 0;
         AssignProp("", false, edtavTotalattractions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalattractions_Enabled), 5, 0), true);
      }

      protected void RF132( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 27;
         E12132 ();
         nGXsfl_27_idx = 1;
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         bGXsfl_27_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_272( ) ;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV6AttractionNameForm ,
                                                 AV7AttractionNameTo ,
                                                 A8AttractionName } ,
                                                 new int[]{
                                                 }
            });
            /* Using cursor H00133 */
            pr_default.execute(0, new Object[] {AV6AttractionNameForm, AV7AttractionNameTo});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A10CountryName = H00133_A10CountryName[0];
               AssignAttri("", false, "A10CountryName", A10CountryName);
               A9CountryId = H00133_A9CountryId[0];
               A40002AttractionPhoto_GXI = H00133_A40002AttractionPhoto_GXI[0];
               AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40002AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_27_Refreshing);
               AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
               A8AttractionName = H00133_A8AttractionName[0];
               A7AttractionId = H00133_A7AttractionId[0];
               A40000GXC1 = H00133_A40000GXC1[0];
               n40000GXC1 = H00133_n40000GXC1[0];
               A13AttractionPhoto = H00133_A13AttractionPhoto[0];
               AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40002AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_27_Refreshing);
               AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
               A10CountryName = H00133_A10CountryName[0];
               AssignAttri("", false, "A10CountryName", A10CountryName);
               A40000GXC1 = H00133_A40000GXC1[0];
               n40000GXC1 = H00133_n40000GXC1[0];
               E11132 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 27;
            WB130( ) ;
         }
         bGXsfl_27_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes132( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ATTRACTIONID"+"_"+sGXsfl_27_idx, GetSecureSignedToken( sGXsfl_27_idx, context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"), context));
      }

      protected void RF133( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 48;
         E16132 ();
         nGXsfl_48_idx = 1;
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_483( ) ;
         bGXsfl_48_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "Grid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_483( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV13cityName ,
                                                 A16CityName } ,
                                                 new int[]{
                                                 }
            });
            lV13cityName = StringUtil.PadR( StringUtil.RTrim( AV13cityName), 50, "%");
            /* Using cursor H00135 */
            pr_default.execute(1, new Object[] {lV13cityName});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A9CountryId = H00135_A9CountryId[0];
               A16CityName = H00135_A16CityName[0];
               A15CityId = H00135_A15CityId[0];
               A40001GXC2 = H00135_A40001GXC2[0];
               n40001GXC2 = H00135_n40001GXC2[0];
               A40001GXC2 = H00135_A40001GXC2[0];
               n40001GXC2 = H00135_n40001GXC2[0];
               E15133 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 48;
            WB130( ) ;
         }
         bGXsfl_48_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes133( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTrips_Enabled = 0;
         AssignProp("", false, edtavTrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrips_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavNewtrip_Enabled = 0;
         AssignProp("", false, edtavNewtrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNewtrip_Enabled), 5, 0), !bGXsfl_27_Refreshing);
         edtavTotaltrips_Enabled = 0;
         AssignProp("", false, edtavTotaltrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaltrips_Enabled), 5, 0), true);
         edtavTotalattractions_Enabled = 0;
         AssignProp("", false, edtavTotalattractions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotalattractions_Enabled), 5, 0), true);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP130( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13132 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_27 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_27"), ".", ","));
            nRC_GXsfl_48 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_48"), ".", ","));
            /* Read variables values. */
            A10CountryName = cgiGet( edtCountryName_Internalname);
            AssignAttri("", false, "A10CountryName", A10CountryName);
            AV6AttractionNameForm = cgiGet( edtavAttractionnameform_Internalname);
            AssignAttri("", false, "AV6AttractionNameForm", AV6AttractionNameForm);
            AV7AttractionNameTo = cgiGet( edtavAttractionnameto_Internalname);
            AssignAttri("", false, "AV7AttractionNameTo", AV7AttractionNameTo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotaltrips_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotaltrips_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALTRIPS");
               GX_FocusControl = edtavTotaltrips_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9totalTrips = 0;
               AssignAttri("", false, "AV9totalTrips", StringUtil.LTrimStr( (decimal)(AV9totalTrips), 4, 0));
            }
            else
            {
               AV9totalTrips = (short)(context.localUtil.CToN( cgiGet( edtavTotaltrips_Internalname), ".", ","));
               AssignAttri("", false, "AV9totalTrips", StringUtil.LTrimStr( (decimal)(AV9totalTrips), 4, 0));
            }
            AV13cityName = cgiGet( edtavCityname_Internalname);
            AssignAttri("", false, "AV13cityName", AV13cityName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavTotalattractions_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavTotalattractions_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vTOTALATTRACTIONS");
               GX_FocusControl = edtavTotalattractions_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14totalAttractions = 0;
               AssignAttri("", false, "AV14totalAttractions", StringUtil.LTrimStr( (decimal)(AV14totalAttractions), 4, 0));
            }
            else
            {
               AV14totalAttractions = (short)(context.localUtil.CToN( cgiGet( edtavTotalattractions_Internalname), ".", ","));
               AssignAttri("", false, "AV14totalAttractions", StringUtil.LTrimStr( (decimal)(AV14totalAttractions), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E11132( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         AV8trips = (short)(A40000GXC1);
         AssignAttri("", false, edtavTrips_Internalname, StringUtil.LTrimStr( (decimal)(AV8trips), 4, 0));
         AV9totalTrips = (short)(AV9totalTrips+AV8trips);
         AssignAttri("", false, "AV9totalTrips", StringUtil.LTrimStr( (decimal)(AV9totalTrips), 4, 0));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 27;
         }
         sendrow_272( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_27_Refreshing )
         {
            context.DoAjaxLoad(27, Grid1Row);
         }
         /*  Sending Event outputs  */
      }

      protected void E12132( )
      {
         /* Grid1_Refresh Routine */
         returnInSub = false;
         AV9totalTrips = 0;
         AssignAttri("", false, "AV9totalTrips", StringUtil.LTrimStr( (decimal)(AV9totalTrips), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void E16132( )
      {
         /* Grid2_Refresh Routine */
         returnInSub = false;
         AV14totalAttractions = 0;
         AssignAttri("", false, "AV14totalAttractions", StringUtil.LTrimStr( (decimal)(AV14totalAttractions), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13132( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10update = context.GetImagePath( "2c23d666-bf81-474c-9f82-9a0d6f117c27", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV17Update_GXI : context.convertURL( context.PathToRelativeUrl( AV10update))), !bGXsfl_27_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV10update), true);
         AV17Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2c23d666-bf81-474c-9f82-9a0d6f117c27", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV17Update_GXI : context.convertURL( context.PathToRelativeUrl( AV10update))), !bGXsfl_27_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV10update), true);
         AV11newTrip = "New Trip";
         AssignAttri("", false, edtavNewtrip_Internalname, AV11newTrip);
      }

      protected void E14132( )
      {
         /* Newtrip_Click Routine */
         returnInSub = false;
         GXt_int1 = AV8trips;
         new newtrip(context ).execute(  A7AttractionId, out  GXt_int1) ;
         AV8trips = GXt_int1;
         AssignAttri("", false, edtavTrips_Internalname, StringUtil.LTrimStr( (decimal)(AV8trips), 4, 0));
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
      }

      private void E15133( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         AV12attractions = (short)(A40001GXC2);
         AssignAttri("", false, edtavAttractions_Internalname, StringUtil.LTrimStr( (decimal)(AV12attractions), 4, 0));
         AV14totalAttractions = (short)(AV14totalAttractions+AV12attractions);
         AssignAttri("", false, "AV14totalAttractions", StringUtil.LTrimStr( (decimal)(AV14totalAttractions), 4, 0));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 48;
         }
         sendrow_483( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_48_Refreshing )
         {
            context.DoAjaxLoad(48, Grid2Row);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table2_40_132( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable3_Internalname, tblTable3_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavCityname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCityname_Internalname, "City Name", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCityname_Internalname, StringUtil.RTrim( AV13cityName), StringUtil.RTrim( context.localUtil.Format( AV13cityName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCityname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCityname_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ViewCountryInfo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            Grid2Container.SetWrapped(nGXWrapped);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"48\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid2_Backcolorstyle == 0 )
               {
                  subGrid2_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Title";
                  }
               }
               else
               {
                  subGrid2_Titlebackstyle = 1;
                  if ( subGrid2_Backcolorstyle == 1 )
                  {
                     subGrid2_Titlebackcolor = subGrid2_Allbackcolor;
                     if ( StringUtil.Len( subGrid2_Class) > 0 )
                     {
                        subGrid2_Linesclass = subGrid2_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid2_Class) > 0 )
                     {
                        subGrid2_Linesclass = subGrid2_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "City Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "City Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Attractions") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid2Container.AddObjectProperty("GridName", "Grid2");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid2Container = new GXWebGrid( context);
               }
               else
               {
                  Grid2Container.Clear();
               }
               Grid2Container.SetWrapped(nGXWrapped);
               Grid2Container.AddObjectProperty("GridName", "Grid2");
               Grid2Container.AddObjectProperty("Header", subGrid2_Header);
               Grid2Container.AddObjectProperty("Class", "Grid");
               Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("CmpContext", "");
               Grid2Container.AddObjectProperty("InMasterPage", "false");
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CityId), 4, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.RTrim( A16CityName));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12attractions), 4, 0, ".", "")));
               Grid2Container.AddColumnProperties(Grid2Column);
               Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
               Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
               Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 48 )
         {
            wbEnd = 0;
            nRC_GXsfl_48 = (int)(nGXsfl_48_idx-1);
            if ( Grid2Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotalattractions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotalattractions_Internalname, "total Attractions", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotalattractions_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14totalAttractions), 4, 0, ".", "")), StringUtil.LTrim( ((edtavTotalattractions_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14totalAttractions), "ZZZ9") : context.localUtil.Format( (decimal)(AV14totalAttractions), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotalattractions_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotalattractions_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ViewCountryInfo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_40_132e( true) ;
         }
         else
         {
            wb_table2_40_132e( false) ;
         }
      }

      protected void wb_table1_11_132( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAttractionnameform_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAttractionnameform_Internalname, "Attraction Name Form", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAttractionnameform_Internalname, StringUtil.RTrim( AV6AttractionNameForm), StringUtil.RTrim( context.localUtil.Format( AV6AttractionNameForm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAttractionnameform_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAttractionnameform_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ViewCountryInfo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavAttractionnameto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAttractionnameto_Internalname, "Attraction Name To", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAttractionnameto_Internalname, StringUtil.RTrim( AV7AttractionNameTo), StringUtil.RTrim( context.localUtil.Format( AV7AttractionNameTo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAttractionnameto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAttractionnameto_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ViewCountryInfo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"27\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Attraction Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Attraction Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Attraction Photo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Trips") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Image"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "Grid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A8AttractionName));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( A13AttractionPhoto));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8trips), 4, 0, ".", "")));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavTrips_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV10update));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( AV11newTrip));
               Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNewtrip_Enabled), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 27 )
         {
            wbEnd = 0;
            nRC_GXsfl_27 = (int)(nGXsfl_27_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotaltrips_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotaltrips_Internalname, "Total Trips", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_27_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotaltrips_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9totalTrips), 4, 0, ".", "")), StringUtil.LTrim( ((edtavTotaltrips_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9totalTrips), "ZZZ9") : context.localUtil.Format( (decimal)(AV9totalTrips), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotaltrips_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotaltrips_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ViewCountryInfo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_11_132e( true) ;
         }
         else
         {
            wb_table1_11_132e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5CountryId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV5CountryId", StringUtil.LTrimStr( (decimal)(AV5CountryId), 4, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA132( ) ;
         WS132( ) ;
         WE132( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20236151336626", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("viewcountryinfo.js", "?20236151336626", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_272( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_27_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_27_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_27_idx;
         edtavTrips_Internalname = "vTRIPS_"+sGXsfl_27_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_27_idx;
         edtavNewtrip_Internalname = "vNEWTRIP_"+sGXsfl_27_idx;
      }

      protected void SubsflControlProps_fel_272( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_27_fel_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_27_fel_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_27_fel_idx;
         edtavTrips_Internalname = "vTRIPS_"+sGXsfl_27_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_27_fel_idx;
         edtavNewtrip_Internalname = "vNEWTRIP_"+sGXsfl_27_fel_idx;
      }

      protected void sendrow_272( )
      {
         SubsflControlProps_272( ) ;
         WB130( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_27_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_27_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionName_Internalname,StringUtil.RTrim( A8AttractionName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+"e17132_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionName_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A13AttractionPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40002AttractionPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40002AttractionPhoto_GXI : context.PathToRelativeUrl( A13AttractionPhoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A13AttractionPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrips_Enabled!=0)&&(edtavTrips_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 31,'',false,'"+sGXsfl_27_idx+"',27)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavTrips_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8trips), 4, 0, ".", "")),StringUtil.LTrim( ((edtavTrips_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8trips), "ZZZ9") : context.localUtil.Format( (decimal)(AV8trips), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavTrips_Enabled!=0)&&(edtavTrips_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,31);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavTrips_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavTrips_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 32,'',false,'',27)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV10update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV10update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV10update)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV17Update_GXI : context.PathToRelativeUrl( AV10update));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavUpdate_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e18132_client"+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV10update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNewtrip_Enabled!=0)&&(edtavNewtrip_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 33,'',false,'"+sGXsfl_27_idx+"',27)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNewtrip_Internalname,StringUtil.RTrim( AV11newTrip),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNewtrip_Enabled!=0)&&(edtavNewtrip_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,33);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVNEWTRIP.CLICK."+sGXsfl_27_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNewtrip_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavNewtrip_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)27,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes132( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_27_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_27_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_27_idx+1);
         sGXsfl_27_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_27_idx), 4, 0), 4, "0");
         SubsflControlProps_272( ) ;
         /* End function sendrow_272 */
      }

      protected void SubsflControlProps_483( )
      {
         edtCityId_Internalname = "CITYID_"+sGXsfl_48_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_48_idx;
         edtavAttractions_Internalname = "vATTRACTIONS_"+sGXsfl_48_idx;
      }

      protected void SubsflControlProps_fel_483( )
      {
         edtCityId_Internalname = "CITYID_"+sGXsfl_48_fel_idx;
         edtCityName_Internalname = "CITYNAME_"+sGXsfl_48_fel_idx;
         edtavAttractions_Internalname = "vATTRACTIONS_"+sGXsfl_48_fel_idx;
      }

      protected void sendrow_483( )
      {
         SubsflControlProps_483( ) ;
         WB130( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0x0);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_48_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_48_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCityId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15CityId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15CityId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCityId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)48,(short)1,(short)-1,(short)0,(bool)false,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCityName_Internalname,StringUtil.RTrim( A16CityName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCityName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)48,(short)1,(short)-1,(short)-1,(bool)false,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAttractions_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12attractions), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12attractions), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAttractions_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)48,(short)1,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes133( ) ;
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_48_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_48_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_48_idx+1);
         sGXsfl_48_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_48_idx), 4, 0), 4, "0");
         SubsflControlProps_483( ) ;
         /* End function sendrow_483 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtCountryName_Internalname = "COUNTRYNAME";
         edtavAttractionnameform_Internalname = "vATTRACTIONNAMEFORM";
         edtavAttractionnameto_Internalname = "vATTRACTIONNAMETO";
         divTable1_Internalname = "TABLE1";
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO";
         edtavTrips_Internalname = "vTRIPS";
         edtavUpdate_Internalname = "vUPDATE";
         edtavNewtrip_Internalname = "vNEWTRIP";
         edtavTotaltrips_Internalname = "vTOTALTRIPS";
         tblTable2_Internalname = "TABLE2";
         edtavCityname_Internalname = "vCITYNAME";
         edtCityId_Internalname = "CITYID";
         edtCityName_Internalname = "CITYNAME";
         edtavAttractions_Internalname = "vATTRACTIONS";
         edtavTotalattractions_Internalname = "vTOTALATTRACTIONS";
         tblTable3_Internalname = "TABLE3";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
         subGrid2_Internalname = "GRID2";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavAttractions_Jsonclick = "";
         edtCityName_Jsonclick = "";
         edtCityId_Jsonclick = "";
         edtavNewtrip_Jsonclick = "";
         edtavNewtrip_Visible = -1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Visible = -1;
         edtavUpdate_Enabled = 1;
         edtavTrips_Jsonclick = "";
         edtavTrips_Visible = -1;
         edtAttractionName_Jsonclick = "";
         edtAttractionId_Jsonclick = "";
         edtavTotaltrips_Jsonclick = "";
         edtavTotaltrips_Enabled = 1;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavNewtrip_Enabled = 1;
         edtavTrips_Enabled = 1;
         subGrid1_Header = "";
         subGrid1_Class = "Grid";
         subGrid1_Backcolorstyle = 0;
         edtavAttractionnameto_Jsonclick = "";
         edtavAttractionnameto_Enabled = 1;
         edtavAttractionnameform_Jsonclick = "";
         edtavAttractionnameform_Enabled = 1;
         edtavTotalattractions_Jsonclick = "";
         edtavTotalattractions_Enabled = 1;
         subGrid2_Allowcollapsing = 0;
         subGrid2_Allowselection = 0;
         subGrid2_Header = "";
         subGrid2_Class = "Grid";
         subGrid2_Backcolorstyle = 0;
         edtavCityname_Jsonclick = "";
         edtavCityname_Enabled = 1;
         edtCountryName_Jsonclick = "";
         edtCountryName_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "View Country Info";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV10update',fld:'vUPDATE',pic:''},{av:'AV11newTrip',fld:'vNEWTRIP',pic:''},{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV6AttractionNameForm',fld:'vATTRACTIONNAMEFORM',pic:''},{av:'AV7AttractionNameTo',fld:'vATTRACTIONNAMETO',pic:''},{av:'AV13cityName',fld:'vCITYNAME',pic:''},{av:'AV14totalAttractions',fld:'vTOTALATTRACTIONS',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID1.LOAD","{handler:'E11132',iparms:[{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'}]");
         setEventMetadata("GRID1.LOAD",",oparms:[{av:'AV8trips',fld:'vTRIPS',pic:'ZZZ9'},{av:'A40000GXC1',fld:'GXC1',pic:'999999999'},{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID2.LOAD","{handler:'E15133',iparms:[{av:'AV14totalAttractions',fld:'vTOTALATTRACTIONS',pic:'ZZZ9'}]");
         setEventMetadata("GRID2.LOAD",",oparms:[{av:'AV12attractions',fld:'vATTRACTIONS',pic:'ZZZ9'},{av:'A40001GXC2',fld:'GXC2',pic:'999999999'},{av:'AV14totalAttractions',fld:'vTOTALATTRACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1.REFRESH","{handler:'E12132',iparms:[]");
         setEventMetadata("GRID1.REFRESH",",oparms:[{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'}]}");
         setEventMetadata("GRID2.REFRESH","{handler:'E16132',iparms:[]");
         setEventMetadata("GRID2.REFRESH",",oparms:[{av:'AV14totalAttractions',fld:'vTOTALATTRACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("VUPDATE.CLICK","{handler:'E18132',iparms:[{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("VUPDATE.CLICK",",oparms:[]}");
         setEventMetadata("VNEWTRIP.CLICK","{handler:'E14132',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV6AttractionNameForm',fld:'vATTRACTIONNAMEFORM',pic:''},{av:'AV7AttractionNameTo',fld:'vATTRACTIONNAMETO',pic:''},{av:'AV13cityName',fld:'vCITYNAME',pic:''},{av:'AV10update',fld:'vUPDATE',pic:''},{av:'AV11newTrip',fld:'vNEWTRIP',pic:''},{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'},{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9',hsh:true},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'AV14totalAttractions',fld:'vTOTALATTRACTIONS',pic:'ZZZ9'}]");
         setEventMetadata("VNEWTRIP.CLICK",",oparms:[{av:'AV8trips',fld:'vTRIPS',pic:'ZZZ9'}]}");
         setEventMetadata("ATTRACTIONNAME.CLICK","{handler:'E17132',iparms:[{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ATTRACTIONNAME.CLICK",",oparms:[]}");
         setEventMetadata("VALID_ATTRACTIONID","{handler:'Valid_Attractionid',iparms:[]");
         setEventMetadata("VALID_ATTRACTIONID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Newtrip',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_CITYID","{handler:'Valid_Cityid',iparms:[]");
         setEventMetadata("VALID_CITYID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Attractions',iparms:[]");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV10update = "";
         AV11newTrip = "";
         AV6AttractionNameForm = "";
         AV7AttractionNameTo = "";
         AV13cityName = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         A10CountryName = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         Grid2Container = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A8AttractionName = "";
         A13AttractionPhoto = "";
         A40002AttractionPhoto_GXI = "";
         AV17Update_GXI = "";
         A16CityName = "";
         scmdbuf = "";
         H00133_A10CountryName = new string[] {""} ;
         H00133_A9CountryId = new short[1] ;
         H00133_A40002AttractionPhoto_GXI = new string[] {""} ;
         H00133_A8AttractionName = new string[] {""} ;
         H00133_A7AttractionId = new short[1] ;
         H00133_A40000GXC1 = new int[1] ;
         H00133_n40000GXC1 = new bool[] {false} ;
         H00133_A13AttractionPhoto = new string[] {""} ;
         lV13cityName = "";
         H00135_A9CountryId = new short[1] ;
         H00135_A16CityName = new string[] {""} ;
         H00135_A15CityId = new short[1] ;
         H00135_A40001GXC2 = new int[1] ;
         H00135_n40001GXC2 = new bool[] {false} ;
         Grid1Row = new GXWebRow();
         Grid2Row = new GXWebRow();
         TempTags = "";
         subGrid2_Linesclass = "";
         Grid2Column = new GXWebColumn();
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.viewcountryinfo__default(),
            new Object[][] {
                new Object[] {
               H00133_A10CountryName, H00133_A9CountryId, H00133_A40002AttractionPhoto_GXI, H00133_A8AttractionName, H00133_A7AttractionId, H00133_A40000GXC1, H00133_n40000GXC1, H00133_A13AttractionPhoto
               }
               , new Object[] {
               H00135_A9CountryId, H00135_A16CityName, H00135_A15CityId, H00135_A40001GXC2, H00135_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrips_Enabled = 0;
         edtavNewtrip_Enabled = 0;
         edtavTotaltrips_Enabled = 0;
         edtavTotalattractions_Enabled = 0;
      }

      private short AV5CountryId ;
      private short wcpOAV5CountryId ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV9totalTrips ;
      private short AV14totalAttractions ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A7AttractionId ;
      private short AV8trips ;
      private short A15CityId ;
      private short AV12attractions ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short A9CountryId ;
      private short subGrid2_Backcolorstyle ;
      private short GXt_int1 ;
      private short GRID1_nEOF ;
      private short GRID2_nEOF ;
      private short subGrid2_Titlebackstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subGrid1_Backstyle ;
      private short subGrid2_Backstyle ;
      private int nRC_GXsfl_27 ;
      private int nRC_GXsfl_48 ;
      private int nGXsfl_27_idx=1 ;
      private int nGXsfl_48_idx=1 ;
      private int edtCountryName_Enabled ;
      private int subGrid1_Islastpage ;
      private int subGrid2_Islastpage ;
      private int edtavTrips_Enabled ;
      private int edtavNewtrip_Enabled ;
      private int edtavTotaltrips_Enabled ;
      private int edtavTotalattractions_Enabled ;
      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private int edtavCityname_Enabled ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Allbackcolor ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private int edtavAttractionnameform_Enabled ;
      private int edtavAttractionnameto_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int edtavTrips_Visible ;
      private int edtavUpdate_Enabled ;
      private int edtavUpdate_Visible ;
      private int edtavNewtrip_Visible ;
      private int subGrid2_Backcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID2_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID2_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_27_idx="0001" ;
      private string AV11newTrip ;
      private string AV6AttractionNameForm ;
      private string AV7AttractionNameTo ;
      private string AV13cityName ;
      private string sGXsfl_48_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string edtCountryName_Internalname ;
      private string A10CountryName ;
      private string edtCountryName_Jsonclick ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAttractionId_Internalname ;
      private string A8AttractionName ;
      private string edtAttractionName_Internalname ;
      private string edtAttractionPhoto_Internalname ;
      private string edtavTrips_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavNewtrip_Internalname ;
      private string edtCityId_Internalname ;
      private string A16CityName ;
      private string edtCityName_Internalname ;
      private string edtavAttractions_Internalname ;
      private string edtavAttractionnameform_Internalname ;
      private string edtavTotaltrips_Internalname ;
      private string edtavTotalattractions_Internalname ;
      private string scmdbuf ;
      private string lV13cityName ;
      private string edtavAttractionnameto_Internalname ;
      private string edtavCityname_Internalname ;
      private string tblTable3_Internalname ;
      private string TempTags ;
      private string edtavCityname_Jsonclick ;
      private string subGrid2_Internalname ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string subGrid2_Header ;
      private string edtavTotalattractions_Jsonclick ;
      private string tblTable2_Internalname ;
      private string divTable1_Internalname ;
      private string edtavAttractionnameform_Jsonclick ;
      private string edtavAttractionnameto_Jsonclick ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavTotaltrips_Jsonclick ;
      private string sGXsfl_27_fel_idx="0001" ;
      private string ROClassString ;
      private string edtAttractionId_Jsonclick ;
      private string edtAttractionName_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtavTrips_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavNewtrip_Jsonclick ;
      private string sGXsfl_48_fel_idx="0001" ;
      private string edtCityId_Jsonclick ;
      private string edtCityName_Jsonclick ;
      private string edtavAttractions_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_27_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000GXC1 ;
      private bool bGXsfl_48_Refreshing=false ;
      private bool n40001GXC2 ;
      private bool returnInSub ;
      private bool A13AttractionPhoto_IsBlob ;
      private bool AV10update_IsBlob ;
      private string A40002AttractionPhoto_GXI ;
      private string AV17Update_GXI ;
      private string AV10update ;
      private string A13AttractionPhoto ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid Grid2Container ;
      private GXWebRow Grid1Row ;
      private GXWebRow Grid2Row ;
      private GXWebColumn Grid2Column ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H00133_A10CountryName ;
      private short[] H00133_A9CountryId ;
      private string[] H00133_A40002AttractionPhoto_GXI ;
      private string[] H00133_A8AttractionName ;
      private short[] H00133_A7AttractionId ;
      private int[] H00133_A40000GXC1 ;
      private bool[] H00133_n40000GXC1 ;
      private string[] H00133_A13AttractionPhoto ;
      private short[] H00135_A9CountryId ;
      private string[] H00135_A16CityName ;
      private short[] H00135_A15CityId ;
      private int[] H00135_A40001GXC2 ;
      private bool[] H00135_n40001GXC2 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class viewcountryinfo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00133( IGxContext context ,
                                             string AV6AttractionNameForm ,
                                             string AV7AttractionNameTo ,
                                             string A8AttractionName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[2];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[CountryName], T1.[CountryId], T1.[AttractionPhoto_GXI], T1.[AttractionName], T1.[AttractionId], COALESCE( T3.[GXC1], 0) AS GXC1, T1.[AttractionPhoto] FROM (([Attraction] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN (SELECT COUNT(*) AS GXC1, T4.[AttractionId] FROM ([TripAttraction] T4 INNER JOIN [Trip] T5 ON T5.[TripId] = T4.[TripId]) GROUP BY T4.[AttractionId] ) T3 ON T3.[AttractionId] = T1.[AttractionId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6AttractionNameForm)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] >= @AV6AttractionNameForm)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7AttractionNameTo)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] <= @AV7AttractionNameTo)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CountryId], T1.[AttractionName]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_H00135( IGxContext context ,
                                             string AV13cityName ,
                                             string A16CityName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[1];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[CountryId], T1.[CityName], T1.[CityId], COALESCE( T2.[GXC2], 0) AS GXC2 FROM ([CountryCity] T1 LEFT JOIN (SELECT COUNT(*) AS GXC2, [CountryId], [CityId] FROM [Attraction] GROUP BY [CountryId], [CityId] ) T2 ON T2.[CountryId] = T1.[CountryId] AND T2.[CityId] = T1.[CityId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cityName)) )
         {
            AddWhere(sWhereString, "(T1.[CityName] like @lV13cityName)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CountryId], T1.[CityId]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00133(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] );
               case 1 :
                     return conditional_H00135(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00133;
          prmH00133 = new Object[] {
          new ParDef("@AV6AttractionNameForm",GXType.Char,50,0) ,
          new ParDef("@AV7AttractionNameTo",GXType.Char,50,0)
          };
          Object[] prmH00135;
          prmH00135 = new Object[] {
          new ParDef("@lV13cityName",GXType.NChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00133", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00133,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00135", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00135,11, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
