import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { first, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  public getTableItems(pPagination: any): Observable<any> {
    return this.http.get<Observable<any>>(
      `https://localhost:7053/ProductPackaging/product/packaging?qtdpage=${pPagination.qtdRecords}&skip=${pPagination.skip}`,
      { observe: 'body', responseType: 'json', headers: new HttpHeaders("Access-Control-Allow-Origin: *") }
    ).pipe(first());
  }

  public delTableItem(pCode: number): Observable<any> {
    return this.http.delete<Observable<any>>(
      `https://localhost:7053/ProductPackaging/product/packaging/${pCode}`,
      { observe: 'body', responseType: 'json', headers: new HttpHeaders("Access-Control-Allow-Origin: *") }
    ).pipe(first());
  }
}
