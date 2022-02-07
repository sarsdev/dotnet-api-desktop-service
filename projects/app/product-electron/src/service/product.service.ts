import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { first, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private url: string = "https://localhost:7053/ProductPackaging/product/packaging";
  private options: any = { headers: new HttpHeaders("Access-Control-Allow-Origin: *") };

  constructor(private http: HttpClient) { }

  public getTableItems = (pPagination: any): Observable<any> => 
    this.http.get<Observable<any>>(`${this.url}?qtdpage=${pPagination.qtdRecords}&skip=${pPagination.skip}`, this.options).pipe(first());
  
  public postTableItem = (pNewRecord: any): Observable<any> => this.http.post<Observable<any>>(this.url, pNewRecord, this.options).pipe(first());
  public putTableItem = (pUpdatedRecord: any): Observable<any> => this.http.put<Observable<any>>(this.url, pUpdatedRecord, this.options).pipe(first());
  public delTableItem = (pCode: number): Observable<any> => this.http.delete<Observable<any>>(`${this.url}/${pCode}`, this.options).pipe(first());
}
