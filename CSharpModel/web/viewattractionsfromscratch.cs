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
   public class viewattractionsfromscratch : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public viewattractionsfromscratch( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public viewattractionsfromscratch( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_AttractionId )
      {
         this.A7AttractionId = aP0_AttractionId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavCountryid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "AttractionId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCOUNTRYID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCOUNTRYID112( ) ;
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
               gxfirstwebparm = GetFirstPar( "AttractionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "AttractionId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_24 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_24"), "."));
               nGXsfl_24_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_24_idx"), "."));
               sGXsfl_24_idx = GetPar( "sGXsfl_24_idx");
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
               dynavCountryid.FromJSonString( GetNextPar( ));
               AV5CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
               AV6AttractionNameForm = GetPar( "AttractionNameForm");
               AV7AttractionNameTo = GetPar( "AttractionNameTo");
               A7AttractionId = (short)(NumberUtil.Val( GetPar( "AttractionId"), "."));
               AV10update = GetPar( "update");
               AV11newTrip = GetPar( "newTrip");
               AV9totalTrips = (short)(NumberUtil.Val( GetPar( "totalTrips"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( AV5CountryId, AV6AttractionNameForm, AV7AttractionNameTo, A7AttractionId, AV10update, AV11newTrip, AV9totalTrips) ;
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
               A7AttractionId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
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
         PA112( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START112( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202361414565137", false, true);
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("viewattractionsfromscratch.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A7AttractionId,4,0))}, new string[] {"AttractionId"}) +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ViewAttractionsFromScratch");
         forbiddenHiddens.Add("totalTrips", context.localUtil.Format( (decimal)(AV9totalTrips), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("viewattractionsfromscratch:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vATTRACTIONNAMEFORM", StringUtil.RTrim( AV6AttractionNameForm));
         GxWebStd.gx_hidden_field( context, "GXH_vATTRACTIONNAMETO", StringUtil.RTrim( AV7AttractionNameTo));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_24", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_24), 8, 0, ".", "")));
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
         context.WriteHtmlTextNl( "</form>") ;
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
            WE112( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT112( ) ;
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
         return formatLink("viewattractionsfromscratch.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A7AttractionId,4,0))}, new string[] {"AttractionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "ViewAttractionsFromScratch" ;
      }

      public override string GetPgmdesc( )
      {
         return "View Attractions From Scratch" ;
      }

      protected void WB110( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavCountryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCountryid_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'" + sGXsfl_24_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCountryid, dynavCountryid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5CountryId), 4, 0)), 1, dynavCountryid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCountryid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", "", true, 1, "HLP_ViewAttractionsFromScratch.htm");
            dynavCountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5CountryId), 4, 0));
            AssignProp("", false, dynavCountryid_Internalname, "Values", (string)(dynavCountryid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAttractionnameform_Internalname, StringUtil.RTrim( AV6AttractionNameForm), StringUtil.RTrim( context.localUtil.Format( AV6AttractionNameForm, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAttractionnameform_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAttractionnameform_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ViewAttractionsFromScratch.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAttractionnameto_Internalname, StringUtil.RTrim( AV7AttractionNameTo), StringUtil.RTrim( context.localUtil.Format( AV7AttractionNameTo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAttractionnameto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAttractionnameto_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ViewAttractionsFromScratch.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"24\">") ;
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Country Name") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A10CountryName));
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
         if ( wbEnd == 24 )
         {
            wbEnd = 0;
            nRC_GXsfl_24 = (int)(nGXsfl_24_idx-1);
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTotaltrips_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTotaltrips_Internalname, "Total Trips", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTotaltrips_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9totalTrips), 4, 0, ".", "")), StringUtil.LTrim( ((edtavTotaltrips_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9totalTrips), "ZZZ9") : context.localUtil.Format( (decimal)(AV9totalTrips), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTotaltrips_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTotaltrips_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ViewAttractionsFromScratch.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 24 )
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
         wbLoad = true;
      }

      protected void START112( )
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
            Form.Meta.addItem("description", "View Attractions From Scratch", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP110( ) ;
      }

      protected void WS112( )
      {
         START112( ) ;
         EVT112( ) ;
      }

      protected void EVT112( )
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VNEWTRIP.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 14), "VNEWTRIP.CLICK") == 0 ) )
                           {
                              nGXsfl_24_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
                              SubsflControlProps_242( ) ;
                              A7AttractionId = (short)(context.localUtil.CToN( cgiGet( edtAttractionId_Internalname), ".", ","));
                              A8AttractionName = cgiGet( edtAttractionName_Internalname);
                              A10CountryName = cgiGet( edtCountryName_Internalname);
                              A13AttractionPhoto = cgiGet( edtAttractionPhoto_Internalname);
                              AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40001AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_24_Refreshing);
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
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV14Update_GXI : context.convertURL( context.PathToRelativeUrl( AV10update))), !bGXsfl_24_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV10update), true);
                              AV11newTrip = cgiGet( edtavNewtrip_Internalname);
                              AssignAttri("", false, edtavNewtrip_Internalname, AV11newTrip);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E11112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VNEWTRIP.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E14112 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Countryid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOUNTRYID"), ".", ",") != Convert.ToDecimal( AV5CountryId )) )
                                       {
                                          Rfr0gs = true;
                                       }
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE112( )
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

      protected void PA112( )
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
               GX_FocusControl = dynavCountryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCOUNTRYID112( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCOUNTRYID_data112( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvCOUNTRYID_html112( )
      {
         short gxdynajaxvalue;
         GXDLVvCOUNTRYID_data112( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCountryid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavCountryid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCOUNTRYID_data112( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("Select");
         /* Using cursor H00112 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00112_A9CountryId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H00112_A10CountryName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_242( ) ;
         while ( nGXsfl_24_idx <= nRC_GXsfl_24 )
         {
            sendrow_242( ) ;
            nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( short AV5CountryId ,
                                        string AV6AttractionNameForm ,
                                        string AV7AttractionNameTo ,
                                        short A7AttractionId ,
                                        string AV10update ,
                                        string AV11newTrip ,
                                        short AV9totalTrips )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E12112 ();
         GRID1_nCurrentRecord = 0;
         RF112( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ViewAttractionsFromScratch");
         forbiddenHiddens.Add("totalTrips", context.localUtil.Format( (decimal)(AV9totalTrips), "ZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("viewattractionsfromscratch:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
         /* End function gxgrGrid1_refresh */
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
            GXVvCOUNTRYID_html112( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCountryid.ItemCount > 0 )
         {
            AV5CountryId = (short)(NumberUtil.Val( dynavCountryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5CountryId), 4, 0))), "."));
            AssignAttri("", false, "AV5CountryId", StringUtil.LTrimStr( (decimal)(AV5CountryId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5CountryId), 4, 0));
            AssignProp("", false, dynavCountryid_Internalname, "Values", dynavCountryid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF112( ) ;
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
         AssignProp("", false, edtavTrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrips_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         edtavNewtrip_Enabled = 0;
         AssignProp("", false, edtavNewtrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNewtrip_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         edtavTotaltrips_Enabled = 0;
         AssignProp("", false, edtavTotaltrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaltrips_Enabled), 5, 0), true);
      }

      protected void RF112( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 24;
         /* Execute user event: Refresh */
         E12112 ();
         nGXsfl_24_idx = 1;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         bGXsfl_24_Refreshing = true;
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
            SubsflControlProps_242( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV5CountryId ,
                                                 AV6AttractionNameForm ,
                                                 AV7AttractionNameTo ,
                                                 A9CountryId ,
                                                 A8AttractionName ,
                                                 A7AttractionId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H00114 */
            pr_default.execute(1, new Object[] {A7AttractionId, AV5CountryId, AV6AttractionNameForm, AV7AttractionNameTo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A9CountryId = H00114_A9CountryId[0];
               A40001AttractionPhoto_GXI = H00114_A40001AttractionPhoto_GXI[0];
               AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40001AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_24_Refreshing);
               AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
               A10CountryName = H00114_A10CountryName[0];
               A8AttractionName = H00114_A8AttractionName[0];
               A40000GXC1 = H00114_A40000GXC1[0];
               n40000GXC1 = H00114_n40000GXC1[0];
               A13AttractionPhoto = H00114_A13AttractionPhoto[0];
               AssignProp("", false, edtAttractionPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40001AttractionPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A13AttractionPhoto))), !bGXsfl_24_Refreshing);
               AssignProp("", false, edtAttractionPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A13AttractionPhoto), true);
               A10CountryName = H00114_A10CountryName[0];
               A40000GXC1 = H00114_A40000GXC1[0];
               n40000GXC1 = H00114_n40000GXC1[0];
               /* Execute user event: Load */
               E11112 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            wbEnd = 24;
            WB110( ) ;
         }
         bGXsfl_24_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes112( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ATTRACTIONID"+"_"+sGXsfl_24_idx, GetSecureSignedToken( sGXsfl_24_idx, context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9"), context));
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

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTrips_Enabled = 0;
         AssignProp("", false, edtavTrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTrips_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         edtavNewtrip_Enabled = 0;
         AssignProp("", false, edtavNewtrip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNewtrip_Enabled), 5, 0), !bGXsfl_24_Refreshing);
         edtavTotaltrips_Enabled = 0;
         AssignProp("", false, edtavTotaltrips_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTotaltrips_Enabled), 5, 0), true);
         GXVvCOUNTRYID_html112( ) ;
         /* Using cursor H00116 */
         pr_default.execute(2, new Object[] {A7AttractionId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = H00116_A40000GXC1[0];
            n40000GXC1 = H00116_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(2);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP110( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13112 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_24 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_24"), ".", ","));
            /* Read variables values. */
            dynavCountryid.Name = dynavCountryid_Internalname;
            dynavCountryid.CurrentValue = cgiGet( dynavCountryid_Internalname);
            AV5CountryId = (short)(NumberUtil.Val( cgiGet( dynavCountryid_Internalname), "."));
            AssignAttri("", false, "AV5CountryId", StringUtil.LTrimStr( (decimal)(AV5CountryId), 4, 0));
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
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"ViewAttractionsFromScratch");
            AV9totalTrips = (short)(context.localUtil.CToN( cgiGet( edtavTotaltrips_Internalname), ".", ","));
            AssignAttri("", false, "AV9totalTrips", StringUtil.LTrimStr( (decimal)(AV9totalTrips), 4, 0));
            forbiddenHiddens.Add("totalTrips", context.localUtil.Format( (decimal)(AV9totalTrips), "ZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("viewattractionsfromscratch:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E11112( )
      {
         /* Load Routine */
         returnInSub = false;
         AV8trips = (short)(A40000GXC1);
         AssignAttri("", false, edtavTrips_Internalname, StringUtil.LTrimStr( (decimal)(AV8trips), 4, 0));
         AV9totalTrips = (short)(AV9totalTrips+AV8trips);
         AssignAttri("", false, "AV9totalTrips", StringUtil.LTrimStr( (decimal)(AV9totalTrips), 4, 0));
         sendrow_242( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_24_Refreshing )
         {
            context.DoAjaxLoad(24, Grid1Row);
         }
      }

      protected void E12112( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         AV9totalTrips = 0;
         AssignAttri("", false, "AV9totalTrips", StringUtil.LTrimStr( (decimal)(AV9totalTrips), 4, 0));
         /*  Sending Event outputs  */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13112( )
      {
         /* Start Routine */
         returnInSub = false;
         AV10update = context.GetImagePath( "2c23d666-bf81-474c-9f82-9a0d6f117c27", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV14Update_GXI : context.convertURL( context.PathToRelativeUrl( AV10update))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV10update), true);
         AV14Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "2c23d666-bf81-474c-9f82-9a0d6f117c27", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV14Update_GXI : context.convertURL( context.PathToRelativeUrl( AV10update))), !bGXsfl_24_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV10update), true);
         AV11newTrip = "New Trip";
         AssignAttri("", false, edtavNewtrip_Internalname, AV11newTrip);
      }

      protected void E14112( )
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

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A7AttractionId = Convert.ToInt16(getParm(obj,0));
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
         PA112( ) ;
         WS112( ) ;
         WE112( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202361414565763", true, true);
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
         context.AddJavascriptSource("viewattractionsfromscratch.js", "?202361414565765", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_242( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_24_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_24_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_24_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_24_idx;
         edtavTrips_Internalname = "vTRIPS_"+sGXsfl_24_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_24_idx;
         edtavNewtrip_Internalname = "vNEWTRIP_"+sGXsfl_24_idx;
      }

      protected void SubsflControlProps_fel_242( )
      {
         edtAttractionId_Internalname = "ATTRACTIONID_"+sGXsfl_24_fel_idx;
         edtAttractionName_Internalname = "ATTRACTIONNAME_"+sGXsfl_24_fel_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_24_fel_idx;
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO_"+sGXsfl_24_fel_idx;
         edtavTrips_Internalname = "vTRIPS_"+sGXsfl_24_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_24_fel_idx;
         edtavNewtrip_Internalname = "vNEWTRIP_"+sGXsfl_24_fel_idx;
      }

      protected void sendrow_242( )
      {
         SubsflControlProps_242( ) ;
         WB110( ) ;
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
            if ( ((int)((nGXsfl_24_idx) % (2))) == 0 )
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
            context.WriteHtmlText( " gxrow=\""+sGXsfl_24_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AttractionId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionName_Internalname,StringUtil.RTrim( A8AttractionName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAttractionName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryName_Internalname,StringUtil.RTrim( A10CountryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCountryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A13AttractionPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001AttractionPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A13AttractionPhoto)) ? A40001AttractionPhoto_GXI : context.PathToRelativeUrl( A13AttractionPhoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAttractionPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A13AttractionPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavTrips_Enabled!=0)&&(edtavTrips_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 29,'',false,'"+sGXsfl_24_idx+"',24)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavTrips_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8trips), 4, 0, ".", "")),StringUtil.LTrim( ((edtavTrips_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8trips), "ZZZ9") : context.localUtil.Format( (decimal)(AV8trips), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavTrips_Enabled!=0)&&(edtavTrips_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,29);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavTrips_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavTrips_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavUpdate_Enabled!=0)&&(edtavUpdate_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 30,'',false,'',24)\"" : " ");
         ClassString = "Image";
         StyleString = "";
         AV10update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV10update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV14Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV10update)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV10update)) ? AV14Update_GXI : context.PathToRelativeUrl( AV10update));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)7,(string)edtavUpdate_Jsonclick,(string)"'"+""+"'"+",false,"+"'"+"e15112_client"+"'",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV10update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavNewtrip_Enabled!=0)&&(edtavNewtrip_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 31,'',false,'"+sGXsfl_24_idx+"',24)\"" : " ");
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNewtrip_Internalname,StringUtil.RTrim( AV11newTrip),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavNewtrip_Enabled!=0)&&(edtavNewtrip_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,31);\"" : " "),"'"+""+"'"+",false,"+"'"+"EVNEWTRIP.CLICK."+sGXsfl_24_idx+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNewtrip_Jsonclick,(short)5,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavNewtrip_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes112( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         /* End function sendrow_242 */
      }

      protected void init_web_controls( )
      {
         dynavCountryid.Name = "vCOUNTRYID";
         dynavCountryid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavCountryid_Internalname = "vCOUNTRYID";
         edtavAttractionnameform_Internalname = "vATTRACTIONNAMEFORM";
         edtavAttractionnameto_Internalname = "vATTRACTIONNAMETO";
         divTable1_Internalname = "TABLE1";
         edtAttractionId_Internalname = "ATTRACTIONID";
         edtAttractionName_Internalname = "ATTRACTIONNAME";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtAttractionPhoto_Internalname = "ATTRACTIONPHOTO";
         edtavTrips_Internalname = "vTRIPS";
         edtavUpdate_Internalname = "vUPDATE";
         edtavNewtrip_Internalname = "vNEWTRIP";
         edtavTotaltrips_Internalname = "vTOTALTRIPS";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavNewtrip_Jsonclick = "";
         edtavNewtrip_Visible = -1;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Visible = -1;
         edtavUpdate_Enabled = 1;
         edtavTrips_Jsonclick = "";
         edtavTrips_Visible = -1;
         edtCountryName_Jsonclick = "";
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
         dynavCountryid_Jsonclick = "";
         dynavCountryid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "View Attractions From Scratch";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV6AttractionNameForm',fld:'vATTRACTIONNAMEFORM',pic:''},{av:'AV7AttractionNameTo',fld:'vATTRACTIONNAMETO',pic:''},{av:'AV10update',fld:'vUPDATE',pic:''},{av:'AV11newTrip',fld:'vNEWTRIP',pic:''},{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'},{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9',hsh:true},{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'},{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
         setEventMetadata("VUPDATE.CLICK","{handler:'E15112',iparms:[{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9',hsh:true},{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("VUPDATE.CLICK",",oparms:[{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
         setEventMetadata("VNEWTRIP.CLICK","{handler:'E14112',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV6AttractionNameForm',fld:'vATTRACTIONNAMEFORM',pic:''},{av:'AV7AttractionNameTo',fld:'vATTRACTIONNAMETO',pic:''},{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9',hsh:true},{av:'AV10update',fld:'vUPDATE',pic:''},{av:'AV11newTrip',fld:'vNEWTRIP',pic:''},{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'},{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("VNEWTRIP.CLICK",",oparms:[{av:'AV8trips',fld:'vTRIPS',pic:'ZZZ9'},{av:'AV9totalTrips',fld:'vTOTALTRIPS',pic:'ZZZ9'},{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_ATTRACTIONID","{handler:'Valid_Attractionid',iparms:[{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_ATTRACTIONID",",oparms:[{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Validv_Newtrip',iparms:[{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynavCountryid'},{av:'AV5CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         A8AttractionName = "";
         A10CountryName = "";
         A13AttractionPhoto = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A40001AttractionPhoto_GXI = "";
         AV14Update_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00112_A9CountryId = new short[1] ;
         H00112_A10CountryName = new string[] {""} ;
         H00114_A7AttractionId = new short[1] ;
         H00114_A9CountryId = new short[1] ;
         H00114_A40001AttractionPhoto_GXI = new string[] {""} ;
         H00114_A10CountryName = new string[] {""} ;
         H00114_A8AttractionName = new string[] {""} ;
         H00114_A40000GXC1 = new int[1] ;
         H00114_n40000GXC1 = new bool[] {false} ;
         H00114_A13AttractionPhoto = new string[] {""} ;
         H00116_A40000GXC1 = new int[1] ;
         H00116_n40000GXC1 = new bool[] {false} ;
         hsh = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.viewattractionsfromscratch__default(),
            new Object[][] {
                new Object[] {
               H00112_A9CountryId, H00112_A10CountryName
               }
               , new Object[] {
               H00114_A7AttractionId, H00114_A9CountryId, H00114_A40001AttractionPhoto_GXI, H00114_A10CountryName, H00114_A8AttractionName, H00114_A40000GXC1, H00114_n40000GXC1, H00114_A13AttractionPhoto
               }
               , new Object[] {
               H00116_A40000GXC1, H00116_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTrips_Enabled = 0;
         edtavNewtrip_Enabled = 0;
         edtavTotaltrips_Enabled = 0;
      }

      private short A7AttractionId ;
      private short wcpOA7AttractionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV5CountryId ;
      private short AV9totalTrips ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short AV8trips ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A9CountryId ;
      private short GRID1_nEOF ;
      private short GXt_int1 ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_24 ;
      private int nGXsfl_24_idx=1 ;
      private int edtavAttractionnameform_Enabled ;
      private int edtavAttractionnameto_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int edtavTrips_Enabled ;
      private int edtavNewtrip_Enabled ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int edtavTotaltrips_Enabled ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int A40000GXC1 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int edtavTrips_Visible ;
      private int edtavUpdate_Enabled ;
      private int edtavUpdate_Visible ;
      private int edtavNewtrip_Visible ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_24_idx="0001" ;
      private string AV11newTrip ;
      private string AV6AttractionNameForm ;
      private string AV7AttractionNameTo ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string dynavCountryid_Internalname ;
      private string TempTags ;
      private string dynavCountryid_Jsonclick ;
      private string divTable1_Internalname ;
      private string edtavAttractionnameform_Internalname ;
      private string edtavAttractionnameform_Jsonclick ;
      private string edtavAttractionnameto_Internalname ;
      private string edtavAttractionnameto_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string A8AttractionName ;
      private string A10CountryName ;
      private string edtavTotaltrips_Internalname ;
      private string edtavTotaltrips_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAttractionId_Internalname ;
      private string edtAttractionName_Internalname ;
      private string edtCountryName_Internalname ;
      private string edtAttractionPhoto_Internalname ;
      private string edtavTrips_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavNewtrip_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string hsh ;
      private string sGXsfl_24_fel_idx="0001" ;
      private string ROClassString ;
      private string edtAttractionId_Jsonclick ;
      private string edtAttractionName_Jsonclick ;
      private string edtCountryName_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtavTrips_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavNewtrip_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_24_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000GXC1 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool A13AttractionPhoto_IsBlob ;
      private bool AV10update_IsBlob ;
      private string A40001AttractionPhoto_GXI ;
      private string AV14Update_GXI ;
      private string AV10update ;
      private string A13AttractionPhoto ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCountryid ;
      private IDataStoreProvider pr_default ;
      private short[] H00112_A9CountryId ;
      private string[] H00112_A10CountryName ;
      private short[] H00114_A7AttractionId ;
      private short[] H00114_A9CountryId ;
      private string[] H00114_A40001AttractionPhoto_GXI ;
      private string[] H00114_A10CountryName ;
      private string[] H00114_A8AttractionName ;
      private int[] H00114_A40000GXC1 ;
      private bool[] H00114_n40000GXC1 ;
      private string[] H00114_A13AttractionPhoto ;
      private int[] H00116_A40000GXC1 ;
      private bool[] H00116_n40000GXC1 ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class viewattractionsfromscratch__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00114( IGxContext context ,
                                             short AV5CountryId ,
                                             string AV6AttractionNameForm ,
                                             string AV7AttractionNameTo ,
                                             short A9CountryId ,
                                             string A8AttractionName ,
                                             short A7AttractionId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[AttractionId], T1.[CountryId], T1.[AttractionPhoto_GXI], T2.[CountryName], T1.[AttractionName], COALESCE( T3.[GXC1], 0) AS GXC1, T1.[AttractionPhoto] FROM (([Attraction] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN (SELECT COUNT(*) AS GXC1, T4.[AttractionId] FROM ([TripAttraction] T4 INNER JOIN [Trip] T5 ON T5.[TripId] = T4.[TripId]) GROUP BY T4.[AttractionId] ) T3 ON T3.[AttractionId] = T1.[AttractionId])";
         AddWhere(sWhereString, "(T1.[AttractionId] = @AttractionId)");
         if ( ! (0==AV5CountryId) )
         {
            AddWhere(sWhereString, "(T1.[CountryId] = @AV5CountryId)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6AttractionNameForm)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] >= @AV6AttractionNameForm)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7AttractionNameTo)) )
         {
            AddWhere(sWhereString, "(T1.[AttractionName] <= @AV7AttractionNameTo)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         if ( ! (0==AV5CountryId) )
         {
            scmdbuf += " ORDER BY T1.[CountryId], T1.[AttractionName]";
         }
         else if ( true )
         {
            scmdbuf += " ORDER BY T1.[AttractionName]";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H00114(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00112;
          prmH00112 = new Object[] {
          };
          Object[] prmH00116;
          prmH00116 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0)
          };
          Object[] prmH00114;
          prmH00114 = new Object[] {
          new ParDef("@AttractionId",GXType.Int16,4,0) ,
          new ParDef("@AV5CountryId",GXType.Int16,4,0) ,
          new ParDef("@AV6AttractionNameForm",GXType.Char,50,0) ,
          new ParDef("@AV7AttractionNameTo",GXType.Char,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00112", "SELECT [CountryId], [CountryName] FROM [Country] ORDER BY [CountryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00112,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00114", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00114,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H00116", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1, T2.[AttractionId] FROM ([TripAttraction] T2 INNER JOIN [Trip] T3 ON T3.[TripId] = T2.[TripId]) GROUP BY T2.[AttractionId] ) T1 WHERE T1.[AttractionId] = @AttractionId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00116,1, GxCacheFrequency.OFF ,true,true )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 50);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(3));
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
