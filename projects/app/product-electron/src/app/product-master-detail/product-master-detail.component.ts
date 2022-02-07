import { Component, OnInit } from '@angular/core';
import { PoPageFilter, PoTableAction, PoTableColumn } from '@po-ui/ng-components';
import { ProductService } from 'src/service/product.service';

@Component({
  selector: 'app-product-master-detail',
  templateUrl: './product-master-detail.component.html',
  styleUrls: ['./product-master-detail.component.css']
})
export class ProductMasterDetailComponent implements OnInit {

  public pageFilter: PoPageFilter = {
    action: this.quickFilter.bind(this),
    placeholder: "Filtrar"
  };

  public tableColumns: Array<PoTableColumn> = [
    { property: "id", width: "20%", type: "string", visible: false },
    { property: "code", label: "Code", width: "15%", type: "number" },
    { property: "description", label: "Description", width: "50%", type: "string" },
    { property: "unit", label: "Unit", width: "20%", type: "string" }
  ];

  public tableActions: Array<PoTableAction> = [{
    label: "Remove",
    action: this.onDeleteTableRecord.bind(this),
    icon: "po-icon po-icon-delete",
    type: "danger"
  }];

  public qtdRecordsByPage: number = 10;
  public qtdSkip: number = 0;
  public loadingHidden: boolean = true;
  public loadingActived: boolean = false;
  public showMoreDisable: boolean = true;
  public tableItems: Array<any> = [];
  public tableItemsAuxiliary: Array<any> = [];

  constructor(private _service: ProductService) { }

  ngOnInit(): void {
    this.getTableItems();
  }

  public quickFilter(pFilter: string): void {
    if (pFilter === undefined || pFilter == "") {
      this.tableItems = this.tableItemsAuxiliary;
      return;
    }
    this.tableItems = this.tableItems.filter(f => f.code == pFilter || f.description == pFilter || f.unit == pFilter );
  }

  public onShowMore(): void {
    this.updatePagination();
    this.getTableItems();
  }

  public onDeleteTableRecord(record: any): void {
    this.toggleLoading();    
    this.updatePagination(0);
    this._service.delTableItem(record.code)
      .subscribe({
        next: (data) => {
          this.toggleLoading();
          this.getTableItems();
        },
        error: (err) => {
          console.error(err);
          this.toggleLoading();
        }
      });
  }

  public getTableItems(): void {
    this.toggleLoading();
    this._service.getTableItems(this.getPagination())
      .subscribe({
        next: (data) => {
          this.updateTableItems(data.payload);
          this.setShowMore(data.footer.hasNext);
        },
        error: (err) => {
          this.updateTableItems([]);
          this.toggleLoading();
        },
        complete: () => this.toggleLoading()
      });
  }

  public toggleLoading(): void {
    this.loadingHidden = !this.loadingHidden;
    this.loadingActived = !this.loadingActived;
  }

  public updatePagination(pNewValueSkip?: number): void {
    if (pNewValueSkip === undefined || pNewValueSkip === null) {
      this.qtdSkip = this.tableItems.length;
      return;
    }
    this.qtdSkip = pNewValueSkip;
  }

  private setShowMore(pHasNextData: boolean): void {
    this.showMoreDisable = !pHasNextData;
  }

  private getPagination(): any {
    return { 
      qtdRecords: this.qtdRecordsByPage,
      skip: this.qtdSkip 
    };
  }

  private updateTableItems(pData: Array<any>) {
    if (this.qtdSkip == 0) {
      this.tableItems = pData;
    } else {
      this.tableItems = this.tableItems.concat(pData);
    }
    this.tableItemsAuxiliary = this.tableItems;
  }
}