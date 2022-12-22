import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { ImageProcessService } from 'src/service/image-process.service';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.scss']
})
export class UploadImageComponent implements OnInit {

  constructor(private imageService: ImageProcessService, private router: Router) { }
  baseUrl: string = environment.baseUrl;
  ngOnInit(): void {
  }

  handleFileInput(event: any)
  {
    const reader = new FileReader();
    const file = event.target.files[0];
    const imgData = new FormData();
    imgData.append("Image" , file);
    this.imageService.uploadImage(imgData).subscribe(x => 
      {
        this.router.navigateByUrl(`${this.baseUrl}/Image`);
      });
    
  }

}
