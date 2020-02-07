import { Component, OnInit , Inject} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidatorFn, FormArray } from '@angular/forms';
import { first } from 'rxjs/operators';
import { ApiService } from '../core/api.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-area-edit',
  templateUrl: './area-edit.component.html'
})
export class AreaEditComponent implements OnInit {
  areaEditForm: FormGroup;

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private actRoute: ActivatedRoute,
              private apiService: ApiService) { }

  ngOnInit() {
    const areaId = +this.actRoute.snapshot.paramMap.get('id');
    var datePipe = new DatePipe("en-US");

    this.areaEditForm = this.formBuilder.group({
      id: [''],
      name: ['', [Validators.required,Validators.maxLength(200)]],
      createdOn: [''],
      createdBy: [''],
      updatedOn: [''],
      updatedBy: ['']
    });
    
    this.apiService.getAreaById(areaId)
        .subscribe(result => {
          this.areaEditForm.setValue({
            id: result.id,
            name: result.name,
            createdOn: datePipe.transform(result.createdOn,'dd/MM/yyyy, h:mm a'),
            createdBy: result.createdBy,
            updatedOn: datePipe.transform(result.updatedOn, 'dd/MM/yyyy, h:mm a'),
            updatedBy: result.updatedBy
          });
        });
  }

  onSubmit() {
     this.apiService.updateArea(this.areaEditForm.value)
      .pipe(first())
      .subscribe(
        result => {
          if (result != null) {
            alert('Area updated successfully.');
            this.router.navigate(['area-list']);
          }
        });
  }

}









