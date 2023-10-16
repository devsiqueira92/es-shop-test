import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ColorService {
  protected rootUrl = 'https://localhost:7054/api';
  constructor(protected httpClient: HttpClient) {}

  getColors() {
    return this.httpClient
      .get<any>(`${this.rootUrl}/color/`)
      .pipe(map((result: any) => result));
  }
}
