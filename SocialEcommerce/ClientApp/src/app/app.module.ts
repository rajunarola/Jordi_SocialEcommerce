import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER, Injector } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { API_BASE_URL } from 'src/shared/service-proxies/service-proxies';
import { AppConstants } from 'src/shared/app.constants';
import { APP_BASE_HREF, LocationStrategy } from '@angular/common';
import { ServiceProxyModule } from 'src/shared/service-proxies/service-proxies.module';
import { NavMenuComponent } from './Layout/nav-menu/nav-menu.component';
import { AppRoutes } from './app.routing';
import { AppPreBootstrap } from 'src/AppPreBootstrap';


export function appInitializerFactory(injector: Injector, location: LocationStrategy) {

  return () => {
    AppConstants.appBaseHref = getBaseHref(location);

    let appBaseUrl = getDocumentOrigin() + AppConstants.appBaseHref;

    AppPreBootstrap.run(appBaseUrl);

     // TO DO : To set user info in app session
    // injector.get(AppSessionService).init();
};

  /*return () => {
    AppConstants.appBaseHref = "/";

    AppConstants.appBaseUrl = environment.appBaseUrl;
    AppConstants.remoteServiceBaseUrl = environment.remoteServiceBaseUrl;
    AppConstants.inProd = environment.production;

  
  };*/
}

function getDocumentOrigin() {
  if (!document.location.origin) {
    return document.location.protocol + '//' + document.location.hostname + (document.location.port ? ':' + document.location.port : '');
  }
  return document.location.origin;
}

export function getBaseHref(locationStrategy: LocationStrategy): string {
  return '/';
}

export function getRemoteServiceBaseUrl() {
  console.log("AppConstants.remoteServiceBaseUrl : ", AppConstants.remoteServiceBaseUrl);
  return AppConstants.remoteServiceBaseUrl;
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    ServiceProxyModule,
    RouterModule.forRoot(AppRoutes),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: APP_INITIALIZER, useFactory: appInitializerFactory, deps: [Injector, LocationStrategy], multi: true },
    { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
