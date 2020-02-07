import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators';
import { ApiService } from '../core/api.service';
import { Router } from '@angular/router';
import { Area } from '../model/area.model';

@Component({
  selector: 'app-area-list',
  templateUrl: './area-list.component.html'
})
export class AreaListComponent {
  public area: Area[];
  filteredAreas: Area[];

  _searchFilter: string;
  get searchFilter(): string {
    return this._searchFilter;
  }
  set searchFilter(value: string) {
    this._searchFilter = value;
    this.filteredAreas = this.searchFilter ? this.performFilter(this.searchFilter) : this.area;
  }

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string,
    private apiService: ApiService,private router: Router) {
    http.get<Area[]>(baseUrl + 'Areas').subscribe(result => {
      this.area = result;
      this.filteredAreas = result;
    }, error => console.error(error));
  }

  performFilter(filterBy: string): Area[] {
      filterBy = filterBy.toLocaleLowerCase();
      return this.area.filter((area: Area) => area.name.toLocaleLowerCase().indexOf(filterBy) !== -1);
  }

  deleteProduct(area: Area): void {
    if (confirm("Are you sure to delete Area : " + area.name)) {
      this.apiService.deleteArea(area.id)
        .pipe(first())
        .subscribe(result => { });
    }
  }
}
