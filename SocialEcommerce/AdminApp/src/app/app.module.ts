import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER, Injector } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { API_BASE_URL } from 'src/shared/service-proxies/service-proxies';
import { AppConstants } from 'src/shared/app.constants';
import { LocationStrategy } from '@angular/common';
import { environment } from 'src/environments/environment';
import { ServiceProxyModule } from 'src/shared/service-proxies/service-proxies.module';

export function appInitializerFactory(injector: Injector, location: LocationStrategy) {
  return () => {
    AppConstants.appBaseHref = "/";

    AppConstants.appBaseUrl = environment.appBaseUrl;
    AppConstants.remoteServiceBaseUrl = environment.remoteServiceBaseUrl;
    AppConstants.inProd = environment.production;

    // TO DO : To set user info in app session
    // injector.get(AppSessionService).init();
  };
}

export function getRemoteServiceBaseUrl() {
  return AppConstants.remoteServiceBaseUrl;
}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    ServiceProxyModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: APP_INITIALIZER, useFactory: appInitializerFactory, deps: [Injector, LocationStrategy], multi: true },
    { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
