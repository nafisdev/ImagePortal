import { Component, OnChanges, OnInit } from '@angular/core';
import { ImageProcessService } from 'src/service/image-process.service';

@Component({
  selector: 'app-image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.scss']
})
export class ImageListComponent implements OnInit , OnChanges{
  items: any[]| any = [];

  constructor(private imageService: ImageProcessService) {
   }

  ngOnInit(): void {
    debugger;
    this.imageService.getImages().subscribe(
      data => {
          this.items = data;
      }
    );
  }
  ngOnChanges(): void {
    debugger;
    this.imageService.getImages().subscribe(
      data => {
          this.items = data;
      }
    );
  }

}
