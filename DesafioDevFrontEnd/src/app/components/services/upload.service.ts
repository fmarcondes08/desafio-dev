import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpErrorResponse, HttpEventType, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UploadService {
  SERVER_URL: string = "https://localhost:54169/";
  constructor(private http: HttpClient) { }

  uploadFile(file: File): Observable<HttpEvent<any>> {
    const formData: FormData = new FormData();

    formData.append('file', file);

    const req = new HttpRequest('PATCH', `${this.SERVER_URL}transaction/Import`, formData);

    return this.http.request(req);
  }

  getData(): Observable<any> {
    return this.http.get(`${this.SERVER_URL}`);
  }
}
