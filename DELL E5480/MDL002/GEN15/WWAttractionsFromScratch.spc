spec_i([ web,33,'WWAttractions From Scratch','WWAttractionsFromScratch',0,eng,'17_0_8-158023' ]).
 
struct_i(2,1,[ 'Update','Newtrip' ],[]).
 
level_i(2,[ 2,[ [ 2,many ],[ 3,one ],[ 2000,one ] ],[],[],[ [ [ 2,3,2000 ],[ 9,13,40001,10,8,7,40000 ] ] ],[ [ [ 2,3,2000 ],[] ] ],[ 7 ],'IATTRACTION',[],[] ]).
 
tw_i(2,[ [ 3,[ [ 2,9,9 ] ] ],[ 2000,[ [ 2,oe([ t(7,2) ]),7 ] ] ] ]).
 
lwi_i(2,[ [] ]).
 
cond_constraint_i(2,[ [ t(9,2),t(=,10),t('Countryid',23) ],[ 9 ],[ t('.NOT.',8),t('null(',1),t('Countryid',23),t(')',4) ],[] ]).
cond_constraint_i(2,[ [ t(8,2),t(>=,10),t('Attractionnameform',23) ],[ 8 ],[ t('.NOT.',8),t('null(',1),t('Attractionnameform',23),t(')',4) ],[] ]).
cond_constraint_i(2,[ [ t(8,2),t(<=,10),t('Attractionnameto',23) ],[ 8 ],[ t('.NOT.',8),t('null(',1),t('Attractionnameto',23),t(')',4) ],[] ]).
 
cond_order_i(2,[ 9,8 ],[ t('.NOT.',8),t('null(',1),t('Countryid',23),t(')',4) ]).
cond_order_i(2,[ 8 ],[]).
 
 
ta_i(2,[ [ [ 2,9 ],[ 2,13 ],[ 2,40001 ],[ 3,10 ],[ 2,8 ],[ 2,7 ],[ 2000,se(40000,[ [ 2000,40000 ] ],[ t('coalesce(',1),t(40000,2),t(',',7),t('0',3),t(')',4) ]) ] ] ]).
 
las_i(2,[ [ 'Countryid','Attractionnameform','Attractionnameto','Trips','Newtrip','Totaltrips',9,13,40001,10,8,7,40000 ] ]).
 
lac_i(2,[ [ 'Countryid','Attractionnameform','Attractionnameto','Trips','Newtrip','Totaltrips' ] ]).
 
 
 
cls_i([ 0,0 ],[ 2,2261 ]).
 
pos_i('Countryid',[ 0,0,0 ]).
pos_i('Attractionnameform',[ 0,0,0 ]).
pos_i('Attractionnameto',[ 0,0,0 ]).
pos_i(7,[ 1,2,0 ]).
pos_i(8,[ 1,2,5 ]).
pos_i(10,[ 1,2,56 ]).
pos_i(13,[ 1,2,107 ]).
pos_i('Trips',[ 1,2,1132 ]).
pos_i('Update',[ 1,2,1137 ]).
pos_i('Newtrip',[ 1,2,2162 ]).
pos_i('Totaltrips',[ 0,0,0 ]).
 
repeat_i(2,[ 1,2,[ 7,8,10,13,'Trips','Update','Newtrip' ],[ 'Trips','Newtrip' ] ]).
 
 
rule_i(0,datastore(1,'DS_LAST_CHANGE','')).
rule_i(0,datastore(1,'LOCK_RETRY','10')).
rule_i(0,datastore(1,'WAIT_RECORD','0')).
rule_i(0,datastore(1,'ISOLATION_LEVEL','CR')).
rule_i(0,datastore(1,'SQLSERVER_VERSION','10')).
rule_i(0,datastore(1,'COMMENT_ON','No')).
rule_i(0,datastore(1,'DFT_TMP_TBLSPACE','')).
rule_i(0,datastore(1,'DFT_IDX_TBLSPACE','')).
rule_i(0,datastore(1,'DFT_TBL_TBLSPACE','')).
rule_i(0,datastore(1,'DCL_REF_INT_DB','Yes')).
rule_i(0,datastore(1,'PRIMARY_KEY_TYPE','PK')).
rule_i(0,datastore(1,'CS_SCHEMA','')).
rule_i(0,datastore(1,'SORT_ATTRIBUTES','Yes')).
rule_i(0,datastore(1,'JRN400','QSQJRN')).
rule_i(0,datastore(1,'CREATE_SAVF','Yes')).
rule_i(0,datastore(1,'PGMLIB','')).
rule_i(0,datastore(1,'DTALIB','')).
rule_i(0,datastore(1,'RecycleRWMin','30')).
rule_i(0,datastore(1,'RecycleRWType','1')).
rule_i(0,datastore(1,'RecycleRW','-1')).
rule_i(0,datastore(1,'POOL_STARTUP','No')).
rule_i(0,datastore(1,'POOLSIZE_RW','10')).
rule_i(0,datastore(1,'UnlimitedRWPool','-1')).
rule_i(0,datastore(1,'PoolRWEnabled','-1')).
rule_i(0,datastore(1,'CS_RPCPGML','')).
rule_i(0,datastore(1,'JDBC_DATASOURCE','')).
rule_i(0,datastore(1,'USE_JDBC_DATASOURCE','0')).
rule_i(0,datastore(1,'DS_DBMS_ADDINFO','Timeout=120')).
rule_i(0,datastore(1,'USER_PASSWORD','uZX�=�o�E�''[Z}tv�Cڿ�T')).
rule_i(0,datastore(1,'USER_ID',uZXAxoI7SbyvxC12)).
rule_i(0,datastore(1,'TRUSTED_CONNECTION','No')).
rule_i(0,datastore(1,'CS_CONNECT','First')).
rule_i(0,datastore(1,'DBMS_PORT','')).
rule_i(0,datastore(1,'CS_SERVER','trialapps3.genexus.com')).
rule_i(0,datastore(1,'CS_DBNAME','Idd34a97045eb5096d2a7b475d46cdbbd3')).
rule_i(0,datastore(1,'CS_FLEDSNAME','')).
rule_i(0,datastore(1,'CS_DRVNAME','sql server')).
rule_i(0,datastore(1,'CS_DSNAME','')).
rule_i(0,datastore(1,'DB_URL','')).
rule_i(0,datastore(1,'JDBC_CUSTOM_URL','0')).
rule_i(0,datastore(1,'JDBC_CUSTOM_DRIVER','')).
rule_i(0,datastore(1,'JDBC_DRIVER','net.sourceforge.jtds.jdbc.Driver')).
rule_i(0,datastore(1,'CONNECT_METHOD','OPSYS')).
rule_i(0,datastore(1,'ACCESS_TECHNO','ADONET')).
rule_i(0,datastore(1,'MAIN_DS','-1')).
rule_i(0,datastore(1,'REORG_GEN','8')).
rule_i(0,datastore(1,'HelpKeyword','20')).
rule_i(0,datastore(1,'DBMS',12)).
rule_i(0,datastore(1,'NAME','Default')).
rule_i(0,prop(idNULLS_BEHAVIOR,idNB_Current)).
rule_i(0,prop('PWFCallable','0')).
rule_i(0,prop('ObjectVisibility','Public')).
rule_i(0,prop('FullyQualifiedName','WWAttractionsFromScratch')).
rule_i(0,prop('GenerateObject','-1')).
rule_i(0,prop('Hint_firstrows','UMPV')).
rule_i(0,prop('JOIN_TYPE','UMPV')).
rule_i(0,prop('DBMS_JOINS','UMPV')).
rule_i(0,prop('REFRESH_TOUT_TRIG','ALL')).
rule_i(0,prop('REFRESH_TOUT','')).
rule_i(0,prop('KEY_ENTER','UMPV')).
rule_i(0,prop('KEY_CANCEL','UMPV')).
rule_i(0,prop('KEY_REFRESH','UMPV')).
rule_i(0,prop('KEY_HELP','UMPV')).
rule_i(0,prop('ASSIGNED_FNC_KEYS','UMPV')).
rule_i(0,prop('WEB_SECURITY_LEVEL','High')).
rule_i(0,prop('HTTP_PROTOCOL','Secure')).
rule_i(0,prop('USE_ENCRYPTION','NO')).
rule_i(0,prop('FIRST_WD_DATEPICKER','UMPV')).
rule_i(0,prop('WNUM_DATEPICKER','UMPV')).
rule_i(0,prop(idUSE_WEB_DATEPICKER,'UMPV')).
rule_i(0,prop('WebUX','SMOOTH')).
rule_i(0,prop('STD_FUNC_OBJECT','Yes')).
rule_i(0,prop('SPC_WARNINGS_DISABLED','spc0096 spc0107 spc0142')).
rule_i(0,prop('WebApplication',idDefault)).
rule_i(0,prop('COMPRESS_HTML','UMPV')).
rule_i(0,prop('AUTO_REFRESH','VARS_CHANGE')).
rule_i(0,prop('CACHE_EXPIRES','')).
rule_i(0,prop('WEB_AUTO_FOCUS','UMPV')).
rule_i(0,prop('OnSessionTimeout','Ignore')).
rule_i(0,prop('OBJECT_METADATA','')).
rule_i(0,prop('IsMain','0')).
rule_i(0,prop(sessiontype,'RW')).
rule_i(0,prop('SHOWMASTERPAGE_POPUP','0')).
rule_i(0,prop('MasterPage',o(13,'RwdMasterPage'))).
rule_i(0,prop('WEB_COMP','No')).
rule_i(0,prop('Theme',o(25,'Carmine'))).
rule_i(0,prop('Folder',o(120,'Root Module'))).
rule_i(0,prop('ObjDesc','WWAttractions From Scratch')).
rule_i(0,prop('ObjName','WWAttractionsFromScratch')).
rule_i(0,maingen(15)).
 
