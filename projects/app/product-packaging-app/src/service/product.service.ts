import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  public getTableItems(): Observable<any> {
    return this.http.get<Observable<any>>("https://localhost:7053/ProductPackaging/product/packaging?qtdpage=10&skip=0", { observe: 'body', responseType: 'json', headers: new HttpHeaders("Access-Control-Allow-Origin: *") });
  }
}
