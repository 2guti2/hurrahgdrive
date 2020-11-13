// sources: 
// https://stackoverflow.com/questions/31809987/google-app-scripts-email-a-spreadsheet-as-excel
// https://stackoverflow.com/questions/26615546/google-apps-script-urlfetchapp-post-file
// https://stackoverflow.com/questions/24340340/urlfetchapp-upload-file-multipart-form-data-in-google-apps-script

function main(){
  deleteTriggers();
  ScriptApp.newTrigger('sendExcel')
      .timeBased()
      .everyMinutes(5)
      .create();
}

function sendExcel() {
  config = {};
  var spreadsheet   = SpreadsheetApp.getActiveSpreadsheet();
  var spreadsheetId = spreadsheet.getId()
  var file          = Drive.Files.get(spreadsheetId);
  var url           = 'https://docs.google.com/spreadsheets/d/'+spreadsheetId+'/export?format=xlsx';
  var token         = ScriptApp.getOAuthToken();
  var response      = UrlFetchApp.fetch(url, {
    headers: {
      'Authorization': 'Bearer ' + token
    }
  });

  var fileName = (config.fileName || spreadsheet.getName()) + '.xlsx';
  var blobs   = [response.getBlob().setName(fileName)];
  if (config.zip) {
    blobs = [Utilities.zip(blobs).setName(fileName + '.zip')];
  }
  url = "http://drivefiles.gohurrah.com/api/File/Upload";
  
  var form = {
    attachment: response.getBlob()
  };
  uploadFile(url,form);
}

function uploadFile(url,form) {
  var options = {
    method : "POST",
    payload : form
  };
  var request = UrlFetchApp.getRequest(url,options);   // (OPTIONAL) generate the request so you
  console.info("Request payload: " + request.payload); // can examine it (useful for debugging)
  var response = UrlFetchApp.fetch(url,options);
  console.info("Response body: " + response.getContentText());
}

function deleteTriggers() {
  var allTriggers = ScriptApp.getProjectTriggers();
  for (var i = 0; i < allTriggers.length; i++) {
      ScriptApp.deleteTrigger(allTriggers[i]);
  }
}