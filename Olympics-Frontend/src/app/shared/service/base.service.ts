import { HttpClient } from "@angular/common/http";
import { Inject, Injectable, Injector } from "@angular/core";
import { environment } from "src/environments/environment";


@Injectable()
export class BaseService {

  constructor(@Inject(Injector) protected injector: Injector) {}

  protected httpClient: HttpClient = this.injector.get(HttpClient);


  protected async httpPost<T>(method: string, data: any): Promise<T> {
    const url = environment.BaseUrl + method;
    return this.httpClient.post<T>(url, data).toPromise();
  }

  protected async httpGet<T>(method: string, params?: { [param: string]: string }): Promise<T> {
    const url = environment.BaseUrl + method;
    return this.httpClient.get<T>(url, { params: params }).toPromise();
  }

  protected async httpDelete<T>(method: string, params?: { [param: string]: string }): Promise<T> {
    const url = environment.BaseUrl + method;
    return this.httpClient.delete<T>(url, { params: params }).toPromise();
  }

}
