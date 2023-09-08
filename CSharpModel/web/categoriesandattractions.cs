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
   public class categoriesandattractions : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public categoriesandattractions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public categoriesandattractions( IGxContext context )
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
         PA0V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0V2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20236151021358", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("categoriesandattractions.aspx") +"\">") ;
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
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCATEGORY", AV5category);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCATEGORY", AV5category);
         }
         GxWebStd.gx_hidden_field( context, "CITYNAME", StringUtil.RTrim( A16CityName));
         GxWebStd.gx_hidden_field( context, "CATEGORYNAME", StringUtil.RTrim( A12CategoryName));
         GxWebStd.gx_hidden_field( context, "ATTRACTIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AttractionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40001CategoryId), 4, 0, ".", "")));
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
            WE0V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0V2( ) ;
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
         return formatLink("categoriesandattractions.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CategoriesandAttractions" ;
      }

      public override string GetPgmdesc( )
      {
         return "Categoriesand Attractions" ;
      }

      protected void WB0V0( )
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Create the new category \"Tourist site\" and assign it to all the attractions of beijing with category \"Museum\"", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CategoriesandAttractions.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttDo_Internalname, "", "Do", bttDo_Jsonclick, 5, "Do", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CategoriesandAttractions.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 11,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttUndo_Internalname, "", "Undo", bttUndo_Jsonclick, 5, "Undo", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'UNDO\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CategoriesandAttractions.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0V2( )
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
            Form.Meta.addItem("description", "Categoriesand Attractions", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0V0( ) ;
      }

      protected void WS0V2( )
      {
         START0V2( ) ;
         EVT0V2( ) ;
      }

      protected void EVT0V2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'DO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Do' */
                              E110V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'UNDO'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Undo' */
                              E120V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E130V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0V2( )
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

      protected void PA0V2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF0V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E130V2 ();
            WB0V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0V2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         /* Using cursor H000V3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40001CategoryId = H000V3_A40001CategoryId[0];
            n40001CategoryId = H000V3_n40001CategoryId[0];
         }
         else
         {
            A40001CategoryId = 0;
            n40001CategoryId = false;
            AssignAttri("", false, "A40001CategoryId", StringUtil.LTrimStr( (decimal)(A40001CategoryId), 4, 0));
         }
         pr_default.close(0);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E110V2( )
      {
         /* 'Do' Routine */
         returnInSub = false;
         AV5category.gxTpr_Categoryname = "Tourist site";
         if ( AV5category.Insert() )
         {
            /* Using cursor H000V4 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A9CountryId = H000V4_A9CountryId[0];
               A15CityId = H000V4_A15CityId[0];
               A11CategoryId = H000V4_A11CategoryId[0];
               n11CategoryId = H000V4_n11CategoryId[0];
               A12CategoryName = H000V4_A12CategoryName[0];
               A16CityName = H000V4_A16CityName[0];
               A7AttractionId = H000V4_A7AttractionId[0];
               A16CityName = H000V4_A16CityName[0];
               A12CategoryName = H000V4_A12CategoryName[0];
               AV6attraction.Load(A7AttractionId);
               AV6attraction.gxTpr_Categoryid = AV5category.gxTpr_Categoryid;
               AV6attraction.Update();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            context.CommitDataStores("categoriesandattractions",pr_default);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5category", AV5category);
      }

      protected void E120V2( )
      {
         /* 'Undo' Routine */
         returnInSub = false;
         /* Using cursor H000V6 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            A9CountryId = H000V6_A9CountryId[0];
            A15CityId = H000V6_A15CityId[0];
            A11CategoryId = H000V6_A11CategoryId[0];
            n11CategoryId = H000V6_n11CategoryId[0];
            A12CategoryName = H000V6_A12CategoryName[0];
            A16CityName = H000V6_A16CityName[0];
            A7AttractionId = H000V6_A7AttractionId[0];
            A40000CategoryId = H000V6_A40000CategoryId[0];
            n40000CategoryId = H000V6_n40000CategoryId[0];
            A16CityName = H000V6_A16CityName[0];
            A12CategoryName = H000V6_A12CategoryName[0];
            A40000CategoryId = H000V6_A40000CategoryId[0];
            n40000CategoryId = H000V6_n40000CategoryId[0];
            AV6attraction.Load(A7AttractionId);
            AV6attraction.gxTpr_Categoryid = A40000CategoryId;
            AV6attraction.Update();
            pr_default.readNext(2);
         }
         pr_default.close(2);
         /* Using cursor H000V8 */
         pr_default.execute(3);
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40001CategoryId = H000V8_A40001CategoryId[0];
            n40001CategoryId = H000V8_n40001CategoryId[0];
         }
         else
         {
            A40001CategoryId = 0;
            n40001CategoryId = false;
            AssignAttri("", false, "A40001CategoryId", StringUtil.LTrimStr( (decimal)(A40001CategoryId), 4, 0));
         }
         pr_default.close(3);
         AV7categoryId = A40001CategoryId;
         AV5category.Load(AV7categoryId);
         AV5category.Delete();
         if ( AV6attraction.Success() )
         {
            context.CommitDataStores("categoriesandattractions",pr_default);
         }
         else
         {
            context.RollbackDataStores("categoriesandattractions",pr_default);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5category", AV5category);
      }

      protected void nextLoad( )
      {
      }

      protected void E130V2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA0V2( ) ;
         WS0V2( ) ;
         WE0V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202361510213523", true, true);
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
         context.AddJavascriptSource("categoriesandattractions.js", "?202361510213523", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         bttDo_Internalname = "DO";
         bttUndo_Internalname = "UNDO";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Categoriesand Attractions";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DO'","{handler:'E110V2',iparms:[{av:'AV5category',fld:'vCATEGORY',pic:''},{av:'A16CityName',fld:'CITYNAME',pic:''},{av:'A12CategoryName',fld:'CATEGORYNAME',pic:''},{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9'}]");
         setEventMetadata("'DO'",",oparms:[{av:'AV5category',fld:'vCATEGORY',pic:''}]}");
         setEventMetadata("'UNDO'","{handler:'E120V2',iparms:[{av:'A16CityName',fld:'CITYNAME',pic:''},{av:'A12CategoryName',fld:'CATEGORYNAME',pic:''},{av:'A7AttractionId',fld:'ATTRACTIONID',pic:'ZZZ9'}]");
         setEventMetadata("'UNDO'",",oparms:[{av:'A40000CategoryId',fld:'CATEGORYID',pic:'9999'},{av:'A40001CategoryId',fld:'CATEGORYID',pic:'9999'},{av:'AV5category',fld:'vCATEGORY',pic:''}]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV5category = new SdtCategory(context);
         A16CityName = "";
         A12CategoryName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttDo_Jsonclick = "";
         bttUndo_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000V3_A40001CategoryId = new short[1] ;
         H000V3_n40001CategoryId = new bool[] {false} ;
         H000V4_A9CountryId = new short[1] ;
         H000V4_A15CityId = new short[1] ;
         H000V4_A11CategoryId = new short[1] ;
         H000V4_n11CategoryId = new bool[] {false} ;
         H000V4_A12CategoryName = new string[] {""} ;
         H000V4_A16CityName = new string[] {""} ;
         H000V4_A7AttractionId = new short[1] ;
         AV6attraction = new SdtAttraction(context);
         H000V6_A9CountryId = new short[1] ;
         H000V6_A15CityId = new short[1] ;
         H000V6_A11CategoryId = new short[1] ;
         H000V6_n11CategoryId = new bool[] {false} ;
         H000V6_A12CategoryName = new string[] {""} ;
         H000V6_A16CityName = new string[] {""} ;
         H000V6_A7AttractionId = new short[1] ;
         H000V6_A40000CategoryId = new short[1] ;
         H000V6_n40000CategoryId = new bool[] {false} ;
         H000V8_A40001CategoryId = new short[1] ;
         H000V8_n40001CategoryId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriesandattractions__default(),
            new Object[][] {
                new Object[] {
               H000V3_A40001CategoryId, H000V3_n40001CategoryId
               }
               , new Object[] {
               H000V4_A9CountryId, H000V4_A15CityId, H000V4_A11CategoryId, H000V4_n11CategoryId, H000V4_A12CategoryName, H000V4_A16CityName, H000V4_A7AttractionId
               }
               , new Object[] {
               H000V6_A9CountryId, H000V6_A15CityId, H000V6_A11CategoryId, H000V6_n11CategoryId, H000V6_A12CategoryName, H000V6_A16CityName, H000V6_A7AttractionId, H000V6_A40000CategoryId, H000V6_n40000CategoryId
               }
               , new Object[] {
               H000V8_A40001CategoryId, H000V8_n40001CategoryId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A7AttractionId ;
      private short A40001CategoryId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A9CountryId ;
      private short A15CityId ;
      private short A11CategoryId ;
      private short A40000CategoryId ;
      private short AV7categoryId ;
      private short nGXWrapped ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string A16CityName ;
      private string A12CategoryName ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttDo_Internalname ;
      private string bttDo_Jsonclick ;
      private string bttUndo_Internalname ;
      private string bttUndo_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40001CategoryId ;
      private bool returnInSub ;
      private bool n11CategoryId ;
      private bool n40000CategoryId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000V3_A40001CategoryId ;
      private bool[] H000V3_n40001CategoryId ;
      private short[] H000V4_A9CountryId ;
      private short[] H000V4_A15CityId ;
      private short[] H000V4_A11CategoryId ;
      private bool[] H000V4_n11CategoryId ;
      private string[] H000V4_A12CategoryName ;
      private string[] H000V4_A16CityName ;
      private short[] H000V4_A7AttractionId ;
      private short[] H000V6_A9CountryId ;
      private short[] H000V6_A15CityId ;
      private short[] H000V6_A11CategoryId ;
      private bool[] H000V6_n11CategoryId ;
      private string[] H000V6_A12CategoryName ;
      private string[] H000V6_A16CityName ;
      private short[] H000V6_A7AttractionId ;
      private short[] H000V6_A40000CategoryId ;
      private bool[] H000V6_n40000CategoryId ;
      private short[] H000V8_A40001CategoryId ;
      private bool[] H000V8_n40001CategoryId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private SdtAttraction AV6attraction ;
      private SdtCategory AV5category ;
   }

   public class categoriesandattractions__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000V3;
          prmH000V3 = new Object[] {
          };
          Object[] prmH000V4;
          prmH000V4 = new Object[] {
          };
          Object[] prmH000V6;
          prmH000V6 = new Object[] {
          };
          Object[] prmH000V8;
          prmH000V8 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H000V3", "SELECT COALESCE( T1.[CategoryId], 0) AS CategoryId FROM (SELECT MIN([CategoryId]) AS CategoryId FROM [Category] WHERE [CategoryName] = 'Tourist site' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V4", "SELECT T1.[CountryId], T1.[CityId], T1.[CategoryId], T3.[CategoryName], T2.[CityName], T1.[AttractionId] FROM (([Attraction] T1 INNER JOIN [CountryCity] T2 ON T2.[CountryId] = T1.[CountryId] AND T2.[CityId] = T1.[CityId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]) WHERE (T2.[CityName] = 'Maumere') AND (T3.[CategoryName] = 'Museum') ORDER BY T1.[AttractionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V6", "SELECT T1.[CountryId], T1.[CityId], T1.[CategoryId], T3.[CategoryName], T2.[CityName], T1.[AttractionId], COALESCE( T4.[CategoryId], 0) AS CategoryId FROM (([Attraction] T1 INNER JOIN [CountryCity] T2 ON T2.[CountryId] = T1.[CountryId] AND T2.[CityId] = T1.[CityId]) LEFT JOIN [Category] T3 ON T3.[CategoryId] = T1.[CategoryId]),  (SELECT MIN([CategoryId]) AS CategoryId FROM [Category] WHERE [CategoryName] = 'Museum' ) T4 WHERE (T2.[CityName] = 'Maumere') AND (T3.[CategoryName] = 'Tourist site') ORDER BY T1.[AttractionId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000V8", "SELECT COALESCE( T1.[CategoryId], 0) AS CategoryId FROM (SELECT MIN([CategoryId]) AS CategoryId FROM [Category] WHERE [CategoryName] = 'Tourist site' ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V8,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 50);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
