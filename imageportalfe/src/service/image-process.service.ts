import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ImageProcessService {
  baseUrl: string = environment.baseUrl;

  constructor(private http: HttpClient) { }
  uploadImage(req: any) {
    debugger;
    return this.http.post(`${this.baseUrl}/UploadImage`, req)
  }
}
