import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalesOrderListsComponent } from './sales-order-lists.component';

describe('SalesOrderListsComponent', () => {
  let component: SalesOrderListsComponent;
  let fixture: ComponentFixture<SalesOrderListsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SalesOrderListsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SalesOrderListsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
