import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import {FormControl} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import { environment } from 'src/environments/environment';

export interface ProductPortalDto {
  ProductId: number;
  ProductName: string;
  GrossWeight: number;
  SKU: string;
  Barcode: number;
  MPE: number;
  Photo: string;
  Unit: string;
  Category: string;
  Trademark: string;
  OnHand: number;
  Price: number;
}

@Component({
  selector: 'app-products-and-services',
  templateUrl: './products-and-services.component.html',
  styleUrls: ['./products-and-services.component.css']
})
export class ProductsAndServicesComponent implements OnInit {

  trademarks = new FormControl();
   categories = new FormControl();
   allProducts: ProductPortalDto[] = []
   products: any;
   trademarkList : any;
   categoriesList : any;

   //trademarkList: string[] = ['Extra cheese', 'Mushroom', 'Onion', 'Pepperoni', 'Sausage', 'Tomato'];
   pageNumber: 1;
   pageSize: 8;
   pageCount: any;
   arrayNumber : number[];

  // products = [];
  //    pageNo: any = 1;
       pageNumbers: boolean[] = [];
  //    sortOrder: any = 'CompanyName';
    //Pagination Variables

  pageField = [];
    exactPageList: any;
    paginationData: number;
    productsPerPage: any = 5;
    totalProducts: any;
    totalProductsCount: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllProduct();

     this.pageNumber= 1;
     this.pageSize= 8;
    this.pageNumbers[0] = true;
   // this.getSelectedProduct(this.pageNumber);
    this.getAlltrademarkList();
    this.getAllCategoriesList();
    //this.getSelectedProductFilterTrademark([1,2,3]);

  }

  getAllProduct() {
    //'https://localhost:44307/api/Sales/portal'
    this.http.get(environment.apiUrl+'/api/ProductsAndServices')
     .subscribe((response2) => {
    this.products = response2;
    console.log(this.products);
  } );
}

// getSelectedProduct(numberForGet:any) {
//   //console.error('this.PageNumber',this.pageNumber);
//   this.pageNumber = numberForGet;
//   this.http.put(environment.apiUrl+'/api/ProductLists',{
//     "pageNumber":  this.pageNumber,
//         "pageSize":  this.pageSize,
//         "SelectedTrademarks": this.trademarks.value,
//         "SelectedCategories": this.categories.value
//     })
//    .subscribe((response2: any) => {
//   this.products = response2.products;
//   this.pageCount= response2.pageCount;
//   console.log(this.products);
//   console.log('this.pageCount',this.pageCount);
//   this.arrayNumber = Array.from({length: this.pageCount}, (_, i) => i + 1)
//   console.log('this.arrayNumber',this.arrayNumber);
// } );
// }

getAlltrademarkList() {
  //'https://localhost:44307/api/Sales/portal'
  this.http.get(environment.apiUrl+'/api/TrademarksLists')
   .subscribe((response2) => {
  this.trademarkList = response2;
  console.log('this.trademarkList', this.trademarkList);
} );
}

getAllCategoriesList() {
  //'https://localhost:44307/api/Sales/portal'
  this.http.get(environment.apiUrl+'/api/CategoriesLists')
   .subscribe((response2) => {
  this.categoriesList = response2;
  console.log('this.trademarkList',this.trademarkList);
} );
}

getSelectedProductFilterTrademark() {
  //selectedTrade:any
  console.error('trademarks',this.trademarks.value);

  //console.error('selectedTrade',selectedTrade);
  let dataArray: Number[] = [1,2];
  this.http.put(environment.apiUrl+'/api/ProductLists',{
    "pageNumber":  this.pageNumber,
        "pageSize":  this.pageSize,
        "SelectedTrademarks": this.trademarks.value,
        "SelectedCategories": this.categories.value
    })
   .subscribe((response2: any) => {
  this.products = response2.products;
  this.pageCount= response2.pageCount;
  console.log(this.products);
  console.log('this.pageCount',this.pageCount);
  this.arrayNumber = Array.from({length: this.pageCount}, (_, i) => i + 1)
  console.log('this.arrayNumber',this.arrayNumber);
} );
}

//Method For Pagination
  // totalNoOfPages() {

  //   this.paginationData = Number(this.totalProductsCount / this.productsPerPage);
  //   let tempPageData = this.paginationData.toFixed();
  //   if (Number(tempPageData) < this.paginationData) {
  //     this.exactPageList = Number(tempPageData) + 1;
  //     this.paginationService.exactPageList = this.exactPageList;
  //   } else {
  //     this.exactPageList = Number(tempPageData);
  //     this.paginationService.exactPageList = this.exactPageList
  //   }
  //   this.paginationService.pageOnLoad();
  //   this.pageField = this.paginationService.pageField;

  // }
  // showCompaniesByPageNumber(page, i) {
  //   this.products = [];
  //   this.pageNumber = [];
  //   this.pageNumber[i] = true;
  //   this.pageNo = page;
  //   this.getSelectedProduct()
  // }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
        // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
        // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getProducts(): Observable<ProductPortalDto[]> {
    // now returns an Observable of Config
    //https://localhost:44307/api/Sales/portal'
    return this.http.get<ProductPortalDto[]>(environment.apiUrl+'/api/ProductLists', {
      headers: new HttpHeaders({ 'Access-Control-Allow-Origin': '*' })
    }
  )
    .pipe(
      catchError(this.handleError<ProductPortalDto[]>('getHeroes', []))
    );


  //   .subscribe((response) => {
  //     this.allProducts = response.data;
  //     console.log("this.allProducts",this.allProducts);
  //     if (response.result === false){
  //       console.log('error')
  //     };
   }

}
