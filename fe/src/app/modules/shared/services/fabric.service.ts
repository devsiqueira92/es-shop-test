import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class FabricService {
  protected rootUrl = 'https://localhost:7054/api';
  constructor(protected httpClient: HttpClient) {}

  getFabrics() {
    return this.httpClient
      .get<any>(`${this.rootUrl}/fabric/`)
      .pipe(map((result: any) => result));
  }
}