a_i(1,2,d,t('Countryid',23),[],[ 9,10,[ [ [ 3,9 ],[ 3,10 ] ],n,[ [ 3,many ] ],[],[],[ 10 ],[],[],[] ],empty,'Select' ]).
a_i(2,1,f,'Err',[],[ [],[ t('0',3) ] ]).
a_i(3,2,t,2,[],[ [],'IATTRACTION',[] ]).
a_i(4,2,r,3,[],[ [ [ 2,9,9 ] ],'ICOUNTRY',[] ]).
a_i(5,2,r,2000,[],[ [ [ 2,oe([ t(7,2) ]),7 ] ],'IATTRACTION',[] ]).
a_i(6,1,f,[ t('&Trips',23),t('Enabled',3) ],[],[ [],[ t(0,3),t(';',18) ] ]).
a_i(7,1,f,[ t('&Newtrip',23),t('Enabled',3) ],[],[ [],[ t(0,3),t(';',18) ] ]).
a_i(8,1,f,[ t('&Totaltrips',23),t('Enabled',3) ],[],[ [],[ t(0,3),t(';',18) ] ]).
 
v_i(d,i,1,[]).
v_i(d,o,1,'Countryid').
v_i(f,i,2,[]).
v_i(f,o,2,'Err').
v_i(t,i,3,[]).
v_i(t,o,3,9).
v_i(t,o,3,13).
v_i(t,o,3,40001).
v_i(t,o,3,8).
v_i(t,o,3,7).
v_i(r,i,4,9).
v_i(r,o,4,10).
v_i(r,i,5,7).
v_i(r,o,5,40000).
v_i(f,i,6,[]).
v_i(f,o,6,[ t('&Trips',23),t('Enabled',3) ]).
v_i(f,i,7,[]).
v_i(f,o,7,[ t('&Newtrip',23),t('Enabled',3) ]).
v_i(f,i,8,[]).
v_i(f,o,8,[ t('&Totaltrips',23),t('Enabled',3) ]).
 
 
 
 
 
 
attri_i(48,[ 'TripId',int,4,0,'ZZZ9',0,'Trip Id','',0 ]).
attri_i(40001,[ 'AttractionPhoto_GXI',svchar,2048,0,'',0,'',[],0 ]).
attri_i(9,[ 'CountryId',int,4,0,'ZZZ9',0,'Country Id','',0 ]).
attri_i(13,[ 'AttractionPhoto',bits,4,0,'',0,'Attraction Photo','',0 ]).
attri_i(10,[ 'CountryName',char,50,0,'',0,'Country Name','',0 ]).
attri_i(8,[ 'AttractionName',char,50,0,'',0,'Attraction Name','',0 ]).
attri_i(7,[ 'AttractionId',int,4,0,'ZZZ9',0,'Attraction Id','',0 ]).
attri_i('Update_GXI',[ 'Update_GXI',svchar,2048,0,'',0,'',[],14 ]).
attri_i(40000,[ 'GXC1',int,9,0,'',0,'',[],0 ]).
attri_i(49,[ 'TripDate',date,8,0,'99/99/99',0,'Trip Date','',0 ]).
attri_i('Errmsg',[ 'Gx_emsg',char,70,0,'',1,'Error text','',13 ]).
attri_i('Err',[ 'Gx_err',int,3,0,'ZZ9',1,'Error code','',12 ]).
attri_i('Newtrip',[ newTrip,char,100,0,'',0,'new Trip','',11 ]).
attri_i('Update',[ update,bits,1024,0,'',0,update,'',10 ]).
attri_i('Totaltrips',[ totalTrips,int,4,0,'ZZZ9',0,'total Trips','',9 ]).
attri_i('Trips',[ trips,int,4,0,'ZZZ9',0,trips,'',8 ]).
attri_i('Attractionnameto',[ 'AttractionNameTo',char,50,0,'',0,'Attraction Name To','',7 ]).
attri_i('Attractionnameform',[ 'AttractionNameForm',char,50,0,'',0,'Attraction Name Form','',6 ]).
attri_i('Countryid',[ 'CountryId',int,4,0,'ZZZ9',0,'Country Id','',5 ]).
 
table_i(13,[ 'Trip',[ 48,49 ],'Trip','Trip' ]).
table_i(14,[ 'TripAttraction',[ 48,7 ],'Attraction','TripAttraction' ]).
table_i(2000,[ 'Attraction',[ 40000,7 ],'Attraction','Attraction' ]).
table_i(3,[ 'Country',[ 9,10 ],'Country','Country' ]).
table_i(2,[ 'Attraction',[ 7,8,9,13,40001 ],'Attraction','Attraction' ]).
 
index_i(14,[ 'ITRIPATTRACTION',u,[ 48,7 ],'ITripAttraction' ]).
index_i(13,[ 'ITRIP',u,[ 48 ],'ITrip' ]).
index_i(3,[ 'ICOUNTRY',u,[ 9 ],'ICountry' ]).
index_i(2,[ 'IATTRACTION',u,[ 7 ],'IAttraction' ]).
index_i(2,[ 'IATTRACTION3',k,[ 8 ],'IAttraction3' ]).
index_i(2000,[ 'IATTRACTION',u,[ 7 ],'IAttraction' ]).
 
lv_i(2,2000,2).
 
 
function_i(2,'Trips',yes,udp,o(1,'NewTrip'),[ 7 ],20,'Trips',[ [ t(7,2) ] ]).
 
 
nav_view_i(2000,[ 40000 ],[ 7 ],[ 7 ],[ [ 2000,[ [ 2,oe([ t(7,2) ]),7 ] ] ] ],[ [ [ 13,[ 'count(',49 ] ],[ 14,7 ] ],n,[ [ 14,many ],[ 13,one ] ],[ [ 13,[ [ 14,48,48 ] ] ] ],[],[ none ],[],[ 7 ],[] ]).
 
 
agg_def_i(40000,[ t('0',3) ]).
 
 
 
 
 
add_att_i(bits,2,'Update_GXI','Update','Update_GXI',[ svchar,2048,0,0 ]).
add_att_i(bits,2,40001,13,'AttractionPhoto_GXI',[ svchar,2048,0,0 ]).
 
 
 
 
 
 
 
 
 
 
enum_value_i(2,41,'"INS"','Insert','"Insert"',[ none ]).
enum_value_i(2,41,'"UPD"','Update','"Update"',[ none ]).
enum_value_i(2,41,'"DLT"','Delete','"Delete"',[ none ]).
enum_value_i(2,41,'"DSP"','Display','"Display"',[ none ]).
 
enum_value_info_i(2,41,'GeneXus\TrnMode').
 
enum_type_i(2,41,char,3,0).
 
dom_info_i(85,[ 'Id' ]).
dom_info_i(86,[ 'Name' ]).
dom_info_i(42,[ 'GeneXus\Address' ]).
 
 
break_i(2,nvg,1,[],[ [ 7,8,10,13,9 ],[],[] ]).
 
b_group_i(2,1,lit,0,1,1).
b_group_i(2,2,lit,0,2,6).
b_group_i(2,3,lit,0,7,10).
b_group_i(2,4,lit,0,11,15).
b_group_i(2,5,lit,0,16,19).
b_group_i(2,6,lit,0,20,25).
b_group_i(2,7,lit,0,26,0).
 
