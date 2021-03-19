import {NgModule} from '@angular/core';
import * as ApiServiceProxies from './service-proxies';

@NgModule({
  providers: [
    ApiServiceProxies.WeatherForecastServiceProxy
  ]
})
export class ServiceProxyModule {
}
