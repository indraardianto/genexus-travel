gx.evt.autoSkip=!1;gx.define("gx00d0",!1,function(){var n,t;this.ServerClass="gx00d0";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx00d0.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9pTripId=gx.fn.getIntegerValue("vPTRIPID",",")};this.Validv_Ctripdate=function(){return this.validCliEvt("Validv_Ctripdate",0,function(){try{var n=gx.util.balloon.getNew("vCTRIPDATE");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV7cTripDate)===0||new gx.date.gxdate(this.AV7cTripDate).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Trip Date is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e140z1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110z1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TRIPIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TRIPIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTRIPID","Visible",!0)):(gx.fn.setCtrlProperty("TRIPIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTRIPID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRIPIDFILTERCONTAINER","Class")',ctrl:"TRIPIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRIPID","Visible")',ctrl:"vCTRIPID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120z1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TRIPDATEFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("TRIPDATEFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRIPDATEFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRIPDATEFILTERCONTAINER","Class")',ctrl:"TRIPDATEFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130z1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TRIPDESCRIPTIONFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TRIPDESCRIPTIONFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTRIPDESCRIPTION","Visible",!0)):(gx.fn.setCtrlProperty("TRIPDESCRIPTIONFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTRIPDESCRIPTION","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRIPDESCRIPTIONFILTERCONTAINER","Class")',ctrl:"TRIPDESCRIPTIONFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRIPDESCRIPTION","Visible")',ctrl:"vCTRIPDESCRIPTION",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170z2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e180z1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,45,46,47,48,49,50,51];this.GXLastCtrlId=51;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",44,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx00d0",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",45,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(48,46,"TRIPID","Id","","TripId","int",0,"px",4,4,"right",null,[],48,"TripId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(49,47,"TRIPDATE","Date","","TripDate","date",0,"px",8,8,"right",null,[],49,"TripDate",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(50,48,"TRIPDESCRIPTION","Description","","TripDescription","char",0,"px",20,20,"left",null,[],50,"TripDescription",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TRIPIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLTRIPIDFILTER",format:1,grid:0,evt:"e110z1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRIPID",gxz:"ZV6cTripId",gxold:"OV6cTripId",gxvar:"AV6cTripId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cTripId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cTripId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCTRIPID",gx.O.AV6cTripId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cTripId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCTRIPID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TRIPDATEFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLTRIPDATEFILTER",format:1,grid:0,evt:"e120z1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctripdate,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRIPDATE",gxz:"ZV7cTripDate",gxold:"OV7cTripDate",gxvar:"AV7cTripDate",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cTripDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cTripDate=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRIPDATE",gx.O.AV7cTripDate,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cTripDate=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRIPDATE")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"TRIPDESCRIPTIONFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLTRIPDESCRIPTIONFILTER",format:1,grid:0,evt:"e130z1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"char",len:20,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRIPDESCRIPTION",gxz:"ZV8cTripDescription",gxold:"OV8cTripDescription",gxvar:"AV8cTripDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cTripDescription=n)},v2z:function(n){n!==undefined&&(gx.O.ZV8cTripDescription=n)},v2c:function(){gx.fn.setControlValue("vCTRIPDESCRIPTION",gx.O.AV8cTripDescription,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cTripDescription=this.val())},val:function(){return gx.fn.getControlValue("vCTRIPDESCRIPTION")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"GRIDTABLE",grid:0};n[39]={id:39,fld:"",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"BTNTOGGLE",grid:0,evt:"e140z1_client"};n[42]={id:42,fld:"",grid:0};n[43]={id:43,fld:"",grid:0};n[45]={id:45,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44),gx.O.AV5LinkSelection,gx.O.AV13Linkselection_GXI)},c2v:function(n){gx.O.AV13Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(44))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(44))},gxvar_GXI:"AV13Linkselection_GXI",nac:gx.falseFn};n[46]={id:46,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRIPID",gxz:"Z48TripId",gxold:"O48TripId",gxvar:"A48TripId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A48TripId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z48TripId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TRIPID",n||gx.fn.currentGridRowImpl(44),gx.O.A48TripId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A48TripId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TRIPID",n||gx.fn.currentGridRowImpl(44),",")},nac:gx.falseFn};n[47]={id:47,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRIPDATE",gxz:"Z49TripDate",gxold:"O49TripDate",gxvar:"A49TripDate",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A49TripDate=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z49TripDate=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("TRIPDATE",n||gx.fn.currentGridRowImpl(44),gx.O.A49TripDate,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A49TripDate=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("TRIPDATE",n||gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};n[48]={id:48,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:44,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRIPDESCRIPTION",gxz:"Z50TripDescription",gxold:"O50TripDescription",gxvar:"A50TripDescription",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A50TripDescription=n)},v2z:function(n){n!==undefined&&(gx.O.Z50TripDescription=n)},v2c:function(n){gx.fn.setGridControlValue("TRIPDESCRIPTION",n||gx.fn.currentGridRowImpl(44),gx.O.A50TripDescription,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A50TripDescription=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TRIPDESCRIPTION",n||gx.fn.currentGridRowImpl(44))},nac:gx.falseFn};n[49]={id:49,fld:"",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"BTN_CANCEL",grid:0,evt:"e180z1_client"};this.AV6cTripId=0;this.ZV6cTripId=0;this.OV6cTripId=0;this.AV7cTripDate=gx.date.nullDate();this.ZV7cTripDate=gx.date.nullDate();this.OV7cTripDate=gx.date.nullDate();this.AV8cTripDescription="";this.ZV8cTripDescription="";this.OV8cTripDescription="";this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z48TripId=0;this.O48TripId=0;this.Z49TripDate=gx.date.nullDate();this.O49TripDate=gx.date.nullDate();this.Z50TripDescription="";this.O50TripDescription="";this.AV6cTripId=0;this.AV7cTripDate=gx.date.nullDate();this.AV8cTripDescription="";this.AV9pTripId=0;this.AV5LinkSelection="";this.A48TripId=0;this.A49TripDate=gx.date.nullDate();this.A50TripDescription="";this.Events={e170z2_client:["ENTER",!0],e180z1_client:["CANCEL",!0],e140z1_client:["'TOGGLE'",!1],e110z1_client:["LBLTRIPIDFILTER.CLICK",!1],e120z1_client:["LBLTRIPDATEFILTER.CLICK",!1],e130z1_client:["LBLTRIPDESCRIPTIONFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTripId",fld:"vCTRIPID",pic:"ZZZ9"},{av:"AV7cTripDate",fld:"vCTRIPDATE",pic:""},{av:"AV8cTripDescription",fld:"vCTRIPDESCRIPTION",pic:""}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLTRIPIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRIPIDFILTERCONTAINER","Class")',ctrl:"TRIPIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRIPIDFILTERCONTAINER","Class")',ctrl:"TRIPIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRIPID","Visible")',ctrl:"vCTRIPID",prop:"Visible"}]];this.EvtParms["LBLTRIPDATEFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRIPDATEFILTERCONTAINER","Class")',ctrl:"TRIPDATEFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRIPDATEFILTERCONTAINER","Class")',ctrl:"TRIPDATEFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRIPDESCRIPTIONFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRIPDESCRIPTIONFILTERCONTAINER","Class")',ctrl:"TRIPDESCRIPTIONFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRIPDESCRIPTIONFILTERCONTAINER","Class")',ctrl:"TRIPDESCRIPTIONFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRIPDESCRIPTION","Visible")',ctrl:"vCTRIPDESCRIPTION",prop:"Visible"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A48TripId",fld:"TRIPID",pic:"ZZZ9",hsh:!0}],[{av:"AV9pTripId",fld:"vPTRIPID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTripId",fld:"vCTRIPID",pic:"ZZZ9"},{av:"AV7cTripDate",fld:"vCTRIPDATE",pic:""},{av:"AV8cTripDescription",fld:"vCTRIPDESCRIPTION",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTripId",fld:"vCTRIPID",pic:"ZZZ9"},{av:"AV7cTripDate",fld:"vCTRIPDATE",pic:""},{av:"AV8cTripDescription",fld:"vCTRIPDESCRIPTION",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTripId",fld:"vCTRIPID",pic:"ZZZ9"},{av:"AV7cTripDate",fld:"vCTRIPDATE",pic:""},{av:"AV8cTripDescription",fld:"vCTRIPDESCRIPTION",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTripId",fld:"vCTRIPID",pic:"ZZZ9"},{av:"AV7cTripDate",fld:"vCTRIPDATE",pic:""},{av:"AV8cTripDescription",fld:"vCTRIPDESCRIPTION",pic:""}],[]];this.EvtParms.VALIDV_CTRIPDATE=[[],[]];this.setVCMap("AV9pTripId","vPTRIPID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx00d0)})