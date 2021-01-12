import { from } from 'rxjs';

import { Routes, RouterModule  } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatMenuModule} from '@angular/material/menu';
import {CustomerPortalComponent } from './sales/customer-portal/customer-portal.component';
import {MatCardModule} from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatSelectModule} from '@angular/material/select/';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CustomerListComponent } from './Customer/customer-list/customer-list.component';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import {ToasterModule} from 'angular2-toaster';
import { AuthGuard } from './auth.guard';
import {JwtModule} from '@auth0/angular-jwt';
import { RoleAuthGuard as RoleGuard } from './role.auth.guard';
import { TokenInterception } from './token.interception';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { SalesOrderListsComponent } from './Sales/sales-order-lists/sales-order-lists.component';
import { AdminComponent } from './admin/admin.component';
import { RegisterComponent } from './register/register.component';
import { PurchaseOrderComponent } from './Purchase/purchase-order/purchase-order.component';
import { SuppliersComponent } from './Purchase/suppliers/suppliers.component';
import { ProductsAndServicesComponent } from './inventory/products-and-services/products-and-services.component';
import { TransfersComponent } from './inventory/transfers/transfers.component';
import { WorkOrdersComponent } from './manufactoring/work-orders/work-orders.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

const routes: Routes = [
  {path: 'login', component: LoginComponent},
  { path: 'register', component: RegisterComponent},
  { path: 'customerPortalComponent', component: CustomerPortalComponent, canActivate: [AuthGuard]}, //
  { path: 'customer-list', component: CustomerListComponent, canActivate: [AuthGuard] },
  { path: 'sales-order-lists', component: SalesOrderListsComponent, canActivate: [AuthGuard] },
    {path: 'logout', component: LogoutComponent , canActivate: [AuthGuard]}, //
    {path: 'admin', component: AdminComponent , canActivate: [AuthGuard]},
    {path: 'purchase-order', component: PurchaseOrderComponent , canActivate: [AuthGuard]},
    {path: 'suppliers', component: SuppliersComponent , canActivate: [AuthGuard]},
    {path: 'productsAndServices', component: ProductsAndServicesComponent , canActivate: [AuthGuard]},
    {path: 'transfers', component: TransfersComponent , canActivate: [AuthGuard]},
    {path: 'workOrders', component: WorkOrdersComponent , canActivate: [AuthGuard]},


    //
]; // sets up routes constant where you define your routes


export function tokenGetter() {
  return this.appService.getToken$.subscribe(res => {
    if (res) {
    console.warn('tokenGetter', res);
    return res;
  }
  });
}

@NgModule({
  declarations: [
    AppComponent,
    CustomerPortalComponent,
    CustomerListComponent,
    LoginComponent,
    LogoutComponent,
    SalesOrderListsComponent,
    AdminComponent,
    RegisterComponent,
    PurchaseOrderComponent,
    SuppliersComponent,
    ProductsAndServicesComponent,
    TransfersComponent,
    WorkOrdersComponent
  ],
  imports: [

    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    MatMenuModule,
    FlexLayoutModule,
    HttpClientModule,
    [RouterModule.forRoot(routes)],
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    ToasterModule.forRoot(),
    BrowserAnimationsModule,

    JwtModule.forRoot({
      config: {
        tokenGetter,
        skipWhenExpired: true
      }
    })
    ],
  exports: [RouterModule,
    MatSelectModule,
    MatFormFieldModule,
    MatInputModule],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterception,
    multi: true
  },
  AuthGuard,
  RoleGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
