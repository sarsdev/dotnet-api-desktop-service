import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PoDynamicFormField } from '@po-ui/ng-components';
import { ProductService } from 'src/service/product.service';

@Component({
  selector: 'app-product-master',
  templateUrl: './product-master.component.html',
  styleUrls: ['./product-master.component.css']
})
export class ProductMasterComponent implements OnInit {

  @Input() valuesForm: any = {};
  @Output() onToggleLoading = new EventEmitter<any>();
  @Output() onUpdateTableItems = new EventEmitter<any>();
  @Output() onUpdatePagination = new EventEmitter<number>();

  public fieldsForm: Array<PoDynamicFormField> = [
    {
      property: 'code',
      minLength: 1,
      maxLength: 50,
      gridColumns: 6,
      order: 1,
      placeholder: 'Type product code here...',
      type: "number"
    },
    {
      property: 'unit',
      minLength: 1,
      maxLength: 20,
      gridColumns: 6,
      order: 2,
      placeholder: 'Type product unit here...',
      type: "string"
    },
    {
      property: 'description',
      minLength: 1,
      maxLength: 2000,
      gridColumns: 12,
      order: 3,
      placeholder: 'Type product description here...',
      type: "string"
    }
  ];

  constructor(private _service: ProductService) { }

  ngOnInit(): void { }

  public onSave(): void {
    if (this.AreFieldsFormInvalid()) { return; }
    this.onToggleLoading.emit();
    if(this.valuesForm.id === undefined || this.valuesForm.id === null || this.valuesForm.id == "") {
      this.addRecord();
    } else {
      this.updateRecord();
    }
  }

  private AreFieldsFormInvalid(): boolean {
    let fieldsInvalid: boolean = false;

    fieldsInvalid = fieldsInvalid || this.valuesForm.code === undefined;
    fieldsInvalid = fieldsInvalid || this.valuesForm.unit === undefined;
    fieldsInvalid = fieldsInvalid || this.valuesForm.description === undefined;

    fieldsInvalid = fieldsInvalid || this.valuesForm.code === null;
    fieldsInvalid = fieldsInvalid || this.valuesForm.unit === null;
    fieldsInvalid = fieldsInvalid || this.valuesForm.description === null;

    fieldsInvalid = fieldsInvalid || this.valuesForm.code == "";
    fieldsInvalid = fieldsInvalid || this.valuesForm.unit == "";
    fieldsInvalid = fieldsInvalid || this.valuesForm.description == "";

    return fieldsInvalid;
  }

  private addRecord(): void {    
    this.onUpdatePagination.emit();
    this._service.postTableItem(this.valuesForm).subscribe({
      next: (res) => {
        this.onToggleLoading.emit();
        this.onUpdateTableItems.emit();
      },
      error: (err) => {
        this.onToggleLoading.emit();
        console.error(err);
      }
    });
  }

  private updateRecord(): void {    
    this.onUpdatePagination.emit(0);
    this._service.putTableItem(this.valuesForm).subscribe({
      next: (res) => {
        this.onToggleLoading.emit();
        this.onUpdateTableItems.emit();
      },
      error: (err) => {
        this.onToggleLoading.emit();
        console.error(err);
      }
    });
  }
}
