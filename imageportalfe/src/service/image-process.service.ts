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
    return this.http.post(`${this.baseUrl}/UploadImage`, req)
  }
  getData(path: string) {
    return this.http.get(`${this.baseUrl}/GetImage/${path}`)
    // return this.http.get('/assets/config.json');
  }

  getImages() {
    return this.http.get(`${this.baseUrl}/GetImages`)
    // return this.http.get('/assets/config.json');
  }

}
