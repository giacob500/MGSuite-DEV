 __author__ = 'bdm4'

import requests, json

token_url = "https://api.byu.edu/token"

test_api_url = "AIzaSyDK48i45yKE-OfYiVrsZtdfBzXYP1YyiSI"    #API KEY / API URL

#client (application) credentials on apim.byu.edu
client_id = '260392633753-18hl37euj7tpdk4pp4c1happd80d2o9t.apps.googleusercontent.com'  # ID client
client_secret = '4aQUzmnt-08DpxHP9Cqbi7gS'                                              # Client secret

#step A, B - single call with client credentials as the basic auth header - will return access_token
data = {'grant_type': 'client_credentials'}

access_token_response = requests.post(token_url, data=data, verify=False, allow_redirects=False, auth=(client_id, client_secret))

print access_token_response.headers
print access_token_response.text

tokens = json.loads(access_token_response.text)

print "access token: " + tokens['access_token']

#step B - with the returned access_token we can make as many calls as we want

api_call_headers = {'Authorization': 'Bearer ' + tokens['access_token']}
api_call_response = requests.get(test_api_url, headers=api_call_headers, verify=False)

print api_call_response.text