b_line_i(1,2,1,cmd,1,[ t('',146,1,0),t('Load',3,1,8) ]).
b_line_i(2,2,2,cmd,1,[ t('',107,2,0),t('Trips',23,1,0),t(=,10,1,0),t(40000,2,1,0) ]).
b_line_i(3,2,2,cmd,1,[ t('',107,3,0),t('Totaltrips',23,1,0),t(=,10,1,0),t('Totaltrips',23,1,0),t(+,5,1,0),t('Trips',23,1,0) ]).
b_line_i(4,2,2,cmd,1,[ t('',155,4,0) ]).
b_line_i(4,2,2,cmd,1,[ t('',147,4,0) ]).
b_line_i(6,2,2,cmd,1,[ t('',146,6,0),t('Refresh',3,6,7) ]).
b_line_i(7,2,3,cmd,1,[ t('',107,7,0),t('Totaltrips',23,1,0),t(=,10,1,0),t('0',3,1,0) ]).
b_line_i(8,2,3,cmd,1,[ t('',147,8,0) ]).
b_line_i(10,2,3,cmd,1,[ t('',146,10,0),t('Start',3,10,7) ]).
b_line_i(11,2,4,cmd,1,[ t('',107,11,0),t([ t('Update',23,11,2),t('fromimage(',1,11,10) ],31,11,2),t(i(98,'2c23d666-bf81-474c-9f82-9a0d6f117c27'),69,1,21),t(')',4,1,31) ]).
b_line_i([ 11,1 ],2,4,cmd,1,[ t('',107,11,0),t('Update_GXI',23,1,0),t(=,10,1,0),t('urifromurl(',1,1,0),t(i(98,'2c23d666-bf81-474c-9f82-9a0d6f117c27'),69,1,0),t(')',4,1,0) ]).
b_line_i(12,2,4,cmd,2,[ t('',107,12,0),t('Newtrip',23,2,0),t(=,10,2,0),t('"New Trip"',3,2,0) ]).
b_line_i(13,2,4,cmd,2,[ t('',147,13,0) ]).
b_line_i(15,2,4,cmd,2,[ t('',146,15,0),t([ t('Update',23,15,7),t('Click',3,15,15) ],29,15,15) ]).
b_line_i(16,2,5,cmd,2,[ t('',104,16,0),t(o(0,'Attraction'),28,2,2),t([ 41,'Update' ],44,16,13),t(',',7,2,0),t(7,2,2,29) ]).
b_line_i(17,2,5,cmd,2,[ t('',147,17,0) ]).
b_line_i(19,2,5,cmd,2,[ t('',146,19,0),t([ t('Newtrip',23,19,7),t('Click',3,19,16) ],29,19,16) ]).
b_line_i(20,2,6,cmd,2,[ t('',107,20,0),t('Trips',23,2,0),t(=,10,2,0),t('udp(',1,2,0),t('Trips',3,2,0),t(20,3,2,0),t(7,2,2,0),t(')',4,2,0) ]).
b_line_i(21,2,6,cmd,2,[ t('',148,21,0) ]).
b_line_i(22,2,6,cmd,2,[ t('',147,22,0) ]).
b_line_i(25,2,6,cmd,2,[ t('',146,25,0),t([ t(8,2,25,7),t('Click',3,25,22) ],29,25,22) ]).
b_line_i(26,2,7,cmd,2,[ t('',104,26,0),t(o(13,'ViewCountryInfo_related'),28,2,2),t(7,2,2,26) ]).
b_line_i(28,2,7,cmd,2,[ t('',147,28,0) ]).
 
sf_break_i(24,2).
 
 
 
 
 
 
 
 
 
 
 
 
 
html_i(2,div(2)).
 
html_sub_i(2,3,html_i(0,div(3))).
html_sub_i(3,4,html_i(0,div(4))).
html_sub_i(4,5,html_i(0,div(5))).
html_sub_i(5,6,html_i(0,div(6))).
html_sub_i(6,7,html_i(0,div(7))).
html_sub_i(7,8,html_i(0,t('Countryid',23))).
html_sub_i(3,9,html_i(1,div(9))).
html_sub_i(9,10,html_i(0,div(10))).
html_sub_i(10,11,html_i(0,div(11))).
html_sub_i(11,12,html_i(0,div(12))).
html_sub_i(12,13,html_i(0,div(13))).
html_sub_i(13,14,html_i(0,div(14))).
html_sub_i(14,15,html_i(0,div(15))).
html_sub_i(15,16,html_i(0,t('Attractionnameform',23))).
html_sub_i(11,17,html_i(1,div(17))).
html_sub_i(17,18,html_i(0,div(18))).
html_sub_i(18,19,html_i(0,div(19))).
html_sub_i(19,20,html_i(0,div(20))).
html_sub_i(20,21,html_i(0,t('Attractionnameto',23))).
html_sub_i(3,22,html_i(2,div(22))).
html_sub_i(22,23,html_i(0,div(23))).
html_sub_i(23,24,html_i(0,s(24))).
html_sub_i(3,32,html_i(3,div(32))).
html_sub_i(32,33,html_i(0,div(33))).
html_sub_i(33,34,html_i(0,div(34))).
html_sub_i(34,35,html_i(0,div(35))).
html_sub_i(35,36,html_i(0,t('Totaltrips',23))).
 
html_tags_i(1,'Class','form-horizontal Form').
html_tags_i(2,'data-gx-base-lib',bootstrapv3).
html_tags_i(2,'data-abstract-form','').
html_tags_i(6,'data-gx-att','var:5').
html_tags_i(8,'data-gx-att','var:5').
html_tags_i(14,'data-gx-att','var:6').
html_tags_i(16,'data-gx-att','var:6').
html_tags_i(19,'data-gx-att','var:7').
html_tags_i(21,'data-gx-att','var:7').
html_tags_i(34,'data-gx-att','var:9').
html_tags_i(36,'data-gx-att','var:9').
 
