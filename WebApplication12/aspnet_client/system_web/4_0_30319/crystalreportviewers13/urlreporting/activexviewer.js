
function writeActxViewer(sViewerVer, sProductLang, sPreferredViewingLang, bDrillDown, bExport, bDisplayGroupTree,
						bGroupTree, bAnimation, bPrint, bRefresh, bSearch,
						bZoom, bSearchExpert, bSelectExpert, sParamVer) {
	document.write("<OBJECT ID=\"CRViewer\"");
	document.write("CLASSID=\"CLSID:C0A870C3-66BB-4106-9A25-60A26F3C1DA8\"");
	document.write("WIDTH=\"100%\" HEIGHT=\"99%\"");
	document.write("STYLE=\"position:absolute\"");
	document.write("CODEBASE=\"" + gPath + viewerPath + "ActiveXControls/ActiveXViewer.cab#Version=" + sViewerVer + "\">");
	document.write("<PARAM NAME=\"LocaleID\" VALUE=\"" + sProductLang + "\">");
	document.write("<PARAM NAME=\"PreferredViewingLocaleID\" VALUE=\"" + sPreferredViewingLang + "\">");
	document.write("<PARAM NAME=\"EnableDrillDown\" VALUE=" + bDrillDown + ">");
	document.write("<PARAM NAME=\"EnableExportButton\" VALUE=" + bExport + ">");
	document.write("<PARAM NAME=\"DisplayGroupTree\" VALUE=" + bDisplayGroupTree + ">");

	document.write("<PARAM NAME=\"EnableGroupTree\" VALUE=" + bGroupTree +">");
	document.write("<PARAM NAME=\"EnableAnimationControl\" VALUE=" + bAnimation + ">");
	document.write("<PARAM NAME=\"EnablePrintButton\" VALUE=" + bPrint + ">");
	document.write("<PARAM NAME=\"EnableRefreshButton\" VALUE=" + bRefresh + ">");
	document.write("<PARAM NAME=\"EnableSearchControl\" VALUE=" + bSearch + ">");
	
	document.write("<PARAM NAME=\"EnableZoomControl\" VALUE=" + bZoom + ">");
	document.write("<PARAM NAME=\"EnableSearchExpertButton\" VALUE=" + bSearchExpert + ">");
	document.write("<PARAM NAME=\"EnableSelectExpertButton\" VALUE=" + bSelectExpert + ">");
	document.write("</OBJECT>");

	document.write("<OBJECT ID=\"ReportSource\"");
	document.write("CLASSID=\"CLSID:C05C1BE9-3285-4ED8-B47E-8F408534E89D\"");
	document.write("HEIGHT=\"1%\" WIDTH=\"1%\"");
	document.write("CODEBASE=\"" + gPath + viewerPath + "ActiveXControls/ActiveXViewer.cab#Version=" + sViewerVer + "\">");
	document.write("</OBJECT>");

	document.write("<OBJECT ID=\"ViewHelp\"");
	document.write("CLASSID=\"CLSID:C02176CF-8629-4AF6-8F96-00D2DAA4EFB2\"");
	document.write("HEIGHT=\"1%\" WIDTH=\"1%\"");
	document.write("CODEBASE=\"" + gPath + viewerPath + "ActiveXControls/ActiveXViewer.cab#Version=" + sViewerVer + "\">");
	document.write("</OBJECT>");
}

String.format = function() {
	if(arguments.length == 0) {
		return null;
	}
	var str = arguments[0];
	for(var i=1;i<arguments.length;i++) {
		var re = new RegExp('\\{' + (i-1) + '\\}','gm');
		str = str.replace(re, arguments[i]);
	}
	return str;
}

var PAGE_INITIALIZE_CODE = 'return function pageInitialize() {' +
	'try {'+
		'var webBroker = new ActiveXObject(\"CrystalReports14.WebReportBroker.1\");'+
		'var webSource0 = new ActiveXObject(\"CrystalReports14.WebReportSource.1\");'+
		'webSource0.ReportSource = webBroker;'+
		'var docUrl, qPos;'+
		'docUrl = window.location.href;'+
		'qPos = docUrl.indexOf(\"?\");'+
		'if(qPos > 0) {'+
			'docUrl = docUrl.substring(0, qPos);'+
		'}'+
		'webSource0.URL = docUrl + \"{1}\";'+
		'webSource0.PromptOnRefresh = {2};'+
		'webSource0.AddParameter(\"proxypath\", docUrl);'+
		'{3}'+
		'CRViewer.ReportSource = webSource0;'+
		'CRViewer.DownloadResourceCab(\"{4}\");'+
		'CRViewer.ViewReport();'+
	'}'+
	'catch(err) {'+
		'if((err.number & 0xFF) != 0) {'+
			'window.alert(\"The Crystal Report Viewer is unable to create its resource objects.\");'+
			'CRViewer.ReportName = {0};'+
		'}'+
	'}'+
'};';

function renderPageInitialize(reportName, url, promptOnRefresh, rptParameters, resourceCab) {
	if(rptParameters == undefined) { rptParameters = ""; }
	var codePageInitialize = String.format(PAGE_INITIALIZE_CODE, reportName, url, promptOnRefresh, rptParameters, resourceCab);
	codePageInitialize = unescape(codePageInitialize);
	var fPageInitialize = new Function(codePageInitialize);
	window.pageInitialize = fPageInitialize();
}

