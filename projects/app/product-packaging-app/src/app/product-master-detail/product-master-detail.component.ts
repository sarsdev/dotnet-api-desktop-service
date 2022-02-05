import { Component, OnInit } from '@angular/core';
import { PoPageFilter, PoTableColumn } from '@po-ui/ng-components';
import { ProductService } from 'src/service/product.service';

@Component({
  selector: 'app-product-master-detail',
  templateUrl: './product-master-detail.component.html',
  styleUrls: ['./product-master-detail.component.css']
})
export class ProductMasterDetailComponent implements OnInit {

  public pageFilter: PoPageFilter = {
    action: this.quickFilter,
    advancedAction: this.advancedFilter,
    placeholder: "Filtrar"
  };

  public tableColumns: Array<PoTableColumn> = [
    { property: "id", visible: false },
    { property: "code", label: "Code" },
    { property: "description", label: "Description" },
    { property: "unit", label: "Unit" }
  ];

  public tableItems: any = [];
  public service: ProductService;

  constructor(pService: ProductService) { 
    this.service = pService;
  }

  ngOnInit(): void {
    this.tableItems = this.getTableItems();
  }

  public quickFilter(pFilter: string): void {
    console.info(`quickFilter: ${pFilter}`);
  }

  public advancedFilter(): void {
    console.info("advancedFilter");
  }

  private getTableItems(): void {
    this.service.getTableItems().subscribe(
      (data) => {
        console.info(data);
        this.tableItems = data.payload;
      },
      (err) => {
        console.error(err);
        this.tableItems = [];
      }
    );
  }
}