html_comp_i(2,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(2,'Class','Section',d,[ str ]).
html_comp_i(2,'Id','',d,[ str ]).
html_comp_i(2,'Height',measure(0,px),d,[ measure ]).
html_comp_i(2,'Width',measure(0,px),d,[ measure ]).
html_comp_i(2,'Semanticcontent',div,d,[ str ]).
html_comp_i(2,'Align',left,d,[ str ]).
html_comp_i(2,'Valign',top,d,[ str ]).
html_comp_i(3,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(3,'Class','Table',v,[ str ]).
html_comp_i(3,'Id','Maintable',v,[ str ]).
html_comp_i(3,'Height',measure(0,px),d,[ measure ]).
html_comp_i(3,'Width',measure(0,px),d,[ measure ]).
html_comp_i(3,'Semanticcontent',div,d,[ str ]).
html_comp_i(3,'Align',left,d,[ str ]).
html_comp_i(3,'Valign',top,d,[ str ]).
html_comp_i(4,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(4,'Class',row,v,[ str ]).
html_comp_i(4,'Id','',d,[ str ]).
html_comp_i(4,'Height',measure(0,px),d,[ measure ]).
html_comp_i(4,'Width',measure(0,px),d,[ measure ]).
html_comp_i(4,'Semanticcontent',div,d,[ str ]).
html_comp_i(4,'Align',left,d,[ str ]).
html_comp_i(4,'Valign',top,d,[ str ]).
html_comp_i(5,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(5,'Class','col-xs-12',v,[ str ]).
html_comp_i(5,'Id','',d,[ str ]).
html_comp_i(5,'Height',measure(0,px),d,[ measure ]).
html_comp_i(5,'Width',measure(0,px),d,[ measure ]).
html_comp_i(5,'Semanticcontent',div,d,[ str ]).
html_comp_i(5,'Align',left,d,[ str ]).
html_comp_i(5,'Valign',top,d,[ str ]).
html_comp_i(6,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(6,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(6,'Id','',d,[ str ]).
html_comp_i(6,'Height',measure(0,px),d,[ measure ]).
html_comp_i(6,'Width',measure(0,px),d,[ measure ]).
html_comp_i(6,'Semanticcontent',div,d,[ str ]).
html_comp_i(6,'Align',left,d,[ str ]).
html_comp_i(6,'Valign',top,d,[ str ]).
html_comp_i(7,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(7,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(7,'Id','',d,[ str ]).
html_comp_i(7,'Height',measure(0,px),d,[ measure ]).
html_comp_i(7,'Width',measure(0,px),d,[ measure ]).
html_comp_i(7,'Semanticcontent',div,d,[ str ]).
html_comp_i(7,'Align',left,d,[ str ]).
html_comp_i(7,'Valign',top,d,[ str ]).
html_comp_i(8,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(8,'Colcount',50,d,[ num ]).
html_comp_i(8,'Attid',-5,v,[ num ]).
html_comp_i(8,'Class','Attribute',v,[ str ]).
html_comp_i(8,'Controlname','&Countryid',d,[ str ]).
html_comp_i(8,'Returnonclick',0,v,[ bool ]).
html_comp_i(8,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(8,'Captionstyle','',v,[ str ]).
html_comp_i(8,'Captionposition','Left',v,[ str ]).
html_comp_i(8,'Captionvalue','Country Id',d,[ str ]).
html_comp_i(8,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(8,'Controltype',4,v,[ num ]).
html_comp_i(8,'Datasourcefrom','Attributes',d,[ str ]).
html_comp_i(8,'Controlitemvalues',9,d,[ num ]).
html_comp_i(8,'Controlitemdescription',10,v,[ num ]).
html_comp_i(8,'Controlsortdescription',-1,d,[ bool ]).
html_comp_i(8,'Controlwhere','',d,[ str ]).
html_comp_i(8,'Controlrestrictedby','',d,[ str ]).
html_comp_i(8,'Addemptyitem',-1,v,[ bool ]).
html_comp_i(8,'Emptyitemtext','Select',v,[ str ]).
html_comp_i(8,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(8,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(8,'Readonly',0,v,[ bool ]).
html_comp_i(8,'Autocomplete',-1,d,[ bool ]).
html_comp_i(8,'Autoresize',-1,d,[ bool ]).
html_comp_i(8,'Gxwidth',measure(50,chr),d,[ measure ]).
html_comp_i(8,'Ismultiline',0,d,[ bool ]).
html_comp_i(8,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(8,'Fill',-1,d,[ bool ]).
html_comp_i(8,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(8,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(8,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(8,'Horizontalalignment',left,d,[ str ]).
html_comp_i(8,'Title','',d,[ str ]).
html_comp_i(8,'Invitemsg','',v,[ str ]).
html_comp_i(9,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(9,'Class',row,v,[ str ]).
html_comp_i(9,'Id','',d,[ str ]).
html_comp_i(9,'Height',measure(0,px),d,[ measure ]).
html_comp_i(9,'Width',measure(0,px),d,[ measure ]).
html_comp_i(9,'Semanticcontent',div,d,[ str ]).
html_comp_i(9,'Align',left,d,[ str ]).
html_comp_i(9,'Valign',top,d,[ str ]).
html_comp_i(10,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(10,'Class','col-xs-12',v,[ str ]).
html_comp_i(10,'Id','',d,[ str ]).
html_comp_i(10,'Height',measure(0,px),d,[ measure ]).
html_comp_i(10,'Width',measure(0,px),d,[ measure ]).
html_comp_i(10,'Semanticcontent',div,d,[ str ]).
html_comp_i(10,'Align',left,d,[ str ]).
html_comp_i(10,'Valign',top,d,[ str ]).
html_comp_i(11,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(11,'Class','Table',v,[ str ]).
html_comp_i(11,'Id','Table1',v,[ str ]).
html_comp_i(11,'Height',measure(0,px),d,[ measure ]).
html_comp_i(11,'Width',measure(0,px),d,[ measure ]).
html_comp_i(11,'Semanticcontent',div,d,[ str ]).
html_comp_i(11,'Align',left,d,[ str ]).
html_comp_i(11,'Valign',top,d,[ str ]).
html_comp_i(12,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(12,'Class',row,v,[ str ]).
html_comp_i(12,'Id','',d,[ str ]).
html_comp_i(12,'Height',measure(0,px),d,[ measure ]).
html_comp_i(12,'Width',measure(0,px),d,[ measure ]).
html_comp_i(12,'Semanticcontent',div,d,[ str ]).
html_comp_i(12,'Align',left,d,[ str ]).
html_comp_i(12,'Valign',top,d,[ str ]).
html_comp_i(13,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(13,'Class','col-xs-12',v,[ str ]).
html_comp_i(13,'Id','',d,[ str ]).
html_comp_i(13,'Height',measure(0,px),d,[ measure ]).
html_comp_i(13,'Width',measure(0,px),d,[ measure ]).
html_comp_i(13,'Semanticcontent',div,d,[ str ]).
html_comp_i(13,'Align',left,d,[ str ]).
html_comp_i(13,'Valign',top,d,[ str ]).
html_comp_i(14,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(14,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(14,'Id','',d,[ str ]).
html_comp_i(14,'Height',measure(0,px),d,[ measure ]).
html_comp_i(14,'Width',measure(0,px),d,[ measure ]).
html_comp_i(14,'Semanticcontent',div,d,[ str ]).
html_comp_i(14,'Align',left,d,[ str ]).
html_comp_i(14,'Valign',top,d,[ str ]).
html_comp_i(15,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(15,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(15,'Id','',d,[ str ]).
html_comp_i(15,'Height',measure(0,px),d,[ measure ]).
html_comp_i(15,'Width',measure(0,px),d,[ measure ]).
html_comp_i(15,'Semanticcontent',div,d,[ str ]).
html_comp_i(15,'Align',left,d,[ str ]).
html_comp_i(15,'Valign',top,d,[ str ]).
html_comp_i(16,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(16,'Colcount',50,d,[ num ]).
html_comp_i(16,'Attid',-6,v,[ num ]).
html_comp_i(16,'Class','Attribute',v,[ str ]).
html_comp_i(16,'Controlname','&Attractionnameform',d,[ str ]).
html_comp_i(16,'Returnonclick',0,v,[ bool ]).
html_comp_i(16,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(16,'Captionstyle','',v,[ str ]).
html_comp_i(16,'Captionposition','Left',v,[ str ]).
html_comp_i(16,'Captionvalue','Attraction Name Form',d,[ str ]).
html_comp_i(16,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(16,'Controltype',2,d,[ num ]).
html_comp_i(16,'Inputtype',0,d,[ num ]).
html_comp_i(16,'Editautocomplete',0,d,[ num ]).
html_comp_i(16,'Autocorrection',-1,d,[ bool ]).
html_comp_i(16,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(16,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(16,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(16,'Readonly',0,v,[ bool ]).
html_comp_i(16,'Autocomplete',-1,d,[ bool ]).
html_comp_i(16,'Ispassword',0,d,[ bool ]).
html_comp_i(16,'Autoresize',-1,d,[ bool ]).
html_comp_i(16,'Gxwidth',measure(50,chr),d,[ measure ]).
html_comp_i(16,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(16,'Ismultiline',0,d,[ bool ]).
html_comp_i(16,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(16,'Fill',-1,d,[ bool ]).
html_comp_i(16,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(16,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(16,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(16,'Horizontalalignment',left,d,[ str ]).
html_comp_i(16,'Gxformat',0,d,[ num ]).
html_comp_i(16,'Title','',d,[ str ]).
html_comp_i(16,'Invitemsg','',v,[ str ]).
html_comp_i(17,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(17,'Class',row,v,[ str ]).
html_comp_i(17,'Id','',d,[ str ]).
html_comp_i(17,'Height',measure(0,px),d,[ measure ]).
html_comp_i(17,'Width',measure(0,px),d,[ measure ]).
html_comp_i(17,'Semanticcontent',div,d,[ str ]).
html_comp_i(17,'Align',left,d,[ str ]).
html_comp_i(17,'Valign',top,d,[ str ]).
html_comp_i(18,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(18,'Class','col-xs-12',v,[ str ]).
html_comp_i(18,'Id','',d,[ str ]).
html_comp_i(18,'Height',measure(0,px),d,[ measure ]).
html_comp_i(18,'Width',measure(0,px),d,[ measure ]).
html_comp_i(18,'Semanticcontent',div,d,[ str ]).
html_comp_i(18,'Align',left,d,[ str ]).
html_comp_i(18,'Valign',top,d,[ str ]).
html_comp_i(19,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(19,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(19,'Id','',d,[ str ]).
html_comp_i(19,'Height',measure(0,px),d,[ measure ]).
html_comp_i(19,'Width',measure(0,px),d,[ measure ]).
html_comp_i(19,'Semanticcontent',div,d,[ str ]).
html_comp_i(19,'Align',left,d,[ str ]).
html_comp_i(19,'Valign',top,d,[ str ]).
html_comp_i(20,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(20,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(20,'Id','',d,[ str ]).
html_comp_i(20,'Height',measure(0,px),d,[ measure ]).
html_comp_i(20,'Width',measure(0,px),d,[ measure ]).
html_comp_i(20,'Semanticcontent',div,d,[ str ]).
html_comp_i(20,'Align',left,d,[ str ]).
html_comp_i(20,'Valign',top,d,[ str ]).
html_comp_i(21,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(21,'Colcount',50,d,[ num ]).
html_comp_i(21,'Attid',-7,v,[ num ]).
html_comp_i(21,'Class','Attribute',v,[ str ]).
html_comp_i(21,'Controlname','&Attractionnameto',d,[ str ]).
html_comp_i(21,'Returnonclick',0,v,[ bool ]).
html_comp_i(21,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(21,'Captionstyle','',v,[ str ]).
html_comp_i(21,'Captionposition','Left',v,[ str ]).
html_comp_i(21,'Captionvalue','Attraction Name To',d,[ str ]).
html_comp_i(21,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(21,'Controltype',2,d,[ num ]).
html_comp_i(21,'Inputtype',0,d,[ num ]).
html_comp_i(21,'Editautocomplete',0,d,[ num ]).
html_comp_i(21,'Autocorrection',-1,d,[ bool ]).
html_comp_i(21,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(21,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(21,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(21,'Readonly',0,v,[ bool ]).
html_comp_i(21,'Autocomplete',-1,d,[ bool ]).
html_comp_i(21,'Ispassword',0,d,[ bool ]).
html_comp_i(21,'Autoresize',-1,d,[ bool ]).
html_comp_i(21,'Gxwidth',measure(50,chr),d,[ measure ]).
html_comp_i(21,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(21,'Ismultiline',0,d,[ bool ]).
html_comp_i(21,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(21,'Fill',-1,d,[ bool ]).
html_comp_i(21,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(21,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(21,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(21,'Horizontalalignment',left,d,[ str ]).
html_comp_i(21,'Gxformat',0,d,[ num ]).
html_comp_i(21,'Title','',d,[ str ]).
html_comp_i(21,'Invitemsg','',v,[ str ]).
html_comp_i(22,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(22,'Class',row,v,[ str ]).
html_comp_i(22,'Id','',d,[ str ]).
html_comp_i(22,'Height',measure(0,px),d,[ measure ]).
html_comp_i(22,'Width',measure(0,px),d,[ measure ]).
html_comp_i(22,'Semanticcontent',div,d,[ str ]).
html_comp_i(22,'Align',left,d,[ str ]).
html_comp_i(22,'Valign',top,d,[ str ]).
html_comp_i(23,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(23,'Class','col-xs-12',v,[ str ]).
html_comp_i(23,'Id','',d,[ str ]).
html_comp_i(23,'Height',measure(0,px),d,[ measure ]).
html_comp_i(23,'Width',measure(0,px),d,[ measure ]).
html_comp_i(23,'Semanticcontent',div,d,[ str ]).
html_comp_i(23,'Align',left,d,[ str ]).
html_comp_i(23,'Valign',top,d,[ str ]).
html_comp_i(24,'Isabstractlayoutcontrol',-1,v,[ bool ]).
html_comp_i(24,'Controlname','Grid1',v,[ str ]).
html_comp_i(24,'Controlorder','''.''(''.''(t($ORDER$,39),''.''(t(9,2),''.''(t($,$,7),''.''(t(8,2),''.''(t($when$,35),''.''(t($.NOT.$,8),''.''(t($&Countryid$,29),''.''(t(28,30),''.''(t($isempty($,1),''.''(t($)$,4),''.''(t($ORDER$,39),''.''(t(8,2),$[]$)))))))))))),$[]$)',v,[ str ]).
html_comp_i(24,'Controlwhere','''.''(''.''(t(9,2),''.''(t($=$,10),''.''(t($Countryid$,23),''.''(t($when$,35),''.''(t($.NOT.$,8),''.''(t($&Countryid$,29),''.''(t(28,30),''.''(t($isempty($,1),''.''(t($)$,4),''.''(t($;$,18),$[]$)))))))))),''.''(''.''(t(8,2),''.''(t($>=$,10),''.''(t($Attractionnameform$,23),''.''(t($when$,35),''.''(t($.NOT.$,8),''.''(t($&Attractionnameform$,29),''.''(t(28,30),''.''(t($isempty($,1),''.''(t($)$,4),''.''(t($;$,18),$[]$)))))))))),''.''(''.''(t(8,2),''.''(t($<=$,10),''.''(t($Attractionnameto$,23),''.''(t($when$,35),''.''(t($.NOT.$,8),''.''(t($&Attractionnameto$,29),''.''(t(28,30),''.''(t($isempty($,1),''.''(t($)$,4),''.''(t($;$,18),$[]$)))))))))),''.''($[]$,$[]$))))',v,[ str ]).
html_comp_i(24,'Controlunique','',d,[ str ]).
html_comp_i(24,'Save_state',0,d,[ bool ]).
html_comp_i(24,'Iddataselector','',d,[ str ]).
html_comp_i(24,'Sflrender','',d,[ str ]).
html_comp_i(24,'Class','Grid',v,[ str ]).
html_comp_i(24,'Prop_emptydatasettext','',d,[ str ]).
html_comp_i(24,'Autoresize',-1,d,[ bool ]).
html_comp_i(24,'Gxwidth',measure(0,px),d,[ measure ]).
html_comp_i(24,'Gxheight',measure(0,px),d,[ measure ]).
html_comp_i(24,'Maxcols',1,d,[ num ]).
html_comp_i(24,'Maxrows',0,d,[ num ]).
html_comp_i(24,'Header','',d,[ str ]).
html_comp_i(24,'Title','',d,[ str ]).
html_comp_i(24,'Linescolor',rgb(0,0,0),d,[ color ]).
html_comp_i(24,'Linesfont',font('Courier New',9,[]),d,[ font ]).
html_comp_i(24,'Titlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(24,'Titlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(24,'Align',left,d,[ str ]).
html_comp_i(24,'Cellpadding','1',d,[ str ]).
html_comp_i(24,'Cellspacing','2',d,[ str ]).
html_comp_i(24,'Sortable',-1,d,[ bool ]).
html_comp_i(24,'Allowdrop',0,d,[ bool ]).
html_comp_i(24,'Allowdrag',0,d,[ bool ]).
html_comp_i(24,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(24,'Allowcollapsing',0,d,[ bool ]).
html_comp_i(24,'Allowselection',0,d,[ bool ]).
html_comp_i(25,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(25,'Colcount',4,d,[ num ]).
html_comp_i(25,'Colattid',7,v,[ num ]).
html_comp_i(25,'Controlname','Attractionid',d,[ str ]).
html_comp_i(25,'Class','Attribute',v,[ str ]).
html_comp_i(25,'Columnclass','',d,[ str ]).
html_comp_i(25,'Returnonclick',0,d,[ bool ]).
html_comp_i(25,'Eventgx','',d,[ str ]).
html_comp_i(25,'Controltype',2,d,[ num ]).
html_comp_i(25,'Inputtype',0,d,[ num ]).
html_comp_i(25,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(25,'Colreadonly',-1,d,[ bool ]).
html_comp_i(25,'Autocomplete',-1,d,[ bool ]).
html_comp_i(25,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(25,'Ispassword',0,d,[ bool ]).
html_comp_i(25,'Colautoresize',-1,d,[ bool ]).
html_comp_i(25,'Colwidth',measure(0,px),d,[ measure ]).
html_comp_i(25,'Height',measure(17,px),d,[ measure ]).
html_comp_i(25,'Collinesfont',font('Courier New',9,[]),d,[ font ]).
html_comp_i(25,'Collinescolor',rgb(0,0,0),d,[ color ]).
html_comp_i(25,'Coltitle','Attraction Id',d,[ str ]).
html_comp_i(25,'Coltitlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(25,'Coltitlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(25,'Horizontalalignment',right,d,[ str ]).
html_comp_i(25,'Gxformat',0,d,[ num ]).
html_comp_i(25,'Colvisible',0,v,[ bool ]).
html_comp_i(25,'Title','',d,[ str ]).
html_comp_i(25,'Invitemsg','',d,[ str ]).
html_comp_i(26,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(26,'Colcount',50,d,[ num ]).
html_comp_i(26,'Colattid',8,v,[ num ]).
html_comp_i(26,'Controlname','Attractionname',d,[ str ]).
html_comp_i(26,'Class','Attribute',v,[ str ]).
html_comp_i(26,'Columnclass','',d,[ str ]).
html_comp_i(26,'Returnonclick',0,d,[ bool ]).
html_comp_i(26,'Eventgx','',d,[ str ]).
html_comp_i(26,'Controltype',2,d,[ num ]).
html_comp_i(26,'Inputtype',0,d,[ num ]).
html_comp_i(26,'Editautocomplete',0,d,[ num ]).
html_comp_i(26,'Autocorrection',-1,d,[ bool ]).
html_comp_i(26,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(26,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(26,'Colreadonly',-1,d,[ bool ]).
html_comp_i(26,'Autocomplete',-1,d,[ bool ]).
html_comp_i(26,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(26,'Ispassword',0,d,[ bool ]).
html_comp_i(26,'Colautoresize',-1,d,[ bool ]).
html_comp_i(26,'Colwidth',measure(0,px),d,[ measure ]).
html_comp_i(26,'Height',measure(17,px),d,[ measure ]).
html_comp_i(26,'Collinesfont',font('Courier New',9,[]),d,[ font ]).
html_comp_i(26,'Collinescolor',rgb(0,0,0),d,[ color ]).
html_comp_i(26,'Coltitle','Attraction Name',d,[ str ]).
html_comp_i(26,'Coltitlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(26,'Coltitlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(26,'Horizontalalignment',left,d,[ str ]).
html_comp_i(26,'Gxformat',0,d,[ num ]).
html_comp_i(26,'Colvisible',-1,d,[ bool ]).
html_comp_i(26,'Title','',d,[ str ]).
html_comp_i(26,'Invitemsg','',d,[ str ]).
html_comp_i(27,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(27,'Colcount',50,d,[ num ]).
html_comp_i(27,'Colattid',10,v,[ num ]).
html_comp_i(27,'Controlname','Countryname',d,[ str ]).
html_comp_i(27,'Class','Attribute',v,[ str ]).
html_comp_i(27,'Columnclass','',d,[ str ]).
html_comp_i(27,'Returnonclick',0,d,[ bool ]).
html_comp_i(27,'Eventgx','',d,[ str ]).
html_comp_i(27,'Controltype',2,d,[ num ]).
html_comp_i(27,'Inputtype',0,d,[ num ]).
html_comp_i(27,'Editautocomplete',0,d,[ num ]).
html_comp_i(27,'Autocorrection',-1,d,[ bool ]).
html_comp_i(27,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(27,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(27,'Colreadonly',-1,d,[ bool ]).
html_comp_i(27,'Autocomplete',-1,d,[ bool ]).
html_comp_i(27,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(27,'Ispassword',0,d,[ bool ]).
html_comp_i(27,'Colautoresize',-1,d,[ bool ]).
html_comp_i(27,'Colwidth',measure(0,px),d,[ measure ]).
html_comp_i(27,'Height',measure(17,px),d,[ measure ]).
html_comp_i(27,'Collinesfont',font('Courier New',9,[]),d,[ font ]).
html_comp_i(27,'Collinescolor',rgb(0,0,0),d,[ color ]).
html_comp_i(27,'Coltitle','Country Name',d,[ str ]).
html_comp_i(27,'Coltitlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(27,'Coltitlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(27,'Horizontalalignment',left,d,[ str ]).
html_comp_i(27,'Gxformat',0,d,[ num ]).
html_comp_i(27,'Colvisible',-1,d,[ bool ]).
html_comp_i(27,'Title','',d,[ str ]).
html_comp_i(27,'Invitemsg','',d,[ str ]).
html_comp_i(28,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(28,'Colcount',5,d,[ num ]).
html_comp_i(28,'Colattid',13,v,[ num ]).
html_comp_i(28,'Controlname','Attractionphoto',d,[ str ]).
html_comp_i(28,'Class','ImageAttribute',v,[ str ]).
html_comp_i(28,'Columnclass','',d,[ str ]).
html_comp_i(28,'Returnonclick',0,d,[ bool ]).
html_comp_i(28,'Eventgx','',d,[ str ]).
html_comp_i(28,'Controltype',2,d,[ num ]).
html_comp_i(28,'Inputtype',0,d,[ num ]).
html_comp_i(28,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(28,'Autocomplete',0,d,[ bool ]).
html_comp_i(28,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(28,'Colautoresize',-1,d,[ bool ]).
html_comp_i(28,'Colwidth',measure(0,px),d,[ measure ]).
html_comp_i(28,'Height',measure(17,px),d,[ measure ]).
html_comp_i(28,'Coltitle','Attraction Photo',d,[ str ]).
html_comp_i(28,'Coltitlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(28,'Coltitlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(28,'Colvisible',-1,d,[ bool ]).
html_comp_i(28,'Border','1',d,[ str ]).
html_comp_i(28,'Alt','',d,[ str ]).
html_comp_i(28,'Title','',d,[ str ]).
html_comp_i(28,'Hspace',0,d,[ num ]).
html_comp_i(28,'Vspace',0,d,[ num ]).
html_comp_i(29,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(29,'Colcount',4,d,[ num ]).
html_comp_i(29,'Colattid',-8,v,[ num ]).
html_comp_i(29,'Controlname','&Trips',d,[ str ]).
html_comp_i(29,'Class','Attribute',v,[ str ]).
html_comp_i(29,'Columnclass','',d,[ str ]).
html_comp_i(29,'Returnonclick',0,d,[ bool ]).
html_comp_i(29,'Eventgx','',d,[ str ]).
html_comp_i(29,'Controltype',2,d,[ num ]).
html_comp_i(29,'Inputtype',0,d,[ num ]).
html_comp_i(29,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(29,'Colreadonly',-1,v,[ bool ]).
html_comp_i(29,'Autocomplete',-1,d,[ bool ]).
html_comp_i(29,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(29,'Ispassword',0,d,[ bool ]).
html_comp_i(29,'Colautoresize',-1,d,[ bool ]).
html_comp_i(29,'Colwidth',measure(0,px),d,[ measure ]).
html_comp_i(29,'Height',measure(17,px),d,[ measure ]).
html_comp_i(29,'Collinesfont',font('Courier New',9,[]),d,[ font ]).
html_comp_i(29,'Collinescolor',rgb(0,0,0),d,[ color ]).
html_comp_i(29,'Coltitle','Trips',d,[ str ]).
html_comp_i(29,'Coltitlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(29,'Coltitlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(29,'Horizontalalignment',right,d,[ str ]).
html_comp_i(29,'Gxformat',0,d,[ num ]).
html_comp_i(29,'Colvisible',-1,d,[ bool ]).
html_comp_i(29,'Title','',d,[ str ]).
html_comp_i(29,'Invitemsg','',d,[ str ]).
html_comp_i(30,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(30,'Colcount',5,d,[ num ]).
html_comp_i(30,'Colattid',-10,v,[ num ]).
html_comp_i(30,'Controlname','&Update',d,[ str ]).
html_comp_i(30,'Class','Image',v,[ str ]).
html_comp_i(30,'Columnclass','',d,[ str ]).
html_comp_i(30,'Returnonclick',0,d,[ bool ]).
html_comp_i(30,'Eventgx','',d,[ str ]).
html_comp_i(30,'Controltype',2,d,[ num ]).
html_comp_i(30,'Inputtype',0,d,[ num ]).
html_comp_i(30,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(30,'Autocomplete',0,d,[ bool ]).
html_comp_i(30,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(30,'Colautoresize',-1,d,[ bool ]).
html_comp_i(30,'Colwidth',measure(0,px),d,[ measure ]).
html_comp_i(30,'Height',measure(17,px),d,[ measure ]).
html_comp_i(30,'Coltitle','',d,[ str ]).
html_comp_i(30,'Coltitlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(30,'Coltitlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(30,'Colvisible',-1,d,[ bool ]).
html_comp_i(30,'Border','0',d,[ str ]).
html_comp_i(30,'Alt','',d,[ str ]).
html_comp_i(30,'Title','',d,[ str ]).
html_comp_i(30,'Hspace',0,d,[ num ]).
html_comp_i(30,'Vspace',0,d,[ num ]).
html_comp_i(31,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(31,'Colcount',80,d,[ num ]).
html_comp_i(31,'Colattid',-11,v,[ num ]).
html_comp_i(31,'Controlname','&Newtrip',d,[ str ]).
html_comp_i(31,'Class','Attribute',v,[ str ]).
html_comp_i(31,'Columnclass','',d,[ str ]).
html_comp_i(31,'Returnonclick',0,d,[ bool ]).
html_comp_i(31,'Eventgx','',d,[ str ]).
html_comp_i(31,'Controltype',2,d,[ num ]).
html_comp_i(31,'Inputtype',0,d,[ num ]).
html_comp_i(31,'Editautocomplete',0,d,[ num ]).
html_comp_i(31,'Autocorrection',-1,d,[ bool ]).
html_comp_i(31,'Autocapitalization','FirstWord',d,[ str ]).
html_comp_i(31,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(31,'Colreadonly',-1,v,[ bool ]).
html_comp_i(31,'Autocomplete',-1,d,[ bool ]).
html_comp_i(31,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(31,'Ispassword',0,d,[ bool ]).
html_comp_i(31,'Colautoresize',-1,d,[ bool ]).
html_comp_i(31,'Colwidth',measure(0,px),d,[ measure ]).
html_comp_i(31,'Height',measure(17,px),d,[ measure ]).
html_comp_i(31,'Collinesfont',font('Courier New',9,[]),d,[ font ]).
html_comp_i(31,'Collinescolor',rgb(0,0,0),d,[ color ]).
html_comp_i(31,'Coltitle','',d,[ str ]).
html_comp_i(31,'Coltitlefont',font('Microsoft Sans Serif',8,[ bold ]),d,[ font ]).
html_comp_i(31,'Coltitlecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(31,'Horizontalalignment',left,d,[ str ]).
html_comp_i(31,'Gxformat',0,d,[ num ]).
html_comp_i(31,'Colvisible',-1,d,[ bool ]).
html_comp_i(31,'Title','',d,[ str ]).
html_comp_i(31,'Invitemsg','',d,[ str ]).
html_comp_i(32,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(32,'Class',row,v,[ str ]).
html_comp_i(32,'Id','',d,[ str ]).
html_comp_i(32,'Height',measure(0,px),d,[ measure ]).
html_comp_i(32,'Width',measure(0,px),d,[ measure ]).
html_comp_i(32,'Semanticcontent',div,d,[ str ]).
html_comp_i(32,'Align',left,d,[ str ]).
html_comp_i(32,'Valign',top,d,[ str ]).
html_comp_i(33,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(33,'Class','col-xs-12',v,[ str ]).
html_comp_i(33,'Id','',d,[ str ]).
html_comp_i(33,'Height',measure(0,px),d,[ measure ]).
html_comp_i(33,'Width',measure(0,px),d,[ measure ]).
html_comp_i(33,'Semanticcontent',div,d,[ str ]).
html_comp_i(33,'Align',left,d,[ str ]).
html_comp_i(33,'Valign',top,d,[ str ]).
html_comp_i(34,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(34,'Class','form-group gx-form-group ',v,[ str ]).
html_comp_i(34,'Id','',d,[ str ]).
html_comp_i(34,'Height',measure(0,px),d,[ measure ]).
html_comp_i(34,'Width',measure(0,px),d,[ measure ]).
html_comp_i(34,'Semanticcontent',div,d,[ str ]).
html_comp_i(34,'Align',left,d,[ str ]).
html_comp_i(34,'Valign',top,d,[ str ]).
html_comp_i(35,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(35,'Class','col-sm-9 gx-attribute',v,[ str ]).
html_comp_i(35,'Id','',d,[ str ]).
html_comp_i(35,'Height',measure(0,px),d,[ measure ]).
html_comp_i(35,'Width',measure(0,px),d,[ measure ]).
html_comp_i(35,'Semanticcontent',div,d,[ str ]).
html_comp_i(35,'Align',left,d,[ str ]).
html_comp_i(35,'Valign',top,d,[ str ]).
html_comp_i(36,'Isabstractlayoutcontrol',0,d,[ bool ]).
html_comp_i(36,'Colcount',4,d,[ num ]).
html_comp_i(36,'Attid',-9,v,[ num ]).
html_comp_i(36,'Class','Attribute',v,[ str ]).
html_comp_i(36,'Controlname','&Totaltrips',d,[ str ]).
html_comp_i(36,'Returnonclick',0,v,[ bool ]).
html_comp_i(36,'Eventgx','',d,[ str ]).
html_comp_i(36,'Captionclass','col-sm-3 AttributeLabel',v,[ str ]).
html_comp_i(36,'Captionstyle','',v,[ str ]).
html_comp_i(36,'Captionposition','Left',v,[ str ]).
html_comp_i(36,'Captionvalue','Total Trips',d,[ str ]).
html_comp_i(36,'Layoutclass','col-sm-9',v,[ str ]).
html_comp_i(36,'Controltype',2,d,[ num ]).
html_comp_i(36,'Inputtype',0,d,[ num ]).
html_comp_i(36,'Notifycontextchange',0,d,[ bool ]).
html_comp_i(36,'Emptyasnull','Yes',d,[ str ]).
html_comp_i(36,'Readonly',-1,v,[ bool ]).
html_comp_i(36,'Autocomplete',-1,d,[ bool ]).
html_comp_i(36,'Ispassword',0,d,[ bool ]).
html_comp_i(36,'Autoresize',-1,d,[ bool ]).
html_comp_i(36,'Gxwidth',measure(4,chr),d,[ measure ]).
html_comp_i(36,'Gxheight',measure(1,row),d,[ measure ]).
html_comp_i(36,'Ismultiline',0,d,[ bool ]).
html_comp_i(36,'Maxtextnumberlines',0,d,[ num ]).
html_comp_i(36,'Fill',-1,d,[ bool ]).
html_comp_i(36,'Backcolor',rgb(255,255,255),d,[ color ]).
html_comp_i(36,'Forecolor',rgb(0,0,0),d,[ color ]).
html_comp_i(36,'Font',font('Arial',10,[]),d,[ font ]).
html_comp_i(36,'Horizontalalignment',right,d,[ str ]).
html_comp_i(36,'Gxformat',0,d,[ num ]).
html_comp_i(36,'Title','',d,[ str ]).
html_comp_i(36,'Invitemsg','',v,[ str ]).
 
 
 
 
 
 
 
 
 
lit_i(8,1,t('Countryid',23),[ ctlname('&Countryid'),ctrltype(dyncombo,8),pos(8),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(7,1,div(7),[ ctlname('') ]).
lit_i(6,1,div(6),[ ctlname('') ]).
lit_i(5,1,div(5),[ ctlname('') ]).
lit_i(4,1,div(4),[ ctlname('') ]).
lit_i(16,1,t('Attractionnameform',23),[ ctlname('&Attractionnameform'),ctrltype(edit,16),pos(16),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(15,1,div(15),[ ctlname('') ]).
lit_i(14,1,div(14),[ ctlname('') ]).
lit_i(13,1,div(13),[ ctlname('') ]).
lit_i(12,1,div(12),[ ctlname('') ]).
lit_i(21,1,t('Attractionnameto',23),[ ctlname('&Attractionnameto'),ctrltype(edit,21),pos(21),ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(20,1,div(20),[ ctlname('') ]).
lit_i(19,1,div(19),[ ctlname('') ]).
lit_i(18,1,div(18),[ ctlname('') ]).
lit_i(17,1,div(17),[ ctlname('') ]).
lit_i(11,1,div(11),[ ctlname('Table1') ]).
lit_i(10,1,div(10),[ ctlname('') ]).
lit_i(9,1,div(9),[ ctlname('') ]).
lit_i(25,1,s(t(7,2),24),[ ctlname(7),ctrltype(edit,25),pos(25),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(26,1,s(t(8,2),24),[ ctlname(8),ctrltype(edit,26),pos(26),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(27,1,s(t(10,2),24),[ ctlname(10),ctrltype(edit,27),pos(27),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(28,1,s(t(13,2),24),[ ctlname(13),ctrltype(edit,28),pos(28),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(29,1,s(t('Trips',23),24),[ ctlname('&Trips'),ctrltype(edit,29),pos(29),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(30,1,s(t('Update',23),24),[ ctlname('&Update'),ctrltype(edit,30),pos(30),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(31,1,s(t('Newtrip',23),24),[ ctlname('&Newtrip'),ctrltype(edit,31),pos(31),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(24,1,s(24),[ ctlname('Grid1'),el([ t(7,2),t(8,2),t(10,2),t(13,2),t('Trips',23),t('Update',23),t('Newtrip',23) ]),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(23,1,div(23),[ ctlname('') ]).
lit_i(22,1,div(22),[ ctlname('') ]).
lit_i(36,1,t('Totaltrips',23),[ ctlname('&Totaltrips'),ctrltype(edit,36),pos(36),readonly,ispwd(0),e2n(1),width(0),rect(0,0,10,10),title('Nothing') ]).
lit_i(35,1,div(35),[ ctlname('') ]).
lit_i(34,1,div(34),[ ctlname('') ]).
lit_i(33,1,div(33),[ ctlname('') ]).
lit_i(32,1,div(32),[ ctlname('') ]).
lit_i(3,1,div(3),[ ctlname('Maintable') ]).
lit_i(2,1,div(2),[ ctlname('') ]).
lit_i(1,1,window,[ rect(0,0,1000,1000),ctlname('Form') ]).
 
 
 
 
 
 
ctrl_info_i(1,30,[ [ 0,0,sort,[],[],0,0,5,0,0 ] ]).
 
 
 
att_prop_i(2,49,'ExternalName','TripDate',d).
att_prop_i(2,49,'ExternalNamespace','Traveling',d).
att_prop_i(2,49,'EmptyAsNull','Yes',d).
att_prop_i(2,49,idBasedOn,'',d).
att_prop_i(2,49,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,49,'AttRegEx','',d).
att_prop_i(2,49,'AttValidationFailedMsg','',d).
att_prop_i(2,49,idDATEFORMAT,idDATEFORMAT_SHORT,d).
att_prop_i(2,49,'DownloadOffline','0',d).
att_prop_i(2,49,'VarServiceExtName','',d).
att_prop_i(2,49,'FullName','TripDate',v).
att_prop_i(2,7,'ExternalName','AttractionId',d).
att_prop_i(2,7,'ExternalNamespace','Traveling',d).
att_prop_i(2,7,'EmptyAsNull','Yes',d).
att_prop_i(2,7,idBasedOn,85,v).
att_prop_i(2,7,'AUTONUMBER','-1',v).
att_prop_i(2,7,'AUTONUMBER_START','1',d).
att_prop_i(2,7,'AUTONUMBER_STEP','1',d).
att_prop_i(2,7,'AUTONUMBER_FORREPLICATION','-1',d).
att_prop_i(2,7,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,7,'AttRegEx','',d).
att_prop_i(2,7,'AttValidationFailedMsg','',d).
att_prop_i(2,7,'DownloadOffline','0',d).
att_prop_i(2,7,'VarServiceExtName','',d).
att_prop_i(2,7,'FullName','AttractionId',v).
att_prop_i(2,8,'ExternalName','AttractionName',d).
att_prop_i(2,8,'ExternalNamespace','Traveling',d).
att_prop_i(2,8,'EmptyAsNull','Yes',d).
att_prop_i(2,8,idBasedOn,86,v).
att_prop_i(2,8,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,8,'DB_NLS_SUPPORT','Yes',d).
att_prop_i(2,8,'AttRegEx','',d).
att_prop_i(2,8,'AttValidationFailedMsg','',d).
att_prop_i(2,8,'DownloadOffline','0',d).
att_prop_i(2,8,'VarServiceExtName','',d).
att_prop_i(2,8,'FullName','AttractionName',v).
att_prop_i(2,10,'ExternalName','CountryName',d).
att_prop_i(2,10,'ExternalNamespace','Traveling',d).
att_prop_i(2,10,'EmptyAsNull','Yes',d).
att_prop_i(2,10,idBasedOn,86,v).
att_prop_i(2,10,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,10,'DB_NLS_SUPPORT','Yes',d).
att_prop_i(2,10,'AttRegEx','',d).
att_prop_i(2,10,'AttValidationFailedMsg','',d).
att_prop_i(2,10,'DownloadOffline','0',d).
att_prop_i(2,10,'VarServiceExtName','',d).
att_prop_i(2,10,'FullName','CountryName',v).
att_prop_i(2,13,'ExternalName','AttractionPhoto',d).
att_prop_i(2,13,'ExternalNamespace','Traveling',d).
att_prop_i(2,13,'EmptyAsNull','Yes',d).
att_prop_i(2,13,'ExternalStorage','-1',d).
att_prop_i(2,13,idBasedOn,'',d).
att_prop_i(2,13,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,13,'AttRegEx','',d).
att_prop_i(2,13,'AttValidationFailedMsg','',d).
att_prop_i(2,13,'DownloadOffline','0',d).
att_prop_i(2,13,'VarServiceExtName','',d).
att_prop_i(2,13,'FullName','AttractionPhoto',v).
att_prop_i(2,9,'ExternalName','CountryId',d).
att_prop_i(2,9,'ExternalNamespace','Traveling',d).
att_prop_i(2,9,'EmptyAsNull','Yes',d).
att_prop_i(2,9,idBasedOn,85,v).
att_prop_i(2,9,'AUTONUMBER','-1',v).
att_prop_i(2,9,'AUTONUMBER_START','1',d).
att_prop_i(2,9,'AUTONUMBER_STEP','1',d).
att_prop_i(2,9,'AUTONUMBER_FORREPLICATION','-1',d).
att_prop_i(2,9,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,9,'AttRegEx','',d).
att_prop_i(2,9,'AttValidationFailedMsg','',d).
att_prop_i(2,9,'DownloadOffline','0',d).
att_prop_i(2,9,'VarServiceExtName','',d).
att_prop_i(2,9,'FullName','CountryId',v).
att_prop_i(2,48,'ExternalName','TripId',d).
att_prop_i(2,48,'ExternalNamespace','Traveling',d).
att_prop_i(2,48,'EmptyAsNull','Yes',d).
att_prop_i(2,48,idBasedOn,85,v).
att_prop_i(2,48,'AUTONUMBER','-1',v).
att_prop_i(2,48,'AUTONUMBER_START','1',d).
att_prop_i(2,48,'AUTONUMBER_STEP','1',d).
att_prop_i(2,48,'AUTONUMBER_FORREPLICATION','-1',d).
att_prop_i(2,48,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,48,'AttRegEx','',d).
att_prop_i(2,48,'AttValidationFailedMsg','',d).
att_prop_i(2,48,'DownloadOffline','0',d).
att_prop_i(2,48,'VarServiceExtName','',d).
att_prop_i(2,48,'FullName','TripId',v).
att_prop_i(2,40000,'ExternalName','TripDate',d).
att_prop_i(2,40000,'ExternalNamespace','Traveling',d).
att_prop_i(2,40000,'EmptyAsNull','Yes',d).
att_prop_i(2,40000,idBasedOn,'',d).
att_prop_i(2,40000,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,40000,'AttRegEx','',d).
att_prop_i(2,40000,'AttValidationFailedMsg','',d).
att_prop_i(2,40000,idDATEFORMAT,idDATEFORMAT_SHORT,d).
att_prop_i(2,40000,'DownloadOffline','0',d).
att_prop_i(2,40000,'VarServiceExtName','',d).
att_prop_i(2,40000,'FullName','TripDate',v).
att_prop_i(2,40001,'ExternalName','',d).
att_prop_i(2,40001,'ExternalNamespace','',d).
att_prop_i(2,40001,'EmptyAsNull','Yes',d).
att_prop_i(2,40001,idBasedOn,'',d).
att_prop_i(2,40001,'AUTONUMBER','0',d).
att_prop_i(2,40001,'ATT_INITIAL_VALUE','',d).
att_prop_i(2,40001,'AttRegEx','',d).
att_prop_i(2,40001,'AttValidationFailedMsg','',d).
att_prop_i(2,40001,'FullName','',v).
 
tbl_prop_i(2,14,'AllDirSuper',[ [ 2,[ 7 ] ],[ 13,[ 48 ] ] ],v).
tbl_prop_i(2,2000,'DirSubor',[ [ 14,[ 7 ] ] ],v).
tbl_prop_i(2,13,'DirSubor',[ [ 14,[ 48 ] ] ],v).
tbl_prop_i(2,2,'DirSubor',[ [ 14,[ 7 ] ] ],v).
tbl_prop_i(2,14,'DirSuper',[ [ 2,[ 7 ] ],[ 13,[ 48 ] ] ],v).
 
tbl_att_prop_i(2,14,48,'AllowNulls',n).
tbl_att_prop_i(2,14,7,'AllowNulls',n).
tbl_att_prop_i(2,13,48,'AllowNulls',n).
tbl_att_prop_i(2,13,48,'AUTONUMBER',y).
tbl_att_prop_i(2,13,49,'AllowNulls',n).
tbl_att_prop_i(2,3,9,'AllowNulls',n).
tbl_att_prop_i(2,3,9,'AUTONUMBER',y).
tbl_att_prop_i(2,3,10,'AllowNulls',n).
tbl_att_prop_i(2,2,7,'AllowNulls',n).
tbl_att_prop_i(2,2,7,'AUTONUMBER',y).
tbl_att_prop_i(2,2,8,'AllowNulls',n).
tbl_att_prop_i(2,2,9,'AllowNulls',n).
tbl_att_prop_i(2,2,13,'AllowNulls',n).
tbl_att_prop_i(2,2,40001,'AllowNulls',n).
tbl_att_prop_i(2,2000,7,'AllowNulls',n).
tbl_att_prop_i(2,2000,7,'AUTONUMBER',y).
 
var_prop_i(2,'Countryid',idBasedOn,'',v).
var_prop_i(2,'Attractionnameform',idBasedOn,'',v).
var_prop_i(2,'Attractionnameto',idBasedOn,'',v).
 
 
 
a_alias_i([ 'count(',49 ],'GXC1').
a_alias_i(se(40000,[ [ 2000,40000 ] ],[ t('coalesce(',1),t(40000,2),t(',',7),t('0',3),t(')',4) ]),'GXC1').
 
 
 
 
 
 
 
 
sub_info_i(146,'Load',1,4,[ [ 'Totaltrips' ],[ 'Trips',40000,'Totaltrips' ] ]).
sub_info_i(146,'Refresh',6,8,[ [],[ 'Totaltrips' ] ]).
sub_info_i(146,'Start',10,13,[ [],[ 'Update','Newtrip' ] ]).
sub_info_i(146,[ t('Update',23,15,7),t('Click',3,15,15) ],15,17,[ [ 7 ],[] ]).
sub_info_i(146,[ t('Newtrip',23,19,7),t('Click',3,19,16) ],19,22,[ [ ctrl('Grid1','refresh('),7 ],[ 'Trips' ] ]).
sub_info_i(146,[ t(8,2,25,7),t('Click',3,25,22) ],25,28,[ [ 7 ],[] ]).
 
pgm_parm_i(web,42,'VIEWCOUNTRYINFO_RELATED',[ [ int,4,0,0 ] ],[ [ 'CountryId',in,[] ] ]).
pgm_parm_i(trn,2,'ATTRACTION',[ [ char,3,0,0 ],[ int,4,0,0 ] ],[ [ 'Mode',in,[] ],[ 'AttractionId',in,[] ] ]).
pgm_parm_i(proc,31,'NEWTRIP',[ [ int,4,0,0 ],[ int,4,0,0 ] ],[ [ 'AttractionId',in,[] ],[ trips,out,[] ] ]).
 
pgm_callprotocol_i(web,33,'WWATTRACTIONSFROMSCRATCH','INTERNAL','Secure').
pgm_callprotocol_i(web,42,'VIEWCOUNTRYINFO_RELATED','INTERNAL','Secure').
pgm_callprotocol_i(trn,2,'ATTRACTION','INTERNAL','Secure').
pgm_callprotocol_i(proc,31,'NEWTRIP','INTERNAL','Secure').
 
 
 
 
module_info_i('GeneXus','CSHARP_NAME_SPACE','GeneXus.Core').
module_info_i('GeneXus','AssemblyName','GeneXus.dll').
 
 
 
 
 
 
 
 
 
 
