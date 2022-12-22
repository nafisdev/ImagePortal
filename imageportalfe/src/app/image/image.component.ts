import { Component, Input, OnInit } from '@angular/core';
import { ImageProcessService } from 'src/service/image-process.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.scss']
})
export class ImageComponent implements OnInit {
  thumbnail: any;
  @Input() ImageData: any;
  ImageName: any;

  constructor(private imageService: ImageProcessService, private sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.ImageName = this.ImageData?.name;
    this.imageService.getData(this.ImageData?.path)
    .subscribe((baseImage : any) => {
      //alert(JSON.stringify(data.image));
      let objectURL = 'data:image/jpg;base64,' + baseImage;

       this.thumbnail = this.sanitizer.bypassSecurityTrustUrl(objectURL);
     
    });
  }

}
