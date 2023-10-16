import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ShirtService {
  protected rootUrl = 'https://localhost:7054/api';
  constructor(protected httpClient: HttpClient) {}

  getShirts() {
    return this.httpClient
      .get<any>(`${this.rootUrl}/shirt/`)
      .pipe(map((result: any) => result));
  }

  getShirtsSpecification(id: string) {
    return this.httpClient
      .get<any>(`${this.rootUrl}/shirt-specification/${id}`)
      .pipe(map((result: any) => result));
  }
}
