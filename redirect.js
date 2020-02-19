/*
id client:
260392633753-18hl37euj7tpdk4pp4c1happd80d2o9t.apps.googleusercontent.com

client secret:
4aQUzmnt-08DpxHP9Cqbi7gS
*/


//Spunti per il codice presi da https://developers.google.com/identity/protocols/OAuth2UserAgent#creatingclient

var GoogleAuth; // Google Auth object.
function initClient() {
  gapi.client.init({
      'apiKey': 'AIzaSyDK48i45yKE-OfYiVrsZtdfBzXYP1YyiSI',                                      // api key
      'clientId': '260392633753-18hl37euj7tpdk4pp4c1happd80d2o9t.apps.googleusercontent.com',   //client id
      'scope': 'https://www.googleapis.com/auth/drive.metadata.readonly',
      'discoveryDocs': ['https://www.googleapis.com/discovery/v1/apis/drive/v3/rest']
  }).then(function () {
      GoogleAuth = gapi.auth2.getAuthInstance();

      // Listen for sign-in state changes.
      GoogleAuth.isSignedIn.listen(updateSigninStatus);
  });
}

//The application might set a Boolean value to determine whether to call the signIn() method before attempting to make an API call
var AccessTry = false;
if (AccessTry == true) {
    GoogleAuth.signIn();;
  }