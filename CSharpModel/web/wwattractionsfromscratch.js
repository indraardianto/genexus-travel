gx.evt.autoSkip=!1;gx.define("wwattractionsfromscratch",!1,function(){var n,t;this.ServerClass="wwattractionsfromscratch";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwattractionsfromscratch.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Attractionid=function(){var n=gx.fn.currentGridRowImpl(24);return this.validCliEvt("Valid_Attractionid",24,function(){try{if(gx.fn.currentGridRowImpl(24)===0)return!0;var n=gx.util.balloon.getNew("ATTRACTIONID",gx.fn.currentGridRowImpl(24));this.AnyError=0;this.refreshOutputs([{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}])}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e160x2_client=function(){return this.clearMessages(),this.call("attraction.aspx",["UPD",this.A7AttractionId],null,["Mode","AttractionId"]),this.refreshOutputs([{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150x2_client=function(){return this.clearMessages(),this.call("viewcountryinfo_related.aspx",[this.A7AttractionId],null,["CountryId"]),this.refreshOutputs([{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140x2_client=function(){return this.executeServerEvent("VNEWTRIP.CLICK",!0,arguments[0],!1,!1)};this.e170x2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e180x2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,25,26,27,28,29,30,31,32,33,34,35,36];this.GXLastCtrlId=36;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",24,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"wwattractionsfromscratch",[],!1,1,!1,!0,0,!1,!1,!1,"",0,"px",0,"px","New row",!1,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addSingleLineEdit(7,25,"ATTRACTIONID","Attraction Id","","AttractionId","int",0,"px",4,4,"right",null,[],7,"AttractionId",!1,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(8,26,"ATTRACTIONNAME","Attraction Name","","AttractionName","char",0,"px",50,50,"left","e150x2_client",[],8,"AttractionName",!0,0,!1,!1,"Attribute",1,"");t.addSingleLineEdit(10,27,"COUNTRYNAME","Country Name","","CountryName","char",0,"px",50,50,"left",null,[],10,"CountryName",!0,0,!1,!1,"Attribute",1,"");t.addBitmap(13,"ATTRACTIONPHOTO",28,0,"px",17,"px",null,"","Attraction Photo","ImageAttribute","");t.addSingleLineEdit("Trips",29,"vTRIPS","Trips","","trips","int",0,"px",4,4,"right",null,[],"Trips","trips",!0,0,!1,!1,"Attribute",1,"");t.addBitmap("&Update","vUPDATE",30,0,"px",17,"px","e160x2_client","","","Image","");t.addSingleLineEdit("Newtrip",31,"vNEWTRIP","","","newTrip","char",0,"px",100,80,"left","e140x2_client",[],"Newtrip","newTrip",!0,0,!1,!1,"Attribute",1,"");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCOUNTRYID",gxz:"ZV5CountryId",gxold:"OV5CountryId",gxvar:"AV5CountryId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"dyncombo",v2v:function(n){n!==undefined&&(gx.O.AV5CountryId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV5CountryId=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vCOUNTRYID",gx.O.AV5CountryId)},c2v:function(){this.val()!==undefined&&(gx.O.AV5CountryId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCOUNTRYID",",")},nac:gx.falseFn};n[9]={id:9,fld:"",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"TABLE1",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vATTRACTIONNAMEFORM",gxz:"ZV6AttractionNameForm",gxold:"OV6AttractionNameForm",gxvar:"AV6AttractionNameForm",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6AttractionNameForm=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6AttractionNameForm=n)},v2c:function(){gx.fn.setControlValue("vATTRACTIONNAMEFORM",gx.O.AV6AttractionNameForm,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6AttractionNameForm=this.val())},val:function(){return gx.fn.getControlValue("vATTRACTIONNAMEFORM")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,lvl:0,type:"char",len:50,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vATTRACTIONNAMETO",gxz:"ZV7AttractionNameTo",gxold:"OV7AttractionNameTo",gxvar:"AV7AttractionNameTo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7AttractionNameTo=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7AttractionNameTo=n)},v2c:function(){gx.fn.setControlValue("vATTRACTIONNAMETO",gx.O.AV7AttractionNameTo,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7AttractionNameTo=this.val())},val:function(){return gx.fn.getControlValue("vATTRACTIONNAMETO")},nac:gx.falseFn};n[22]={id:22,fld:"",grid:0};n[23]={id:23,fld:"",grid:0};n[25]={id:25,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:this.Valid_Attractionid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONID",gxz:"Z7AttractionId",gxold:"O7AttractionId",gxvar:"A7AttractionId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7AttractionId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z7AttractionId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("ATTRACTIONID",n||gx.fn.currentGridRowImpl(24),gx.O.A7AttractionId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A7AttractionId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("ATTRACTIONID",n||gx.fn.currentGridRowImpl(24),",")},nac:gx.falseFn};n[26]={id:26,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONNAME",gxz:"Z8AttractionName",gxold:"O8AttractionName",gxvar:"A8AttractionName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A8AttractionName=n)},v2z:function(n){n!==undefined&&(gx.O.Z8AttractionName=n)},v2c:function(n){gx.fn.setGridControlValue("ATTRACTIONNAME",n||gx.fn.currentGridRowImpl(24),gx.O.A8AttractionName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A8AttractionName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ATTRACTIONNAME",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn,evt:"e150x2_client"};n[27]={id:27,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"COUNTRYNAME",gxz:"Z10CountryName",gxold:"O10CountryName",gxvar:"A10CountryName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A10CountryName=n)},v2z:function(n){n!==undefined&&(gx.O.Z10CountryName=n)},v2c:function(n){gx.fn.setGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(24),gx.O.A10CountryName,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A10CountryName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("COUNTRYNAME",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ATTRACTIONPHOTO",gxz:"Z13AttractionPhoto",gxold:"O13AttractionPhoto",gxvar:"A13AttractionPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A13AttractionPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z13AttractionPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("ATTRACTIONPHOTO",n||gx.fn.currentGridRowImpl(24),gx.O.A13AttractionPhoto,gx.O.A40001AttractionPhoto_GXI)},c2v:function(n){gx.O.A40001AttractionPhoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A13AttractionPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("ATTRACTIONPHOTO",n||gx.fn.currentGridRowImpl(24))},val_GXI:function(n){return gx.fn.getGridControlValue("ATTRACTIONPHOTO_GXI",n||gx.fn.currentGridRowImpl(24))},gxvar_GXI:"A40001AttractionPhoto_GXI",nac:gx.falseFn};n[29]={id:29,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTRIPS",gxz:"ZV8trips",gxold:"OV8trips",gxvar:"AV8trips",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV8trips=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8trips=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("vTRIPS",n||gx.fn.currentGridRowImpl(24),gx.O.AV8trips,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV8trips=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("vTRIPS",n||gx.fn.currentGridRowImpl(24),",")},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV10update",gxold:"OV10update",gxvar:"AV10update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV10update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV10update=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vUPDATE",n||gx.fn.currentGridRowImpl(24),gx.O.AV10update,gx.O.AV14Update_GXI)},c2v:function(n){gx.O.AV14Update_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV10update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(24))},val_GXI:function(n){return gx.fn.getGridControlValue("vUPDATE_GXI",n||gx.fn.currentGridRowImpl(24))},gxvar_GXI:"AV14Update_GXI",nac:gx.falseFn,evt:"e160x2_client"};n[31]={id:31,lvl:2,type:"char",len:100,dec:0,sign:!1,ro:0,isacc:0,grid:24,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vNEWTRIP",gxz:"ZV11newTrip",gxold:"OV11newTrip",gxvar:"AV11newTrip",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11newTrip=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11newTrip=n)},v2c:function(n){gx.fn.setGridControlValue("vNEWTRIP",n||gx.fn.currentGridRowImpl(24),gx.O.AV11newTrip,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11newTrip=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vNEWTRIP",n||gx.fn.currentGridRowImpl(24))},nac:gx.falseFn,evt:"e140x2_client"};n[32]={id:32,fld:"",grid:0};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vTOTALTRIPS",gxz:"ZV9totalTrips",gxold:"OV9totalTrips",gxvar:"AV9totalTrips",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9totalTrips=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9totalTrips=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vTOTALTRIPS",gx.O.AV9totalTrips,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9totalTrips=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vTOTALTRIPS",",")},nac:gx.falseFn};this.AV5CountryId=0;this.ZV5CountryId=0;this.OV5CountryId=0;this.AV6AttractionNameForm="";this.ZV6AttractionNameForm="";this.OV6AttractionNameForm="";this.AV7AttractionNameTo="";this.ZV7AttractionNameTo="";this.OV7AttractionNameTo="";this.Z7AttractionId=0;this.O7AttractionId=0;this.Z8AttractionName="";this.O8AttractionName="";this.Z10CountryName="";this.O10CountryName="";this.Z13AttractionPhoto="";this.O13AttractionPhoto="";this.ZV8trips=0;this.OV8trips=0;this.ZV10update="";this.OV10update="";this.ZV11newTrip="";this.OV11newTrip="";this.AV9totalTrips=0;this.ZV9totalTrips=0;this.OV9totalTrips=0;this.AV5CountryId=0;this.AV6AttractionNameForm="";this.AV7AttractionNameTo="";this.AV9totalTrips=0;this.A40001AttractionPhoto_GXI="";this.A9CountryId=0;this.A40000GXC1=0;this.A7AttractionId=0;this.A8AttractionName="";this.A10CountryName="";this.A13AttractionPhoto="";this.AV8trips=0;this.AV10update="";this.AV11newTrip="";this.Events={e140x2_client:["VNEWTRIP.CLICK",!0],e170x2_client:["ENTER",!0],e180x2_client:["CANCEL",!0],e160x2_client:["VUPDATE.CLICK",!1],e150x2_client:["ATTRACTIONNAME.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"AV6AttractionNameForm",fld:"vATTRACTIONNAMEFORM",pic:""},{av:"AV7AttractionNameTo",fld:"vATTRACTIONNAMETO",pic:""},{av:"AV10update",fld:"vUPDATE",pic:""},{av:"AV11newTrip",fld:"vNEWTRIP",pic:""},{av:"AV9totalTrips",fld:"vTOTALTRIPS",pic:"ZZZ9"},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{av:"AV9totalTrips",fld:"vTOTALTRIPS",pic:"ZZZ9"},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms.LOAD=[[{av:"AV9totalTrips",fld:"vTOTALTRIPS",pic:"ZZZ9"},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{av:"AV8trips",fld:"vTRIPS",pic:"ZZZ9"},{av:"A40000GXC1",fld:"GXC1",pic:"999999999"},{av:"AV9totalTrips",fld:"vTOTALTRIPS",pic:"ZZZ9"},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms.START=[[{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{av:"AV10update",fld:"vUPDATE",pic:""},{av:"AV11newTrip",fld:"vNEWTRIP",pic:""},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms["VUPDATE.CLICK"]=[[{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9",hsh:!0},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms["VNEWTRIP.CLICK"]=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{av:"AV6AttractionNameForm",fld:"vATTRACTIONNAMEFORM",pic:""},{av:"AV7AttractionNameTo",fld:"vATTRACTIONNAMETO",pic:""},{av:"AV10update",fld:"vUPDATE",pic:""},{av:"AV11newTrip",fld:"vNEWTRIP",pic:""},{av:"AV9totalTrips",fld:"vTOTALTRIPS",pic:"ZZZ9"},{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9",hsh:!0},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{av:"AV8trips",fld:"vTRIPS",pic:"ZZZ9"},{av:"AV9totalTrips",fld:"vTOTALTRIPS",pic:"ZZZ9"},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms["ATTRACTIONNAME.CLICK"]=[[{av:"A7AttractionId",fld:"ATTRACTIONID",pic:"ZZZ9",hsh:!0},{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms.ENTER=[[{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];this.EvtParms.VALID_ATTRACTIONID=[[{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}],[{ctrl:"vCOUNTRYID"},{av:"AV5CountryId",fld:"vCOUNTRYID",pic:"ZZZ9"}]];t.addRefreshingVar(this.GXValidFnc[8]);t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[21]);t.addRefreshingVar({rfrVar:"AV10update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV11newTrip",rfrProp:"Value",gxAttId:"Newtrip"});t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[8]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[21]);t.addRefreshingParm({rfrVar:"AV10update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV11newTrip",rfrProp:"Value",gxAttId:"Newtrip"});t.addRefreshingParm(this.GXValidFnc[36]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwattractionsfromscratch)})