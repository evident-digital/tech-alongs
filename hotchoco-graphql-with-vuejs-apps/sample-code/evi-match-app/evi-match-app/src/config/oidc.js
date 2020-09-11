export const oidcSettings = {
  authority: 'https://login.microsoftonline.com/f927e0d2-5ac9-4d98-b514-df7b4d776ac3/v2.0',
  clientId: '4be6421c-bdfd-4a53-8962-af56d4c3fd96',
  redirectUri: 'http://localhost:5002/oidc-signin',
  responseType: 'code',
  scope: '4be6421c-bdfd-4a53-8962-af56d4c3fd96/.default openid profile',
  loadUserInfo: false
}
