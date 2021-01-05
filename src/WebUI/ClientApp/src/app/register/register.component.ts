import { AppService } from './../app.service';
import { ToasterService } from 'angular2-toaster';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';


// @Component({
//   selector: 'app-register',
//   templateUrl: './register.component.html',
//   styleUrls: ['./register.component.css']
// })

@Component ({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {

  form: FormGroup;
    loading = false;
    submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    public readonly toasterService: ToasterService,
    private appService: AppService, private _router: Router
    //private alertService: AlertService
) { }

ngOnInit() {
    this.form = this.formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        username: ['', Validators.required],
        password: ['', [Validators.required, Validators.minLength(6)]]
    });
}

 get f() { return this.form.controls; }

onSubmit() {
  console.log('onSubmit() log');
  this.submitted = true;

  if (this.form.invalid) {
      return;
  }

  this.loading = true;
  this.appService.register(this.form.value)
      .pipe(first())
      .subscribe({
          next: () => {
              this.router.navigateByUrl('/login');
               this.toasterService.pop('info','Registration successful');   keepAfterRouteChange: true;
             // this.router.navigate(['/login'], { relativeTo: this.route });
          },
          error: error => {
            this.toasterService.pop('error', error);
              this.loading = false;
          }
      });
      this.router.navigate(['/login']);
      console.log('onSubmit() log 2');
}


}
