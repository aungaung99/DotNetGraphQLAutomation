import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { Observable } from 'rxjs';
import {
  GET_ALL_BRANDS,
  GET_BRAND_BY_ID,
  CREATE_BRAND,
  UPDATE_BRAND,
  DELETE_BRAND
} from './brands.graphql';

@Injectable({ providedIn: 'root' })
export class BrandService {
  constructor(private apollo: Apollo) {}

  getAllBrands(filter?: string, sort?: string): Observable<any> {
    return this.apollo.watchQuery({
      query: GET_ALL_BRANDS,
      variables: { filter, sort }
    }).valueChanges;
  }

  getBrandById(id: number): Observable<any> {
    return this.apollo.watchQuery({
      query: GET_BRAND_BY_ID,
      variables: { id }
    }).valueChanges;
  }

  createBrand(input: any): Observable<any> {
    return this.apollo.mutate({
      mutation: CREATE_BRAND,
      variables: { input }
    });
  }

  updateBrand(input: any): Observable<any> {
    return this.apollo.mutate({
      mutation: UPDATE_BRAND,
      variables: { input }
    });
  }

  deleteBrand(id: number): Observable<any> {
    return this.apollo.mutate({
      mutation: DELETE_BRAND,
      variables: { id }
    });
  }
}
